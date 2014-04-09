using IdioSoft.Business.Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;


namespace IdioSoft.Site.ClassLibrary
{
    public class ICHttpHandler : IHttpHandler, IRequiresSessionState
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
        public virtual void ProcessRequest(HttpContext context)
        {
            context.Response.Write("");
            context.Response.End();
        }

        public virtual bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}