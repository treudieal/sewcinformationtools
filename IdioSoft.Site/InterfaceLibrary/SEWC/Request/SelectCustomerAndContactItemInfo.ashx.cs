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
using IdioSoft.Site.DB.Tables;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.Request
{
    /// <summary>
    /// Summary description for SelectCustomerAndContactItemInfo
    /// </summary>
    public class SelectCustomerAndContactItemInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            IVList vlst = new CVList(new Webinfo_Account_Contact_info(), context
, "ID, ContactName, Tel, Mobile, Fax, Address, PostCode, Email");

            string AccounID = context.funString_RequestFormValue("id");
            if (AccounID != "")
            {
                vlst.ExtendCondition = "AccountID='" + context.funString_RequestFormValue("id") + "'";
            }
            string strReturn = vlst.getData();

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
            //objJqGridData.DicSearchFiledType.Add("ContactName", "string");
            //objJqGridData.DicSearchFiledType.Add("Tel", "string");
            //objJqGridData.DicSearchFiledType.Add("Mobile", "string");
            //objJqGridData.DicSearchFiledType.Add("Fax", "string");
            //objJqGridData.DicSearchFiledType.Add("Address", "string");
            //objJqGridData.DicSearchFiledType.Add("PostCode", "string");
            //objJqGridData.DicSearchFiledType.Add("Email", "string");

            //string filters = context.funString_RequestFormValue("filters");
            //string filterReturn = "";


            //string uRequestID = context.funString_RequestFormValue("id");
            //filterReturn = "AccountID='" + uRequestID + "'";

            //if (SortCol == "")
            //{
            //    SortCol = "ContactName";
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
            //lst.Add("Webinfo_Account_Contact_info");
            //lst.Add(SortCol);
            //lst.Add("ID, ContactName, Tel, Mobile, Fax, Address, PostCode, Email");
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