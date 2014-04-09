using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Views.SEWC
{
    public class View_SEWC_GoodsReceipt_Detail : Columns
    {

        private static View_SEWC_GoodsReceipt_Detail instance;

        public static View_SEWC_GoodsReceipt_Detail GetInstance()
        {
            if (instance == null)
            {
                instance = new View_SEWC_GoodsReceipt_Detail();
            }
            return instance;
        }

        public View_SEWC_GoodsReceipt_Detail()
        {
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
            this.FuntinalStateOriginal.Name = "FuntinalStateOriginal";
            this.FuntinalStateOriginal.FieldLenght = 255;
            this.FirmwareOriginal.Name = "FirmwareOriginal";
            this.FirmwareOriginal.FieldLenght = 255;
            this.RejectFile.Name = "RejectFile";
            this.RejectFile.FieldLenght = 4000;
            this.ServiceType.Name = "ServiceType";
            this.ServiceType.FieldLenght = 20;
            this.ID.Name = "ID";
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



    }
}
