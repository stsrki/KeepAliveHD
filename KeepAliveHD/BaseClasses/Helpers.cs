#region Using Directives
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
#endregion

namespace KeepAliveHD.BaseClasses
{
    public class Helpers
    {
        #region Methods

        public static void SelectItemValue( ComboBox cbo, string value )
        {
            foreach ( ComboBoxItem item in cbo.Items )
            {
                if ( item.Value == value )
                {
                    cbo.SelectedItem = item;
                    return;
                }
            }
        }

        public static void SelectRowByValue( DataGridView dg, int columnName, string value )
        {
            dg.ClearSelection();

            if ( value == "-1" )
            {
                if ( dg.Rows.Count > 0 )
                {
                    dg.Rows[0].Selected = true;
                    dg.FirstDisplayedScrollingRowIndex = dg.Rows[0].Index;
                }
            }
            else
            {
                foreach ( DataGridViewRow row in dg.Rows )
                {
                    if ( row.Cells[columnName].Value.ToString() == value )
                    {
                        row.Selected = true;
                        dg.FirstDisplayedScrollingRowIndex = row.Index;
                        break;
                    }
                }
            }
        }

        public static string ToFileSize( long source )
        {
            const int byteConversion = 1024;
            double bytes = Convert.ToDouble( source );

            if ( bytes >= Math.Pow( byteConversion, 3 ) ) //GB Range
            {
                return string.Concat( Math.Round( bytes / Math.Pow( byteConversion, 3 ), 2 ), " GB" );
            }
            else if ( bytes >= Math.Pow( byteConversion, 2 ) ) //MB Range
            {
                return string.Concat( Math.Round( bytes / Math.Pow( byteConversion, 2 ), 2 ), " MB" );
            }
            else if ( bytes >= byteConversion ) //KB Range
            {
                return string.Concat( Math.Round( bytes / byteConversion, 2 ), " KB" );
            }
            else //Bytes
            {
                return string.Concat( bytes, " Bytes" );
            }
        }

        public static DataTable LINQToDataTable<T>( IEnumerable<T> varlist )
        {
            DataTable dtReturn = new DataTable();

            // column names 
            PropertyInfo[] oProps = null;

            if ( varlist == null )
                return dtReturn;

            foreach ( T rec in varlist )
            {
                // Use reflection to get property names, to create table, Only first time, others will follow 
                if ( oProps == null )
                {
                    oProps = ( (Type)rec.GetType() ).GetProperties();
                    foreach ( PropertyInfo pi in oProps )
                    {
                        Type colType = pi.PropertyType;

                        if ( ( colType.IsGenericType ) && ( colType.GetGenericTypeDefinition()
                        == typeof( Nullable<> ) ) )
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add( new DataColumn( pi.Name, colType ) );
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach ( PropertyInfo pi in oProps )
                {
                    dr[pi.Name] = pi.GetValue( rec, null ) == null ? DBNull.Value : pi.GetValue
                    ( rec, null );
                }

                dtReturn.Rows.Add( dr );
            }
            return dtReturn;
        }

        #endregion
    }
}
