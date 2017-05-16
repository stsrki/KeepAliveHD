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
    public partial class DriveSettingsMulti : Form
    {
        #region Members

        private int _id = 0;

        List<string> _drives = new List<string>();

        #endregion

        #region Constructors

        public DriveSettingsMulti( List<string> drives )
        {
            InitializeComponent();

            _drives.AddRange( drives );
        }

        #endregion

        #region Events

        private void DriveSettingsMulti_Load( object sender, EventArgs e )
        {
            cboOperation.Items.Add( new ComboBoxItem( "Write", "w" ) );
            cboOperation.Items.Add( new ComboBoxItem( "Read", "r" ) );
            cboOperation.SelectedIndex = 0;

            cboTimeUnit.Items.Add( new ComboBoxItem( "seconds", "s" ) );
            cboTimeUnit.Items.Add( new ComboBoxItem( "minutes", "m" ) );
            cboTimeUnit.Items.Add( new ComboBoxItem( "hours", "h" ) );
            cboTimeUnit.SelectedIndex = 0;

            txtDrives.Text = string.Join( ", ", _drives );

            numTimeInterval.Value = 7;
            chkEnabled.Checked = true;
        }

        private void DriveSettingsMulti_FormClosing( object sender, FormClosingEventArgs e )
        {
            try
            {
                if ( DialogResult == DialogResult.OK )
                {
                    int timeInterval = (int)numTimeInterval.Value;
                    string operation = ComboBoxTools.GetSelectedValue( cboOperation );
                    string timeUnit = ComboBoxTools.GetSelectedValue( cboTimeUnit );
                    int status = chkEnabled.Checked ? 1 : 0;

                    if ( timeInterval < 1 )
                        throw new Exception( "Cannot have time interval less than one minute." );

                    foreach ( string drive in _drives )
                    {
                        if ( !Database.DatabaseManager.Exist( -1, drive ) )
                        {
                            string sVolumeName = ( new System.IO.DriveInfo( Path.GetPathRoot( drive ) ) ).VolumeLabel;

                            Database.DatabaseManager.Insert( out _id, drive: drive, volumeName: sVolumeName, operation: operation, timeInterval: timeInterval, timeUnit: timeUnit, status: status );
                        }
                        else
                        {
                            string sVolumeName = ( new System.IO.DriveInfo( Path.GetPathRoot( drive ) ) ).VolumeLabel;

                            var driveInfo = Database.DatabaseManager.GetByDrive( drive );

                            if ( driveInfo != null )
                            {
                                _id = driveInfo.ID;
                                Database.DatabaseManager.Update( id: _id, drive: drive, volumeName: sVolumeName, operation: operation, timeInterval: timeInterval, timeUnit: timeUnit, status: status );
                            }
                        }
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

        private void cboOperation_SelectedIndexChanged( object sender, EventArgs e )
        {
            string operation = ComboBoxTools.GetSelectedValue( cboOperation );

            lblOperationInfo.Text = operation == "r" ? "disk every" : "file every";
        }

        #endregion

        #region Methods

        #endregion

        #region Properties

        public int DriveInfoID
        {
            get { return _id; }
        }

        #endregion
    }
}
