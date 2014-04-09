using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Views.SEWC
{
    public class View_SEWC_Repair_List : Columns
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
        private Column<System.String> _WorkStationCode = new Column<System.String>();
        public Column<System.String> WorkStationCode
        {
            get
            {
                return _WorkStationCode;
            }
            set
            {
                _WorkStationCode = value;
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
        private Column<System.String> _FuntinalStatelatest = new Column<System.String>();
        public Column<System.String> FuntinalStatelatest
        {
            get
            {
                return _FuntinalStatelatest;
            }
            set
            {
                _FuntinalStatelatest = value;
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
        private Column<System.String> _Firmwarelatest = new Column<System.String>();
        public Column<System.String> Firmwarelatest
        {
            get
            {
                return _Firmwarelatest;
            }
            set
            {
                _Firmwarelatest = value;
            }
        }
        private Column<System.DateTime?> _ConfirmCompleteDate = new Column<System.DateTime?>();
        public Column<System.DateTime?> ConfirmCompleteDate
        {
            get
            {
                return _ConfirmCompleteDate;
            }
            set
            {
                _ConfirmCompleteDate = value;
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
        private Column<System.String> _Engineer = new Column<System.String>();
        public Column<System.String> Engineer
        {
            get
            {
                return _Engineer;
            }
            set
            {
                _Engineer = value;
            }
        }
        private Column<System.String> _RepairResult = new Column<System.String>();
        public Column<System.String> RepairResult
        {
            get
            {
                return _RepairResult;
            }
            set
            {
                _RepairResult = value;
            }
        }
        private Column<System.String> _Remarks = new Column<System.String>();
        public Column<System.String> Remarks
        {
            get
            {
                return _Remarks;
            }
            set
            {
                _Remarks = value;
            }
        }
        private Column<System.Boolean?> _isSave = new Column<System.Boolean?>();
        public Column<System.Boolean?> isSave
        {
            get
            {
                return _isSave;
            }
            set
            {
                _isSave = value;
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
