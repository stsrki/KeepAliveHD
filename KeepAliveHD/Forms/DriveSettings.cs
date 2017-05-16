#region Using Directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using KeepAliveHD.BaseClasses;
#endregion

namespace KeepAliveHD.Forms
{
    public partial class DriveSettings : Form
    {
        #region Members

        private int _id = 0;

        #endregion

        #region Constructors

        public DriveSettings( int id )
        {
            InitializeComponent();

            _id = id;
        }

        #endregion

        #region Events

        private void DriveSettings_Load( object sender, EventArgs e )
        {
            cboOperation.Items.Add( new ComboBoxItem( "Write", "w" ) );
            cboOperation.Items.Add( new ComboBoxItem( "Read", "r" ) );
            cboOperation.SelectedIndex = 0;

            cboTimeUnit.Items.Add( new ComboBoxItem( "seconds", "s" ) );
            cboTimeUnit.Items.Add( new ComboBoxItem( "minutes", "m" ) );
            cboTimeUnit.Items.Add( new ComboBoxItem( "hours", "h" ) );
            cboTimeUnit.SelectedIndex = 0;

            if ( _id > 0 )
                FillHeader( _id );
            else
            {
                numTimeInterval.Value = 7;
                chkEnabled.Checked = true;
            }
        }

        private void DriveSettings_FormClosing( object sender, FormClosingEventArgs e )
        {
            try
            {
                if ( DialogResult == DialogResult.OK )
                {
                    string drive = txtDrive.Text.Trim();

                    if ( string.IsNullOrEmpty( drive ) )
                        throw new Exception( "You must select drive." );

                    if ( !Directory.Exists( drive ) )
                        throw new Exception( "The path does not exist." );

                    string volumeName = ( new System.IO.DriveInfo( Path.GetPathRoot( drive ) ) ).VolumeLabel;
                    string operation = ComboBoxTools.GetSelectedValue( cboOperation );
                    int timeInterval = (int)numTimeInterval.Value;
                    string timeUnit = ComboBoxTools.GetSelectedValue( cboTimeUnit );
                    int status = chkEnabled.Checked ? 1 : 0;

                    if ( Database.DatabaseManager.Exist( _id, drive ) )
                    {
                        var driveInfo = Database.DatabaseManager.GetByDrive( drive );

                        if ( driveInfo.VolumeNames.Contains( volumeName ) )
                            throw new Exception( "You have already specified drive with the same volume name." );

                        _id = driveInfo.ID;
                    }

                    if ( timeInterval < 1 )
                        throw new Exception( "Cannot have time interval less than one minute." );

                    if ( _id == 0 )
                    {
                        Database.DatabaseManager.Insert( id: out _id, drive: drive, volumeName: volumeName, operation: operation, timeInterval: timeInterval, timeUnit: timeUnit, status: status );
                    }
                    else
                    {
                        Database.DatabaseManager.Update( id: _id, drive: drive, volumeName: volumeName, operation: operation, timeInterval: timeInterval, timeUnit: timeUnit, status: status );
                    }
                }
            }
            catch ( Exception exc )
            {
                e.Cancel = true;
                LogManager.Write( exc.Message );
                MessageBox.Show( exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
            }
        }

        private void btnSelectDrive_Click( object sender, EventArgs e )
        {
            using ( FolderBrowserDialog dialog = new FolderBrowserDialog()
            {
                RootFolder = Environment.SpecialFolder.MyComputer
            } )
            {
                if ( dialog.ShowDialog() == DialogResult.OK )
                {
                    txtDrive.Text = dialog.SelectedPath;
                }
            }
        }

        private void cboOperation_SelectedIndexChanged( object sender, EventArgs e )
        {
            string operation = ComboBoxTools.GetSelectedValue( cboOperation );

            lblOperationInfo.Text = operation == "r" ? "disk every" : "file every";
        }

        #endregion

        #region Methods

        private void FillHeader( int iID )
        {
            Database.DriveInfo di = Database.DatabaseManager.Get( iID );

            txtDrive.Text = di.Drive;
            numTimeInterval.Value = di.TimeInterval;
            chkEnabled.Checked = di.Status == 1;
            ComboBoxTools.SelectItemValue( cboOperation, di.Operation );
            ComboBoxTools.SelectItemValue( cboTimeUnit, di.TimeUnit );
        }

        #endregion

        #region Properties

        public int DriveInfoID
        {
            get { return _id; }
        }

        #endregion
    }
}