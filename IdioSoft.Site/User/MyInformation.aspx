<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyInformation.aspx.cs" Inherits="IdioSoft.Site.User.MyInformation" MasterPageFile="~/Master/Csite/Pop.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript" src="../../JsLibrary/Master/JsMaster-myinformation.js"></script>
    <table border="0" id="tblOperation">
        <tr>
            <td>Email</td>
            <td>
                <input type="text" name="txtEmail" id="txtEmail" runat="Server" class="clstxtEmail" disabled="disabled" /></td>
            <td>Password</td>
            <td>
                <input type="password" name="txtPassword" id="txtPassword" runat="Server" class="clstxtPassword" />
                <input type="hidden" value="" runat="server" id="hidPassword" class="clshidPassword" />
            </td>
        </tr>
        <tr>
            <td>En User Name </td>
            <td>
                <input type="text" name="txtEnUserName" id="txtEnUserName" runat="Server" class="clstxtEnUserName" /></td>
            <td>Cn User Name</td>
            <td>
                <input type="text" name="txtCnUserName" id="txtCnUserName" runat="Server" class="clstxtCnUserName" /></td>
        </tr>
        <tr>
            <td>Tel</td>
            <td>
                <input type="text" name="txtTel" id="txtTel" runat="Server" class="clstxtTel" /></td>
            <td>Fax</td>
            <td>
                <input type="text" name="txtFax" id="txtFax" maxlength="11" runat="Server" class="clstxtFax" /></td>
        </tr>
        <tr>
            <td>Region</td>
            <td>
                <select name="cboRegion" id="cboRegion" runat="server" class="clscboRegion" disabled="disabled">
                </select>
            </td>
            <td>Service Provider </td>
            <td>
                <select name="cboServiceProvider" class="clscboServiceProvider" id="cboServiceProvider" runat="server" disabled="disabled">
                </select></td>
        </tr>
        <tr>
            <td>SetPage</td>
            <td>
                <input name="txtSetPage" type="text" class="clstxtSetPage" id="txtSetPage" style="width: 200px" runat="server" /></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: right;">
                <input id="btnClose" type="button" class="btn btn-primary" value="Close" data-dismiss="modal" />
                <input id="btnSave" type="button" class="btn btn-primary" value="Save changes" />
            </td>
        </tr>
    </table>
</asp:Content>

