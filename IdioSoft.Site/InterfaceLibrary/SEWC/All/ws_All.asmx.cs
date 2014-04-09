using IdioSoft.Business.Frames;
using IdioSoft.Site.ClassLibrary;
using IdioSoft.Site.DB.Views.SEWC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.All
{
    /// <summary>
    /// Summary description for ws_All
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
   [System.Web.Script.Services.ScriptService]
    public class ws_All : IWebService
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
            IVList vlst = new CVList(new View_SEWC_All_Info(), context
, @"uRequestID, RequestID, MLFB, SerialNo, ProductGroup,ProductDesc, SEWCNotificationNo, ServiceType, Warranty, DeliveryCustomer, TrackingNo, CaseTime, ProductName, EndRepairDate, 
            DeliveryDate, AppCompanyName, EnduserCompanyName, [ReceiveDefectiveDateT3], NewMLFB, NewSerialNo, [WeightUnit], issueDNDate, WorkStationCode,
            [FuntinalStateoriginal], [FuntinalStatelatest], [Firmwareoriginal], [Firmwarelatest], ConfirmCompleteDate, Engineer, RepairResult, ReceiveCompany, Receiver, ReceiverTel,
            ReceiverAddress");
            string strReturn = vlst.getData();

            ClassLibrary.SQLInfo sql = new ClassLibrary.SQLInfo();
            sql.lst = vlst.SPList;
            sql.SPName = "SP_getGridPages";
            base.objUserInfo.UpdateExportSQLInfo(sql, ExportSQlInfoKey.SEWC_All);
            context.Response.Clear();
            context.Response.Write(strReturn);
            context.Response.End();
        }

      
    }
}
