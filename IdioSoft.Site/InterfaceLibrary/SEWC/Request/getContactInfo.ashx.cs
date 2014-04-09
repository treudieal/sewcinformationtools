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
    /// Summary description for getContactInfo
    /// </summary>
    public class getContactInfo : IdioSoft.Site.ClassLibrary.ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            string ContactID = context.Server.UrlDecode(context.funString_RequestFormValue("ContactID"));
            string strSQL = "select ContactName, Tel, Mobile, Fax, Address, PostCode, Email from Webinfo_Account_Contact_info where ID = '" + ContactID + "'";
            DataSet ds = new DataSet();
            StringBuilder sbReturn = new StringBuilder();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    sbReturn.Append("\"" + ds.Tables[0].Rows[i]["ContactName"].ToString() + "$$$" + ds.Tables[0].Rows[i]["Tel"].ToString() + "$$$" + ds.Tables[0].Rows[i]["Mobile"].ToString() + "$$$" + ds.Tables[0].Rows[i]["Fax"].ToString() + "$$$" + ds.Tables[0].Rows[i]["Address"].ToString() + "$$$" + ds.Tables[0].Rows[i]["PostCode"].ToString() + "$$$" + ds.Tables[0].Rows[i]["Email"].ToString() + "\",");
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}