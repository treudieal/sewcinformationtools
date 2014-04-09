using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdioSoft.Site.ClassLibrary;

using System.Data;
using System.Text;

namespace IdioSoft.Site.SEWC.Request
{
    public partial class RequestSendFax : IPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string uRequestID = PuRequestIDs;
                subAppInformation(uRequestID);
            }
        }

        #region "在Material表里获得基本信息"
        private void subAppInformation(string uRequestID)
        {
            string strSQL = "";

            if (uRequestID != "")
            {
                strSQL = "select AppFax,AppContactName,AppCompanyName,AppTel from webInfo_ServiceRequest_Info where ID = '" + uRequestID + "'";

                DataSet ds = new DataSet();
                try
                {
                    ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
                    this.txtFaxNumber.Value = ds.Tables[0].Rows[0][0].ToString();
                    this.txtReceiver.Value = ds.Tables[0].Rows[0][1].ToString();
                    this.txtReceiverCompany.Value = ds.Tables[0].Rows[0][2].ToString();
                    this.txtReceiverTel.Value = ds.Tables[0].Rows[0][3].ToString();
                }
                catch
                { }
            }
        }
        #endregion

        public string PuRequestIDs
        {
            get
            {
                string sID = Request["uRequestID"].ToString();
                return sID;
            }
        }

        public string strTmpFileName
        {
            get
            {
                string TempText = Request["TempText"].ToString();
                return TempText;
            }
        }

        public string strTmpFileNameValue
        {
            get
            {
                string TempValue = HttpContext.Current.Server.UrlEncode(Request["TempValue"].ToString());
                return TempValue;
            }
        }
    }
}