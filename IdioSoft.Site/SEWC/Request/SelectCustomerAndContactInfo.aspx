<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectCustomerAndContactInfo.aspx.cs" Inherits="IdioSoft.Site.SEWC.Request.SelectCustomerAndContactInfo" MasterPageFile="~/Master/Csite/Pop.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script type="text/javascript" src="../../Scripts/jquery-ui.js"></script>
    <link rel="stylesheet" type="text/css" href="../../Style/css/jquery-ui-1.9.2.custom.css" />
    <link rel="stylesheet" type="text/css" href="../../Style/css/ui.jqgrid.css" />
    <script type="text/javascript" src="../../Scripts/jquery.jqGrid.src.js"></script>
    <script type="text/javascript" src="../../Scripts/grid.locale-en.js"></script>
    <style type="text/css">
        body{
            margin:2px;
        }
    </style>
    <script type="text/javascript">
        var PuRequestIDs = "<%=PuRequestIDs%>";
        var POperationType = "<%=POperationType%>";//用来返回是App还是End的客户类型
    </script>

    <div id="divMain">
        <ul class="nav nav-tabs">
            <li class="clsSelectCustomerAndContactInfo active" id="SelectCustomerAndContactInfo"><a href="#" style="font-size:16px;">Selected </a></li>
            <li class="clsEditCustomerAndContactInfo" id="EditCustomerAndContactInfo"><a href="#" style="font-size:16px;">Edit </a></li>
        </ul>

        <div class="navbar" style="width:800px;">
            <div class="navbar-inner">
                <ul class="nav" id="navToolbar">
                    <li><a href="#" title="Exit" class="clsbtnClose" id="btnClose" style="font-size: 12px;">Exit</a></li>
                     <li class="divider-vertical"></li>
                    <li><input type="text" id="txtSearchContactName" class="search-query span2" placeholder="ContactName" style="margin-top:10px;margin-left:5px;" /></li>
                     <li class="divider-vertical"></li>
                    <li><a href="#" title="ACompany" class="clsbtnAddnewCustomer" id="btnAddnewCustomer" style="font-size: 12px;">ACompany</a></li>
                    <li><a href="#" title="AContact" class="clsbtnAddnewContact" id="btnAddnewContact" style="font-size: 12px;" >AContact</a></li>
                     <li class="divider-vertical"></li>
                    <li><a href="#" title="MCompany" class="clsbtnModifyCustomer" id="btnModifyCustomer" style="font-size: 12px; " disabled="disabled">MCompany</a></li>
                    <li><a href="#" title="MContact" class="clsbtnModifyContact" id="btnModifyContact" style="font-size: 12px;" disabled="disabled">MContact</a></li>
                     <li class="divider-vertical"></li>
                    <li><a href="#" title="DCompany" class="clsbtnDelCustomer" id="btnDelCustomer" style="font-size: 12px;" disabled="disabled">DCompany</a></li>
                    <li><a href="#" title="DContact" class="clsbtnDelContact" id="btnDelContact" style="font-size: 12px;" disabled="disabled">DContact</a></li>
                </ul>
            </div>
        </div>

        <div id="divDataGrid">
            <table id="list1"></table>
            <div id="pager1"></div>
        </div>

        <div id="divCompanyInfo">
            <table id="tblCompany" class="clstblCompany" width="100%" border="0" cellpadding="2" cellspacing="0" runat="server" style="display: none; height: 250px;">
                <tr>
                    <td>Company Name
                    </td>
                    <td>
                        <input name="txtCompanyName" type="text" class="clstxtCompanyName" id="txtCompanyName"
                            maxlength="255" style="width: 160px" runat="server" />
                    </td>
                    <td>CompanyKeyWords
                    </td>
                    <td>
                        <input name="txtCompanyKeyWords" type="text" class="clstxtCompanyKeyWords" id="txtCompanyKeyWords" maxlength="50" style="width: 160px" runat="server" /><span style="color: red">*</span>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap">Province
                    </td>
                    <td>
                        <select name="cboProvince" class="clscboProvince" id="cboProvince" style="width: 160px"
                            runat="server">
                        </select>
                    </td>
                    <td nowrap="nowrap">City
                    </td>
                    <td>
                        <input name="txtCity" type="text" class="clstxtCity" id="txtCity" maxlength="50"
                            style="width: 160px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap">CompanyAddress
                    </td>
                    <td>
                        <input name="txtCompanyAddress" type="text" class="clstxtCompanyAddress" id="txtCompanyAddress"
                            maxlength="255" style="width: 160px" runat="server" />
                    </td>
                    <td nowrap="nowrap">PostCode
                    </td>
                    <td>
                        <input name="txtPostCode" type="text" class="clstxtPostCode" id="txtPostCode"
                            maxlength="20" style="width: 160px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>CustomerType
                    </td>
                    <td>
                        <select name="cboCustomerType" class="cbocboCustomerType" id="cboCustomerType"
                            style="width: 160px" runat="server">
                        </select>
                    </td>
                    <td>Customer ID
                    </td>
                    <td>
                        <input name="txtCustomerID" type="text" class="clstxtCustomerID" id="txtCustomerID"
                            maxlength="20" style="width: 160px" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td nowrap="nowrap">ConsignorAddress
                    </td>
                    <td>
                        <input name="txtConsignorAddress" type="text" class="clstxtConsignorAddress" id="txtConsignorAddress"
                            maxlength="255" style="width: 160px" runat="server" />
                    </td>
                    <td nowrap="nowrap">TaxCode
                    </td>
                    <td>
                        <input name="txtTaxCode" type="text" class="clstxtTaxCode" id="txtTaxCode"
                            maxlength="100" style="width: 160px" runat="server" size="50" />
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap">AccountCode
                    </td>
                    <td>
                        <input name="txtAccountCode" type="text" class="clstxtAccountCode" id="txtAccountCode"
                            maxlength="100" style="width: 160px" runat="server" size="50" />
                    </td>
                    <td nowrap="nowrap">BankName
                    </td>
                    <td>
                        <input name="txtBankName" type="text" class="clstxtBankName" id="txtBankName"
                            maxlength="50" style="width: 160px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap">RegAddress
                    </td>
                    <td>
                        <input name="txtRegAddress" type="text" class="clstxtRegAddress" id="txtRegAddress"
                            maxlength="255" style="width: 160px" runat="server" />
                    </td>
                    <td nowrap="nowrap">FinanceTel
                    </td>
                    <td>
                        <input name="txtFinanceTel" type="text" class="clstxtFinanceTel" id="txtFinanceTel"
                            maxlength="20" style="width: 160px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap">Country
                    </td>
                    <td>
                        <input name="txtCountry" type="text" class="clstxtCountry" id="txtCountry"
                            maxlength="20" style="width: 160px" runat="server" />
                    </td>
                    <td nowrap="nowrap">Branch
                    </td>
                    <td>
                        <select name="cboBranch" class="clscboBranch" id="cboBranch" style="width: 160px"
                            runat="server">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap">Post Address
                    </td>
                    <td>
                        <input name="txtPostAddress" type="text" class="clstxtPostAddress" id="txtPostAddress"
                            maxlength="20" style="width: 160px" runat="server" />
                    </td>
                    <td nowrap="nowrap">VIP ID
                    </td>
                    <td>
                        <input name="txtVipID" type="text" class="clstxtVipID" id="txtVipID"
                            maxlength="20" style="width: 160px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap">VIP EN CompanyName
                    </td>
                    <td>
                        <input name="txtVipENCompanyName" type="text" class="clstxtVipENCompanyName" id="txtVipENCompanyName"
                            maxlength="255" style="width: 160px" runat="server" />
                    </td>
                    <td nowrap="nowrap">VIP CN CompanyName
                    </td>
                    <td>
                        <input name="txtVipCNCompanyName" type="text" class="clstxtVipCNCompanyName" id="txtVipCNCompanyName"
                            maxlength="255" style="width: 160px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap">IsGroupDamex
                    </td>
                    <td>
                        <asp:DropDownList ID="cboIsGroupDamex" runat="server" CssClass="clscboIsGroupDamex" Width="160px">
                            <asp:ListItem Value="0">No</asp:ListItem>
                            <asp:ListItem Value="1">Yes</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>sub-Office
                    </td>
                    <td>
                        <input name="txtSubOffice" type="text" class="clstxtSubOffice" id="txtSubOffice"
                            maxlength="50" style="width: 160px" runat="server" />
                    </td>
                </tr>
                <tr id="trBeiDe" runat="server">
                    <td>VIP配套商
                    </td>
                    <td>
                        <select id="cboBeiDeVIP" runat="server" class="clscboBeiDeVIP" name="cboBeiDeVIP"
                            style="width: 160px">
                        </select>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td nowrap="nowrap" colspan="4">
                        <input name="btnSaveCompany" type="button" class="btn btn-primary clsbtnSaveCompany" id="btnSaveCompany"
                            value="Save" />
                        <input name="btnCloseCompany" type="button" class="btn btn-primary clsbtnCloseCompany" id="btnCloseCompany"
                            value="Hide" />
                    </td>
                </tr>
            </table>
        </div>

        <div id="divContactInfo">
            <table id="tblContact" class="clstblContact" width="100%" border="0" cellspacing="0" cellpadding="2" style="display: none;"
                runat="server">
                <tr>
                    <td>Contact Name
                    </td>
                    <td>
                        <input name="txtContactName" type="text" class="clstxtContactName" id="txtContactName"
                            maxlength="50" style="width: 160px" runat="server" />
                    </td>
                    <td>Tel
                    </td>
                    <td>
                        <input name="txtTel" type="text" class="clstxtTel" id="txtTel" maxlength="50"
                            style="width: 160px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap">Fax
                    </td>
                    <td>
                        <input name="txtFax" type="text" class="clstxtFax" id="txtFax" maxlength="50"
                            style="width: 160px" runat="server" />
                    </td>
                    <td nowrap="nowrap">Mobile
                    </td>
                    <td>
                        <input name="txtMobile" type="text" class="clstxtMobile" id="txtMobile"
                            maxlength="50" style="width: 160px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap">Address
                    </td>
                    <td>
                        <input name="txtAddress" type="text" class="clstxtAddress" id="txtAddress"
                            maxlength="255" style="width: 160px" runat="server" />
                    </td>
                    <td nowrap="nowrap">Post Code
                    </td>
                    <td>
                        <input name="txtContractPostCode" type="text" class="clstxtContractPostCode" id="txtContractPostCode"
                            maxlength="50" style="width: 160px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap">Email
                    </td>
                    <td>
                        <input name="txtEmail" type="text" class="clstxtEmail" id="txtEmail"
                            maxlength="255" style="width: 160px" runat="server" />
                    </td>
                    <td nowrap="nowrap">&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" colspan="4">
                        <input name="btnSaveContact" type="button" class="btn btn-primary clsbtnSaveContact" id="btnSaveContact"
                            value="Save" />
                        <input name="btnCloseContact" type="button" class="btn btn-primary clsbtnCloseContact" id="btnCloseContact"
                            value="Hide" />
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <script type="text/javascript" src="../../JsLibrary/SEWC/Request/SelectCustomerAndContactInfo.js"></script>
</asp:Content>
