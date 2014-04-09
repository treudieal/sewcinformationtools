using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Views
{
   public class View_Callcenter_AccountContact_List:Columns
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
        private Column<System.String> _CustomerID = new Column<System.String>();
        public Column<System.String> CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                _CustomerID = value;
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
        private Column<System.String> _SubOffice = new Column<System.String>();
        public Column<System.String> SubOffice
        {
            get
            {
                return _SubOffice;
            }
            set
            {
                _SubOffice = value;
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
        private Column<System.String> _CustomerType = new Column<System.String>();
        public Column<System.String> CustomerType
        {
            get
            {
                return _CustomerType;
            }
            set
            {
                _CustomerType = value;
            }
        }
        private Column<System.String> _createuser = new Column<System.String>();
        public Column<System.String> createuser
        {
            get
            {
                return _createuser;
            }
            set
            {
                _createuser = value;
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
        private Column<System.String> _PostAddress = new Column<System.String>();
        public Column<System.String> PostAddress
        {
            get
            {
                return _PostAddress;
            }
            set
            {
                _PostAddress = value;
            }
        }
        private Column<System.String> _RegAddress = new Column<System.String>();
        public Column<System.String> RegAddress
        {
            get
            {
                return _RegAddress;
            }
            set
            {
                _RegAddress = value;
            }
        }
        private Column<System.String> _ConsignorAddress = new Column<System.String>();
        public Column<System.String> ConsignorAddress
        {
            get
            {
                return _ConsignorAddress;
            }
            set
            {
                _ConsignorAddress = value;
            }
        }
        private Column<System.String> _TaxCode = new Column<System.String>();
        public Column<System.String> TaxCode
        {
            get
            {
                return _TaxCode;
            }
            set
            {
                _TaxCode = value;
            }
        }
        private Column<System.String> _AccountCode = new Column<System.String>();
        public Column<System.String> AccountCode
        {
            get
            {
                return _AccountCode;
            }
            set
            {
                _AccountCode = value;
            }
        }
        private Column<System.String> _BankName = new Column<System.String>();
        public Column<System.String> BankName
        {
            get
            {
                return _BankName;
            }
            set
            {
                _BankName = value;
            }
        }
        private Column<System.String> _PostCode = new Column<System.String>();
        public Column<System.String> PostCode
        {
            get
            {
                return _PostCode;
            }
            set
            {
                _PostCode = value;
            }
        }
        private Column<System.String> _SpareSalesCustomerType = new Column<System.String>();
        public Column<System.String> SpareSalesCustomerType
        {
            get
            {
                return _SpareSalesCustomerType;
            }
            set
            {
                _SpareSalesCustomerType = value;
            }
        }
        private Column<System.String> _FinanceTel = new Column<System.String>();
        public Column<System.String> FinanceTel
        {
            get
            {
                return _FinanceTel;
            }
            set
            {
                _FinanceTel = value;
            }
        }
        private Column<System.String> _Country = new Column<System.String>();
        public Column<System.String> Country
        {
            get
            {
                return _Country;
            }
            set
            {
                _Country = value;
            }
        }
        private Column<System.String> _Branch = new Column<System.String>();
        public Column<System.String> Branch
        {
            get
            {
                return _Branch;
            }
            set
            {
                _Branch = value;
            }
        }
        private Column<System.Boolean?> _isHelpLine = new Column<System.Boolean?>();
        public Column<System.Boolean?> isHelpLine
        {
            get
            {
                return _isHelpLine;
            }
            set
            {
                _isHelpLine = value;
            }
        }
        private Column<System.String> _VIPID = new Column<System.String>();
        public Column<System.String> VIPID
        {
            get
            {
                return _VIPID;
            }
            set
            {
                _VIPID = value;
            }
        }
        private Column<System.String> _ContactName = new Column<System.String>();
        public Column<System.String> ContactName
        {
            get
            {
                return _ContactName;
            }
            set
            {
                _ContactName = value;
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
        private Column<System.String> _Mobile = new Column<System.String>();
        public Column<System.String> Mobile
        {
            get
            {
                return _Mobile;
            }
            set
            {
                _Mobile = value;
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
        private Column<System.String> _Email = new Column<System.String>();
        public Column<System.String> Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }
        private Column<System.Boolean?> _isDel = new Column<System.Boolean?>();
        public Column<System.Boolean?> isDel
        {
            get
            {
                return _isDel;
            }
            set
            {
                _isDel = value;
            }
        }
        private Column<System.String> _VIPCompanyENName = new Column<System.String>();
        public Column<System.String> VIPCompanyENName
        {
            get
            {
                return _VIPCompanyENName;
            }
            set
            {
                _VIPCompanyENName = value;
            }
        }
        private Column<System.String> _VIPCompanyCNName = new Column<System.String>();
        public Column<System.String> VIPCompanyCNName
        {
            get
            {
                return _VIPCompanyCNName;
            }
            set
            {
                _VIPCompanyCNName = value;
            }
        }
        private Column<System.String> _CompanyKeyWords = new Column<System.String>();
        public Column<System.String> CompanyKeyWords
        {
            get
            {
                return _CompanyKeyWords;
            }
            set
            {
                _CompanyKeyWords = value;
            }
        }

    }
}
