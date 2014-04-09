using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Views.SEWC
{
   public class View_SEWC_IssueRepairOrder_List : Columns
    {
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
        private Column<System.Boolean?> _ReveiveBankReceipt = new Column<System.Boolean?>();
        public Column<System.Boolean?> ReveiveBankReceipt
        {
            get
            {
                return _ReveiveBankReceipt;
            }
            set
            {
                _ReveiveBankReceipt = value;
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
        private Column<System.String> _ModifyUser = new Column<System.String>();
        public Column<System.String> ModifyUser
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
        private Column<System.DateTime?> _IssueRepairOrderDate = new Column<System.DateTime?>();
        public Column<System.DateTime?> IssueRepairOrderDate
        {
            get
            {
                return _IssueRepairOrderDate;
            }
            set
            {
                _IssueRepairOrderDate = value;
            }
        }
        private Column<System.DateTime?> _CustomerConfirmDate = new Column<System.DateTime?>();
        public Column<System.DateTime?> CustomerConfirmDate
        {
            get
            {
                return _CustomerConfirmDate;
            }
            set
            {
                _CustomerConfirmDate = value;
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
        private Column<System.String> _TroubleDesc = new Column<System.String>();
        public Column<System.String> TroubleDesc
        {
            get
            {
                return _TroubleDesc;
            }
            set
            {
                _TroubleDesc = value;
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
        private Column<System.String> _OrderType = new Column<System.String>();
        public Column<System.String> OrderType
        {
            get
            {
                return _OrderType;
            }
            set
            {
                _OrderType = value;
            }
        }
        private Column<System.String> _Repairble = new Column<System.String>();
        public Column<System.String> Repairble
        {
            get
            {
                return _Repairble;
            }
            set
            {
                _Repairble = value;
            }
        }

    }
}
