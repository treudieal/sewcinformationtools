using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Tables.Public
{
    [Serializable]
    public class webInfo_Basic_ServiceRequest_ServiceType_Info:Columns
    {
        private static webInfo_Basic_ServiceRequest_ServiceType_Info instance;
        public static webInfo_Basic_ServiceRequest_ServiceType_Info GetInstance()
        {
            if (instance == null)
            {
                instance = new webInfo_Basic_ServiceRequest_ServiceType_Info();
            }
            return instance;
        }
        public webInfo_Basic_ServiceRequest_ServiceType_Info()
        {
            this.ID.Name = "ID";
            this.ServiceType.Name = "ServiceType";
            this.ServiceType.FieldLenght = 20;
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
        private Column<System.String> _ServiceType = new Column<System.String>();
        public Column<System.String> ServiceType
        {
            get
            {
                return _ServiceType;
            }
            set
            {
                _ServiceType = value;
            }
        }

    }
}
