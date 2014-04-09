using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;
using System.Collections;
using IdioSoft.Business.Frames;
using IdioSoft.Site.ClassLibrary;
using IdioSoft.Site.DB.Tables.User;
 

namespace IdioSoft.Site.InterfaceLibrary.User
{
    /// <summary>
    /// Summary description for User_derfault
    /// </summary>
    public class User_derfault : ICHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            IVList vlst = new CVList(new webinfo_loginInfo(), context
    , "ID, Email, EnUserName, CnUserName, Tel, Fax, Region, ServiceProvider");
            string strReturn = vlst.getData();

            ClassLibrary.SQLInfo sql = new ClassLibrary.SQLInfo();
            sql.lst = vlst.SPList;
            sql.SPName = "SP_getGridPages";
            base.objUserInfo.UpdateExportSQLInfo(sql, ExportSQlInfoKey.User);

            context.Response.Write(strReturn);

            //JavaScriptSerializer jser = new JavaScriptSerializer();

            //int CurrentPage = context.funString_RequestFormValue("page").funInt_StringToInt(0);
            //int PageSize = context.funString_RequestFormValue("rows").funInt_StringToInt(0);
            //string SortCol = context.funString_RequestFormValue("sidx");
            //string Sorted = context.funString_RequestFormValue("sord");
            //bool _search = context.funString_RequestFormValue("_search").funBool_StringToBool();
            //string searchField = "";
            //searchField = context.funString_RequestFormValue("searchField");
            //string searchString = "";
            //searchString = context.funString_RequestFormValue("searchString");

            //JqGridData objJqGridData = new JqGridData();

            //objJqGridData.DicSearchFiledType.Add("ID", "string");
            //objJqGridData.DicSearchFiledType.Add("Email", "string");
            //objJqGridData.DicSearchFiledType.Add("EnUserName", "string");
            //objJqGridData.DicSearchFiledType.Add("CnUserName", "string");
            //objJqGridData.DicSearchFiledType.Add("Tel", "string");
            //objJqGridData.DicSearchFiledType.Add("Fax", "string");
            //objJqGridData.DicSearchFiledType.Add("Region", "string");
            //objJqGridData.DicSearchFiledType.Add("ServiceProvider", "string");

            //string filters = context.funString_RequestFormValue("filters");
            //string filterReturn = "";

            //if (filters != null && filters != "")
            //{
            //    Dictionary<string, object> dict = jser.Deserialize<Dictionary<string, object>>(filters);

            //    filterReturn = objJqGridData.funString_FilterReturn(dict);
            //}

            //if (SortCol == "")
            //{
            //    SortCol = "Email";
            //}

            //string strFilter = "";
            //if (_search)
            //{
            //    if (searchField != null && searchField != "")
            //    {
            //        strFilter = searchField + "='" + searchString + "'";
            //    }
            //}
            //DbSQLAccess objDbSQLAccess = new DbSQLAccess();
            //List<Object> lst = new List<Object>();
            //lst.Add("webinfo_loginInfo");
            //lst.Add(SortCol);
            //lst.Add("ID, Email, EnUserName, CnUserName, Tel, Fax, Region, ServiceProvider");
            //lst.Add(CurrentPage);
            //lst.Add(PageSize);
            //lst.Add(strFilter);
            //lst.Add(Sorted);
            //lst.Add(filterReturn);
            //lst.Add(0);

            //string spName = "SP_SEWC_pages";
            //object TotalCount = 0;
            //DataTable dt = objDbSQLAccess.funDataTable_SPExecuteNonQuery(lst, spName, "TotalCount", ref TotalCount);

            //string strReturn = objJqGridData.getGridData(CurrentPage, PageSize, false, "", dt, (TotalCount.ToString()).funInt_StringToInt(0));
            //context.Response.Write(strReturn);
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