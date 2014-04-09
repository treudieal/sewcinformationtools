using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace IdioSoft.Site.SEWC.Request
{
    public partial class RequestPrintTemplate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                subLoadTemplate();
            }
        }

        #region "载入可以打印的模版"
        //这个地方以后需要改成对应不同合资厂不同服务类型载入不同的模板
        private void subLoadTemplate()
        {
            lstTemp.Items.Clear();
            string strDir;
            strDir = Server.MapPath("../../template/servicerequest/");
            ListItem item;
            DirectoryInfo docDir = new DirectoryInfo(strDir);
            foreach (FileInfo doc in docDir.GetFiles())
            {
                if (doc.Extension.ToString().ToLower() == ".xml")
                {
                    item = new ListItem();
                    item.Text = doc.Name;
                    item.Value = doc.FullName;
                    lstTemp.Items.Add(item);
                }
            }
        }
        #endregion

        public string PuRequestIDs
        {
            get
            {
                string sID = Request["uRequestID"].ToString();
                return sID;
            }
        }
    }
}