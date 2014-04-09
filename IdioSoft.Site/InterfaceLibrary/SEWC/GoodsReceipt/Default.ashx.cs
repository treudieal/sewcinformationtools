using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;
using System.Collections;

using IdioSoft.Site.ClassLibrary;
using IdioSoft.Business.Frames;
using IdioSoft.Site.DB.Views;
using IdioSoft.Site.DB.Views.SEWC;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.GoodsReceipt
{
    /// <summary>
    /// Summary description for Default
    /// </summary>
    public class Default : ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            IVList vlst = new CVList(new View_SEWC_GoodsReceipt_List(), context
                , "uRequestID,RequestID,AppCompanyName,EnduserCompanyName,MLFB, SerialNo,ProductName,ProductDesc, SEWCNotificationNo, ServiceType, Warranty,[ReceiveDefectiveDateT3],IDays");
            string strReturn = vlst.getData();

            ClassLibrary.SQLInfo sql = new ClassLibrary.SQLInfo();
            sql.lst = vlst.SPList;
            sql.SPName = "SP_getGridPages";
            base.objUserInfo.UpdateExportSQLInfo(sql, ExportSQlInfoKey.SEWC_GoodsReceipt);

            context.Response.Write(strReturn);

        }
    }
}