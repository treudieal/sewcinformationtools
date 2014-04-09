using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IdioSoft.Site
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string strReturn=  IdioSoft.Common.Method.Function.funString_SendMailByWebMail("ad.csit.slc@siemens.com", "cn1ac071", "Itsupport@200705", "测试邮件", "david.siemens.de", "wl9981@163.com", "测试邮件", "", false, "", null);
            //Response.Write(strReturn);
            //MailSender ms = new MailSender();
            //ms.From = "ad.csit.slc@siemens.com";
            //ms.To = "wl9981@163.com";
            //ms.Subject = "Subject";
            //ms.Body = "body text";
            //ms.UserName = "cn1ac071"; // 怎么能告诉你呢
            //ms.Password = "Itsupport@200705"; // 怎么能告诉你呢
            //ms.Server = "david.siemens.com.cn";

            ////ms.Attachments.Add(new MailSender.AttachmentInfo(@"D:\test.txt"));

            //Console.WriteLine("mail sending...");
            //try
            //{
            //    ms.SendMail();
            //    Console.WriteLine("mail sended.");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
        }
    }
}