<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestSenderMsg.aspx.cs" Inherits="IdioSoft.Site.SEWC.Request.RequestSenderMsg" MasterPageFile="~/Master/Csite/Pop.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript">
        var PuRequestIDs = "<%=PuRequestIDs%>";
    </script>
    <script type="text/javascript" src="../../JsLibrary/SEWC/Request/RequestSenderMsg.js"></script>
    <table id="tblOperation" border="0" style="width:100%;">
        <tr>
            <td class="tdLeftRightBottom" style="padding-right: 8px; padding-left: 8px; padding-bottom: 8px; padding-top: 8px;" valign="top">
                <table border="0" cellpadding="2" cellspacing="0" style="border-right: #136891 1px solid; border-top: #136891 1px solid; border-left: #136891 1px solid; border-bottom: #dddddd 1px solid"
                    width="100%">
                    <tr>
                        <td bgcolor="#cce9f7" style="padding-right: 4px; padding-left: 4px; padding-bottom: 4px; padding-top: 4px"
                            align="center">服务登记号:</td>
                        <td bgcolor="#cce9f7" style="padding-right: 4px; padding-left: 4px; padding-bottom: 4px; padding-top: 4px">
                            <asp:TextBox ID="txtNotificationNo" runat="server" CssClass="clstxtNotificationNo" Width="245px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="#cce9f7" style="padding-right: 4px; padding-left: 4px; padding-bottom: 4px; padding-top: 4px"
                            width="100">申请人联系电话:</td>
                        <td bgcolor="#cce9f7" style="padding-right: 4px; padding-left: 4px; padding-bottom: 4px; padding-top: 4px">
                            <asp:TextBox ID="txtAppMobile" runat="server" CssClass="clstxtAppMobile" Width="245px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="#cce9f7" style="padding-right: 4px; padding-left: 4px; padding-bottom: 4px; padding-top: 4px"
                            width="100">最终用户联系电话:</td>
                        <td bgcolor="#cce9f7" style="padding-right: 4px; padding-left: 4px; padding-bottom: 4px; padding-top: 4px">
                            <asp:TextBox ID="txtEnduserMobile" runat="server" CssClass="clstxtEnduserMobile" Width="245px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="#cce9f7" style="padding-right: 4px; padding-left: 4px; padding-bottom: 4px; padding-top: 4px"
                            width="100">内容:</td>
                        <td bgcolor="#cce9f7" style="padding-right: 4px; padding-left: 4px; padding-bottom: 4px; padding-top: 4px">
                            <select name="cboMsgTemplate" class="clscboMsgTemplate" id="cboMsgTemplate"
                                runat="server">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="#cce9f7" style="padding-right: 4px; padding-left: 4px; padding-bottom: 4px; padding-top: 4px"></td>
                        <td bgcolor="#cce9f7" style="padding-right: 4px; padding-left: 4px; padding-bottom: 4px; padding-top: 4px">
                            <textarea id="TextareaMsg" runat="server" class="clsTextareaMsg" cols="20" rows="2"
                                style="width: 245px; height: 80px"></textarea></td>
                    </tr>
                    <tr>
                        <td bgcolor="#cce9f7" style="padding-right: 4px; padding-left: 4px; padding-bottom: 4px; padding-top: 4px"></td>
                        <td bgcolor="#cce9f7" style="padding-right: 4px; padding-left: 4px; padding-bottom: 4px; padding-top: 4px">
                            <input id="btnSave" class="btn btn-primary" name="btnSave" type="button" value="Send" />
                            <input id="btnClose" class="btn btn-primary" name="btnClose" type="button" value="Close" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
