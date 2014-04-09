using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using IdioSoft.Site.ClassLibrary;

namespace IdioSoft.Site.Master.Csite
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        //private void subLoadMyInfo()
        //{
        //    ClassLibrary.UserInfo u = ((ClassLibrary.UserInfo)Session["UserInfo"]);
        //    txtEmail.Value = u.Email;
        //    txtMobile.Value = u.Mobile;

        //    string Password = IdioSoft.Common.Class.Encryption.Decrypt(u.Password);
        //    txtPassword.Value = Password;
        //    txtPassword1.Value = Password;

        //    txtPersonNo.Value = u.PersonNo;
        //    txtUserName.Value = u.Username;
        //    cboPageSize.subComboBox_SelectItemByValue(u.PageSize.ToString());

        //    this.txtPassword.Attributes.Add("Value", Password);
        //    this.txtPassword1.Attributes.Add("Value", Password);
        //    hidPassword.Value = Password;
        //}
    }
}