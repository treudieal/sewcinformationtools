<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IdioSoft.Site.SEWC.Home.Default" MasterPageFile="~/Master/Csite/Site.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplMain">
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="metro span12">
                <div class="metro-sections">
                    <div id="section1" class="metro-section tile-span-4">
                        <a class="tile wide imagetext bg-color-green" href="../Request/Default.aspx" id="lnkRequest" runat="server" limitcode="51001">
                            <div class="image-wrapper">
                                <span class="icon" data-icon="&#x0034;"></span>
                            </div>
                            <div class="column-text">
                                <div>Request</div>
                            </div>
                        </a>
                        <a class="tile wide imagetext bg-color-blueDark" href="../GoodsReceipt/Default.aspx" id="lnkGoodsReceipt" runat="server" limitcode="52001">
                            <div class="image-wrapper">
                                <span class="icon" data-icon="&#x0074;"></span>
                            </div>
                            <div class="column-text">
                                <div>GoodsReceipt</div>
                            </div>
                        </a>

                        <a class="tile wide imagetext wideimage bg-color-orange" href="../IssueRepairOrder/Default.aspx" id="lnkIssueRepairOrder" runat="server" limitcode="53001">
                            <div class="image-wrapper">
                                <span class="icon" style="font-size: 64px;" data-icon="&#xe204;"></span>
                            </div>
                            <div class="textover-wrapper bg-color-blue">
                                <div style="padding-top: 10px;">IssueRepairOrder</div>
                            </div>
                        </a>

                        <a class="tile app wide bg-color-greenDark" href="../Finish/Default.aspx" id="lnkFinish" runat="server" limitcode="56001">
                            <div class="image-wrapper">
                                <span class="icon" data-icon="&#xe03c;"></span>
                            </div>
                            <div class="app-label">Finish</div>
                        </a>

                        <a class="tile app wide bg-color-red" href="../Reject/Default.aspx" id="lnkReject" runat="server" limitcode="58001">
                            <div class="image-wrapper">
                                <span class="icon" data-icon="&#xe001;"></span>
                            </div>
                            <div class="app-label">Reject</div>
                        </a>

                        <a class="tile app wide bg-color-purple3" href="../All/Default.aspx" id="lnkAll" runat="server" limitcode="57001">
                            <div class="image-wrapper">
                                <span class="icon" data-icon="&#xe015;"></span>
                            </div>
                            <div class="app-label">All List</div>
                        </a>

                    </div>

                    <div id="section2" class="metro-section tile-span-2">
                        <a class="tile app bg-color-purple1" href="../Repair/Default.aspx" id="lnkRepair" runat="server" limitcode="54001">
                            <div class="image-wrapper">
                                <span class="icon" data-icon="&#x006e;"></span>
                            </div>
                            <span class="app-label">Repair</span>
                        </a>

                        <a class="tile app bg-color-yellow" href="../Delivery/Default.aspx" id="lnkDelivery" runat="server" limitcode="55001">
                            <div class="image-wrapper">
                                <span class="icon" data-icon="&#xe007;"></span>
                            </div>
                            <span class="app-label">Delivery</span>
                        </a>

                        <a class="tile app wide bg-color-blueDark" href="../Report/Default.aspx" id="lnkReport" runat="server" limitcode="59001">
                            <div class="image-wrapper">
                                <span class="icon" data-icon="&#xe177;"></span>
                            </div>
                            <div class="app-label">Report</div>
                        </a>

                    </div>


                </div>
            </div>
        </div>
    </div>
</asp:Content>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <ul class="breadcrumb">
        <li><a href="#">Informationtools</a> <span class="divider">/</span></li>
        <li><a href="#">SEWC Home</a> <span class="divider">/</span></li>
    </ul>
</asp:Content>



