using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdioSoft.Site.ClassLibrary;

using System.Data;
using IdioSoft.Business.Frames;
using IdioSoft.Site.DB.Views;
using IdioSoft.Site.DB.Views.SEWC;
using IdioSoft.Site.DB.Tables.SEWC;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.SEWC.GoodsReceipt
{
    public partial class GoodsReceiptOperation : IPage, IPForm
    {
        public string OperID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            OperID = Request.funString_RequestFormValue("sID");
            
            cboWarranty.subComboBox_LoadItems("select Warranty from CallCenter_Basic_Warranty_Info", 0, new ListItem("", ""));
            cboProductName.subComboBox_LoadItems("SELECT ProductName  FROM webInfo_Basic_serviceRequest_Duty_Info where serviceProvider = 'SEWC' group by ProductName", 0, new ListItem("", ""));


            //IdioSoft.Business.Method.Function.subComboBox_LoadItems(cboWarranty, CallCenter_Basic_Warranty_Info.GetInstance(), 0, new ListItem("", ""),
            //    CallCenter_Basic_Warranty_Info.GetInstance().Warranty.Name);

            cboServiceType.Items.Add(new ListItem("IHR", "IHR"));
            cboServiceType.Items.Add(new ListItem("EXCH", "EXCH"));

            subDB_Detail();

            if (!IsPostBack)
            {
                string OperationType = Request.funString_RequestFormValue("OperationType").ToString().Trim().ToLower();
                if (OperationType == "detail")
                {
                    trBtn.Attributes.Add("style", "display:none");
                    cboWarranty.Attributes.Add("disabled", "disabled");
                    dtpReceiveDefectiveDate.Attributes.Add("disabled", "disabled");
                    cboProductName.Attributes.Add("disabled", "disabled");
                    cboProductDesc.Attributes.Add("disabled", "disabled");
                    txtMLFB.Attributes.Add("disabled", "disabled");
                    txtSerialNo.Attributes.Add("disabled", "disabled");
                    txtQty.Attributes.Add("disabled", "disabled");
                    chkIsReject.Attributes.Add("disabled", "disabled");
                    txtSEWCNotificationNo.Attributes.Add("disabled", "disabled");
                    txtFuntinalStateoriginal.Attributes.Add("disabled", "disabled");
                    txtFirmwareoriginal.Attributes.Add("disabled", "disabled");
                    txtRejectReason.Attributes.Add("disabled", "disabled");
                }
            }

        }

        public void subDB_Detail()
        {
            //View_SEWC_GoodsReceipt_Detail objViewDetail = new View_SEWC_GoodsReceipt_Detail();
            IDBUnit objView = new CView(View_SEWC_GoodsReceipt_Detail.GetInstance());
            objView.getData("ID='" + OperID + "'");

            if (!objView.HasData)
            {
                return;
            }

            cboServiceType.subComboBox_SelectItemByText(View_SEWC_GoodsReceipt_Detail.GetInstance().ServiceType.FieldValue);
            txtSEWCNotificationNo.Value = View_SEWC_GoodsReceipt_Detail.GetInstance().SEWCNotificationNo.FieldValue;
            cboProductName.subComboBox_SelectItemByText(View_SEWC_GoodsReceipt_Detail.GetInstance().ProductName.FieldValue);

            string strSQL = "select ProductDesc  from CallCenter_Basic_Product_Info where productname='" + cboProductName.funComboBox_SelectedValue() + "' and  ServiceProvider='SEWC' group by ProductDesc";
            cboProductDesc.subComboBox_LoadItems(strSQL, 0, new ListItem("", "")); cboProductDesc.subComboBox_SelectItemByText(View_SEWC_GoodsReceipt_Detail.GetInstance().ProductDesc.FieldValue);
            txtMLFB.Value = View_SEWC_GoodsReceipt_Detail.GetInstance().MLFB.FieldValue;
            txtSerialNo.Value = View_SEWC_GoodsReceipt_Detail.GetInstance().SerialNo.FieldValue;
            txtQty.Value = View_SEWC_GoodsReceipt_Detail.GetInstance().Qty.FieldValue.ToString();
            cboWarranty.subComboBox_SelectItemByText(View_SEWC_GoodsReceipt_Detail.GetInstance().Warranty.FieldValue);
            dtpReceiveDefectiveDate.Value = View_SEWC_GoodsReceipt_Detail.GetInstance().ReceiveDefectiveDateT3.FieldValue.funString_StringToDatetime();

            chkIsReject.Checked = View_SEWC_GoodsReceipt_Detail.GetInstance().IsReject.FieldValue.Value;

            if (View_SEWC_GoodsReceipt_Detail.GetInstance().IsReject.FieldValue.Value)
            {
                trRejectReason.Style.Remove("display");
                trRejectFile.Style.Remove("display");
            }
            else
            {
                trRejectReason.Style["display"] = "none";
                trRejectFile.Style["display"] = "none";
            }
            txtRejectReason.Value = View_SEWC_GoodsReceipt_Detail.GetInstance().RejectReason.FieldValue;
            txtFuntinalStateoriginal.Value = View_SEWC_GoodsReceipt_Detail.GetInstance().FuntinalStateOriginal.FieldValue;
            txtFirmwareoriginal.Value = View_SEWC_GoodsReceipt_Detail.GetInstance().FirmwareOriginal.FieldValue;
            tdAttachmentlist.InnerHtml = "<a href='../../Attachment/SEWC/" + View_SEWC_GoodsReceipt_Detail.GetInstance().RejectFile.FieldValue + "' target='_blank'>" + View_SEWC_GoodsReceipt_Detail.GetInstance().RejectFile.FieldValue + "</a>";
        }

        public string PuRequestIDs
        {
            get
            {
                string sID = OperID;
                return sID;
            }
        }
    }
}