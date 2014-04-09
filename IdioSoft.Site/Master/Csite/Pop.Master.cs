using IdioSoft.Site.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IdioSoft.Site.Master.Csite
{
    public partial class Pop : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserInfo"] == null)
                {
                    return;
                }
                IdioSoft.Business.Frames.CLimites cl = new IdioSoft.Business.Frames.CLimites(this.form1, ((UserInfo)Session["UserInfo"]).SEWCLimiteds);
                cl.DoLimits();
            }
        }
    }
}