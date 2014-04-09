using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Views.SEWC
{
    public class View_SEWC_All_Info : Columns
    {
        private static View_SEWC_All_Info instance;
        public static View_SEWC_All_Info GetInstance()
        {
            if (instance == null)
            {
                instance = new View_SEWC_All_Info();
            }
            return instance;
        }
        public View_SEWC_All_Info()
        {
            this.uRequestID.Name = "uRequestID";
            this.RequestID.Name = "RequestID";
            this.RequestID.FieldLenght = 15;
            this.MLFB.Name = "MLFB";
            this.MLFB.FieldLenght = 255;
            this.SerialNo.Name = "SerialNo";
            this.SerialNo.FieldLenght = 255;
            this.ProductGroup.Name = "ProductGroup";
            this.ProductGroup.FieldLenght = 50;
            this.ProductDesc.Name = "ProductDesc";
            this.ProductDesc.FieldLenght = 50;
            this.SEWCNotificationNo.Name = "SEWCNotificationNo";
            this.SEWCNotificationNo.FieldLenght = 100;
            this.ServiceType.Name = "ServiceType";
            this.ServiceType.FieldLenght = 20;
            this.Warranty.Name = "Warranty";
            this.Warranty.FieldLenght = 50;
            this.DeliveryCustomer.Name = "DeliveryCustomer";
            this.DeliveryCustomer.FieldLenght = 100;
            this.TrackingNo.Name = "TrackingNo";
            this.TrackingNo.FieldLenght = 100;
            this.CaseTime.Name = "CaseTime";
            this.ProductName.Name = "ProductName";
            this.ProductName.FieldLenght = 100;
            this.EndRepairDate.Name = "EndRepairDate";
            this.DeliveryDate.Name = "DeliveryDate";
            this.AppCompanyName.Name = "AppCompanyName";
            this.AppCompanyName.FieldLenght = 255;
            this.EnduserCompanyName.Name = "EnduserCompanyName";
            this.EnduserCompanyName.FieldLenght = 255;
            this.ReceiveDefectiveDateT3.Name = "ReceiveDefectiveDateT3";
            this.ReturnNo.Name = "ReturnNo";
            this.ReturnNo.FieldLenght = 50;
            this.CreateDate.Name = "CreateDate";
            this.NewMLFB.Name = "NewMLFB";
            this.NewMLFB.FieldLenght = 100;
            this.NewSerialNo.Name = "NewSerialNo";
            this.NewSerialNo.FieldLenght = 100;
            this.WeightUnit.Name = "WeightUnit";
            this.WeightUnit.FieldLenght = 100;
            this.issueDNDate.Name = "issueDNDate";
            this.WorkStationCode.Name = "WorkStationCode";
            this.WorkStationCode.FieldLenght = 50;
            this.FuntinalStateoriginal.Name = "FuntinalStateoriginal";
            this.FuntinalStateoriginal.FieldLenght = 255;
            this.FuntinalStatelatest.Name = "FuntinalStatelatest";
            this.FuntinalStatelatest.FieldLenght = 255;
            this.Firmwareoriginal.Name = "Firmwareoriginal";
            this.Firmwareoriginal.FieldLenght = 255;
            this.Firmwarelatest.Name = "Firmwarelatest";
            this.Firmwarelatest.FieldLenght = 255;
            this.ConfirmCompleteDate.Name = "ConfirmCompleteDate";
            this.Engineer.Name = "Engineer";
            this.Engineer.FieldLenght = 50;
            this.RepairResult.Name = "RepairResult";
            this.RepairResult.FieldLenght = 300;
            this.ReceiveCompany.Name = "ReceiveCompany";
            this.ReceiveCompany.FieldLenght = 100;
            this.Receiver.Name = "Receiver";
            this.Receiver.FieldLenght = 50;
            this.ReceiverTel.Name = "ReceiverTel";
            this.ReceiverTel.FieldLenght = 50;
            this.ReceiverAddress.Name = "ReceiverAddress";
            this.ReceiverAddress.FieldLenght = 200;
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
        private Column<System.String> _TrackingNo = new Column<System.String>();
        public Column<System.String> TrackingNo
        {
            get
            {
                return _TrackingNo;
            }
            set
            {
                _TrackingNo = value;
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
        private Column<System.DateTime?> _DeliveryDate = new Column<System.DateTime?>();
        public Column<System.DateTime?> DeliveryDate
        {
            get
            {
                return _DeliveryDate;
            }
            set
            {
                _DeliveryDate = value;
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
        private Column<System.String> _ReturnNo = new Column<System.String>();
        public Column<System.String> ReturnNo
        {
            get
            {
                return _ReturnNo;
            }
            set
            {
                _ReturnNo = value;
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
        private Column<System.String> _WeightUnit = new Column<System.String>();
        public Column<System.String> WeightUnit
        {
            get
            {
                return _WeightUnit;
            }
            set
            {
                _WeightUnit = value;
            }
        }
        private Column<System.DateTime?> _issueDNDate = new Column<System.DateTime?>();
        public Column<System.DateTime?> issueDNDate
        {
            get
            {
                return _issueDNDate;
            }
            set
            {
                _issueDNDate = value;
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
        private Column<System.String> _FuntinalStateoriginal = new Column<System.String>();
        public Column<System.String> FuntinalStateoriginal
        {
            get
            {
                return _FuntinalStateoriginal;
            }
            set
            {
                _FuntinalStateoriginal = value;
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
        private Column<System.String> _Firmwareoriginal = new Column<System.String>();
        public Column<System.String> Firmwareoriginal
        {
            get
            {
                return _Firmwareoriginal;
            }
            set
            {
                _Firmwareoriginal = value;
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
        private Column<System.String> _ReceiveCompany = new Column<System.String>();
        public Column<System.String> ReceiveCompany
        {
            get
            {
                return _ReceiveCompany;
            }
            set
            {
                _ReceiveCompany = value;
            }
        }
        private Column<System.String> _Receiver = new Column<System.String>();
        public Column<System.String> Receiver
        {
            get
            {
                return _Receiver;
            }
            set
            {
                _Receiver = value;
            }
        }
        private Column<System.String> _ReceiverTel = new Column<System.String>();
        public Column<System.String> ReceiverTel
        {
            get
            {
                return _ReceiverTel;
            }
            set
            {
                _ReceiverTel = value;
            }
        }
        private Column<System.String> _ReceiverAddress = new Column<System.String>();
        public Column<System.String> ReceiverAddress
        {
            get
            {
                return _ReceiverAddress;
            }
            set
            {
                _ReceiverAddress = value;
            }
        }

    }
}
