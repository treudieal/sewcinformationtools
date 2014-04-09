using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Views.SEWC
{
    public class View_SEWC_Request_Info : Columns
    {
        private static View_SEWC_Request_Info instance;
        public static View_SEWC_Request_Info GetInstance()
        {
            if (instance == null)
            {
                instance = new View_SEWC_Request_Info();
            }
            return instance;
        }
        public View_SEWC_Request_Info()
        {
            this.uRequestID.Name = "uRequestID";
            this.RequestID.Name = "RequestID";
            this.RequestID.FieldLenght = 15;
            this.NotificationNo.Name = "NotificationNo";
            this.NotificationNo.FieldLenght = 20;
            this.CaseTime.Name = "CaseTime";
            this.MLFB.Name = "MLFB";
            this.MLFB.FieldLenght = 100;
            this.SerialNo.Name = "SerialNo";
            this.SerialNo.FieldLenght = 50;
            this.ServiceType.Name = "ServiceType";
            this.ServiceType.FieldLenght = 20;
            this.ProductName.Name = "ProductName";
            this.ProductName.FieldLenght = 100;
            this.ProductDesc.Name = "ProductDesc";
            this.ProductDesc.FieldLenght = 50;
            this.Area.Name = "Area";
            this.Area.FieldLenght = 20;
            this.ServiceProvider.Name = "ServiceProvider";
            this.ServiceProvider.FieldLenght = 50;
            this.CaseProperty.Name = "CaseProperty";
            this.CaseProperty.FieldLenght = 100;
            this.Sirot.Name = "Sirot";
            this.Sirot.FieldLenght = 50;
            this.TroubleDesc.Name = "TroubleDesc";
            this.TroubleDesc.FieldLenght = 2000;
            this.AppCompanyName.Name = "AppCompanyName";
            this.AppCompanyName.FieldLenght = 255;
            this.AppSubOffice.Name = "AppSubOffice";
            this.AppSubOffice.FieldLenght = 50;
            this.AppCustomerID.Name = "AppCustomerID";
            this.AppCustomerID.FieldLenght = 50;
            this.AppProvince.Name = "AppProvince";
            this.AppProvince.FieldLenght = 50;
            this.AppCity.Name = "AppCity";
            this.AppCity.FieldLenght = 50;
            this.AppCustomerType.Name = "AppCustomerType";
            this.AppCustomerType.FieldLenght = 50;
            this.AppContactName.Name = "AppContactName";
            this.AppContactName.FieldLenght = 50;
            this.AppTel.Name = "AppTel";
            this.AppTel.FieldLenght = 50;
            this.AppMobile.Name = "AppMobile";
            this.AppMobile.FieldLenght = 50;
            this.AppFax.Name = "AppFax";
            this.AppFax.FieldLenght = 50;
            this.AppAddress.Name = "AppAddress";
            this.AppAddress.FieldLenght = 255;
            this.AppPostCode.Name = "AppPostCode";
            this.AppPostCode.FieldLenght = 20;
            this.AppEmail.Name = "AppEmail";
            this.AppEmail.FieldLenght = 255;
            this.AppCountry.Name = "AppCountry";
            this.AppCountry.FieldLenght = 50;
            this.AppBranch.Name = "AppBranch";
            this.AppBranch.FieldLenght = 50;
            this.EnduserCompanyName.Name = "EnduserCompanyName";
            this.EnduserCompanyName.FieldLenght = 255;
            this.EnduserSubOffice.Name = "EnduserSubOffice";
            this.EnduserSubOffice.FieldLenght = 50;
            this.EnduserCustomerID.Name = "EnduserCustomerID";
            this.EnduserCustomerID.FieldLenght = 50;
            this.EnduserProvince.Name = "EnduserProvince";
            this.EnduserProvince.FieldLenght = 50;
            this.EnduserCity.Name = "EnduserCity";
            this.EnduserCity.FieldLenght = 50;
            this.EnduserCustomerType.Name = "EnduserCustomerType";
            this.EnduserCustomerType.FieldLenght = 50;
            this.EnduserContactName.Name = "EnduserContactName";
            this.EnduserContactName.FieldLenght = 50;
            this.EnduserTel.Name = "EnduserTel";
            this.EnduserTel.FieldLenght = 50;
            this.EnduserMobile.Name = "EnduserMobile";
            this.EnduserMobile.FieldLenght = 50;
            this.EnduserFax.Name = "EnduserFax";
            this.EnduserFax.FieldLenght = 50;
            this.EnduserAddress.Name = "EnduserAddress";
            this.EnduserAddress.FieldLenght = 255;
            this.EnduserPostCode.Name = "EnduserPostCode";
            this.EnduserPostCode.FieldLenght = 20;
            this.EnduserCountry.Name = "EnduserCountry";
            this.EnduserCountry.FieldLenght = 50;
            this.EnduserBranch.Name = "EnduserBranch";
            this.EnduserBranch.FieldLenght = 50;
            this.EnduserEmail.Name = "EnduserEmail";
            this.EnduserEmail.FieldLenght = 255;
            this.EnduserMainOffice.Name = "EnduserMainOffice";
            this.EnduserMainOffice.FieldLenght = 50;
            this.Text.Name = "Text";
            this.Text.FieldLenght = 2000;
            this.callagentComments.Name = "callagentComments";
            this.callagentComments.FieldLenght = 2000;
            this.TransferUser.Name = "TransferUser";
            this.TransferUser.FieldLenght = 100;
            this.isRepair.Name = "isRepair";
            this.CreateUser.Name = "CreateUser";
            this.CreateUser.FieldLenght = 100;
            this.SODate.Name = "SODate";
            this.WBSNO.Name = "WBSNO";
            this.WBSNO.FieldLenght = 50;
            this.SpecialOrderRemark.Name = "SpecialOrderRemark";
            this.SpecialOrderRemark.FieldLenght = 50;
            this.s39No.Name = "s39No";
            this.s39No.FieldLenght = 50;
            this.s39UpdateNo.Name = "s39UpdateNo";
            this.s39UpdateNo.FieldLenght = 50;
            this.MachineManufacturer.Name = "MachineManufacturer";
            this.MachineManufacturer.FieldLenght = 50;
            this.ControllerType.Name = "ControllerType";
            this.ControllerType.FieldLenght = 50;
            this.MachineSerialNo.Name = "MachineSerialNo";
            this.MachineSerialNo.FieldLenght = 50;
            this.TypeOfMachine.Name = "TypeOfMachine";
            this.TypeOfMachine.FieldLenght = 50;
            this.DriverType.Name = "DriverType";
            this.DriverType.FieldLenght = 50;
            this.SoftwareVersion.Name = "SoftwareVersion";
            this.SoftwareVersion.FieldLenght = 50;
            this.RSVNO.Name = "RSVNO";
            this.RSVNO.FieldLenght = 50;
            this.OrderType.Name = "OrderType";
            this.OrderType.FieldLenght = 50;
            this.Status.Name = "Status";
            this.Status.FieldLenght = 50;
            this.isUrgent.Name = "isUrgent";
            this.isSubmit.Name = "isSubmit";
            this.AppVIPID.Name = "AppVIPID";
            this.AppVIPID.FieldLenght = 50;
            this.EnduserVIPID.Name = "EnduserVIPID";
            this.EnduserVIPID.FieldLenght = 50;
            this.ModifyUser.Name = "ModifyUser";
            this.ModifyUser.FieldLenght = 100;
            this.IsFromSFAE.Name = "IsFromSFAE";
            this.MaterialFault.Name = "MaterialFault";
            this.MaterialFault.FieldLenght = 1000;
            this.MaterialProductName.Name = "MaterialProductName";
            this.MaterialProductName.FieldLenght = 50;
            this.MaterialProductDesc.Name = "MaterialProductDesc";
            this.MaterialProductDesc.FieldLenght = 50;
            this.Source.Name = "Source";
            this.Source.FieldLenght = 50;
            this.Distributors.Name = "Distributors";
            this.Distributors.FieldLenght = 100;
            this.Quantity.Name = "Quantity";
            this.NewMLFB.Name = "NewMLFB";
            this.NewMLFB.FieldLenght = 200;
            this.NewSerialNo.Name = "NewSerialNo";
            this.NewSerialNo.FieldLenght = 50;
            this.SFAEIHR_Warranty.Name = "SFAEIHR_Warranty";
            this.SFAEIHR_Warranty.FieldLenght = 50;
            this.SFAEIHR_ServiceOrder.Name = "SFAEIHR_ServiceOrder";
            this.SFAEIHR_ServiceOrder.FieldLenght = 50;
            this.CreateDate.Name = "CreateDate";
            this.Warranty.Name = "Warranty";
            this.Warranty.FieldLenght = 50;
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
        private Column<System.String> _NotificationNo = new Column<System.String>();
        public Column<System.String> NotificationNo
        {
            get
            {
                return _NotificationNo;
            }
            set
            {
                _NotificationNo = value;
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
        private Column<System.String> _Area = new Column<System.String>();
        public Column<System.String> Area
        {
            get
            {
                return _Area;
            }
            set
            {
                _Area = value;
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
        private Column<System.String> _CaseProperty = new Column<System.String>();
        public Column<System.String> CaseProperty
        {
            get
            {
                return _CaseProperty;
            }
            set
            {
                _CaseProperty = value;
            }
        }
        private Column<System.String> _Sirot = new Column<System.String>();
        public Column<System.String> Sirot
        {
            get
            {
                return _Sirot;
            }
            set
            {
                _Sirot = value;
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
        private Column<System.String> _AppSubOffice = new Column<System.String>();
        public Column<System.String> AppSubOffice
        {
            get
            {
                return _AppSubOffice;
            }
            set
            {
                _AppSubOffice = value;
            }
        }
        private Column<System.String> _AppCustomerID = new Column<System.String>();
        public Column<System.String> AppCustomerID
        {
            get
            {
                return _AppCustomerID;
            }
            set
            {
                _AppCustomerID = value;
            }
        }
        private Column<System.String> _AppProvince = new Column<System.String>();
        public Column<System.String> AppProvince
        {
            get
            {
                return _AppProvince;
            }
            set
            {
                _AppProvince = value;
            }
        }
        private Column<System.String> _AppCity = new Column<System.String>();
        public Column<System.String> AppCity
        {
            get
            {
                return _AppCity;
            }
            set
            {
                _AppCity = value;
            }
        }
        private Column<System.String> _AppCustomerType = new Column<System.String>();
        public Column<System.String> AppCustomerType
        {
            get
            {
                return _AppCustomerType;
            }
            set
            {
                _AppCustomerType = value;
            }
        }
        private Column<System.String> _AppContactName = new Column<System.String>();
        public Column<System.String> AppContactName
        {
            get
            {
                return _AppContactName;
            }
            set
            {
                _AppContactName = value;
            }
        }
        private Column<System.String> _AppTel = new Column<System.String>();
        public Column<System.String> AppTel
        {
            get
            {
                return _AppTel;
            }
            set
            {
                _AppTel = value;
            }
        }
        private Column<System.String> _AppMobile = new Column<System.String>();
        public Column<System.String> AppMobile
        {
            get
            {
                return _AppMobile;
            }
            set
            {
                _AppMobile = value;
            }
        }
        private Column<System.String> _AppFax = new Column<System.String>();
        public Column<System.String> AppFax
        {
            get
            {
                return _AppFax;
            }
            set
            {
                _AppFax = value;
            }
        }
        private Column<System.String> _AppAddress = new Column<System.String>();
        public Column<System.String> AppAddress
        {
            get
            {
                return _AppAddress;
            }
            set
            {
                _AppAddress = value;
            }
        }
        private Column<System.String> _AppPostCode = new Column<System.String>();
        public Column<System.String> AppPostCode
        {
            get
            {
                return _AppPostCode;
            }
            set
            {
                _AppPostCode = value;
            }
        }
        private Column<System.String> _AppEmail = new Column<System.String>();
        public Column<System.String> AppEmail
        {
            get
            {
                return _AppEmail;
            }
            set
            {
                _AppEmail = value;
            }
        }
        private Column<System.String> _AppCountry = new Column<System.String>();
        public Column<System.String> AppCountry
        {
            get
            {
                return _AppCountry;
            }
            set
            {
                _AppCountry = value;
            }
        }
        private Column<System.String> _AppBranch = new Column<System.String>();
        public Column<System.String> AppBranch
        {
            get
            {
                return _AppBranch;
            }
            set
            {
                _AppBranch = value;
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
        private Column<System.String> _EnduserSubOffice = new Column<System.String>();
        public Column<System.String> EnduserSubOffice
        {
            get
            {
                return _EnduserSubOffice;
            }
            set
            {
                _EnduserSubOffice = value;
            }
        }
        private Column<System.String> _EnduserCustomerID = new Column<System.String>();
        public Column<System.String> EnduserCustomerID
        {
            get
            {
                return _EnduserCustomerID;
            }
            set
            {
                _EnduserCustomerID = value;
            }
        }
        private Column<System.String> _EnduserProvince = new Column<System.String>();
        public Column<System.String> EnduserProvince
        {
            get
            {
                return _EnduserProvince;
            }
            set
            {
                _EnduserProvince = value;
            }
        }
        private Column<System.String> _EnduserCity = new Column<System.String>();
        public Column<System.String> EnduserCity
        {
            get
            {
                return _EnduserCity;
            }
            set
            {
                _EnduserCity = value;
            }
        }
        private Column<System.String> _EnduserCustomerType = new Column<System.String>();
        public Column<System.String> EnduserCustomerType
        {
            get
            {
                return _EnduserCustomerType;
            }
            set
            {
                _EnduserCustomerType = value;
            }
        }
        private Column<System.String> _EnduserContactName = new Column<System.String>();
        public Column<System.String> EnduserContactName
        {
            get
            {
                return _EnduserContactName;
            }
            set
            {
                _EnduserContactName = value;
            }
        }
        private Column<System.String> _EnduserTel = new Column<System.String>();
        public Column<System.String> EnduserTel
        {
            get
            {
                return _EnduserTel;
            }
            set
            {
                _EnduserTel = value;
            }
        }
        private Column<System.String> _EnduserMobile = new Column<System.String>();
        public Column<System.String> EnduserMobile
        {
            get
            {
                return _EnduserMobile;
            }
            set
            {
                _EnduserMobile = value;
            }
        }
        private Column<System.String> _EnduserFax = new Column<System.String>();
        public Column<System.String> EnduserFax
        {
            get
            {
                return _EnduserFax;
            }
            set
            {
                _EnduserFax = value;
            }
        }
        private Column<System.String> _EnduserAddress = new Column<System.String>();
        public Column<System.String> EnduserAddress
        {
            get
            {
                return _EnduserAddress;
            }
            set
            {
                _EnduserAddress = value;
            }
        }
        private Column<System.String> _EnduserPostCode = new Column<System.String>();
        public Column<System.String> EnduserPostCode
        {
            get
            {
                return _EnduserPostCode;
            }
            set
            {
                _EnduserPostCode = value;
            }
        }
        private Column<System.String> _EnduserCountry = new Column<System.String>();
        public Column<System.String> EnduserCountry
        {
            get
            {
                return _EnduserCountry;
            }
            set
            {
                _EnduserCountry = value;
            }
        }
        private Column<System.String> _EnduserBranch = new Column<System.String>();
        public Column<System.String> EnduserBranch
        {
            get
            {
                return _EnduserBranch;
            }
            set
            {
                _EnduserBranch = value;
            }
        }
        private Column<System.String> _EnduserEmail = new Column<System.String>();
        public Column<System.String> EnduserEmail
        {
            get
            {
                return _EnduserEmail;
            }
            set
            {
                _EnduserEmail = value;
            }
        }
        private Column<System.String> _EnduserMainOffice = new Column<System.String>();
        public Column<System.String> EnduserMainOffice
        {
            get
            {
                return _EnduserMainOffice;
            }
            set
            {
                _EnduserMainOffice = value;
            }
        }
        private Column<System.String> _Text = new Column<System.String>();
        public Column<System.String> Text
        {
            get
            {
                return _Text;
            }
            set
            {
                _Text = value;
            }
        }
        private Column<System.String> _callagentComments = new Column<System.String>();
        public Column<System.String> callagentComments
        {
            get
            {
                return _callagentComments;
            }
            set
            {
                _callagentComments = value;
            }
        }
        private Column<System.String> _TransferUser = new Column<System.String>();
        public Column<System.String> TransferUser
        {
            get
            {
                return _TransferUser;
            }
            set
            {
                _TransferUser = value;
            }
        }
        private Column<System.Boolean?> _isRepair = new Column<System.Boolean?>();
        public Column<System.Boolean?> isRepair
        {
            get
            {
                return _isRepair;
            }
            set
            {
                _isRepair = value;
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
        private Column<System.DateTime?> _SODate = new Column<System.DateTime?>();
        public Column<System.DateTime?> SODate
        {
            get
            {
                return _SODate;
            }
            set
            {
                _SODate = value;
            }
        }
        private Column<System.String> _WBSNO = new Column<System.String>();
        public Column<System.String> WBSNO
        {
            get
            {
                return _WBSNO;
            }
            set
            {
                _WBSNO = value;
            }
        }
        private Column<System.String> _SpecialOrderRemark = new Column<System.String>();
        public Column<System.String> SpecialOrderRemark
        {
            get
            {
                return _SpecialOrderRemark;
            }
            set
            {
                _SpecialOrderRemark = value;
            }
        }
        private Column<System.String> _s39No = new Column<System.String>();
        public Column<System.String> s39No
        {
            get
            {
                return _s39No;
            }
            set
            {
                _s39No = value;
            }
        }
        private Column<System.String> _s39UpdateNo = new Column<System.String>();
        public Column<System.String> s39UpdateNo
        {
            get
            {
                return _s39UpdateNo;
            }
            set
            {
                _s39UpdateNo = value;
            }
        }
        private Column<System.String> _MachineManufacturer = new Column<System.String>();
        public Column<System.String> MachineManufacturer
        {
            get
            {
                return _MachineManufacturer;
            }
            set
            {
                _MachineManufacturer = value;
            }
        }
        private Column<System.String> _ControllerType = new Column<System.String>();
        public Column<System.String> ControllerType
        {
            get
            {
                return _ControllerType;
            }
            set
            {
                _ControllerType = value;
            }
        }
        private Column<System.String> _MachineSerialNo = new Column<System.String>();
        public Column<System.String> MachineSerialNo
        {
            get
            {
                return _MachineSerialNo;
            }
            set
            {
                _MachineSerialNo = value;
            }
        }
        private Column<System.String> _TypeOfMachine = new Column<System.String>();
        public Column<System.String> TypeOfMachine
        {
            get
            {
                return _TypeOfMachine;
            }
            set
            {
                _TypeOfMachine = value;
            }
        }
        private Column<System.String> _DriverType = new Column<System.String>();
        public Column<System.String> DriverType
        {
            get
            {
                return _DriverType;
            }
            set
            {
                _DriverType = value;
            }
        }
        private Column<System.String> _SoftwareVersion = new Column<System.String>();
        public Column<System.String> SoftwareVersion
        {
            get
            {
                return _SoftwareVersion;
            }
            set
            {
                _SoftwareVersion = value;
            }
        }
        private Column<System.String> _RSVNO = new Column<System.String>();
        public Column<System.String> RSVNO
        {
            get
            {
                return _RSVNO;
            }
            set
            {
                _RSVNO = value;
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
        private Column<System.Boolean?> _isUrgent = new Column<System.Boolean?>();
        public Column<System.Boolean?> isUrgent
        {
            get
            {
                return _isUrgent;
            }
            set
            {
                _isUrgent = value;
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
        private Column<System.String> _AppVIPID = new Column<System.String>();
        public Column<System.String> AppVIPID
        {
            get
            {
                return _AppVIPID;
            }
            set
            {
                _AppVIPID = value;
            }
        }
        private Column<System.String> _EnduserVIPID = new Column<System.String>();
        public Column<System.String> EnduserVIPID
        {
            get
            {
                return _EnduserVIPID;
            }
            set
            {
                _EnduserVIPID = value;
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
        private Column<System.Boolean?> _IsFromSFAE = new Column<System.Boolean?>();
        public Column<System.Boolean?> IsFromSFAE
        {
            get
            {
                return _IsFromSFAE;
            }
            set
            {
                _IsFromSFAE = value;
            }
        }
        private Column<System.String> _MaterialFault = new Column<System.String>();
        public Column<System.String> MaterialFault
        {
            get
            {
                return _MaterialFault;
            }
            set
            {
                _MaterialFault = value;
            }
        }
        private Column<System.String> _MaterialProductName = new Column<System.String>();
        public Column<System.String> MaterialProductName
        {
            get
            {
                return _MaterialProductName;
            }
            set
            {
                _MaterialProductName = value;
            }
        }
        private Column<System.String> _MaterialProductDesc = new Column<System.String>();
        public Column<System.String> MaterialProductDesc
        {
            get
            {
                return _MaterialProductDesc;
            }
            set
            {
                _MaterialProductDesc = value;
            }
        }
        private Column<System.String> _Source = new Column<System.String>();
        public Column<System.String> Source
        {
            get
            {
                return _Source;
            }
            set
            {
                _Source = value;
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
        private Column<System.Int32?> _Quantity = new Column<System.Int32?>();
        public Column<System.Int32?> Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                _Quantity = value;
            }
        }
        private Column<System.String> _NewMLFB = new Column<System.String>();
        public Column<System.String> NewMLFB
        {
            get
            {
                return _NewMLFB;
            }
            set
            {
                _NewMLFB = value;
            }
        }
        private Column<System.String> _NewSerialNo = new Column<System.String>();
        public Column<System.String> NewSerialNo
        {
            get
            {
                return _NewSerialNo;
            }
            set
            {
                _NewSerialNo = value;
            }
        }
        private Column<System.String> _SFAEIHR_Warranty = new Column<System.String>();
        public Column<System.String> SFAEIHR_Warranty
        {
            get
            {
                return _SFAEIHR_Warranty;
            }
            set
            {
                _SFAEIHR_Warranty = value;
            }
        }
        private Column<System.String> _SFAEIHR_ServiceOrder = new Column<System.String>();
        public Column<System.String> SFAEIHR_ServiceOrder
        {
            get
            {
                return _SFAEIHR_ServiceOrder;
            }
            set
            {
                _SFAEIHR_ServiceOrder = value;
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

    }
}
