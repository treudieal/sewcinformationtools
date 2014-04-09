using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IdioSoft.Site.SEWC.Request
{
    public partial class RequestSendMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string PuRequestIDs
        {
            get
            {
                string sID = Request["uRequestID"].ToString();
                return sID;
            }
        }
    }
}