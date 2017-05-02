#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
#endregion

namespace KeepAliveHD.BaseClasses
{
    public class LogManager
    {
        #region Members

        public static string LogFullPath = string.Empty;

        #endregion

        #region Methods

        public static void Create( string logFileName )
        {
            LogFullPath = Path.Combine( Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData ), "KeepAliveHD", "Logs", logFileName );

            if ( !Directory.Exists( Path.GetDirectoryName( LogFullPath ) ) )
                Directory.CreateDirectory( Path.GetDirectoryName( LogFullPath ) );

            if ( !File.Exists( LogFullPath ) )
            {
                using ( StreamWriter writer = new StreamWriter( LogFullPath, false, Encoding.UTF8 ) )
                {
                }
            }
        }

        public static void Write( string message, params string[] args )
        {
            if ( ApplicationConfiguration.LogMessages )
            {
                using ( StreamWriter writer = new StreamWriter( LogFullPath, true, Encoding.UTF8 ) )
                {
                    writer.WriteLine( string.Format( "{0} - {1}", DateTime.Now.ToString( "dd.MM.yyyy HH:mm:ss" ), message ), args );
                }
            }
        }

        #endregion
    }
}
