#region Using Directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private uint _disableTimersAfter = 0;

        private bool _close = false;

        private bool _minimize = false;

        private DateTime? _resumedFromSleep = null;

        private ManagementEventWatcher InsertWatcher;

        private ManagementEventWatcher RemoveWatcher;

        private Random _random = new Random( Guid.NewGuid().GetHashCode() );

        private bool _startedFromTaskScheduler = false;

        #endregion

        #region Constructors

        public Main( bool minimize )
        {
            InitializeComponent();

            _minimize = minimize;

            _startedFromTaskScheduler = Directory.GetCurrentDirectory() != Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location );
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

                Database.DatabaseManager.Load();

                cboTimeUnit.Items.Add( new ComboBoxItem( "minutes", "m" ) );
                cboTimeUnit.Items.Add( new ComboBoxItem( "hours", "h" ) );
                cboTimeUnit.SelectedIndex = 0;

                FillSettings();

                InitialiseTimers( this.WritingEnabled );

                LoadDrives();

                tsDrives.Visible = tsConnectedDrives.Visible = true;

                tmrIdle.Enabled = chkTurnOffWhenUserInactive.Checked;
                numTimeAmount.Enabled = cboTimeUnit.Enabled = chkTurnOffWhenUserInactive.Checked;

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
            }
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
            }
            catch ( Exception exc )
            {
                LogManager.Write( exc.Message );
            }

            tmrIdle.Enabled = false;

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
            ntfTray.Visible = false;
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.Show();
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
                ntfTray.Visible = false;
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                this.Show();
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
            Process.Start( "https://github.com/stsrki/keepalivehd" );
        }

        private void lnkIssues_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            Process.Start( "https://github.com/stsrki/keepalivehd/issues" );
        }

        private void lnkDonations_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            Process.Start( "https://www.patreon.com/mladenmacanovic" );
        }

        private void btnOpenLogDir_Click( object sender, EventArgs e )
        {
            try
            {
                string directory = Path.GetDirectoryName( LogManager.LogFullPath );

                if ( Directory.Exists( directory ) )
                    Process.Start( new ProcessStartInfo { FileName = "explorer.exe", Arguments = directory, WindowStyle = ProcessWindowStyle.Normal } );
            }
            catch
            {
            }
        }

        #endregion

        #region Timers

        private void InitialiseTimers( bool enabled )
        {
            _timersEnabled = enabled;

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

                if ( enabled && ( driveInfo.Status == 1 ) )
                    ManageDriveOperation( driveInfo );

                timer.Enabled = enabled && ( driveInfo.Status == 1 );
            }

            if ( enabled )
            {
                if ( driveInfoList.All( x => x.Status == 1 && x.Connected ) )
                    ntfTray.Icon = Properties.Resources.tray_good;
                else if ( driveInfoList.All( x => x.Connected == false ) )
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
                }
            }
        }

        private void ManageDriveOperation( Database.DriveInfo driveInfo )
        {
            if ( _resumedFromSleep != null )
            {
                if ( ( DateTime.Now - _resumedFromSleep.Value ).TotalSeconds > 15 )
                    _resumedFromSleep = null;
                else
                    return;
            }

            string volumeName = string.Empty;
            bool ignoreVolumeNames = ApplicationConfiguration.IgnoreVolumeNames;

            try
            {
                if ( !ignoreVolumeNames )
                    volumeName = ( new System.IO.DriveInfo( Path.GetPathRoot( driveInfo.Drive ) ) ).VolumeLabel;
            }
            catch ( Exception exc )
            {
                LogManager.Write( exc.Message );
            }

            if ( Directory.Exists( driveInfo.Drive ) && ( ignoreVolumeNames == true || ( ignoreVolumeNames == false && driveInfo.VolumeNames.Contains( volumeName ) ) ) )
            {
                try
                {
                    if ( driveInfo.Operation == "r" )
                    {
                        var fileNames = Directory.GetFiles( driveInfo.Drive, "*.*" ).Take( 5 ).ToList();

                        if ( fileNames != null && fileNames.Count > 0 )
                        {
                            // get random file
                            var fileName = fileNames[_random.Next( Math.Max( fileNames.Count - 1, 1 ) )];

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
                                            var offset = _random.Next( Math.Max( maxOffset - 1, 1 ) );

                                            //LogManager.Write( "Read one byte at location {0} from file '{1}'", offset, fileName );

                                            reader.Seek( offset, SeekOrigin.Begin );

                                            var data = new byte[1];
                                            reader.Read( data, 0, 1 );
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        var fileName = Path.Combine( Path.GetFullPath( driveInfo.Drive ), "KeepAliveHD.txt" );

                        using ( var writer = new StreamWriter( fileName, false, Encoding.ASCII ) )
                        {
                            writer.Write( "This file was generated by KeepAliveHD application on " + DateTime.Now.ToString() );
                        }

                        driveInfo.Connected = true;

                        if ( ApplicationConfiguration.DeleteTextFile )
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
                    LogManager.Write( exc.Message );
                }
            }
            else
            {
                driveInfo.Connected = false;
            }
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

            if ( _idleTime == 0 && _timersEnabled == false )
                InitialiseTimers( this.WritingEnabled );
            else if ( _idleTime >= _disableTimersAfter && _timersEnabled && chkTurnOffWhenUserInactive.Checked )
                InitialiseTimers( false );

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

                if ( row.Cells[DriveStatus.Index].Value.ToString() == "0" )
                    row.DefaultCellStyle.SelectionForeColor = Color.Black;
                else
                    row.DefaultCellStyle.SelectionForeColor = this.WritingEnabled ? Color.Green : Color.Blue;
            }

            SetDrivesEditMode();
        }

        private void dgDrives_RowsAdded( object sender, DataGridViewRowsAddedEventArgs e )
        {
            foreach ( DataGridViewRow row in dgDrives.Rows )
            {
                if ( row.Cells[DriveStatus.Index].Value.ToString() == "0" )
                    row.DefaultCellStyle.ForeColor = Color.Black;
                else
                    row.DefaultCellStyle.ForeColor = this.WritingEnabled ? Color.Green : Color.Blue;
            }
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

            ApplicationConfiguration.WritingEnabled = true;
            InitialiseTimers( this.WritingEnabled );
            LoadDrives();
        }

        private void btnEngineStop_Click( object sender, EventArgs e )
        {
            SetEngineStatus( EngineStatus.Stopped );

            ApplicationConfiguration.WritingEnabled = false;
            InitialiseTimers( this.WritingEnabled );
            LoadDrives();
        }

        private void chkSystemAutoRun_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkSystemAutoRun.ContainsFocus )
                ApplicationConfiguration.AutoRunOnStartup = chkSystemAutoRun.Checked;
        }

        private void chkSystemHideInTray_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkSystemHideInTray.ContainsFocus )
                ApplicationConfiguration.HideInTray = chkSystemHideInTray.Checked;
        }

        private void chkMinimizeOnClose_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkMinimizeOnClose.ContainsFocus )
                ApplicationConfiguration.MinimizeOnClose = chkMinimizeOnClose.Checked;
        }

        private void chkHideTrayIcon_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkHideTrayIcon.ContainsFocus )
                ApplicationConfiguration.HideTrayIcon = chkHideTrayIcon.Checked;
        }

        private void chkStartMinimized_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkStartMinimized.ContainsFocus )
                ApplicationConfiguration.StartMinimized = chkStartMinimized.Checked;
        }

        private void chkTurnOffWhenUserInactive_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkTurnOffWhenUserInactive.ContainsFocus )
            {
                ApplicationConfiguration.TurnOffWhenUserInactive = chkTurnOffWhenUserInactive.Checked;
                tmrIdle.Enabled = chkTurnOffWhenUserInactive.Checked;
            }

            numTimeAmount.Enabled = cboTimeUnit.Enabled = chkTurnOffWhenUserInactive.Checked;
        }

        private void chkDeleteTextFile_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkDeleteTextFile.ContainsFocus )
                ApplicationConfiguration.DeleteTextFile = chkDeleteTextFile.Checked;
        }

        private void chkIgnoreVolumeNames_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkIgnoreVolumeNames.ContainsFocus )
                ApplicationConfiguration.IgnoreVolumeNames = chkIgnoreVolumeNames.Checked;
        }

        private void chkLogMessages_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkLogMessages.ContainsFocus )
                ApplicationConfiguration.LogMessages = chkLogMessages.Checked;
        }

        private void numTimeAmount_ValueChanged( object sender, EventArgs e )
        {
            if ( numTimeAmount.ContainsFocus )
            {
                ApplicationConfiguration.TurnOffWhenUserInactiveTimeInterval = (int)numTimeAmount.Value;
            }

            string sTimeUnit = ( (ComboBoxItem)cboTimeUnit.SelectedItem ).Value;
            int iTimeAmount = (int)numTimeAmount.Value;

            // convert minutes/hours into seconds
            _disableTimersAfter = (uint)( sTimeUnit == "m" ? iTimeAmount : ( iTimeAmount * 60 ) ) * 60;
        }

        private void cboTimeUnit_SelectedIndexChanged( object sender, EventArgs e )
        {
            if ( cboTimeUnit.ContainsFocus )
            {
                ApplicationConfiguration.TurnOffWhenUserInactiveTimeUnit = ( (ComboBoxItem)cboTimeUnit.SelectedItem ).Value;
            }

            numTimeAmount_ValueChanged( null, null );
        }

        private void chkDelayWriteOnResume_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkDelayWriteOnResume.ContainsFocus )
                ApplicationConfiguration.DelayWriteOnSystemResume = chkDelayWriteOnResume.Checked;
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
                    if ( ApplicationConfiguration.DelayWriteOnSystemResume )
                        _resumedFromSleep = DateTime.Now;
                    break;
                case PowerModes.Suspend:
                    break;
            }
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
            Database.DatabaseManager.FillDrives( dgDrives, this.WritingEnabled );
            Helpers.SelectRowByValue( dgDrives, DrivesID.Index, iID.ToString() );

            if ( dgDrives.SelectedRows.Count == 0 && dgDrives.Rows.Count > 0 )
                dgDrives.Rows[0].Selected = true;

            SetDrivesEditMode();
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
                          TotalSize = GetDiskTotalSize( d ),
                          FreeSpace = GetDiskTotalFreeSpace( d ),
                          d.DriveType
                      } ).ToList() );
            }
            catch ( Exception exc )
            {
                LogManager.Write( exc.Message );
                MessageBox.Show( exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
            }
        }

        private string GetDiskTotalSize( DriveInfo d )
        {
            try
            {
                return Helpers.ToFileSize( d.TotalSize );
            }
            catch ( Exception exc )
            {
                LogManager.Write( "Failed to get disk total size: " + exc.Message );
                return string.Empty;
            }
        }

        private string GetDiskTotalFreeSpace( DriveInfo d )
        {
            try
            {
                return Helpers.ToFileSize( d.TotalFreeSpace );
            }
            catch ( Exception exc )
            {
                LogManager.Write( "Failed to get disk total free space: " + exc.Message );
                return string.Empty;
            }
        }

        #endregion

        #region Other

        private void FillSettings()
        {
            chkSystemAutoRun.Checked = ApplicationConfiguration.AutoRunOnStartup;
            chkSystemHideInTray.Checked = ApplicationConfiguration.HideInTray;
            chkMinimizeOnClose.Checked = ApplicationConfiguration.MinimizeOnClose;
            numTimeAmount.Value = ApplicationConfiguration.TurnOffWhenUserInactiveTimeInterval;
            Helpers.SelectItemValue( cboTimeUnit, ApplicationConfiguration.TurnOffWhenUserInactiveTimeUnit );
            chkTurnOffWhenUserInactive.Checked = ApplicationConfiguration.TurnOffWhenUserInactive;
            chkDeleteTextFile.Checked = ApplicationConfiguration.DeleteTextFile;
            chkIgnoreVolumeNames.Checked = ApplicationConfiguration.IgnoreVolumeNames;
            chkLogMessages.Checked = ApplicationConfiguration.LogMessages;
            chkStartMinimized.Checked = ApplicationConfiguration.StartMinimized;
            chkDelayWriteOnResume.Checked = ApplicationConfiguration.DelayWriteOnSystemResume;

            SetEngineStatus( this.WritingEnabled ? EngineStatus.Started : EngineStatus.Stopped );

            chkTurnOffWhenUserInactive_CheckedChanged( null, null );
        }

        private void SetEngineStatus( EngineStatus status )
        {
            btnEngineStart.Visible = status == EngineStatus.Stopped;
            btnEngineStop.Visible = lblStatus.Visible = status == EngineStatus.Started;
        }

        private void SetMinimizeMode()
        {
            if ( this.WindowState == FormWindowState.Minimized && chkSystemHideInTray.Checked == true )
            {
                ntfTray.Visible = true;
                ntfTray.BalloonTipText = "KeepAliveHD";
                ntfTray.Text = "KeepAliveHD";
                this.ShowInTaskbar = false;
                this.Hide();
            }
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

        private bool WritingEnabled
        {
            get
            {
                return _startedFromTaskScheduler || ApplicationConfiguration.WritingEnabled;
            }
        }

        #endregion
    }
}