using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Tables.User
{
    public class webinfo_loginInfo : Columns
    {
        private static webinfo_loginInfo instance;
        public static webinfo_loginInfo GetInstance()
        {
            if (instance == null)
            {
                instance = new webinfo_loginInfo();
            }
            return instance;
        }
        public webinfo_loginInfo()
        {
            this.ID.Name = "ID";
            this.Email.Name = "Email";
            this.Email.FieldLenght = 255;
            this.LoginPwd.Name = "LoginPwd";
            this.LoginPwd.FieldLenght = 20;
            this.EnUserName.Name = "EnUserName";
            this.EnUserName.FieldLenght = 100;
            this.CnUserName.Name = "CnUserName";
            this.CnUserName.FieldLenght = 50;
            this.Region.Name = "Region";
            this.Region.FieldLenght = 10;
            this.ServiceProvider.Name = "ServiceProvider";
            this.ServiceProvider.FieldLenght = 50;
            this.Tel.Name = "Tel";
            this.Tel.FieldLenght = 50;
            this.Fax.Name = "Fax";
            this.Fax.FieldLenght = 50;
            this.SystemLimited.Name = "SystemLimited";
            this.DutyLimited.Name = "DutyLimited";
            this.SetPage.Name = "SetPage";
            this.isEngineer.Name = "isEngineer";
            this.CreateDate.Name = "CreateDate";
            this.CreateUser.Name = "CreateUser";
            this.isDel.Name = "isDel";
            this.Distributors.Name = "Distributors";
            this.Distributors.FieldLenght = 100;
            this.DefaultPage.Name = "DefaultPage";
            this.DefaultPage.FieldLenght = 100;
            this.SfaeSpareSalesBU.Name = "SfaeSpareSalesBU";
            this.SortID.Name = "SortID";
            this.SIASRepairCategory.Name = "SIASRepairCategory";
            this.StockNo.Name = "StockNo";
            this.StockNo.FieldLenght = 50;
            this.Office.Name = "Office";
            this.Office.FieldLenght = 50;
            this.PersonNo.Name = "PersonNo";
            this.PersonNo.FieldLenght = 50;
            this.EngineerGroup.Name = "EngineerGroup";
            this.EngineerGroup.FieldLenght = 50;
            this.Mobile.Name = "Mobile";
            this.Mobile.FieldLenght = 50;
            this.ModuleLimited.Name = "ModuleLimited";
            this.issfaeihrmotorengineer.Name = "issfaeihrmotorengineer";
            this.issfaeLogisticSA.Name = "issfaeLogisticSA";
            this.isSfaeSDEngineer.Name = "isSfaeSDEngineer";
            this.OperDutyType.Name = "OperDutyType";
            this.OperDutyType.FieldLenght = 50;
            this.isTran.Name = "isTran";
            this.isESP.Name = "isESP";
            this.SystemLimiteds.Name = "SystemLimiteds";
            this.BUs.Name = "BUs";
            this.BUs.FieldLenght = 500;
            this.SEALLimiteds.Name = "SEALLimiteds";
            this.SEALLimiteds.FieldLenght = 500;
            this.CSSNCLimiteds.Name = "CSSNCLimiteds";
            this.CSSNCLimiteds.FieldLenght = 500;
            this.ProductLimited.Name = "ProductLimited";
            this.ProductLimited.FieldLenght = 500;
            this.SSCLLimiteds.Name = "SSCLLimiteds";
            this.SSCLLimiteds.FieldLenght = 500;
            this.GoodWillLimiteds.Name = "GoodWillLimiteds";
            this.GoodWillLimiteds.FieldLenght = 500;
            this.IsFollowCallCenter.Name = "IsFollowCallCenter";
            this.isDisplayRequest.Name = "isDisplayRequest";
            this.SFAEMType.Name = "SFAEMType";
            this.SFAEMType.FieldLenght = 50;
            this.issa.Name = "issa";
            this.UserScreenHeight.Name = "UserScreenHeight";
            this.UserScreenWidth.Name = "UserScreenWidth";
            this.AHeight.Name = "AHeight";
            this.DomainInfo.Name = "DomainInfo";
            this.DomainInfo.FieldLenght = 100;
            this.SEWCLimiteds.Name = "SEWCLimiteds";
            this.SEWCLimiteds.FieldLenght = 500;
            this.EscLimiteds.Name = "EscLimiteds";
            this.EscLimiteds.FieldLenght = 500;
            this.nvd.Name = "nvd";
        }
        private Column<System.Int32?> _ID = new Column<System.Int32?>();
        public Column<System.Int32?> ID
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
        private Column<System.String> _LoginPwd = new Column<System.String>();
        public Column<System.String> LoginPwd
        {
            get
            {
                return _LoginPwd;
            }
            set
            {
                _LoginPwd = value;
            }
        }
        private Column<System.String> _EnUserName = new Column<System.String>();
        public Column<System.String> EnUserName
        {
            get
            {
                return _EnUserName;
            }
            set
            {
                _EnUserName = value;
            }
        }
        private Column<System.String> _CnUserName = new Column<System.String>();
        public Column<System.String> CnUserName
        {
            get
            {
                return _CnUserName;
            }
            set
            {
                _CnUserName = value;
            }
        }
        private Column<System.String> _Region = new Column<System.String>();
        public Column<System.String> Region
        {
            get
            {
                return _Region;
            }
            set
            {
                _Region = value;
            }
        }
        private Column<System.String> _ServiceProvider = new Column<System.String>();
        public Column<System.String> ServiceProvider
        {
            get
            {
                return _ServiceProvider;
            }
            set
            {
                _ServiceProvider = value;
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
        private Column<System.String> _SystemLimited = new Column<System.String>();
        public Column<System.String> SystemLimited
        {
            get
            {
                return _SystemLimited;
            }
            set
            {
                _SystemLimited = value;
            }
        }
        private Column<System.String> _DutyLimited = new Column<System.String>();
        public Column<System.String> DutyLimited
        {
            get
            {
                return _DutyLimited;
            }
            set
            {
                _DutyLimited = value;
            }
        }
        private Column<System.Int32?> _SetPage = new Column<System.Int32?>();
        public Column<System.Int32?> SetPage
        {
            get
            {
                return _SetPage;
            }
            set
            {
                _SetPage = value;
            }
        }
        private Column<System.Boolean?> _isEngineer = new Column<System.Boolean?>();
        public Column<System.Boolean?> isEngineer
        {
            get
            {
                return _isEngineer;
            }
            set
            {
                _isEngineer = value;
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
        private Column<System.String> _Distributors = new Column<System.String>();
        public Column<System.String> Distributors
        {
            get
            {
                return _Distributors;
            }
            set
            {
                _Distributors = value;
            }
        }
        private Column<System.String> _DefaultPage = new Column<System.String>();
        public Column<System.String> DefaultPage
        {
            get
            {
                return _DefaultPage;
            }
            set
            {
                _DefaultPage = value;
            }
        }
        private Column<System.String> _SfaeSpareSalesBU = new Column<System.String>();
        public Column<System.String> SfaeSpareSalesBU
        {
            get
            {
                return _SfaeSpareSalesBU;
            }
            set
            {
                _SfaeSpareSalesBU = value;
            }
        }
        private Column<System.Int32?> _SortID = new Column<System.Int32?>();
        public Column<System.Int32?> SortID
        {
            get
            {
                return _SortID;
            }
            set
            {
                _SortID = value;
            }
        }
        private Column<System.String> _SIASRepairCategory = new Column<System.String>();
        public Column<System.String> SIASRepairCategory
        {
            get
            {
                return _SIASRepairCategory;
            }
            set
            {
                _SIASRepairCategory = value;
            }
        }
        private Column<System.String> _StockNo = new Column<System.String>();
        public Column<System.String> StockNo
        {
            get
            {
                return _StockNo;
            }
            set
            {
                _StockNo = value;
            }
        }
        private Column<System.String> _Office = new Column<System.String>();
        public Column<System.String> Office
        {
            get
            {
                return _Office;
            }
            set
            {
                _Office = value;
            }
        }
        private Column<System.String> _PersonNo = new Column<System.String>();
        public Column<System.String> PersonNo
        {
            get
            {
                return _PersonNo;
            }
            set
            {
                _PersonNo = value;
            }
        }
        private Column<System.String> _EngineerGroup = new Column<System.String>();
        public Column<System.String> EngineerGroup
        {
            get
            {
                return _EngineerGroup;
            }
            set
            {
                _EngineerGroup = value;
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
        private Column<System.String> _ModuleLimited = new Column<System.String>();
        public Column<System.String> ModuleLimited
        {
            get
            {
                return _ModuleLimited;
            }
            set
            {
                _ModuleLimited = value;
            }
        }
        private Column<System.Boolean?> _issfaeihrmotorengineer = new Column<System.Boolean?>();
        public Column<System.Boolean?> issfaeihrmotorengineer
        {
            get
            {
                return _issfaeihrmotorengineer;
            }
            set
            {
                _issfaeihrmotorengineer = value;
            }
        }
        private Column<System.Boolean?> _issfaeLogisticSA = new Column<System.Boolean?>();
        public Column<System.Boolean?> issfaeLogisticSA
        {
            get
            {
                return _issfaeLogisticSA;
            }
            set
            {
                _issfaeLogisticSA = value;
            }
        }
        private Column<System.Boolean?> _isSfaeSDEngineer = new Column<System.Boolean?>();
        public Column<System.Boolean?> isSfaeSDEngineer
        {
            get
            {
                return _isSfaeSDEngineer;
            }
            set
            {
                _isSfaeSDEngineer = value;
            }
        }
        private Column<System.String> _OperDutyType = new Column<System.String>();
        public Column<System.String> OperDutyType
        {
            get
            {
                return _OperDutyType;
            }
            set
            {
                _OperDutyType = value;
            }
        }
        private Column<System.Boolean?> _isTran = new Column<System.Boolean?>();
        public Column<System.Boolean?> isTran
        {
            get
            {
                return _isTran;
            }
            set
            {
                _isTran = value;
            }
        }
        private Column<System.Boolean?> _isESP = new Column<System.Boolean?>();
        public Column<System.Boolean?> isESP
        {
            get
            {
                return _isESP;
            }
            set
            {
                _isESP = value;
            }
        }
        private Column<System.String> _SystemLimiteds = new Column<System.String>();
        public Column<System.String> SystemLimiteds
        {
            get
            {
                return _SystemLimiteds;
            }
            set
            {
                _SystemLimiteds = value;
            }
        }
        private Column<System.String> _BUs = new Column<System.String>();
        public Column<System.String> BUs
        {
            get
            {
                return _BUs;
            }
            set
            {
                _BUs = value;
            }
        }
        private Column<System.String> _SEALLimiteds = new Column<System.String>();
        public Column<System.String> SEALLimiteds
        {
            get
            {
                return _SEALLimiteds;
            }
            set
            {
                _SEALLimiteds = value;
            }
        }
        private Column<System.String> _CSSNCLimiteds = new Column<System.String>();
        public Column<System.String> CSSNCLimiteds
        {
            get
            {
                return _CSSNCLimiteds;
            }
            set
            {
                _CSSNCLimiteds = value;
            }
        }
        private Column<System.String> _ProductLimited = new Column<System.String>();
        public Column<System.String> ProductLimited
        {
            get
            {
                return _ProductLimited;
            }
            set
            {
                _ProductLimited = value;
            }
        }
        private Column<System.String> _SSCLLimiteds = new Column<System.String>();
        public Column<System.String> SSCLLimiteds
        {
            get
            {
                return _SSCLLimiteds;
            }
            set
            {
                _SSCLLimiteds = value;
            }
        }
        private Column<System.String> _GoodWillLimiteds = new Column<System.String>();
        public Column<System.String> GoodWillLimiteds
        {
            get
            {
                return _GoodWillLimiteds;
            }
            set
            {
                _GoodWillLimiteds = value;
            }
        }
        private Column<System.Boolean?> _IsFollowCallCenter = new Column<System.Boolean?>();
        public Column<System.Boolean?> IsFollowCallCenter
        {
            get
            {
                return _IsFollowCallCenter;
            }
            set
            {
                _IsFollowCallCenter = value;
            }
        }
        private Column<System.Boolean?> _isDisplayRequest = new Column<System.Boolean?>();
        public Column<System.Boolean?> isDisplayRequest
        {
            get
            {
                return _isDisplayRequest;
            }
            set
            {
                _isDisplayRequest = value;
            }
        }
        private Column<System.String> _SFAEMType = new Column<System.String>();
        public Column<System.String> SFAEMType
        {
            get
            {
                return _SFAEMType;
            }
            set
            {
                _SFAEMType = value;
            }
        }
        private Column<System.Boolean?> _issa = new Column<System.Boolean?>();
        public Column<System.Boolean?> issa
        {
            get
            {
                return _issa;
            }
            set
            {
                _issa = value;
            }
        }
        private Column<System.Int32?> _UserScreenHeight = new Column<System.Int32?>();
        public Column<System.Int32?> UserScreenHeight
        {
            get
            {
                return _UserScreenHeight;
            }
            set
            {
                _UserScreenHeight = value;
            }
        }
        private Column<System.Int32?> _UserScreenWidth = new Column<System.Int32?>();
        public Column<System.Int32?> UserScreenWidth
        {
            get
            {
                return _UserScreenWidth;
            }
            set
            {
                _UserScreenWidth = value;
            }
        }
        private Column<System.Int32?> _AHeight = new Column<System.Int32?>();
        public Column<System.Int32?> AHeight
        {
            get
            {
                return _AHeight;
            }
            set
            {
                _AHeight = value;
            }
        }
        private Column<System.String> _DomainInfo = new Column<System.String>();
        public Column<System.String> DomainInfo
        {
            get
            {
                return _DomainInfo;
            }
            set
            {
                _DomainInfo = value;
            }
        }
        private Column<System.String> _SEWCLimiteds = new Column<System.String>();
        public Column<System.String> SEWCLimiteds
        {
            get
            {
                return _SEWCLimiteds;
            }
            set
            {
                _SEWCLimiteds = value;
            }
        }
        private Column<System.String> _EscLimiteds = new Column<System.String>();
        public Column<System.String> EscLimiteds
        {
            get
            {
                return _EscLimiteds;
            }
            set
            {
                _EscLimiteds = value;
            }
        }
        private Column<System.Guid?> _nvd = new Column<System.Guid?>();
        public Column<System.Guid?> nvd
        {
            get
            {
                return _nvd;
            }
            set
            {
                _nvd = value;
            }
        }

    }
}
