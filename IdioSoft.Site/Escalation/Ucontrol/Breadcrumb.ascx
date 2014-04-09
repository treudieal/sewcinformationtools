<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Breadcrumb.ascx.cs" Inherits="IdioSoft.Site.Escalation.Ucontrol.Breadcrumb" %>
<ul class="breadcrumb">
    <li><a href="#">Informationtools</a> <span class="divider">/</span></li>
    <li class="dropdown">
        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Escalation Home</a>
        <ul class="dropdown-menu">
            <li><a href="../Home/Default.aspx">Escalation</a></li>
            <li class="divider"></li>
            <li id="Li1" limitcode="60001" runat="server"><a href="../List/OpenList.aspx">Open List</a></li>
            <li id="Li2" limitcode="60002" runat="server"><a href="../List/InProcessList.aspx">InProcess List</a></li>
            <li id="Li3" limitcode="60003" runat="server"><a href="../List/PendingList.aspx">Pending List</a></li>
            <li id="Li4" limitcode="60004" runat="server"><a href="../List/FinishList.aspx">Finish List</a></li>
            <li id="Li5" limitcode="60005" runat="server"><a href="../List/AllList.aspx">All List</a></li>
        </ul>
        <span class="divider">/</span>
    </li>
    <li><a href="javascript:" id="lnkModule" runat="Server"></a><span class="divider">/</span></li>
</ul>
