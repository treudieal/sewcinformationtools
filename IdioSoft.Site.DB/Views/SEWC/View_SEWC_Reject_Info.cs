using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Views.SEWC
{
    public class View_SEWC_Reject_Info : Columns
    {
        private static View_SEWC_Reject_Info instance;
        public static View_SEWC_Reject_Info GetInstance()
        {
            if (instance == null)
            {
                instance = new View_SEWC_Reject_Info();
            }
            return instance;
        }
        public View_SEWC_Reject_Info()
        {
            this.uRequestID.Name = "uRequestID";
            this.RequestID.Name = "RequestID";
            this.RequestID.FieldLenght = 15;
            this.SEWCNotificationNo.Name = "SEWCNotificationNo";
            this.SEWCNotificationNo.FieldLenght = 100;
            this.ProductDesc.Name = "ProductDesc";
            this.ProductDesc.FieldLenght = 50;
            this.MLFB.Name = "MLFB";
            this.MLFB.FieldLenght = 255;
            this.SerialNo.Name = "SerialNo";
            this.SerialNo.FieldLenght = 255;
            this.Warranty.Name = "Warranty";
            this.Warranty.FieldLenght = 100;
            this.IsReject.Name = "IsReject";
            this.RejectReason.Name = "RejectReason";
            this.RejectReason.FieldLenght = 300;
            this.RejectFile.Name = "RejectFile";
            this.RejectFile.FieldLenght = 4000;
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
        private Column<System.String> _ProductDesc = new Column<System.String>();
        public Column<System.String> ProductDesc
        {
            get
            {
                return _ProductDesc;
            }
            set
            {
                _ProductDesc = value;
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
        private Column<System.Int32?> _IsReject = new Column<System.Int32?>();
        public Column<System.Int32?> IsReject
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
        private Column<System.String> _RejectReason = new Column<System.String>();
        public Column<System.String> RejectReason
        {
            get
            {
                return _RejectReason;
            }
            set
            {
                _RejectReason = value;
            }
        }
        private Column<System.String> _RejectFile = new Column<System.String>();
        public Column<System.String> RejectFile
        {
            get
            {
                return _RejectFile;
            }
            set
            {
                _RejectFile = value;
            }
        }

    }
}
