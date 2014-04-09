using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Text;

using IdioSoft.Site.ClassLibrary;
using System.Collections;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.Request
{
    /// <summary>
    /// Summary description for doajaxfileupload
    /// </summary>
    public class doajaxfileupload : ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            StringBuilder sbReturn = new StringBuilder();
            //context.Response.ContentType = "text/plain";
            if (context.Request.ServerVariables["HTTP_REFERER"] == null)
            {
                context.Response.Write("不要这样访问");
                context.Response.End();
            }

            string uRequestID = "";
            try
            {
                uRequestID = context.Request["uRequestID"].ToString();
            }
            catch (Exception)
            {

            }
            if (uRequestID == "")
            {
                context.Response.Clear();
                sbReturn.Append("{");
                sbReturn.Append("\"fileName\":\"" + "" + "\",\"iserror\":true");
                sbReturn.Append("}");
                context.Response.Write(sbReturn.ToString());
                context.Response.Flush();
                context.Response.End();
                return;
            }
            string strYear = DateTime.Now.ToString("yyyy");
            string strExtension = Path.GetExtension(context.Request.Files[0].FileName).ToLower();
            string sName = Path.GetFileNameWithoutExtension(context.Request.Files[0].FileName);
            string fullFileName = sName + "_" + GetFileName(uRequestID) + strExtension;
            string dir = context.Server.MapPath("../../RequestDocument/") + strYear + "/";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string strSaveLocation = dir + fullFileName;
            if (File.Exists(strSaveLocation))
            {
                try
                {
                    File.Delete(strSaveLocation);
                }
                catch (Exception)
                {

                }
            }
            if (context.Request.Files[0].ContentLength <= 0)
            {
                context.Response.Clear();
                sbReturn.Append("{");
                sbReturn.Append("\"fileName\":\"" + "" + "\",\"iserror\":true");
                sbReturn.Append("}");
                context.Response.Write(sbReturn.ToString());
                context.Response.Flush();
                context.Response.End();
                return;
            }
            context.Request.Files[0].SaveAs(strSaveLocation);
            string strSQL = "";
            //做业务
            if (fullFileName != "")
            {
                string RequestID = funString_RequestCode();
                //strSQL = "update webInfo_ServiceRequest_Info set RequestDocument='" + strYear + "/" + fullFileName + "' where ID='" + uRequestID + "'";
                strSQL = "insert into webInfo_ServiceRequest_Info(ID,RequestID,RequestDocument) values('" + uRequestID + "','" + RequestID + "','" + strYear + "/" + fullFileName + "')";
                string strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            }
            ArrayList ary = new ArrayList();
            ary.Add(strSaveLocation);
            context.Response.Clear();

            sbReturn.Append("{");
            sbReturn.Append("\"fileName\":\"" + strYear + "/" + fullFileName + "\",\"iserror\":false,\"sfile\":\"" + fullFileName + "\"");
            sbReturn.Append("}");

            context.Response.Write(sbReturn.ToString());
            context.Response.Flush();
            context.Response.End();
        }

        private string GetFileName(string uRequestID)
        {
            string strSQL = "select case when NotificationNo='' then RequestID else NotificationNo end from webInfo_serviceRequest_Info where ID='" + uRequestID + "'";
            return objDbSQLAccess.funString_SQLExecuteScalar(strSQL);
        }

        #region "RequestID编码yyyyMM0001"
        public string funString_RequestCode()
        {
            string strSQL;

            strSQL = "SELECT   max(case when ISNUMERIC(RequestID)=0 then 0 else CONVERT(decimal,RequestID) end)  as MaxID FROM webInfo_ServiceRequest_Info where  substring(requestid,1,1)=2";//year(createdate)=" + DateTime.Now.Year.ToString() +" and

            string strID = "";
            try
            {
                strID = objDbSQLAccess.funString_SQLExecuteScalar(strSQL);
                if (strID == "")
                {
                    strID = DateTime.Now.ToString("yyyyMM0001");
                }
                else
                {
                    string sYear = DateTime.Now.Year.ToString();
                    string strTmp = strID.Substring(0, 4);
                    if (strTmp != sYear)
                    {
                        strID = DateTime.Now.ToString("yyyyMM0001");
                    }
                    else
                    {
                        strID = (Int64.Parse(strID) + 1).ToString();
                    }
                }
            }
            catch
            {
                strID = DateTime.Now.ToString("yyyyMM0001");
            }
            return strID;
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