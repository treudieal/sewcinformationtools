using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdioSoft.Site.ClassLibrary;

using System.Data;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.Finish
{
    /// <summary>
    /// Summary description for DefaultUtil
    /// </summary>
    public class DefaultUtil : ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            string strimg = "<img src='../../Style/images/black.png' />";
            string strSQL = "";
            string uRequestID = context.funString_RequestFormValue("uRequestID");
            if (uRequestID == "")
            {
                context.Response.Write(strimg);
                context.Response.End();
            }
            strSQL = @"SELECT DeliveryDate FROM SEWC_Delivery_Info where uRequestID='" + uRequestID + "'";
            DataSet ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                string issueDNDate = ds.Tables[0].Rows[0]["DeliveryDate"].ToString();
                if (issueDNDate.ToLower() == "")
                {
                    strimg = "<img src='../../Style/images/black.png' />";
                }
                else
                {
                    strimg = "<img src='../../Style/images/green.png' />";
                }
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write(strimg);
            context.Response.End();
        }

    }
}