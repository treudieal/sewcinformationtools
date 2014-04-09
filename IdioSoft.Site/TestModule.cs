using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdioSoft.Site
{
    public class TestModule : IHttpModule
    {
        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.EndRequest += new EventHandler(context_EndRequest);
        }

        void context_EndRequest(object sender, EventArgs e)
        {

            HttpApplication ha = (HttpApplication)sender;

            ha.Response.Write("<!--这是每个页面都会动态生成的文字。--grayworm-->");

        }


    }
}