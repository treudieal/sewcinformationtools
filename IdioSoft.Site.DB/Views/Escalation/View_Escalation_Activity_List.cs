using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Views.Escalation
{
    public class View_Escalation_Activity_List : Columns
    {
        private Column<System.Guid?> _ActivityID = new Column<System.Guid?>();
        public Column<System.Guid?> ActivityID
        {
            get
            {
                return _ActivityID;
            }
            set
            {
                _ActivityID = value;
            }
        }
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
        private Column<System.String> _CurrentStatus = new Column<System.String>();
        public Column<System.String> CurrentStatus
        {
            get
            {
                return _CurrentStatus;
            }
            set
            {
                _CurrentStatus = value;
            }
        }
        private Column<System.String> _NextStep = new Column<System.String>();
        public Column<System.String> NextStep
        {
            get
            {
                return _NextStep;
            }
            set
            {
                _NextStep = value;
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

    }
}
