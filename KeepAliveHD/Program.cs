#region Using Directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using KeepAliveHD.BaseClasses;
#endregion

namespace KeepAliveHD
{
    static class Program
    {
        #region Members

        /// <summary>
        /// TO keep only one aplication openned.
        /// </summary>
        static Mutex mutex = new Mutex( true, "Megabit.KeepAliveHD" );

        #endregion

        #region Methods

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main( string[] args )
        {
            if ( mutex.WaitOne( TimeSpan.Zero, true ) )
            {
                try
                {
                    // new log file
                    LogManager.Create( string.Format( "log_{0}.txt", DateTime.Today.ToString( "yyyy-MM-dd" ) ) );

                    // initialise configuration
                    new ApplicationConfiguration();

                    bool minimize = false;

                    if ( args.Length > 0 )
                    {
                        CommandLineParser parser = new CommandLineParser();

                        try
                        {
                            minimize = parser.GetValue<bool>( "Minimize", args );
                        }
                        catch
                        {
                        }
                    }
                    else
                        minimize = ApplicationConfiguration.StartMinimized;

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault( false );
                    Application.Run( new Forms.Main( minimize ) );
                }
                catch ( Exception exc )
                {
                    LogManager.Write( exc.Message );
                    MessageBox.Show( exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
            else
            {
                // send our Win32 message to make the currently running instance
                // jump on top of all the other windows
                NativeMethods.PostMessage( (IntPtr)NativeMethods.HWND_BROADCAST, NativeMethods.WM_SHOWME, IntPtr.Zero, IntPtr.Zero );
            }
        }

        #endregion
    }
}
