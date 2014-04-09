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
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;
using IdioSoft.Site.DB.Views.SEWC;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.SEWC.IssueRepairOrder
{
    public partial class IssueRepairOrderOperation : IPage
    {
        string OperID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            cboWarranty.subComboBox_LoadItems("select Warranty from CallCenter_Basic_Warranty_Info", 0, null);
            cboServiceType.Items.Add(new ListItem("", ""));
            cboServiceType.Items.Add(new ListItem("IHR", "IHR"));
            cboServiceType.Items.Add(new ListItem("EXCH", "EXCH"));
            cboOrderType.subComboBox_LoadItems("SELECT OrderType FROM SEWC_Basic_OrderType_Info", 0,new ListItem("",""));
            OperID = Request.funString_RequestFormValue("sID");

            subDB_Detail();

            //if (funBoolean_DetailExist())
            //{
            //    subDB_Detail();
            //}
            //else
            //{
            //    subDB_DefaultInfo();
            //}
            if (!IsPostBack)
            {
                string OperationType = Request.funString_RequestFormValue("OperationType").ToString().Trim().ToLower();
                if (OperationType == "detail")
                {
                    btnSave.Visible = false;
                    btnSubmit.Visible = false;

                    txtRequestID.Attributes.Add("disabled", "disabled");
                    cboServiceType.Attributes.Add("disabled", "disabled");
                    txtMLFB.Attributes.Add("disabled", "disabled");
                    txtSerialNo.Attributes.Add("disabled", "disabled");
                    txtQty.Attributes.Add("disabled", "disabled");
                    cboOrderType.Attributes.Add("disabled", "disabled");
                    cboWarranty.Attributes.Add("disabled", "disabled");
                    txtReceiveDefectiveDate.Attributes.Add("disabled", "disabled");
 
                    chkIsReveiveBankReceipt.Attributes.Add("disabled", "disabled");
                    chkIsGoodWill.Attributes.Add("disabled", "disabled");
                    txtGoodWillNo.Attributes.Add("disabled", "disabled");
                    cboRepairble.Attributes.Add("disabled", "disabled");
                    dtpCustomerConfirmDate.Attributes.Add("disabled", "disabled");
                    dtpIssueRepairOrderDate.Attributes.Add("disabled", "disabled");
                    dtpCancelDate.Attributes.Add("disabled", "disabled");
                    txtCancelReason.Attributes.Add("disabled", "disabled");
                    dtpQuotationDate.Attributes.Add("disabled", "disabled");
                }
            }
        }


        public bool funBoolean_DetailExist()
        {
            string strSQL = "select count(*) from SEWC_IssueRepairOrder_Info where uRequestID = '" + OperID + "'";
            return objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0) > 0;
        }

        public void subDB_Detail()
        {
            View_SEWC_IssueRepairOrder_MDetial objViewDetail = new View_SEWC_IssueRepairOrder_MDetial();
            IDBUnit objView = new CView(objViewDetail);
            objView.getData("ID = '" + OperID + "'");
            if (!objView.HasData)
            {
                return;
            }
            cboServiceType.subComboBox_SelectItemByValue(objViewDetail.ServiceType.FieldValue);
            string Warranty = objViewDetail.Warranty.FieldValue;
            cboWarranty.subComboBox_SelectItemByText(Warranty);
            chkIsReveiveBankReceipt.Checked = objViewDetail.ReveiveBankReceipt.FieldValue.Value;
            chkIsGoodWill.Checked = objViewDetail.IsGoodWill.FieldValue.Value;
            txtGoodWillNo.Value = objViewDetail.GoodWillNo.FieldValue;
            dtpCancelDate.Value = objViewDetail.CancelDate.FieldValue.funString_StringToDatetime();
            txtCancelReason.Value = objViewDetail.CancelReason.FieldValue;
            txtRequestID.Value = objViewDetail.RequestID.FieldValue;
            txtReceiveDefectiveDate.Value = objViewDetail.ReceiveDefectiveDateT3.FieldValue.funString_StringToDatetime();
            txtMLFB.Value = objViewDetail.MLFB.FieldValue;
            txtSerialNo.Value = objViewDetail.SerialNo.FieldValue;
            txtQty.Value = objViewDetail.Qty.FieldValue.ToString();

            dtpIssueRepairOrderDate.Value = objViewDetail.IssueRepairOrderDate.FieldValue.funString_StringToDatetime();
            dtpQuotationDate.Value = objViewDetail.QuotationDate.FieldValue.funString_StringToDatetime();
            dtpCustomerConfirmDate.Value = objViewDetail.CustomerConfirmDate.FieldValue.funString_StringToDatetime();
            cboOrderType.subComboBox_SelectItemByText(objViewDetail.OrderType.FieldValue);
            cboRepairble.subComboBox_SelectItemByValue(objViewDetail.Repairble.FieldValue);
            chkOneTotalPrice.Checked = objViewDetail.FixPrice.FieldValue.ToString().funBoolean_StringToBoolean();
            txtTotalPrice.Value = objViewDetail.TotalPrice.FieldValue.ToString();
            if (chkOneTotalPrice.Checked)
            {
                txtTotalPrice.Attributes.Remove("disabled");
            }
            //control show
            if (Warranty.ToLower() == "in warranty" || Warranty.ToLower() == "ow change to iw")
            {
              
                trRepairble.Attributes.Add("style", "display:none;");
            }
            else
            {
             
                trRepairble.Attributes.Remove("style");
            }

            if (Warranty.ToLower() == "out warranty" || Warranty.ToLower() == "iw ow change")
            {
                trDate.Attributes.Add("style", "display:none;");
                trGoodWill.Attributes.Add("style", "display:none;");
            }
            else
            {
                trDate.Attributes.Remove("style");
                trGoodWill.Attributes.Remove("style");
            }

            if (objViewDetail.Repairble.FieldValue == "Y")
            {
                trQuotation.Attributes.Remove("style");
                subQuotation_Table();
                trSendMail.Attributes.Remove("style");
            }

            if (objViewDetail.Repairble.FieldValue == "N")
            {
                trSendCancelMail.Attributes.Remove("style");
                trCancelDate.Attributes.Remove("style");
                trCancelReason.Attributes.Remove("style");
            }


//            string strSQL = "";
//            string sID = Request["sID"].ToString();
//            strSQL = @"SELECT    s.ServiceType, i.Warranty, i.ReveiveBankReceipt, i.IsGoodWill, i.GoodWillNo, i.CancelDate, i.CancelReason, i.MLFB, i.SerialNo, i.Qty,
//                       i.IssueRepairOrderDate, i.Repairble, i.QuotationDate, 
//                       i.CustomerConfirmDate, i.OrderType, g.[ReceiveDefectiveDateT3],s.RequestID
//                       FROM dbo.SEWC_IssueRepairOrder_Info AS i INNER JOIN
//                      dbo.webInfo_ServiceRequest_Info AS s ON i.uRequestID = s.ID INNER JOIN
//                      dbo.SEWC_GoodsReceipt_Info AS g ON i.uRequestID = g.uRequestID where s.ID = '" + OperID + "'";
//            DataSet ds = new DataSet();
//            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
//            if (ds != null && ds.Tables[0].Rows.Count > 0)
//            {
//                cboServiceType.subComboBox_SelectItemByValue(ds.Tables[0].Rows[0]["ServiceType"].ToString());
//                string Warranty = ds.Tables[0].Rows[0]["Warranty"].ToString();
//                cboWarranty.subComboBox_SelectItemByText(Warranty);
//                chkIsReveiveBankReceipt.Checked = ds.Tables[0].Rows[0]["ReveiveBankReceipt"].ToString().funBool_StringToBool();
//                chkIsGoodWill.Checked = ds.Tables[0].Rows[0]["IsGoodWill"].ToString().funBool_StringToBool();
//                txtGoodWillNo.Value = ds.Tables[0].Rows[0]["GoodWillNo"].ToString();
//                dtpCancelDate.Value = ds.Tables[0].Rows[0]["CancelDate"].ToString();
//                txtCancelReason.Value = ds.Tables[0].Rows[0]["CancelReason"].ToString();
//                txtRequestID.Value = ds.Tables[0].Rows[0]["RequestID"].ToString();
//                txtReceiveDefectiveDate.Value = ds.Tables[0].Rows[0]["ReceiveDefectiveDateT3"].ToString();
//                txtMLFB.Value = ds.Tables[0].Rows[0]["MLFB"].ToString();
//                txtSerialNo.Value = ds.Tables[0].Rows[0]["SerialNo"].ToString();
//                txtQty.Value = ds.Tables[0].Rows[0]["Qty"].ToString();
               
//                dtpIssueRepairOrderDate.Value = ds.Tables[0].Rows[0]["IssueRepairOrderDate"].ToString();
//                dtpQuotationDate.Value = ds.Tables[0].Rows[0]["QuotationDate"].ToString();
//                dtpCustomerConfirmDate.Value = ds.Tables[0].Rows[0]["CustomerConfirmDate"].ToString();
//                cboOrderType.subComboBox_SelectItemByText(ds.Tables[0].Rows[0]["OrderType"].ToString());
//                cboRepairble.subComboBox_SelectItemByValue(ds.Tables[0].Rows[0]["Repairble"].ToString());
//                //control show
//                if (Warranty.ToLower() == "in warranty" || Warranty.ToLower() == "ow change to iw")
//                {
//                    trDate.Attributes.Add("style", "display:none;");
//                    trGoodWill.Attributes.Add("style", "display:none;");
//                    trRepairble.Attributes.Add("style", "display:none;");
//                }
//                else
//                {
//                    trDate.Attributes.Remove("style");
//                    trGoodWill.Attributes.Remove("style");
//                    trRepairble.Attributes.Remove("style");
//                }

//                if (ds.Tables[0].Rows[0]["Repairble"].ToString() == "Y")
//                {
//                    trQuotation.Attributes.Remove("style");
//                    subQuotation_Table();
//                    trSendMail.Attributes.Remove("style");
//                }

//                if (ds.Tables[0].Rows[0]["Repairble"].ToString() == "N")
//                {
//                    trSendCancelMail.Attributes.Remove("style");
//                    trCancelDate.Attributes.Remove("style");
//                    trCancelReason.Attributes.Remove("style");
//                }
//            }

        }


        private void subQuotation_Table()
        {
            string MLFB = txtMLFB.Value;
            string uRequestID = OperID;

            string strSQL = "SELECT ProductType, MLFB, Component,orderno FROM SEWC_Basic_Quotation_Info where MLFB = '" + MLFB + "'  group by orderno,ProductType, MLFB, Component order by  orderno,ProductType, MLFB, Component";
            DataSet ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            HtmlTable objTable = new HtmlTable();
            objTable.Border = 1;
            objTable.Attributes.Add("bordercolordark", "#CCCCCC");
            objTable.Attributes.Add("bordercolorlight", "#FFFFFF");
            objTable.CellPadding = 2;
            objTable.CellSpacing = 0;
            HtmlTableRow objRow;
            HtmlTableCell objCell;
            HtmlInputText objText;
            CheckBox objChk;
            StringBuilder sb = new StringBuilder();

            string strProductType = "";
            string strMLFB = "";
            DataView dv;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                objRow = new HtmlTableRow();

                if (strProductType != ds.Tables[0].Rows[i]["ProductType"].ToString())
                {
                    objCell = new HtmlTableCell();
                    objCell.InnerText = ds.Tables[0].Rows[i]["ProductType"].ToString();
                    dv = new DataView(ds.Tables[0]);
                    dv.RowFilter = "ProductType='" + ds.Tables[0].Rows[i]["ProductType"].ToString() + "'";
                    objCell.RowSpan = dv.Count;
                    objRow.Cells.Add(objCell);
                }
                if (strMLFB != ds.Tables[0].Rows[i]["MLFB"].ToString())
                {
                    objCell = new HtmlTableCell();
                    objCell.InnerText = ds.Tables[0].Rows[i]["MLFB"].ToString();

                    dv = new DataView(ds.Tables[0]);
                    dv.RowFilter = "ProductType='" + ds.Tables[0].Rows[i]["ProductType"].ToString() + "' and MLFB='" + ds.Tables[0].Rows[i]["MLFB"].ToString() + "'";
                    objCell.RowSpan = dv.Count;

                    objRow.Cells.Add(objCell);
                }
                strMLFB = ds.Tables[0].Rows[i]["MLFB"].ToString();
                objCell = new HtmlTableCell();
                objCell.InnerText = ds.Tables[0].Rows[i]["Component"].ToString();
                objRow.Cells.Add(objCell);

                objCell = new HtmlTableCell();
                objText = new HtmlInputText();
                objText.ID = "txtValue" + i.ToString();
                //objText.Attributes.Add("Class", "clstxtValue");
                objText.Disabled = true;

                objText.Value = funString_Amount(ds.Tables[0].Rows[i]["ProductType"].ToString(), ds.Tables[0].Rows[i]["MLFB"].ToString(), ds.Tables[0].Rows[i]["Component"].ToString());

                objCell.Controls.Add(objText);
                objRow.Cells.Add(objCell);

                objCell = new HtmlTableCell();
                objChk = new CheckBox();
                objChk.ID = "chk" + i.ToString();
                objChk.Attributes.Add("ProductType", ds.Tables[0].Rows[i]["ProductType"].ToString());
                objChk.Attributes.Add("MLFB", ds.Tables[0].Rows[i]["MLFB"].ToString());
                objChk.Attributes.Add("Component", ds.Tables[0].Rows[i]["Component"].ToString());
 
                if (objText.Value != "")
                {
                    objChk.Checked = true;
                }
                else
                {
                    objChk.Checked = false;
                }
                objChk.CssClass = "clschkQuotation";

                objCell.Controls.Add(objChk);
                objRow.Cells.Add(objCell);

                strProductType = ds.Tables[0].Rows[i]["ProductType"].ToString();

                objTable.Rows.Add(objRow);
            }
            //StringWriter s = new StringWriter();
            //HtmlTextWriter d = new HtmlTextWriter(s);
            //objTable.RenderControl(d);
            tdQuotation.Controls.Add(objTable);
        }

        private string funString_Amount(string ProductType, string MLFB, string Component)
        {
            string strSQL = "";
            strSQL = "select Amount from SEWC_Quotation_Info where ProductType = '" + ProductType + "' and MLFB = '" + MLFB + "' and Component = '" + Component + "' and uRequestID='" + OperID + "'";
            string Amount = "";
            Amount = objDbSQLAccess.funString_SQLExecuteScalar(strSQL);
            return Amount;
        }

        public string PuRequestIDs
        {
            get
            {
                string sID = Request["sID"].ToString();
                return sID;
            }
        }
    }
}