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
    public partial class Operation : IPage
    {
        string KeyID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            cboRegion.subComboBox_LoadItems("SELECT  RegionName FROM  webInfo_UserRegion order by RegionName", 0, new ListItem("", ""));
            cboServiceProvider.subComboBox_LoadItems("SELECT ServiceProvider FROM webInfo_Basic_serviceProvider_info order by ServiceProvider", 0, new ListItem("", ""));
            cboDistributors.subComboBox_LoadItems("SELECT DistributorsName FROM webInfo_Basic_ESPmonthly_ServiceReport_Distributors_Info order by DistributorsName", 0, new ListItem("", ""));
            subLoad_chkSfaeSpareSalesBU();
            subLoad_chkSIASRepairCategoryType();
            subLoad_chkListModuleLimited();
            subDutyLimited();
            subSystemLimited();
            subLoadDefaultpage();
           
            try
            {
                KeyID = Request["KeyID"].ToString();
                subDetail_DBLoad();
            }
            catch (System.Exception ex)
            {
            	
            }
            foreach (ListItem item in cboServiceProvider.Items)
            {
                if (item.Text == objUserInfo.ServiceProvider)
                {
                    item.Selected = true;
                    //cboServiceProvider.Disabled = true;
                }
                else
                {
                    item.Selected = false;
                }
            }
            chkEngineer.Disabled = true;
        }

        #region "载入基本信息"
        private void subLoad_chkSfaeSpareSalesBU()
        {
            chkListSystemLimited.Items.Clear();
            string strSQL;
            strSQL = "SELECT Bu  FROM webInfo_Basic_SpareSales_Quotation_BU_Info ORDER BY SortID";
            ListItem item;
            try
            {
                DataSet ds = new DataSet();
                ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
                if (ds != null)
                {
                    for (int nC = 0; nC < ds.Tables[0].Rows.Count; nC++)
                    {
                        item = new ListItem();
                        item.Text = ds.Tables[0].Rows[nC]["Bu"].ToString();
                        item.Value = ds.Tables[0].Rows[nC]["Bu"].ToString();
                        chkSfaeSpareSalesBU.Items.Add(item);
                    }
                }
            }
            catch
            {

            }
        }

        private void subLoad_chkSIASRepairCategoryType()
        {
            chkSIASRepairCategoryType.Items.Clear();
            string strSQL = "select RepairCategory from WebInfo_Basic_SIAS_RepairCategory_ProductType group by RepairCategory";
            DataSet ds = new DataSet();
            try
            {
                ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
                if (ds != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ListItem item = new ListItem();
                        item.Text = ds.Tables[0].Rows[i]["RepairCategory"].ToString();
                        item.Value = ds.Tables[0].Rows[i]["RepairCategory"].ToString();
                        chkSIASRepairCategoryType.Items.Add(item);
                    }
                }
            }
            catch
            {
            }
        }

        private void subLoad_chkListModuleLimited()
        {
            this.chkListModuleLimited.Items.Clear();
            string strSQL = "select ID,ModuleName from Public_Basic_Module_Info";
            ListItem item;
            try
            {
                DataSet ds = new DataSet();
                ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);

                if (ds != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item = new ListItem();
                        item.Text = ds.Tables[0].Rows[i]["ModuleName"].ToString();
                        item.Value = ds.Tables[0].Rows[i]["ID"].ToString();
                        this.chkListModuleLimited.Items.Add(item);
                    }
                }
            }
            catch
            { }
        }

        //载入职务权限
        private void subDutyLimited()
        {
            chkListDutyLimited.Items.Clear();
            string strSQL;
            string strLimit = objUserInfo.DutyLimited;
            strSQL = "select duty,ID from webInfo_dutyinfo order by sortinfo";
            ListItem item;
            try
            {
                DataSet ds = new DataSet();
                ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
                if (ds != null)
                {
                    for (int nA = 0; nA < ds.Tables[0].Rows.Count; nA++)
                    {
                        item = new ListItem();
                        item.Text = ds.Tables[0].Rows[nA]["duty"].ToString();
                        item.Value = ds.Tables[0].Rows[nA]["ID"].ToString();
                        chkListDutyLimited.Items.Add(item);
                    }
                }
            }
            catch
            {

            }
        }

        //载入系统权限
        private void subSystemLimited()
        {
            chkListSystemLimited.Items.Clear();
            string strSQL;
            string strLimit = objUserInfo.SysLimited;
            strSQL = "SELECT Limited, SortID  FROM webInfo_Limited order by OrderID ";
            ListItem item;

            try
            {
                DataSet ds = new DataSet();
                ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
                if (ds != null)
                {
                    for (int nA = 0; nA < ds.Tables[0].Rows.Count; nA++)
                    {
                        item = new ListItem();
                        item.Text = ds.Tables[0].Rows[nA]["Limited"].ToString();
                        item.Value = ds.Tables[0].Rows[nA]["SortID"].ToString();
                        chkListSystemLimited.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        //载入默认页面
        private void subLoadDefaultpage()
        {
            string strSQL;
            strSQL = "SELECT ID,PageName,PageUrl FROM webInfo_Basic_LoginInfo_DefaultPage_info ORDER BY SortID";
            ListItem item;
            try
            {
                DataSet ds = new DataSet();
                ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
                item = new ListItem();
                item.Text = "";
                item.Value = "";
                DdlDefaultpage.Items.Add(item);
                if (ds != null)
                {
                    for (int nC = 0; nC < ds.Tables[0].Rows.Count; nC++)
                    {
                        item = new ListItem();
                        item.Text = ds.Tables[0].Rows[nC]["PageName"].ToString();
                        item.Value = ds.Tables[0].Rows[nC]["PageUrl"].ToString();
                        DdlDefaultpage.Items.Add(item);
                    }
                }
            }
            catch
            {
            }
        }
        #endregion

        #region "载入需要修改的信息"
        private void subDetail_DBLoad()
        {
            string strSQL = "";
            strSQL = "SELECT     Email, LoginPwd, EnUserName, CnUserName, Region, ServiceProvider, Tel, Fax, SystemLimited, DutyLimited,isEngineer,Distributors,DefaultPage,SfaeSpareSalesBU,SIASRepairCategory,stockNo,ModuleLimited FROM    webInfo_loginInfo where ID=" + objUserInfo.UserID + "";

            DataSet ds = new DataSet();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                txtEmail.Value = ds.Tables[0].Rows[0]["Email"].ToString();

                txtPassword.Value = ds.Tables[0].Rows[0]["LoginPwd"].ToString();
                txtEnUserName.Value = ds.Tables[0].Rows[0]["EnUserName"].ToString();
                txtCnUserName.Value = ds.Tables[0].Rows[0]["CnUserName"].ToString();
                txtTel.Value = ds.Tables[0].Rows[0]["Tel"].ToString();
                txtFax.Value = ds.Tables[0].Rows[0]["Fax"].ToString();
                txtStockNo.Value = ds.Tables[0].Rows[0]["stockNo"].ToString();

                subLoadModifySystemLimited(ds.Tables[0].Rows[0]["SystemLimited"].ToString());
                subLoadModifyDutyLimited(ds.Tables[0].Rows[0]["DutyLimited"].ToString());
                subLoadModifyBU(ds.Tables[0].Rows[0]["SfaeSpareSalesBU"].ToString());
                subLoadModifySIASRepairCategory(ds.Tables[0].Rows[0]["SIASRepairCategory"].ToString());
                subLoadModifyModuleLimited(ds.Tables[0].Rows[0]["ModuleLimited"].ToString());

                cboRegion.subComboBox_SelectItemByValue(ds.Tables[0].Rows[0]["Region"].ToString());
                cboServiceProvider.subComboBox_SelectItemByValue(ds.Tables[0].Rows[0]["ServiceProvider"].ToString());
                cboDistributors.subComboBox_SelectItemByValue(ds.Tables[0].Rows[0]["Distributors"].ToString());
                DdlDefaultpage.subComboBox_SelectItemByValue(ds.Tables[0].Rows[0]["DefaultPage"].ToString());

                if (bool.Parse(ds.Tables[0].Rows[0]["isEngineer"].ToString()))
                {
                    chkEngineer.Checked = true;
                }
                else
                {
                    chkEngineer.Checked = false;
                }
            }
        }
        #endregion

        #region "勾选模块权限"
        private void subLoadModifyModuleLimited(string strLimit)
        {
            for (int i = 0; i < this.chkListModuleLimited.Items.Count; i++)
            {
                if (strLimit.IndexOf("," + this.chkListModuleLimited.Items[i].Value + ",") >= 0)
                {
                    this.chkListModuleLimited.Items[i].Selected = true;
                }
            }
        }
        
        #endregion

        #region "取得模块权限列表"
        public string getModuleLimited
        {
            get
            {
                string strLimited = "";
                for (int i = 0; i < this.chkListModuleLimited.Items.Count; i++)
                {
                    if (this.chkListModuleLimited.Items[i].Selected)
                    {
                        strLimited = strLimited + this.chkListModuleLimited.Items[i].Value + ",";
                    }
                }
                if (strLimited != "")
                {
                    strLimited = "," + strLimited;
                }
                else
                {
                    strLimited = ",,";
                }
                return strLimited;
            }
        }
        #endregion

        #region "勾选系统权限"
        private void subLoadModifySystemLimited(string strLimit)
        {
            for (int i = 0; i <= chkListSystemLimited.Items.Count - 1; i++)
            {
                if (strLimit.IndexOf("," + chkListSystemLimited.Items[i].Value + ",") >= 0)
                {
                    chkListSystemLimited.Items[i].Selected = true;
                }
            }
        }
        #endregion

        #region "勾选SIASRepairCategory"
        private void subLoadModifySIASRepairCategory(string strRepairCategory)
        {
            for (int i = 0; i < chkSIASRepairCategoryType.Items.Count; i++)
            {
                if (strRepairCategory.IndexOf("," + chkSIASRepairCategoryType.Items[i].Value + ",") >= 0)
                {
                    chkSIASRepairCategoryType.Items[i].Selected = true;
                }
            }
        }
        #endregion

        #region "勾选BU"
        private void subLoadModifyBU(string strBU)
        {
            for (int i = 0; i <= chkSfaeSpareSalesBU.Items.Count - 1; i++)
            {
                if (strBU.IndexOf("," + chkSfaeSpareSalesBU.Items[i].Value + ",") >= 0)
                {
                    chkSfaeSpareSalesBU.Items[i].Selected = true;
                }
            }
        }
        #endregion

        #region "勾选职务权限"
        private void subLoadModifyDutyLimited(string strLimit)
        {
            for (int i = 0; i <= chkListDutyLimited.Items.Count - 1; i++)
            {
                if (strLimit.IndexOf("," + chkListDutyLimited.Items[i].Value + ",") >= 0)
                {
                    chkListDutyLimited.Items[i].Selected = true;
                }
            }
        }
        #endregion
    }
}