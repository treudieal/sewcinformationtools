using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdioSoft.Site
{
    public class Test:IHttpHandler
    {

        public bool IsReusable
        {
            get {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            string a = "";
        }
    }
}