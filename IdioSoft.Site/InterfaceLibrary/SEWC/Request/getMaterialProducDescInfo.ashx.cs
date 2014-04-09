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
    /// Summary description for getMaterialProducDescInfo
    /// </summary>
    public class getMaterialProducDescInfo : IdioSoft.Site.ClassLibrary.ICHttpHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            string ServiceProvider = context.Server.UrlDecode(context.funString_RequestFormValue("ServiceProvider"));
            string MaterialProductName = context.Server.UrlDecode(context.funString_RequestFormValue("MaterialProductName"));
            //string strSQL = @"select ProductDesc  from CallCenter_Basic_Product_Info where productname='" + MaterialProductName + "' and  ServiceProvider='" + ServiceProvider + "' group by ProductDesc";
            string strSQL = @"SELECT  ProductDesc FROM SEWC_Basic_MLFB_Info where productname='" + MaterialProductName + "' group by ProductDesc order by ProductDesc";
            DataSet ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            StringBuilder sbReturn = new StringBuilder();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sbReturn.Append("\"" + ds.Tables[0].Rows[i]["ProductDesc"].ToString() + "\",");
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