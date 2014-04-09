<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Csite/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IdioSoft.Site.User.Default" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div>
        <ul class="breadcrumb">
            <li><a href="../Home/Default.aspx">Home</a> <span class="divider">/</span></li>
            <li><a href="#">用户管理</a> <span class="divider">/</span></li>
        </ul>

    </div>
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cplMain">

    <script type="text/javascript" src="../../Scripts/jquery-ui.js"></script>
    <link rel="stylesheet" type="text/css" href="../../Style/css/jquery-ui-1.9.2.custom.css" />
    <link rel="stylesheet" type="text/css" href="../../Style/css/ui.jqgrid.css" />
    <script type="text/javascript" src="../../Scripts/jquery.jqGrid.src.js"></script>
    <script type="text/javascript" src="../../Scripts/grid.locale-en.js"></script>

    <div id="divMain">
 

        <div class="navbar">
            <div class="navbar-inner">
                <ul class="nav" id="navToolbar">
                    <li><a href="#" title="Addnew" class="nav-icon" id="lnkAddnew" data-icon="&#xe03e;" style="font-size: 20px;"></a></li>
                    <li><a href="#" title="Edit" class="nav-icon" id="lnkEdit" data-icon="&#x0025;" style="font-size: 20px;"></a></li>
                    <li><a href="#" title="Delete" class="nav-icon" id="lnkDelete" data-icon="&#xe003;" style="font-size: 20px;"></a></li>
                    <li><a href="#" title="Detail" class="nav-icon" id="lnkDetail" data-icon="&#x0038;" style="font-size: 20px;"></a></li>
<%--                    <li class="divider-vertical"></li>
                    <li><a href="#" title="Import" class="nav-icon" data-icon="&#xe111;" style="font-size: 20px;"></a></li>
                    <li><a href="#" title="Export" class="nav-icon" data-icon="&#xe112;" style="font-size: 20px;"></a></li>--%>
                </ul>
            </div>
        </div>

        <div id="myModalConfirm" class="modal message hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                <h3>删除对话框</h3>
            </div>
            <div class="modal-body">
                <h4>删除选中记录?</h4>
                <p>您确定删除记录吗?</p>
            </div>
            <div class="modal-footer">
                <button class="btn" data-dismiss="modal">Close</button>
                <button class="btn btn-primary" id="btnDelete">Save changes</button>
            </div>
        </div>

 

        <table id="list1"></table>
        <div id="pager1"></div>

    </div>
    <script type="text/javascript" src="../../JsLibrary/User/JsUser-default.js"></script>

</asp:Content>



