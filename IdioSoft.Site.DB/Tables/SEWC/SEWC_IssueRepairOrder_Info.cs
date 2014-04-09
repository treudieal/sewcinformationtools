using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Tables.SEWC
{
    public class SEWC_IssueRepairOrder_Info : Columns
    {
        public SEWC_IssueRepairOrder_Info()
        {
            this.ID.Name = "ID";
            this.uRequestID.Name = "uRequestID";
            this.MLFB.Name = "MLFB";
            this.SerialNo.Name = "SerialNo";
            this.Qty.Name = "Qty";
            this.Warranty.Name = "Warranty";
            this.IssueRepairOrderDate.Name = "IssueRepairOrderDate";
            this.Repairble.Name = "Repairble";
            this.ReveiveBankReceipt.Name = "ReveiveBankReceipt";
            this.QuotationDate.Name = "QuotationDate";
            this.IsGoodWill.Name = "IsGoodWill";
            this.GoodWillNo.Name = "GoodWillNo";
            this.CustomerConfirmDate.Name = "CustomerConfirmDate";
            this.CancelReason.Name = "CancelReason";
            this.CancelDate.Name = "CancelDate";
            this.CreateDate.Name = "CreateDate";
            this.CreateUser.Name = "CreateUser";
            this.ModifyDate.Name = "ModifyDate";
            this.ModifyUser.Name = "ModifyUser";
            this.isSubmit.Name = "isSubmit";
            this.OrderType.Name = "OrderType";
            this.ProductDate.Name = "ProductDate";
            this.FactoryOforigin.Name = "FactoryOforigin";
            this.FixPrice.Name = "FixPrice";
            this.TotalPrice.Name = "TotalPrice";
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
        private Column<System.String> _ProductDate = new Column<System.String>();
        public Column<System.String> ProductDate
        {
            get
            {
                return _ProductDate;
            }
            set
            {
                _ProductDate = value;
            }
        }
        private Column<System.String> _FactoryOforigin = new Column<System.String>();
        public Column<System.String> FactoryOforigin
        {
            get
            {
                return _FactoryOforigin;
            }
            set
            {
                _FactoryOforigin = value;
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
