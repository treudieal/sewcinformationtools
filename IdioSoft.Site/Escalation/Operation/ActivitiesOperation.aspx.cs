using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IdioSoft.Site.Escalation.Operation
{
    public partial class ActivitiesOperation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Breadcrumb1.CurrentModule = "Activities Operation";
            EscalationID = Request.QueryString["EscalationID"].ToString();
        }

        public string EscalationID
        {
            get
            {
                return ViewState["EscalationID"].ToString();
            }
            set
            {
                ViewState["EscalationID"] = value;
            }
        }
    }
}