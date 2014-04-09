using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Tables.SEWC
{
    public class SEWC_Basic_FailureCodeCaused_Info : Columns
    {
        private static SEWC_Basic_FailureCodeCaused_Info instance;
        public static SEWC_Basic_FailureCodeCaused_Info GetInstance()
        {
            if (instance == null)
            {
                instance = new SEWC_Basic_FailureCodeCaused_Info();
            }
            return instance;
        }
        public SEWC_Basic_FailureCodeCaused_Info()
        {
            this.ID.Name = "ID";
            this.Code.Name = "Code";
            this.Code.FieldLenght = 50;
            this.Value.Name = "Value";
            this.Value.FieldLenght = 100;
        }
        private Column<System.Guid?> _ID = new Column<System.Guid?>();
        public Column<System.Guid?> ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        private Column<System.String> _Code = new Column<System.String>();
        public Column<System.String> Code
        {
            get
            {
                return _Code;
            }
            set
            {
                _Code = value;
            }
        }
        private Column<System.String> _Value = new Column<System.String>();
        public Column<System.String> Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
            }
        }

    }
}
