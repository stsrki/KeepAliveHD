#region Using Directives
using System;
using System.Collections.Generic;
#endregion

namespace KeepAliveHD.BaseClasses
{
    public class ComboBoxItem
    {
        #region Members

        private string _text;
        private string _value;

        #endregion

        #region Constructors

        public ComboBoxItem( string text, string value )
        {
            _text = text;
            _value = value;
        }

        #endregion

        #region Methods

        public ComboBoxItem Clone()
        {
            return new ComboBoxItem( _text, _value );
        }

        public override string ToString()
        {
            return Text;
        }

        #endregion

        #region Properties

        public string Text
        {
            get
            {
                return this._text;
            }
            internal set
            {
                this._text = value;
            }
        }

        public string Value
        {
            get
            {
                return this._value;
            }
        }

        #endregion
    }
}
