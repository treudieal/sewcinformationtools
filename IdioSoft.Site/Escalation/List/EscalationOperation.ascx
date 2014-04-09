<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EscalationOperation.ascx.cs" Inherits="IdioSoft.Site.Escalation.List.EscalationOperation" %>
<style>
    #tblOperation td {
        padding: 2px;
    }

    .clsNumber {
        width: 160px !important;
    }
</style>

<div id="divOperation">


    <div style="margin-right: 2px; margin-top: 2px;" id="divRealOperation">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" id="tblOperation">
            <tr>
                <td colspan="2">
                    <input type="button" name="btnModify" id="btnModify" value="Modify" class="btn-info clsModify" limitcode="60006" runat="server" />
                    <input type="button" name="btnSave" id="btnSave" value="Save" class="btn-primary clsSave" limitcode="60006" runat="server" />
                    <input type="button" name="btnDelete" id="btnDelete" value="Delete" class="btn-danger clsDelete" limitcode="60006" runat="server" /></td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="500" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>ER Number:</td>
                            <td>
                                <input type="text" name="txtERNo" id="txtERNo" class="clstxtERNo" runat="server" /></td>
                            <td>SR Number</td>
                            <td>
                                <input type="text" name="txtSRNo" id="txtSRNo" class="clstxtSRNo" runat="server" style="width:120px;" /><input type="button" name="btnLoadSR" id="btnLoadSR" value="LoadSR" class="btn-info clsLoadSR" runat="server" limitcode="60006"  /></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 10px;"></td>
                        </tr>
                        <tr>
                            <td colspan="4" bgcolor="#dddddd">SR Information</td>
                        </tr>
                        <tr>
                            <td>AppCompany</td>
                            <td colspan="3">
                                <input type="text" name="txtAppCompany" id="txtAppCompany" class="clstxtAppCompany" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>EndUser</td>
                            <td colspan="3">
                                <input type="text" name="txtEndUser" id="txtEndUser" class="clstxtEndUser" runat="server" /></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 10px;"></td>
                        </tr>
                        <tr>
                            <td colspan="4" bgcolor="#DDDDDD">ER Information</td>
                        </tr>
                        <tr>
                            <td>Contact</td>
                            <td colspan="3">
                                <input type="text" name="txtContact" id="txtContact" class="clstxtContact" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>OC</td>
                            <td colspan="3">
                                <input type="text" name="txtOC" id="txtOC" class="clstxtOC" runat="server" /></td>
                        </tr>
                        <tr>
                            <td colspan="4">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4" bgcolor="#DDDDDD">Product Information</td>
                        </tr>
                        <tr>
                            <td>ProductDesc</td>
                            <td colspan="3">
                                <input type="text" name="txtProductDesc" id="txtProductDesc" class="clstxtProductDesc" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>MLFB</td>
                            <td colspan="3">
                                <input type="text" name="txtMLFB" id="txtMLFB" class="clstxtMLFB" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>S/N</td>
                            <td colspan="3">
                                <input type="text" name="txtSN" id="txtSN" class="clstxtSN" runat="server" /></td>
                        </tr>
                    </table>
                </td>
                <td width="80%" valign="top">
                    <table width="400" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td colspan="2" bgcolor="#DDDDDD">Description</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 10px;"></td>
                        </tr>
                        <tr>
                            <td>Abstract</td>
                            <td>
                                <input type="text" name="txtAbstract" id="txtAbstract" class="clstxtAbstract" runat="server" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <textarea name="txtRemark" id="txtRemark" cols="45" rows="5" style="width: 400px" class="clstxtRemark" runat="server"></textarea></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 10px;"></td>
                        </tr>
                        <tr>
                            <td colspan="2" bgcolor="#DDDDDD">Status and Ownership</td>
                        </tr>
                        <tr>
                            <td>Status</td>
                            <td>
                                <select name="cboStatus" id="cboStatus" class="clscboStatus" runat="server">
                                    <option value="Open">Open</option>
                                    <option value="InProcess">InProcess</option>
                                    <option value="Pending">Pending</option>
                                    <option value="Finish">Finish</option>
                                </select></td>
                        </tr>
                        <tr>
                            <td>Type</td>
                            <td>
                                <select name="cboType" id="cboType" class="clscboType" runat="server">
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td>Priority</td>
                            <td>
                                <select name="cboPriority" id="cboPriority" class="clscboPriority" runat="server">
                                </select></td>
                        </tr>
                        <tr>
                            <td>Owner</td>
                            <td>
                                <select name="cboOwner" id="cboOwner" class="clscboOwner" runat="server">
                                </select></td>
                        </tr>
                        <tr>
                            <td>Date created</td>
                            <td>
                                <input type="text" name="dtpCreatedDate" id="dtpCreatedDate" class="clsdtpCreatedDate dtpTime" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>EscalationBy</td>
                            <td>
                                <input type="text" name="txtEscalationBy" id="txtEscalationBy" class="clstxtEscalationBy" runat="server" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>

    <div class="ui-state-default ui-corner-bottom" style="padding: 2px; margin-right: 2px;">
        <span>Current Operation: </span><span id="spanOperationTitle">View</span>
    </div>
</div>

<script type="text/javascript" src="../../JsLibrary/Escalation/List/CommonOperation.js"></script>
