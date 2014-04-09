using IdioSoft.Business.Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdioSoft.Site.ClassLibrary
{
    [System.Web.Script.Services.ScriptService]
    public class IWebService : System.Web.Services.WebService
    {
        public IdioSoft.Business.Method.SQLDbHelper objDbSQLAccess = new SQLDbHelper();
        #region "属性"
        /// <summary>
        /// 用户信息
        /// </summary>
        public UserInfo objUserInfo
        {
            get
            {
                if (HttpContext.Current.Session["UserInfo"] != null)
                {
                    return (UserInfo)HttpContext.Current.Session["UserInfo"];
                }
                else
                {
                    HttpContext.Current.Session["UserInfo"] = new UserInfo();
                    return (UserInfo)HttpContext.Current.Session["UserInfo"];
                }
            }
            set
            {
                HttpContext.Current.Session["UserInfo"] = value;
            }
        }
        #endregion
    }
}