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
using IdioSoft.Site.DB.Views.SEWC;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.Finish
{
    /// <summary>
    /// Summary description for Default
    /// </summary>
    public class Default : ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            IVList vlst = new CVList(new View_SEWC_Finish_Info(), context
, "uRequestID, RequestID,MLFB, SerialNo,Warranty, ServiceType, DeliveryDate,EndRepairDate");
            string strReturn = vlst.getData();

            ClassLibrary.SQLInfo sql = new ClassLibrary.SQLInfo();
            sql.lst = vlst.SPList;
            sql.SPName = "SP_getGridPages";
            base.objUserInfo.UpdateExportSQLInfo(sql, ExportSQlInfoKey.SEWC_Finish);

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