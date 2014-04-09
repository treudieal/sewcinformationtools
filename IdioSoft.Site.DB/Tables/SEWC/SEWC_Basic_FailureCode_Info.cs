using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Tables.SEWC
{
    public class SEWC_Basic_FailureCode_Info : Columns
    {
        private static SEWC_Basic_FailureCode_Info instance;
        public static SEWC_Basic_FailureCode_Info GetInstance()
        {
            if (instance == null)
            {
                instance = new SEWC_Basic_FailureCode_Info();
            }
            return instance;
        }
        public SEWC_Basic_FailureCode_Info()
        {
            this.ID.Name = "ID";
            this.FCode.Name = "FCode";
            this.FCode.FieldLenght = 50;
            this.Type.Name = "Type";
            this.Type.FieldLenght = 100;
            this.FailureKind.Name = "FailureKind";
            this.FailureKind.FieldLenght = 100;
            this.DefectType.Name = "DefectType";
            this.DefectType.FieldLenght = 100;
            this.IsDel.Name = "IsDel";
            this.ProductDesc.Name = "ProductDesc";
            this.ProductDesc.FieldLenght = 50;
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
        private Column<System.String> _FCode = new Column<System.String>();
        public Column<System.String> FCode
        {
            get
            {
                return _FCode;
            }
            set
            {
                _FCode = value;
            }
        }
        private Column<System.String> _Type = new Column<System.String>();
        public Column<System.String> Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
            }
        }
        private Column<System.String> _FailureKind = new Column<System.String>();
        public Column<System.String> FailureKind
        {
            get
            {
                return _FailureKind;
            }
            set
            {
                _FailureKind = value;
            }
        }
        private Column<System.String> _DefectType = new Column<System.String>();
        public Column<System.String> DefectType
        {
            get
            {
                return _DefectType;
            }
            set
            {
                _DefectType = value;
            }
        }
        private Column<System.Int32?> _IsDel = new Column<System.Int32?>();
        public Column<System.Int32?> IsDel
        {
            get
            {
                return _IsDel;
            }
            set
            {
                _IsDel = value;
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
