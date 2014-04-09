<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TabNav.ascx.cs" Inherits="IdioSoft.Site.Escalation.Ucontrol.TabNav" %>
<ul class="nav nav-tabs">
    <li class="active" id="liOpenList" runat="server" limitcode="60001"><a href="OpenList.aspx">Open List</a></li>
    <li id="liInProcess" runat="server" limitcode="60002"><a href="InProcessList.aspx">In-Process List</a></li>
    <li id="liPendingList" runat="server" limitcode="60003"><a href="PendingList.aspx">Pending List</a></li>
    <li id="liFinishList" runat="server" limitcode="60004"><a href="FinishList.aspx">Finish List</a></li>
    <li id="liAllList" runat="server" limitcode="60005"><a href="AllList.aspx">All List</a></li>
</ul>
