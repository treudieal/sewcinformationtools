using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using System.IO;
using System.Text;
using IdioSoft.Site.ClassLibrary;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.InterfaceLibrary.Escalation.List
{
    /// <summary>
    /// Summary description for FileUpLoad
    /// </summary>
    public class FileUpLoad : ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            StringBuilder sbReturn = new StringBuilder();
            if (context.Request.ServerVariables["HTTP_REFERER"] == null)
            {
                sbReturn.Append("{");
                sbReturn.Append("\"fileName\":\"" + "" + "\",\"iserror\":true");
                sbReturn.Append("}");
                context.Response.End();
                return;
            }
            string ActivityID = context.funString_RequestFormValue("ActivityID");
            if (ActivityID == "")
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
            string strFileName = Path.GetFileName(context.Request.Files[0].FileName).ToLower();
            string dir = context.Server.MapPath("../../../Attachment/Escalation/");
            string strSaveLocation = dir + strFileName;
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
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
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
            long FileSize = context.Request.Files[0].ContentLength;
            string strSQL = "";
            string strError = "";
            //做业务
            if (strFileName != "")
            {
                string fid = Guid.NewGuid().ToString();
                strSQL = @"INSERT INTO Escalation_Activity_AttachmentInfo(ActivityFileID, ActivityID, DocumentName, CreatedUserID, CreatedDate) VALUES (";
                strSQL += "'" + fid + "','" + ActivityID + "','" + strFileName + "','" + objUserInfo.UserID + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
                if (strError == "")
                {
                    sbReturn.Append("{");
                    sbReturn.Append("\"fileName\":\"" + strFileName + "\",\"iserror\":false,\"fid\":\"" + fid + "\"");
                    sbReturn.Append("}");
                }
                else
                {
                    sbReturn.Append("{");
                    sbReturn.Append("\"fileName\":\"" + strFileName + "\",\"iserror\":true");
                    sbReturn.Append("}");
                }
            }
            else
            {
                sbReturn.Append("{");
                sbReturn.Append("\"fileName\":\"" + strFileName + "\",\"iserror\":true");
                sbReturn.Append("}");
            }
            context.Response.Clear();
            context.Response.Write(sbReturn.ToString());
            context.Response.Flush();
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