using IdioSoft.Business.Frames;
using IdioSoft.Site.ClassLibrary;
using IdioSoft.Site.DB.Views.SEWC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.IssueRepairOrder
{
    /// <summary>
    /// Summary description for ws_IssueRepairOrder
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ws_IssueRepairOrder : IWebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod(EnableSession=true)]
        public void subLoadGridList()
        {
            HttpContext context = HttpContext.Current;
            IVList vlst = new CVList(new View_SEWC_IssueRepairOrder_List(), context
    , "uRequestID,RequestID,MLFB, SerialNo,ProductGroup,ProductDesc,SEWCNotificationNo,ServiceType,Warranty,DeliveryCustomer,[ReceiveDefectiveDateT3],CustomerConfirmDate,IssueRepairOrderDate,ReveiveBankReceipt, CreateUser, CreateDate");
            string strReturn = vlst.getData();

            ClassLibrary.SQLInfo sql = new ClassLibrary.SQLInfo();
            sql.lst = vlst.SPList;
            sql.SPName = "SP_getGridPages";
            base.objUserInfo.UpdateExportSQLInfo(sql, ExportSQlInfoKey.SEWC_IssueRepairOrder);
            context.Response.Clear();
            context.Response.Write(strReturn);
            context.Response.End();
        }
        [WebMethod(EnableSession = true)]
        public string funString_StatusImage(string uRequestID)
        {
            string strimg = "<img src='../../Style/images/black.png' />";
            string strSQL = "";
            if (uRequestID == "")
            {
                return strimg;
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
            return strimg;
        }
    }
}
