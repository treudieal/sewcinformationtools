<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IdioSoft.Site.Escalation.Home.Default" MasterPageFile="~/Master/Csite/Site.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplMain">
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="metro span12">
                <div class="metro-sections">
                    <div id="section1" class="metro-section tile-span-4">
                        <a class="tile wide imagetext bg-color-green" href="../List/OpenList.aspx" id="lnkOpenList" runat="server" limitcode="60001">
                            <div class="image-wrapper">
                                <span class="icon" data-icon="&#x0034;"></span>
                            </div>
                            <div class="column-text">
                                <div>Open List</div>
                            </div>
                        </a>
                        <a class="tile wide imagetext bg-color-blueDark" href="../List/InProcessList.aspx" id="lnkInprocess" runat="server" limitcode="60002">
                            <div class="image-wrapper">
                                <span class="icon" data-icon="&#x0074;"></span>
                            </div>
                            <div class="column-text">
                                <div>In-Process</div>
                            </div>
                        </a>

                        <a class="tile wide imagetext wideimage bg-color-orange" href="../List/PendingList.aspx" id="lnkPending" runat="server" limitcode="60003">
                            <div class="image-wrapper">
                                <span class="icon" style="font-size: 64px;" data-icon="&#xe204;"></span>
                            </div>
                            <div class="textover-wrapper bg-color-blue">
                                <div style="padding-top: 10px;">Pending</div>
                            </div>
                        </a>

                        <a class="tile app wide bg-color-greenDark" href="../List/FinishList.aspx" id="lnkFinish" runat="server" limitcode="60004">
                            <div class="image-wrapper">
                                <span class="icon" data-icon="&#xe03c;"></span>
                            </div>
                            <div class="app-label">Finish</div>
                        </a>

                    </div>

                    <div id="section2" class="metro-section tile-span-2">
                        <a class="tile app wide bg-color-yellow" href="../List/AllList.aspx" id="lnkAll" runat="server" limitcode="60005">
                            <div class="image-wrapper">
                                <span class="icon" data-icon="&#xe177;"></span>
                            </div>
                            <div class="app-label">All List</div>
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
        <li><a href="#">Escalation Home</a> <span class="divider">/</span></li>
    </ul>
</asp:Content>



