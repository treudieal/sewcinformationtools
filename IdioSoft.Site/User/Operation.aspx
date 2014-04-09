<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Operation.aspx.cs" Inherits="IdioSoft.Site.User.Operation" MasterPageFile="~/Master/Csite/Pop.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript" src="../../JsLibrary/User/JsUser-operation.js"></script>
    <table border="0" id="tblOperation" style="width:100%;">
        <tr>
            <td>Email</td>
            <td>
                <input type="text" name="txtEmail" id="txtEmail" runat="Server" class="clstxtEmail" /></td>
            <td>Password</td>
            <td>
                <input type="password" name="txtPassword" id="txtPassword" runat="Server" class="clstxtPassword" />
                <input type="hidden" value="" runat="server" id="hidPassword" class="clshidPassword" />
            </td>
        </tr>
        <tr>
            <td>En User Name</td>
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
                <select name="cboRegion" id="cboRegion" runat="server" class="clscboRegion">
                </select>
            </td>
            <td>Service Provider
            </td>
            <td>
                <select name="cboServiceProvider" class="clscboServiceProvider" id="cboServiceProvider"
                    runat="server">
                </select>
            </td>
        </tr>
        <tr>
            <td>Is Engineer
            </td>
            <td>
                <input name="chkEngineer" type="checkbox" id="chkEngineer" value="1" runat="server" class="clschkEngineer" /></td>
            <td>Distributors</td>
            <td>
                <select name="cboDistributors" class="clscboDistributors" id="cboDistributors"
                    runat="server">
                </select>
            </td>
        </tr>
        <tr>
            <td>DefaultPage</td>
            <td>
                <asp:DropDownList ID="DdlDefaultpage" runat="server" CssClass="clsDdlDefaultpage">
                </asp:DropDownList></td>
            <td>stockNo</td>
            <td>
                <input name="txtStockNo" type="text" class="clstxtStockNo" id="txtStockNo"
                    maxlength="50" style="width: 200px" runat="server" /></td>
        </tr>
        <tr>
            <td>SfaeSpareSalesBU</td>
            <td colspan="3">
                <asp:CheckBoxList ID="chkSfaeSpareSalesBU" runat="server" RepeatColumns="6" CssClass="clschkSfaeSpareSalesBU">
                </asp:CheckBoxList></td>
        </tr>
        <tr>
            <td>SIAS Repair Category Type</td>
            <td colspan="3">
                <asp:CheckBoxList ID="chkSIASRepairCategoryType" runat="server" RepeatColumns="6" CssClass="clschkSIASRepairCategoryType">
                </asp:CheckBoxList></td>
        </tr>
        <tr>
            <td>ModuleLimited</td>
            <td colspan="3">
                <asp:CheckBoxList ID="chkListModuleLimited" runat="server" RepeatColumns="6" CssClass="clschkListModuleLimited">
                </asp:CheckBoxList></td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center;">
                <button class="btn" data-dismiss="modal">Close</button>
                <input id="btnSave" type="button" class="btn btn-primary" value="Save changes" />
            </td>
        </tr>
    </table>
    <div style="overflow: scroll; border: 1px #dddddd solid; background-color: White; width: 100%; height: 255px"
        class="idio_ScroolStyle" id="divGrid" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="2">
            <tr>
                <td bgcolor="#e0e0e0" style="padding-right: 4px; padding-left: 4px; padding-bottom: 4px; padding-top: 4px;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="2" style="border-bottom: #999999 1px solid">
                        <tr>
                            <td nowrap style="width: 160px">
                                <img src="../../Style/images/sorticon.gif" width="22" height="22" />System Permission
                                                    List
                            </td>
                            <td align="right" nowrap style="text-align: right;"></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="4">
                        <tr id="trLimit" runat="server" name="trLimit">
                            <td nowrap>
                                <asp:CheckBoxList ID="chkListSystemLimited" runat="server" RepeatColumns="4" Width="100%">
                                </asp:CheckBoxList></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="2" style="border-bottom: #999999 1px solid">
                        <tr>
                            <td nowrap bgcolor="#e0e0e0" style="width: 160px">
                                <img src="../../Style/images/sorticon.gif" width="22" height="22" />Duty Permission List
                            </td>
                            <td align="right" nowrap bgcolor="#e0e0e0" style="text-align: right;"></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="trDuty" runat="server" name="trDuty">
                <td valign="top">
                    <asp:CheckBoxList ID="chkListDutyLimited" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList></td>
            </tr>
        </table>
    </div>
</asp:Content>


