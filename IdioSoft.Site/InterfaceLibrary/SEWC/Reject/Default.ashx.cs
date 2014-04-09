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

namespace IdioSoft.Site.InterfaceLibrary.SEWC.Reject
{
    /// <summary>
    /// Summary description for Default
    /// </summary>
    public class Default : ICHttpHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            IVList vlst = new CVList(new View_SEWC_Reject_Info(), context
                , "uRequestID, RequestID,SEWCNotificationNo,MLFB, SerialNo,Warranty, RejectReason, RejectFile");
            string strReturn = vlst.getData();

            ClassLibrary.SQLInfo sql = new ClassLibrary.SQLInfo();
            sql.lst = vlst.SPList;
            sql.SPName = "SP_getGridPages";
            base.objUserInfo.UpdateExportSQLInfo(sql, ExportSQlInfoKey.SEWC_Request);

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

            //objJqGridData.DicSearchFiledType.Add("uRequestID", "string");
            //objJqGridData.DicSearchFiledType.Add("RequestID", "string");
            //objJqGridData.DicSearchFiledType.Add("SEWCNotificationNo", "string");
            //objJqGridData.DicSearchFiledType.Add("MLFB", "string");
            //objJqGridData.DicSearchFiledType.Add("SerialNo", "string");
            //objJqGridData.DicSearchFiledType.Add("Warranty", "string");
            //objJqGridData.DicSearchFiledType.Add("RejectReason", "string");
            //objJqGridData.DicSearchFiledType.Add("RejectFile", "string");
            

            //string filters = context.funString_RequestFormValue("filters");
            //string filterReturn = "";

            //if (filters != null && filters != "")
            //{
            //    Dictionary<string, object> dict = jser.Deserialize<Dictionary<string, object>>(filters);

            //    filterReturn = objJqGridData.funString_FilterReturn(dict);
            //}

            //if (SortCol == "")
            //{
            //    SortCol = "RequestID";
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
            //lst.Add("View_SEWC_Reject_Info");
            //lst.Add(SortCol);
            //lst.Add("uRequestID, RequestID,SEWCNotificationNo,MLFB, SerialNo,Warranty, RejectReason, RejectFile");
            //lst.Add(CurrentPage);
            //lst.Add(PageSize);
            //lst.Add(strFilter);
            //lst.Add(Sorted);
            //lst.Add(filterReturn);
            //lst.Add(0);

            //string spName = "SP_SEWC_pages";

            //ClassLibrary.SQLInfo sql = new ClassLibrary.SQLInfo();
            //sql.lst = lst;
            //sql.SPName = spName;
            //base.objUserInfo.UpdateExportSQLInfo(sql, ExportSQlInfoKey.SEWC_Reject);

            //object TotalCount = 0;
            //DataTable dt = objDbSQLAccess.funDataTable_SPExecuteNonQuery(lst, spName, "TotalCount", ref TotalCount);

            //string strReturn = objJqGridData.getGridData(CurrentPage, PageSize, false, "", dt, (TotalCount.ToString()).funInt_StringToInt(0));
            //context.Response.Write(strReturn);
        }

    }
}