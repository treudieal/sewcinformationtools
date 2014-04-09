using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Views.SEWC
{
    public class View_SEWC_Repair_MDetail : Columns
    {
        private static View_SEWC_Repair_MDetail instance;
        public static View_SEWC_Repair_MDetail GetInstance()
        {
            if (instance == null)
            {
                instance = new View_SEWC_Repair_MDetail();
            }
            return instance;
        }
        public View_SEWC_Repair_MDetail()
        {
            this.RequestID.Name = "RequestID";
            this.RequestID.FieldLenght = 15;
            this.WorkStationCode.Name = "WorkStationCode";
            this.WorkStationCode.FieldLenght = 50;
            this.MLFB.Name = "MLFB";
            this.MLFB.FieldLenght = 255;
            this.SerialNo.Name = "SerialNo";
            this.SerialNo.FieldLenght = 255;
            this.Qty.Name = "Qty";
            this.FuntinalStateOriginal.Name = "FuntinalStateOriginal";
            this.FuntinalStateOriginal.FieldLenght = 255;
            this.FuntinalStatelatest.Name = "FuntinalStatelatest";
            this.FuntinalStatelatest.FieldLenght = 255;
            this.FirmwareOriginal.Name = "FirmwareOriginal";
            this.FirmwareOriginal.FieldLenght = 255;
            this.Firmwarelatest.Name = "Firmwarelatest";
            this.Firmwarelatest.FieldLenght = 255;
            this.Warranty.Name = "Warranty";
            this.Warranty.FieldLenght = 50;
            this.ConfirmCompleteDate.Name = "ConfirmCompleteDate";
            this.EndRepairDate.Name = "EndRepairDate";
            this.Engineer.Name = "Engineer";
            this.Engineer.FieldLenght = 50;
            this.RepairResult.Name = "RepairResult";
            this.RepairResult.FieldLenght = 300;
            this.Remarks.Name = "Remarks";
            this.Remarks.FieldLenght = 300;
            this.ServiceType.Name = "ServiceType";
            this.ServiceType.FieldLenght = 20;
            this.RejectFile.Name = "RejectFile";
            this.RejectFile.FieldLenght = 4000;
            this.OrderType.Name = "OrderType";
            this.OrderType.FieldLenght = 50;
            this.SEWCNotificationNo.Name = "SEWCNotificationNo";
            this.SEWCNotificationNo.FieldLenght = 100;
            this.TroubleDesc.Name = "TroubleDesc";
            this.TroubleDesc.FieldLenght = 2000;
            this.ServiceProvider.Name = "ServiceProvider";
            this.ServiceProvider.FieldLenght = 50;
            this.isSubmit.Name = "isSubmit";
            this.ID.Name = "ID";
            this.FailureCasedType.Name = "FailureCasedType";
            this.FailureCasedType.FieldLenght = 100;
            this.LaborCost.Name = "LaborCost";
            this.ProductDesc.Name = "ProductDesc";
            this.ProductDesc.FieldLenght = 50;
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
        private Column<System.String> _RejectFile = new Column<System.String>();
        public Column<System.String> RejectFile
        {
            get
            {
                return _RejectFile;
            }
            set
            {
                _RejectFile = value;
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
        private Column<System.String> _FailureCasedType = new Column<System.String>();
        public Column<System.String> FailureCasedType
        {
            get
            {
                return _FailureCasedType;
            }
            set
            {
                _FailureCasedType = value;
            }
        }
        private Column<System.Decimal?> _LaborCost = new Column<System.Decimal?>();
        public Column<System.Decimal?> LaborCost
        {
            get
            {
                return _LaborCost;
            }
            set
            {
                _LaborCost = value;
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

    }
}
