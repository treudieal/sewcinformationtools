using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
using IdioSoft.Site.ClassLibrary;
using System.Data;
using System.IO;
using System.Text;
using System.Collections;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.Request
{
    /// <summary>
    /// Summary description for RequestSendMail
    /// </summary>
    public class RequestSendMail : ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            string strSQL = "";
            string strError = "";

            string SendMail = context.Server.UrlDecode(context.funString_RequestFormValue("SendMail"));
            string SendCC = context.Server.UrlDecode(context.funString_RequestFormValue("SendCC"));
            string uRequestID = context.Server.UrlDecode(context.funString_RequestFormValue("uRequestID"));

            //开始发信
            strSQL = @"SELECT     ID, Email, EmailName, Password, SmtpServer FROM         Public_Basic_SendEmail_Info";
            DataSet dsSender = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);

            strSQL = "SELECT   count(*) FROM         CallCenter_SendMailInfo where email='" + SendCC + "'";
            int intCount = objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0);
            if (intCount <= 0)
            {
                strSQL = "INSERT INTO CallCenter_SendMailInfo(Email) VALUES ('" + SendCC + "')";
                strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            }
            strSQL = "select RequestDocument from webinfo_serviceRequest_info where ID='" + uRequestID + "'";
            string RequestDocument = objDbSQLAccess.funString_SQLExecuteScalar(strSQL);
            string strSaveLocation = HttpContext.Current.Server.MapPath("../../RequestDocument/" + RequestDocument);
            List<string> ary = new List<string>();
            ary.Add(strSaveLocation);

            string Subject = "New Request";
            strError =  Function.funString_SendMailByWebMail(dsSender.Tables[0].Rows[0]["Email"].ToString(), dsSender.Tables[0].Rows[0]["EmailName"].ToString(), dsSender.Tables[0].Rows[0]["Password"].ToString(), "", dsSender.Tables[0].Rows[0]["SmtpServer"].ToString(), SendMail, Subject, SendCC, false, "", ary);
            if (strError == "")
            {
                context.Response.Write("0");
            }
            else
            {
                context.Response.Write("1");
            }
            context.Response.End();
        }
    }
}