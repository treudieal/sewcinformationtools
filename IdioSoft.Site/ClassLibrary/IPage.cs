using IdioSoft.Business.Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdioSoft.Site.ClassLibrary
{
    public class IPage : System.Web.UI.Page
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
                if (Session["UserInfo"] != null)
                {
                    return (UserInfo)Session["UserInfo"];
                }
                else
                {
                    Session["UserInfo"] = new UserInfo();
                    return (UserInfo)Session["UserInfo"];
                }
            }
            set
            {
                Session["UserInfo"] = value;
            }
        }
        #endregion
    }
}