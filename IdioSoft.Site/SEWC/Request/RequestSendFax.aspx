<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestSendFax.aspx.cs" Inherits="IdioSoft.Site.SEWC.Request.RequestSendFax" MasterPageFile="~/Master/Csite/Pop.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript" src="../../Scripts/jquery-ui.js"></script>
    <script type="text/javascript">
        var PuRequestIDs = "<%=PuRequestIDs%>";
        var strTmpFileName = "<%=strTmpFileName%>";
        var strTmpFileNameValue = "<%=strTmpFileNameValue%>";
    </script>
    <script type="text/javascript" src="../../JsLibrary/SEWC/Request/RequestSendFax.js"></script>
    <table id="tblOperation" width="100%" border="0" cellpadding="2" cellspacing="0" bgcolor="#FFFFFF">
        <tr>
            <td bgcolor="#cce9f7" style="border-bottom: 1px #999999 solid" nowrap="nowrap">
                <img src="../../Style/images/detailicon.gif" width="22" height="22" />Fax</td>
            <td align="right" bgcolor="#cce9f7" style="border-bottom: 1px #999999 solid">
                <asp:TextBox ID="txtLoadGridSqlstr" runat="server" Height="16px" Visible="False"></asp:TextBox>
                <asp:TextBox ID="txtParentSql" runat="server" Height="16px" Visible="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td height="57" colspan="2">
                <table width="100%" border="0" cellpadding="2" cellspacing="0" bgcolor="#FFFFFF">

                    <tr>
                        <td nowrap="nowrap">Subject</td>
                        <td>
                            <input name="txtSubject" type="text" class="clstxtSubject" id="txtSubject" maxlength="255" style="width: 160px" runat="server" /></td>
                        <td nowrap="nowrap">FaxNumber</td>
                        <td>
                            <input name="txtFaxNumber" type="text" class="clstxtFaxNumber" id="txtFaxNumber" maxlength="255" style="width: 160px" runat="server" /></td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap">Receiver</td>
                        <td>
                            <input name="txtReceiver" type="text" class="clstxtReceiver" id="txtReceiver" maxlength="255" style="width: 160px" runat="server" /></td>
                        <td nowrap="nowrap">ReceiverCompany</td>
                        <td>
                            <input name="txtReceiverCompany" type="text" class="clstxtReceiverCompany" id="txtReceiverCompany" maxlength="20" style="width: 160px" runat="server" /></td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" style="height: 18px">ReceiverTel</td>
                        <td style="height: 18px">
                            <input name="txtReceiverTel" type="text" class="clstxtReceiverTels" id="txtReceiverTel" maxlength="255" style="width: 160px" runat="server" /></td>
                        <td nowrap="nowrap" style="height: 18px"></td>
                        <td style="height: 18px"></td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" colspan="2" style="height: 18px">
                            <input id="btnSave" class="btn btn-primary" name="btnSave" type="button" value="Save" />
                            <input id="btnClose" class="btn btn-primary" name="btnClose" type="button" value="Close" /></td>
                        <td nowrap="nowrap" style="height: 18px"></td>
                        <td style="height: 18px"></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
