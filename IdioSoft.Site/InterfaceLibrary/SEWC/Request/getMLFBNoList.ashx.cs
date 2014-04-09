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
    /// Summary description for getMLFBNoList
    /// </summary>
    public class getMLFBNoList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string sType = context.funString_RequestFormValue("sType");
            StringBuilder sbReturn = new StringBuilder();
            IdioSoft.Business.Method.SQLDbHelper objDbSQLAccess = new SQLDbHelper();
            DataSet ds = null;
            string strSQL = "";
            switch (sType)
            {
                case "mlfb":
                    strSQL = @"SELECT  MLFB  FROM SEWC_Basic_MLFB_Info order by MLFB";
                    ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            sbReturn.Append(ds.Tables[0].Rows[i]["MLFB"].ToString() + "\n");
                        }
                    }
                    break;
                case "product":
                    string MLFB = context.funString_RequestFormValue("MLFB");
                    strSQL = @"SELECT    ProductDesc, ProductGroup, Plant FROM SEWC_Basic_MLFB_Info where MLFB='" + MLFB + "'";
                    ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        sbReturn.Append("{ProductGroup:\"" + Microsoft.JScript.GlobalObject.escape(ds.Tables[0].Rows[0]["ProductGroup"].ToString()) + "\",");
                        sbReturn.Append("ProductDesc:\"" + Microsoft.JScript.GlobalObject.escape(ds.Tables[0].Rows[0]["ProductDesc"].ToString()) + "\"}");
                    }
                    break;
                default:
                    break;
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(sbReturn.ToString());
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