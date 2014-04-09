<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SEWCRequestOperation.aspx.cs" Inherits="IdioSoft.Site.SEWC.Request.SEWCRequestOperation" MasterPageFile="~/Master/Csite/Pop.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../../Scripts/jQuery-Timepicker-Addon/jquery-ui-timepicker-addon.css" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="../../Scripts/jQuery-Timepicker-Addon/jquery-ui-timepicker-addon.js"></script>
    <script type="text/javascript" src="../../Scripts/ajaxfileupload.js"></script>
    <script type='text/javascript' src='../../Scripts/jquery-autocomplete/jquery.autocomplete.js'></script>
    <link rel="stylesheet" type="text/css" href="../../Scripts/jquery-autocomplete/jquery.autocomplete.css" />
    <script type="text/javascript">
        var PuRequestIDs = "<%=PuRequestIDs%>";
        var POperationType = "<%=POperationType%>";
        $(document).ready(function () {
            $(".clsdtpCaseTime").datetimepicker({ dateFormat: 'yy-mm-dd', timeFormat: "HH:mm:ss", defaultValue: new Date().Format("yyyy-MM-dd hh:mm:ss") });

        });
    </script>
    <script type="text/javascript" src="../../JsLibrary/SEWC/Request/SEWCRequestOperation.js"></script>

    <table border="0" id="tblOperation" style="width: 100%;">
        <tr>
            <td colspan="4" align="left" style="border-bottom: #dddddd 1px solid">
                <input id="btnTSave" class="btn btn-primary clsbtnTSave" name="btnTSave" type="button" value="Save" style="width: 80px;" runat="server"  limitCode="51002"  />
                <input id="btnTSubmit" class="btn btn-primary clsbtnTSubmit" name="btnTSubmit" type="button" value="Submit" runat="server"  limitCode="51002"  />
                <input id="btnModify" class="btn btn-primary clsbtnModify" name="btnModify" type="button" value="Modify" runat="server"  limitCode="51002"  />
                <input id="btnDelete" class="btn btn-primary clsbtnDelete" name="btnDelete" type="button" value="Delete" runat="server"  limitCode="51002"  />
                <input id="btnCancel" class="btn btn-primary clsbtnCancel" name="btnCancel" type="button" value="Cancel" runat="server"  limitCode="51002"  />
                <input id="btnPrint" class="btn btn-primary clsbtnPrint" name="btnPrint" type="button" value="Print" runat="server"  limitCode="51002"  />
                <input id="btnSenderMessage" class="btn btn-primary clsbtnSenderMessage" name="btnSenderMessage" style="width: 90px" type="button" value="Send Message" runat="server"  limitCode="51002"  />
                <input id="btnSendMail" class="btn btn-primary clsbtnSendMail" name="btnSendMail" style="width: 90px" type="button" value="Send Mail" runat="server"  limitCode="51002"  />
                <input id="btnCopy" class="btn btn-primary clsbtnCopy" name="btnCopy" type="button" value="Copy Request" runat="server"  limitCode="51002"  />
            </td>
        </tr>
        <tr>
            <td>NotificationNo</td>
            <td>
                <input name="txtNotificationNo" type="text" id="txtNotificationNo" runat="server" class="clstxtNotificationNo" />
            </td>
            <td>Service Provider</td>
            <td style="width: 80%">
                <select name="cboServiceProvider" class="clscboServiceProvider" id="cboServiceProvider"
                    runat="server">
                </select></td>
        </tr>
        <tr>
            <td>Service Type</td>
            <td>
                <select name="cboServiceType" class="clscboServiceType" id="cboServiceType"
                    runat="server">
                </select>
            </td>
            <td>Area</td>
            <td>
                <select name="cboArea" class="clscboArea" id="cboArea"
                    runat="server">
                </select>
            </td>
        </tr>
        <tr>
            <td>Case Property</td>
            <td>
                <select name="cboCaseProperty" class="clscboCaseProperty" id="cboCaseProperty" style="width: 80px;"
                    runat="server">
                </select>
                <input id="txtSirot" runat="server" class="clstxtSirot" disabled="disabled"
                    maxlength="50" name="txtSirot" style="width: 110px" type="text" />
                <input id="txtTransferID" runat="server" class="clstxtTransferID" style="height: 16px; display: none;"
                    type="text" disabled="disabled" />
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>TroubleDesc
            </td>
            <td colspan="3">
                <textarea id="txtTroubleDesc" class="clstxtTroubleDesc" runat="server" cols="45" rows="6" name="txtTroubleDesc"
                    style="width: 525px; height: 60px"></textarea>
            </td>
        </tr>
        <tr>
            <td>是否为补单
            </td>
            <td>
                <input id="chkRepair" class="clschkRepair" runat="server" name="chkRepair" type="checkbox" value="1" />&nbsp;
            </td>
            <td id="tdName" runat="server" nowrap="nowrap" class="clstdName">Warranty
            </td>
            <td id="tdValue" runat="server" valign="top" class="clstdValue">
                <select name="cboWarranty" class="clscboWarranty" id="cboWarranty"
                    runat="server">
                </select>
            </td>
        </tr>
        <tr>
            <td>isRepeat
            </td>
            <td>
                <input id="chkisRepeat" class="clschkisRepeat" runat="server" name="chkisRepeat" type="checkbox" />&nbsp;
                <input id="txtOriCase" runat="server" class="clstxtOriCase" name="txtOriCase" type="text" style="width: 175px;" />
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr id="trordertype" runat="server" class="clstrordertype" style="display: none;">
            <td>OrderType
            </td>
            <td>
                <select name="cboOrderType" class="clscboOrderType" id="cboOrderType"
                    runat="server">
                </select>
            </td>
            <td>RSV- No.
            </td>
            <td>
                <input name="txtRSVNo" type="text" class="clstxtRSVNo" id="txtRSVNo"
                    maxlength="50" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Created User
            </td>
            <td>
                <input id="txtCreateUser" runat="server" class="clstxtCreateUser" disabled="disabled"
                    maxlength="50" name="txtCreateUser" type="text" />
            </td>
            <td>Created Date
            </td>
            <td>
                <input id="txtCreateDate" runat="server" class="clstxtCreateDate" disabled="disabled"
                    maxlength="20" name="txtCreateDate" type="text" />
            </td>
        </tr>
        <tr id="trSfaeExchProjectInfo" runat="server" class="clstrSfaeExchProjectInfo" style="display: none;">
            <td colspan="4">
                <table width="100%" border="0" cellspacing="0" cellpadding="2">
                    <tr>
                        <td height="25" colspan="4" bgcolor="#F0F0F0" style="border-top: #999999 1px solid; border-bottom: #999999 1px solid;">Project Info
                        </td>
                    </tr>
                    <tr>
                        <td width="6%" nowrap="nowrap">ProjectNO
                        </td>
                        <td width="15%">
                            <input id="txtProjectNOExchExpend" runat="server" class="clstxtProjectNOExchExpend"
                                maxlength="50" name="txtProjectNOExchExpend" type="text" />
                        </td>
                        <td width="5%">ProjectName
                        </td>
                        <td width="74%">
                            <input id="txtProjectNameExchExpend" runat="server" class="clstxtProjectNameExchExpend"
                                maxlength="50" name="txtProjectNameExchExpend" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td>SelectCompany
                        </td>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <input id="chkAppExchExpend" type="checkbox" runat="server" class="clschkAppExchExpend" />
                                        <asp:Label ID="Label1" runat="server" Text="申请者"></asp:Label>
                                    </td>
                                    <td>
                                        <input id="chkEndExchExpend" type="checkbox" runat="server" class="clschkEndExchExpend" />
                                        <asp:Label ID="Label2" runat="server" Text="最终用户"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td nowrap="nowrap">FSPostAddress
                        </td>
                        <td>
                            <input id="txtFSPostAddressExchExpend" runat="server" class="clstxtFSPostAddressExchExpend"
                                maxlength="50" name="txtFSPostAddressExchExpend" type="text" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4" height="25" nowrap="nowrap" style="border-top: #dddddd 1px solid; border-bottom: #999999 1px solid; padding-left: 8px; background-color: #EBF2FA">Product Info 
                <asp:Label ID="lblCount" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="tdItems" runat="server" id="tdIDItems">
                <table border="0" style="border-spacing: 0;" id="tblOther" runat="server">
                    <tr>
                        <td style="width: 120px;">MLFBNo
                        </td>
                        <td style="width: 225px;">
                            <input id="txtMLFBNo" runat="server" class="clstxtMLFBNo" maxlength="50"
                                name="txtMLFBNo" type="text" />
                        </td>
                        <td style="width: 100px;">SerialNo
                        </td>
                        <td style="width: 200px;">
                            <input id="txtSerialNo" runat="server" class="clstxtSerialNo" maxlength="50"
                                name="txtSerialNo" type="text" />
                        </td>
                        <td rowspan="5"><a href="#" class="lnkaddother" data-icon="&#xe1f4;" title="AddNew"></a>
                            <br />
                            <a href="#" class="lnkdelother" data-icon="&#xe1f3;" title="Delete"></a></td>
                    </tr>
                    <tr>
                        <td>ProductName
                        </td>
                        <td>
                            <select name="cboMaterialProductName" class="clscboMaterialProductName" id="cboMaterialProductName"
                                runat="server">
                            </select>
                        </td>
                        <td>ProductDesc
                        </td>
                        <td>
                            <select name="cboMaterialProducDesc" class="clscboMaterialProducDesc" id="cboMaterialProducDesc"
                                runat="server">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td>MaterialFault
                        </td>
                        <td>
                            <select name="cboMaterialFault" class="clscboMaterialFault" id="cboMaterialFault"
                                runat="server">
                            </select>
                        </td>
                        <td>Quantity
                        </td>
                        <td>
                            <input id="txtQuantity" runat="server" class="clstxtQuantity" maxlength="50"
                                name="txtQuantity" onkeypress="return event.keyCode>=48&&event.keyCode<=57||event.keyCode==13" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td>Transfer User</td>
                        <td>
                            <select name="cboTransferUser" class="clscboTransferUser" id="cboTransferUser"
                                runat="server">
                            </select>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td bgcolor="#EBF2FA" colspan="4" height="25" nowrap="nowrap" style="border-top: #dddddd 1px solid; border-bottom: #dddddd 1px solid"><b>申请公司信息</b><input id="btnSelectAppCustomer" class="btn btn-primary clsbtnSelectAppCustomer"
                style="width: 18px; cursor: hand; font-family: Webdings; height: 17px" type="button"
                value="2" title="载入客户信息" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Company Name
            </td>
            <td colspan="3">
                <input id="txtAppCompanyName" runat="server" class="clstxtAppCompanyName" maxlength="255"
                    name="txtAppCompanyName" style="width: 525px" type="text" readonly="readonly" />
                <asp:Label ID="lblAppStar" runat="server" Width="15px" ForeColor="Red" Visible="false">★</asp:Label>
                <asp:Image ID="ImgAPPDames" runat="server" Visible="false" ImageUrl="~/Style/images/Outlook[1].gif" />
                <asp:Label ID="lblAppUE" runat="server" ForeColor="Red" Visible="false" Font-Bold="true">Pending UE</asp:Label>
            </td>
        </tr>
        <tr>
            <td>Customer ID
            </td>
            <td>
                <input id="txtAppCustomerID" runat="server" class="clstxtAppCustomerID" maxlength="50"
                    name="txtAppCustomerID" type="text" />
            </td>
            <td>Province
            </td>
            <td>
                <input id="txtAppProvince" runat="server" class="clstxtAppProvince" maxlength="50"
                    name="txtAppProvince" type="text" />
            </td>
        </tr>
        <tr>
            <td>City
            </td>
            <td>
                <input id="txtAppCity" runat="server" class="clstxtAppCity" maxlength="50"
                    name="txtAppCity" type="text" />
            </td>
            <td>VIP Type
            </td>
            <td>
                <select name="cboAppCustomerType" class="clscboAppCustomerType" id="cboAppCustomerType"
                    runat="server">
                </select>
            </td>
        </tr>
        <tr>
            <td>Contact Person
            </td>
            <td>
                <input id="txtAppContactName" runat="server" class="clstxtAppContactName" maxlength="50"
                    name="txtAppContactName" type="text" />
            </td>
            <td>Tel
            </td>
            <td>
                <input id="txtAppTel" runat="server" class="clstxtAppTel" maxlength="50"
                    name="txtAppTel" type="text" />
            </td>
        </tr>
        <tr>
            <td>Fax
            </td>
            <td>
                <input id="txtAppFax" runat="server" class="clstxtAppFax" maxlength="50"
                    name="txtAppFax" type="text" />
            </td>
            <td>Mobile
            </td>
            <td>
                <input id="txtAppMobile" runat="server" class="clstxtAppMobile" maxlength="50"
                    name="txtAppMobile" type="text" />
            </td>
        </tr>
        <tr>
            <td>Address
            </td>
            <td colspan="3">
                <input id="txtAppAddress" runat="server" class="clstxtAppAddress" maxlength="255"
                    name="txtAppAddress" style="width: 525px" type="text" />
            </td>
        </tr>
        <tr>
            <td>Sub Office
            </td>
            <td>
                <input id="txtAppSubOffice" runat="server" class="clstxtAppSubOffice" maxlength="50"
                    name="txtAppSubOffice" type="text" />
            </td>
            <td>Post Code
            </td>
            <td>
                <input id="txtAppPostCode" runat="server" class="clstxtAppPostCode" maxlength="50"
                    name="txtAppPostCode" type="text" />
            </td>
        </tr>
        <tr>
            <td>Email
            </td>
            <td>
                <input id="txtAppEmail" runat="server" class="clstxtAppEmail" maxlength="255"
                    name="txtAppEmail" type="text" />
            </td>
            <td>VIP ID
            </td>
            <td>
                <input id="txtAppVIPID" runat="server" class="clstxtAppVIPID" type="text" />
            </td>
        </tr>
        <tr>
            <td>Country
            </td>
            <td>
                <input id="txtAppCountry" runat="server" class="clstxtAppCountry" maxlength="255"
                    name="txtAppCountry" type="text" />
            </td>
            <td>Branch
            </td>
            <td>
                <select id="cboAppBranch" runat="server" class="clscboAppBranch" name="cboAppBranch">
                </select>
            </td>
        </tr>
        <tr>
            <td>IsGroupDamex
            </td>
            <td>
                <asp:DropDownList ID="cboAppIsGroupDamex" runat="server" CssClass="clscboAppIsGroupDamex"
                    Enabled="false">
                    <asp:ListItem Value="0">No</asp:ListItem>
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>SFAE VIPID</td>
            <td>
                <input id="txtAppSFAEVIPID" runat="server" class="clstxtAppSFAEVIPID"
                    type="text" />
            </td>
        </tr>
        <tr>
            <td bgcolor="#EBF2FA" colspan="4" height="25" nowrap="nowrap" style="border-top: #dddddd 1px solid; border-bottom: #dddddd 1px solid"><b>最终用户信息</b>
                <input id="btnSelectEndCustomer" class="btn btn-primary clsbtnSelectEndCustomer" style="width: 18px; cursor: hand; font-family: Webdings; height: 17px"
                    type="button" value="2" runat="server" />
                <input id="btnClearEndUser" type="button" value="Clear EndUser" class="btn btn-primary clsbtnClearEndUser" />
            </td>
        </tr>
        <tr>
            <td>Company Name
            </td>
            <td colspan="3">
                <input id="txtEnduserCompanyName" runat="server" class="clstxtEnduserCompanyName"
                    maxlength="255" name="txtEnduserCompanyName" style="width: 525px" type="text" readonly="readonly" />
                <asp:Label ID="lblEndStar" runat="server" Width="15px" ForeColor="Red" Visible="false">★</asp:Label>
                <asp:Image ID="ImgEndDemax" runat="server" Visible="false" ImageUrl="~/Style/images/Outlook[1].gif" />
                <asp:Label ID="lblEndUE" runat="server" ForeColor="Red" Visible="false" Font-Bold="true">Pending UE</asp:Label>
            </td>
        </tr>
        <tr>
            <td>Customer ID
            </td>
            <td>
                <input id="txtEnduserCustomerID" runat="server" class="clstxtEnduserCustomerID"
                    maxlength="50" name="txtEnduserCustomerID" type="text" />
            </td>
            <td>Province
            </td>
            <td>
                <input id="txtEnduserProvince" runat="server" class="clstxtEnduserProvince" maxlength="50"
                    name="txtEnduserProvince" type="text" />
            </td>
        </tr>
        <tr>
            <td>City
            </td>
            <td>
                <input id="txtEnduserCity" runat="server" class="clstxtEnduserCity" maxlength="50"
                    name="txtEnduserCity" type="text" />
            </td>
            <td>VIP Type
            </td>
            <td>
                <select id="cboEnduserCustomerType" runat="server" class="clscboEnduserCustomerType"
                    name="cboEnduserCustomerType">
                </select>
            </td>
        </tr>
        <tr>
            <td>Contact Person
            </td>
            <td>
                <input id="txtEnduserContactName" runat="server" class="clstxtEnduserContactName"
                    maxlength="50" name="txtEnduserContactName" type="text" />
            </td>
            <td>Tel
            </td>
            <td>
                <input id="txtEnduserTel" runat="server" class="clstxtEnduserTel" maxlength="50"
                    name="txtEnduserTel" type="text" />
            </td>
        </tr>
        <tr>
            <td>Fax
            </td>
            <td>
                <input id="txtEnduserFax" runat="server" class="clstxtEnduserFax" maxlength="50"
                    name="txtEnduserFax" type="text" />
            </td>
            <td>Mobile
            </td>
            <td>
                <input id="txtEnduserMobile" runat="server" class="clstxtEnduserMobile" maxlength="50"
                    name="txtEnduserMobile" type="text" />
            </td>
        </tr>
        <tr>
            <td>Address
            </td>
            <td colspan="3">
                <input id="txtEnduserAddress" runat="server" class="clstxtEnduserAddress" maxlength="255"
                    name="txtEnduserAddress" style="width: 525px" type="text" />
            </td>
        </tr>
        <tr>
            <td>Sub Office
            </td>
            <td>
                <input id="txtEnduserSubOffice" runat="server" class="clstxtEnduserSubOffice" maxlength="50"
                    name="txtEnduserSubOffice" type="text" />
            </td>
            <td>Post Code
            </td>
            <td>
                <input id="txtEnduserPostCode" runat="server" class="clstxtEnduserPostCode" maxlength="50"
                    name="txtEnduserPostCode" type="text" />
            </td>
        </tr>
        <tr>
            <td>Email
            </td>
            <td>
                <input id="txtEnduserEmail" runat="server" class="clstxtEnduserEmail" maxlength="255"
                    name="txtEnduserEmail" type="text" />
            </td>
            <td>VIP ID
            </td>
            <td>
                <input id="txtEnduserVIPID" runat="server" class="clstxtEnduserVIPID" type="text" />
            </td>
        </tr>
        <tr>
            <td>Country
            </td>
            <td>
                <input id="txtEnduserCountry" runat="server" class="clstxtEnduserCountry" maxlength="255"
                    name="txtEnduserCountry" type="text" />
            </td>
            <td>Branch
            </td>
            <td>
                <select id="cboEnduserBranch" runat="server" class="clscboEnduserBranch" name="cboEnduserBranch">
                </select>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #dddddd 1px solid">IsGroupDamex
            </td>
            <td style="border-bottom: #dddddd 1px solid">
                <asp:DropDownList ID="cboEndIsGroupDamex" runat="server" CssClass="clscboEndIsGroupDamex"
                    Enabled="false">
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="border-bottom: #dddddd 1px solid">&nbsp;
            </td>
            <td style="border-bottom: #dddddd 1px solid">&nbsp;
            </td>
        </tr>
        <tr id="trMC1" runat="server" class="clstrMC1">
            <td nowrap="nowrap" style="width: 113px; height: 25px;">Machine Manufacturer
            </td>
            <td>
                <input name="txtMachineManufacturer" type="text" class="clstxtMachineManufacturer"
                    id="txtMachineManufacturer" maxlength="50" runat="server" />
            </td>
            <td nowrap="nowrap" style="height: 25px">Type Of Machine
            </td>
            <td>
                <input name="txtTypeOfMachine" type="text" class="clstxtTypeOfMachine" id="txtTypeOfMachine"
                    maxlength="50" runat="server" />
            </td>
        </tr>
        <tr id="trMC2" runat="server" class="clstrMC2">
            <td nowrap="nowrap" style="width: 113px">Machine Serial No.
            </td>
            <td>
                <input name="txtMachineSerialNo" type="text" class="clstxtMachineSerialNo" id="txtMachineSerialNo"
                    maxlength="50" runat="server" />
            </td>
            <td nowrap="nowrap">Controller Type
            </td>
            <td>
                <input name="txtControllerType" type="text" class="clstxtControllerType" id="txtControllerType"
                    maxlength="50" runat="server" />
            </td>
        </tr>
        <tr id="trMC3" runat="server" class="clstrMC3">
            <td nowrap="nowrap" style="width: 113px;">Driver Type
            </td>
            <td>
                <input name="txtDriverType" type="text" class="clstxtDriverType" id="txtDriverType"
                    maxlength="50" runat="server" />
            </td>
            <td nowrap="nowrap">Software Version
            </td>
            <td>
                <input name="txtSoftwareVersion" type="text" class="clstxtSoftwareVersion" id="txtSoftwareVersion"
                    maxlength="50" runat="server" />
            </td>
        </tr>
        <tr id="trMC4" runat="server" class="clstrMC4">
            <td nowrap="nowrap">Processing Technology
            </td>
            <td>
                <input name="txtProcessingTechnology" type="text" class="clstxtProcessingTechnology"
                    id="txtProcessingTechnology" maxlength="100" runat="server" />
            </td>
            <td nowrap="nowrap">If Down
            </td>
            <td>
                <input id="chkifdown" type="checkbox" runat="server" class="clschkifdown" />
            </td>
        </tr>
        <tr id="trMC5" runat="server" class="clstrMC5">
            <td nowrap="nowrap">RSCNo
            </td>
            <td>
                <input name="txtRSCNo" type="text" class="clstxtRSCNo" id="txtRSCNo"
                    runat="server" />
            </td>
            <td nowrap="nowrap">LocalRSCNo
            </td>
            <td>
                <input name="txtLocalRSCNo" type="text" class="clstxtLocalRSCNo" id="txtLocalRSCNo"
                    runat="server" />
            </td>
        </tr>


        <tr>
            <td bgcolor="#EBF2FA" colspan="1" nowrap="nowrap" style="border-top: #dddddd 1px solid; border-bottom: #dddddd 1px solid"><b>Delivery Info</b>

            </td>
            <td colspan="3">
                <select id="cboDeliveryType" class="clscboDeliveryType" name="cboDeliveryType" runat="Server">
                    <option value=""></option>
                    <option value="Applicant">Applicant</option>
                    <option value="Enduser">Enduser</option>
                </select>
                <input id="btnCopyDeliveryInfo" type="button" value="Copy Delivery Info"
                    class="clsbtnCopyDeliveryInfo btn btn-primary" />
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap">ReceiveCompany</td>
            <td>
                <input id="txtReceiveCompany" runat="server" class="clstxtReceiveCompany" maxlength="255"
                    name="txtReceiveCompany" type="text" /></td>
            <td nowrap="nowrap">Receiver</td>
            <td>
                <input id="txtReceiver" runat="server" class="clstxtReceiver" maxlength="255"
                    name="txtReceiver" type="text" />
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap">Receiver Tel</td>
            <td>
                <input id="txtReceiverTel" runat="server" class="clstxtReceiverTel" maxlength="255"
                    name="txtReceiverTel" type="text" /></td>
            <td nowrap="nowrap">Receiver Address</td>
            <td>
                <input id="txtReceiverAddress" runat="server" class="clstxtReceiverAddress" maxlength="255"
                    name="txtReceiverAddress" type="text" />
            </td>
        </tr>


        <tr>
            <td nowrap="nowrap">Case Created Time
            </td>
            <td colspan="3">
                <input type="text" id="dtpCaseTime" runat="server" class="clsdtpCaseTime" />
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap">Text
            </td>
            <td colspan="3">
                <textarea id="txtText" runat="server" class="clstxtText" name="txtText" style="width: 525px; height: 60px"></textarea>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap">CallAgent Comments
            </td>
            <td colspan="3">
                <textarea id="txtCallagentComments" runat="server" class="clstxtCallagentComments" name="txtCallagentComments" style="width: 525px; height: 60px"></textarea>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap">Upload File
            </td>
            <td colspan="3">
                <table width="100%" border="0" cellspacing="0" cellpadding="2">
                    <tr>
                        <td>
                            <input id="fileToUpload" type="file" name="fileToUpload" class="clsfileToUpload" style="border: 1px #dddddd solid; background-color: #ffffff;" />
                            <input id="btnUploadfile" type="button" class="btn btn-primary clsbtnUploadfile" value="Upload file"  limitCode="51002"  runat="server" />
                            <input id="btnDeletefile" type="button" class="btn btn-primary clsbtnDeletefile" value="Delete File"   limitCode="51002"  runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td id="tdAttachmentlist" class="clstdAttachmentlist" runat="server">&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>Modify User
            </td>
            <td>
                <input id="txtModifyUser" runat="server" class="clstxtModifyUser" disabled="disabled"
                    maxlength="50" name="txtCreateUser" type="text" />
            </td>
            <td>Modify Date
            </td>
            <td>
                <input id="txtModifyDate" runat="server" class="clstxtModifyDate" disabled="disabled"
                    maxlength="20" name="txtModifyDate" type="text" />
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap"></td>
            <td>
                <input id="btnSave" class="btn btn-primary clsbtnSave" name="btnSave"
                    type="button" value="Save" runat="server"  limitCode="51002"  />
                <input id="btnSubmit" class="btn btn-primary clsbtnSubmit" name="btnSubmit"
                    type="button" value="Submit" runat="server"  limitCode="51002"  />
            </td>
            <td nowrap="nowrap"></td>
            <td></td>
        </tr>
    </table>

</asp:Content>
