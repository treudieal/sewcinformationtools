using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IdioSoft.Site.ClassLibrary;
using System.Data;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.Request
{
    /// <summary>
    /// Summary description for EditContactOperation
    /// </summary>
    public class EditContactOperation : ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            string OperationType = context.funString_RequestFormValue("OperationType");
            switch (OperationType.ToString().Trim().ToLower())
            {
                case "addnew":
                case "modify":
                    subDB_EditCompany(context);
                    break;
                case "delete":
                    subDB_Delete(context);
                    break;
            }
        }

        public void subDB_EditCompany(HttpContext context)
        {
            string strError = "";
            string strSQL = "";

            string AccountID = context.funString_RequestFormValue("AccountID");
            string ContactName = context.funString_RequestFormValue("ContactName");
            string Tel = context.funString_RequestFormValue("Tel");
            string Mobile = context.funString_RequestFormValue("Mobile");
            string Fax = context.funString_RequestFormValue("Fax");
            string Address = context.funString_RequestFormValue("Address");
            string PostCode = context.funString_RequestFormValue("PostCode");
            string Email = context.funString_RequestFormValue("Email");

            string OperationType = context.funString_RequestFormValue("OperationType").ToString().Trim().ToLower();
            string CreateDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (OperationType == "addnew")
            {
                strSQL = @"INSERT INTO Webinfo_Account_Contact_info
                      (AccountID, ContactName, Tel, Mobile, Fax, Address, PostCode, Email, CreateUser, CreateDate) values (";
                strSQL = strSQL + "'" + AccountID + "','" + ContactName + "','" + Tel + "','" + Mobile + "','";
                strSQL = strSQL + Fax + "','" + Address + "','" + PostCode + "','" + Email + "'," + objUserInfo.UserID + ",'" + CreateDate + "')";
            }
            if (OperationType == "modify")
            {
                string ContactID = context.funString_RequestFormValue("ContactID");
                strSQL = @"UPDATE    Webinfo_Account_Contact_info SET AccountID ='" + AccountID + "', ContactName ='" + ContactName + "',";
                strSQL = strSQL + "Tel ='" + Tel + "', Mobile ='" + Mobile + "', Fax ='" + Fax + "', Address ='" + Address + "', PostCode ='" + PostCode + "',";
                strSQL = strSQL + "Email ='" + Email + "' where ID='" + ContactID + "'";
            }
            strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

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

        public void subDB_Delete(HttpContext context)
        {
            string strError = "";
            string strSQL = "";

            string ContactID = context.funString_RequestFormValue("ContactID");
            strSQL = "delete from Webinfo_Account_Contact_info where ID='" + ContactID + "'";
            strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}