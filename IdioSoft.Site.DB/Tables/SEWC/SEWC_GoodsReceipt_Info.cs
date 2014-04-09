using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.Data;
using System.Reflection;
using IdioSoft.Business.Frames;

namespace IdioSoft.Site.DB.Tables.SEWC
{
    [Serializable]
    public class SEWC_GoodsReceipt_Info : Columns
    {
        private static SEWC_GoodsReceipt_Info instance;

        public static SEWC_GoodsReceipt_Info GetInstance()
        {
            if (instance == null)
            {
                instance = new SEWC_GoodsReceipt_Info();
            }
            return instance;
        }

        public SEWC_GoodsReceipt_Info()
        {
            this.ID.Name = "ID";
            this.uRequestID.Name = "uRequestID";
            this.SEWCNotificationNo.Name = "SEWCNotificationNo";
            this.SEWCNotificationNo.FieldLenght = 100;
            this.ProductName.Name = "ProductName";
            this.ProductName.FieldLenght = 50;
            this.ProductDesc.Name = "ProductDesc";
            this.ProductDesc.FieldLenght = 50;
            this.MLFB.Name = "MLFB";
            this.MLFB.FieldLenght = 100;
            this.SerialNo.Name = "SerialNo";
            this.SerialNo.FieldLenght = 100;
            this.Qty.Name = "Qty";
            this.Warranty.Name = "Warranty";
            this.Warranty.FieldLenght = 100;
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
            this.FuntinalStateOriginal.Name = "FuntinalStateOriginal";
            this.FuntinalStateOriginal.FieldLenght = 255;
            this.FirmwareOriginal.Name = "FirmwareOriginal";
            this.FirmwareOriginal.FieldLenght = 255;
            this.ReturnNo.Name = "ReturnNo";
            this.ReturnNo.FieldLenght = 50;
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
        private Column<System.String> _FuntinalStateOriginal = new Column<System.String>();
        public Column<System.String> FuntinalStateOriginal
        {
            get
            {
                return _FuntinalStateOriginal;
            }
            set
            {
                _FuntinalStateOriginal = value;
            }
        }
        private Column<System.String> _FirmwareOriginal = new Column<System.String>();
        public Column<System.String> FirmwareOriginal
        {
            get
            {
                return _FirmwareOriginal;
            }
            set
            {
                _FirmwareOriginal = value;
            }
        }
        private Column<System.String> _ReturnNo = new Column<System.String>();
        public Column<System.String> ReturnNo
        {
            get
            {
                return _ReturnNo;
            }
            set
            {
                _ReturnNo = value;
            }
        }


    }
}
