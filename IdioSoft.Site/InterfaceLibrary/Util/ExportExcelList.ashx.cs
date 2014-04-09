using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdioSoft.Common.Method;
using IdioSoft.Site.ClassLibrary;
using System.Data;
using System.IO;
using IdioSoft.Common.Class;

namespace IdioSoft.Site.InterfaceLibrary.Util
{
    /// <summary>
    /// Summary description for ExportExcelList
    /// </summary>
    public class ExportExcelList : ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            int SQLInfoKey = context.funString_RequestFormValue("SQLInfoKey").funInt_StringToInt(0);
            if (SQLInfoKey == 0)
            {
                context.Response.Write("");
                context.Response.End();
                return;
            }
            ExportExcel exc = new ExportExcel();

            List<object> lst = new List<object>();

            ClassLibrary.ExportSQlInfoKey eKey = (ClassLibrary.ExportSQlInfoKey)(SQLInfoKey);

            lst = ((ClassLibrary.SQLInfo)(objUserInfo.ExportSQLInfo[eKey])).lst;
            string spName = ((ClassLibrary.SQLInfo)(objUserInfo.ExportSQLInfo[eKey])).SPName;

            object TotalCount = 0;
            DataTable dt = objDbSQLAccess.funDataTable_SPExecuteNonQuery(lst, spName);

            string xfileName = exc.ExcelExportXlsx(dt);

            context.Response.ContentType = "text/plain";
            context.Response.Write(xfileName);
            context.Response.End();
        }
 
    }
}