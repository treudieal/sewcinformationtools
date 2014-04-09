using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdioSoft.Site.ClassLibrary;

using System.Data;
using System.Text;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.SEWC.Request
{
    public partial class RequestSenderMsg : IPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string uRequestID = PuRequestIDs;
            if (uRequestID != "")
            {
                subDB_LoadDetail(uRequestID);
            }
            cboMsgTemplate.subComboBox_LoadItems("select Content,MsgTitle from webInfo_Basic_Message_Info where ModID = 1", 0, new ListItem("", ""));
        }

        #region "载入信息"
        private void subDB_LoadDetail(string uRequestID)
        {
            string strSQL = "select RequestID,NotificationNo,ProductName,AppMobile,EnduserMobile from webInfo_ServiceRequest_Info where ID = '" + uRequestID + "'";
            DataSet ds = new DataSet();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            if (ds != null)
            {
                string strProductName = "";
                strProductName = ds.Tables[0].Rows[0]["ProductName"].ToString();
                if (strProductName.Trim().ToLower() == "lv" || strProductName.Trim().ToLower() == "lv 3vt")
                {
                    //ptype = "requestid";
                    this.txtNotificationNo.Text = ds.Tables[0].Rows[0]["RequestID"].ToString();
                }
                else
                {
                    //ptype = "notificationno";
                    string requestid = ds.Tables[0].Rows[0]["NotificationNo"].ToString();
                    if (requestid == "")
                    {
                        requestid = ds.Tables[0].Rows[0]["RequestID"].ToString();
                    }
                    this.txtNotificationNo.Text = requestid.ToString();
                }
                this.txtAppMobile.Text = ds.Tables[0].Rows[0]["AppMobile"].ToString();
                this.txtEnduserMobile.Text = ds.Tables[0].Rows[0]["EnduserMobile"].ToString();
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
    }
}