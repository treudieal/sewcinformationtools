using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Text;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.Request
{
    /// <summary>
    /// Summary description for getMsgTemplateInfo
    /// </summary>
    public class getMsgTemplateInfo : IdioSoft.Site.ClassLibrary.ICHttpHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            string uRequestID = context.Server.UrlDecode(context.funString_RequestFormValue("uRequestID"));
            string NotificationNo = context.Server.UrlDecode(context.funString_RequestFormValue("NotificationNo"));
            string MsgTemplate = context.Server.UrlDecode(context.funString_RequestFormValue("MsgTemplate"));

            DataSet sqlDS = new DataSet();
            sqlDS = funDSGetinfo(uRequestID);
            if (sqlDS != null && sqlDS.Tables[0].Rows.Count > 0)
            {
                MsgTemplate = MsgTemplate.Replace("month", DateTime.Parse(sqlDS.Tables[0].Rows[0]["CaseTime"].ToString()).Month.ToString());
                MsgTemplate = MsgTemplate.Replace("day", DateTime.Parse(sqlDS.Tables[0].Rows[0]["CaseTime"].ToString()).Day.ToString());
                MsgTemplate = MsgTemplate.Replace("mlfbno", sqlDS.Tables[0].Rows[0]["MLFBNo"].ToString());
                if (MsgTemplate.ToString().ToLower().IndexOf("requestid") >= 0)
                {
                    MsgTemplate = MsgTemplate.Replace("requestid", NotificationNo);
                }
                else
                {
                    MsgTemplate = MsgTemplate.Replace("notificationno", NotificationNo);
                }
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(MsgTemplate);
        }

        public DataSet funDSGetinfo(string uRequestID)
        {
            string strSQL = "select MLFBNo,CaseTime from webInfo_ServiceRequest_Info where ID = '" + uRequestID + "'";
            DataSet sqlDS = new DataSet();
            try
            {
                sqlDS = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            }
            catch
            {
            }
            return sqlDS;
        }
    }
}