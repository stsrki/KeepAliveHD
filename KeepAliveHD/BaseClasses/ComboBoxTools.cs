#region Using Directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
#endregion

namespace KeepAliveHD.BaseClasses
{
    public class ComboBoxTools
    {
        #region Members

        public const int DefaultItemValue = 0;

        #endregion

        #region Methods

        public static bool IsDefaultItemSelected( ComboBox cbo )
        {
            return IsDefaultItemSelected( cbo, true );
        }

        public static bool IsDefaultItemSelected( ComboBox cbo, bool noItemSelected )
        {
            if ( cbo.SelectedItem == null )
                return noItemSelected;
            else
            {
                if ( IsNoValueItemSelected( cbo ) || ( (ComboBoxItem)cbo.SelectedItem ).Value.Trim() == "0" )
                    return true;
                else
                    return false;
            }
        }

        public static bool IsNoValueItemSelected( ComboBox cbo )
        {
            if ( cbo.SelectedItem == null || ( (ComboBoxItem)cbo.SelectedItem ).Value == "" )
                return true;
            else
                return false;
        }

        public static string GetSelectedValue( ComboBox cbo )
        {
            if ( IsDefaultItemSelected( cbo ) )
                return DefaultItemValue.ToString();
            else
                return ( (ComboBoxItem)cbo.SelectedItem ).Value;
        }

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

        #endregion
    }
}
