using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Views.SEWC
{
    public class View_SFAE_LogisticSearchPlatForm_List : Columns
    {
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
        private Column<System.Guid?> _DispatchID = new Column<System.Guid?>();
        public Column<System.Guid?> DispatchID
        {
            get
            {
                return _DispatchID;
            }
            set
            {
                _DispatchID = value;
            }
        }
        private Column<System.String> _DispatchType = new Column<System.String>();
        public Column<System.String> DispatchType
        {
            get
            {
                return _DispatchType;
            }
            set
            {
                _DispatchType = value;
            }
        }
        private Column<System.DateTime?> _ConsignmentDate = new Column<System.DateTime?>();
        public Column<System.DateTime?> ConsignmentDate
        {
            get
            {
                return _ConsignmentDate;
            }
            set
            {
                _ConsignmentDate = value;
            }
        }
        private Column<System.String> _PickUpType = new Column<System.String>();
        public Column<System.String> PickUpType
        {
            get
            {
                return _PickUpType;
            }
            set
            {
                _PickUpType = value;
            }
        }
        private Column<System.String> _OperationCategory = new Column<System.String>();
        public Column<System.String> OperationCategory
        {
            get
            {
                return _OperationCategory;
            }
            set
            {
                _OperationCategory = value;
            }
        }
        private Column<System.String> _ExpressNo = new Column<System.String>();
        public Column<System.String> ExpressNo
        {
            get
            {
                return _ExpressNo;
            }
            set
            {
                _ExpressNo = value;
            }
        }
        private Column<System.String> _MainNo = new Column<System.String>();
        public Column<System.String> MainNo
        {
            get
            {
                return _MainNo;
            }
            set
            {
                _MainNo = value;
            }
        }
        private Column<System.String> _AssistNo = new Column<System.String>();
        public Column<System.String> AssistNo
        {
            get
            {
                return _AssistNo;
            }
            set
            {
                _AssistNo = value;
            }
        }
        private Column<System.DateTime?> _RequestArriveDate = new Column<System.DateTime?>();
        public Column<System.DateTime?> RequestArriveDate
        {
            get
            {
                return _RequestArriveDate;
            }
            set
            {
                _RequestArriveDate = value;
            }
        }
        private Column<System.DateTime?> _ActualArriveDate = new Column<System.DateTime?>();
        public Column<System.DateTime?> ActualArriveDate
        {
            get
            {
                return _ActualArriveDate;
            }
            set
            {
                _ActualArriveDate = value;
            }
        }
        private Column<System.String> _SignUser = new Column<System.String>();
        public Column<System.String> SignUser
        {
            get
            {
                return _SignUser;
            }
            set
            {
                _SignUser = value;
            }
        }
        private Column<System.String> _Status = new Column<System.String>();
        public Column<System.String> Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }
        private Column<System.DateTime?> _RecordDate = new Column<System.DateTime?>();
        public Column<System.DateTime?> RecordDate
        {
            get
            {
                return _RecordDate;
            }
            set
            {
                _RecordDate = value;
            }
        }
        private Column<System.Int32?> _Timelimit = new Column<System.Int32?>();
        public Column<System.Int32?> Timelimit
        {
            get
            {
                return _Timelimit;
            }
            set
            {
                _Timelimit = value;
            }
        }
        private Column<System.String> _ConsignorKind = new Column<System.String>();
        public Column<System.String> ConsignorKind
        {
            get
            {
                return _ConsignorKind;
            }
            set
            {
                _ConsignorKind = value;
            }
        }
        private Column<System.String> _TypeOfShipping = new Column<System.String>();
        public Column<System.String> TypeOfShipping
        {
            get
            {
                return _TypeOfShipping;
            }
            set
            {
                _TypeOfShipping = value;
            }
        }
        private Column<System.String> _PickupAddress = new Column<System.String>();
        public Column<System.String> PickupAddress
        {
            get
            {
                return _PickupAddress;
            }
            set
            {
                _PickupAddress = value;
            }
        }
        private Column<System.String> _DestinationAddress = new Column<System.String>();
        public Column<System.String> DestinationAddress
        {
            get
            {
                return _DestinationAddress;
            }
            set
            {
                _DestinationAddress = value;
            }
        }
        private Column<System.String> _CompanyName = new Column<System.String>();
        public Column<System.String> CompanyName
        {
            get
            {
                return _CompanyName;
            }
            set
            {
                _CompanyName = value;
            }
        }
        private Column<System.String> _CompanyAddress = new Column<System.String>();
        public Column<System.String> CompanyAddress
        {
            get
            {
                return _CompanyAddress;
            }
            set
            {
                _CompanyAddress = value;
            }
        }
        private Column<System.String> _CompanyConsignee = new Column<System.String>();
        public Column<System.String> CompanyConsignee
        {
            get
            {
                return _CompanyConsignee;
            }
            set
            {
                _CompanyConsignee = value;
            }
        }
        private Column<System.String> _CompanyTel1 = new Column<System.String>();
        public Column<System.String> CompanyTel1
        {
            get
            {
                return _CompanyTel1;
            }
            set
            {
                _CompanyTel1 = value;
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
        private Column<System.Decimal?> _ActualWeight = new Column<System.Decimal?>();
        public Column<System.Decimal?> ActualWeight
        {
            get
            {
                return _ActualWeight;
            }
            set
            {
                _ActualWeight = value;
            }
        }
        private Column<System.Decimal?> _CostWeight = new Column<System.Decimal?>();
        public Column<System.Decimal?> CostWeight
        {
            get
            {
                return _CostWeight;
            }
            set
            {
                _CostWeight = value;
            }
        }
        private Column<System.Decimal?> _UnitPrice = new Column<System.Decimal?>();
        public Column<System.Decimal?> UnitPrice
        {
            get
            {
                return _UnitPrice;
            }
            set
            {
                _UnitPrice = value;
            }
        }
        private Column<System.Decimal?> _TransCost = new Column<System.Decimal?>();
        public Column<System.Decimal?> TransCost
        {
            get
            {
                return _TransCost;
            }
            set
            {
                _TransCost = value;
            }
        }
        private Column<System.String> _TranCity = new Column<System.String>();
        public Column<System.String> TranCity
        {
            get
            {
                return _TranCity;
            }
            set
            {
                _TranCity = value;
            }
        }
        private Column<System.Decimal?> _Kil = new Column<System.Decimal?>();
        public Column<System.Decimal?> Kil
        {
            get
            {
                return _Kil;
            }
            set
            {
                _Kil = value;
            }
        }
        private Column<System.Decimal?> _MorelongCost = new Column<System.Decimal?>();
        public Column<System.Decimal?> MorelongCost
        {
            get
            {
                return _MorelongCost;
            }
            set
            {
                _MorelongCost = value;
            }
        }
        private Column<System.Decimal?> _PackCost = new Column<System.Decimal?>();
        public Column<System.Decimal?> PackCost
        {
            get
            {
                return _PackCost;
            }
            set
            {
                _PackCost = value;
            }
        }
        private Column<System.Decimal?> _OtherCost = new Column<System.Decimal?>();
        public Column<System.Decimal?> OtherCost
        {
            get
            {
                return _OtherCost;
            }
            set
            {
                _OtherCost = value;
            }
        }
        private Column<System.Decimal?> _AddCost = new Column<System.Decimal?>();
        public Column<System.Decimal?> AddCost
        {
            get
            {
                return _AddCost;
            }
            set
            {
                _AddCost = value;
            }
        }
        private Column<System.String> _PackMaterial = new Column<System.String>();
        public Column<System.String> PackMaterial
        {
            get
            {
                return _PackMaterial;
            }
            set
            {
                _PackMaterial = value;
            }
        }
        private Column<System.String> _storeKeeper = new Column<System.String>();
        public Column<System.String> storeKeeper
        {
            get
            {
                return _storeKeeper;
            }
            set
            {
                _storeKeeper = value;
            }
        }
        private Column<System.String> _OrderApplicant = new Column<System.String>();
        public Column<System.String> OrderApplicant
        {
            get
            {
                return _OrderApplicant;
            }
            set
            {
                _OrderApplicant = value;
            }
        }
        private Column<System.String> _forwardingAgents = new Column<System.String>();
        public Column<System.String> forwardingAgents
        {
            get
            {
                return _forwardingAgents;
            }
            set
            {
                _forwardingAgents = value;
            }
        }
        private Column<System.String> _sfaeComments = new Column<System.String>();
        public Column<System.String> sfaeComments
        {
            get
            {
                return _sfaeComments;
            }
            set
            {
                _sfaeComments = value;
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
        private Column<System.Int32?> _OrderApplicantID = new Column<System.Int32?>();
        public Column<System.Int32?> OrderApplicantID
        {
            get
            {
                return _OrderApplicantID;
            }
            set
            {
                _OrderApplicantID = value;
            }
        }
        private Column<System.String> _ContractNo = new Column<System.String>();
        public Column<System.String> ContractNo
        {
            get
            {
                return _ContractNo;
            }
            set
            {
                _ContractNo = value;
            }
        }
        private Column<System.String> _SupplierCode = new Column<System.String>();
        public Column<System.String> SupplierCode
        {
            get
            {
                return _SupplierCode;
            }
            set
            {
                _SupplierCode = value;
            }
        }
    }
}
