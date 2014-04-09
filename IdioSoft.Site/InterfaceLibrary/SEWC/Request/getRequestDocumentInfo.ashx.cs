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
    /// Summary description for getRequestDocumentInfo
    /// </summary>
    public class getRequestDocumentInfo : IdioSoft.Site.ClassLibrary.ICHttpHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            string uRequestID = context.Server.UrlDecode(context.funString_RequestFormValue("uRequestID"));
            string strSQL = @"select RequestDocument from webinfo_serviceRequest_info where id = '" + uRequestID + "'";
            DataSet ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            StringBuilder sbReturn = new StringBuilder();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sbReturn.Append("\"" + ds.Tables[0].Rows[i]["RequestDocument"].ToString() + "\",");
                }
            }
            string strReturn = sbReturn.ToString();
            if (strReturn != "")
            {
                strReturn = strReturn.Substring(0, strReturn.Length - 1);
            }
            strReturn = "[" + strReturn + "]";
            context.Response.ContentType = "text/plain";
            context.Response.Write(strReturn);
        }
    }
}