using IdioSoft.Business.Class;
using IdioSoft.Site.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;


namespace IdioSoft.Site.InterfaceLibrary.Util
{
    /// <summary>
    /// Summary description for ws_Util
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ws_Util : IWebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(EnableSession=true)]
        public string funString_ExportExcel(int SQLInfoKey)
        {
            HttpContext context = HttpContext.Current;
            if (SQLInfoKey == 0)
            {
                return "";
            }
            ExportExcelHelper exc = new ExportExcelHelper();
            List<object> lst = new List<object>();
            ClassLibrary.ExportSQlInfoKey eKey = (ClassLibrary.ExportSQlInfoKey)(SQLInfoKey);
            lst = ((ClassLibrary.SQLInfo)(objUserInfo.ExportSQLInfo[eKey])).lst;
            string spName = ((ClassLibrary.SQLInfo)(objUserInfo.ExportSQLInfo[eKey])).SPName;
            object TotalCount = 0;
            DataTable dt = objDbSQLAccess.funDataTable_SPExecuteNonQuery(lst, spName);
            string xfileName = exc.funString_SaveFile("",dt,ExportExcelHelper.ExcelType.Excel2007);
            return xfileName;
        }


    }
}
