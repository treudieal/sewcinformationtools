using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Views.SEWC
{
    public class View_SFAE_LogisticSearchPlatForm_DispatchList : Columns
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
        private Column<System.Guid?> _RequestID = new Column<System.Guid?>();
        public Column<System.Guid?> RequestID
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
        private Column<System.String> _SalesOrderNo = new Column<System.String>();
        public Column<System.String> SalesOrderNo
        {
            get
            {
                return _SalesOrderNo;
            }
            set
            {
                _SalesOrderNo = value;
            }
        }
        private Column<System.String> _ServiceOrderNo = new Column<System.String>();
        public Column<System.String> ServiceOrderNo
        {
            get
            {
                return _ServiceOrderNo;
            }
            set
            {
                _ServiceOrderNo = value;
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
        private Column<System.String> _WBSNo = new Column<System.String>();
        public Column<System.String> WBSNo
        {
            get
            {
                return _WBSNo;
            }
            set
            {
                _WBSNo = value;
            }
        }
        private Column<System.String> _RepairOrderNo = new Column<System.String>();
        public Column<System.String> RepairOrderNo
        {
            get
            {
                return _RepairOrderNo;
            }
            set
            {
                _RepairOrderNo = value;
            }
        }
        private Column<System.String> _s4000No = new Column<System.String>();
        public Column<System.String> s4000No
        {
            get
            {
                return _s4000No;
            }
            set
            {
                _s4000No = value;
            }
        }
        private Column<System.String> _CostCenter = new Column<System.String>();
        public Column<System.String> CostCenter
        {
            get
            {
                return _CostCenter;
            }
            set
            {
                _CostCenter = value;
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
        private Column<System.String> _CustomerName = new Column<System.String>();
        public Column<System.String> CustomerName
        {
            get
            {
                return _CustomerName;
            }
            set
            {
                _CustomerName = value;
            }
        }
        private Column<System.String> _Address = new Column<System.String>();
        public Column<System.String> Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }
        private Column<System.String> _Zip = new Column<System.String>();
        public Column<System.String> Zip
        {
            get
            {
                return _Zip;
            }
            set
            {
                _Zip = value;
            }
        }
        private Column<System.String> _Contact = new Column<System.String>();
        public Column<System.String> Contact
        {
            get
            {
                return _Contact;
            }
            set
            {
                _Contact = value;
            }
        }
        private Column<System.String> _Tel = new Column<System.String>();
        public Column<System.String> Tel
        {
            get
            {
                return _Tel;
            }
            set
            {
                _Tel = value;
            }
        }
        private Column<System.String> _Fax = new Column<System.String>();
        public Column<System.String> Fax
        {
            get
            {
                return _Fax;
            }
            set
            {
                _Fax = value;
            }
        }
        private Column<System.Int32?> _DevHours = new Column<System.Int32?>();
        public Column<System.Int32?> DevHours
        {
            get
            {
                return _DevHours;
            }
            set
            {
                _DevHours = value;
            }
        }
        private Column<System.DateTime?> _DevDate = new Column<System.DateTime?>();
        public Column<System.DateTime?> DevDate
        {
            get
            {
                return _DevDate;
            }
            set
            {
                _DevDate = value;
            }
        }
        private Column<System.DateTime?> _ReturnDate = new Column<System.DateTime?>();
        public Column<System.DateTime?> ReturnDate
        {
            get
            {
                return _ReturnDate;
            }
            set
            {
                _ReturnDate = value;
            }
        }
        private Column<System.String> _Comments = new Column<System.String>();
        public Column<System.String> Comments
        {
            get
            {
                return _Comments;
            }
            set
            {
                _Comments = value;
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
        private Column<System.String> _CustomerName1 = new Column<System.String>();
        public Column<System.String> CustomerName1
        {
            get
            {
                return _CustomerName1;
            }
            set
            {
                _CustomerName1 = value;
            }
        }
        private Column<System.String> _Address1 = new Column<System.String>();
        public Column<System.String> Address1
        {
            get
            {
                return _Address1;
            }
            set
            {
                _Address1 = value;
            }
        }
        private Column<System.String> _Zip1 = new Column<System.String>();
        public Column<System.String> Zip1
        {
            get
            {
                return _Zip1;
            }
            set
            {
                _Zip1 = value;
            }
        }
        private Column<System.String> _Contact1 = new Column<System.String>();
        public Column<System.String> Contact1
        {
            get
            {
                return _Contact1;
            }
            set
            {
                _Contact1 = value;
            }
        }
        private Column<System.String> _Tel1 = new Column<System.String>();
        public Column<System.String> Tel1
        {
            get
            {
                return _Tel1;
            }
            set
            {
                _Tel1 = value;
            }
        }
        private Column<System.String> _Fax1 = new Column<System.String>();
        public Column<System.String> Fax1
        {
            get
            {
                return _Fax1;
            }
            set
            {
                _Fax1 = value;
            }
        }
        private Column<System.String> _OtherMaterialList = new Column<System.String>();
        public Column<System.String> OtherMaterialList
        {
            get
            {
                return _OtherMaterialList;
            }
            set
            {
                _OtherMaterialList = value;
            }
        }
        private Column<System.String> _OutAddress = new Column<System.String>();
        public Column<System.String> OutAddress
        {
            get
            {
                return _OutAddress;
            }
            set
            {
                _OutAddress = value;
            }
        }
        private Column<System.String> _serviceType = new Column<System.String>();
        public Column<System.String> serviceType
        {
            get
            {
                return _serviceType;
            }
            set
            {
                _serviceType = value;
            }
        }
        private Column<System.String> _Province = new Column<System.String>();
        public Column<System.String> Province
        {
            get
            {
                return _Province;
            }
            set
            {
                _Province = value;
            }
        }
        private Column<System.String> _City = new Column<System.String>();
        public Column<System.String> City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
            }
        }
        private Column<System.Int32?> _Status = new Column<System.Int32?>();
        public Column<System.Int32?> Status
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
    }
}
