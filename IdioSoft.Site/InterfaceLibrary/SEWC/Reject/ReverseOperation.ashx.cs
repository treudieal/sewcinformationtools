using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdioSoft.Site.ClassLibrary;

using System.Data;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Collections;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.Reject
{
    /// <summary>
    /// Summary description for ReverseOperation
    /// </summary>
    public class ReverseOperation : ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            string strError = "";
            string strSQL = "";
            string sID = "";
            sID = context.funString_RequestFormValue("sID");
            string[] lst = sID.Split(',');

            for (int i = 0; i < lst.Length; i++)
            {
                strSQL = "update SEWC_GoodsReceipt_Info set IsReject=0,isSubmit=0 where uRequestID = '" + lst[i].ToString() + "' and IsReject=1";
                strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
                strSQL = "update SEWC_IssueRepairOrder_Info set CancelDate=null,Repairble ='',isSubmit=0 where  uRequestID = '" + lst[i].ToString() + "' and Repairble='N'";
                strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
                strSQL = "update SEWC_Repair_Info set RepairResult='',isSubmit=0 where  uRequestID = '" + lst[i].ToString() + "' and RepairResult='Reject'";
                strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
                strSQL = "update webInfo_serviceRequest_Info set iscancel=0 where ID = '" + lst[i].ToString() + "'";
                strError = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            }
            if (strError == "")
            {
                context.Response.Write("0");//成功
            }
            else
            {
                context.Response.Write("1");//失败
            }
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