#region Using Directives
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
#endregion

namespace KeepAliveHD.BaseClasses
{
    public class NativeMethods
    {
        #region Constants

        public const int HWND_BROADCAST = 0xffff;

        public static readonly int WM_SHOWME = RegisterWindowMessage( "WM_SHOWME" );

        public const int MOUSEEVENTF_LEFTDOWN = 0x2;
        public const int MOUSEEVENTF_LEFTUP = 0x4;

        public const Int32 WM_LBUTTONDOWN = 0x0201;

        #endregion

        #region Methods

        [DllImport( "user32" )]
        public static extern bool PostMessage( IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam );

        [DllImport( "user32" )]
        public static extern bool PostMessage( IntPtr hwnd, int msg, Int32 wparam, Int32 lparam );

        [DllImport( "user32" )]
        public static extern int RegisterWindowMessage( string message );

        [DllImport( "user32.dll" )]
        public static extern int SendMessage( IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam );

        [DllImport( "user32.dll" )]
        public static extern int mouse_event( int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo );

        [DllImport( "user32.dll" )]
        public static extern int SetCursorPos( int x, int y );

        [DllImport( "user32.dll" )]
        public static extern bool ShowWindow( IntPtr hwnd, Int32 nCmdShow );

        [DllImport( "user32.dll" )]
        public static extern bool SetForegroundWindow( IntPtr hwnd );

        private const int WM_SETREDRAW = 11;

        public static void SuspendDrawing( Control parent )
        {
            SendMessage( parent.Handle, WM_SETREDRAW, false, 0 );
        }

        public static void ResumeDrawing( Control parent )
        {
            SendMessage( parent.Handle, WM_SETREDRAW, true, 0 );
            parent.Refresh();
        }

        // Unmanaged function from user32.dll
        [DllImport( "user32.dll" )]
        internal static extern bool GetLastInputInfo( ref LASTINPUTINFO plii );

        // Struct we'll need to pass to the function
        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        #endregion
    }
}
