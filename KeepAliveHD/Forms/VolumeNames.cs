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
    public partial class VolumeNames : Form
    {
        #region Members

        private int _iDriveID = 0;

        private List<string> _VolumeNames = new List<string>();

        #endregion

        #region Constructors

        public VolumeNames( int iDriveID )
        {
            InitializeComponent();

            _iDriveID = iDriveID;
        }

        #endregion

        #region Events

        #region Form

        private void VolumeNames_Load( object sender, EventArgs e )
        {
            if ( _iDriveID > 0 )
            {
                Database.DatabaseManager.FillVolumeNames( dgVolumeNames, _iDriveID );
            }

            SetVolumeNamesEditMode();
        }

        private void VolumeNames_FormClosing( object sender, FormClosingEventArgs e )
        {
            try
            {
                if ( DialogResult == DialogResult.OK )
                {
                    _VolumeNames.Clear();

                    foreach ( DataGridViewRow row in dgVolumeNames.Rows )
                    {
                        string sValue = Convert.ToString( row.Cells[VolumeNamesName.Name].Value );

                        if ( !string.IsNullOrEmpty( sValue ) )
                        {
                            _VolumeNames.Add( sValue );
                        }
                    }

                    if ( _VolumeNames.Count == 0 )
                    {
                        if ( MessageBox.Show( "It is not advisable to remove all volume names.\r\nAre you sure you want to continue?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1 ) == DialogResult.No )
                        {
                            e.Cancel = true;
                            return;
                        }
                    }

                    Database.DatabaseManager.UpdateVolumeNames( id: _iDriveID, volumeNames: _VolumeNames.ToArray() );
                }
            }
            catch ( Exception exc )
            {
                e.Cancel = true;
                LogManager.Write( exc.Message );
                MessageBox.Show( exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
            }
        }

        #endregion

        #region VolumeNames

        private void dgVolumeNames_SelectionChanged( object sender, EventArgs e )
        {
            SetVolumeNamesEditMode();
        }

        #endregion

        #endregion

        #region Methods

        #region Other

        private void SetVolumeNamesEditMode()
        {
            btnOk.Enabled = dgVolumeNames.SelectedRows.Count > 0;
        }

        #endregion

        #endregion

        #region Properties

        #endregion
    }
}
