using IdioSoft.Business.Frames;
using IdioSoft.Site.ClassLibrary;
using IdioSoft.Site.DB.Views.SEWC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.Delivery
{
    /// <summary>
    /// Summary description for Default
    /// </summary>
    public class Default : ICHttpHandler
    {

        public  override void ProcessRequest(HttpContext context)
        {
 
            IVList vlst = new CVList(new View_SEWC_Delivery_Info(), context
, "uRequestID, RequestID,AppCompanyName,EnduserCompanyName,DeliveryCustomer,MLFB, SerialNo,ProductGroup,ProductDesc,SEWCNotificationNo,ServiceType,Warranty, CreateUser, CaseTime");
            string strReturn = vlst.getData();

            ClassLibrary.SQLInfo sql = new ClassLibrary.SQLInfo();
            sql.lst = vlst.SPList;
            sql.SPName = "SP_getGridPages";
            base.objUserInfo.UpdateExportSQLInfo(sql, ExportSQlInfoKey.SEWC_Delivery);

            context.Response.Clear();
            context.Response.Write(strReturn);
            context.Response.End();
        }

 
    }
}