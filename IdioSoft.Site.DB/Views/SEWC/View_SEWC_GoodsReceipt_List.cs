using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Views.SEWC
{
    public class View_SEWC_GoodsReceipt_List : Columns
    {
        private static View_SEWC_GoodsReceipt_List instance;
        public static View_SEWC_GoodsReceipt_List GetInstance()
        {
            if (instance == null)
            {
                instance = new View_SEWC_GoodsReceipt_List();
            }
            return instance;
        }
        public View_SEWC_GoodsReceipt_List()
        {
            this.uRequestID.Name = "uRequestID";
            this.RequestID.Name = "RequestID";
            this.RequestID.FieldLenght = 15;
            this.MLFB.Name = "MLFB";
            this.MLFB.FieldLenght = 100;
            this.SerialNo.Name = "SerialNo";
            this.SerialNo.FieldLenght = 50;
            this.ProductDesc.Name = "ProductDesc";
            this.ProductDesc.FieldLenght = 50;
            this.Warranty.Name = "Warranty";
            this.Warranty.FieldLenght = 50;
            this.ServiceType.Name = "ServiceType";
            this.ServiceType.FieldLenght = 20;
            this.ProductName.Name = "ProductName";
            this.ProductName.FieldLenght = 100;
            this.SEWCNotificationNo.Name = "SEWCNotificationNo";
            this.SEWCNotificationNo.FieldLenght = 100;
            this.Qty.Name = "Qty";
            this.ReceiveDefectiveDateT3.Name = "ReceiveDefectiveDateT3";
            this.IsReject.Name = "IsReject";
            this.RejectReason.Name = "RejectReason";
            this.RejectReason.FieldLenght = 300;
            this.RejectFile.Name = "RejectFile";
            this.RejectFile.FieldLenght = 4000;
            this.CreateDate.Name = "CreateDate";
            this.CreateUser.Name = "CreateUser";
            this.ModifyDate.Name = "ModifyDate";
            this.ModifyUser.Name = "ModifyUser";
            this.isSubmit.Name = "isSubmit";
            this.AppCompanyName.Name = "AppCompanyName";
            this.AppCompanyName.FieldLenght = 255;
            this.EnduserCompanyName.Name = "EnduserCompanyName";
            this.EnduserCompanyName.FieldLenght = 255;
            this.IDays.Name = "IDays";
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
        private Column<System.String> _ProductName = new Column<System.String>();
        public Column<System.String> ProductName
        {
            get
            {
                return _ProductName;
            }
            set
            {
                _ProductName = value;
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
        private Column<System.DateTime?> _ReceiveDefectiveDateT3 = new Column<System.DateTime?>();
        public Column<System.DateTime?> ReceiveDefectiveDateT3
        {
            get
            {
                return _ReceiveDefectiveDateT3;
            }
            set
            {
                _ReceiveDefectiveDateT3 = value;
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
        private Column<System.DateTime?> _CreateDate = new Column<System.DateTime?>();
        public Column<System.DateTime?> CreateDate
        {
            get
            {
                return _CreateDate;
            }
            set
            {
                _CreateDate = value;
            }
        }
        private Column<System.Int32?> _CreateUser = new Column<System.Int32?>();
        public Column<System.Int32?> CreateUser
        {
            get
            {
                return _CreateUser;
            }
            set
            {
                _CreateUser = value;
            }
        }
        private Column<System.DateTime?> _ModifyDate = new Column<System.DateTime?>();
        public Column<System.DateTime?> ModifyDate
        {
            get
            {
                return _ModifyDate;
            }
            set
            {
                _ModifyDate = value;
            }
        }
        private Column<System.Int32?> _ModifyUser = new Column<System.Int32?>();
        public Column<System.Int32?> ModifyUser
        {
            get
            {
                return _ModifyUser;
            }
            set
            {
                _ModifyUser = value;
            }
        }
        private Column<System.Boolean?> _isSubmit = new Column<System.Boolean?>();
        public Column<System.Boolean?> isSubmit
        {
            get
            {
                return _isSubmit;
            }
            set
            {
                _isSubmit = value;
            }
        }
        private Column<System.String> _AppCompanyName = new Column<System.String>();
        public Column<System.String> AppCompanyName
        {
            get
            {
                return _AppCompanyName;
            }
            set
            {
                _AppCompanyName = value;
            }
        }
        private Column<System.String> _EnduserCompanyName = new Column<System.String>();
        public Column<System.String> EnduserCompanyName
        {
            get
            {
                return _EnduserCompanyName;
            }
            set
            {
                _EnduserCompanyName = value;
            }
        }
        private Column<System.Int32?> _IDays = new Column<System.Int32?>();
        public Column<System.Int32?> IDays
        {
            get
            {
                return _IDays;
            }
            set
            {
                _IDays = value;
            }
        }

    }
}
