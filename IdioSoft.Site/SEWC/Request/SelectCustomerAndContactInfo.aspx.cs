using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdioSoft.Site.ClassLibrary;

using System.Data;
using System.Text;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.SEWC.Request
{
    public partial class SelectCustomerAndContactInfo : IPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
            cboProvince.subComboBox_LoadItems("select Province from WebInfo_Basic_Account_Province_Info",0,new ListItem("",""));
            cboCustomerType.subComboBox_LoadItems("select CustomerType from WebInfo_Basic_Account_CustomerType_Info",0,null);
            cboBranch.subComboBox_LoadItems("SELECT Branch FROM WebInfo_Basic_SPAS_IHR_BRANCH WHERE (IsDel = 0) order by orderno",0,null);
            cboBeiDeVIP.subComboBox_LoadItems("select BeiDeVIP from SSML_Basic_BeiDeVIP_Info", 0, new ListItem("", ""));
        }

        public string PuRequestIDs
        {
            get
            {
                //string sID = Request["uRequestID"].ToString();
                string sID = "";
                return sID;
            }
        }
        public string POperationType
        {
            get
            {
                string OperationType = Request["OperationType"].ToString();
                return OperationType;
            }
        }
    }
}