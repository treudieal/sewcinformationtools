<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeliveryOperation.aspx.cs" Inherits="IdioSoft.Site.SEWC.Delivery.DeliveryOperation" MasterPageFile="~/Master/Csite/Pop.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../../Scripts/jQuery-Timepicker-Addon/jquery-ui-timepicker-addon.css" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="../../Scripts/jQuery-Timepicker-Addon/jquery-ui-timepicker-addon.js"></script>
    <script type="text/javascript">
        var PuRequestIDs = "<%=PuRequestIDs%>";
    </script>
    <script type="text/javascript" src="../../JsLibrary/SEWC/Delivery/DeliveryOperation.js"></script>
    <table border="0" id="tblOperation" style="width: 100%;">
        <tr>
            <td class="TitleColor">RequestID</td>
            <td>
                <input name="txtRequestID" type="text" id="txtRequestID" runat="server" class="clstxtRequestID" disabled="disabled" /></td>
            <td class="TitleColor">MLFB</td>
            <td style="width:90%">
                <input name="txtMLFB" type="text" id="txtMLFB" runat="server" class="clstxtMLFB" disabled="disabled" />
            </td>
        </tr>
        <tr>
            <td class="TitleColor">SerialNo</td>
            <td>
                <input name="txtSerialNo" type="text" id="txtSerialNo" runat="server" class="clstxtSerialNo" disabled="disabled" />
            </td>
            <td class="TitleColor">Qty</td>
            <td>
                <input name="txtQty" type="text" id="txtQty" runat="server" class="clstxtQty" disabled="disabled" />
            </td>
        </tr>
        <tr>
            <td class="TitleColor">Service Type</td>
            <td>
                <select id="cboServiceType" name="cboServiceType" class="clscboServiceType" disabled="disabled" runat="Server" >
                    <option value="IHR">IHR</option>
                    <option value="EXCH">EXCH</option>
                </select></td>
            <td class="TitleColor">Warranty</td>
            <td>
                 
                <select name="cboWarranty" class="clscboWarranty" id="cboWarranty"
                    runat="server">
                </select></td>
        </tr>
        <tr>
            <td class="TitleColor">Weight(Unit)</td>
            <td>
                <input name="txtWeight" type="text" id="txtWeight" runat="server" class="clstxtWeight" />
            </td>
            <td class="TitleColor">issueDNdate(T5*)</td>
            <td>
                <input name="dtpissueDNDate" type="text" id="dtpissueDNDate" runat="server" class="clsdtpissueDNDate dtpTime" />
            </td>
        </tr>

        <tr id="trNew" runat="server" class="clstrNew">
            <td class="TitleColor">New SerialNo</td>
            <td>
                  <input name="txtNewSerialNo" type="text" id="txtNewSerialNo" runat="server" class="clstxtNewSerialNo" />
            </td>
            <td class="TitleColor"></td>
            <td>
               
            </td>
        </tr>
        <tr>
            <td class="TitleColor">DeliveryDate(T6)</td>
            <td>
                <input id="dtpDeliveryDate" type="text" class="dtpDeliveryDate dtpTime" runat="server" value="" />
            </td>
            <td class="TitleColor">TrackingNo</td>
            <td>
                <input name="txtTrackingNo" type="text" id="txtTrackingNo" runat="server" class="clstxtTrackingNo" />
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" class="TitleColor">ReceiveCompany</td>
            <td>
                <input id="txtReceiveCompany" runat="server" class="clstxtReceiveCompany" maxlength="255"
                    name="txtReceiveCompany" type="text" /></td>
            <td nowrap="nowrap" class="TitleColor">Receiver</td>
            <td>
                <input id="txtReceiver" runat="server" class="clstxtReceiver" maxlength="255"
                    name="txtReceiver" type="text" />
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" class="TitleColor">Receiver Tel</td>
            <td>
                <input id="txtReceiverTel" runat="server" class="clstxtReceiverTel" maxlength="255"
                    name="txtReceiverTel" type="text" /></td>
            <td nowrap="nowrap" class="TitleColor">Receiver Address</td>
            <td>
                <input id="txtReceiverAddress" runat="server" class="clstxtReceiverAddress" maxlength="255"
                    name="txtReceiverAddress" type="text" />
            </td>
        </tr>
        <tr>
            <td colspan="3"></td>
            <td>
                <input id="btnSave" type="button" class="btn btn-primary btnSave" value="Save"  runat="server" limitCode="55002"/>
                <input id="btnSubmit" type="button" class="btn btn-primary btnSubmit" value="Submit"  runat="server" limitCode="55002"/>
                <input id="btnReport" type="button" class="btn btn-primary" value="Report" />
            </td>
        </tr>
    </table>
</asp:Content>
