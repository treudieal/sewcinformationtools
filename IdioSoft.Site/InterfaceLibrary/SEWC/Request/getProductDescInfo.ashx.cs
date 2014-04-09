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
    /// Summary description for getProductDescInfo
    /// </summary>
    public class getProductDescInfo : IdioSoft.Site.ClassLibrary.ICHttpHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            string ProductName = context.Server.UrlDecode(context.funString_RequestFormValue("ProductName"));
            string ServiceProvider = context.Server.UrlDecode(context.funString_RequestFormValue("ServiceProvider"));
            string strSQL = "SELECT productDesc  FROM webInfo_Basic_ServiceRequest_Product_Info where productName='" + ProductName + "' and ServiceProviders  like '%" + ServiceProvider + "%'";
            DataSet ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            StringBuilder sbReturn = new StringBuilder();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sbReturn.Append("\"" + ds.Tables[0].Rows[i]["productDesc"].ToString() + "\",");
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