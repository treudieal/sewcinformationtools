<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IdioSoft.Site.SEWC.Request.Default" MasterPageFile="~/Master/Csite/Site.Master" %>
<%@ Register Src="../Ucontrol/navDetailMore.ascx" TagName="navDetailMore" TagPrefix="uc2" %>
<%@ Register Src="../Ucontrol/Breadcrumb.ascx" TagName="Breadcrumb" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
     <uc1:Breadcrumb ID="Breadcrumb1" runat="server" />
</asp:Content>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cplMain">
    <script type="text/javascript" src="../../Scripts/jquery-ui.js"></script>
    <link rel="stylesheet" type="text/css" href="../../Style/css/jquery-ui-1.9.2.custom.css" />
    <link rel="stylesheet" type="text/css" href="../../Style/css/ui.jqgrid.css" />
    <script type="text/javascript" src="../../Scripts/jquery.jqGrid.src.js"></script>
    <script type="text/javascript" src="../../Scripts/grid.locale-en.js"></script>
    <script type="text/javascript" src="../../Scripts/JsFunction.js"></script>

    <div id="divMain">
        <div class="navbar" id="divNavBar">
            <div class="navbar-inner">
                <ul class="nav" id="navToolbar">
                    <li id="liAddNeweRequest" runat="server" limitCode="51002"><a href="#" title="AddNewRequest" class="nav-icon" id="lnkAddNewRequest" data-icon="&#xe03e;" ></a></li>
                    <li><a href="#" title="Detail" class="nav-icon" id="lnkDetail" data-icon="&#x0038;"></a></li>
                     <li class="divider-vertical"></li>
                      <li><a href="#" title="Refresh" class="nav-icon" id="lnkRefresh" data-icon="&#xe1de;" ></a></li>
                     <li class="divider-vertical"></li>
                 
                     <li><a href="#" title="Export" class="nav-icon" id="lnkExport" data-icon="&#xe01c;" ></a></li>
                     <uc2:navDetailMore ID="navDetailMore1" runat="server" />
                </ul>
            </div>
        </div>

        <table id="list1"></table>
        <div id="pager1"></div>

    </div>
    <script type="text/javascript" src="../../JsLibrary/SEWC/Request/Default.js"></script>
</asp:Content>
