using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IdioSoft.Site.Escalation.Ucontrol
{
    public partial class TabNav : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void DoTabItemSelected(ClassLibrary.Escalation.Util.ModuleName eModuleName)
        {
            liOpenList.Attributes.Remove("class");
            liInProcess.Attributes.Remove("class");
            liPendingList.Attributes.Remove("class");
            liFinishList.Attributes.Remove("class");
            liAllList.Attributes.Remove("class");
            switch (eModuleName)
            {
                case IdioSoft.Site.ClassLibrary.Escalation.Util.ModuleName.OpenList:
                    liOpenList.Attributes.Add("class", "active");
                    break;
                case IdioSoft.Site.ClassLibrary.Escalation.Util.ModuleName.InProcessList:
                    liInProcess.Attributes.Add("class", "active");
                    break;
                case IdioSoft.Site.ClassLibrary.Escalation.Util.ModuleName.PendingList:
                    liPendingList.Attributes.Add("class", "active");
                    break;
                case IdioSoft.Site.ClassLibrary.Escalation.Util.ModuleName.FinishList:
                    liFinishList.Attributes.Add("class", "active");
                    break;
                case IdioSoft.Site.ClassLibrary.Escalation.Util.ModuleName.AllList:
                    liAllList.Attributes.Add("class", "active");
                    break;
                default:
                    liOpenList.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}