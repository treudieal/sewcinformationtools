using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdioSoft.Site.ClassLibrary;

using System.Data;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.IssueRepairOrder
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
            strSQL = @"SELECT   ID, uRequestID, MLFB, SerialNo, Qty, Warranty, IssueRepairOrderDate, Repairble, ReveiveBankReceipt, QuotationDate, IsGoodWill, GoodWillNo, 
                      CustomerConfirmDate, CancelReason, CancelDate, CreateDate, CreateUser, ModifyDate, ModifyUser, isSubmit, OrderType
FROM         SEWC_IssueRepairOrder_Info where uRequestID='" + uRequestID + "'";
            DataSet ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                string Warranty = ds.Tables[0].Rows[0]["Warranty"].ToString();
                if ((Warranty.ToLower() == "out warranty" || Warranty.ToLower() == "iw change to ow") && ds.Tables[0].Rows[0]["QuotationDate"].ToString() != "" && ds.Tables[0].Rows[0]["Repairble"].ToString() == "Y")
                {
                    strimg = "<img src='../../Style/images/yellow.png' />";
                }
                if (ds.Tables[0].Rows[0]["CustomerConfirmDate"].ToString() != "")
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