using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdioSoft.Site.ClassLibrary;

using System.Data;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.User
{
    public partial class Detail : IPage
    {
        string KeyID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                KeyID = Request["KeyID"].ToString();
                subDetail_DBLoad();
            }
            catch (System.Exception ex)
            {

            }
        }

        private void subDetail_DBLoad()
        {
            string strSQL = "";
            strSQL = @"SELECT   ID, LoginName, Password, Username,Mobile,Tel, Email, Duty, SiteCode, PageSize, IsDisabled FROM CT_LoginInfo where ID='" + KeyID + "'";
            DataSet ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                string Password =  ds.Tables[0].Rows[0]["Password"].ToString();

                tdPersonNo.InnerText = ds.Tables[0].Rows[0]["LoginName"].ToString();
                tdPassword.InnerText = Password;
                tdUserName.InnerText = ds.Tables[0].Rows[0]["Username"].ToString();
                tdMobile.InnerText = ds.Tables[0].Rows[0]["Mobile"].ToString();
                tdTel.InnerText = ds.Tables[0].Rows[0]["Tel"].ToString();
                tdEmail.InnerText = ds.Tables[0].Rows[0]["Email"].ToString();

                tdDuty.InnerText = ds.Tables[0].Rows[0]["Duty"].ToString();
                tdPageSize.InnerText = ds.Tables[0].Rows[0]["PageSize"].ToString();
                chkIsDisable.Checked = ds.Tables[0].Rows[0]["IsDisabled"].ToString().funBoolean_StringToBoolean();
            }
        }
    }
}