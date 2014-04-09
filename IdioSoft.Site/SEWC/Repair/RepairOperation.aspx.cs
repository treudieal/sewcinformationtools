using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdioSoft.Site.ClassLibrary;
//
using System.Data;
using System.Text;
using IdioSoft.Site.DB.Views;
using IdioSoft.Business.Frames;
using IdioSoft.Site.DB.Views.SEWC;
using IdioSoft.Site.DB.Tables.Public;
using IdioSoft.Business.Method;
using IdioSoft.Site.DB.Tables.SEWC;

namespace IdioSoft.Site.SEWC.Repair
{
    public partial class RepairOperation : IPage
    {
        string OperID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            OperID = Request.funString_RequestFormValue("sID");


            cboWarranty.subComboBox_LoadItems(new CView(CallCenter_Basic_Warranty_Info.GetInstance()).getDatas(""), 0, new ListItem("", ""), new string[] { CallCenter_Basic_Warranty_Info.GetInstance().Warranty.Name });

            //cboWarranty.subComboBox_LoadItems("select Warranty from CallCenter_Basic_Warranty_Info", 0, new ListItem("", ""));

            cboServiceType.subComboBox_LoadItems(new CView(webInfo_Basic_ServiceRequest_ServiceType_Info.GetInstance()).getDatas(""), 0, new ListItem("", ""), new string[] { webInfo_Basic_ServiceRequest_ServiceType_Info.GetInstance().ServiceType.Name });


            //cboServiceType.subComboBox_LoadItems("select ServiceType from webInfo_Basic_ServiceRequest_ServiceType_Info", 0, new ListItem("", ""));

            cboRepairAction.subComboBox_LoadItems(new CView(SEWC_Basic_RepairAction_Info.GetInstance()).getDatas(""), 0, new ListItem("", ""), new string[] { SEWC_Basic_RepairAction_Info.GetInstance().RepairAction.Name });

            //cboRepairAction.subComboBox_LoadItems("select  RepairAction from SEWC_Basic_RepairAction_Info order by RepairAction", 0, new ListItem("", ""));

            cboRepairResult.subComboBox_LoadItems(new CView(SEWC_Basic_RepairResult_Info.GetInstance()).getDatas(""), 0, new ListItem("", ""), new string[] { SEWC_Basic_RepairResult_Info.GetInstance().RepairResult.Name });

            //cboRepairResult.subComboBox_LoadItems("select RepairResult from  SEWC_Basic_RepairResult_Info where IsDel=0", 0, new ListItem("", ""));

            cboWorkStationCode.subComboBox_LoadItems(new CView(SEWC_Basic_WorkStationCode_Info.GetInstance()).getDatas(""), 0, new ListItem("", ""), new string[] { SEWC_Basic_WorkStationCode_Info.GetInstance().StationCode.Name });
            //cboWorkStationCode.subComboBox_LoadItems("SELECT StationCode FROM SEWC_Basic_WorkStationCode_Info where IsDel=0", 0, new ListItem("", ""));

            cboFailureCasedType.subComboBox_LoadItems(new CView(SEWC_Basic_FailureCodeCaused_Info.GetInstance()).getDatas(""), 0, new ListItem("", ""), new string[] { SEWC_Basic_FailureCodeCaused_Info.GetInstance().Code.Name });

            //cboRepairAction.subComboBox_LoadItems("SELECT RepairAction FROM SEWC_Basic_RepairAction_Info order by RepairAction", 0, new ListItem("", ""));
            //cboFailureCasedType.subComboBox_LoadItems("SELECT Code FROM SEWC_Basic_FailureCodeCaused_Info order by Code", 0, new ListItem("", ""));

            subDB_Detail();
            subDB_Item();
 

            if (!IsPostBack)
            {
                OperationType = Request.funString_RequestFormValue("OperationType").ToString().Trim().ToLower();
                if (OperationType == "detail")
                {
                    btnSave.Visible = false;
                    btnSubmit.Visible = false;
                    btnReport.Visible = true;

                    cboWorkStationCode.Attributes.Add("disabled", "disabled");
                    txtMLFB.Attributes.Add("disabled", "disabled");
                    txtSerialNo.Attributes.Add("disabled", "disabled");
                    txtQty.Attributes.Add("disabled", "disabled");
                    txtFuntinalStateoriginal.Attributes.Add("disabled", "disabled");
                    txtFuntinalStatelatest.Attributes.Add("disabled", "disabled");
                    txtFirmwareoriginal.Attributes.Add("disabled", "disabled");
                    txtFirmwarelatest.Attributes.Add("disabled", "disabled");
                    cboWarranty.Attributes.Add("disabled", "disabled");
                    dtpConfirmCompleteDate.Attributes.Add("disabled", "disabled");
                    cboServiceType.Attributes.Add("disabled", "disabled");
                    txtEngineer.Attributes.Add("disabled", "disabled");
                    dtpEndRepairDate.Attributes.Add("disabled", "disabled");
                    cboRepairResult.Attributes.Add("disabled", "disabled");
                    txtRemarks.Attributes.Add("disabled", "disabled");
                    cboFailureCasedType.Attributes.Add("disabled", "disabled");
                }
            }

        }

        public string OperationType
        {
            get
            {
                return ViewState["OperationType"].ToString();
            }
            set
            {
                ViewState["OperationType"] = value;
            }
        }

        public bool funBoolean_DetailExist()
        {
            string strSQL = "select count(*) from SEWC_Repair_Info where uRequestID = '" + OperID + "'";
            return objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0) > 0;
        }

      
        public void subDB_Detail()
        {
            View_SEWC_Repair_MDetail objViewDetail = new View_SEWC_Repair_MDetail();
            IDBUnit objView = new CView(objViewDetail);
            objView.getData("ID='" + OperID + "'");
            if (!objView.HasData)
            {
                return;
            }
            cboWorkStationCode.subComboBox_SelectItem(objViewDetail.WorkStationCode.FieldValue, Function.SelectAdapterType.Text);
            //cboWorkStationCode.subComboBox_SelectItemByText(objViewDetail.WorkStationCode.FieldValue);
            txtMLFB.Value = objViewDetail.MLFB.FieldValue;
            txtSerialNo.Value = objViewDetail.SerialNo.FieldValue;
            txtQty.Value = objViewDetail.Qty.FieldValue.ToString();
            txtFuntinalStateoriginal.Value = objViewDetail.FuntinalStateOriginal.FieldValue;
            txtFuntinalStatelatest.Value = objViewDetail.FuntinalStatelatest.FieldValue;
            txtFirmwareoriginal.Value = objViewDetail.FirmwareOriginal.FieldValue;
            txtFirmwarelatest.Value = objViewDetail.Firmwarelatest.FieldValue;
            cboWarranty.subComboBox_SelectItem(objViewDetail.Warranty.FieldValue, Function.SelectAdapterType.Text);
            //cboWarranty.subComboBox_SelectItemByText(objViewDetail.Warranty.FieldValue);
            dtpConfirmCompleteDate.Value = objViewDetail.ConfirmCompleteDate.FieldValue.funString_StringToDatetime();
            cboServiceType.subComboBox_SelectItem(objViewDetail.ServiceType.FieldValue, Function.SelectAdapterType.Text);

            //cboServiceType.subComboBox_SelectItemByText(objViewDetail.ServiceType.FieldValue);
            dtpEndRepairDate.Value = objViewDetail.EndRepairDate.FieldValue.funString_StringToDatetime();

            ViewState["ProductDesc"] = objViewDetail.ProductDesc.ToString().ToLower();
            if (ViewState["ProductDesc"].ToString() == "ipc")
            {
                cboFailureType.subComboBox_LoadItems(objDbSQLAccess.funDataset_SQLExecuteNonQuery("SELECT Type  FROM SEWC_Basic_FailureCode_Info where ProductDesc='IPC' and isdel=0 group by Type order by Type"), 0, new ListItem("", ""));
            }
            else
            {
                cboFailureType.subComboBox_LoadItems(objDbSQLAccess.funDataset_SQLExecuteNonQuery("SELECT Type  FROM SEWC_Basic_FailureCode_Info where ProductDesc<>'IPC' and isdel=0 group by Type order by Type"), 0, new ListItem("", ""));
            }

            cboFailureCasedType.subComboBox_SelectItem(objViewDetail.FailureCasedType.FieldValue, Function.SelectAdapterType.Text);

            txtEngineer.Value = objViewDetail.Engineer.FieldValue == "" ? objUserInfo.EnUserName : objViewDetail.Engineer.FieldValue;

            cboRepairResult.subComboBox_SelectItem(objViewDetail.RepairResult.FieldValue, Function.SelectAdapterType.Text);

            txtRemarks.Value = objViewDetail.Remarks.FieldValue;

            txtRequestID.Value = objViewDetail.RequestID.FieldValue;
            txtOrderType.Value = objViewDetail.OrderType.FieldValue;
            txtSEWCNoticificaionNo.Value = objViewDetail.SEWCNotificationNo.FieldValue;
            txtTroubleDesc.Value = objViewDetail.TroubleDesc.FieldValue;
            txtLaborCost.Value = objViewDetail.LaborCost.FieldValue.ToString();

            if (objViewDetail.RepairResult.FieldValue.ToLower() == "scrap" || objViewDetail.RepairResult.FieldValue.ToLower() == "reject")
            {
                trRejectFile.Attributes.Remove("style");
                tdAttachmentlist.InnerHtml = "<a href='../../Attachment/SEWC/" + objViewDetail.RejectFile.FieldValue + "' target='_blank'>" + objViewDetail.RejectFile.FieldValue + "</a>";
            }

            string strSQL = "";
            strSQL = "select count(*) from SEWC_Basic_MLFB_Labor_Info where MLFB='" + objViewDetail.MLFB.FieldValue + "'";
            if (objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0) > 0)
            {
                //txtLaborCost.Attributes.Add("disabled", "disabled");
            }          
        }

        private void subDB_Item()
        {

            string strItem = @"<table border='0' id='tblOther'  style='margin:0px;border-top:0px;'>
                    <tr>
                        <td class='TitleColor' style='width: 150px; border-top:0px;'>PCBA5ENo</td>
                        <td style='width: 200px;border-top:0px;'>
                            <input type='text' id='txtPCBA5ENo' name='txtPCBA5ENo' class='clstxtPCBA5ENo'  value='$PCBA5ENoValue$' />
                        </td>
                        <td class='TitleColor' style='border-top:0px; width: 150px'>ComponentLocation</td>
                        <td style='border-top:0px;'>
                            <input type='text' class='clsComponentLocation' id='txtComponentLocation'  value='$ComponentLocationValue$' />

                        </td>
                        <td rowspan='5' style='border-top:0px;' class='auto-style2'><a href='#' class='lnkaddother' data-icon='&#xe1f4;' title='AddNew'></a>
                            <br />
                            <a href='#' class='lnkdelother' data-icon='&#xe1f3;' title='Delete'  $isshowdelete$></a></td>
                    </tr>
                    <tr>
                        <td class='TitleColor'>RepairedComponentA5E</td>
                        <td>
                            <input type='text' id='txtRepairedComponentA5E' name='txtRepairedComponentA5E' class='clsRepairedComponentA5E'  value='$RepairedComponentA5EValue$' />
                        </td>
                        <td class='TitleColor'>Type</td>
                        <td>
                            $cboFailureTypeValue$
                        </td>
                    </tr>
                    <tr>
                        <td class='TitleColor'>Failure Kind</td>
                        <td>
                             $cboFailureKindValue$
                        </td>
                        <td class='TitleColor'>F-Code</td>
                        <td>
                             <input type='text' class='clstxtFcode'  id='txtFCode' value='$FCodeValue$'  />
                        </td>
                    </tr>
                    <tr>
                        <td class='TitleColor'>RepairAction</td>
                        <td>
                             $cboRepairActionValue$
                            </td>
                        <td class='TitleColor'></td>
                        <td>
                             
                        </td>
                    </tr>
                </table>";

            string strSQL = "";

            strSQL = "select count(*) from SEWC_RepairItem_Info where uRequestID = '" + OperID + "'";
            int intItemCount = 0;
            intItemCount = objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0);
            if (intItemCount > 0)
            {
                tdIDItems.Controls.Clear();
            }
            else
            {
                return;
            }
            StringBuilder sb = new StringBuilder(); ;
            strSQL = "SELECT  ID, uRequestID, PCBA5ENo, ComponentLocation, RepairedComponentA5E, Type, FailureKind, FCode, FailureCasedType, RepairAction, rowIndex FROM SEWC_RepairItem_Info where uRequestID = '" + OperID + "' order by rowIndex";
            DataSet ds = new DataSet();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string Item = strItem;
                    if (i == 0)
                    {
                        Item = Item.Replace("$isshowdelete$", " style='display:none;'");
                    }
                    else
                    {
                        Item = Item.Replace("$isshowdelete$", "");
                    }
                    Item = Item.Replace("$PCBA5ENoValue$", ds.Tables[0].Rows[i]["PCBA5ENo"].ToString());
                    Item = Item.Replace("$ComponentLocationValue$", ds.Tables[0].Rows[i]["ComponentLocation"].ToString());
                    Item = Item.Replace("$RepairedComponentA5EValue$", ds.Tables[0].Rows[i]["RepairedComponentA5E"].ToString());
                    Item = Item.Replace("$cboFailureTypeValue$", funString_ReturnItemType(ds.Tables[0].Rows[i]["Type"].ToString()));
                    Item = Item.Replace("$cboFailureKindValue$", funString_ReturnItemFailureKind(ds.Tables[0].Rows[i]["FailureKind"].ToString(), ds.Tables[0].Rows[i]["Type"].ToString()));
                    Item = Item.Replace("$FCodeValue$", ds.Tables[0].Rows[i]["FCode"].ToString());
                    //Item = Item.Replace("$cboFailureCasedTypeValue$", funString_ReturnItemFailureCasedType(ds.Tables[0].Rows[i]["FailureCasedType"].ToString()));
                    Item = Item.Replace("$cboRepairActionValue$", funString_ReturnSelect_RepairAction(ds.Tables[0].Rows[i]["RepairAction"].ToString()));
                    sb.Append(Item);
                }
            }
            tdIDItems.InnerHtml = sb.ToString();
        }

        private string funString_ReturnItemType(string Selected)
        {

            string strSQL = "";
            if (ViewState["ProductDesc"].ToString().IndexOf("ipc") >= 0)
            {
                strSQL = "SELECT  Type FROM SEWC_Basic_FailureCode_Info where productdesc='ipc' and isdel=0 group by Type order by Type";
            }
            else
            {
                strSQL = "SELECT  Type FROM SEWC_Basic_FailureCode_Info where  productdesc<>'ipc' and isdel=0 group by Type order by Type";
            }
            DataSet dsP = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            StringBuilder sb = new StringBuilder();
            sb.Append("<select class='clscboFailureType'>");
            sb.Append("<option value=''> </option>");
            for (int i = 0; i < dsP.Tables[0].Rows.Count; i++)
            {
                if (dsP.Tables[0].Rows[i]["Type"].ToString() == Selected)
                {
                    sb.Append("<option value='" + dsP.Tables[0].Rows[i]["Type"].ToString() + "' selected='selected'>" + dsP.Tables[0].Rows[i]["Type"].ToString() + "</option>");
                }
                else
                {
                    sb.Append("<option value='" + dsP.Tables[0].Rows[i]["Type"].ToString() + "'>" + dsP.Tables[0].Rows[i]["Type"].ToString() + "</option>");
                }
            }
            sb.Append("</select>");
            return sb.ToString();
        }

        private string funString_ReturnItemFailureKind(string Selected, string sType)
        {
            string strSQL = "";

            if (ViewState["ProductDesc"].ToString().IndexOf("ipc") >= 0)
            {
                strSQL = "SELECT  FailureKind FROM SEWC_Basic_FailureCode_Info where Type='" + sType + "' and productdesc='ipc' and isdel=0 group by FailureKind order by FailureKind";
            }
            else
            {
                strSQL = "SELECT  FailureKind FROM SEWC_Basic_FailureCode_Info where Type='" + sType + "' and productdesc<>'ipc'  and isdel=0 group by FailureKind order by FailureKind";
            }

            DataSet dsP = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            StringBuilder sb = new StringBuilder();
            sb.Append("<select class='clscboFailureKind'>");
            sb.Append("<option value=''> </option>");
            for (int i = 0; i < dsP.Tables[0].Rows.Count; i++)
            {
                if (dsP.Tables[0].Rows[i]["FailureKind"].ToString() == Selected)
                {
                    sb.Append("<option value='" + dsP.Tables[0].Rows[i]["FailureKind"].ToString() + "' selected='selected'>" + dsP.Tables[0].Rows[i]["FailureKind"].ToString() + "</option>");
                }
                else
                {
                    sb.Append("<option value='" + dsP.Tables[0].Rows[i]["FailureKind"].ToString() + "'>" + dsP.Tables[0].Rows[i]["FailureKind"].ToString() + "</option>");
                }
            }
            sb.Append("</select>");
            return sb.ToString();
        }

        private string funString_ReturnItemFailureCasedType(string Selected)
        {
            string strSQL = "SELECT   Code, Value FROM SEWC_Basic_FailureCodeCaused_Info order by Code";
            DataSet dsP = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            StringBuilder sb = new StringBuilder();
            sb.Append("<select class='clscboFailureCasedType'>");
            sb.Append("<option value=''> </option>");
            for (int i = 0; i < dsP.Tables[0].Rows.Count; i++)
            {
                if (dsP.Tables[0].Rows[i]["Code"].ToString() == Selected)
                {
                    sb.Append("<option value='" + dsP.Tables[0].Rows[i]["Code"].ToString() + "' selected='selected'>" + dsP.Tables[0].Rows[i]["Code"].ToString() + "</option>");
                }
                else
                {
                    sb.Append("<option value='" + dsP.Tables[0].Rows[i]["Code"].ToString() + "'>" + dsP.Tables[0].Rows[i]["Code"].ToString() + "</option>");
                }
            }
            sb.Append("</select>");
            return sb.ToString();
        }

        private string funString_ReturnSelect_RepairAction(string Selected)
        {
            string strSQL = "select distinct RepairAction from SEWC_Basic_RepairAction_Info order by RepairAction";
            DataSet dsP = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            StringBuilder sb = new StringBuilder();
            sb.Append("<select class='clscboRepairAction'>");
            sb.Append("<option value=''> </option>");
            for (int i = 0; i < dsP.Tables[0].Rows.Count; i++)
            {
                if (dsP.Tables[0].Rows[i]["RepairAction"].ToString() == Selected)
                {
                    sb.Append("<option value='" + dsP.Tables[0].Rows[i]["RepairAction"].ToString() + "' selected='selected'>" + dsP.Tables[0].Rows[i]["RepairAction"].ToString() + "</option>");
                }
                else
                {
                    sb.Append("<option value='" + dsP.Tables[0].Rows[i]["RepairAction"].ToString() + "'>" + dsP.Tables[0].Rows[i]["RepairAction"].ToString() + "</option>");
                }
            }
            sb.Append("</select>");
            return sb.ToString();
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