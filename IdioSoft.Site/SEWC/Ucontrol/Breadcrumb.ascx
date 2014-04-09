<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Breadcrumb.ascx.cs" Inherits="IdioSoft.Site.SEWC.Ucontrol.Breadcrumb" %>
    <ul class="breadcrumb">
        <li><a href="#">Informationtools</a> <span class="divider">/</span></li>
        <li class="dropdown">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown">SEWC Home</a>
            <ul class="dropdown-menu">
                <li><a href="../Home/Default.aspx">Home</a></li>
                <li class="divider"></li>
                <li limitCode="51001" runat="server"><a href="../Request/Default.aspx">Request</a></li>
                <li limitCode="52001" runat="server"><a href="../GoodsReceipt/Default.aspx">GoodsReceipt</a></li>
                <li limitCode="53001" runat="server"><a href="../IssueRepairOrder/Default.aspx">IssueRepairOrder</a></li>
                <li limitCode="54001" runat="server"><a href="../Repair/Default.aspx">Repair</a></li>
                <li limitCode="55001" runat="server"><a href="../Delivery/Default.aspx">Delivery</a></li>
                <li limitCode="56001" runat="server"><a href="../Finish/Default.aspx">Finish</a></li>
                <li limitCode="57001" runat="server"><a href="../Reject/Default.aspx">Reject</a></li>
                <li limitCode="58001" runat="server"><a href="../All/Default.aspx">All</a></li>
                <li limitCode="59001" runat="server"><a href="../Report/Default.aspx">Report</a></li>
            </ul>
            <span class="divider">/</span>
        </li>
        <li><a href="javascript:" id="lnkModule" runat="Server"></a> <span class="divider">/</span></li>
    </ul>