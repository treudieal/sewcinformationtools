using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using IdioSoft.Site.ClassLibrary;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.SEWC.Delivery
{
    public partial class T6Operation :IPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sID = "";
            sID = Request.funString_RequestFormValue("sID");
            if (sID == "")
            {
                Response.Write("<script type='javascript'>window.close();</script>");
                return;
            }
            string[] lst = sID.Split(',');
            if (lst.Length > 0)
            {
                string strSQL = "select DeliveryDate from SEWC_Delivery_Info where uRequestID='" + lst[0] + "'";
                dtpDeliveryDate.Value = objDbSQLAccess.funString_SQLExecuteScalar(strSQL);
            }
        }

        public string PuRequestIDs
        {
            get
            {
                string sID = Request["sID"].ToString();
                return sID;
            }
        }
    }
}