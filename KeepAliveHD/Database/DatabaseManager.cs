#region Using Directives
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using System.Reflection;
#endregion

namespace KeepAliveHD.Database
{
    public class DatabaseManager
    {
        #region Members

        private static List<DriveInfo> _drives = new List<DriveInfo>();

        private const string DrivesFileName = "drives.xml";

        private static string DrivesFilePath = Path.Combine( Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData ), "KeepAliveHD", DrivesFileName );

        #endregion

        #region Constructors

        public DatabaseManager()
        {
        }

        #endregion

        #region Methods

        public static void Load()
        {
            string sOldDrivesFilePath = Path.Combine( Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location ), DrivesFileName );

            if ( File.Exists( sOldDrivesFilePath ) && !File.Exists( DrivesFilePath ) )
            {
                try
                {
                    File.Move( sOldDrivesFilePath, DrivesFilePath );
                }
                catch
                {
                }
            }

            if ( File.Exists( DrivesFilePath ) )
            {
                XElement doc = XElement.Load( DrivesFilePath );

                _drives.AddRange( ( from d in doc.Elements( "DriveInfo" )
                                    select new DriveInfo()
                                    {
                                        ID = d.Element( "ID" ) == null ? GetNewID() : Convert.ToInt32( d.Element( "ID" ).Value ),
                                        Drive = d.Element( "Drive" ) == null ? string.Empty : d.Element( "Drive" ).Value,
                                        VolumeNames = d.Element( "VolumeNames" ) == null ?
                                            new List<string>( new string[] { ( d.Element( "VolumeName" ) == null ? string.Empty : d.Element( "VolumeName" ).Value ) } ) : // this is needed to support old xml schema
                                            new List<string>( ( from v in d.Element( "VolumeNames" ).Elements() select v == null ? string.Empty : v.Value ).ToArray() ),
                                        TimeInterval = d.Element( "TimeInterval" ) == null ? 7 : Convert.ToInt32( d.Element( "TimeInterval" ).Value ) < 1 ? 1 : Convert.ToInt32( d.Element( "TimeInterval" ).Value ),
                                        TimeUnit = d.Element( "TimeUnit" ) == null ? "m" : d.Element( "TimeUnit" ).Value,
                                        Status = d.Element( "Status" ) == null ? 0 : Convert.ToInt32( d.Element( "Status" ).Value ),
                                        Connected = d.Element( "Connected" ) == null ? false : Convert.ToBoolean( d.Element( "Connected" ).Value ),
                                    } ).ToList() );
            }
        }

        private static void Save()
        {
            XElement doc = new XElement( "Root",
                  from d in _drives
                  select new XElement( "DriveInfo",
                      new XElement( "ID", d.ID ),
                      new XElement( "Drive", d.Drive ),
                      new XElement( "VolumeNames", ( from v in d.VolumeNames select new XElement( "Name", v ) ) ),
                      new XElement( "TimeInterval", d.TimeInterval ),
                      new XElement( "TimeUnit", d.TimeUnit ),
                      new XElement( "Status", d.Status ),
                      new XElement( "Connected", d.Connected )
                      ) );

            doc.Save( DrivesFilePath );
        }

        public static void FillDrives( DataGridView dg, bool enabled )
        {
            var list = from d in _drives
                       select new
                       {
                           d.ID,
                           d.Drive,
                           VolumeName = string.Join( ", ", d.VolumeNames.Take( 3 ) ) + ( d.VolumeNames.Count > 3 ? " ..." : "" ),
                           d.TimeInterval,
                           TimeIntervalText = d.TimeInterval.ToString() + ( d.TimeUnit == "s" ? " seconds" : d.TimeUnit == "m" ? " minutes" : d.TimeUnit == "h" ? " hours" : " unknown" ),
                           d.TimeUnit,
                           d.Status,
                           d.Connected,
                           StatusText = d.Connected == false ? "DISCONNECTED" : ( d.Status == 0 ? "SUSPENDED" : enabled == false ? "DISABLED" : "ENABLED" )
                       };

            dg.DataSource = BaseClasses.Helpers.LINQToDataTable( list );
        }

        public static void FillVolumeNames( DataGridView dg, int id )
        {
            var list = from d in _drives
                       from v in d.VolumeNames
                       where d.ID == id
                       select new
                       {
                           Name = v,
                       };

            dg.DataSource = BaseClasses.Helpers.LINQToDataTable( list );
        }

        public static DriveInfo Get( int id )
        {
            return _drives.FirstOrDefault( x => x.ID == id );
        }

        public static DriveInfo GetByDrive( string drive )
        {
            return _drives.FirstOrDefault( x => x.Drive == drive );
        }

        public static DriveInfo[] GetAll()
        {
            return _drives.ToArray();
        }

        public static bool Exist( int id, string drive )
        {
            //return ( from d in _Drives where d.ID != iID && Path.GetPathRoot( d.Drive ) == Path.GetPathRoot( sDrive ) select d ).Count() > 0;
            return ( from d in _drives where d.ID != id && d.Drive == drive select d ).Any();
        }

        public static bool Insert( out int id, string drive, string volumeName, int timeInterval, string timeUnit, int status )
        {
            id = 0;

            try
            {
                DriveInfo driveInfo = new DriveInfo()
                {
                    ID = GetNewID(),
                    Drive = drive,
                    VolumeNames = new List<string>( new string[] { volumeName } ),
                    TimeInterval = timeInterval,
                    TimeUnit = timeUnit,
                    Status = status
                };

                _drives.Add( driveInfo );

                Save();

                id = driveInfo.ID;

                return true;
            }
            catch ( Exception exc )
            {
                throw exc;
            }
        }

        public static bool Update( int id, string drive, string volumeName, int timeInterval, string timeUnit, int status )
        {
            try
            {
                DriveInfo driveInfo = _drives.FirstOrDefault( x => x.ID == id );

                if ( driveInfo != null )
                {
                    driveInfo.Drive = drive;
                    driveInfo.TimeInterval = timeInterval;
                    driveInfo.TimeUnit = timeUnit;
                    driveInfo.Status = status;

                    if ( !driveInfo.VolumeNames.Contains( volumeName ) )
                        driveInfo.VolumeNames.Add( volumeName );

                    Save();
                }

                return true;
            }
            catch ( Exception exc )
            {
                throw exc;
            }
        }

        public static bool Delete( int[] ids )
        {
            try
            {
                foreach ( var id in ids )
                {
                    DriveInfo driveInfo = _drives.FirstOrDefault( x => x.ID == id );

                    if ( driveInfo != null )
                    {
                        _drives.Remove( driveInfo );
                    }
                }

                Save();

                return true;
            }
            catch ( Exception exc )
            {
                throw exc;
            }
        }

        public static bool UpdateVolumeNames( int id, string[] volumeNames )
        {
            try
            {
                DriveInfo driveInfo = _drives.FirstOrDefault( x => x.ID == id );

                if ( driveInfo != null )
                {
                    driveInfo.VolumeNames.Clear();
                    driveInfo.VolumeNames.AddRange( volumeNames );

                    Save();
                }

                return true;
            }
            catch ( Exception exc )
            {
                throw exc;
            }
        }

        private static int GetNewID()
        {
            return ( ( from d in _drives select (int?)d.ID ).Max() ?? 0 ) + 1;
        }

        #endregion

        #region Properties
        #endregion
    }
}
