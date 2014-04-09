<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestPrintTemplate.aspx.cs" Inherits="IdioSoft.Site.SEWC.Request.RequestPrintTemplate" MasterPageFile="~/Master/Csite/Pop.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript" src="../../Scripts/jquery-ui.js"></script>
    <script type="text/javascript">
        var PuRequestIDs = "<%=PuRequestIDs%>";
    </script>
    <script type="text/javascript" src="../../JsLibrary/SEWC/Request/RequestPrintTemplate.js"></script>
    <table id="tblOperation" width="100%" border="0" cellspacing="0" cellpadding="2" style="border: 1px #136891 solid">
        <tr>
            <td height="25" bgcolor="#CCE9F7" style="border-bottom: 1px #999999 solid">Select template</td>
        </tr>
        <tr>
            <td>
                <asp:ListBox ID="lstTemp" runat="server" CssClass="clslstTemp" Height="100px"
                    Width="100%"></asp:ListBox></td>
        </tr>
        <tr>
            <td valign="top">
                <input id="btnPrint" class="btn btn-primary" name="btnPrint" type="button" value="Print"  />
                <input id="btnClose" class="btn btn-primary" name="btnClose" type="button" value="Close" />
                <input id="btnPrintXml" class="btn btn-primary" name="btnPrintXml" type="button" value="Send Fax" /></td>
        </tr>
    </table>
</asp:Content>
