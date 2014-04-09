using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Tables.Escalation
{
    [Serializable]
    public class Escalation_Activity_AttachmentInfo : Columns
    {
        private Column<System.Guid?> _ActivityFileID = new Column<System.Guid?>();
        public Column<System.Guid?> ActivityFileID
        {
            get
            {
                return _ActivityFileID;
            }
            set
            {
                _ActivityFileID = value;
            }
        }
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
        private Column<System.String> _DocumentName = new Column<System.String>();
        public Column<System.String> DocumentName
        {
            get
            {
                return _DocumentName;
            }
            set
            {
                _DocumentName = value;
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

    }
}
