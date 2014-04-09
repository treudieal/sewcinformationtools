using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;
using System.Collections;
using IdioSoft.Business.Method;
using IdioSoft.Site.ClassLibrary;

namespace IdioSoft.Site.InterfaceLibrary.Login
{
    /// <summary>
    /// Summary description for Login
    /// </summary>
    public class Login : ICHttpHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            string strMail = context.funString_RequestFormValue("email");
            string strLoginName = context.funString_RequestFormValue("loginname");
            string strPassword = context.funString_RequestFormValue("loginpwd");
            //if (strPassword != null)
            //{
            //    strPassword = IdioSoft.Common.Class.Encryption.Encrypt(strPassword);
            //}
            string stype = context.funString_RequestFormValue("stype");
            switch (stype)
            {
                case "findpassword":
                    break;
                case "login":
                    funString_Login(strLoginName, strPassword);
                    break;
            }
        }

        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="strMail"></param>
        /// <returns></returns>
        private void funString_FindPassword(string strMail)
        {
            int intIsEmail = 0;
            string strSQL = "";

            strSQL = "select LoginPwd, EnUserName, CnUserName, Email from webInfo_loginInfo where Email = '" + strMail + "'";
            DataSet dsLogin = new DataSet();
            dsLogin = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            if (dsLogin != null && dsLogin.Tables[0].Rows.Count > 0)
            {
                DataSet ds = new DataSet();
                strSQL = "SELECT ID, Email, UserName, Password, SmtpServer FROM Public_Basic_EmailInfo";
                ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    string strTemplateName = HttpContext.Current.Server.MapPath("../../Document/Email/FindPassword.htm");
                    string strBody = strTemplateName.funString_GetHtmlFile();
                    strBody = strBody.Replace("!email!", dsLogin.Tables[0].Rows[0]["Email"].ToString());
                    strBody = strBody.Replace("!personno!", "");
                    strBody = strBody.Replace("!password!",  dsLogin.Tables[0].Rows[0]["LoginPwd"].ToString());
                    strBody = strBody.Replace("!date!", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    string strError = ds.Tables[0].Rows[0]["Email"].ToString().funString_SendNoMailByWebMail(ds.Tables[0].Rows[0]["UserName"].ToString(), ds.Tables[0].Rows[0]["Password"].ToString(), strBody, ds.Tables[0].Rows[0]["SmtpServer"].ToString(), strMail, "Find Password", "", false, "", null);
                    if (strError == "")
                    {
                        intIsEmail = 1;
                    }
                }
            }
            HttpContext.Current.Response.Write(intIsEmail.ToString());
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        private void funString_Login(string Email, string Password)
        {
            int intIsLogin = 0;
            string strSQL = "";
            strSQL = @"SELECT  ID, Email, LoginPwd, EnUserName, CnUserName, Region, ServiceProvider, Tel, Fax,SystemLimiteds, SystemLimited, 
            DutyLimited, SetPage,isEngineer,Distributors,DefaultPage,SIASRepairCategory,Modulelimited,StockNo,BUs,SEALLimiteds,
            CSSNCLimiteds,ProductLimited,SSCLLimiteds,GoodWillLimiteds,IsFollowCallcenter,SFAEMType,issa,UserScreenHeight,UserScreenWidth,AHeight,SEWCLimiteds,EscLimiteds FROM  webinfo_loginInfo where IsDel=0 and ";
            strSQL = strSQL + "Email='" + Email + "' and LoginPwd='" + Password + "'";
            DataSet ds = new DataSet();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            IdioSoft.Business.Method.LogHelper.GetInstance(HttpContext.Current.Server.MapPath("../../Log/")).Save(strSQL);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                intIsLogin = 1;
                #region "载入用户信息"
                objUserInfo.UserID = ds.Tables[0].Rows[0]["ID"].ToString().funInt_StringToInt(0);
                objUserInfo.UserEmail = ds.Tables[0].Rows[0]["Email"].ToString();
                objUserInfo.UserPwd = ds.Tables[0].Rows[0]["LoginPwd"].ToString();
                objUserInfo.EnUserName = ds.Tables[0].Rows[0]["EnUserName"].ToString();
                objUserInfo.CnUserName = ds.Tables[0].Rows[0]["CnUserName"].ToString();
                objUserInfo.Region = ds.Tables[0].Rows[0]["Region"].ToString();
                objUserInfo.ServiceProvider = ds.Tables[0].Rows[0]["ServiceProvider"].ToString();
                objUserInfo.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                objUserInfo.Fax = ds.Tables[0].Rows[0]["Fax"].ToString();
                objUserInfo.SysLimited = ds.Tables[0].Rows[0]["SystemLimited"].ToString();
                objUserInfo.DutyLimited = ds.Tables[0].Rows[0]["DutyLimited"].ToString();
                objUserInfo.PageSize = int.Parse(ds.Tables[0].Rows[0]["SetPage"].ToString());
                objUserInfo.isEngineer = bool.Parse(ds.Tables[0].Rows[0]["isEngineer"].ToString());
                objUserInfo.Distributors = ds.Tables[0].Rows[0]["Distributors"].ToString();
                objUserInfo.DefaultPage = ds.Tables[0].Rows[0]["DefaultPage"].ToString();
                objUserInfo.SIASRepairCategory = ds.Tables[0].Rows[0]["SIASRepairCategory"].ToString();
                objUserInfo.ModuleLimited = ds.Tables[0].Rows[0]["ModuleLimited"].ToString();
                objUserInfo.StockNo = ds.Tables[0].Rows[0]["StockNo"].ToString();
                objUserInfo.SysLimiteds = ds.Tables[0].Rows[0]["SystemLimiteds"].ToString();
                objUserInfo.SEALLimiteds = ds.Tables[0].Rows[0]["SEALLimiteds"].ToString();
                objUserInfo.CSSNCLimiteds = ds.Tables[0].Rows[0]["CSSNCLimiteds"].ToString();
                objUserInfo.SSCLLimiteds = ds.Tables[0].Rows[0]["SSCLLimiteds"].ToString();
                objUserInfo.ProductLimited = ds.Tables[0].Rows[0]["ProductLimited"].ToString();
                objUserInfo.GoodWillLimiteds = ds.Tables[0].Rows[0]["GoodWillLimiteds"].ToString();
                objUserInfo.IsFollowCallcenter = ds.Tables[0].Rows[0]["IsFollowCallcenter"].ToString().funBoolean_StringToBoolean();
                objUserInfo.IsSA = ds.Tables[0].Rows[0]["IsSA"].ToString().funBoolean_StringToBoolean();
                objUserInfo.SEWCLimiteds = ds.Tables[0].Rows[0]["SEWCLimiteds"].ToString();
                objUserInfo.EscLimiteds = ds.Tables[0].Rows[0]["EscLimiteds"].ToString();
                string strMType = ds.Tables[0].Rows[0]["SFAEMType"].ToString();

                if (strMType != "")
                {
                    strMType = "'" + strMType.Replace(",", "','") + "'";
                }
                else
                {
                    strMType = "''";
                }
                objUserInfo.SFAEMType = strMType;

                string strBUs = ds.Tables[0].Rows[0]["BUs"].ToString();


                string[] aryBUs = strBUs.Split(',');
                string strTmpBus = "";
                for (int i = 0; i < aryBUs.Length; i++)
                {
                    if (aryBUs[i] != "")
                    {
                        strTmpBus = strTmpBus + "'" + aryBUs[i] + "',";
                    }
                }
                if (strTmpBus != "")
                {
                    strTmpBus = strTmpBus.Substring(0, strTmpBus.Length - 1);
                }
                objUserInfo.BUs = strTmpBus;
                HttpContext.Current.Session["UserInfo"] = objUserInfo;
                #endregion
            }
            HttpContext.Current.Response.Write("{loginStatus:" + intIsLogin.ToString() + ",DefaultPage:\"" + objUserInfo.DefaultPage+"\"}");
            HttpContext.Current.Response.End();
        }

        public override bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}