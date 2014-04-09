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
    /// Summary description for getTransferUserInfo
    /// </summary>
    public class getTransferUserInfo : IdioSoft.Site.ClassLibrary.ICHttpHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            string TransferID = context.Server.UrlDecode(context.funString_RequestFormValue("TransferID"));
            string ServiceProvider = context.Server.UrlDecode(context.funString_RequestFormValue("ServiceProvider"));
            string strSQL = "SELECT ID, EnUserName FROM webInfo_loginInfo WHERE (DutyLimited LIKE '%," + TransferID + ",%') and serviceProvider='" + ServiceProvider + "' and isdel = 0 and isDisplayRequest=1 order by SortID desc";
            DataSet ds = new DataSet();
            StringBuilder sbReturn = new StringBuilder();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    sbReturn.Append("\"" + ds.Tables[0].Rows[i]["ID"].ToString() + "$$$" + ds.Tables[0].Rows[i]["EnUserName"].ToString() + "\",");
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