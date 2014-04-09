using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;
using System.Collections;
using IdioSoft.Business.Method;
using IdioSoft.Business.Frames;
using IdioSoft.Site.DB.Views;

namespace IdioSoft.Site.InterfaceLibrary.SEWC.Request
{
    /// <summary>
    /// Summary description for SelectCustomerAndContactInfo
    /// </summary>
    public class SelectCustomerAndContactInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            IVList vlst = new CVList(new View_Callcenter_AccountContact_List(), context
    , "ID, CompanyName,VIPID,CustomerID, SubOffice, Province, City, CustomerType, CompanyAddress, PostAddress, RegAddress, ConsignorAddress, TaxCode, AccountCode,  BankName, PostCode, FinanceTel, Country, Branch,CreateDate");
            string Contactname = context.funString_RequestFormValue("contactname");
            if (Contactname != "")
            {
                vlst.ExtendCondition = "Contactname='" + Contactname + "'";
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
            //objJqGridData.DicSearchFiledType.Add("CompanyName", "string");
            //objJqGridData.DicSearchFiledType.Add("VIPID", "string");
            //objJqGridData.DicSearchFiledType.Add("CustomerID", "string");
            //objJqGridData.DicSearchFiledType.Add("SubOffice", "string");
            //objJqGridData.DicSearchFiledType.Add("Province", "string");
            //objJqGridData.DicSearchFiledType.Add("City", "string");
            //objJqGridData.DicSearchFiledType.Add("CustomerType", "string");
            //objJqGridData.DicSearchFiledType.Add("CompanyAddress", "string");
            //objJqGridData.DicSearchFiledType.Add("PostAddress", "string");
            //objJqGridData.DicSearchFiledType.Add("RegAddress", "string");
            //objJqGridData.DicSearchFiledType.Add("ConsignorAddress", "string");
            //objJqGridData.DicSearchFiledType.Add("TaxCode", "string");
            //objJqGridData.DicSearchFiledType.Add("AccountCode", "string");
            //objJqGridData.DicSearchFiledType.Add("BankName", "string");
            //objJqGridData.DicSearchFiledType.Add("PostCode", "string");
            //objJqGridData.DicSearchFiledType.Add("FinanceTel", "string");
            //objJqGridData.DicSearchFiledType.Add("Country", "string");
            //objJqGridData.DicSearchFiledType.Add("Branch", "string");
            //objJqGridData.DicSearchFiledType.Add("CreateDate", "datetime");

            //string filters = context.funString_RequestFormValue("filters");
            //string filterReturn = "";

            //if (filters != null && filters != "")
            //{
            //    Dictionary<string, object> dict = jser.Deserialize<Dictionary<string, object>>(filters);

            //    filterReturn = objJqGridData.funString_FilterReturn(dict);
            //}

            //if (SortCol == "")
            //{
            //    SortCol = "CompanyName";
            //}


            //string strFilter = "";
            //if (_search)
            //{
            //    if (searchField != null && searchField != "")
            //    {
            //        strFilter = searchField + "='" + searchString + "'";
            //    }
            //}
            //string Contactname = context.funString_RequestFormValue("contactname");
            //if (Contactname != "")
            //{
            //    strFilter = "Contactname='" + Contactname+"'";
            //}
            //DbSQLAccess objDbSQLAccess = new DbSQLAccess();
            //List<Object> lst = new List<Object>();
            //lst.Add("View_Callcenter_AccountContact_List");
            //lst.Add(SortCol);
            //lst.Add("ID, CompanyName,VIPID,CustomerID, SubOffice, Province, City, CustomerType, CompanyAddress, PostAddress, RegAddress, ConsignorAddress, TaxCode, AccountCode,  BankName, PostCode, FinanceTel, Country, Branch,CreateDate");
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