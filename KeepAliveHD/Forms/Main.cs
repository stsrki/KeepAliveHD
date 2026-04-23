#region Using Directives
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using KeepAliveHD.BaseClasses;
using Microsoft.Win32;
#endregion

namespace KeepAliveHD.Forms
{
    public partial class Main : Form
    {
        #region Members

        private enum EngineStatus
        {
            Stopped,
            Started,
        }

        private bool _timersEnabled = true;

        private SortedList<string, Timer> _timers = new SortedList<string, Timer>();

        private uint _idleTime = 0;

        private uint _disableWritingAfter = 0;

        private uint _disableReadingAfter = 0;

        private bool _userInactiveWriting = false;

        private bool _userInactiveReading = false;

        private bool _close = false;

        private bool _minimize = false;

        private bool _restoringFromTray = false;

        private DateTime? _resumedFromSleep = null;

        private bool _backgroundWorkPaused = false;

        private bool _restoreTimersAfterPause = false;

        private ManagementEventWatcher InsertWatcher;

        private ManagementEventWatcher RemoveWatcher;

        private Random _random = new Random( Guid.NewGuid().GetHashCode() );

        private readonly Timer _countdownTimer = new Timer();

        private const string DrivesNextRunColumnName = "DrivesNextRunText";

        #endregion

        #region Constructors

        public Main( bool minimize )
        {
            InitializeComponent();

            _minimize = minimize;
            _countdownTimer.Interval = 1000;
            _countdownTimer.Tick += CountdownTimer_Tick;
            chkShowCountdownTimer.CheckedChanged += chkShowCountdownTimer_CheckedChanged;
            chkTurnOffWhenUserInactiveReading.CheckedChanged += chkTurnOffWhenUserInactiveReading_CheckedChanged;
            numTimeAmountReading.ValueChanged += numTimeAmountReading_ValueChanged;
            cboTimeUnitReading.SelectedIndexChanged += cboTimeUnitReading_SelectedIndexChanged;
        }

        #endregion

        #region Events

        #region Form

        protected override void OnLoad( EventArgs e )
        {
            try
            {
                if ( _minimize )
                    this.WindowState = FormWindowState.Minimized;

                dgDrives.AutoGenerateColumns = dgConnectedDrives.AutoGenerateColumns = false;
                dgConnectedDrives.CellFormatting += dgConnectedDrives_CellFormatting;
                EnsureDriveCountdownColumn();

                Database.DatabaseManager.Load();

                cboTimeUnitWriting.Items.Add( new ComboBoxItem( "minutes", "m" ) );
                cboTimeUnitWriting.Items.Add( new ComboBoxItem( "hours", "h" ) );
                cboTimeUnitWriting.SelectedIndex = 0;
                cboTimeUnitReading.Items.Add( new ComboBoxItem( "minutes", "m" ) );
                cboTimeUnitReading.Items.Add( new ComboBoxItem( "hours", "h" ) );
                cboTimeUnitReading.SelectedIndex = 0;

                FillSettings();

                InitialiseTimers( this.WritingEnabled );

                LoadDrives();

                tsDrives.Visible = tsConnectedDrives.Visible = true;

                UpdateIdleMonitoringState();

                SetMinimizeMode();

                WqlEventQuery insertQuery = new WqlEventQuery( "SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_USBHub'" );
                InsertWatcher = new ManagementEventWatcher( insertQuery );
                InsertWatcher.EventArrived += new EventArrivedEventHandler( DeviceInsertedEvent );
                InsertWatcher.Start();

                WqlEventQuery removeQuery = new WqlEventQuery( "SELECT * FROM __InstanceDeletionEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_USBHub'" );
                RemoveWatcher = new ManagementEventWatcher( removeQuery );
                RemoveWatcher.EventArrived += new EventArrivedEventHandler( DeviceRemovedEvent );
                RemoveWatcher.Start();

                SystemEvents.PowerModeChanged += OnPowerChange;
                SystemEvents.SessionEnding += OnSessionEnding;

                var version = this.GetType().Assembly.GetName().Version;
                lblAppVersion.Text = string.Format( "{0}.{1}.{2} beta", version.Major, version.Minor, version.Build );
            }
            catch ( Exception exc )
            {
                LogManager.Write( exc.Message );
                MessageBox.Show( exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
            }

            base.OnLoad( e );
        }

        private void Main_FormClosing( object sender, FormClosingEventArgs e )
        {
            if ( e.CloseReason == CloseReason.UserClosing && chkMinimizeOnClose.Checked && !_close )
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                SetMinimizeMode();
                return;
            }

            PauseBackgroundWork( false );
        }

        private void Main_FormClosed( object sender, FormClosedEventArgs e )
        {
            try
            {
                if ( RemoveWatcher != null )
                {
                    RemoveWatcher.Stop();
                    RemoveWatcher.Dispose();
                }

                if ( InsertWatcher != null )
                {
                    InsertWatcher.Stop();
                    InsertWatcher.Dispose();
                }

                SystemEvents.PowerModeChanged -= OnPowerChange;
                SystemEvents.SessionEnding -= OnSessionEnding;
            }
            catch ( Exception exc )
            {
                LogManager.Write( exc.Message );
            }

            tmrIdle.Enabled = false;
            _countdownTimer.Enabled = false;
            _countdownTimer.Dispose();

            foreach ( var timer in _timers )
            {
                timer.Value.Enabled = false;
                timer.Value.Tick -= timer_Tick;
            }

            _timers.Clear();
        }

        private void tabMain_SelectedIndexChanged( object sender, EventArgs e )
        {
            if ( tabMain.SelectedTab == tabPageDriveInfo )
            {
                LoadConnectedDrives();
            }
        }

        private void Main_Resize( object sender, EventArgs e )
        {
            SetMinimizeMode();
        }

        private void ctxTrayShow_Click( object sender, EventArgs e )
        {
            ShowMainWindow();
        }

        private void ctxTrayClose_Click( object sender, EventArgs e )
        {
            _close = true;
            Close();
        }

        private void ntfTray_MouseUp( object sender, MouseEventArgs e )
        {
            if ( e.Button == MouseButtons.Left )
            {
                ShowMainWindow();
            }
            else if ( e.Button == MouseButtons.Right )
            {
                ntfTray.ContextMenuStrip = ctxTray;
                MethodInfo mi = typeof( NotifyIcon ).GetMethod( "ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic );
                mi.Invoke( ntfTray, null );
            }
        }

        private void btnConnectedDriveRefresh_Click( object sender, EventArgs e )
        {
            LoadConnectedDrives();
        }

        private void lnkHomepage_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            OpenWithShell( "https://github.com/stsrki/keepalivehd" );
        }

        private void lnkIssues_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            OpenWithShell( "https://github.com/stsrki/keepalivehd/issues" );
        }

        private void lnkDonations_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            OpenWithShell( "https://www.patreon.com/mladenmacanovic" );
        }

        private void btnOpenLogDir_Click( object sender, EventArgs e )
        {
            try
            {
                string directory = Path.GetDirectoryName( LogManager.LogFullPath );

                if ( Directory.Exists( directory ) )
                    OpenWithShell( directory );
            }
            catch
            {
            }
        }

        #endregion

        #region Timers

        private void InitialiseTimers( bool enabled )
        {
            var driveInfoList = Database.DatabaseManager.GetAll();

            foreach ( var driveInfo in driveInfoList )
            {
                driveInfo.Connected = Directory.Exists( driveInfo.Drive );

                if ( !_timers.ContainsKey( driveInfo.Drive ) )
                {
                    _timers.Add( driveInfo.Drive, new Timer() );

                    _timers[driveInfo.Drive].Tick += new EventHandler( timer_Tick );
                }

                Timer timer = _timers[driveInfo.Drive];
                timer.Tag = driveInfo;

                switch ( driveInfo.TimeUnit )
                {

                    case "s":
                        timer.Interval = driveInfo.TimeInterval * 1000;
                        break;
                    case "m":
                        timer.Interval = ( driveInfo.TimeInterval * 60 ) * 1000;
                        break;
                    case "h":
                        timer.Interval = ( driveInfo.TimeInterval * 60 * 60 ) * 1000;
                        break;
                    default:
                        timer.Interval = ( driveInfo.TimeInterval * 60 ) * 1000; // minutes by default
                        break;
                }

                bool driveEnabled = IsDriveOperationEnabled( driveInfo, enabled );

                if ( driveEnabled )
                {
                    ManageDriveOperation( driveInfo );
                    ScheduleNextRun( timer, driveInfo );
                }
                else
                    driveInfo.NextRunAt = null;

                timer.Enabled = driveEnabled;
            }

            _timersEnabled = driveInfoList.Any( x => IsDriveOperationEnabled( x, enabled ) );

            if ( enabled )
            {
                var activeDriveInfoList = driveInfoList.Where( x => IsDriveOperationEnabled( x, enabled ) ).ToList();

                if ( activeDriveInfoList.Count == 0 )
                    ntfTray.Icon = Properties.Resources.tray_normal;
                else if ( activeDriveInfoList.All( x => x.Status == 1 && x.Connected ) )
                    ntfTray.Icon = Properties.Resources.tray_good;
                else if ( activeDriveInfoList.All( x => x.Connected == false ) )
                    ntfTray.Icon = Properties.Resources.tray_disabled;
                else
                    ntfTray.Icon = Properties.Resources.tray_partial;
            }
            else
                ntfTray.Icon = Properties.Resources.tray_normal;
        }

        private void RemoveTimer( params string[] drives )
        {
            foreach ( string drive in drives )
            {
                if ( _timers.ContainsKey( drive ) )
                {
                    Timer timer = _timers[drive];
                    timer.Enabled = false;
                    timer.Tick -= timer_Tick;
                    _timers.Remove( drive );
                }
            }
        }

        void timer_Tick( object sender, EventArgs e )
        {
            if ( sender != null && sender is Timer )
            {
                Timer timer = sender as Timer;

                if ( timer.Tag != null && timer.Tag is Database.DriveInfo )
                {
                    Database.DriveInfo driveInfo = timer.Tag as Database.DriveInfo;

                    ManageDriveOperation( driveInfo );
                    ScheduleNextRun( timer, driveInfo );
                }
            }
        }

        private void ManageDriveOperation( Database.DriveInfo driveInfo )
        {
            if ( _backgroundWorkPaused )
                return;

            string drivePath = Helpers.NormalizeDrivePath( driveInfo.Drive );
            bool previousConnected = driveInfo.Connected;

            if ( _resumedFromSleep != null )
            {
                if ( ( DateTime.Now - _resumedFromSleep.Value ).TotalSeconds > 15 )
                    _resumedFromSleep = null;
                else
                    return;
            }

            string volumeName = string.Empty;
            bool ignoreVolumeNames = AppConfiguration.IgnoreVolumeNames;

            try
            {
                if ( !ignoreVolumeNames )
                    volumeName = Helpers.GetVolumeIdentity( drivePath );
            }
            catch ( Exception exc )
            {
                LogManager.Write( "Failed to resolve volume identity for '{0}': {1}", drivePath, exc.Message );
            }

            if ( Directory.Exists( drivePath ) && ( ignoreVolumeNames == true || ( ignoreVolumeNames == false && driveInfo.VolumeNames.Contains( volumeName ) ) ) )
            {
                try
                {
                    if ( driveInfo.Operation == "r" )
                    {
                        var fileNames = Directory.EnumerateFiles( drivePath, "*.*" ).Take( 5 ).ToList();

                        if ( fileNames != null && fileNames.Count > 0 )
                        {
                            // get random file
                            var fileName = fileNames[_random.Next( fileNames.Count )];

                            if ( fileName != null )
                            {
                                if ( File.Exists( fileName ) )
                                {
                                    using ( var reader = File.OpenRead( fileName ) )
                                    {
                                        // make sure that file is at least on byte long
                                        if ( reader.Length > 1 )
                                        {
                                            // read random byte from the file
                                            var maxOffset = reader.Length > int.MaxValue ? int.MaxValue : (int)reader.Length;
                                            var offset = _random.Next( maxOffset );

                                            //LogManager.Write( "Read one byte at location {0} from file '{1}'", offset, fileName );

                                            reader.Seek( offset, SeekOrigin.Begin );

                                            var data = new byte[1];
                                            reader.ReadExactly( data, 0, 1 );
                                        }
                                    }
                                }
                            }
                        }

                        driveInfo.Connected = true;
                    }
                    else
                    {
                        var fileName = Helpers.GetKeepAliveFilePath( drivePath );

                        using ( var writer = new StreamWriter( fileName, false, Encoding.ASCII ) )
                        {
                            writer.Write( "This file was generated by KeepAliveHD application on " + DateTime.Now.ToString() );
                        }

                        driveInfo.Connected = true;

                        if ( AppConfiguration.DeleteTextFile )
                        {
                            if ( File.Exists( fileName ) )
                            {
                                File.Delete( fileName );
                            }
                        }
                    }
                }
                catch ( Exception exc )
                {
                    LogDriveOperationError( driveInfo, drivePath, exc );
                }
            }
            else
            {
                driveInfo.Connected = false;
            }

            if ( previousConnected != driveInfo.Connected )
                RefreshDriveStatus();
        }

        private void tmrIdle_Tick( object sender, EventArgs e )
        {
            // Get the system uptime
            int systemUptime = Environment.TickCount;
            // The tick at which the last input was recorded
            uint LastInputTicks = 0;
            // The number of ticks that passed since last input
            uint IdleTicks = 0;

            // Set the struct
            NativeMethods.LASTINPUTINFO LastInputInfo = new NativeMethods.LASTINPUTINFO();
            LastInputInfo.cbSize = (uint)Marshal.SizeOf( LastInputInfo );
            LastInputInfo.dwTime = 0;

            // If we have a value from the function
            if ( NativeMethods.GetLastInputInfo( ref LastInputInfo ) )
            {
                // Get the number of ticks at the point when the last activity was seen
                LastInputTicks = LastInputInfo.dwTime;
                // Number of idle ticks = system uptime ticks - number of ticks at last input
                IdleTicks = (uint)systemUptime - LastInputTicks;
            }

            // divide by 1000 to transform the milliseconds to seconds and by 60 to convert to minutes
            _idleTime = ( IdleTicks / 1000 );

            bool shouldPauseWriting = chkTurnOffWhenUserInactiveWriting.Checked && _disableWritingAfter > 0 && _idleTime >= _disableWritingAfter;
            bool shouldPauseReading = chkTurnOffWhenUserInactiveReading.Checked && _disableReadingAfter > 0 && _idleTime >= _disableReadingAfter;

            if ( shouldPauseWriting != _userInactiveWriting || shouldPauseReading != _userInactiveReading )
            {
                _userInactiveWriting = shouldPauseWriting;
                _userInactiveReading = shouldPauseReading;
                InitialiseTimers( this.WritingEnabled );
            }

            //this.Text = _iIdleTime.ToString();
        }

        #endregion

        #region Drive manage

        private void dgDrives_CellMouseDoubleClick( object sender, DataGridViewCellMouseEventArgs e )
        {
            if ( e.ColumnIndex < 0 || e.RowIndex < 0 || e.ColumnIndex > dgDrives.Columns.Count || e.RowIndex > dgDrives.Rows.Count )
                return;

            ProcessDialogKey( Keys.F3 );
        }

        private void dgDrives_KeyDown( object sender, KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                ProcessDialogKey( Keys.F3 );
            }
        }

        private void dgDrives_SelectionChanged( object sender, EventArgs e )
        {
            if ( dgDrives.SelectedRows.Count == 0 )
            {
            }
            else
            {
                DataGridViewRow row = dgDrives.SelectedRows[0];
                row.DefaultCellStyle.SelectionForeColor = GetDriveRowColor( row );
            }

            SetDrivesEditMode();
        }

        private void dgDrives_RowsAdded( object sender, DataGridViewRowsAddedEventArgs e )
        {
            foreach ( DataGridViewRow row in dgDrives.Rows )
                row.DefaultCellStyle.ForeColor = GetDriveRowColor( row );
        }

        private void dgConnectedDrives_SelectionChanged( object sender, EventArgs e )
        {
            btnDriveNewMulti.Enabled = dgConnectedDrives.SelectedRows.Count > 0;
        }

        private void btnDriveNew_Click( object sender, EventArgs e )
        {
            ManageDrivesNew();
        }

        private void btnDriveNewMulti_Click( object sender, EventArgs e )
        {
            ManageDrivesNewMulti();
        }

        private void btnDriveEdit_Click( object sender, EventArgs e )
        {
            ManageDrivesEdit();
        }

        private void btnDriveEdit_ButtonClick( object sender, EventArgs e )
        {
            ManageDrivesEdit();
        }

        private void btnDriveDelete_Click( object sender, EventArgs e )
        {
            ManageDrivesDelete();
        }

        private void btnDriveVolumeNamesEdit_Click( object sender, EventArgs e )
        {
            ManageVolumeNamesEdit();
        }

        #endregion

        #region System

        private void btnEngineStart_Click( object sender, EventArgs e )
        {
            SetEngineStatus( EngineStatus.Started );

            AppConfiguration.WritingEnabled = true;
            InitialiseTimers( this.WritingEnabled );
            LoadDrives();
        }

        private void btnEngineStop_Click( object sender, EventArgs e )
        {
            SetEngineStatus( EngineStatus.Stopped );

            AppConfiguration.WritingEnabled = false;
            InitialiseTimers( this.WritingEnabled );
            LoadDrives();
        }

        private void chkSystemAutoRun_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkSystemAutoRun.ContainsFocus )
                AppConfiguration.AutoRunOnStartup = chkSystemAutoRun.Checked;
        }

        private void chkSystemHideInTray_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkSystemHideInTray.ContainsFocus )
                AppConfiguration.HideInTray = chkSystemHideInTray.Checked;
        }

        private void chkMinimizeOnClose_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkMinimizeOnClose.ContainsFocus )
                AppConfiguration.MinimizeOnClose = chkMinimizeOnClose.Checked;
        }

        private void chkHideTrayIcon_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkHideTrayIcon.ContainsFocus )
                AppConfiguration.HideTrayIcon = chkHideTrayIcon.Checked;
        }

        private void chkStartMinimized_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkStartMinimized.ContainsFocus )
                AppConfiguration.StartMinimized = chkStartMinimized.Checked;
        }

        private void chkTurnOffWhenUserInactiveWriting_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkTurnOffWhenUserInactiveWriting.ContainsFocus )
                AppConfiguration.TurnOffWhenUserInactive = chkTurnOffWhenUserInactiveWriting.Checked;

            UpdateIdleMonitoringState();
        }

        private void chkTurnOffWhenUserInactiveReading_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkTurnOffWhenUserInactiveReading.ContainsFocus )
                AppConfiguration.TurnOffReadingWhenUserInactive = chkTurnOffWhenUserInactiveReading.Checked;

            UpdateIdleMonitoringState();
        }

        private void chkDeleteTextFile_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkDeleteTextFile.ContainsFocus )
                AppConfiguration.DeleteTextFile = chkDeleteTextFile.Checked;
        }

        private void chkIgnoreVolumeNames_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkIgnoreVolumeNames.ContainsFocus )
                AppConfiguration.IgnoreVolumeNames = chkIgnoreVolumeNames.Checked;
        }

        private void chkLogMessages_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkLogMessages.ContainsFocus )
                AppConfiguration.LogMessages = chkLogMessages.Checked;
        }

        private void numTimeAmountWriting_ValueChanged( object sender, EventArgs e )
        {
            if ( numTimeAmountWriting.ContainsFocus )
            {
                AppConfiguration.TurnOffWhenUserInactiveTimeInterval = (int)numTimeAmountWriting.Value;
            }

            string sTimeUnit = ( (ComboBoxItem)cboTimeUnitWriting.SelectedItem ).Value;
            int iTimeAmount = (int)numTimeAmountWriting.Value;

            // convert minutes/hours into seconds
            _disableWritingAfter = (uint)( sTimeUnit == "m" ? iTimeAmount : ( iTimeAmount * 60 ) ) * 60;

            if ( IdleMonitoringEnabled )
                InitialiseTimers( this.WritingEnabled );
        }

        private void cboTimeUnitWriting_SelectedIndexChanged( object sender, EventArgs e )
        {
            if ( cboTimeUnitWriting.ContainsFocus )
            {
                AppConfiguration.TurnOffWhenUserInactiveTimeUnit = ( (ComboBoxItem)cboTimeUnitWriting.SelectedItem ).Value;
            }

            numTimeAmountWriting_ValueChanged( null, null );
        }

        private void numTimeAmountReading_ValueChanged( object sender, EventArgs e )
        {
            if ( numTimeAmountReading.ContainsFocus )
                AppConfiguration.TurnOffReadingWhenUserInactiveTimeInterval = (int)numTimeAmountReading.Value;

            string sTimeUnit = ( (ComboBoxItem)cboTimeUnitReading.SelectedItem ).Value;
            int iTimeAmount = (int)numTimeAmountReading.Value;

            _disableReadingAfter = (uint)( sTimeUnit == "m" ? iTimeAmount : ( iTimeAmount * 60 ) ) * 60;

            if ( IdleMonitoringEnabled )
                InitialiseTimers( this.WritingEnabled );
        }

        private void cboTimeUnitReading_SelectedIndexChanged( object sender, EventArgs e )
        {
            if ( cboTimeUnitReading.ContainsFocus )
                AppConfiguration.TurnOffReadingWhenUserInactiveTimeUnit = ( (ComboBoxItem)cboTimeUnitReading.SelectedItem ).Value;

            numTimeAmountReading_ValueChanged( null, null );
        }

        private void chkDelayWriteOnResume_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkDelayWriteOnResume.ContainsFocus )
                AppConfiguration.DelayWriteOnSystemResume = chkDelayWriteOnResume.Checked;
        }

        private void chkShowCountdownTimer_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkShowCountdownTimer.ContainsFocus )
                AppConfiguration.ShowCountdownTimer = chkShowCountdownTimer.Checked;

            ApplyCountdownTimerVisibility();
        }

        #endregion

        #region Windows

        private void DeviceInsertedEvent( object sender, EventArrivedEventArgs e )
        {
            try
            {
                InvokeGUIThread( () =>
                {
                    InitialiseTimers( this.WritingEnabled );
                    LoadDrives( SelectedDriveID );
                } );
            }
            catch ( Exception exc )
            {
                LogManager.Write( exc.Message );
            }
        }

        void DeviceRemovedEvent( object sender, EventArrivedEventArgs e )
        {
            try
            {
                InvokeGUIThread( () =>
                {
                    InitialiseTimers( this.WritingEnabled );
                    LoadDrives( SelectedDriveID );
                } );
            }
            catch ( Exception exc )
            {
                LogManager.Write( exc.Message );
            }
        }

        private void OnPowerChange( object s, PowerModeChangedEventArgs e )
        {
            switch ( e.Mode )
            {
                case PowerModes.Resume:
                    _backgroundWorkPaused = false;

                    if ( _restoreTimersAfterPause && this.WritingEnabled )
                        InitialiseTimers( this.WritingEnabled );
                    else
                    {
                        foreach ( var timer in _timers.Values )
                            timer.Enabled = false;
                    }

                    tmrIdle.Enabled = IdleMonitoringEnabled;
                    _restoreTimersAfterPause = false;

                    if ( AppConfiguration.DelayWriteOnSystemResume )
                        _resumedFromSleep = DateTime.Now;
                    break;
                case PowerModes.Suspend:
                    PauseBackgroundWork( true );
                    break;
            }
        }

        private void OnSessionEnding( object sender, SessionEndingEventArgs e )
        {
            PauseBackgroundWork( false );
        }

        #endregion

        #endregion

        #region Methods

        #region Data

        private void LoadDrives()
        {
            LoadDrives( -1 );
        }

        private void LoadDrives( int iID )
        {
            Database.DatabaseManager.FillDrives( dgDrives, x => IsDriveOperationEnabled( x ) );
            Helpers.SelectRowByValue( dgDrives, DrivesID.Index, iID.ToString() );

            if ( dgDrives.SelectedRows.Count == 0 && dgDrives.Rows.Count > 0 )
                dgDrives.Rows[0].Selected = true;

            SetDrivesEditMode();
            ApplyCountdownTimerVisibility();
        }

        private void LoadConnectedDrives()
        {
            try
            {
                // get only the devices that are ready
                var drives = System.IO.DriveInfo.GetDrives().Where( x => x.IsReady ).ToList();

                dgConnectedDrives.DataSource = Helpers.LINQToDataTable(
                    ( from d in drives
                      where
                      ( d.DriveType == DriveType.Fixed && ( d.DriveFormat == "NTFS" || d.DriveFormat == "FAT32" ) )
                      ||
                      ( d.DriveType == DriveType.Removable && ( d.DriveFormat == "NTFS" || d.DriveFormat == "FAT32" ) )
                      orderby d.RootDirectory.FullName ascending
                      select new
                      {
                          Drive = d.RootDirectory == null ? string.Empty : d.RootDirectory.FullName,
                          VolumeName = d.VolumeLabel,
                          TotalSize = d.TotalSize,
                          FreeSpace = d.TotalFreeSpace,
                          d.DriveType
                      } ).ToList() );
            }
            catch ( Exception exc )
            {
                LogManager.Write( exc.Message );
                MessageBox.Show( exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
            }
        }

        #endregion

        #region Other

        private void FillSettings()
        {
            chkSystemAutoRun.Checked = AppConfiguration.AutoRunOnStartup;
            chkSystemHideInTray.Checked = AppConfiguration.HideInTray;
            chkMinimizeOnClose.Checked = AppConfiguration.MinimizeOnClose;
            numTimeAmountWriting.Value = AppConfiguration.TurnOffWhenUserInactiveTimeInterval;
            Helpers.SelectItemValue( cboTimeUnitWriting, AppConfiguration.TurnOffWhenUserInactiveTimeUnit );
            numTimeAmountReading.Value = AppConfiguration.TurnOffReadingWhenUserInactiveTimeInterval;
            Helpers.SelectItemValue( cboTimeUnitReading, AppConfiguration.TurnOffReadingWhenUserInactiveTimeUnit );
            chkTurnOffWhenUserInactiveWriting.Checked = AppConfiguration.TurnOffWhenUserInactive;
            chkTurnOffWhenUserInactiveReading.Checked = AppConfiguration.TurnOffReadingWhenUserInactive;
            chkDeleteTextFile.Checked = AppConfiguration.DeleteTextFile;
            chkIgnoreVolumeNames.Checked = AppConfiguration.IgnoreVolumeNames;
            chkLogMessages.Checked = AppConfiguration.LogMessages;
            chkStartMinimized.Checked = AppConfiguration.StartMinimized;
            chkDelayWriteOnResume.Checked = AppConfiguration.DelayWriteOnSystemResume;
            chkShowCountdownTimer.Checked = AppConfiguration.ShowCountdownTimer;

            SetEngineStatus( this.WritingEnabled ? EngineStatus.Started : EngineStatus.Stopped );

            UpdateIdleMonitoringState();
            ApplyCountdownTimerVisibility();
        }

        private void UpdateIdleMonitoringState()
        {
            bool enabled = IdleMonitoringEnabled;

            tmrIdle.Enabled = enabled;
            numTimeAmountWriting.Enabled = cboTimeUnitWriting.Enabled = chkTurnOffWhenUserInactiveWriting.Checked;
            numTimeAmountReading.Enabled = cboTimeUnitReading.Enabled = chkTurnOffWhenUserInactiveReading.Checked;

            if ( !enabled )
            {
                _userInactiveWriting = false;
                _userInactiveReading = false;
            }

            if ( IsHandleCreated )
                InitialiseTimers( this.WritingEnabled );
        }

        private void SetEngineStatus( EngineStatus status )
        {
            btnEngineStart.Visible = status == EngineStatus.Stopped;
            btnEngineStop.Visible = lblStatus.Visible = status == EngineStatus.Started;
        }

        private void SetMinimizeMode()
        {
            if ( !_restoringFromTray && this.WindowState == FormWindowState.Minimized && chkSystemHideInTray.Checked == true )
            {
                ntfTray.Visible = true;
                ntfTray.BalloonTipText = "KeepAliveHD";
                ntfTray.Text = "KeepAliveHD";
                this.ShowInTaskbar = false;
                this.Hide();
            }
        }

        private void ShowMainWindow()
        {
            _restoringFromTray = true;

            try
            {
                ntfTray.Visible = false;
                ShowInTaskbar = true;
                Visible = true;
                Show();
                WindowState = FormWindowState.Normal;
                BringToFront();
                Activate();
            }
            finally
            {
                BeginInvoke( new Action( () =>
                {
                    _restoringFromTray = false;
                    BringToFront();
                    Activate();
                } ) );
            }
        }

        private void RefreshDriveStatus()
        {
            if ( !IsHandleCreated || IsDisposed )
                return;

            LoadDrives( SelectedDriveID );
        }

        private void LogDriveOperationError( Database.DriveInfo driveInfo, string drivePath, Exception exc )
        {
            string operation = driveInfo.Operation == "r" ? "read" : "write";
            string targetPath = driveInfo.Operation == "r" ? drivePath : Helpers.GetKeepAliveFilePath( drivePath );

            LogManager.Write( "Drive '{0}' {1} failed for '{2}': {3}", drivePath, operation, targetPath, exc.Message );
        }

        private bool IsDriveOperationEnabled( Database.DriveInfo driveInfo )
        {
            return IsDriveOperationEnabled( driveInfo, this.WritingEnabled );
        }

        private bool IsDriveOperationEnabled( Database.DriveInfo driveInfo, bool engineEnabled )
        {
            if ( driveInfo == null || !engineEnabled || driveInfo.Status != 1 )
                return false;

            if ( driveInfo.Operation == "r" )
                return !_userInactiveReading;

            return !_userInactiveWriting;
        }

        private Color GetDriveRowColor( DataGridViewRow row )
        {
            if ( row == null || row.Cells[DriveStatus.Index].Value == null )
                return Color.Black;

            if ( row.Cells[DriveStatus.Index].Value.ToString() == "0" )
                return Color.Black;

            string drive = Convert.ToString( row.Cells[DrivesLetter.Index].Value );
            var driveInfo = Database.DatabaseManager.GetByDrive( drive );

            return driveInfo != null && IsDriveOperationEnabled( driveInfo ) ? Color.Green : Color.Blue;
        }

        private void ApplyCountdownTimerVisibility()
        {
            bool visible = chkShowCountdownTimer.Checked;

            if ( dgDrives.Columns.Contains( DrivesNextRunColumnName ) )
                dgDrives.Columns[DrivesNextRunColumnName].Visible = visible;

            _countdownTimer.Enabled = visible;

            if ( visible )
                RefreshDriveCountdowns();
        }

        private void EnsureDriveCountdownColumn()
        {
            if ( dgDrives.Columns.Contains( DrivesNextRunColumnName ) )
                return;

            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.Name = DrivesNextRunColumnName;
            column.DataPropertyName = "NextRunText";
            column.HeaderText = "Next Run";
            column.ReadOnly = true;
            column.Width = 80;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgDrives.Columns.Insert( DriveStatusText.Index, column );
        }

        private void ScheduleNextRun( Timer timer, Database.DriveInfo driveInfo )
        {
            if ( driveInfo == null )
                return;

            if ( timer == null )
            {
                driveInfo.NextRunAt = null;
                return;
            }

            driveInfo.NextRunAt = DateTime.Now.AddMilliseconds( timer.Interval );
        }

        private void CountdownTimer_Tick( object sender, EventArgs e )
        {
            RefreshDriveCountdowns();
        }

        private void RefreshDriveCountdowns()
        {
            if ( IsDisposed || !IsHandleCreated || dgDrives.Rows.Count == 0 || !dgDrives.Columns.Contains( DrivesNextRunColumnName ) )
                return;

            DateTime now = DateTime.Now;
            int nextRunColumnIndex = dgDrives.Columns[DrivesNextRunColumnName].Index;

            foreach ( DataGridViewRow row in dgDrives.Rows )
            {
                string drive = Convert.ToString( row.Cells[DrivesLetter.Index].Value );
                var driveInfo = Database.DatabaseManager.GetByDrive( drive );

                if ( driveInfo != null )
                    row.Cells[nextRunColumnIndex].Value = Database.DatabaseManager.GetNextRunText( driveInfo, IsDriveOperationEnabled( driveInfo ), now );
            }
        }

        private void PauseBackgroundWork( bool rememberTimerState )
        {
            if ( rememberTimerState )
                _restoreTimersAfterPause = _timersEnabled;
            else
                _restoreTimersAfterPause = false;

            _backgroundWorkPaused = true;
            tmrIdle.Enabled = false;

            foreach ( var timer in _timers.Values )
                timer.Enabled = false;

            foreach ( var driveInfo in Database.DatabaseManager.GetAll() )
                driveInfo.NextRunAt = null;
        }

        private static void OpenWithShell( string target )
        {
            Process.Start( new ProcessStartInfo
            {
                FileName = target,
                UseShellExecute = true
            } );
        }

        private void SetDrivesEditMode()
        {
            btnDriveEdit.Enabled = dgDrives.SelectedRows.Count == 1; // enable edit only when one drive is selected
            btnDriveDelete.Enabled = dgDrives.SelectedRows.Count > 0;
        }

        /// <summary>
        /// The controls of the Windows Form applications can only be modified on the GUI thread. This method grants access to the GUI thread.
        /// </summary>
        /// <param name="action"></param>
        private void InvokeGUIThread( Action action )
        {
            this.Invoke( action );
        }

        private void dgConnectedDrives_CellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
        {
            if ( e.RowIndex < 0 )
                return;

            if ( e.ColumnIndex != InfoTotalSize.Index && e.ColumnIndex != InfoFreeSpace.Index )
                return;

            if ( e.Value == null || e.Value == DBNull.Value )
                return;

            try
            {
                e.Value = Helpers.ToFileSize( Convert.ToInt64( e.Value ) );
                e.FormattingApplied = true;
            }
            catch ( Exception exc )
            {
                LogManager.Write( "Failed to format disk size: " + exc.Message );
            }
        }

        protected override void WndProc( ref Message m )
        {
            if ( m.Msg == NativeMethods.WM_SHOWME )
            {
                ShowMainWindow();
                return;
            }

            base.WndProc( ref m );
        }

        #endregion

        #region Editing

        #region Drives

        private void ManageDrivesNew()
        {
            try
            {
                using ( var form = new DriveSettings( 0 ) )
                {
                    if ( form.ShowDialog() == DialogResult.OK )
                    {
                        InitialiseTimers( this.WritingEnabled );
                        LoadDrives( form.DriveInfoID );
                    }
                }
            }
            catch ( Exception exc )
            {
                LogManager.Write( exc.Message );
                MessageBox.Show( exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
            }
        }

        private void ManageDrivesNewMulti()
        {
            try
            {
                if ( dgConnectedDrives.SelectedRows.Count > 0 )
                {
                    List<string> drives = new List<string>();

                    foreach ( DataGridViewRow row in dgConnectedDrives.SelectedRows )
                    {
                        drives.Add( Convert.ToString( row.Cells[InfoDrive.Name].Value ) );
                    }

                    using ( var form = new DriveSettingsMulti( drives ) )
                    {
                        if ( form.ShowDialog() == DialogResult.OK )
                        {
                            InitialiseTimers( this.WritingEnabled );
                            LoadDrives( form.DriveInfoID );
                        }
                    }
                }
            }
            catch ( Exception exc )
            {
                LogManager.Write( exc.Message );
                MessageBox.Show( exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
            }
        }

        private void ManageDrivesEdit()
        {
            try
            {
                if ( dgDrives.SelectedRows.Count == 1 )
                {
                    int id = SelectedDriveID;

                    using ( var form = new DriveSettings( id ) )
                    {
                        if ( form.ShowDialog() == DialogResult.OK )
                        {
                            InitialiseTimers( this.WritingEnabled );
                            LoadDrives( form.DriveInfoID );
                        }
                    }
                }
            }
            catch ( Exception exc )
            {
                LogManager.Write( exc.Message );
                MessageBox.Show( exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
            }
        }

        private void ManageDrivesDelete()
        {
            try
            {
                if ( dgDrives.SelectedRows.Count > 0 )
                {
                    if ( MessageBox.Show( "Are you sure you want to remove the selected drive(s)?", "Confirm remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1 ) == DialogResult.Yes )
                    {
                        List<int> driveIDs = new List<int>();
                        List<string> driveNames = new List<string>();

                        foreach ( DataGridViewRow row in dgDrives.SelectedRows )
                        {
                            driveIDs.Add( Convert.ToInt32( row.Cells[DrivesID.Index].Value.ToString().Trim() ) );
                            driveNames.Add( row.Cells[DrivesLetter.Index].Value.ToString().Trim() );
                        }

                        if ( Database.DatabaseManager.Delete( driveIDs.ToArray() ) )
                        {
                            RemoveTimer( driveNames.ToArray() );
                            InitialiseTimers( this.WritingEnabled );
                            LoadDrives();
                        }
                    }
                }
            }
            catch ( Exception exc )
            {
                LogManager.Write( exc.Message );
                MessageBox.Show( exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
            }
        }

        #endregion

        #region VolumeNames

        private void ManageVolumeNamesEdit()
        {
            try
            {
                if ( dgDrives.SelectedRows.Count > 0 )
                {
                    int id = SelectedDriveID;

                    using ( var form = new VolumeNames( id ) )
                    {
                        if ( form.ShowDialog() == DialogResult.OK )
                        {
                            InitialiseTimers( this.WritingEnabled );
                            LoadDrives( id );
                        }
                    }
                }
            }
            catch ( Exception exc )
            {
                LogManager.Write( exc.Message );
                MessageBox.Show( exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
            }
        }

        #endregion

        #endregion

        #region Keys

        protected override bool ProcessDialogKey( Keys keyData )
        {
            if ( keyData == Keys.Escape )
            {
                this.WindowState = FormWindowState.Minimized;
                SetMinimizeMode();
            }
            else if ( dgDrives.ContainsFocus && dgDrives.SelectedRows.Count > 0 && keyData == Keys.F3 )
            {
                ManageDrivesEdit();
            }
            else if ( dgDrives.ContainsFocus && dgDrives.SelectedRows.Count > 0 && keyData == Keys.Delete )
            {
                ManageDrivesDelete();
            }

            return base.ProcessDialogKey( keyData );
        }

        #endregion

        #endregion

        #region Properties

        private int SelectedDriveID
        {
            get
            {
                if ( dgDrives.SelectedRows.Count == 0 )
                    return 0;

                return Convert.ToInt32( dgDrives.SelectedRows[0].Cells[DrivesID.Index].Value.ToString() );
            }
        }

        private bool IdleMonitoringEnabled
        {
            get
            {
                return chkTurnOffWhenUserInactiveWriting.Checked || chkTurnOffWhenUserInactiveReading.Checked;
            }
        }

        private bool WritingEnabled
        {
            get
            {
                return AppConfiguration.WritingEnabled;
            }
        }

        #endregion
    }
}