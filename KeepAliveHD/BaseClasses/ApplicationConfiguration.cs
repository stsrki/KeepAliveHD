#region Using Directives
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using Microsoft.Win32;
using System.Reflection;
#endregion

namespace KeepAliveHD.BaseClasses
{
    public class ApplicationConfiguration
    {
        #region Classes

        [Serializable()]
        [XmlRoot( "Settings" )]
        public class Settings
        {
            [XmlElement( "Section", typeof( SettingSections ) )]
            public List<SettingSections> Sections { get; set; }
        }

        [Serializable()]
        public class SettingSections
        {
            [XmlAttribute( "Name" )]
            public string Name { get; set; }

            [XmlElement( "Item", typeof( SettingSectionItem ) )]
            public List<SettingSectionItem> Items { get; set; }
        }

        [Serializable()]
        public class SettingSectionItem
        {
            [XmlAttribute( "Key" )]
            public string Key { get; set; }

            [XmlAttribute( "Value" )]
            public string Value { get; set; }
        }

        #endregion

        #region Members

        private static Settings _settings = new Settings();

        private static string SettingsDirectory;

        private const string SettingsFileName = "Settings.xml";

        private const string SectionName_Application = "Application";

        private const string SectionName_System = "System";

        public static bool SuppressSaving = false;

        #endregion

        #region Constructors

        public ApplicationConfiguration()
        {
            SettingsDirectory = Path.Combine( Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData ), "KeepAliveHD" );

            Load();
        }

        #endregion

        #region Methods

        #region Serialization

        public static void Load()
        {
            if ( !Directory.Exists( SettingsDirectory ) )
            {
                Directory.CreateDirectory( SettingsDirectory );
            }

            if ( !File.Exists( Path.Combine( SettingsDirectory, SettingsFileName ) ) )
            {
                Save();
            }

            XmlSerializer serializer = new XmlSerializer( typeof( Settings ) );
            using ( StreamReader reader = new StreamReader( Path.Combine( SettingsDirectory, SettingsFileName ), Encoding.UTF8 ) )
            {
                _settings = (Settings)serializer.Deserialize( reader );
                reader.Close();
            }
        }

        public static void Save()
        {
            XmlSerializer serializer = new XmlSerializer( typeof( Settings ) );
            using ( StreamWriter writer = new StreamWriter( Path.Combine( SettingsDirectory, SettingsFileName ) ) )
            {
                serializer.Serialize( writer, _settings );
            }
        }

        private static void SetValueBool( string sectionName, string key, bool value )
        {
            SetValue( sectionName, key, value.ToString() );
        }

        private static void SetValueInt( string sectionName, string key, int value )
        {
            SetValue( sectionName, key, value.ToString() );
        }

        private static void SetValue( string sectionName, string key, string value )
        {
            SettingSectionItem item = ( from s in _settings.Sections from i in s.Items where s.Name == sectionName && i.Key == key select i ).SingleOrDefault();

            if ( item != null )
            {
                item.Value = value == null ? string.Empty : value;

                if ( !SuppressSaving )
                    Save();
            }
        }

        public static bool GetValueBool( string sectionName, string key, bool defaultValue )
        {
            return bool.Parse( GetValue( sectionName, key, defaultValue.ToString() ) );
        }

        public static int GetValueInt( string sectionName, string key, int defaultValue )
        {
            return int.Parse( GetValue( sectionName, key, defaultValue.ToString() ) );
        }

        public static string GetValue( string sectionName, string key, string defaultValue )
        {
            SettingSectionItem item = ( from s in _settings.Sections
                                        from i in s.Items
                                        where
                                        s.Name == sectionName
                                        &&
                                        i.Key == key
                                        select
                                        i ).SingleOrDefault();

            if ( item == null )
            {
                SettingSections section = ( from s in _settings.Sections where s.Name == sectionName select s ).SingleOrDefault();

                if ( section == null )
                {
                    _settings.Sections.Add( section = new SettingSections() { Name = sectionName, Items = new List<SettingSectionItem>() } );
                }

                section.Items.Add( item = new SettingSectionItem() { Key = key, Value = defaultValue } );

                Save();
            }

            return item.Value;
        }

        #endregion

        #endregion

        #region Properties

        #region System

        public static bool AutoRunOnStartup
        {
            get
            {
                RegistryKey rkApp = Registry.CurrentUser.OpenSubKey( "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true );
                return rkApp.GetValue( "KeepAliveHD" ) != null;
            }
            set
            {
                RegistryKey rkApp = Registry.CurrentUser.OpenSubKey( "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true );

                if ( value )
                    rkApp.SetValue( "KeepAliveHD", Assembly.GetExecutingAssembly().Location + " Minimize=True" );
                else
                    rkApp.DeleteValue( "KeepAliveHD", false );
            }
        }

        public static bool HideInTray
        {
            get { return GetValueBool( SectionName_System, "HideInTray", true ); }
            set { SetValueBool( SectionName_System, "HideInTray", value ); }
        }

        public static bool MinimizeOnClose
        {
            get { return GetValueBool( SectionName_System, "MinimizeOnClose", false ); }
            set { SetValueBool( SectionName_System, "MinimizeOnClose", value ); }
        }

        public static bool HideTrayIcon
        {
            get { return GetValueBool( SectionName_System, "HideTrayIcon", false ); }
            set { SetValueBool( SectionName_System, "HideTrayIcon", value ); }
        }

        public static bool TurnOffWhenUserInactive
        {
            get { return GetValueBool( SectionName_System, "TurnOffWhenUserInactive", false ); }
            set { SetValueBool( SectionName_System, "TurnOffWhenUserInactive", value ); }
        }

        public static int TurnOffWhenUserInactiveTimeInterval
        {
            get { return GetValueInt( SectionName_System, "TurnOffWhenUserInactiveTimeInterval", 1 ); }
            set { SetValueInt( SectionName_System, "TurnOffWhenUserInactiveTimeInterval", value ); }
        }

        public static string TurnOffWhenUserInactiveTimeUnit
        {
            get { return GetValue( SectionName_System, "TurnOffWhenUserInactiveTimeUnit", "h" ); }
            set { SetValue( SectionName_System, "TurnOffWhenUserInactiveTimeUnit", value ); }
        }

        public static bool StartMinimized
        {
            get { return GetValueBool( SectionName_System, "StartMinimized", false ); }
            set { SetValueBool( SectionName_System, "StartMinimized", value ); }
        }

        #endregion

        #region Application

        public static bool WritingEnabled
        {
            get { return GetValueBool( SectionName_Application, "WritingEnabled", false ); }
            set { SetValueBool( SectionName_Application, "WritingEnabled", value ); }
        }

        public static bool DeleteTextFile
        {
            get { return GetValueBool( SectionName_Application, "DeleteTextFile", false ); }
            set { SetValueBool( SectionName_Application, "DeleteTextFile", value ); }
        }

        public static bool IgnoreVolumeNames
        {
            get { return GetValueBool( SectionName_Application, "IgnoreVolumeNames", false ); }
            set { SetValueBool( SectionName_Application, "IgnoreVolumeNames", value ); }
        }

        public static bool LogMessages
        {
            get { return GetValueBool( SectionName_Application, "LogMessages", false ); }
            set { SetValueBool( SectionName_Application, "LogMessages", value ); }
        }

        public static bool DelayWriteOnSystemResume
        {
            get { return GetValueBool( SectionName_Application, "DelayWriteOnSystemResume", false ); }
            set { SetValueBool( SectionName_Application, "DelayWriteOnSystemResume", value ); }
        }

        #endregion

        #endregion
    }
}
