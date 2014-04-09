using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using IdioSoft.Business.Controls;
using System.Data;
using IdioSoft.Business.Method;

namespace IdioSoft.Business.Frames
{
    public class CVList:IVList
    {
        SQLDbHelper objSQLDbHelper = null;

        public CVList(Object objectView, HttpContext context, string showColumns)
        {
            this.objectView = objectView;
            this.context = context;
            this.showColumns = showColumns;
            objSQLDbHelper = new SQLDbHelper();
        }

        public CVList(Object objectView, HttpContext context, string showColumns, string ConfingKey)
        {
            this.objectView = objectView;
            this.context = context;
            this.showColumns = showColumns;
            objSQLDbHelper = new SQLDbHelper(ConfingKey);
        }

        public CVList()
        {
            objSQLDbHelper = new SQLDbHelper();
        }

        public CVList(string ConfingKey)
        {
            objSQLDbHelper = new SQLDbHelper(ConfingKey);
        }

        /// <summary>
        /// 需要显示的列
        /// </summary>
        public string showColumns
        {
            get;
            set;
        }
        /// <summary>
        /// 操作的DB对像
        /// </summary>
        public object objectView
        {
            get;
            set;
        }

        public HttpContext context
        {
            get;
            set;
        }

        /// <summary>
        /// 扩展搜索条件
        /// </summary>
        public string ExtendCondition
        {
            get;
            set;
        }

        /// <summary>
        /// 存储过程的搜索条件
        /// </summary>
        public List<object> SPList
        {
            get;
            set;
        }

        public string  getData()
        {
            JavaScriptSerializer jser = new JavaScriptSerializer();
            int CurrentPage = context.funString_RequestFormValue("page").funInt_StringToInt(0);
            int PageSize = context.funString_RequestFormValue("rows").funInt_StringToInt(0);
            string SortCol = "[" + context.funString_RequestFormValue("sidx") + "]";
            string Sorted = context.funString_RequestFormValue("sord");
            bool _search = context.funString_RequestFormValue("_search").funBoolean_StringToBoolean();
            string searchField = "";
            searchField = context.funString_RequestFormValue("searchField");
            string searchString = "";
            searchString = context.funString_RequestFormValue("searchString");

            JqGridData objJqGridData = new JqGridData();


            string filters = context.funString_RequestFormValue("filters");
            string filterReturn = "";

            if (filters != null && filters != "")
            {
                Dictionary<string, object> dict = jser.Deserialize<Dictionary<string, object>>(filters);
                filterReturn = objJqGridData.funString_FilterReturn(dict, objectView);
            }


            string strFilter = "";
            if (_search)
            {
                if (searchField != null && searchField != "")
                {
                    strFilter = searchField + "='" + searchString + "'";
                }
            }

            if (ExtendCondition != null)
            {
                strFilter = ExtendCondition;
            }

           
            SPList = new List<Object>();
            SPList.Add(objectView.GetType().Name);
            SPList.Add(SortCol);
            SPList.Add(showColumns);
            SPList.Add(CurrentPage);
            SPList.Add(PageSize);
            SPList.Add(strFilter);
            SPList.Add(Sorted);
            SPList.Add(filterReturn);
            SPList.Add(0);


            
            object TotalCount = 0;
            DataTable dt = objSQLDbHelper.funDataTable_SPExecuteNonQuery(SPList, this.SPName, "TotalCount", ref TotalCount);

            //LogHelper.GetInstance(HttpContext.Current.Server.MapPath("../../../Log/")).Save(this.SPName + "|" + SortCol + "|" + showColumns + "|" + CurrentPage.ToString() + "|");
            
            string JsonInfo = objJqGridData.getGridData(CurrentPage, PageSize, false, "", dt, (TotalCount.ToString()).funInt_StringToInt(0));
            return JsonInfo;
        }

        string _SPName = "SP_getGridPages";
        public string SPName
        {
            get
            {
                return _SPName;
            }
            set
            {
                _SPName = value;
            }
        }


    }
}
