using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Tables.Public
{
    [Serializable]
    public class CallCenter_Basic_Warranty_Info : Columns
    {
        private static CallCenter_Basic_Warranty_Info instance;
        public static CallCenter_Basic_Warranty_Info GetInstance()
        {
            if (instance == null)
            {
                instance = new CallCenter_Basic_Warranty_Info();
            }
            return instance;
        }
        public CallCenter_Basic_Warranty_Info()
        {
            this.ID.Name = "ID";
            this.Warranty.Name = "Warranty";
            this.Warranty.FieldLenght = 20;
        }
        private Column<System.Int32?> _ID = new Column<System.Int32?>();
        public Column<System.Int32?> ID
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
        private Column<System.String> _Warranty = new Column<System.String>();
        public Column<System.String> Warranty
        {
            get
            {
                return _Warranty;
            }
            set
            {
                _Warranty = value;
            }
        }

    }
}
