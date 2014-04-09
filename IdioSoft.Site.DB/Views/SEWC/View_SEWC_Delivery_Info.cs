using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Views.SEWC
{
    public class View_SEWC_Delivery_Info : Columns
    {
        private static View_SEWC_Delivery_Info instance;
        public static View_SEWC_Delivery_Info GetInstance()
        {
            if (instance == null)
            {
                instance = new View_SEWC_Delivery_Info();
            }
            return instance;
        }
        public View_SEWC_Delivery_Info()
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
            this.AppCompanyName.Name = "AppCompanyName";
            this.AppCompanyName.FieldLenght = 255;
            this.EnduserCompanyName.Name = "EnduserCompanyName";
            this.EnduserCompanyName.FieldLenght = 255;
            this.DeliveryCustomer.Name = "DeliveryCustomer";
            this.DeliveryCustomer.FieldLenght = 100;
            this.ProductName.Name = "ProductName";
            this.ProductName.FieldLenght = 100;
            this.ProductDesc.Name = "ProductDesc";
            this.ProductDesc.FieldLenght = 50;
            this.ServiceType.Name = "ServiceType";
            this.ServiceType.FieldLenght = 20;
            this.ProductGroup.Name = "ProductGroup";
            this.ProductGroup.FieldLenght = 50;
            this.SEWCNotificationNo.Name = "SEWCNotificationNo";
            this.SEWCNotificationNo.FieldLenght = 100;
            this.CreateUser.Name = "CreateUser";
            this.CreateUser.FieldLenght = 100;
            this.CaseTime.Name = "CaseTime";
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
        private Column<System.String> _DeliveryCustomer = new Column<System.String>();
        public Column<System.String> DeliveryCustomer
        {
            get
            {
                return _DeliveryCustomer;
            }
            set
            {
                _DeliveryCustomer = value;
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
        private Column<System.String> _ProductGroup = new Column<System.String>();
        public Column<System.String> ProductGroup
        {
            get
            {
                return _ProductGroup;
            }
            set
            {
                _ProductGroup = value;
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
        private Column<System.String> _CreateUser = new Column<System.String>();
        public Column<System.String> CreateUser
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
        private Column<System.DateTime?> _CaseTime = new Column<System.DateTime?>();
        public Column<System.DateTime?> CaseTime
        {
            get
            {
                return _CaseTime;
            }
            set
            {
                _CaseTime = value;
            }
        }

    }
}
