using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Views.SEWC
{
    public class View_SEWC_IssueRepairOrder_MDetial : Columns
    {
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
        private Column<System.Boolean?> _IsGoodWill = new Column<System.Boolean?>();
        public Column<System.Boolean?> IsGoodWill
        {
            get
            {
                return _IsGoodWill;
            }
            set
            {
                _IsGoodWill = value;
            }
        }
        private Column<System.String> _GoodWillNo = new Column<System.String>();
        public Column<System.String> GoodWillNo
        {
            get
            {
                return _GoodWillNo;
            }
            set
            {
                _GoodWillNo = value;
            }
        }
        private Column<System.DateTime?> _CancelDate = new Column<System.DateTime?>();
        public Column<System.DateTime?> CancelDate
        {
            get
            {
                return _CancelDate;
            }
            set
            {
                _CancelDate = value;
            }
        }
        private Column<System.String> _CancelReason = new Column<System.String>();
        public Column<System.String> CancelReason
        {
            get
            {
                return _CancelReason;
            }
            set
            {
                _CancelReason = value;
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
        private Column<System.DateTime?> _QuotationDate = new Column<System.DateTime?>();
        public Column<System.DateTime?> QuotationDate
        {
            get
            {
                return _QuotationDate;
            }
            set
            {
                _QuotationDate = value;
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
        private Column<System.Boolean?> _FixPrice = new Column<System.Boolean?>();
        public Column<System.Boolean?> FixPrice
        {
            get
            {
                return _FixPrice;
            }
            set
            {
                _FixPrice = value;
            }
        }
        private Column<System.Decimal?> _TotalPrice = new Column<System.Decimal?>();
        public Column<System.Decimal?> TotalPrice
        {
            get
            {
                return _TotalPrice;
            }
            set
            {
                _TotalPrice = value;
            }
        }


    }
}
