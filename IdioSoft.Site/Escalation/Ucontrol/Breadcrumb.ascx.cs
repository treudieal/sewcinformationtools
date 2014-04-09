using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IdioSoft.Site.Escalation.Ucontrol
{
    public partial class Breadcrumb : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string CurrentModule
        {
            set
            {
                lnkModule.InnerText = value;
            }
        }
    }
}