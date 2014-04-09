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
    public partial class SEWCRequestOperation : IPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cboOrderType.subComboBox_LoadItems("SELECT OrderType FROM Webinfo_Basic_OrderType_info order by OrderType", 0, new ListItem("", ""));
            subDB_LoadServiceProvider();
            cboServiceType.Items.Add(new ListItem("", ""));
            cboServiceType.Items.Add(new ListItem("IHR", "IHR"));
            cboServiceType.Items.Add(new ListItem("EXCH", "EXCH"));
            cboArea.subComboBox_LoadItems("SELECT Area FROM webInfo_Basic_serviceRequest_Duty_Info where ServiceProvider='" + cboServiceProvider.funComboBox_SelectItemValue(Function.SelectAdapterType.Value) + "' group by area", 0, new ListItem("", ""));
            cboWarranty.subComboBox_LoadItems("SELECT  warranty  FROM   Callcenter_Basic_Warranty_Info", 0, new ListItem("", ""));
            cboAppCustomerType.subComboBox_LoadItems("select CustomerType from WebInfo_Basic_Account_CustomerType_Info", 0, new ListItem("", ""));
            cboEnduserCustomerType.subComboBox_LoadItems("select CustomerType from WebInfo_Basic_Account_CustomerType_Info", 0, new ListItem("", ""));
            cboCaseProperty.subComboBox_LoadItems("SELECT CaseProperty FROM webInfo_Basic_ServiceRequest_CaseProperty_Info order by sortID", 0, null);
            cboAppBranch.subComboBox_LoadItems("SELECT Branch FROM CallCenter_Basic_Branch_Info WHERE (IsDel = 0) order by orderno", 0, new ListItem("", ""));
            cboEnduserBranch.subComboBox_LoadItems("SELECT Branch FROM WebInfo_Basic_SPAS_IHR_BRANCH WHERE (IsDel = 0) order by orderno", 0, new ListItem("", ""));
            cboMaterialProductName.subComboBox_LoadItems("select ProductName from SEWC_Basic_MLFB_Info   group by ProductName order by ProductName", 0, new ListItem("", ""));
            cboTransferUser.subComboBox_LoadItems("select ID,EnUserName from webInfo_loginInfo where isDel=0 and ServiceProvider='SEWC' and isDisplayRequest=1", 0, new ListItem("", ""));
            if (!IsPostBack)
            {
                string OperationType = POperationType.ToString().Trim().ToLower();

                switch (OperationType)
                {
                    case "modify":
                        subDB_LoadModifyInfo();
                        subDB_LoadMaterial();
                        subControl_EnableALL(false);
                        btnSave.Disabled = true;
                        btnSubmit.Disabled = true;
                        btnTSave.Disabled = true;
                        btnTSubmit.Disabled = true;
                        btnDelete.Disabled = false;
                        btnModify.Disabled = false;
                        btnCancel.Disabled = false;
                        btnPrint.Disabled = false;
                        btnSelectAppCustomer.Disabled = true;
                        btnSelectEndCustomer.Disabled = true;
                        break;
                    case "detail":
                        subDB_LoadModifyInfo();
                        subDB_LoadMaterial();
                        subControl_EnableALL(false);
                        btnSave.Disabled = true;
                        btnSubmit.Disabled = true;
                        btnTSave.Disabled = true;
                        btnTSubmit.Disabled = true;
                        btnDelete.Disabled = true;
                        btnModify.Disabled = true;
                        btnCancel.Disabled = true;
                        btnPrint.Disabled = true;
                        btnSelectAppCustomer.Disabled = true;
                        btnSelectEndCustomer.Disabled = true;
                        btnSenderMessage.Disabled = true;
                        btnSendMail.Disabled = true;
                        break;
                    default:
                        btnDelete.Disabled = true;
                        btnModify.Disabled = true;
                        btnCancel.Disabled = true;
                        btnPrint.Disabled = true;
                        btnSenderMessage.Disabled = true;
                        btnSendMail.Disabled = true;
                        txtCreateDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        txtCreateUser.Value = objUserInfo.EnUserName;
                        dtpCaseTime.Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        break;
                }

            }
        }

        #region "载入基本信息"
        //载入serviceProvider
        private void subDB_LoadServiceProvider()
        {
            cboServiceProvider.Items.Clear();
            ListItem item;
            item = new ListItem();
            item.Text = "SEWC";
            item.Value = "SEWC";
            cboServiceProvider.Items.Add(item);
            //subDB_LoadTransferID();
        }


        //载入cboTransferUser
        public void subDB_LoadCboTransferUser()
        {
            cboTransferUser.Items.Clear();
            string strSQL = "";

            strSQL = "SELECT ID, EnUserName FROM webInfo_loginInfo WHERE (DutyLimited LIKE '%," + txtTransferID.Value + ",%') and serviceProvider='" + cboServiceProvider.funComboBox_SelectedValue() + "' and isdel = 0 and isDisplayRequest=1 order by SortID desc";
            DataSet ds = new DataSet();

            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            ListItem item;
            if (ds != null)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    item = new ListItem();
                    item.Text = ds.Tables[0].Rows[i]["EnUserName"].ToString();
                    item.Value = ds.Tables[0].Rows[i]["ID"].ToString();
                    cboTransferUser.Items.Add(item);
                }
            }
            if (cboTransferUser.Items.Count == 1)
            {
                cboTransferUser.SelectedIndex = 0;
            }
        }

        //public void subDB_LoadcboProductDesc(string productName)
        //{
        //    cboProductDesc.subComboBox_LoadItems("SELECT productDesc  FROM webInfo_Basic_ServiceRequest_Product_Info where productName='" + productName + "' and ServiceProviders  like '%" + cboServiceProvider.funComboBox_SelectedValue() + "%'", 0, new ListItem("", ""));
        //}
        #endregion

        #region "根据cboServiceType选项的内容来显示"
        public void subcboServiceTypeSelectedIndexChanged()
        {
            switch (cboServiceType.Items[cboServiceType.SelectedIndex].Value.Trim().ToLower())
            {
                case "fs":
                    //this.tdName.Visible = false;
                    //this.tdValue.Visible = false;
                    //this.trMC1.Attributes.Add("style", "display:block");
                    //this.trMC2.Attributes.Add("style", "display:block");
                    //this.trMC3.Attributes.Add("style", "display:block");
                    //this.trMC4.Attributes.Add("style", "display:block");
                    //this.trMC5.Attributes.Add("style", "display:block");
                    //this.trordertype.Attributes.Add("style", "display:block");
                    break;
                case "ihr":
                    //this.tdName.Attributes.Add("style", "display:block");
                    //this.tdValue.Attributes.Add("style", "display:block");
                    //this.trMC1.Attributes.Add("style", "display:block");
                    //this.trMC2.Attributes.Add("style", "display:block");
                    //this.trMC3.Attributes.Add("style", "display:block");
                    //this.trMC4.Attributes.Add("style", "display:block");
                    //this.trMC5.Attributes.Add("style", "display:block");
                    //this.trordertype.Attributes.Add("style", "display:none");
                    break;
                case "exch":
                    //this.tdName.Attributes.Add("style", "display:block");
                    //this.tdValue.Attributes.Add("style", "display:block");
                    //this.trMC1.Attributes.Add("style", "display:block");
                    //this.trMC2.Attributes.Add("style", "display:block");
                    //this.trMC3.Attributes.Add("style", "display:block");
                    //this.trMC4.Attributes.Add("style", "display:block");
                    //this.trMC5.Attributes.Add("style", "display:block");
                    //this.trordertype.Attributes.Add("style", "display:none");
                    break;
            }
        }
        #endregion

        #region "点击记录，载入修改信息"
        public void subDB_LoadModifyInfo()
        {
            try
            {
                string strSQL = "";
                strSQL = @"SELECT     s.ID, s.NotificationNo, s.RequestID, s.MLFBNo, s.SerialNo, s.ServiceType, s.ProductName, s.ProductDesc, s.Area, s.ServiceProvider, s.CaseProperty, s.Sirot, s.TroubleDesc, s.AppCompanyName, 
                      s.AppSubOffice, s.AppCustomerID, s.AppProvince, s.AppCity, s.AppCustomerType, s.AppContactName, s.AppTel, s.AppMobile, s.AppFax, s.AppAddress, s.AppPostCode, s.AppEmail, 
                      s.EnduserCompanyName, s.EnduserSubOffice, s.EnduserCustomerID, s.EnduserProvince, s.EnduserCity, s.EnduserCustomerType, s.EnduserContactName, s.EnduserTel, s.EnduserMobile, 
                      s.EnduserFax, s.EnduserAddress, s.EnduserPostCode, s.EnduserEmail, s.CaseTime, s.Text, s.callagentComments, s.DutyID, s.TransferUser, s.isRepair, s.CreateDate, 
                      l1.EnUserName AS CreateUser, s.MachineManufacturer, s.TypeOfMachine, s.MachineSerialNo, s.ControllerType, s.DriverType, s.SoftwareVersion, s.RSVNO, s.OrderType, 
                      s.ExchExpendProjectName, s.ExchExpendProjectNO, s.ExchExpendSelectCompany, s.ExchExpendFSPostAddress, s.AppCountry, s.AppBranch, s.EnduserCountry, s.EnduserBranch, 
                      s.SPASIHR_RelatedService, s.SPASIHR_OriginalSO, s.SPASIHR_OriginalPO, s.SPASIHR_OriginalDN, s.SPASIHR_OccurrenceOftrouble, s.SPASIHR_ProjectNo, s.SPASIHR_Consignment, 
                      s.SSCLIHR_RelatedService, s.SSCLIHR_OriginalSO, s.SSCLIHR_OriginalPO, s.SSCLIHR_OriginalDN, s.SSCLIHR_OccurrenceOftrouble, s.SSCLIHR_ProjectNo, s.SSCLIHR_Consignment, 
                      s.ModifyDate, l2.EnUserName AS ModifyUser, s.isCancel, s.SFAEIHR_Warranty, s.Warranty, s.AppVIPID, s.AppAccountID, s.AppContactID, s.OriCase, s.IsRepeat, s.RequestDocument, 
                      s.EnduserVIPID, s.EnduserAccountID, s.EnduserContactID, s.AppIsGroupDamex, s.EnduserIsGroupDamex, s.ProcessingTechnology, s.RSCNo, s.LocalRSCNo, s.IfDown, 
                      s.FalconEscalateToSiemens, s.FalconESPWarranty, s.FalconESPEngineer, s.FalconOutOfStock, s.ESP, s.SFAEVIPID, s.DeliveryType, s.ReceiveCompany, s.Receiver, s.ReceiverTel, 
                      s.ReceiverAddress
                      FROM dbo.webInfo_ServiceRequest_Info AS s LEFT OUTER JOIN
                      dbo.webInfo_loginInfo AS l1 ON s.CreateUser = l1.ID LEFT OUTER JOIN
                      dbo.webInfo_loginInfo AS l2 ON s.ModifyUser = l2.ID where s.ID='" + PuRequestIDs + "'";

                DataSet ds = new DataSet();
                ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);

                int intTranUser = 0;
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    string RequestDocument = ds.Tables[0].Rows[0]["RequestDocument"].ToString();
                    string filename = "";
                    if (RequestDocument != "")
                    {
                        filename = RequestDocument.Substring(RequestDocument.LastIndexOf("/") + 1);
                    }
                    tdAttachmentlist.InnerHtml = "<a href='../../RequestDocument/" + RequestDocument + "' target='_blank'>" + filename + "</a>";

                    txtNotificationNo.Value = ds.Tables[0].Rows[0]["NotificationNo"].ToString();
                    this.txtMLFBNo.Value = "";
                    this.txtSerialNo.Value = "";
                    cboServiceType.subComboBox_SelectItemByValue(ds.Tables[0].Rows[0]["ServiceType"].ToString());
                    //cboProductName.subComboBox_SelectItemByValue(ds.Tables[0].Rows[0]["ProductName"].ToString());

                    //subDB_LoadcboProductDesc(ds.Tables[0].Rows[0]["ProductName"].ToString());
                    //cboProductDesc.subComboBox_SelectItemByValue(ds.Tables[0].Rows[0]["ProductDesc"].ToString());
                    cboServiceProvider.subComboBox_SelectItemByValue(ds.Tables[0].Rows[0]["ServiceProvider"].ToString());

                    subcboServiceTypeSelectedIndexChanged();

                    //subDB_LoadcboArea();
                    cboArea.subComboBox_SelectItemByValue(ds.Tables[0].Rows[0]["Area"].ToString());
                    cboCaseProperty.subComboBox_SelectItemByValue(ds.Tables[0].Rows[0]["CaseProperty"].ToString());
                    cboWarranty.subComboBox_SelectItemByValue(ds.Tables[0].Rows[0]["Warranty"].ToString());
                    txtSirot.Value = ds.Tables[0].Rows[0]["Sirot"].ToString();
                    txtTroubleDesc.Value = ds.Tables[0].Rows[0]["TroubleDesc"].ToString();
                    txtAppCompanyName.Value = ds.Tables[0].Rows[0]["AppCompanyName"].ToString();
                    txtAppSubOffice.Value = ds.Tables[0].Rows[0]["AppSubOffice"].ToString();
                    txtAppCustomerID.Value = ds.Tables[0].Rows[0]["AppCustomerID"].ToString();
                    txtAppProvince.Value = ds.Tables[0].Rows[0]["AppProvince"].ToString();
                    txtAppCity.Value = ds.Tables[0].Rows[0]["AppCity"].ToString();
                    cboAppCustomerType.subComboBox_SelectItemByValue(ds.Tables[0].Rows[0]["AppCustomerType"].ToString());
                    txtAppContactName.Value = ds.Tables[0].Rows[0]["AppContactName"].ToString();
                    txtAppTel.Value = ds.Tables[0].Rows[0]["AppTel"].ToString();
                    txtAppMobile.Value = ds.Tables[0].Rows[0]["AppMobile"].ToString();
                    txtAppFax.Value = ds.Tables[0].Rows[0]["AppFax"].ToString();
                    txtAppAddress.Value = ds.Tables[0].Rows[0]["AppAddress"].ToString();
                    txtAppPostCode.Value = ds.Tables[0].Rows[0]["AppPostCode"].ToString();
                    txtAppEmail.Value = ds.Tables[0].Rows[0]["AppEmail"].ToString();
                    txtAppCountry.Value = ds.Tables[0].Rows[0]["AppCountry"].ToString();
                    cboAppBranch.subComboBox_SelectItemByValue(ds.Tables[0].Rows[0]["AppBranch"].ToString());
                    txtEnduserCompanyName.Value = ds.Tables[0].Rows[0]["EnduserCompanyName"].ToString();
                    txtEnduserSubOffice.Value = ds.Tables[0].Rows[0]["EnduserSubOffice"].ToString();
                    txtEnduserCustomerID.Value = ds.Tables[0].Rows[0]["EnduserCustomerID"].ToString();
                    //载入cboEnduserProvince
                    txtEnduserProvince.Value = ds.Tables[0].Rows[0]["EnduserProvince"].ToString();
                    txtEnduserCity.Value = ds.Tables[0].Rows[0]["EnduserCity"].ToString();
                    //cboEnduserCustomerType
                    cboEnduserCustomerType.subComboBox_SelectItemByValue(ds.Tables[0].Rows[0]["EnduserCustomerType"].ToString());
                    txtEnduserContactName.Value = ds.Tables[0].Rows[0]["EnduserContactName"].ToString();
                    txtEnduserTel.Value = ds.Tables[0].Rows[0]["EnduserTel"].ToString();
                    txtEnduserMobile.Value = ds.Tables[0].Rows[0]["EnduserMobile"].ToString();
                    txtEnduserFax.Value = ds.Tables[0].Rows[0]["EnduserFax"].ToString();
                    txtEnduserAddress.Value = ds.Tables[0].Rows[0]["EnduserAddress"].ToString();
                    txtEnduserPostCode.Value = ds.Tables[0].Rows[0]["EnduserPostCode"].ToString();
                    txtEnduserEmail.Value = ds.Tables[0].Rows[0]["EnduserEmail"].ToString();
                    this.txtEnduserCountry.Value = ds.Tables[0].Rows[0]["EnduserCountry"].ToString();
                    cboEnduserBranch.subComboBox_SelectItemByValue(ds.Tables[0].Rows[0]["EnduserBranch"].ToString());
                    if (ds.Tables[0].Rows[0].IsNull("CaseTime") == false)
                    {

                        dtpCaseTime.Value = ((DateTime)ds.Tables[0].Rows[0]["CaseTime"]).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    txtText.Value = ds.Tables[0].Rows[0]["Text"].ToString();
                    txtCallagentComments.Value = ds.Tables[0].Rows[0]["callagentComments"].ToString();
                    txtTransferID.Value = ds.Tables[0].Rows[0]["DutyID"].ToString();
                    //subDB_LoadCboTransferUser();
                    intTranUser = ds.Tables[0].Rows[0]["TransferUser"].ToString().funInt_StringToInt(0);
                    cboTransferUser.subComboBox_SelectItemByValue(intTranUser.ToString());
                    chkRepair.Checked = (Boolean)ds.Tables[0].Rows[0]["isRepair"];
                    chkisRepeat.Checked = (Boolean)ds.Tables[0].Rows[0]["isRepeat"];
                    txtOriCase.Value = ds.Tables[0].Rows[0]["OriCase"].ToString();
                    txtQuantity.Value = "";
                    txtCreateDate.Value = ((DateTime)ds.Tables[0].Rows[0]["CreateDate"]).ToString("yyyy-MM-dd HH:mm:ss");
                    txtCreateUser.Value = ds.Tables[0].Rows[0]["CreateUser"].ToString();
                    if (ds.Tables[0].Rows[0]["ModifyUser"].ToString().Trim() != "")
                    {
                        txtModifyDate.Value = ((DateTime)ds.Tables[0].Rows[0]["ModifyDate"]).ToString("yyyy-MM-dd HH:mm:ss");
                        txtModifyUser.Value = ds.Tables[0].Rows[0]["ModifyUser"].ToString();
                    }
                    else
                    {
                        txtModifyDate.Value = "";
                        txtModifyUser.Value = "";
                    }
                    if (ds.Tables[0].Rows[0]["isCancel"].ToString().ToLower() == "true")
                    {
                        btnCancel.Disabled = true;
                    }

                    txtAppVIPID.Value = ds.Tables[0].Rows[0]["AppVIPID"].ToString();
                    txtEnduserVIPID.Value = ds.Tables[0].Rows[0]["EnduserVIPID"].ToString();

                    string strAppDemax = "false";
                    strAppDemax = ds.Tables[0].Rows[0]["AppIsGroupDamex"].ToString();
                    string strEndDemax = "false";
                    strEndDemax = ds.Tables[0].Rows[0]["EnduserIsGroupDamex"].ToString();
                    txtAppSFAEVIPID.Value = ds.Tables[0].Rows[0]["SFAEVIPID"].ToString();

                    if (txtAppVIPID.Value.Trim() != "" && txtAppVIPID.Value.Substring(0, 2).ToLower() != "md")
                    {
                        this.lblAppStar.Visible = true;
                        if (txtAppSFAEVIPID.Value.Trim() == "")
                        {
                            txtAppCompanyName.Attributes.Add("style", "width: 525px;border:1px solid red;");
                            this.lblAppStar.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            txtAppCompanyName.Attributes.Add("style", "width: 525px;border:1px solid red;color:green;");
                            this.lblAppStar.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                    else
                    {
                        this.lblAppStar.Visible = false;
                        if (txtAppSFAEVIPID.Value.Trim() == "")
                        {
                            txtAppCompanyName.Attributes.Add("style", "width: 525px;border:1px solid #7F9DB9;");
                        }
                        else
                        {
                            txtAppCompanyName.Attributes.Add("style", "width: 525px;border:1px solid #7F9DB9;color:green;");
                        }
                    }

                    if (txtEnduserVIPID.Value.Trim() != "")
                    {
                        txtEnduserCompanyName.Attributes.Add("style", "width: 525px;border-left-color: red; border-bottom-color: red; border-top-style: solid; border-top-color: red; border-right-style: solid; border-left-style: solid; border-right-color: red; border-bottom-style: solid;");
                        this.lblEndStar.Visible = true;
                    }
                    else
                    {
                        this.lblEndStar.Visible = false;
                        txtEnduserCompanyName.Attributes.Add("style", "width: 525px;border-left-color: #7F9DB9; border-bottom-color: #7F9DB9; border-top-style: solid; border-top-color: #7F9DB9; border-right-style: solid; border-left-style: solid; border-right-color: #7F9DB9; border-bottom-style: solid;");
                    }

                    if (strAppDemax.ToString().Trim().ToLower() == "true")
                    {
                        this.cboAppIsGroupDamex.SelectedIndex = 1;
                        txtAppCompanyName.Attributes.Add("style", "width: 525px;border:1px solid yellow;");
                        this.ImgAPPDames.Visible = true;
                    }

                    if (strEndDemax.ToString().Trim().ToLower() == "true")
                    {
                        this.cboEndIsGroupDamex.SelectedIndex = 1;
                        txtEnduserCompanyName.Attributes.Add("style", "width: 525px;border-left-color: yellow; border-bottom-color: yellow; border-top-style: solid; border-top-color: yellow; border-right-style: solid; border-left-style: solid; border-right-color: yellow; border-bottom-style: solid;");
                        this.ImgEndDemax.Visible = true;
                    }
                    else
                    {
                        this.ImgEndDemax.Visible = false;
                        if (txtEnduserVIPID.Value.Trim() != "")
                        {
                            txtEnduserCompanyName.Attributes.Add("style", "width: 525px;border-left-color: red; border-bottom-color: red; border-top-style: solid; border-top-color: red; border-right-style: solid; border-left-style: solid; border-right-color: red; border-bottom-style: solid;");
                            this.lblEndStar.Visible = true;
                        }
                        else
                        {
                            this.lblEndStar.Visible = false;
                            txtEnduserCompanyName.Attributes.Add("style", "width: 525px;border-left-color: #7F9DB9; border-bottom-color: #7F9DB9; border-top-style: solid; border-top-color: #7F9DB9; border-right-style: solid; border-left-style: solid; border-right-color: #7F9DB9; border-bottom-style: solid;");
                        }
                    }

                    ViewState["AppAccountID"] = ds.Tables[0].Rows[0]["AppAccountID"].ToString();
                    ViewState["AppContactID"] = ds.Tables[0].Rows[0]["AppContactID"].ToString();
                    ViewState["EnduserVIPID"] = ds.Tables[0].Rows[0]["EnduserVIPID"].ToString();
                    ViewState["EnduserAccountID"] = ds.Tables[0].Rows[0]["EnduserAccountID"].ToString();
                    ViewState["EnduserContactID"] = ds.Tables[0].Rows[0]["EnduserContactID"].ToString();

                    txtMachineManufacturer.Value = ds.Tables[0].Rows[0]["MachineManufacturer"].ToString();
                    txtMachineSerialNo.Value = ds.Tables[0].Rows[0]["MachineSerialNo"].ToString();
                    txtRSVNo.Value = ds.Tables[0].Rows[0]["RSVNO"].ToString();
                    txtDriverType.Value = ds.Tables[0].Rows[0]["DriverType"].ToString();
                    txtControllerType.Value = ds.Tables[0].Rows[0]["ControllerType"].ToString();
                    txtTypeOfMachine.Value = ds.Tables[0].Rows[0]["TypeOfMachine"].ToString();
                    txtSoftwareVersion.Value = ds.Tables[0].Rows[0]["SoftwareVersion"].ToString();
                    this.txtProcessingTechnology.Value = ds.Tables[0].Rows[0]["ProcessingTechnology"].ToString();

                    txtRSCNo.Value = ds.Tables[0].Rows[0]["RSCNo"].ToString();
                    txtLocalRSCNo.Value = ds.Tables[0].Rows[0]["LocalRSCNo"].ToString();

                    //s.DeliveryType, s.ReceiveCompany, s.Receiver, s.ReceiverTel,s.ReceiverAddress
                    cboDeliveryType.subComboBox_SelectItemByValue(ds.Tables[0].Rows[0]["DeliveryType"].ToString());
                    txtReceiveCompany.Value = ds.Tables[0].Rows[0]["ReceiveCompany"].ToString();
                    txtReceiver.Value = ds.Tables[0].Rows[0]["Receiver"].ToString();
                    txtReceiverTel.Value = ds.Tables[0].Rows[0]["ReceiverTel"].ToString();
                    txtReceiverAddress.Value = ds.Tables[0].Rows[0]["ReceiverAddress"].ToString();

                    if (ds.Tables[0].Rows[0]["IfDown"].ToString().Trim().ToLower() == "true")
                    {
                        this.chkifdown.Checked = true;
                    }
                    else
                    {
                        this.chkifdown.Checked = false;
                    }


                    cboOrderType.subComboBox_SelectItemByValue(ds.Tables[0].Rows[0]["OrderType"].ToString());

                    if (ds.Tables[0].Rows[0]["OrderType"].ToString().ToLower() == "project expend")
                    {
                        //ExchExpendProjectName, ExchExpendProjectNO, ExchExpendSelectCompany,ExchExpendFSPostAddress
                        trSfaeExchProjectInfo.Visible = true;
                        txtProjectNameExchExpend.Value = ds.Tables[0].Rows[0]["ExchExpendProjectName"].ToString();
                        txtProjectNOExchExpend.Value = ds.Tables[0].Rows[0]["ExchExpendProjectNO"].ToString();
                        if (bool.Parse(ds.Tables[0].Rows[0]["ExchExpendSelectCompany"].ToString()))
                        {
                            chkAppExchExpend.Checked = true;
                            chkEndExchExpend.Checked = false;
                        }
                        else
                        {
                            chkEndExchExpend.Checked = false;
                            chkEndExchExpend.Checked = true;
                        }
                        txtFSPostAddressExchExpend.Value = ds.Tables[0].Rows[0]["ExchExpendFSPostAddress"].ToString();
                    }
                    else
                    {
                        trSfaeExchProjectInfo.Visible = false;
                        txtProjectNameExchExpend.Value = "";
                        txtProjectNOExchExpend.Value = "";
                        chkAppExchExpend.Checked = false;
                        txtFSPostAddressExchExpend.Value = "";
                        chkEndExchExpend.Checked = false;
                    }
                }
            }
            catch
            {

            }
            subControl_EnableALL(false);

            subDB_LoadModifyInfo_O();
        }
        #endregion

        private void subDB_LoadMaterial()
        {
            System.Web.UI.HtmlControls.HtmlTable tab;
            System.Web.UI.HtmlControls.HtmlTableRow row;
            System.Web.UI.HtmlControls.HtmlTableCell cell;
            StringBuilder sb = new StringBuilder();
            string strSQL = "";
            string sID = PuRequestIDs;

            strSQL = "select count(*) from webInfo_Servicerequest_Material_Info where uRequestID = '" + sID + "'";
            int intItemCount = 0;
            intItemCount = objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0);
            if (intItemCount > 0)
            {
                tblOther.Visible = false;
            }

            strSQL = "SELECT ID,MLFB, SerialNo, Quantity,CreateDate,MaterialProductName,MaterialProductDesc,MaterialFault FROM webInfo_Servicerequest_Material_Info where uRequestID = '" + PuRequestIDs + "' and ParentID is null order by CreateDate desc";
            DataSet ds = new DataSet();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    tab = new System.Web.UI.HtmlControls.HtmlTable();
                    //tab.Width = "100%";

                    #region "第一行"
                    row = new System.Web.UI.HtmlControls.HtmlTableRow();

                    cell = new System.Web.UI.HtmlControls.HtmlTableCell();
                    cell.InnerHtml = "MLFBNo";
                    cell.Width = "120px";
                    row.Cells.Add(cell);

                    cell = new System.Web.UI.HtmlControls.HtmlTableCell();
                    cell.Width = "225px";
                    cell.InnerHtml = "<input id='txtMLFBNo' runat='server' class='clstxtMLFBNo' maxlength='50' name='txtMLFBNo' disabled='disabled' type='text' value='" + ds.Tables[0].Rows[i]["MLFB"].ToString() + "' />";
                    row.Cells.Add(cell);


                    cell = new System.Web.UI.HtmlControls.HtmlTableCell();
                    cell.InnerHtml = "SerialNo";
                    cell.Width = "100px";
                    row.Cells.Add(cell);

                    cell = new System.Web.UI.HtmlControls.HtmlTableCell();
                    cell.Width = "200px";
                    cell.InnerHtml = "<input id='txtSerialNo' runat='server' class='clstxtSerialNo' maxlength='50' name='txtSerialNo' disabled='disabled' type='text' value='" + ds.Tables[0].Rows[i]["SerialNo"].ToString() + "' />";
                    row.Cells.Add(cell);

                    cell = new System.Web.UI.HtmlControls.HtmlTableCell();
                    //cell.InnerHtml = "<a href='#' class='lnkaddother'>AddNew</a><br/><a href='#' class='lnkdelother'>Delete</a>";
                    //cell.InnerHtml = "<span></span>";
                    cell.InnerHtml = "";
                    //if (i <= 0)
                    //{
                    //    cell.InnerHtml = "<a href='#' class='lnkaddother' data-icon=&#xe1f4; title='AddNew'></a><br/><a href='#' class='lnkdelother' data-icon='&#xe1f3;' title='Delete'></a>";
                    //}
                    //else
                    //{
                    //    cell.InnerHtml = "<a href='#' class='lnkdelother' data-icon='&#xe1f3;' title='Delete'></a>";
                    //}

                    cell.RowSpan = 5;
                    row.Cells.Add(cell);

                    tab.Rows.Add(row);
                    #endregion
                    #region "第二行"
                    row = new System.Web.UI.HtmlControls.HtmlTableRow();

                    cell = new System.Web.UI.HtmlControls.HtmlTableCell();
                    cell.InnerHtml = "ProductName";
                    row.Cells.Add(cell);

                    cell = new System.Web.UI.HtmlControls.HtmlTableCell();
                    //cell.InnerHtml = "<select name='cboMaterialProductName' class='clscboMaterialProductName' id='cboMaterialProductName' runat='server'></select>";
                    cell.InnerHtml = funString_ReturnSelect_ProductName(ds.Tables[0].Rows[i]["MaterialProductName"].ToString());
                    row.Cells.Add(cell);

                    cell = new System.Web.UI.HtmlControls.HtmlTableCell();
                    cell.InnerHtml = "ProductDesc";
                    row.Cells.Add(cell);

                    cell = new System.Web.UI.HtmlControls.HtmlTableCell();
                    //cell.InnerHtml = "<select name='cboMaterialProducDesc' class='clscboMaterialProducDesc' id='cboMaterialProducDesc' runat='server'></select>";
                    cell.InnerHtml = funString_ReturnSelect_ProducDesc(ds.Tables[0].Rows[i]["MaterialProductDesc"].ToString(), ds.Tables[0].Rows[i]["MaterialProductName"].ToString());
                    row.Cells.Add(cell);

                    tab.Rows.Add(row);
                    #endregion
                    #region "第三行"
                    row = new System.Web.UI.HtmlControls.HtmlTableRow();

                    cell = new System.Web.UI.HtmlControls.HtmlTableCell();
                    cell.InnerHtml = "MaterialFault";
                    row.Cells.Add(cell);

                    cell = new System.Web.UI.HtmlControls.HtmlTableCell();
                    //cell.InnerHtml = "<select name='cboMaterialFault' class='clscboMaterialFault' id='cboMaterialFault' runat='server'></select>";
                    cell.InnerHtml = funString_ReturnSelect_ProductFault(ds.Tables[0].Rows[i]["MaterialFault"].ToString(), ds.Tables[0].Rows[i]["MaterialProductName"].ToString());
                    row.Cells.Add(cell);

                    cell = new System.Web.UI.HtmlControls.HtmlTableCell();
                    cell.InnerHtml = "Quantity";
                    row.Cells.Add(cell);

                    cell = new System.Web.UI.HtmlControls.HtmlTableCell();
                    cell.InnerHtml = "<input id='txtQuantity' runat='server' class='clstxtQuantity' maxlength='50' name='txtQuantity' disabled='disabled' onkeypress='return event.keyCode>=48&&event.keyCode<=57||event.keyCode==13' type='text' value='" + ds.Tables[0].Rows[i]["Quantity"].ToString() + "' />";
                    row.Cells.Add(cell);

                    tab.Rows.Add(row);
                    #endregion
                    #region "第四行"
                    row = new System.Web.UI.HtmlControls.HtmlTableRow();

                    cell = new System.Web.UI.HtmlControls.HtmlTableCell();
                    cell.InnerHtml = "Transfer User";

                    row.Cells.Add(cell);

                    strSQL = "select TransferUser from webInfo_ServiceRequest_Info where ID = '" + PuRequestIDs + "'";
                    string TransferUser = "0";
                    TransferUser = objDbSQLAccess.funString_SQLExecuteScalar(strSQL);

                    cell = new System.Web.UI.HtmlControls.HtmlTableCell();
                    cell.InnerHtml = funString_ReturnSelect_TransferUser(TransferUser);
                    row.Cells.Add(cell);

                    cell = new System.Web.UI.HtmlControls.HtmlTableCell();
                    cell.InnerHtml = "";
                    row.Cells.Add(cell);

                    cell = new System.Web.UI.HtmlControls.HtmlTableCell();
                    cell.InnerHtml = "";
                    row.Cells.Add(cell);

                    tab.Rows.Add(row);
                    #endregion

                    tdIDItems.Controls.Add(tab);
                }
            }
        }

        private string funString_ReturnSelect_ProductName(string Selected)
        {
            string strSQL = "select ProductName from CallCenter_Basic_Product_Info where ServiceProvider='SEWC' group by ProductName";
            DataSet dsP = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            StringBuilder sb = new StringBuilder();
            sb.Append("<select class='clscboMaterialProductName'  disabled='disabled' >");
            sb.Append("<option value=''> </option>");
            for (int i = 0; i < dsP.Tables[0].Rows.Count; i++)
            {
                if (dsP.Tables[0].Rows[i]["ProductName"].ToString() == Selected)
                {
                    sb.Append("<option value='" + dsP.Tables[0].Rows[i]["ProductName"].ToString() + "' selected='selected'>" + dsP.Tables[0].Rows[i]["ProductName"].ToString() + "</option>");
                }
                else
                {
                    sb.Append("<option value='" + dsP.Tables[0].Rows[i]["ProductName"].ToString() + "'>" + dsP.Tables[0].Rows[i]["ProductName"].ToString() + "</option>");
                }
            }
            return sb.ToString();
        }

        private string funString_ReturnSelect_ProducDesc(string Selected, string MaterialProductName)
        {
            string strSQL = "select ProductDesc  from CallCenter_Basic_Product_Info where productname='" + MaterialProductName + "' and  ServiceProvider='SEWC' group by ProductDesc";
            DataSet dsP = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            StringBuilder sb = new StringBuilder();
            sb.Append("<select class='clscboMaterialProducDesc'  disabled='disabled' >");
            sb.Append("<option value=''> </option>");
            for (int i = 0; i < dsP.Tables[0].Rows.Count; i++)
            {
                if (dsP.Tables[0].Rows[i]["ProductDesc"].ToString() == Selected)
                {
                    sb.Append("<option value='" + dsP.Tables[0].Rows[i]["ProductDesc"].ToString() + "' selected='selected'>" + dsP.Tables[0].Rows[i]["ProductDesc"].ToString() + "</option>");
                }
                else
                {
                    sb.Append("<option value='" + dsP.Tables[0].Rows[i]["ProductDesc"].ToString() + "'>" + dsP.Tables[0].Rows[i]["ProductDesc"].ToString() + "</option>");
                }
            }
            return sb.ToString();
        }

        private string funString_ReturnSelect_ProductFault(string Selected, string MaterialProductName)
        {
            string strSQL = "select ProductFault  from CallCenter_Basic_Product_Info where productname='" + MaterialProductName + "' and  ServiceProvider='SEWC' group by ProductFault";
            DataSet dsP = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            StringBuilder sb = new StringBuilder();
            sb.Append("<select class='clscboMaterialFault'  disabled='disabled' >");
            sb.Append("<option value=''> </option>");
            for (int i = 0; i < dsP.Tables[0].Rows.Count; i++)
            {
                if (dsP.Tables[0].Rows[i]["ProductFault"].ToString() == Selected)
                {
                    sb.Append("<option value='" + dsP.Tables[0].Rows[i]["ProductFault"].ToString() + "' selected='selected'>" + dsP.Tables[0].Rows[i]["ProductFault"].ToString() + "</option>");
                }
                else
                {
                    sb.Append("<option value='" + dsP.Tables[0].Rows[i]["ProductFault"].ToString() + "'>" + dsP.Tables[0].Rows[i]["ProductFault"].ToString() + "</option>");
                }
            }
            return sb.ToString();
        }

        private string funString_ReturnSelect_TransferUser(string Selected)
        {
            string strSQL = "select ID,EnUserName from webInfo_loginInfo where isDel=0 and ServiceProvider='SEWC' and isDisplayRequest=1";
            DataSet dsP = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            StringBuilder sb = new StringBuilder();
            sb.Append("<select class='clscboTransferUser'  disabled='disabled' >");
            sb.Append("<option value=''> </option>");
            for (int i = 0; i < dsP.Tables[0].Rows.Count; i++)
            {
                if (dsP.Tables[0].Rows[i]["ID"].ToString() == Selected)
                {
                    sb.Append("<option value='" + dsP.Tables[0].Rows[i]["ID"].ToString() + "' selected='selected'>" + dsP.Tables[0].Rows[i]["EnUserName"].ToString() + "</option>");
                }
                else
                {
                    sb.Append("<option value='" + dsP.Tables[0].Rows[i]["ID"].ToString() + "'>" + dsP.Tables[0].Rows[i]["EnUserName"].ToString() + "</option>");
                }
            }
            return sb.ToString();
        }

        #region "是否屏蔽控件"
        public void subControl_EnableALL(bool blen)
        {

            txtMLFBNo.Disabled = !blen;
            txtQuantity.Disabled = !blen;
            cboMaterialProductName.Disabled = !blen;
            cboMaterialProducDesc.Disabled = !blen;
            cboMaterialFault.Disabled = !blen;

            cboTransferUser.Disabled = !blen;
            //cboProductDesc.Disabled = !blen;
            cboCaseProperty.Disabled = !blen;
            cboWarranty.Disabled = !blen;
            cboAppCustomerType.Disabled = !blen;
            dtpCaseTime.Disabled = !blen;
            //btnSelectAppCustomer.Disabled = !blen;
            //btnSelectEndCustomer.Disabled = !blen;

            txtEnduserAddress.Disabled = !blen;
            txtEnduserCity.Disabled = !blen;
            txtEnduserCompanyName.Disabled = !blen;
            txtEnduserContactName.Disabled = !blen;
            txtEnduserCountry.Disabled = !blen;
            txtEnduserCustomerID.Disabled = !blen;
            txtEnduserEmail.Disabled = !blen;
            txtEnduserFax.Disabled = !blen;
            txtEnduserMobile.Disabled = !blen;
            txtEnduserPostCode.Disabled = !blen;
            txtEnduserProvince.Disabled = !blen;
            txtEnduserSubOffice.Disabled = !blen;
            txtEnduserTel.Disabled = !blen;
            cboEnduserBranch.Disabled = !blen;
            cboEnduserCustomerType.Disabled = !blen;

            txtTroubleDesc.Disabled = !blen;
            txtCallagentComments.Disabled = !blen;
            txtText.Disabled = !blen;
            txtNotificationNo.Disabled = !blen;
            txtSerialNo.Disabled = !blen;
            chkRepair.Disabled = !blen;
            chkisRepeat.Disabled = !blen;
            txtOriCase.Disabled = !blen;

            txtAppVIPID.Disabled = !blen;
            txtEnduserVIPID.Disabled = !blen;
            txtAppSFAEVIPID.Disabled = !blen;



            txtAppAddress.Disabled = !blen;
            txtAppCity.Disabled = !blen;
            txtAppCompanyName.Disabled = !blen;
            txtAppContactName.Disabled = !blen;
            txtAppCustomerID.Disabled = !blen;
            txtAppEmail.Disabled = !blen;
            txtAppFax.Disabled = !blen;
            txtAppMobile.Disabled = !blen;
            txtAppPostCode.Disabled = !blen;
            txtAppProvince.Disabled = !blen;
            txtAppSubOffice.Disabled = !blen;
            txtAppTel.Disabled = !blen;
            cboAppBranch.Disabled = !blen;
            cboServiceType.Disabled = !blen;
            cboArea.Disabled = !blen;
            //cboProductName.Disabled = !blen;
            cboAppCustomerType.Disabled = !blen;
            cboServiceProvider.Disabled = !blen;
            cboOrderType.Disabled = !blen;
            txtRSVNo.Disabled = !blen;

            txtMachineManufacturer.Disabled = !blen;
            txtTypeOfMachine.Disabled = !blen;
            txtMachineSerialNo.Disabled = !blen;
            txtControllerType.Disabled = !blen;
            txtDriverType.Disabled = !blen;
            txtSoftwareVersion.Disabled = !blen;
            txtProcessingTechnology.Disabled = !blen;
            chkifdown.Disabled = !blen;
            txtReceiveCompany.Disabled = !blen;
            txtReceiver.Disabled = !blen;
            txtReceiverTel.Disabled = !blen;
            txtReceiverAddress.Disabled = !blen;

            txtAppCountry.Disabled = !blen;
            txtRSCNo.Disabled = !blen;
            txtLocalRSCNo.Disabled = !blen;
        }


        #endregion

        public void subDB_LoadModifyInfo_O()
        {
            if (funBoolean_FindUE(txtAppCompanyName.Value))
            {
                lblAppUE.Visible = true;
            }
            else
            {
                lblAppUE.Visible = false;
            }
            if (funBoolean_FindUE(txtEnduserCompanyName.Value))
            {
                lblEndUE.Visible = true;
            }
            else
            {
                lblEndUE.Visible = false;
            }
        }

        public bool funBoolean_FindUE(string CompanyName)
        {
            string strSQL = "";
            strSQL = "SELECT  count(*) FROM CallCenter_Basic_UEInfo where CompanyName='" + CompanyName + "'";
            return objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0) > 0;
        }

        public string PuRequestIDs
        {
            get
            {
                string sID = Request["uRequestID"].ToString();
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