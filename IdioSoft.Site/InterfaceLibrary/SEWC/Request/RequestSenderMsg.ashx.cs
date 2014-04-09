using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IdioSoft.Site.ClassLibrary;
using System.Data;
using IdioSoft.Business.Method;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.Request
{
    /// <summary>
    /// Summary description for RequestSenderMsg
    /// </summary>
    public class RequestSenderMsg : ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            string strSQL = "";
            string strError = "";

            string NotificationNo = context.funString_RequestFormValue("NotificationNo").funString_SQLToString();
            string AppMobile = context.funString_RequestFormValue("AppMobile").funString_SQLToString();
            string EndUserMobile = context.funString_RequestFormValue("EndUserMobile").funString_SQLToString();
            string Content = context.funString_RequestFormValue("Content").funString_SQLToString();
            string uRequestID = context.funString_RequestFormValue("uRequestID");

            strSQL = @"insert into webInfo_Message_Info(Sender,NotificationNo,AppMobile,EndUserMobile,Content,CreateUser,CreateDate,ModID,Port) values(";
            strSQL += "'" + objUserInfo.EnUserName + "','" + NotificationNo + "','" + AppMobile + "','" + EndUserMobile + "','" + Content + "'," + objUserInfo.UserID;
            strSQL += ",'" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',1,'" + funString_SMSPort() + "')";
            strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

            //向SMS平台存入信息
            IdioSoft.Site.ClassLibrary.Control.ClassSMS objclassSMS = new ClassLibrary.Control.ClassSMS();
            bool blnMsgError = false;

            if (AppMobile.Trim() != "")
            {
                string strAppMobile = "";
                if (AppMobile.Substring(0, 1).Trim().ToString() == "0")
                {
                    strAppMobile = AppMobile.Remove(0, 1);
                }
                else
                {
                    strAppMobile = AppMobile.Trim();
                }
                if (!objclassSMS.subDoSendMessage(0, objUserInfo.EnUserName, strAppMobile, Content, System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 1, int.Parse(funString_SMSPort()), 0))
                {
                    blnMsgError = true;
                }
            }
            if (EndUserMobile.Trim() != "")
            {
                string strEnduserMobile = "";

                if (EndUserMobile.Substring(0, 1).Trim().ToString() == "0")
                {
                    strEnduserMobile = EndUserMobile.Remove(0, 1);
                }
                else
                {
                    strEnduserMobile = EndUserMobile.Trim();
                }
                if (!objclassSMS.subDoSendMessage(0, objUserInfo.EnUserName, strEnduserMobile, Content, System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 1, int.Parse(funString_SMSPort()), 0))
                {
                    blnMsgError = true;
                }
            }

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

        #region "获得发送的基本信息"
        private string funString_SMSPort()
        {
            string strSQL = "select port from webinfo_Basic_SMS_port_info";
            string strport = "";
            try
            {
                strport = objDbSQLAccess.funString_SQLExecuteScalar(strSQL);
            }
            catch
            {
                strport = "0";
            }
            return strport;
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}