using IdioSoft.Business.Frames;
using IdioSoft.Site.ClassLibrary;
using IdioSoft.Site.DB.Views.SEWC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.All
{
    /// <summary>
    /// Summary description for Default
    /// </summary>
    public class Default : ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
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