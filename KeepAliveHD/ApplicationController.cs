#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
#endregion

namespace KeepAliveHD
{
    public class ApplicationController : WindowsFormsApplicationBase
    {
        #region Members

        private Form mainForm;

        #endregion

        #region Constructors

        public ApplicationController( Form form )
        {
            //We keep a reference to main form 
            //To run and also use it when we need to bring to front
            mainForm = form;
            this.IsSingleInstance = true;
            this.StartupNextInstance += this_StartupNextInstance;
        }

        #endregion

        #region Events

        void this_StartupNextInstance( object sender, StartupNextInstanceEventArgs e )
        {
            //Here we bring application to front
            e.BringToForeground = true;
            mainForm.ShowInTaskbar = true;
            mainForm.WindowState = FormWindowState.Minimized;
            mainForm.Show();
            mainForm.WindowState = FormWindowState.Normal;
        }

        #endregion

        #region Methods

        protected override void OnCreateMainForm()
        {
            this.MainForm = mainForm;
        }

        #endregion
    }
}
