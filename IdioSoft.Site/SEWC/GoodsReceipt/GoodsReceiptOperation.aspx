<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsReceiptOperation.aspx.cs" Inherits="IdioSoft.Site.SEWC.GoodsReceipt.GoodsReceiptOperation" MasterPageFile="~/Master/Csite/Pop.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../../Scripts/jQuery-Timepicker-Addon/jquery-ui-timepicker-addon.css" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="../../Scripts/jQuery-Timepicker-Addon/jquery-ui-timepicker-addon.js"></script>
    <script type="text/javascript" src="../../Scripts/ajaxfileupload.js"></script>
    <script type='text/javascript' src='../../jquery-autocomplete/jquery.autocomplete.js'></script>
    <link rel="stylesheet" type="text/css" href="../../jquery-autocomplete/jquery.autocomplete.css" />
    <script type="text/javascript">
        var PuRequestIDs = "<%=PuRequestIDs%>";
    </script>
    <script type="text/javascript" src="../../JsLibrary/SEWC/GoodsReceipt/GoodsReceiptOperation.js"></script>
    <table border="0" id="tblOperation" style="width: 100%;">
        <tr>
            <td class="TitleColor">Warranty</td>
            <td>
                <select name="cboWarranty" class="clscboWarranty" id="cboWarranty" 
                    runat="server">
                </select>
            </td>
            <td class="TitleColor">ReceiveDefectiveDate(T3)</td>
            <td style="width:80%;">
                <input type="text" id="dtpReceiveDefectiveDate" class="dtpReceiveDefectiveDate dtpTime" runat="server" value="" />
            </td>
        </tr>
        <tr>
            <td class="TitleColor">ProductName</td>
            <td>
                <select name="cboProductName" class="clsProductName" id="cboProductName"
                    runat="server">
                </select>
            </td>
            <td class="TitleColor">ProductDesc</td>
            <td>
                <select name="cboProductDesc" class="clsProductDesc" id="cboProductDesc"
                    runat="server">
                </select></td>
        </tr>
        <tr>
            <td class="TitleColor">MLFB</td>
            <td>
               <input name="txtMLFB" type="text" id="txtMLFB" runat="server" class="clstxtMLFB" /></td>
            <td class="TitleColor">ServiceType</td>
            <td>
                <select name="cboServiceType" class="clscboServiceType" id="cboServiceType"
                    runat="server" disabled="disabled">

                </select></td>
        </tr>
        <tr>
            <td class="TitleColor">SerialNo</td>
            <td>
                <input name="txtSerialNo" type="text" id="txtSerialNo" runat="server" class="clstxtSerialNo"/>
            </td>
            <td class="TitleColor">Qty</td>
            <td>
                <input name="txtQty" type="text" id="txtQty" runat="server" class="clstxtQty" />
            </td>
        </tr>
        <tr>
            <td class="TitleColor">Is Reject
            </td>
            <td>
                <input name="chkIsReject" type="checkbox" id="chkIsReject" value="1" runat="server" class="clschkIsReject" /></td>
            <td class="TitleColor">SEWC NotificationNo</td>
            <td>
                <input name="txtSEWCNotificationNo" type="text" id="txtSEWCNotificationNo" runat="server" class="clstxtSEWCNotificationNo" /></td>
        </tr>
        <tr>
            <td class="TitleColor">FuntinalState(original)</td>
            <td>
                <input name="txtFuntinalStateoriginal" type="text" id="txtFuntinalStateoriginal" runat="server" class="clstxtFuntinalStateoriginal"/>
            </td>
            <td class="TitleColor">Firmware(original)</td>
            <td>
                <input name="txtFirmwareoriginal" type="text" id="txtFirmwareoriginal" runat="server" class="clstxtFirmwareoriginal"  />
            </td>
        </tr>

        <tr id="trRejectReason" runat="server" style="display:none;" class="clstrRejectReason">
            <td class="TitleColor">RejectReason</td>
            <td colspan="3">
                <textarea id="txtRejectReason" runat="server" class="clstxtRejectReason" style="width: 545px; height: 60px"></textarea>
            </td>
        </tr>
        <tr id="trRejectFile" runat="server" style="display: none;" class="clstrRejectFile">
            <td nowrap="nowrap" class="TitleColor">Reject File
            </td>
            <td colspan="3">
                <table width="100%" border="0" cellspacing="0" cellpadding="2">
                    <tr>
                        <td>
                            <input id="fileToUpload" type="file" size="30" name="fileToUpload" class="clsfileToUpload" style="border: 1px #dddddd solid; background-color: #ffffff" />
                            <input id="btnUploadfile" type="button" class="btn btn-primary clsbtnUploadfile" value="Upload file" runat="server"  limitCode="52002"  />
                            <input id="btnDeletefile" type="button" class="btn btn-primary clsbtnDeletefile" value="Delete File" runat="server"  limitCode="52002"  />
                        </td>
                    </tr>
                    <tr>
                        <td id="tdAttachmentlist" class="clstdAttachmentlist" runat="server">&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="trBtn" runat="server">
            <td colspan="4" style="text-align: center;">
                <input id="btnSave" type="button" class="btn btn-primary btnSave" value="Save" runat="server"  limitCode="52002"  />
                <input id="btnSubmit" type="button" class="btn btn-primary btnSubmit" value="Submit" runat="server"  limitCode="52002"  />
            </td>
        </tr>
    </table>
</asp:Content>
