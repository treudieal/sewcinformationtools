using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Tables.SEWC
{
    public class SEWC_Basic_WorkStationCode_Info : Columns
    {
        private static SEWC_Basic_WorkStationCode_Info instance;
        public static SEWC_Basic_WorkStationCode_Info GetInstance()
        {
            if (instance == null)
            {
                instance = new SEWC_Basic_WorkStationCode_Info();
            }
            return instance;
        }
        public SEWC_Basic_WorkStationCode_Info()
        {
            this.ID.Name = "ID";
            this.StationCode.Name = "StationCode";
            this.StationCode.FieldLenght = 50;
            this.IsDel.Name = "IsDel";
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
        private Column<System.String> _StationCode = new Column<System.String>();
        public Column<System.String> StationCode
        {
            get
            {
                return _StationCode;
            }
            set
            {
                _StationCode = value;
            }
        }
        private Column<System.Int32?> _IsDel = new Column<System.Int32?>();
        public Column<System.Int32?> IsDel
        {
            get
            {
                return _IsDel;
            }
            set
            {
                _IsDel = value;
            }
        }

    }
}
