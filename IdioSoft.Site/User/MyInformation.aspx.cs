using IdioSoft.Site.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.User
{
    public partial class MyInformation : IPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cboRegion.subComboBox_LoadItems("SELECT  RegionName FROM  webInfo_UserRegion order by RegionName", 0, new ListItem("", ""));
            cboServiceProvider.subComboBox_LoadItems("SELECT ServiceProvider FROM webInfo_Basic_serviceProvider_info",0,new ListItem("",""));

            try
            {
                
                subDetail_DBLoad();
            }
            catch (System.Exception ex)
            {

            }
        }

        private void subDetail_DBLoad()
        {
            string strSQL = "";
            strSQL = "SELECT Email,LoginPwd, EnUserName, CnUserName, Tel, Fax, Region, ServiceProvider,  isEngineer, Distributors,DefaultPage,stockNo,SetPage FROM webInfo_loginInfo where Id=" + objUserInfo.UserID;
            DataSet ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                txtEmail.Value = ds.Tables[0].Rows[0]["Email"].ToString();
                txtPassword.Value = ds.Tables[0].Rows[0]["LoginPwd"].ToString();
                txtEnUserName.Value = ds.Tables[0].Rows[0]["EnUserName"].ToString();
                txtCnUserName.Value = ds.Tables[0].Rows[0]["CnUserName"].ToString();
                txtTel.Value = ds.Tables[0].Rows[0]["Tel"].ToString();
                txtFax.Value = ds.Tables[0].Rows[0]["Fax"].ToString();
                txtSetPage.Value = ds.Tables[0].Rows[0]["SetPage"].ToString();

                for (int i = 0; i <= cboRegion.Items.Count - 1; i++)
                {
                    if (cboRegion.Items[i].Value == ds.Tables[0].Rows[0]["Region"].ToString())
                    {
                        cboRegion.SelectedIndex = i;
                        break;
                    }
                }
                for (int i = 0; i <= cboServiceProvider.Items.Count - 1; i++)
                {
                    if (cboServiceProvider.Items[i].Value == ds.Tables[0].Rows[0]["ServiceProvider"].ToString())
                    {
                        cboServiceProvider.SelectedIndex = i;
                        break;
                    }
                }
                hidPassword.Value = ds.Tables[0].Rows[0]["LoginPwd"].ToString();
            }
        }
    }
}