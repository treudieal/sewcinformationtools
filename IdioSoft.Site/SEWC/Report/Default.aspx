<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IdioSoft.Site.SEWC.Report.Default" MasterPageFile="~/Master/Csite/Site.Master" %>

<%@ Register Src="../Ucontrol/Breadcrumb.ascx" TagName="Breadcrumb" TagPrefix="uc1" %>




<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <uc1:Breadcrumb ID="Breadcrumb1" runat="server" />

</asp:Content>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cplMain">
    <link href="../../Scripts/jQuery-Timepicker-Addon/jquery-ui-timepicker-addon.css" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="../../Scripts/jQuery-Timepicker-Addon/jquery-ui-timepicker-addon.js"></script>
    <div id="divMain">
        <div>
            <div style="padding-left: 10px; background-color: #f1f1f1; margin: 4px;">
                <img src="../../Style/images/icon-link.gif" />
                Delivery Date Period
                <input type="text" value="" class="dtpTime dtpStartDate" title="Start Date" />TO<input type="text" value="" class="dtpTime dtpEndDate" title="End Date" />
            </div>
            <div class="reportlist">
                <a href="#" id="lnkLUReport"><span class="icon reportlist-icon" data-icon="&#xe177;"></span>LU report</a>
            </div>

            <div class="reportlist">
                <a href="#" id="lnkPUReport"><span class="icon reportlist-icon" data-icon="&#xe177;"></span>PU Report</a>
            </div>

            <div class="reportlist">
                <a href="#" id="lnkQAFMSReport"><span class="icon reportlist-icon" data-icon="&#xe177;"></span>QA-FMS report</a>
            </div>

            <div class="reportlist">
                <a href="#" id="lnkQAKPIInvoiceReport"><span class="icon reportlist-icon" data-icon="&#xe177;"></span>QA-KPI&Invocie report</a>
            </div>
        </div>
        <div>
            <div style="padding-left: 10px; background-color: #f1f1f1; margin: 4px;">
                <img src="../../Style/images/icon-link.gif" />
                Confirm Date Period
                <input type="text" value="" class="dtpTime dtpConfirmStartdate" title="Start Date" />TO<input type="text" value="" class="dtpTime dtpConfirmEnddate" title="End Date" />
            </div>

            <div class="reportlist">
                <a href="#" id="lnkGoodwillReport"><span class="icon reportlist-icon" data-icon="&#xe177;"></span>Goodwill report</a>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="../../JsLibrary/SEWC/Report/Default.js"></script>

</asp:Content>
