using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Reflection;
using System.ComponentModel;
using System.Data;

using IdioSoft.Business.Method;

namespace IdioSoft.Site.ClassLibrary.Control
{
    public class ClassRequest : System.Web.UI.Page
    {
        public IdioSoft.Business.Method.SQLDbHelper objDbSQLAccess = new SQLDbHelper();
        
        public IdioSoft.Site.ClassLibrary.UserInfo objLoginUserInfo = new UserInfo();
        
        
        string strFrom = "";
        string strAccountID = "";
        string strContactID = "";

        #region"取得所有控件名字"
        HtmlInputButton btn_TSave;
        HtmlInputButton btn_TSubmit;
        HtmlInputButton btn_Modify;
        HtmlInputButton btn_Delete;
        HtmlInputButton btn_Cancel;
        HtmlInputButton btn_Print;
        HtmlInputButton btn_Reverse;
        //CallCenter特有的
        HtmlInputButton btnSenderMessage;

        HtmlInputText txtNotificationNo;
        DropDownList cboServiceProvider;
        DropDownList cboServiceType;
        DropDownList cboArea;
        DropDownList cboProductName;
        HtmlSelect cboProductDesc;
        HtmlSelect cboTransferUser;
        DropDownList cboCaseProperty;
        HtmlInputText txtSirot;
        HtmlInputText txtTransferID;
        HtmlTextArea txtTroubleDesc;
        HtmlInputCheckBox chkRepair;

        //Other Request特有的
        DropDownList cboWarranty;
        DropDownList cboOrderType;
        HtmlInputText txtRSV_No;
        HtmlInputText txtProjectNO_ExchExpend;
        HtmlInputText txtProjectName_ExchExpend;
        HtmlInputCheckBox chkApp_ExchExpend;
        HtmlInputCheckBox chkEnd_ExchExpend;
        Label Label1;
        Label Label2;
        HtmlInputText txtFSPostAddress_ExchExpend;

        //SMDT Request特有的
        HtmlInputCheckBox chkAssembly;
        HtmlInputCheckBox chkisPackage;
        HtmlSelect cboPaintingJudge;

        HtmlInputButton btn_AddNewMainMaterial;
        HtmlInputButton btn_ModifyMaterial;
        HtmlInputButton btn_DeleteMaterial;

        //Other Request特有的
        HtmlInputButton btn_AddNewSubMaterial;

        //Call Center特有的
        HtmlInputButton btn_ClearAllMaterial;

        TextBox txtmlfbNo;
        HtmlInputText txtSerialNo;
        HtmlInputText txtQuantity;

        //Call Center特有的
        DropDownList cboMaterialProductName;
        DropDownList cboMaterialProducDesc;
        DropDownList cboMaterialFault;

        //SMDT Request特有的
        DropDownList cboMainFault;
        HtmlSelect cboSubFault;
        HtmlTextArea txtMaterialFaultDesc;

        HtmlInputButton btnSelectAppCustomer;
        HtmlInputText txtAppCompanyName;
        Label lblAppStar;
        Image ImgAPPDames;
        HtmlInputText txtAppCustomerID;
        HtmlInputText txtAppProvince;
        HtmlInputText txtAppCity;
        DropDownList cboAppCustomerType;
        HtmlInputText txtAppContactName;
        HtmlInputText txtAppTel;
        HtmlInputText txtAppFax;
        HtmlInputText txtAppMobile;
        HtmlInputText txtAppAddress;
        HtmlInputText txtAppSubOffice;
        HtmlInputText txtAppPostCode;
        HtmlInputText txtAppEmail;
        HtmlInputText txtAppVIPID;
        HtmlInputText txtAppCountry;
        HtmlSelect cboAppBranch;
        DropDownList cboAppIsGroupDamex;
        HtmlInputButton btnSelectEndCustomer;
        HtmlInputText txtEnduserCompanyName;
        Label lblEndStar;
        Image ImgEndDemax;
        HtmlInputText txtEnduserCustomerID;
        HtmlInputText txtEnduserProvince;
        HtmlInputText txtEnduserCity;
        HtmlSelect cboEnduserCustomerType;
        HtmlInputText txtEnduserContactName;
        HtmlInputText txtEnduserTel;
        HtmlInputText txtEnduserFax;
        HtmlInputText txtEnduserMobile;
        HtmlInputText txtEnduserAddress;
        HtmlInputText txtEnduserSubOffice;
        HtmlInputText txtEnduserPostCode;
        HtmlInputText txtEnduserEmail;
        HtmlInputText txtEnduserVIPID;
        HtmlInputText txtEnduserCountry;
        HtmlSelect cboEnduserBranch;
        DropDownList cboEndIsGroupDamex;

        //Other Request特有的
        HtmlInputText txtMachineManufacturer;
        HtmlInputText txtTypeOfMachine;
        HtmlInputText txtMachineSerialNo;
        HtmlInputText txtControllerType;
        HtmlInputText txtDriverType;
        HtmlInputText txtSoftwareVersion;

        //SSCL
        HtmlInputText txtSiemensApplicant;
        HtmlSelect cboSalechannel;

        //SFAE Request特有的
        HtmlInputText txtProcessingTechnology;
        HtmlInputCheckBox chkifdown;
        HtmlInputText txtRSCNo;
        HtmlInputText txtLocalRSCNo;

        //SPAS Request特有的
        HtmlInputText txtRelateService_SPAS;
        HtmlInputText txtOriginalSO_SPAS;
        HtmlInputText txtOriginalPO_SPAS;
        HtmlInputText txtOriginalDN_SPAS;
        HtmlInputText txtProjectNo_SPAS;
        HtmlInputText txtOccurrenceOfTrouble_SPAS;
        DropDownList cboConsignment_SPAS;

        //IdioSoft.DateTimePicker.DateTimePicker CboCaseTime;
        HtmlInputText CboCaseTime;
        HtmlTextArea txtText;
        HtmlTextArea txtCallagentComments;
        HtmlInputText txtCreateUser;
        HtmlInputText txtCreateDate;
        HtmlInputText txtModifyUser;
        HtmlInputText txtModifyDate;
        HtmlInputButton btn_Save;
        HtmlInputButton btn_Submit;
        GridView grdMainMaterial;
        Label lblCount;
        HtmlTable tableMain;
        //IdioSoft.Informationtools.PageInclude.ProjectControl.conSelectCustomerAndContactInfo ConSelectCustomerAndContactInfo1;
        
        DropDownList cboDistributors;

        HtmlInputSubmit btnClearEndUser;
        HtmlInputText txtAppSFAEVIPID;
        Label lblAppUE;
        Label lblEndUE;
        public void subControl_ObjectToInstance()
        {
            #region "按钮类型"
            FieldInfo fibtn_TSave;
            fibtn_TSave = this.GetType().GetField("btn_TSave", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            btn_TSave = (HtmlInputButton)fibtn_TSave.GetValue(this);

            FieldInfo fibtn_TSubmit;
            fibtn_TSubmit = this.GetType().GetField("btn_TSubmit", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            btn_TSubmit = (HtmlInputButton)fibtn_TSubmit.GetValue(this);

            FieldInfo fibtn_Modify;
            fibtn_Modify = this.GetType().GetField("btn_Modify", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            btn_Modify = (HtmlInputButton)fibtn_Modify.GetValue(this);

            FieldInfo fibtn_Delete;
            fibtn_Delete = this.GetType().GetField("btn_Delete", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            btn_Delete = (HtmlInputButton)fibtn_Delete.GetValue(this);

            FieldInfo fibtn_Cancel;
            fibtn_Cancel = this.GetType().GetField("btn_Cancel", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            btn_Cancel = (HtmlInputButton)fibtn_Cancel.GetValue(this);

            FieldInfo fibtn_Print;
            fibtn_Print = this.GetType().GetField("btn_Print", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            btn_Print = (HtmlInputButton)fibtn_Print.GetValue(this);

            FieldInfo fibtn_Reverse;
            fibtn_Reverse = this.GetType().GetField("btn_Reverse", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            btn_Reverse = (HtmlInputButton)fibtn_Reverse.GetValue(this);

            FieldInfo fibtnSenderMessage;
            fibtnSenderMessage = this.GetType().GetField("btnSenderMessage", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fibtnSenderMessage != null)
            {
                btnSenderMessage = (HtmlInputButton)fibtnSenderMessage.GetValue(this);
            }

            FieldInfo fibtn_AddNewMainMaterial;
            fibtn_AddNewMainMaterial = this.GetType().GetField("btn_AddNewMainMaterial", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fibtn_AddNewMainMaterial != null)
            {
                btn_AddNewMainMaterial = (HtmlInputButton)fibtn_AddNewMainMaterial.GetValue(this);
            }

            FieldInfo fibtn_ModifyMaterial;
            fibtn_ModifyMaterial = this.GetType().GetField("btn_ModifyMaterial", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fibtn_ModifyMaterial != null)
            {
                btn_ModifyMaterial = (HtmlInputButton)fibtn_ModifyMaterial.GetValue(this);
            }

            FieldInfo fibtn_DeleteMaterial;
            fibtn_DeleteMaterial = this.GetType().GetField("btn_DeleteMaterial", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fibtn_DeleteMaterial != null)
            {
                btn_DeleteMaterial = (HtmlInputButton)fibtn_DeleteMaterial.GetValue(this);
            }

            FieldInfo fibtn_AddNewSubMaterial;
            fibtn_AddNewSubMaterial = this.GetType().GetField("btn_AddNewSubMaterial", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fibtn_AddNewSubMaterial != null)
            {
                btn_AddNewSubMaterial = (HtmlInputButton)fibtn_AddNewSubMaterial.GetValue(this);
            }

            FieldInfo fibtn_ClearAllMaterial;
            fibtn_ClearAllMaterial = this.GetType().GetField("btn_ClearAllMaterial", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fibtn_ClearAllMaterial != null)
            {
                btn_ClearAllMaterial = (HtmlInputButton)fibtn_ClearAllMaterial.GetValue(this);
            }

            FieldInfo fibtnSelectAppCustomer;
            fibtnSelectAppCustomer = this.GetType().GetField("btnSelectAppCustomer", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            btnSelectAppCustomer = (HtmlInputButton)fibtnSelectAppCustomer.GetValue(this);

            FieldInfo fibtnSelectEndCustomer;
            fibtnSelectEndCustomer = this.GetType().GetField("btnSelectEndCustomer", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            btnSelectEndCustomer = (HtmlInputButton)fibtnSelectEndCustomer.GetValue(this);

            FieldInfo fibtn_Save;
            fibtn_Save = this.GetType().GetField("btn_Save", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            btn_Save = (HtmlInputButton)fibtn_Save.GetValue(this);

            FieldInfo fibtn_Submit;
            fibtn_Submit = this.GetType().GetField("btn_Submit", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            btn_Submit = (HtmlInputButton)fibtn_Submit.GetValue(this);
            #endregion
            #region "文本类型"

            FieldInfo fitxtSiemensApplicant;
            fitxtSiemensApplicant = this.GetType().GetField("txtSiemensApplicant", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtSiemensApplicant != null)
            {
                txtSiemensApplicant = (HtmlInputText)fitxtSiemensApplicant.GetValue(this);
            }
            FieldInfo fitxtNotificationNo;
            fitxtNotificationNo = this.GetType().GetField("txtNotificationNo", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtNotificationNo = (HtmlInputText)fitxtNotificationNo.GetValue(this);

            FieldInfo fitxtSirot;
            fitxtSirot = this.GetType().GetField("txtSirot", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtSirot = (HtmlInputText)fitxtSirot.GetValue(this);

            FieldInfo fitxtTransferID;
            fitxtTransferID = this.GetType().GetField("txtTransferID", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtTransferID != null)
            {
                txtTransferID = (HtmlInputText)fitxtTransferID.GetValue(this);
            }

            FieldInfo fitxtTroubleDesc;
            fitxtTroubleDesc = this.GetType().GetField("txtTroubleDesc", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtTroubleDesc != null)
            {
                txtTroubleDesc = (HtmlTextArea)fitxtTroubleDesc.GetValue(this);
            }

            FieldInfo fitxtRSV_No;
            fitxtRSV_No = this.GetType().GetField("txtRSV_No", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtRSV_No != null)
            {
                txtRSV_No = (HtmlInputText)fitxtRSV_No.GetValue(this);
            }

            FieldInfo fitxtProjectNO_ExchExpend;
            fitxtProjectNO_ExchExpend = this.GetType().GetField("txtProjectNO_ExchExpend", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtProjectNO_ExchExpend != null)
            {
                txtProjectNO_ExchExpend = (HtmlInputText)fitxtProjectNO_ExchExpend.GetValue(this);
            }

            FieldInfo fitxtProjectName_ExchExpend;
            fitxtProjectName_ExchExpend = this.GetType().GetField("txtProjectName_ExchExpend", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtProjectName_ExchExpend != null)
            {
                txtProjectName_ExchExpend = (HtmlInputText)fitxtProjectName_ExchExpend.GetValue(this);
            }

            FieldInfo fitxtFSPostAddress_ExchExpend;
            fitxtFSPostAddress_ExchExpend = this.GetType().GetField("txtFSPostAddress_ExchExpend", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtFSPostAddress_ExchExpend != null)
            {
                txtFSPostAddress_ExchExpend = (HtmlInputText)fitxtFSPostAddress_ExchExpend.GetValue(this);
            }

            FieldInfo fitxtmlfbNo;
            fitxtmlfbNo = this.GetType().GetField("txtmlfbNo", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtmlfbNo != null)
            {
                txtmlfbNo = (TextBox)fitxtmlfbNo.GetValue(this);
            }

            FieldInfo fitxtSerialNo;
            fitxtSerialNo = this.GetType().GetField("txtSerialNo", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtSerialNo != null)
            {
                txtSerialNo = (HtmlInputText)fitxtSerialNo.GetValue(this);
            }

            FieldInfo fitxtQuantity;
            fitxtQuantity = this.GetType().GetField("txtQuantity", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtQuantity != null)
            {
                txtQuantity = (HtmlInputText)fitxtQuantity.GetValue(this);
            }

            FieldInfo fitxtAppCompanyName;
            fitxtAppCompanyName = this.GetType().GetField("txtAppCompanyName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtAppCompanyName = (HtmlInputText)fitxtAppCompanyName.GetValue(this);

            FieldInfo fitxtAppCustomerID;
            fitxtAppCustomerID = this.GetType().GetField("txtAppCustomerID", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtAppCustomerID = (HtmlInputText)fitxtAppCustomerID.GetValue(this);

            FieldInfo fitxtAppProvince;
            fitxtAppProvince = this.GetType().GetField("txtAppProvince", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtAppProvince = (HtmlInputText)fitxtAppProvince.GetValue(this);

            FieldInfo fitxtAppCity;
            fitxtAppCity = this.GetType().GetField("txtAppCity", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtAppCity = (HtmlInputText)fitxtAppCity.GetValue(this);

            FieldInfo fitxtAppContactName;
            fitxtAppContactName = this.GetType().GetField("txtAppContactName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtAppContactName = (HtmlInputText)fitxtAppContactName.GetValue(this);

            FieldInfo fitxtAppTel;
            fitxtAppTel = this.GetType().GetField("txtAppTel", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtAppTel = (HtmlInputText)fitxtAppTel.GetValue(this);

            FieldInfo fitxtAppFax;
            fitxtAppFax = this.GetType().GetField("txtAppFax", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtAppFax = (HtmlInputText)fitxtAppFax.GetValue(this);

            FieldInfo fitxtAppMobile;
            fitxtAppMobile = this.GetType().GetField("txtAppMobile", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtAppMobile = (HtmlInputText)fitxtAppMobile.GetValue(this);

            FieldInfo fitxtAppAddress;
            fitxtAppAddress = this.GetType().GetField("txtAppAddress", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtAppAddress = (HtmlInputText)fitxtAppAddress.GetValue(this);

            FieldInfo fitxtAppSubOffice;
            fitxtAppSubOffice = this.GetType().GetField("txtAppSubOffice", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtAppSubOffice = (HtmlInputText)fitxtAppSubOffice.GetValue(this);

            FieldInfo fitxtAppPostCode;
            fitxtAppPostCode = this.GetType().GetField("txtAppPostCode", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtAppPostCode = (HtmlInputText)fitxtAppPostCode.GetValue(this);

            FieldInfo fitxtAppEmail;
            fitxtAppEmail = this.GetType().GetField("txtAppEmail", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtAppEmail = (HtmlInputText)fitxtAppEmail.GetValue(this);

            FieldInfo fitxtAppVIPID;
            fitxtAppVIPID = this.GetType().GetField("txtAppVIPID", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtAppVIPID = (HtmlInputText)fitxtAppVIPID.GetValue(this);

            FieldInfo fitxtAppSFAEVIPID;
            fitxtAppSFAEVIPID = this.GetType().GetField("txtAppSFAEVIPID", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtAppSFAEVIPID != null)
            {
                txtAppSFAEVIPID = (HtmlInputText)fitxtAppSFAEVIPID.GetValue(this);
            }


            FieldInfo fitxtAppCountry;
            fitxtAppCountry = this.GetType().GetField("txtAppCountry", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtAppCountry = (HtmlInputText)fitxtAppCountry.GetValue(this);

            FieldInfo fitxtEnduserCompanyName;
            fitxtEnduserCompanyName = this.GetType().GetField("txtEnduserCompanyName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtEnduserCompanyName = (HtmlInputText)fitxtEnduserCompanyName.GetValue(this);

            FieldInfo fitxtEnduserCustomerID;
            fitxtEnduserCustomerID = this.GetType().GetField("txtEnduserCustomerID", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtEnduserCustomerID = (HtmlInputText)fitxtEnduserCustomerID.GetValue(this);

            FieldInfo fitxtEnduserProvince;
            fitxtEnduserProvince = this.GetType().GetField("txtEnduserProvince", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtEnduserProvince = (HtmlInputText)fitxtEnduserProvince.GetValue(this);

            FieldInfo fitxtEnduserCity;
            fitxtEnduserCity = this.GetType().GetField("txtEnduserCity", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtEnduserCity = (HtmlInputText)fitxtEnduserCity.GetValue(this);

            FieldInfo fitxtEnduserContactName;
            fitxtEnduserContactName = this.GetType().GetField("txtEnduserContactName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtEnduserContactName = (HtmlInputText)fitxtEnduserContactName.GetValue(this);

            FieldInfo fitxtEnduserTel;
            fitxtEnduserTel = this.GetType().GetField("txtEnduserTel", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtEnduserTel = (HtmlInputText)fitxtEnduserTel.GetValue(this);

            FieldInfo fitxtEnduserFax;
            fitxtEnduserFax = this.GetType().GetField("txtEnduserFax", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtEnduserFax = (HtmlInputText)fitxtEnduserFax.GetValue(this);

            FieldInfo fitxtEnduserMobile;
            fitxtEnduserMobile = this.GetType().GetField("txtEnduserMobile", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtEnduserMobile = (HtmlInputText)fitxtEnduserMobile.GetValue(this);

            FieldInfo fitxtEnduserAddress;
            fitxtEnduserAddress = this.GetType().GetField("txtEnduserAddress", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtEnduserAddress = (HtmlInputText)fitxtEnduserAddress.GetValue(this);

            FieldInfo fitxtEnduserSubOffice;
            fitxtEnduserSubOffice = this.GetType().GetField("txtEnduserSubOffice", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtEnduserSubOffice = (HtmlInputText)fitxtEnduserSubOffice.GetValue(this);

            FieldInfo fitxtEnduserPostCode;
            fitxtEnduserPostCode = this.GetType().GetField("txtEnduserPostCode", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtEnduserPostCode = (HtmlInputText)fitxtEnduserPostCode.GetValue(this);

            FieldInfo fitxtEnduserEmail;
            fitxtEnduserEmail = this.GetType().GetField("txtEnduserEmail", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtEnduserEmail = (HtmlInputText)fitxtEnduserEmail.GetValue(this);

            FieldInfo fitxtEnduserVIPID;
            fitxtEnduserVIPID = this.GetType().GetField("txtEnduserVIPID", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtEnduserVIPID = (HtmlInputText)fitxtEnduserVIPID.GetValue(this);

            FieldInfo fitxtEnduserCountry;
            fitxtEnduserCountry = this.GetType().GetField("txtEnduserCountry", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtEnduserCountry = (HtmlInputText)fitxtEnduserCountry.GetValue(this);

            FieldInfo fitxtMachineManufacturer;
            fitxtMachineManufacturer = this.GetType().GetField("txtMachineManufacturer", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtMachineManufacturer != null)
            {
                txtMachineManufacturer = (HtmlInputText)fitxtMachineManufacturer.GetValue(this);
            }

            FieldInfo fitxtTypeOfMachine;
            fitxtTypeOfMachine = this.GetType().GetField("txtTypeOfMachine", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtTypeOfMachine != null)
            {
                txtTypeOfMachine = (HtmlInputText)fitxtTypeOfMachine.GetValue(this);
            }

            FieldInfo fitxtMachineSerialNo;
            fitxtMachineSerialNo = this.GetType().GetField("txtMachineSerialNo", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtMachineSerialNo != null)
            {
                txtMachineSerialNo = (HtmlInputText)fitxtMachineSerialNo.GetValue(this);
            }

            FieldInfo fitxtControllerType;
            fitxtControllerType = this.GetType().GetField("txtControllerType", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtControllerType != null)
            {
                txtControllerType = (HtmlInputText)fitxtControllerType.GetValue(this);
            }

            FieldInfo fitxtDriverType;
            fitxtDriverType = this.GetType().GetField("txtDriverType", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtDriverType != null)
            {
                txtDriverType = (HtmlInputText)fitxtDriverType.GetValue(this);
            }

            FieldInfo fitxtSoftwareVersion;
            fitxtSoftwareVersion = this.GetType().GetField("txtSoftwareVersion", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtSoftwareVersion != null)
            {
                txtSoftwareVersion = (HtmlInputText)fitxtSoftwareVersion.GetValue(this);
            }

            FieldInfo fitxtText;
            fitxtText = this.GetType().GetField("txtText", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtText = (HtmlTextArea)fitxtText.GetValue(this);

            FieldInfo fitxtCallagentComments;
            fitxtCallagentComments = this.GetType().GetField("txtCallagentComments", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtCallagentComments = (HtmlTextArea)fitxtCallagentComments.GetValue(this);

            FieldInfo fitxtCreateUser;
            fitxtCreateUser = this.GetType().GetField("txtCreateUser", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtCreateUser = (HtmlInputText)fitxtCreateUser.GetValue(this);

            FieldInfo fitxtCreateDate;
            fitxtCreateDate = this.GetType().GetField("txtCreateDate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtCreateDate = (HtmlInputText)fitxtCreateDate.GetValue(this);

            FieldInfo fitxtModifyUser;
            fitxtModifyUser = this.GetType().GetField("txtModifyUser", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtModifyUser = (HtmlInputText)fitxtModifyUser.GetValue(this);

            FieldInfo fitxtModifyDate;
            fitxtModifyDate = this.GetType().GetField("txtModifyDate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            txtModifyDate = (HtmlInputText)fitxtModifyDate.GetValue(this);

            FieldInfo fitxtProcessingTechnology;
            fitxtProcessingTechnology = this.GetType().GetField("txtProcessingTechnology", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtProcessingTechnology != null)
            {
                txtProcessingTechnology = (HtmlInputText)fitxtProcessingTechnology.GetValue(this);
            }

            FieldInfo fitxtRSCNo;
            fitxtRSCNo = this.GetType().GetField("txtRSCNo", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtRSCNo != null)
            {
                txtRSCNo = (HtmlInputText)fitxtRSCNo.GetValue(this);
            }

            FieldInfo fitxtLocalRSCNo;
            fitxtLocalRSCNo = this.GetType().GetField("txtLocalRSCNo", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtLocalRSCNo != null)
            {
                txtLocalRSCNo = (HtmlInputText)fitxtLocalRSCNo.GetValue(this);
            }

            FieldInfo fitxtMaterialFaultDesc;
            fitxtMaterialFaultDesc = this.GetType().GetField("txtMaterialFaultDesc", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtMaterialFaultDesc != null)
            {
                txtMaterialFaultDesc = (HtmlTextArea)fitxtMaterialFaultDesc.GetValue(this);
            }

            FieldInfo fitxtRelateService_SPAS;
            fitxtRelateService_SPAS = this.GetType().GetField("txtRelateService_SPAS", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtRelateService_SPAS != null)
            {
                txtRelateService_SPAS = (HtmlInputText)fitxtRelateService_SPAS.GetValue(this);
            }

            FieldInfo fitxtOriginalSO_SPAS;
            fitxtOriginalSO_SPAS = this.GetType().GetField("txtOriginalSO_SPAS", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtOriginalSO_SPAS != null)
            {
                txtOriginalSO_SPAS = (HtmlInputText)fitxtOriginalSO_SPAS.GetValue(this);
            }

            FieldInfo fitxtOriginalPO_SPAS;
            fitxtOriginalPO_SPAS = this.GetType().GetField("txtOriginalPO_SPAS", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtOriginalPO_SPAS != null)
            {
                txtOriginalPO_SPAS = (HtmlInputText)fitxtOriginalPO_SPAS.GetValue(this);
            }

            FieldInfo fitxtOriginalDN_SPAS;
            fitxtOriginalDN_SPAS = this.GetType().GetField("txtOriginalDN_SPAS", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtOriginalDN_SPAS != null)
            {
                txtOriginalDN_SPAS = (HtmlInputText)fitxtOriginalDN_SPAS.GetValue(this);
            }

            FieldInfo fitxtProjectNo_SPAS;
            fitxtProjectNo_SPAS = this.GetType().GetField("txtProjectNo_SPAS", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtProjectNo_SPAS != null)
            {
                txtProjectNo_SPAS = (HtmlInputText)fitxtProjectNo_SPAS.GetValue(this);
            }

            FieldInfo fitxtOccurrenceOfTrouble_SPAS;
            fitxtOccurrenceOfTrouble_SPAS = this.GetType().GetField("txtOccurrenceOfTrouble_SPAS", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fitxtOccurrenceOfTrouble_SPAS != null)
            {
                txtOccurrenceOfTrouble_SPAS = (HtmlInputText)fitxtOccurrenceOfTrouble_SPAS.GetValue(this);
            }
            #endregion
            #region "下拉类型"
            FieldInfo ficboServiceProvider;
            ficboServiceProvider = this.GetType().GetField("cboServiceProvider", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            cboServiceProvider = (DropDownList)ficboServiceProvider.GetValue(this);

            FieldInfo ficboServiceType;
            ficboServiceType = this.GetType().GetField("cboServiceType", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            cboServiceType = (DropDownList)ficboServiceType.GetValue(this);

            FieldInfo ficboArea;
            ficboArea = this.GetType().GetField("cboArea", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            cboArea = (DropDownList)ficboArea.GetValue(this);

            FieldInfo ficboProductName;
            ficboProductName = this.GetType().GetField("cboProductName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (ficboProductName != null)
            {
                cboProductName = (DropDownList)ficboProductName.GetValue(this);
            }
            FieldInfo ficboProductDesc;
            ficboProductDesc = this.GetType().GetField("cboProductDesc", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (ficboProductDesc != null)
            {
                cboProductDesc = (HtmlSelect)ficboProductDesc.GetValue(this);
            }

            FieldInfo ficboTransferUser;
            ficboTransferUser = this.GetType().GetField("cboTransferUser", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (ficboTransferUser != null)
            {
                cboTransferUser = (HtmlSelect)ficboTransferUser.GetValue(this);
            }

            FieldInfo ficboCaseProperty;
            ficboCaseProperty = this.GetType().GetField("cboCaseProperty", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            cboCaseProperty = (DropDownList)ficboCaseProperty.GetValue(this);

            FieldInfo ficboWarranty;
            ficboWarranty = this.GetType().GetField("cboWarranty", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (ficboWarranty != null)
            {
                cboWarranty = (DropDownList)ficboWarranty.GetValue(this);
            }

            FieldInfo ficboDistributors;
            ficboDistributors = this.GetType().GetField("cboDistributors", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (ficboDistributors != null)
            {
                cboDistributors = (DropDownList)ficboDistributors.GetValue(this);
            }

            FieldInfo ficboOrderType;
            ficboOrderType = this.GetType().GetField("cboOrderType", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (ficboOrderType != null)
            {
                cboOrderType = (DropDownList)ficboOrderType.GetValue(this);
            }

            FieldInfo ficboMaterialProductName;
            ficboMaterialProductName = this.GetType().GetField("cboMaterialProductName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (ficboMaterialProductName != null)
            {
                cboMaterialProductName = (DropDownList)ficboMaterialProductName.GetValue(this);
            }

            FieldInfo ficboMaterialProducDesc;
            ficboMaterialProducDesc = this.GetType().GetField("cboMaterialProducDesc", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (ficboMaterialProducDesc != null)
            {
                cboMaterialProducDesc = (DropDownList)ficboMaterialProducDesc.GetValue(this);
            }

            FieldInfo ficboMaterialFault;
            ficboMaterialFault = this.GetType().GetField("cboMaterialFault", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (ficboMaterialFault != null)
            {
                cboMaterialFault = (DropDownList)ficboMaterialFault.GetValue(this);
            }

            FieldInfo ficboAppCustomerType;
            ficboAppCustomerType = this.GetType().GetField("cboAppCustomerType", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            cboAppCustomerType = (DropDownList)ficboAppCustomerType.GetValue(this);

            FieldInfo ficboAppBranch;
            ficboAppBranch = this.GetType().GetField("cboAppBranch", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            cboAppBranch = (HtmlSelect)ficboAppBranch.GetValue(this);

            FieldInfo ficboAppIsGroupDamex;
            ficboAppIsGroupDamex = this.GetType().GetField("cboAppIsGroupDamex", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            cboAppIsGroupDamex = (DropDownList)ficboAppIsGroupDamex.GetValue(this);

            FieldInfo ficboEnduserCustomerType;
            ficboEnduserCustomerType = this.GetType().GetField("cboEnduserCustomerType", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            cboEnduserCustomerType = (HtmlSelect)ficboEnduserCustomerType.GetValue(this);

            FieldInfo ficboEnduserBranch;
            ficboEnduserBranch = this.GetType().GetField("cboEnduserBranch", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            cboEnduserBranch = (HtmlSelect)ficboEnduserBranch.GetValue(this);

            FieldInfo ficboEndIsGroupDamex;
            ficboEndIsGroupDamex = this.GetType().GetField("cboEndIsGroupDamex", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            cboEndIsGroupDamex = (DropDownList)ficboEndIsGroupDamex.GetValue(this);

            FieldInfo ficboPaintingJudge;
            ficboPaintingJudge = this.GetType().GetField("cboPaintingJudge", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (ficboPaintingJudge != null)
            {
                cboPaintingJudge = (HtmlSelect)ficboPaintingJudge.GetValue(this);
            }

            FieldInfo ficboMainFault;
            ficboMainFault = this.GetType().GetField("cboMainFault", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (ficboMainFault != null)
            {
                cboMainFault = (DropDownList)ficboMainFault.GetValue(this);
            }

            FieldInfo ficboSubFault;
            ficboSubFault = this.GetType().GetField("cboSubFault", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (ficboSubFault != null)
            {
                cboSubFault = (HtmlSelect)ficboSubFault.GetValue(this);
            }

            FieldInfo ficboConsignment_SPAS;
            ficboConsignment_SPAS = this.GetType().GetField("cboConsignment_SPAS", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (ficboConsignment_SPAS != null)
            {
                cboConsignment_SPAS = (DropDownList)ficboConsignment_SPAS.GetValue(this);
            }

            FieldInfo fibtnClearEndUser;
            fibtnClearEndUser = this.GetType().GetField("btnClearEndUser", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fibtnClearEndUser != null)
            {
                btnClearEndUser = (HtmlInputSubmit)fibtnClearEndUser.GetValue(this);

            }

            FieldInfo ficboSalechannel;
            ficboSalechannel = this.GetType().GetField("cboSalechannel", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (ficboSalechannel != null)
            {
                cboSalechannel = (HtmlSelect)ficboSalechannel.GetValue(this);
            }

            #endregion
            #region "勾选类型"
            FieldInfo fichkRepair;
            fichkRepair = this.GetType().GetField("chkRepair", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            chkRepair = (HtmlInputCheckBox)fichkRepair.GetValue(this);

            FieldInfo fichkApp_ExchExpend;
            fichkApp_ExchExpend = this.GetType().GetField("chkApp_ExchExpend", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fichkApp_ExchExpend != null)
            {
                chkApp_ExchExpend = (HtmlInputCheckBox)fichkApp_ExchExpend.GetValue(this);
            }

            FieldInfo fichkEnd_ExchExpend;
            fichkEnd_ExchExpend = this.GetType().GetField("chkEnd_ExchExpend", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fichkEnd_ExchExpend != null)
            {
                chkEnd_ExchExpend = (HtmlInputCheckBox)fichkEnd_ExchExpend.GetValue(this);
            }

            FieldInfo fichkifdown;
            fichkifdown = this.GetType().GetField("chkifdown", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fichkifdown != null)
            {
                chkifdown = (HtmlInputCheckBox)fichkifdown.GetValue(this);
            }

            FieldInfo fichkAssembly;
            fichkAssembly = this.GetType().GetField("chkAssembly", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fichkAssembly != null)
            {
                chkAssembly = (HtmlInputCheckBox)fichkAssembly.GetValue(this);
            }

            FieldInfo fichkisPackage;
            fichkisPackage = this.GetType().GetField("chkisPackage", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fichkisPackage != null)
            {
                chkisPackage = (HtmlInputCheckBox)fichkisPackage.GetValue(this);
            }
            #endregion
            #region "Lable类型"
            FieldInfo fiLabel1;
            fiLabel1 = this.GetType().GetField("Label1", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fiLabel1 != null)
            {
                Label1 = (Label)fiLabel1.GetValue(this);
            }

            fiLabel1 = this.GetType().GetField("lblAppUE", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fiLabel1 != null)
            {
                lblAppUE = (Label)fiLabel1.GetValue(this);
            }

            fiLabel1 = this.GetType().GetField("lblEndUE", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (fiLabel1 != null)
            {
                lblEndUE = (Label)fiLabel1.GetValue(this);
            }

            FieldInfo fiLabel2;
            fiLabel2 = this.GetType().GetField("Label2", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (Label2 != null)
            {
                Label2 = (Label)fiLabel2.GetValue(this);
            }

            FieldInfo filblAppStar;
            filblAppStar = this.GetType().GetField("lblAppStar", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            lblAppStar = (Label)filblAppStar.GetValue(this);

            FieldInfo filblEndStar;
            filblEndStar = this.GetType().GetField("lblEndStar", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            lblEndStar = (Label)filblEndStar.GetValue(this);

            FieldInfo filblCount;
            filblCount = this.GetType().GetField("lblCount", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (filblCount != null)
            {
                lblCount = (Label)filblCount.GetValue(this);
            }
            #endregion
            #region "图片类型"
            FieldInfo fiImgAPPDames;
            fiImgAPPDames = this.GetType().GetField("ImgAPPDames", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            ImgAPPDames = (Image)fiImgAPPDames.GetValue(this);

            FieldInfo fiImgEndDemax;
            fiImgEndDemax = this.GetType().GetField("ImgEndDemax", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            ImgEndDemax = (Image)fiImgEndDemax.GetValue(this);
            #endregion
            #region "时间类型"
            FieldInfo fiCboCaseTime;
            fiCboCaseTime = this.GetType().GetField("CboCaseTime", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            //CboCaseTime = (IdioSoft.DateTimePicker.DateTimePicker)fiCboCaseTime.GetValue(this);
            #endregion
            #region "GID类型"
            FieldInfo figrdMainMaterial;
            figrdMainMaterial = this.GetType().GetField("grdMainMaterial", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            grdMainMaterial = (GridView)figrdMainMaterial.GetValue(this);
            #endregion
            #region "表类型"
            FieldInfo fitableMain;
            fitableMain = this.GetType().GetField("tableMain", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            tableMain = (HtmlTable)fitableMain.GetValue(this);
            #endregion
            #region"SSCL"
            #endregion
            //FieldInfo fiConSelectCustomerAndContactInfo1;
            //fiConSelectCustomerAndContactInfo1 = this.GetType().GetField("ConSelectCustomerAndContactInfo1", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            //ConSelectCustomerAndContactInfo1 = (IdioSoft.Informationtools.PageInclude.ProjectControl.conSelectCustomerAndContactInfo)fiConSelectCustomerAndContactInfo1.GetValue(this);
        }
        #endregion

        #region "载入窗口过程"
        protected override void OnLoad(EventArgs e)
        {
            subControl_ObjectToInstance();
            try
            {
                ViewState["strURequestID"] = Request.QueryString["ID"].ToString();
            }
            catch
            {

            }
            try
            {
                ViewState["strOperation"] = Request.QueryString["Operation"].ToString();
            }
            catch
            {
                ViewState["strOperation"] = "";
            }
            try
            {
                strFrom = Request.QueryString["FromWhere"].ToString().ToLower();
            }
            catch
            {
            }
            try
            {
                strAccountID = Request.QueryString["AccountID"].ToString().Trim();
            }
            catch
            { }
            try
            {
                strContactID = Request.QueryString["ContactID"].ToString().Trim();
            }
            catch
            { }
            if (((IdioSoft.Site.ClassLibrary.UserInfo)(Session["UserInfo"])).IsReDoOnLoadRequest)
            {
                return;
            }
            try
            {
                ViewState["strTmpServiceType"] = Request.QueryString["ServiceType"].ToString().ToLower();
            }
            catch
            {
                ViewState["strTmpServiceType"] = "";
            }
            try
            {
                ViewState["ICompanyName"] = Server.UrlDecode(Request["ICompanyName"].ToString());
            }
            catch (System.Exception ex)
            {
                ViewState["ICompanyName"] = "";
            }
            try
            {
                ViewState["IContactID"] = Request["IContactID"].ToString();
            }
            catch (System.Exception ex)
            {
                ViewState["IContactID"] = "";
            }
            subLoad_ICustomerInfo();
            base.OnLoad(e);
            if (!this.IsPostBack)
            {
                cboServiceType.subComboBox_LoadItems("SELECT ServiceType FROM webInfo_Basic_ServiceRequest_ServiceType_Info", 0, new ListItem("", ""));
                
                cboServiceType.subComboBox_SelectItemByText(ViewState["strTmpServiceType"].ToString());

                if (cboServiceProvider.funComboBox_SelectedText().ToLower() == "seal")
                {
                    cboServiceType.Items.Add(new ListItem("SPS", "SPS"));
                }
                if (cboServiceProvider.funComboBox_SelectedText().ToLower() == "esp")
                {
                    cboServiceType.Items.Clear();
                    cboServiceType.Items.Add(new ListItem("FS", "FS"));
                    cboServiceType.Items.Add(new ListItem("EXCH", "EXCH"));
                }

                cboAppCustomerType.subComboBox_LoadItems("select CustomerType from WebInfo_Basic_Account_CustomerType_Info", 0, new ListItem("", ""));
                cboEnduserCustomerType.subComboBox_LoadItems("select CustomerType from WebInfo_Basic_Account_CustomerType_Info", 0, new ListItem("", ""));
                
                cboCaseProperty.subComboBox_LoadItems("SELECT CaseProperty FROM webInfo_Basic_ServiceRequest_CaseProperty_Info order by sortID", 0, null);
                cboAppBranch.subComboBox_LoadItems("SELECT Branch FROM CallCenter_Basic_Branch_Info WHERE (IsDel = 0) order by orderno", 0, new ListItem("", ""));
                cboEnduserBranch.subComboBox_LoadItems("SELECT Branch FROM WebInfo_Basic_SPAS_IHR_BRANCH WHERE (IsDel = 0) order by orderno", 0, new ListItem("", ""));
                
                btn_Cancel.Attributes.Add("onclick", "return confirm('是否确定取消？')");
                btn_Delete.Attributes.Add("onclick", "return confirm('是否确定删除？')");
                if (strAccountID != "")
                {
                    subDBDetail_CallCenterAccount(strAccountID);
                }
                if (strContactID != "")
                {
                    subDBDetail_CallCenterContact(strContactID);
                }
                if (ViewState["strOperation"].ToString() == "")
                {
                    subDB_LoadModifyInfo();
                    subDB_LoadMaterial();
                    subControl_EnableALL(false);
                    btn_Save.Visible = true;
                    btn_Submit.Visible = true;
                    btn_TSave.Visible = true;
                    btn_TSubmit.Visible = true;
                    btn_Delete.Disabled = false;
                    btn_Modify.Disabled = false;
                    btn_Cancel.Disabled = false;
                    btn_Print.Disabled = false;
                    btn_AddNewMainMaterial.Disabled = true;
                    btn_ModifyMaterial.Disabled = true;
                    btn_DeleteMaterial.Disabled = true;
                    //((IdioSoft.Informationtools.PageInclude.MasterPage.PopOperation)(this.Master)).lblOperationTitleText = "Request Detail";
                    btn_Print.Attributes.Add("onclick", "openPrintWindow('" + ViewState["strURequestID"] + "')");
                }
                else
                {
                    btn_Delete.Disabled = true;
                    btn_Modify.Disabled = true;
                    btn_Cancel.Disabled = true;
                    btn_Print.Disabled = true;
                    btn_DeleteMaterial.Disabled = true;
                    btn_ModifyMaterial.Disabled = true;

                    //((IdioSoft.Informationtools.PageInclude.MasterPage.PopOperation)(this.Master)).lblOperationTitleText = "Request Addnew";
                    txtCreateUser.Value = ((IdioSoft.Site.ClassLibrary.UserInfo)Session["UserInfo"]).EnUserName.ToString();
                    txtCreateDate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    txtQuantity.Value = "1";
                    subDBInsert_NewRequest();
                    //this.CboCaseTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                switch (strFrom)
                {
                    case "cancel":
                        btn_Reverse.Visible = true;
                        break;
                    default:
                        btn_Reverse.Visible = false;
                        break;
                }
            }

        }
        #endregion

        public void subLoad_ICustomerInfo()
        {
            if (ViewState["ICompanyName"] == null || ViewState["IContactID"] == null)
            {
                return;
            }
            if (ViewState["ICompanyName"].ToString() == "" && ViewState["IContactID"].ToString() == "")
            {
                return;
            }
            string strSQL = "";
            strSQL = @"SELECT ID,CustomerID, CompanyName, SubOffice, Province, City, CustomerType, CompanyAddress, PostAddress, RegAddress, ConsignorAddress, TaxCode, AccountCode, 
                       BankName, PostCode, FinanceTel, Country, Branch,VIPID,IsGroupDamex,BeiDeVIP,SFAEVIPID    
                       FROM Webinfo_Account_Info where CompanyName='" + ViewState["ICompanyName"].ToString() + "'";
            DataSet ds = new DataSet();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            if (ds == null || ds.Tables[0].Rows.Count <= 0)
            {
                return;
            }
            IdioSoft.Site.ClassLibrary.Control.ClassReturnCustomerAndContractInfo objclassReturnCustomerAndContractInfo = new ClassReturnCustomerAndContractInfo();

            objclassReturnCustomerAndContractInfo.AccountID = ds.Tables[0].Rows[0]["ID"].ToString();
            objclassReturnCustomerAndContractInfo.CustomerID = ds.Tables[0].Rows[0]["CustomerID"].ToString();
            objclassReturnCustomerAndContractInfo.CompanyName = ds.Tables[0].Rows[0]["CompanyName"].ToString();
            objclassReturnCustomerAndContractInfo.SubOffice = ds.Tables[0].Rows[0]["SubOffice"].ToString();
            objclassReturnCustomerAndContractInfo.Province = ds.Tables[0].Rows[0]["Province"].ToString();
            objclassReturnCustomerAndContractInfo.City = ds.Tables[0].Rows[0]["City"].ToString();
            objclassReturnCustomerAndContractInfo.CustomerType = ds.Tables[0].Rows[0]["CustomerType"].ToString();
            objclassReturnCustomerAndContractInfo.PostAddress = ds.Tables[0].Rows[0]["PostAddress"].ToString();
            objclassReturnCustomerAndContractInfo.RegAddress = ds.Tables[0].Rows[0]["RegAddress"].ToString();
            objclassReturnCustomerAndContractInfo.ConsignorAddress = ds.Tables[0].Rows[0]["ConsignorAddress"].ToString();
            objclassReturnCustomerAndContractInfo.TaxCode = ds.Tables[0].Rows[0]["TaxCode"].ToString();
            objclassReturnCustomerAndContractInfo.AccountCode = ds.Tables[0].Rows[0]["AccountCode"].ToString();
            objclassReturnCustomerAndContractInfo.BankName = ds.Tables[0].Rows[0]["BankName"].ToString();
            //objclassReturnCustomerAndContractInfo.PostCode = ds.Tables[0].Rows[0]["PostCode"].ToString();
            objclassReturnCustomerAndContractInfo.FinanceTel = ds.Tables[0].Rows[0]["FinanceTel"].ToString();
            objclassReturnCustomerAndContractInfo.Country = ds.Tables[0].Rows[0]["Country"].ToString();
            objclassReturnCustomerAndContractInfo.Branch = ds.Tables[0].Rows[0]["Branch"].ToString();
            objclassReturnCustomerAndContractInfo.VIPID = ds.Tables[0].Rows[0]["VIPID"].ToString();
            objclassReturnCustomerAndContractInfo.IsGroupDamex = ds.Tables[0].Rows[0]["IsGroupDamex"].ToString();
            objclassReturnCustomerAndContractInfo.BeiDeVIP = ds.Tables[0].Rows[0]["BeiDeVIP"].ToString();
            objclassReturnCustomerAndContractInfo.SFAEVIPID = ds.Tables[0].Rows[0]["SFAEVIPID"].ToString();

            strSQL = @"SELECT ID,ContactName, Tel, Mobile, Fax, Address, PostCode, Email FROM   Webinfo_Account_Contact_info where  ID='" + ViewState["IContactID"].ToString() + "'";
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                objclassReturnCustomerAndContractInfo.ContactID = ds.Tables[0].Rows[0]["ID"].ToString();
                objclassReturnCustomerAndContractInfo.ContactName = ds.Tables[0].Rows[0]["ContactName"].ToString();
                objclassReturnCustomerAndContractInfo.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                objclassReturnCustomerAndContractInfo.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                objclassReturnCustomerAndContractInfo.Fax = ds.Tables[0].Rows[0]["Fax"].ToString();
                objclassReturnCustomerAndContractInfo.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                objclassReturnCustomerAndContractInfo.contractPostCode = ds.Tables[0].Rows[0]["PostCode"].ToString();
                objclassReturnCustomerAndContractInfo.PostCode = ds.Tables[0].Rows[0]["PostCode"].ToString();//带联系人的postcode
                objclassReturnCustomerAndContractInfo.Email = ds.Tables[0].Rows[0]["Email"].ToString();
            }
            subLoadAppCustomerAndContactInfo(objclassReturnCustomerAndContractInfo);
        }

        public string vuRequestID
        {
            get
            {
                return ViewState["strURequestID"].ToString();
            }
        }
        #region "当载入添加窗体时，自动生成一张Request,将isdel=1"
        public virtual void subDBInsert_NewRequest()
        {
            string strSQL = "";
            ViewState["strURequestID"] = Guid.NewGuid().ToString();
            string RID = funString_RequestCode();
            strSQL = "INSERT INTO webInfo_ServiceRequest_Info (ID, CreateDate, CreateUser, isDel, isSubmit,RequestID) VALUES ('";
            strSQL = strSQL + ViewState["strURequestID"].ToString() + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," + ((IdioSoft.Site.ClassLibrary.UserInfo)(Session["UserInfo"])).UserID;
            strSQL = strSQL + ",1,0,'" + RID + "')";
            objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            ViewState["strOperation"] = "";
        }
        #endregion
        #region "载入基本信息"
        //载入cboProductDesc
        public virtual void subDB_LoadcboProductDesc(string productName)
        {
            cboProductDesc.subComboBox_LoadItems("SELECT productDesc  FROM webInfo_Basic_ServiceRequest_Product_Info where productName='" + productName + "' and ServiceProviders  like '%" + cboServiceProvider.funComboBox_SelectedValue() + "%'", 0, new ListItem("", ""));
        }

        //载入cboArea
        public virtual void subDB_LoadcboArea()
        {
            cboArea.subComboBox_LoadItems("SELECT Area FROM webInfo_Basic_serviceRequest_Duty_Info where ServiceProvider='" + cboServiceProvider.funComboBox_SelectedValue() + "' group by area", 0, new ListItem("", ""));
        }

        //载入TransferID
        public void subDB_LoadTransferID()
        {
            cboTransferUser.Items.Clear();
            if (cboServiceType.SelectedIndex >= 0 && cboProductName.SelectedIndex >= 0 && cboArea.SelectedIndex >= 0 && cboServiceProvider.SelectedIndex >= 0)
            {
                string strSQL = "";
                txtTransferID.Value = "0";

                strSQL = "SELECT dutyID FROM webInfo_Basic_serviceRequest_Duty_Info where productName='" + cboProductName.funComboBox_SelectedValue() + "' and area='" + cboArea.funComboBox_SelectedValue();
                strSQL = strSQL + "' and serviceProvider='" + cboServiceProvider.funComboBox_SelectedValue() + "' and ServiceType='" + cboServiceType.funComboBox_SelectedValue() + "'";

                try
                {

                    DataSet ds = new DataSet();
                    ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txtTransferID.Value = ds.Tables[0].Rows[0][0].ToString();
                        }
                    }
                    subDB_LoadCboTransferUser();
                }
                catch
                {
                }
            }
            else
            {
                txtTransferID.Value = "0";
            }

        }
        //载入cboTransferUser
        public virtual void subDB_LoadCboTransferUser()
        {
            cboTransferUser.Items.Clear();
            string strSQL = "";
            if (cboServiceProvider.funComboBox_SelectedValue().ToLower() == "seal")
            {
                strSQL = "SELECT ID, EnUserName FROM webInfo_loginInfo WHERE  serviceProvider='SEAL' and isdel = 0 and isTran=1 and isDisplayRequest=1";
            }
            else
            {
                strSQL = "SELECT ID, EnUserName FROM webInfo_loginInfo WHERE (DutyLimited LIKE '%," + txtTransferID.Value + ",%') and serviceProvider='" + cboServiceProvider.funComboBox_SelectedValue() + "' and isdel = 0 and isDisplayRequest=1 order by SortID desc";
            }
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

        private void subTransferUser_Selected()
        {
            switch (cboServiceProvider.funComboBox_SelectedText().ToLower())
            {
                case "sfae":
                    switch (cboServiceType.funComboBox_SelectedText().ToLower())
                    {
                        case "fs":
                            #region "fs"
                            switch (cboArea.funComboBox_SelectedText().ToLower())
                            {
                                case "bj":
                                    switch (cboProductName.funComboBox_SelectedText().ToLower())
                                    {
                                        case "mc mt":
                                            cboTransferUser.subComboBox_SelectItemByText("MC BJ Duty");
                                            break;
                                        case "as":
                                            cboTransferUser.subComboBox_SelectItemByText("MC BJ Duty");
                                            break;
                                        case "dr sd":
                                            cboTransferUser.subComboBox_SelectItemByText("Driver BJ Duty");
                                            break;
                                        case "dr ld":
                                            cboTransferUser.subComboBox_SelectItemByText("Driver BJ Duty");
                                            break;
                                        case "mc pm":
                                            cboTransferUser.subComboBox_SelectItemByText("Driver BJ Duty");
                                            break;
                                    }
                                    break;
                                case "sh":
                                    switch (cboProductName.funComboBox_SelectedText().ToLower())
                                    {
                                        case "mc mt":
                                            cboTransferUser.subComboBox_SelectItemByText("MC SH Duty");
                                            break;
                                        case "as":
                                            cboTransferUser.subComboBox_SelectItemByText("MC SH Duty");
                                            break;
                                        case "dr sd":
                                            cboTransferUser.subComboBox_SelectItemByText("Driver SH Duty");
                                            break;
                                        case "dr ld":
                                            cboTransferUser.subComboBox_SelectItemByText("Driver SH Duty");
                                            break;
                                        case "mc pm":
                                            cboTransferUser.subComboBox_SelectItemByText("Driver SH Duty");
                                            break;
                                    }
                                    break;
                                case "sy":
                                    switch (cboProductName.funComboBox_SelectedText().ToLower())
                                    {
                                        case "mc mt":
                                            cboTransferUser.subComboBox_SelectItemByText("MC SY Duty");
                                            break;
                                        case "as":
                                            cboTransferUser.subComboBox_SelectItemByText("MC SY Duty");
                                            break;
                                        case "dr sd":
                                            cboTransferUser.subComboBox_SelectItemByText("Driver SY Duty");
                                            break;
                                        case "dr ld":
                                            cboTransferUser.subComboBox_SelectItemByText("Driver SY Duty");
                                            break;
                                        case "mc pm":
                                            cboTransferUser.subComboBox_SelectItemByText("Driver SY Duty");
                                            break;
                                    }
                                    break;
                                case "gz":
                                    switch (cboProductName.funComboBox_SelectedText().ToLower())
                                    {
                                        case "mc mt":
                                            cboTransferUser.subComboBox_SelectItemByText("MC GZ Duty");
                                            break;
                                        case "as":
                                            cboTransferUser.subComboBox_SelectItemByText("MC GZ Duty");
                                            break;
                                        case "dr sd":
                                            cboTransferUser.subComboBox_SelectItemByText("Driver GZ Duty");
                                            break;
                                        case "dr ld":
                                            cboTransferUser.subComboBox_SelectItemByText("Driver GZ Duty");
                                            break;
                                        case "mc pm":
                                            cboTransferUser.subComboBox_SelectItemByText("Driver GZ Duty");
                                            break;
                                    }
                                    break;
                                case "cd":
                                    switch (cboProductName.funComboBox_SelectedText().ToLower())
                                    {
                                        case "mc mt":
                                            cboTransferUser.subComboBox_SelectItemByText("MC CD Duty");
                                            break;
                                        case "as":
                                            cboTransferUser.subComboBox_SelectItemByText("MC CD Duty");
                                            break;
                                        case "dr sd":
                                            cboTransferUser.subComboBox_SelectItemByText("Driver CD Duty");
                                            break;
                                        case "dr ld":
                                            cboTransferUser.subComboBox_SelectItemByText("Driver CD Duty");
                                            break;
                                        case "mc pm":
                                            cboTransferUser.subComboBox_SelectItemByText("Driver CD Duty");
                                            break;
                                    }
                                    break;
                            }
                            #endregion
                            break;
                        case "ihr":

                            break;

                    }
                    break;
            }
        }
        #endregion
        #region "是否屏蔽控件"
        public virtual void subControl_EnableALL(bool blen)
        {
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
            cboServiceType.Enabled = blen;
            cboArea.Enabled = blen;
            if (cboProductName != null)
            {
                cboProductName.Enabled = blen;
            }
            cboAppCustomerType.Enabled = blen;
            cboServiceProvider.Enabled = blen;
            if (cboOrderType != null)
            {
                cboOrderType.Enabled = blen;
            }
            if (txtRSV_No != null)
            {
                txtRSV_No.Disabled = !blen;
            }
        }
        #endregion
        # region "点击修改服务按钮"
        public virtual void btn_Modify_ServerClick(object sender, EventArgs e)
        {
            subControl_EnableALL(true);
            btn_Save.Visible = true;
            btn_Submit.Visible = true;
            btn_TSave.Visible = true;
            btn_TSubmit.Visible = true;
            btn_AddNewMainMaterial.Disabled = false;
        }
        #endregion
        #region "点击记录，载入修改信息"
        public virtual void subDB_LoadModifyInfo()
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
        #endregion
        #region "载入MainMaterial信息"
        public virtual void subDB_LoadMaterial()
        {
            string strSQL = "";
            strSQL = "SELECT ID,MLFB, SerialNo, Quantity,CreateDate FROM webInfo_Servicerequest_Material_Info where uRequestID = '" + ViewState["strURequestID"].ToString() + "' and ParentID is null order by CreateDate desc";
            DataSet ds = new DataSet();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            grdMainMaterial.DataSource = ds.Tables[0];
            grdMainMaterial.DataBind();
            lblCount.Text = "Record count:" + ds.Tables[0].Rows.Count.ToString();
        }
        //做行数据绑定
        public virtual void grdMainMaterial_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
                {
                    e.Row.Cells[i].Attributes.Add("class", "idio_gridBottom");
                }
            }
            //用于不换行属性
            for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
            {
                e.Row.Cells[i].Attributes.Add("nowrap", "nowrap");
            }
        }
        #endregion
        #region "改变cboServiceProvider选项"
        public virtual void cboServiceProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboServiceProvider.SelectedIndex >= 0)
            {
                subDB_LoadcboArea();
                subDB_LoadTransferID();
            }
        }
        #endregion
        #region "改变cboServiceType选项"
        public virtual void cboServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboServiceType.SelectedIndex > 0)
            {
                subDB_LoadTransferID();
                subDB_LoadcboArea();
            }
        }
        #endregion
        #region "改变cboArea选项"
        protected void cboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboArea.SelectedIndex >= 0)
            {
                subDB_LoadTransferID();
            }
        }
        #endregion
        #region "改变cboProductName选项"
        public virtual void cboProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProductName.SelectedIndex >= 0)
            {
                subDB_LoadcboProductDesc(cboProductName.funComboBox_SelectedValue());
                subDB_LoadTransferID();
            }
        }
        #endregion
        #region "改变cboCaseProperty选项"
        protected void cboCaseProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCaseProperty.SelectedIndex >= 0)
            {
                if (cboCaseProperty.funComboBox_SelectedValue() == "international order")
                {
                    txtSirot.Attributes.Add("class", "idio_inputBoxNormalStyle");
                    txtSirot.Disabled = false;
                }
                else
                {
                    txtSirot.Attributes.Add("class", "inputBoxDisabledStyle");
                    txtSirot.Disabled = true;
                }
            }
            else
            {
                txtSirot.Attributes.Add("class", "inputBoxDisabledStyle");
                txtSirot.Disabled = true;
            }
        }
        #endregion
        #region "点击Save保存"
        public virtual void btn_Save_Click(object sender, EventArgs e)
        {
        }
        #endregion
        #region "点击Submit保存Request"
        public virtual void btn_Submit_ServerClick(object sender, EventArgs e)
        {
        }
        #endregion
        #region "RequestID编码yyyyMM0001"
        public string funString_RequestCode()
        {
            string strSQL;

            //strSQL = "SELECT Max(CONVERT(decimal,case when ISNUMERIC (RequestID)=0 then 0 else RequestID end )) as MaxID FROM webInfo_ServiceRequest_Info where year(createdate)=" + DateTime.Now.Year.ToString();// and month(createdate) =" + DateTime.Now.Month.ToString();
            strSQL = "SELECT   max(case when ISNUMERIC(RequestID)=0 then 0 else CONVERT(decimal,RequestID) end)  as MaxID FROM webInfo_ServiceRequest_Info where  substring(requestid,1,1)=2";//year(createdate)=" + DateTime.Now.Year.ToString() +" and

            string strID = "";
            try
            {
                strID = objDbSQLAccess.funString_SQLExecuteScalar(strSQL);
                if (strID == "")
                {
                    strID = DateTime.Now.ToString("yyyyMM0001");
                }
                else
                {
                    string sYear = DateTime.Now.Year.ToString();
                    string strTmp = strID.Substring(0, 4);
                    if (strTmp != sYear)
                    {
                        strID = DateTime.Now.ToString("yyyyMM0001");
                    }
                    else
                    {
                        strID = (Int64.Parse(strID) + 1).ToString();
                    }
                }
            }
            catch
            {
                strID = DateTime.Now.ToString("yyyyMM0001");
            }
            return strID;
        }
        #endregion
        #region "判断NotificationNo是否已经存在"
        public bool funNotificationNoExist()
        {
            string strSQL = "";
            int intCount = 0;
            if (this.txtNotificationNo.Value.ToString().Trim() != "")
            {
                if (ViewState["strURequestID"].ToString() != "")
                {
                    strSQL = "select count(*) as Count from webInfo_ServiceRequest_Info where NotificationNo = '" + txtNotificationNo.Value.ToString().Trim() + "' and id<>'" + ViewState["strURequestID"].ToString() + "' and isdel=0";
                }
                else
                {
                    strSQL = "select count(*) as Count from webInfo_ServiceRequest_Info where NotificationNo = '" + txtNotificationNo.Value.ToString().Trim() + "' and isdel=0";
                }
                intCount = int.Parse(objDbSQLAccess.funString_SQLExecuteScalar(strSQL));
            }
            if (intCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region "点击载入申请人"
        protected void btnSelectAppCustomer_ServerClick(object sender, EventArgs e)
        {
            //ConSelectCustomerAndContactInfo1.Visible = true;

            //ConSelectCustomerAndContactInfo1.ReturnCustomerContactInfoFunName = "subLoadAppCustomerAndContactInfo";
            //tableMain.Visible = false;
            //ConSelectCustomerAndContactInfo1.subSetFocus();
        }
        #endregion
        #region "点击载入最终用户"
        protected void btnSelectEndCustomer_ServerClick(object sender, EventArgs e)
        {
            //ConSelectCustomerAndContactInfo1.Visible = true;

            //ConSelectCustomerAndContactInfo1.ReturnCustomerContactInfoFunName = "subLoadEndCustomerAndContactInfo";
            //tableMain.Visible = false;
            //ConSelectCustomerAndContactInfo1.subSetFocus();
        }
        #endregion
        #region"修改Request记录"
        public virtual void subDB_ModifyDatabase(int intType)
        {
        }
        #endregion
        #region "将MLFB,SerialNo回存到主表"
        public void subDBInsert_MainTable()
        {
            string strSQL = "";
            if (this.grdMainMaterial.Rows.Count > 0)
            {
                strSQL = "select top 1 MLFB,SerialNo from webInfo_Servicerequest_Material_Info where uRequestID = '" + ViewState["strURequestID"].ToString() + "' order by CreateDate desc";
                DataSet ds = new DataSet();
                ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
                string strMLFB = "";
                strMLFB = ds.Tables[0].Rows[0]["MLFB"].ToString();
                string strSerialNo = "";
                strSerialNo = ds.Tables[0].Rows[0]["SerialNo"].ToString();
                strSQL = "update webInfo_ServiceRequest_Info set MLFBNo = '" + strMLFB + "',SerialNo = '" + strSerialNo + "' where ID = '" + ViewState["strURequestID"].ToString() + "'";
                objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            }
        }
        #endregion
        #region "添加备件"
        //添加主备件
        public virtual void btn_AddNewMainMaterial_ServerClick(object sender, EventArgs e)
        {
        }
        //添加子备件
        public virtual void btn_AddNewSubMaterial_ServerClick(object sender, EventArgs e)
        {
        }
        #endregion
        #region "点击Cancel按钮"
        public virtual void btn_Cancel_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string strSQL;
                strSQL = "update webInfo_ServiceRequest_Info set isCancel=1,Status='Cancel',CancelReason='服务取消',CancelDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where id='" + ViewState["strURequestID"].ToString() + "'";
                string strerror = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

                IdioSoft.Business.Method.LogHelper.GetInstance().InsertSQLLog(strSQL,"Cancel Service Request", ((IdioSoft.Site.ClassLibrary.UserInfo)(Session["UserInfo"])).UserID.ToString(), ((IdioSoft.Site.ClassLibrary.UserInfo)(Session["UserInfo"])).EnUserName);

                ScriptManager.RegisterStartupScript(this, GetType(), "cancelrequest1", "alert('完成取消!');window.close();", true);
            }
            catch
            {
            }
        }
        #endregion
        #region "点击删除按钮"
        protected void btn_Delete_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string strSQL;
                strSQL = "update webInfo_ServiceRequest_Info set isDel=1 where id='" + ViewState["strURequestID"].ToString() + "'";
                string strerror = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

                IdioSoft.Business.Method.LogHelper.GetInstance().InsertSQLLog(strSQL,"Delete Service Request", ((IdioSoft.Site.ClassLibrary.UserInfo)(Session["UserInfo"])).UserID.ToString(), ((IdioSoft.Site.ClassLibrary.UserInfo)(Session["UserInfo"])).EnUserName);

                ScriptManager.RegisterStartupScript(this, GetType(), "deleterequest1", "alert('删除成功！');window.close();", true);
            }
            catch
            { }
        }
        #endregion


        private bool funBoolean_FindUE(string CompanyName)
        {
            string strSQL = "";
            strSQL = "SELECT  count(*) FROM CallCenter_Basic_UEInfo where CompanyName='" + CompanyName + "'";
            return objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0) > 0;
        }

        #region "载入申请人信息"
        public virtual void subLoadAppCustomerAndContactInfo(IdioSoft.Site.ClassLibrary.Control.ClassReturnCustomerAndContractInfo objclassReturnCustomerAndContractInfo)
        {
            txtAppCompanyName.Value = objclassReturnCustomerAndContractInfo.CompanyName;
            txtAppContactName.Value = objclassReturnCustomerAndContractInfo.ContactName;
            txtAppCustomerID.Value = objclassReturnCustomerAndContractInfo.CustomerID;
            txtAppAddress.Value = objclassReturnCustomerAndContractInfo.Address;
            txtAppCity.Value = objclassReturnCustomerAndContractInfo.City;
            txtAppEmail.Value = objclassReturnCustomerAndContractInfo.Email;
            txtAppFax.Value = objclassReturnCustomerAndContractInfo.Fax;
            txtAppMobile.Value = objclassReturnCustomerAndContractInfo.Mobile;
            txtAppPostCode.Value = objclassReturnCustomerAndContractInfo.PostCode;
            txtAppProvince.Value = objclassReturnCustomerAndContractInfo.Province;
            txtAppSubOffice.Value = objclassReturnCustomerAndContractInfo.SubOffice;
            txtAppTel.Value = objclassReturnCustomerAndContractInfo.Tel;
            txtAppCountry.Value = objclassReturnCustomerAndContractInfo.Country;
            txtAppVIPID.Value = objclassReturnCustomerAndContractInfo.VIPID;
            if (txtAppSFAEVIPID != null)
            {
                txtAppSFAEVIPID.Value = objclassReturnCustomerAndContractInfo.SFAEVIPID;
            }
            string strAppDemax = "false";
            strAppDemax = objclassReturnCustomerAndContractInfo.IsGroupDamex;
            //山东蓬莱信益陶瓷厂
            string ServiceProvider = cboServiceProvider.funComboBox_SelectedValue();
            bool blnSMDT = false;
            if (ServiceProvider.ToLower() == "smdt")
            {
                blnSMDT = true;
            }
            else
            {
                try
                {
                    blnSMDT = txtAppVIPID.Value.Substring(0, 2).ToLower() != "md";
                }
                catch (System.Exception ex)
                {

                }
            }
            if (txtAppVIPID.Value.Trim() != "" && blnSMDT)
            {
                if (txtAppSFAEVIPID != null)
                {
                    if (txtAppSFAEVIPID.Value != "")
                    {
                        txtAppCompanyName.Attributes.Add("style", "width: 490px;border:1px solid red;color:green;");
                        this.lblAppStar.Visible = true;
                        this.lblAppStar.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        txtAppCompanyName.Attributes.Add("style", "width: 490px;border:1px solid red;");
                        this.lblAppStar.Visible = true;
                        this.lblAppStar.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    txtAppCompanyName.Attributes.Add("style", "width: 490px;border:1px solid red;");
                    this.lblAppStar.Visible = true;
                    this.lblAppStar.ForeColor = System.Drawing.Color.Red;
                }

            }
            else
            {

                if (txtAppSFAEVIPID != null)
                {
                    if (txtAppSFAEVIPID.Value != "")
                    {
                        txtAppCompanyName.Attributes.Add("style", "width: 490px;border:1px solid #7F9DB9;color:green;");
                        this.lblAppStar.Visible = false;
                        this.lblAppStar.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        this.lblAppStar.Visible = false;
                        txtAppCompanyName.Attributes.Add("style", "width: 490px;border:1px solid  #7F9DB9;");
                    }
                }
                else
                {
                    this.lblAppStar.Visible = false;
                    txtAppCompanyName.Attributes.Add("style", "width: 490px;border:1px solid  #7F9DB9;");
                }
            }
            if (strAppDemax.ToString().Trim().ToLower() == "true")
            {
                this.cboAppIsGroupDamex.SelectedIndex = 1;
                txtAppCompanyName.Attributes.Add("style", "width: 490px;border:1px solid yellow;");
                this.ImgAPPDames.Visible = true;
            }

            ViewState["AppAccountID"] = objclassReturnCustomerAndContractInfo.AccountID;
            ViewState["AppContactID"] = objclassReturnCustomerAndContractInfo.ContactID;

            for (int nA = 0; nA < cboAppBranch.Items.Count; nA++)
            {
                if (cboAppBranch.Items[nA].Value.ToLower() == objclassReturnCustomerAndContractInfo.Branch.ToLower())
                {
                    cboAppBranch.SelectedIndex = nA;
                }
            }

            cboAppCustomerType.subComboBox_SelectItemByValue(objclassReturnCustomerAndContractInfo.CustomerType);

            if (funBoolean_FindUE(txtAppCompanyName.Value))
            {
                lblAppUE.Visible = true;
            }
            else
            {
                lblAppUE.Visible = false;
            }
        }
        #endregion
        #region "载入最终用户信息"
        public virtual void subLoadEndCustomerAndContactInfo(IdioSoft.Site.ClassLibrary.Control.ClassReturnCustomerAndContractInfo objclassReturnCustomerAndContractInfo)
        {
            txtEnduserCompanyName.Value = objclassReturnCustomerAndContractInfo.CompanyName;
            txtEnduserContactName.Value = objclassReturnCustomerAndContractInfo.ContactName;
            txtEnduserCustomerID.Value = objclassReturnCustomerAndContractInfo.CustomerID;
            txtEnduserAddress.Value = objclassReturnCustomerAndContractInfo.Address;
            txtEnduserCity.Value = objclassReturnCustomerAndContractInfo.City;
            txtEnduserEmail.Value = objclassReturnCustomerAndContractInfo.Email;
            txtEnduserFax.Value = objclassReturnCustomerAndContractInfo.Fax;
            txtEnduserMobile.Value = objclassReturnCustomerAndContractInfo.Mobile;
            txtEnduserPostCode.Value = objclassReturnCustomerAndContractInfo.PostCode;
            txtEnduserProvince.Value = objclassReturnCustomerAndContractInfo.Province;
            txtEnduserSubOffice.Value = objclassReturnCustomerAndContractInfo.SubOffice;
            txtEnduserTel.Value = objclassReturnCustomerAndContractInfo.Tel;
            txtEnduserCountry.Value = objclassReturnCustomerAndContractInfo.Country;

            txtEnduserVIPID.Value = objclassReturnCustomerAndContractInfo.VIPID;

            string strEndDemax = "false";
            strEndDemax = objclassReturnCustomerAndContractInfo.IsGroupDamex;

            if (txtEnduserVIPID.Value.Trim() != "")
            {
                txtEnduserCompanyName.Attributes.Add("style", "width: 490px;border-left-color: red; border-bottom-color: red; border-top-style: solid; border-top-color: red; border-right-style: solid; border-left-style: solid; border-right-color: red; border-bottom-style: solid;");
                this.lblEndStar.Visible = true;
            }
            else
            {
                this.lblEndStar.Visible = false;
                txtEnduserCompanyName.Attributes.Add("style", "width: 490px;border-left-color: #7F9DB9; border-bottom-color: #7F9DB9; border-top-style: solid; border-top-color: #7F9DB9; border-right-style: solid; border-left-style: solid; border-right-color: #7F9DB9; border-bottom-style: solid;");
            }
            if (strEndDemax.ToString().Trim().ToLower() == "true")
            {
                this.cboEndIsGroupDamex.SelectedIndex = 1;
                txtEnduserCompanyName.Attributes.Add("style", "width: 490px;border-left-color: yellow; border-bottom-color: yellow; border-top-style: solid; border-top-color: yellow; border-right-style: solid; border-left-style: solid; border-right-color: yellow; border-bottom-style: solid;");
                this.ImgEndDemax.Visible = true;
            }
            else
            {
                this.ImgEndDemax.Visible = false;
                this.cboEndIsGroupDamex.SelectedIndex = 0;
                if (txtEnduserVIPID.Value.Trim() != "")
                {
                    txtEnduserCompanyName.Attributes.Add("style", "width: 490px;border-left-color: red; border-bottom-color: red; border-top-style: solid; border-top-color: red; border-right-style: solid; border-left-style: solid; border-right-color: red; border-bottom-style: solid;");
                    this.lblEndStar.Visible = true;
                }
                else
                {
                    this.lblEndStar.Visible = false;
                    txtEnduserCompanyName.Attributes.Add("style", "width: 490px;border-left-color: #7F9DB9; border-bottom-color: #7F9DB9; border-top-style: solid; border-top-color: #7F9DB9; border-right-style: solid; border-left-style: solid; border-right-color: #7F9DB9; border-bottom-style: solid;");
                }
            }
            ViewState["EnduserAccountID"] = objclassReturnCustomerAndContractInfo.AccountID;
            ViewState["EnduserContactID"] = objclassReturnCustomerAndContractInfo.ContactID;

            for (int nA = 0; nA < cboEnduserBranch.Items.Count; nA++)
            {
                if (cboEnduserBranch.Items[nA].Value.ToLower() == objclassReturnCustomerAndContractInfo.Branch.ToLower())
                {
                    cboEnduserBranch.SelectedIndex = nA;
                }
            }

            cboEnduserCustomerType.subComboBox_SelectItemByValue(objclassReturnCustomerAndContractInfo.CustomerType);

            if (funBoolean_FindUE(txtEnduserCompanyName.Value))
            {
                lblEndUE.Visible = true;
            }
            else
            {
                lblEndUE.Visible = false;
            }
        }
        #endregion
        #region "选中Grid的一行"
        public virtual void grdMainMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        public virtual void grdsubMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        public virtual void subLoad_ModifyMaterialInfo()
        {
        }
        #endregion
        #region "修改Material信息"
        public virtual void btn_ModifyMaterial_ServerClick(object sender, EventArgs e)
        {
            if (ViewState["SelectMaterialID"] == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ModifyMaterialError", "alert('请先选取一条记录再做修改!');", true);
                return;
            }
            string strMLFB = "";
            string strSerialNo = "";
            string ParentID = "";
            ParentID = ViewState["MainMaterialID"].ToString();
            int intQty = 1;
            strMLFB = txtmlfbNo.Text.funString_SQLToString();
            strSerialNo = txtSerialNo.Value.funString_SQLToString();
            intQty = txtQuantity.Value.funInt_StringToInt(1);
            string ProductName = "";
            string ProductDesc = "";
            ProductName = cboMaterialProductName.funComboBox_SelectedValue();
            ProductDesc = cboMaterialProducDesc.funComboBox_SelectedValue();
            string ProductFault = "";
            ProductFault = cboMaterialFault.funComboBox_SelectedValue();
            string strSQL = "";
            strSQL = "update webInfo_Servicerequest_Material_Info  set MLFB='" + strMLFB + "',SerialNo='" + strSerialNo + "',Quantity=" + intQty + ",MaterialProductName='" + ProductName + "',MaterialProductDesc='" + ProductDesc + "',MaterialFault='" + ProductFault + "' where ID='" + ViewState["SelectMaterialID"] + "'";
            objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            subDB_LoadMaterial();
            this.btn_ClearAllMaterial.Disabled = false;
        }
        #endregion
        #region "删除Material信息"
        public virtual void btn_DeleteMaterial_ServerClick(object sender, EventArgs e)
        {
            if (ViewState["SelectMaterialID"] == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "DeleteMaterialError", "alert('请先选取一条记录再做删除!');", true);
                return;
            }
            string strSQL = "";
            strSQL = "delete from webInfo_Servicerequest_Material_Info where ID='" + ViewState["SelectMaterialID"].ToString() + "'";
            objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            subDB_LoadMaterial();
        }
        #endregion

        //下面这些事call center里特有的
        //Other里特有的
        #region "点击cboOrderType时的事件"
        public virtual void cboOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboOrderType.funComboBox_SelectedValue().ToLower() != "project expend")
            //{
            //    trSfaeExchProjectInfo.Visible = false;
            //}
            //else
            //{
            //    trSfaeExchProjectInfo.Visible = true;
            //}
        }
        #endregion
        #region "手动维护webInfo_SfaeIhr_WaitDrive_Info"
        public virtual void subInsertWaitDrive()
        {
            string strSQL = "";

            bool blnIHRProduct = false;
            blnIHRProduct = ((cboProductName.Text.ToLower().IndexOf("motor") > 0 || cboProductName.Text.ToLower().IndexOf("wiss") > 0));
            if (!blnIHRProduct)
            {
                return;
            }
            if ((cboServiceType.Text.ToLower() == "ihr") && blnIHRProduct)
            {
                strSQL = "insert into webInfo_SfaeIhr_WaitDrive_Info(uRequestID,WaitDrive,WaitDriveDate,createDate,createUser)";
                strSQL += " values('" + ViewState["strURequestID"].ToString() + "','" + "Wait Machine" + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," + ((IdioSoft.Site.ClassLibrary.UserInfo)(Session["UserInfo"])).UserID + ")";
            }
            else
            {
                return;
            }
            string strerror = objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
        }
        #endregion


        #region "一键清除所有物料信息"
        protected void btn_ClearAllMaterial_ServerClick(object sender, EventArgs e)
        {
            string strSQL = "";
            strSQL = "delete from webInfo_Servicerequest_Material_Info where uRequestID = '" + ViewState["strURequestID"].ToString() + "'";
            objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);
            subDB_LoadMaterial();

            IdioSoft.Business.Method.LogHelper.GetInstance().InsertSQLLog(strSQL,"Clear ServiceRequest Material", ((IdioSoft.Site.ClassLibrary.UserInfo)(Session["UserInfo"])).UserID.ToString(), ((IdioSoft.Site.ClassLibrary.UserInfo)(Session["UserInfo"])).EnUserName);
        }
        #endregion
        #region "在CallCenter模块里的Account里进行传值"
        public virtual void subDBDetail_CallCenterAccount(string strID)
        {
            string strSQL = "";
            strSQL = "select CompanyName,CustomerID,Province,City,CustomerType,FinanceTel,CompanyAddress,SubOffice,PostCode,VIPID,Country,Branch from Webinfo_Account_Info where ID = '" + strID + "'";
            DataSet ds = new DataSet();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            if (ds != null)
            {
                this.txtAppCompanyName.Value = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                this.txtAppCustomerID.Value = ds.Tables[0].Rows[0]["CustomerID"].ToString();
                this.txtAppProvince.Value = ds.Tables[0].Rows[0]["Province"].ToString();
                this.txtAppCity.Value = ds.Tables[0].Rows[0]["City"].ToString();
                cboAppCustomerType.subComboBox_SelectItemByValue(ds.Tables[0].Rows[0]["CustomerType"].ToString().Trim());
                this.txtAppContactName.Value = "";
                this.txtAppTel.Value = ds.Tables[0].Rows[0]["FinanceTel"].ToString();
                this.txtAppMobile.Value = "";
                this.txtAppFax.Value = "";
                this.txtAppAddress.Value = ds.Tables[0].Rows[0]["CompanyAddress"].ToString();
                this.txtAppSubOffice.Value = ds.Tables[0].Rows[0]["SubOffice"].ToString();
                this.txtAppPostCode.Value = ds.Tables[0].Rows[0]["PostCode"].ToString();
                this.txtAppEmail.Value = "";
                this.txtAppVIPID.Value = ds.Tables[0].Rows[0]["VIPID"].ToString();
                this.txtAppCountry.Value = ds.Tables[0].Rows[0]["Country"].ToString();
                cboAppBranch.subComboBox_SelectItemByValue(ds.Tables[0].Rows[0]["Branch"].ToString());
                ViewState["AppAccountID"] = strID;
            }
        }
        #endregion
        #region "在CallCenter模块里的Contact里进行传值"
        public void subDBDetail_CallCenterContact(string strID)
        {
            string strSQL = "";
            strSQL = "select ContactName, Tel, Mobile, Fax, Address, PostCode, Email FROM   Webinfo_Account_Contact_info where ID='" + strID + "'";
            DataSet ds = new DataSet();
            ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            if (ds != null)
            {
                this.txtAppContactName.Value = ds.Tables[0].Rows[0]["ContactName"].ToString();
                this.txtAppTel.Value = ds.Tables[0].Rows[0]["Tel"].ToString();
                this.txtAppMobile.Value = ds.Tables[0].Rows[0]["Mobile"].ToString();
                this.txtAppFax.Value = ds.Tables[0].Rows[0]["Fax"].ToString();
                //this.txtAppAddress.Value = ds.Tables[0].Rows[0]["Address"].ToString();
                this.txtAppEmail.Value = ds.Tables[0].Rows[0]["Email"].ToString();
                ViewState["AppContactID"] = strID;
            }
        }
        #endregion
        #region "当改变cboMaterialProductName时"
        protected void cboMaterialProductName_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboMaterialFault.subComboBox_LoadItems("select ProductFault  from CallCenter_Basic_Product_Info where productname='" + cboMaterialProductName.funComboBox_SelectedValue() + "' and  ServiceProvider='" + cboServiceProvider.funComboBox_SelectedValue() + "' group by ProductFault", 0, new ListItem("", ""));
                cboMaterialProducDesc.subComboBox_LoadItems("select ProductDesc  from CallCenter_Basic_Product_Info where productname='" + cboMaterialProductName.funComboBox_SelectedValue() + "' and  ServiceProvider='" + cboServiceProvider.funComboBox_SelectedValue() + "' group by ProductDesc", 0, new ListItem("", ""));
            }
            catch
            {
            }
        }
        #endregion


        #region "点击清理End User"
        protected void btnClearEndUser_ServerClick(object sender, EventArgs e)
        {
            txtEnduserAddress.Value = "";
            txtEnduserCity.Value = "";
            txtEnduserCompanyName.Value = "";
            txtEnduserContactName.Value = "";
            txtEnduserCountry.Value = "";
            txtEnduserCustomerID.Value = "";
            txtEnduserEmail.Value = "";
            txtEnduserFax.Value = "";
            txtEnduserMobile.Value = "";
            txtEnduserPostCode.Value = "";
            txtEnduserProvince.Value = "";
            txtEnduserSubOffice.Value = "";
            txtEnduserTel.Value = "";
            txtEnduserVIPID.Value = "";
            string strSQL = "";
            try
            {
                strSQL = @"UPDATE    webInfo_ServiceRequest_Info SET EnduserCompanyName ='', EnduserSubOffice ='', EnduserCustomerID ='', EnduserProvince ='', EnduserCity ='', EnduserCustomerType ='', 
                      EnduserContactName ='', EnduserTel ='', EnduserMobile ='', EnduserFax ='', EnduserAddress ='', EnduserPostCode ='', EnduserCountry ='', EnduserBranch ='', 
                      EnduserEmail ='', EnduserMainOffice ='', EnduserVIPID ='' where ID='" + ViewState["strURequestID"].ToString();
                objDbSQLAccess.funString_SQLExecuteNonQuery(strSQL);

                IdioSoft.Business.Method.LogHelper.GetInstance().InsertSQLLog(strSQL,"Clear EndUserCompanyName Service Request", ((IdioSoft.Site.ClassLibrary.UserInfo)(Session["UserInfo"])).UserID.ToString(), ((IdioSoft.Site.ClassLibrary.UserInfo)(Session["UserInfo"])).EnUserName);

            }
            catch
            {
            }
        }
        #endregion

        public string funString_VIPSalesEmail(bool isEnduer)
        {
            string strSQL = "";
            if (isEnduer)
            {
                strSQL = "SELECT   VipSalesEmail FROM         Webinfo_Account_Info where CompanyName='" + txtEnduserCompanyName.Value + "' and isdel=0";
            }
            else
            {
                strSQL = "SELECT   VipSalesEmail FROM         Webinfo_Account_Info where CompanyName='" + txtAppCompanyName.Value + "' and isdel=0";
            }
            return objDbSQLAccess.funString_SQLExecuteScalar(strSQL);
        }
    }
}