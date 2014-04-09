<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepairOperation.aspx.cs" Inherits="IdioSoft.Site.SEWC.Repair.RepairOperation" MasterPageFile="~/Master/Csite/Pop.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../../Scripts/jQuery-Timepicker-Addon/jquery-ui-timepicker-addon.css" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="../../Scripts/jQuery-Timepicker-Addon/jquery-ui-timepicker-addon.js"></script>
    <script type="text/javascript" src="../../Scripts/ajaxfileupload.js"></script>
    <script type='text/javascript' src='../../Scripts/jquery-autocomplete/jquery.autocomplete.js'></script>
    <link rel="stylesheet" type="text/css" href="../../Scripts/jquery-autocomplete/jquery.autocomplete.css" />
    <script type="text/javascript">
        var PuRequestIDs = "<%=PuRequestIDs%>";
        var PuOperationType = "<%=OperationType%>";
    </script>
    <script type="text/javascript" src="../../JsLibrary/SEWC/Repair/RepairOperation.js"></script>
    <table border="0" id="tblOperation">
        <tr>
            <td >Request ID</td>
            <td style="width: 200px;">
                <input name="txtRequestID" type="text" id="txtRequestID" runat="server" class="clstxtRequestID" disabled="disabled" /></td>
            <td class="TitleColor">SEWC noticification no</td>
            <td>
                <input name="txtSEWCNoticificaionNo" type="text" id="txtSEWCNoticificaionNo" runat="server" class="clstxtSEWCNoticificaionNo" disabled="disabled" />
            </td>
        </tr>
        <tr>
            <td >Order Type</td>
            <td>
                <input name="txtOrderType" type="text" id="txtOrderType" runat="server" class="clstxtOrderType" disabled="disabled" /></td>
            <td class="TitleColor" style="width: 152px;"></td>
            <td></td>
        </tr>
        <tr>
            <td >TroubleDesc</td>
            <td colspan="3">
                <textarea id="txtTroubleDesc" runat="server" class="clstxtTroubleDesc" style="width: 565px; height: 60px" disabled="disabled"></textarea></td>

        </tr>
        <tr>
            <td >WorkStation Code</td>
            <td>
                <select name="cboWorkStationCode" class="clscboWorkStationCode" id="cboWorkStationCode"
                    runat="server">
                </select></td>
            <td class="TitleColor" style="width: 152px;">MLFB</td>
            <td>
                <input name="txtMLFB" type="text" id="txtMLFB" runat="server" class="clstxtMLFB" disabled="disabled" />
            </td>
        </tr>
        <tr>
            <td >SerialNo</td>
            <td>
                <input name="txtSerialNo" type="text" id="txtSerialNo" runat="server" class="clstxtSerialNo" disabled="disabled" />
            </td>
            <td class="TitleColor">Qty</td>
            <td>
                <input name="txtQty" type="text" id="txtQty" runat="server" class="clstxtQty" disabled="disabled" />
            </td>
        </tr>
        <tr>
            <td >FuntinalState(original)</td>
            <td>
                <input name="txtFuntinalStateoriginal" type="text" id="txtFuntinalStateoriginal" runat="server" class="clstxtFuntinalStateoriginal" disabled="disabled" />
            </td>
            <td class="TitleColor">FuntinalState(latest)</td>
            <td>
                <input name="txtFuntinalStatelatest" type="text" id="txtFuntinalStatelatest" runat="server" class="clstxtFuntinalStatelatest" />
            </td>
        </tr>
        <tr>
            <td >Firmware(original)</td>
            <td>
                <input name="txtFirmwareoriginal" type="text" id="txtFirmwareoriginal" runat="server" class="clstxtFirmwareoriginal" disabled="disabled" />
            </td>
            <td class="TitleColor">Firmware(latest)</td>
            <td>
                <input name="txtFirmwarelatest" type="text" id="txtFirmwarelatest" runat="server" class="clstxtFirmwarelatest" />
            </td>
        </tr>
        <tr>
            <td >Warranty</td>
            <td>
                <select name="cboWarranty" class="clscboWarranty" id="cboWarranty"
                    runat="server">
                </select>
            </td>
            <td class="TitleColor">ConfirmCompleteDate</td>
            <td>
                <input id="dtpConfirmCompleteDate" type="text" class="dtpConfirmCompleteDate dtpTime" runat="server" value="" />
            </td>
        </tr>
        <tr>
            <td >ServiceType</td>
            <td>
                <select name="cboServiceType" class="clscboServiceType" id="cboServiceType"
                    runat="server">
                </select>
            </td>
            <td class="TitleColor">Engineer</td>
            <td>
                <input name="txtEngineer" type="text" id="txtEngineer" runat="server" class="clstxtEngineer" />
            </td>
        </tr>
        <tr>
            <td >EndRepairDate(T5)</td>
            <td>
                <input id="dtpEndRepairDate" type="text" class="dtpEndRepairDate dtpTime" runat="server" value="" />
            </td>
            <td>Failure Caused Type</td>
            <td>
                <select name="cboFailureCasedType" class="clscboFailureCasedType" id="cboFailureCasedType"
                    runat="server">
                </select></td>
        </tr>
        <tr>
            <td >Repair Result</td>
            <td>
                <select name="cboRepairResult" class="clscboRepairResult" id="cboRepairResult"
                    runat="server">
                </select>
            </td>
            <td>
                Labor Cost
            </td>
            <td>
                <input name="txtLaborCost" type="text" id="txtLaborCost" runat="server" class="clstxtLaborCost" />
            </td>
        </tr>
        <tr id="trRejectFile" runat="server" style="display: none;" class="clstrRejectFile">
            <td nowrap="nowrap" >Reject File
            </td>
            <td colspan="3">
                <table width="100%" border="0" cellspacing="0" cellpadding="2">
                    <tr>
                        <td>
                            <input id="fileToUpload" type="file" size="30" name="fileToUpload" class="clsfileToUpload" style="border: 1px #dddddd solid; background-color: #ffffff" />
                            <input id="btnUploadfile" type="button" class="btn btn-primary clsbtnUploadfile" value="Upload file" runat="server" limitcode="54002" />
                            <input id="btnDeletefile" type="button" class="btn btn-primary clsbtnDeletefile" value="Delete File" runat="server" limitcode="54002" />
                        </td>
                    </tr>
                    <tr>
                        <td id="tdAttachmentlist" class="clstdAttachmentlist" runat="server">&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td >Remarks</td>
            <td colspan="3">
                <textarea id="txtRemarks" runat="server" class="clstxtRemarks" style="width: 565px; height: 60px"></textarea>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="tdItems" runat="server" id="tdIDItems" style="padding: 0px; margin: 0px;">
                <table border="0" id="tblOther" runat="server" style="margin: 0px; border-top: 0px;">
                    <tr>
                        <td class="TitleColor" style="width: 150px; border-top: 0px;">PCBA5ENo</td>
                        <td style="width: 200px; border-top: 0px;">
                            <input type="text" id="txtPCBA5ENo" name="txtPCBA5ENo" class="clstxtPCBA5ENo" runat="server" />
                        </td>
                        <td class="TitleColor" style="border-top: 0px; width: 150px">ComponentLocation</td>
                        <td style="border-top: 0px;">
                            <input type="text" class="clsComponentLocation" id="txtComponentLocation" runat="Server" />

                        </td>
                        <td rowspan="5" style="border-top: 0px;" class="auto-style2"><a href="#" class="lnkaddother" data-icon="&#xe1f4;" title="AddNew"></a>
                            <br />
                            <a href="#" class="lnkdelother" data-icon="&#xe1f3;" title="Delete" style="display: none;"></a></td>
                    </tr>
                    <tr>
                        <td class="TitleColor">RepairedComponentA5E</td>
                        <td>
                            <input type="text" id="txtRepairedComponentA5E" name="txtRepairedComponentA5E" class="clsRepairedComponentA5E" runat="server" />
                        </td>
                        <td class="TitleColor">Type</td>
                        <td>
                            <select name="cboFailureType" class="clscboFailureType" id="cboFailureType"
                                runat="server">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td class="TitleColor">Failure Kind</td>
                        <td>
                            <select name="cboFailureKind" class="clscboFailureKind" id="cboFailureKind"
                                runat="server">
                            </select>
                        </td>
                        <td class="TitleColor">F-Code</td>
                        <td>
                            <input type="text" class="clstxtFcode" runat="Server" id="txtFCode" />
                        </td>
                    </tr>
                    <tr>
                        <td class="TitleColor">RepairAction</td>
                        <td>
                            <select name="cboRepairAction" class="clscboRepairAction" id="cboRepairAction"
                                runat="server">
                            </select></td>
                        <td class="TitleColor"></td>
                        <td></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3"></td>
            <td colspan="1">
                <input id="btnSave" type="button" class="btn btn-primary btnSave" value="Save" runat="server" limitcode="54002" />
                <input id="btnSubmit" type="button" class="btn btn-primary btnSubmit" value="Submit" runat="server" limitcode="54002" />
                <input id="btnReport" type="button" class="btn btn-primary btnReport" value="Report" runat="server" />
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style1 {
            background-color: #f1f1f1;
            width: 151px;
        }

        .auto-style2 {
            width: 14px;
        }
    </style>
</asp:Content>

