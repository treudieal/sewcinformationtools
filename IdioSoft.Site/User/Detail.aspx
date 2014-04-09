<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="IdioSoft.Site.User.Detail" MasterPageFile="~/Master/Csite/Pop.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript" src="../../JsLibrary/User/JsUser-detail.js"></script>
    <table border="0" id="tblOperation">
        <tr>
            <td  style="width:100px;">员工号</td>
            <td id="tdPersonNo" runat="server" style="width:200px;"></td>
            <td  style="width:100px;">密码</td>
            <td id="tdPassword" runat="server" style="width:200px;"></td>
        </tr>
        <tr>
            <td>用户名</td>
            <td id="tdUserName" runat="server"></td>
            <td>电子邮箱</td>
            <td id="tdEmail" runat="server"></td>
        </tr>
        <tr>
            <td>固定电话</td>
            <td id="tdTel" runat="server"></td>
            <td>移动电话</td>
            <td id="tdMobile" runat="server"></td>
        </tr>
        <tr>
            <td>角色</td>
            <td colspan="3" id="tdDuty" runat="server"></td>
        </tr>
        <tr>
            <td>分页数</td>
            <td id="tdPageSize" runat="server"></td>
            <td>是否停用</td>
            <td>
                <input type="checkbox" name="chkIsDisable" id="chkIsDisable" value="1" runat="Server" class="clschkIsDisable" disabled="disabled" /></td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: right;">
                <button class="btn" data-dismiss="modal">Close</button>
            </td>
        </tr>
    </table>
</asp:Content>
