#region Using Directives
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
#endregion

namespace KeepAliveHD.BaseClasses
{
    public class CommandLineParser
    {
        #region Members

        private const string _keyValueSeperator = "=";

        #endregion

        #region Constructors

        public CommandLineParser()
        {
        }

        #endregion

        #region Methods

        public T GetValue<T>( string key, string[] args )
        {
            if ( string.IsNullOrEmpty( key ) )
            {
                throw new NullReferenceException( "Parameter [key] can't be null or empty" );
            }
            if ( args == null || args.Length == 0 )
            {
                throw new NullReferenceException( "Parameter [args] can't be null or empty" );
            }

            // Select all keyvalue pairs with the given key
            var keyValuePairs = from a in args
                                where !string.IsNullOrEmpty( a ) && a.Trim().StartsWith( key + "=" )
                                select a.Trim();

            if ( keyValuePairs.Count() > 0 )
            {
                // Get last keyvalue pair with the given key
                var lastKeyValuePair = keyValuePairs.Last();

                // Get the value from the last keyvalue pair with the given key
                var value = this.GetValueFromKeyValuePair( lastKeyValuePair );

                // Convert the value to the return type
                var converter = TypeDescriptor.GetConverter( typeof( T ) );
                return (T)converter.ConvertFromString( value );
            }
            else
            {
                throw new Exception( string.Format( "The key [{0}] can't be found on the commandline, make sure it is supplied on the commandline and there are no spaces between the key and the equalsign. Key is case sensitive!", key ) );
            }
        }
        public string GetValueFromKeyValuePair( string keyValuePair )
        {
            var result = string.Empty;

            if ( !string.IsNullOrEmpty( keyValuePair ) )
            {
                // Split line on "="
                string[] keyValue = keyValuePair.Split( new string[] { _keyValueSeperator }, StringSplitOptions.RemoveEmptyEntries );

                if ( keyValue.Length >= 2 )
                {
                    // Restore the "=" in the value
                    result = String.Join( _keyValueSeperator, keyValue, 1, keyValue.Length - 1 );
                }
                else
                {
                    if ( keyValue.Length == 1 )
                    {
                        // value does not contain a "="
                        result = keyValue[0];
                    }
                }

                // Remove leading and trailing quotes
                result = result.Trim( new char[] { '"' } );
            }

            return result;
        }

        #endregion
    }
}
