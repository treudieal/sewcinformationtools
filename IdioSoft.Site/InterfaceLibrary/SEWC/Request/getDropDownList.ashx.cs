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
    /// Summary description for getDropDownList
    /// </summary>
    public class getDropDownList : IdioSoft.Site.ClassLibrary.ICHttpHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            //string SelectID = context.Server.UrlDecode(context.funString_RequestFormValue("SelectID"));
            string SelectName = context.Server.UrlDecode(context.funString_RequestFormValue("sType")).ToLower();


            string strSQL = "";
            switch (SelectName)
            {
                case "productname":
                    strSQL = "SELECT ProductName  FROM webInfo_Basic_serviceRequest_Duty_Info where serviceProvider = 'SEWC' group by ProductName";
                    break;
                case "productdesc":
                    strSQL = "SELECT productDesc  FROM webInfo_Basic_ServiceRequest_Product_Info where ServiceProviders = 'SEWC' group by productDesc";
                    break;
                case "servicetype":
                    strSQL = "SELECT serviceType FROM webInfo_Basic_serviceRequest_Duty_Info where ServiceProvider = 'SEWC'  group by serviceType";
                    break;
                case "warranty":
                    strSQL="SELECT  warranty  FROM   Callcenter_Basic_Warranty_Info";
                    break;
                default:
                    break;
            }
            DataSet ds = new DataSet();
            IdioSoft.Business.Method.SQLDbHelper objDbSQLAccess = new SQLDbHelper();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<select>");
            sb.AppendLine("<option value=''>All</option>");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sb.AppendLine("<option value='" + ds.Tables[0].Rows[i][0].ToString() + "'>" + ds.Tables[0].Rows[i][0].ToString() + "</option>");
                }
              
            }
            sb.AppendLine("</select>");
            context.Response.Write(sb.ToString());
            context.Response.End();

        }
    }
}