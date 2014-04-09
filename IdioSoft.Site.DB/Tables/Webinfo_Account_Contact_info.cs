using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdioSoft.Business.Frames;

namespace IdioSoft.Site.DB.Tables
{
   public class Webinfo_Account_Contact_info:Columns
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
        private Column<System.Guid?> _AccountID = new Column<System.Guid?>();
        public Column<System.Guid?> AccountID
        {
            get
            {
                return _AccountID;
            }
            set
            {
                _AccountID = value;
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
        private Column<System.Boolean?> _isSpareSales = new Column<System.Boolean?>();
        public Column<System.Boolean?> isSpareSales
        {
            get
            {
                return _isSpareSales;
            }
            set
            {
                _isSpareSales = value;
            }
        }

    }
}
