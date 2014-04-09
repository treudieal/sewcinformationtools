using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IdioSoft.Site.ClassLibrary;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.InterfaceLibrary.User
{
    /// <summary>
    /// Summary description for User_operation
    /// </summary>
    public class User_operation : ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            string OpType = context.funString_RequestFormValue("OpType");
            switch (OpType)
            {
                case "Delete":
                    subDB_Delete(context);
                    break;
                case "":
                case "Addnew":
                case "Modify":
                    subDB_Save(context);
                    break;
                case "Myinformation":
                    subDB_SaveMyInfo(context);
                    break;
            }
        }


        private void subDB_Delete(HttpContext context)
        {
            string strSQL = "";
            string OpID = context.funString_RequestFormValue("OpID");
            strSQL = "update webInfo_loginInfo set IsDel=1 where ID=" + OpID + "";
            string strError = objDbSQLAccess.funString_SQLExecuteScalar(strSQL);
            if (strError == "")
            {
                context.Response.Write("0");//成功
            }
            else
            {
                context.Response.Write("1");//失败
            }
            context.Response.End();
        }

        private bool funBoolean_IsExists(string OpID)
        {
            string strSQL = "";
            strSQL = "select count(*) from webInfo_loginInfo where ID=" + OpID + " and isdel=0";
            return objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0) > 0;
        }

        private void subDB_Save(HttpContext context)
        {
            string strSQL = "";

            string Email = "";
            string Password = "";
            string EnUserName = "";
            string CnUserName = "";
            string Tel = "";
            string Fax = "";
            string Region = "";
            string ServiceProvider = "";
            bool IsEngineer = false;
            string Distributors = "";
            string DdlDefaultpage = "";
            string StockNo = "";
            bool IsSfaeSpareSalesBU = false;
            bool IsSIASRepairCategoryType = false;
            bool IsListModuleLimited = false;
            
            string OperUserID = "F74929B4-62CE-4AE8-B6C3-06E07D892F10";
            string OpType = context.funString_RequestFormValue("OpType");
            string OpID = context.funString_RequestFormValue("OpID");

            if (!(OpType == "Addnew" || OpType == "Modify"))
            {
                context.Response.Write("1");//失败
                context.Response.End();
            }
            Email = context.funString_RequestFormValue("Email");
            Password = context.funString_RequestFormValue("Password");
            EnUserName = context.funString_RequestFormValue("EnUserName");
            CnUserName = context.funString_RequestFormValue("CnUserName");
            Tel = context.funString_RequestFormValue("Tel");
            Fax = context.funString_RequestFormValue("Fax");
            Region = context.funString_RequestFormValue("Region");
            ServiceProvider = context.funString_RequestFormValue("ServiceProvider");
            IsEngineer = context.funString_RequestFormValue("IsEngineer").funBoolean_StringToBoolean();
            Distributors = context.funString_RequestFormValue("Distributors");
            DdlDefaultpage = context.funString_RequestFormValue("DdlDefaultpage");
            StockNo = context.funString_RequestFormValue("StockNo");
            IsSfaeSpareSalesBU = context.funString_RequestFormValue("IsSfaeSpareSalesBU").funBoolean_StringToBoolean();
            IsSIASRepairCategoryType = context.funString_RequestFormValue("IsSIASRepairCategoryType").funBoolean_StringToBoolean();
            IsListModuleLimited = context.funString_RequestFormValue("IsListModuleLimited").funBoolean_StringToBoolean();

            string SystemLimited = "";
            string DutyLimited = "";
            string SfaeSpareSalesBU = "";
            string SIASRepairCategory = "";
            string ModuleLimited = "";

            if (Email == "")
            {
                context.Response.Write("2");//员工号不能为空
                context.Response.End();
            }
            if (funBoolean_IsExists(OpID))
            {
                strSQL = "update webInfo_loginInfo set Email = '" + Email + "',LoginPwd = '" + Password + "',EnUserName = '" + EnUserName + "',CnUserName = '" + CnUserName;
                strSQL += "',Region = '" + Region + "',ServiceProvider = '" + ServiceProvider + "',Tel = '" + Tel + "',Fax = '" + Fax;
                strSQL += "',SystemLimited = '" + SystemLimited + "',DutyLimited = '" + DutyLimited + "',isEngineer = " + IsEngineer + ",Distributors = '" + Distributors;
                strSQL += "',DefaultPage = '" + DdlDefaultpage + "',SfaeSpareSalesBU = '" + SfaeSpareSalesBU + "',SIASRepairCategory = '" + SIASRepairCategory;
                strSQL += "',stockNo = '" + StockNo + "',ModuleLimited = '" + ModuleLimited + "' where ID = " + OpID + "";
            }
            else
            {
                OpID = Guid.NewGuid().ToString();
                string CreateDate = "";
                CreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                int CreateUser = 0;
                CreateUser = objUserInfo.UserID;

                strSQL = "INSERT INTO webInfo_loginInfo  (Email, LoginPwd, CnUserName,EnUserName, Region, ServiceProvider, Tel, Fax, SystemLimited, DutyLimited, CreateDate, CreateUser,isEngineer,Distributors,DefaultPage,SfaeSpareSalesBU,SIASRepairCategory,stockNo,ModuleLimited) VALUES  ('";
                strSQL += Email + "','" + Password + "','" + CnUserName + "','" + EnUserName + "','" + Region + "','" + ServiceProvider;
                strSQL += "','" + Tel + "','" + Fax + "','" + SystemLimited + "','" + DutyLimited + "','" + CreateDate;
                strSQL += "'," + CreateUser + "," + IsEngineer + ",'" + Distributors + "','" + DdlDefaultpage + "','" + SfaeSpareSalesBU;
                strSQL += "','" + SIASRepairCategory + "','" + StockNo + "','" + ModuleLimited + "')";
            }
            string strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            if (strError == "")
            {
                context.Response.Write("0");//成功
            }
            else
            {
                context.Response.Write("1");//失败
            }
            context.Response.End();
        }

        private void subDB_SaveMyInfo(HttpContext context)
        {
            string strSQL = "";

            string Email = "";
            string Password = "";
            string EnUserName = "";
            string CnUserName = "";
            string Tel = "";
            string Fax = "";
            string Region = "";
            string ServiceProvider = "";
            int SetPage = 0;
            string OpID = objUserInfo.UserID.ToString();

            Email = context.funString_RequestFormValue("Email");
            Password = context.funString_RequestFormValue("Password");
            EnUserName = context.funString_RequestFormValue("EnUserName");
            CnUserName = context.funString_RequestFormValue("CnUserName");
            Tel = context.funString_RequestFormValue("Tel");
            Fax = context.funString_RequestFormValue("Fax");
            Region = context.funString_RequestFormValue("Region");
            ServiceProvider = context.funString_RequestFormValue("ServiceProvider");
            SetPage = context.funString_RequestFormValue("PageSize").funInt_StringToInt(10);

            strSQL = strSQL + "UPDATE webInfo_loginInfo SET  LoginPwd ='" + Password + "',";
            strSQL = strSQL + "EnUserName ='" + EnUserName + "', CnUserName ='" + CnUserName + "',";
            strSQL = strSQL + " Tel ='" + Tel + "', Fax ='" + Fax + "',";
            strSQL = strSQL + "SetPage = " + SetPage + "";
            strSQL = strSQL + " where ID=" + objUserInfo.UserID;
 
            string strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            if (strError == "")
            {
                context.Response.Write("0");//成功
            }
            else
            {
                context.Response.Write("1");//失败
            }
            context.Response.End();
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