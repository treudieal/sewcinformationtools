<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IssueRepairOrderOperation.aspx.cs" Inherits="IdioSoft.Site.SEWC.IssueRepairOrder.IssueRepairOrderOperation" MasterPageFile="~/Master/Csite/Pop.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../../Scripts/jQuery-Timepicker-Addon/jquery-ui-timepicker-addon.css" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="../../Scripts/jQuery-Timepicker-Addon/jquery-ui-timepicker-addon.js"></script>
    <script type="text/javascript">
        var PuRequestIDs = "<%=PuRequestIDs%>";
 
    </script>
    <script type="text/javascript" src="../../JsLibrary/SEWC/IssueRepairOrder/IssueRepairOrderOperation.js"></script>
    <table border="0" id="tblOperation" style="width: 100%;">
        <tr>
            <td class="TitleColor">RequestID</td>
            <td>
                <input name="txtRequestID" type="text" id="txtRequestID" runat="server" class="clstxtRequestID" disabled="disabled" /></td>
            <td class="TitleColor">ServiceType</td>
            <td style="width: 90%">
                <select name="cboServiceType" class="clscboServiceType" id="cboServiceType"
                    runat="server">
                </select></td>
        </tr>
        <tr>
            <td class="TitleColor">MLFB</td>
            <td>
                <input name="txtMLFB" type="text" id="txtMLFB" runat="server" class="clstxtMLFB" />
            </td>
            <td class="TitleColor">SerialNo</td>
            <td>
                <input name="txtSerialNo" type="text" id="txtSerialNo" runat="server" class="clstxtSerialNo" />
            </td>
        </tr>
        <tr>
            <td class="TitleColor">Qty</td>
            <td>
                <input name="txtQty" type="text" id="txtQty" runat="server" class="clstxtQty" />
            </td>
            <td class="TitleColor">OrderType</td>
            <td>
                <select name="cboOrderType" class="clscboOrderType" id="cboOrderType"
                    runat="server">
                </select></td>
        </tr>
        <tr>
            <td class="TitleColor">Warranty</td>
            <td>
                <select name="cboWarranty" class="clscboWarranty" id="cboWarranty"
                    runat="server">
                </select></td>
            <td class="TitleColor">ReceiveDefectiveDate(T3)</td>
            <td>
                <input name="txtReceiveDefectiveDate" type="text" id="txtReceiveDefectiveDate" runat="server" class="clstxtReceiveDefectiveDate" disabled="disabled" />
            </td>
        </tr>
        <tr id="trDate" runat="server" class="clstrDate">
            <td class="TitleColor">ReveiveBankReceipt</td>
            <td>
                <input name="chkIsReveiveBankReceipt" type="checkbox" id="chkIsReveiveBankReceipt" value="1" runat="server" class="clschkIsReveiveBankReceipt" />

            </td>
            <td class="TitleColor"></td>
            <td></td>
        </tr>
        <tr id="trGoodWill" runat="server" class="clstrGoodWill">
            <td class="TitleColor">IsGoodWill</td>
            <td>
                <input name="chkIsGoodWill" type="checkbox" id="chkIsGoodWill" value="1" runat="server" class="clschkIsGoodWill" /></td>
            <td class="TitleColor">GoodWillNo</td>
            <td>
                <input name="txtGoodWillNo" type="text" id="txtGoodWillNo" runat="server" class="clstxtGoodWillNo" />
            </td>
        </tr>
        <tr id="trRepairble" runat="server" class="clstrRepairble">
            <td class="TitleColor">Repairble</td>
            <td>
                <asp:DropDownList ID="cboRepairble" runat="server" CssClass="clscboRepairble">
                    <asp:ListItem Value=""> </asp:ListItem>
                    <asp:ListItem Value="Y">Y</asp:ListItem>
                    <asp:ListItem Value="N">N</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="TitleColor">CustomerConfirmDate(T3*)</td>
            <td>
                <input type="text" id="dtpCustomerConfirmDate" class="dtpCustomerConfirmDate dtpTime" runat="server" value="" />
            </td>
        </tr>
        <tr>
            <td class="TitleColor">IssueRepairOrderDate(T4)</td>
            <td>
                <input type="text" id="dtpIssueRepairOrderDate" class="dtpIssueRepairOrderDate dtpTime" runat="server" value="" />
            </td>
            <td>Total Price
            </td>
            <td>
                <input id="chkOneTotalPrice" class="clschkOneTotalPrice" type="checkbox" runat="server" /><input type="text" id="txtTotalPrice" class="clstxtTotalPrice" runat="server" value="" disabled="disabled" style="width: 180px;" /></td>
        </tr>
        <tr id="trCancelDate" runat="server" style="display: none;" class="clstrCancelDate">
            <td class="TitleColor">CancelDate</td>
            <td>
                <input id="dtpCancelDate" type="text" class="dtpCancelDate dtpTime" runat="server" value="" /></td>
            <td></td>
            <td></td>
        </tr>
        <tr id="trCancelReason" runat="server" style="display: none;" class="clstrCancelReason">
            <td class="TitleColor">CancelReason</td>
            <td colspan="3">
                <textarea id="txtCancelReason" runat="server" rows="5" class="clstxtCancelReason" style="width: 400px;"></textarea>
            </td>
        </tr>

        <tr id="trQuotation" runat="server" class="clstrQuotation" style="display: none;">
            <td colspan="3" valign="top" id="tdQuotation" class="clstdQuotation" runat="server"></td>
            <td style="vertical-align: top;">QuotationDate<br />
                <input type="text" id="dtpQuotationDate" class="dtpQuotationDate" runat="server" value="" disabled="disabled" />
            </td>
        </tr>
        <tr id="trSendMail" runat="Server" class="clstrSendMail" style="display: none;">
            <td colspan="4">
                <input id="btnSendMail" name="btnSendMail" type="button" value="Send Repair Quotation Mail" class="btn btn-primary clsbtnSendMail" runat="server" limitcode="53002" />
                <input id="btnSendTest" name="btnSendTest" type="button" value="Send Test Mail" class="btn btn-primary clsbtnSendTest" runat="server" limitcode="53002" />
            </td>
        </tr>
        <tr id="trSendCancelMail" runat="Server" class="clstrSendCancelMail" style="display: none;">
            <td colspan="4">
                <input id="Button1" name="btnSendCancelMail" type="button" value="Send Cancel Email to SLC" class="btn btn-primary clsbtnSendCancelMail" runat="server" limitcode="53002" />
            </td>
        </tr>
        <tr>
            <td colspan="3"></td>
            <td>
                <input id="btnSave" type="button" class="btn btn-primary btnSave" value="Save" runat="server" limitcode="53002" />
                <input id="btnSubmit" type="button" class="btn btn-primary btnSubmit" value="Submit" runat="server" limitcode="53002" />
                <input id="btnReport" type="button" class="btn btn-primary" value="Report" />
                <input id="btnQuotation" type="button" class="btn btn-primary clsbtnQuotation" value="Quotation" style="display: none;" runat="server" runat="server" limitcode="53002" />
            </td>
        </tr>
    </table>
</asp:Content>
