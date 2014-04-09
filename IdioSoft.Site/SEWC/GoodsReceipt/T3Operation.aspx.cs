using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using IdioSoft.Site.ClassLibrary;
using IdioSoft.Site.DB.Tables;
using IdioSoft.Business.Frames;
using IdioSoft.Site.DB.Tables.SEWC;
using IdioSoft.Business.Method;
namespace IdioSoft.Site.SEWC.GoodsReceipt
{
    public partial class T3Operation : IPage
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
                SEWC_GoodsReceipt_Info objTableInfo = new SEWC_GoodsReceipt_Info();
                ITable objTable = new CTable(objTableInfo);
                objTable.getData("uRequestID='" + lst[0] + "'");

                dtpReceiveDefectiveDate.Value = objTableInfo.ReceiveDefectiveDateT3.FieldValue.funString_StringToDatetime();
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