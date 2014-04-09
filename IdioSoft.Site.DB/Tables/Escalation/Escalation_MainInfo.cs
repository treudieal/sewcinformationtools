using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Tables.Escalation
{
    [Serializable]
    public class Escalation_MainInfo : Columns
    {
        private Column<System.Guid?> _EscalationID = new Column<System.Guid?>();
        public Column<System.Guid?> EscalationID
        {
            get
            {
                return _EscalationID;
            }
            set
            {
                _EscalationID = value;
            }
        }
        private Column<System.String> _ERNo = new Column<System.String>();
        public Column<System.String> ERNo
        {
            get
            {
                return _ERNo;
            }
            set
            {
                _ERNo = value;
            }
        }
        private Column<System.String> _SRNo = new Column<System.String>();
        public Column<System.String> SRNo
        {
            get
            {
                return _SRNo;
            }
            set
            {
                _SRNo = value;
            }
        }
        private Column<System.String> _AppCompany = new Column<System.String>();
        public Column<System.String> AppCompany
        {
            get
            {
                return _AppCompany;
            }
            set
            {
                _AppCompany = value;
            }
        }
        private Column<System.String> _EndUser = new Column<System.String>();
        public Column<System.String> EndUser
        {
            get
            {
                return _EndUser;
            }
            set
            {
                _EndUser = value;
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
        private Column<System.String> _OC = new Column<System.String>();
        public Column<System.String> OC
        {
            get
            {
                return _OC;
            }
            set
            {
                _OC = value;
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
        private Column<System.String> _SN = new Column<System.String>();
        public Column<System.String> SN
        {
            get
            {
                return _SN;
            }
            set
            {
                _SN = value;
            }
        }
        private Column<System.String> _Abstract = new Column<System.String>();
        public Column<System.String> Abstract
        {
            get
            {
                return _Abstract;
            }
            set
            {
                _Abstract = value;
            }
        }
        private Column<System.String> _Remark = new Column<System.String>();
        public Column<System.String> Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                _Remark = value;
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
        private Column<System.String> _Priority = new Column<System.String>();
        public Column<System.String> Priority
        {
            get
            {
                return _Priority;
            }
            set
            {
                _Priority = value;
            }
        }
        private Column<System.String> _EscalationBy = new Column<System.String>();
        public Column<System.String> EscalationBy
        {
            get
            {
                return _EscalationBy;
            }
            set
            {
                _EscalationBy = value;
            }
        }
        private Column<System.String> _Owner = new Column<System.String>();
        public Column<System.String> Owner
        {
            get
            {
                return _Owner;
            }
            set
            {
                _Owner = value;
            }
        }
        private Column<System.Int32?> _CreatedUserID = new Column<System.Int32?>();
        public Column<System.Int32?> CreatedUserID
        {
            get
            {
                return _CreatedUserID;
            }
            set
            {
                _CreatedUserID = value;
            }
        }
        private Column<System.DateTime?> _CreatedDate = new Column<System.DateTime?>();
        public Column<System.DateTime?> CreatedDate
        {
            get
            {
                return _CreatedDate;
            }
            set
            {
                _CreatedDate = value;
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

    }
}
