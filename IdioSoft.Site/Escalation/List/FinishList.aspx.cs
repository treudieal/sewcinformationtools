using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IdioSoft.Site.Escalation.List
{
    public partial class FinishList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Breadcrumb1.CurrentModule = "Finish List";
            TabNav1.DoTabItemSelected(ClassLibrary.Escalation.Util.ModuleName.FinishList);
        }
    }
}