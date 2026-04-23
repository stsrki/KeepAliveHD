#region Using Directives
using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;
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
                    new AppConfiguration();

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
                        minimize = AppConfiguration.StartMinimized;

                    ApplicationConfiguration.Initialize();
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
                RestoreRunningInstance();
            }
        }

        private static void RestoreRunningInstance()
        {
            IntPtr windowHandle = FindRunningInstanceWindow();

            if ( windowHandle != IntPtr.Zero )
            {
                NativeMethods.PostMessage( windowHandle, NativeMethods.WM_SHOWME, IntPtr.Zero, IntPtr.Zero );
                return;
            }

            NativeMethods.PostMessage( (IntPtr)NativeMethods.HWND_BROADCAST, NativeMethods.WM_SHOWME, IntPtr.Zero, IntPtr.Zero );
        }

        private static IntPtr FindRunningInstanceWindow()
        {
            Process currentProcess = Process.GetCurrentProcess();
            Process runningInstance = Array.Find(
                Process.GetProcessesByName( currentProcess.ProcessName ),
                x => x.Id != currentProcess.Id );

            if ( runningInstance == null )
                return IntPtr.Zero;

            IntPtr fallbackWindowHandle = IntPtr.Zero;
            IntPtr windowHandle = IntPtr.Zero;

            NativeMethods.EnumWindows( ( hWnd, lParam ) =>
            {
                uint processId;
                NativeMethods.GetWindowThreadProcessId( hWnd, out processId );

                if ( processId != runningInstance.Id )
                    return true;

                if ( fallbackWindowHandle == IntPtr.Zero )
                    fallbackWindowHandle = hWnd;

                int titleLength = NativeMethods.GetWindowTextLength( hWnd );

                if ( titleLength <= 0 )
                    return true;

                StringBuilder title = new StringBuilder( titleLength + 1 );
                NativeMethods.GetWindowText( hWnd, title, title.Capacity );

                if ( string.Equals( title.ToString(), "KeepAliveHD", StringComparison.Ordinal ) )
                {
                    windowHandle = hWnd;
                    return false;
                }

                return true;
            }, IntPtr.Zero );

            return windowHandle != IntPtr.Zero ? windowHandle : fallbackWindowHandle;
        }

        #endregion
    }
}