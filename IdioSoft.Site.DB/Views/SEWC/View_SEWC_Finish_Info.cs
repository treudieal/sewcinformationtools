using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Views.SEWC
{
    public class View_SEWC_Finish_Info : Columns
    {
        private static View_SEWC_Finish_Info instance;
        public static View_SEWC_Finish_Info GetInstance()
        {
            if (instance == null)
            {
                instance = new View_SEWC_Finish_Info();
            }
            return instance;
        }
        public View_SEWC_Finish_Info()
        {
            this.uRequestID.Name = "uRequestID";
            this.RequestID.Name = "RequestID";
            this.RequestID.FieldLenght = 15;
            this.MLFB.Name = "MLFB";
            this.MLFB.FieldLenght = 255;
            this.SerialNo.Name = "SerialNo";
            this.SerialNo.FieldLenght = 255;
            this.Warranty.Name = "Warranty";
            this.Warranty.FieldLenght = 100;
            this.DeliveryDate.Name = "DeliveryDate";
            this.EndRepairDate.Name = "EndRepairDate";
            this.ServiceType.Name = "ServiceType";
            this.ServiceType.FieldLenght = 20;
            this.Qty.Name = "Qty";
            this.WeightUnit.Name = "WeightUnit";
            this.WeightUnit.FieldLenght = 100;
            this.SEWCNotificationNo.Name = "SEWCNotificationNo";
            this.SEWCNotificationNo.FieldLenght = 100;
            this.IsReject.Name = "IsReject";
        }
        private Column<System.Guid?> _uRequestID = new Column<System.Guid?>();
        public Column<System.Guid?> uRequestID
        {
            get
            {
                return _uRequestID;
            }
            set
            {
                _uRequestID = value;
            }
        }
        private Column<System.String> _RequestID = new Column<System.String>();
        public Column<System.String> RequestID
        {
            get
            {
                return _RequestID;
            }
            set
            {
                _RequestID = value;
            }
        }
        private Column<System.String> _MLFB = new Column<System.String>();
        public Column<System.String> MLFB
        {
            get
            {
                return _MLFB;
            }
            set
            {
                _MLFB = value;
            }
        }
        private Column<System.String> _SerialNo = new Column<System.String>();
        public Column<System.String> SerialNo
        {
            get
            {
                return _SerialNo;
            }
            set
            {
                _SerialNo = value;
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
        private Column<System.DateTime?> _DeliveryDate = new Column<System.DateTime?>();
        public Column<System.DateTime?> DeliveryDate
        {
            get
            {
                return _DeliveryDate;
            }
            set
            {
                _DeliveryDate = value;
            }
        }
        private Column<System.DateTime?> _EndRepairDate = new Column<System.DateTime?>();
        public Column<System.DateTime?> EndRepairDate
        {
            get
            {
                return _EndRepairDate;
            }
            set
            {
                _EndRepairDate = value;
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
        private Column<System.Int32?> _Qty = new Column<System.Int32?>();
        public Column<System.Int32?> Qty
        {
            get
            {
                return _Qty;
            }
            set
            {
                _Qty = value;
            }
        }
        private Column<System.String> _WeightUnit = new Column<System.String>();
        public Column<System.String> WeightUnit
        {
            get
            {
                return _WeightUnit;
            }
            set
            {
                _WeightUnit = value;
            }
        }
        private Column<System.String> _SEWCNotificationNo = new Column<System.String>();
        public Column<System.String> SEWCNotificationNo
        {
            get
            {
                return _SEWCNotificationNo;
            }
            set
            {
                _SEWCNotificationNo = value;
            }
        }
        private Column<System.Boolean?> _IsReject = new Column<System.Boolean?>();
        public Column<System.Boolean?> IsReject
        {
            get
            {
                return _IsReject;
            }
            set
            {
                _IsReject = value;
            }
        }

    }
}
