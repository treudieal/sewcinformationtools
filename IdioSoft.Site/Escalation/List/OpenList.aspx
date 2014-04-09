<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpenList.aspx.cs" Inherits="IdioSoft.Site.Escalation.List.OpenList" MasterPageFile="~/Master/Csite/Site.Master" %>

<%@ Register Src="../Ucontrol/Breadcrumb.ascx" TagName="Breadcrumb" TagPrefix="uc1" %>



<%@ Register Src="../Ucontrol/TabNav.ascx" TagName="TabNav" TagPrefix="uc2" %>

<%@ Register Src="~/Escalation/List/EscalationOperation.ascx" TagName="EscalationOperation" TagPrefix="uc3" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <uc1:Breadcrumb ID="Breadcrumb1" runat="server" />
</asp:Content>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cplMain">
    <script type="text/javascript" src="../../Scripts/jquery-ui.js"></script>
    <link rel="stylesheet" type="text/css" href="../../Style/css/jquery-ui-1.9.2.custom.css" />
    <link rel="stylesheet" type="text/css" href="../../Style/css/ui.jqgrid.css" />
    <script type="text/javascript" src="../../Scripts/jquery.jqGrid.src.js"></script>
    <script type="text/javascript" src="../../Scripts/grid.locale-en.js"></script>
    <script type="text/javascript">
        jsModuleName = "openlist";
    </script>

    <div id="divMain" style="overflow-y:auto;height:600px;overflow-x:hidden;">
        <uc2:TabNav ID="TabNav1" runat="server" />
        <div class="navbar" id="divNavBar">
            <div class="navbar-inner">
                <ul class="nav" id="navToolbar">
                    <li><a href="#" title="New" class="nav-icon" id="lnkNew" data-icon="&#xe03e;"></a></li>
                    <li class="divider-vertical"></li>
                    <li><a href="#" title="Export" class="nav-icon" id="lnkExport" data-icon="&#xe01c;"></a></li>
                </ul>

            </div>
        </div>
        <table id="list1"></table>
        <div id="pager1"></div>
        <uc3:EscalationOperation ID="EscalationOperation1" runat="server" />
    </div>


    <script type="text/javascript" src="../../JsLibrary/Escalation/List/CommonList.js"></script>

</asp:Content>
