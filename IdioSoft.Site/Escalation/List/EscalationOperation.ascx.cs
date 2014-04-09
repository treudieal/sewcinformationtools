using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using IdioSoft.Business.Method;

namespace IdioSoft.Site.Escalation.List
{
    public partial class EscalationOperation : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            subOperationControlDisabled();
            if (!IsPostBack)
            {
                cboStatus.subComboBox_LoadItems("SELECT Status FROM Escalation_Basic_StatusInfo order by OrderNo", 0, new ListItem("", ""));
                cboType.subComboBox_LoadItems("SELECT sType FROM Escalation_Basic_TypeInfo order by OrderNo", 0, new ListItem("", ""));
                cboPriority.subComboBox_LoadItems("SELECT Priority FROM Escalation_Basic_PriorityInfo order by OrderNo", 0, new ListItem("", ""));
                cboOwner.subComboBox_LoadItems("SELECT Owner FROM Escalation_Basic_OwnerInfo order by OrderNo", 0, new ListItem("", ""));
            }
        }

        private void subOperationControlDisabled()
        {
            txtERNo.Attributes.Add("disabled", "disabled");
            txtSRNo.Attributes.Add("disabled", "disabled");
            txtAppCompany.Attributes.Add("disabled", "disabled");
            txtEndUser.Attributes.Add("disabled", "disabled");
            txtContact.Attributes.Add("disabled", "disabled");
            txtOC.Attributes.Add("disabled", "disabled");
            txtProductDesc.Attributes.Add("disabled", "disabled");
            txtMLFB.Attributes.Add("disabled", "disabled");
            txtSN.Attributes.Add("disabled", "disabled");
            txtAbstract.Attributes.Add("disabled", "disabled");
            txtRemark.Attributes.Add("disabled", "disabled");

            cboStatus.Attributes.Add("disabled", "disabled");
            cboType.Attributes.Add("disabled", "disabled");
            cboPriority.Attributes.Add("disabled", "disabled");
            cboOwner.Attributes.Add("disabled", "disabled");
            dtpCreatedDate.Attributes.Add("disabled", "disabled");
            txtEscalationBy.Attributes.Add("disabled", "disabled");
        }
    }
}