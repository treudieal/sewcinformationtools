using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace IdioSoft.Site.ClassLibrary.Control
{
    public class ClassSendFaxListTable:IdioSoft.Business.Class.XmlSerializationHelper
    {
        public SendFaxListRow SendFaxListRow;
    }

    public class SendFaxListRow
    {
        public string Subject;
        public string Message;
        public string SendFaxDateTime;
        public string ScheduledDateTime;
        public int Priority;
        public SubSendFaxListTable SubSendFaxListTable;
        public FaxFileTable FaxFileTable;
    }

    public class SubSendFaxListTable
    {
        public SubSendFaxListRow SubSendFaxListRow;

    }

    public class SubSendFaxListRow
    {
        public string Receiver;
        public string FaxNumber;
        public string FaxType;
        public string ReceiverCompany;
    }
    public class FaxFileTable
    {
        public FaxFileRow FaxFileRow;


    }
    public class FaxFileRow
    {
        public string FaxFileName;
        public string FaxFile;
        public string FaxFileType;
        public string FaxFileSize;

    }
}