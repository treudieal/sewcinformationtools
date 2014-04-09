<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="T3Operation.aspx.cs" Inherits="IdioSoft.Site.SEWC.GoodsReceipt.T3Operation" MasterPageFile="~/Master/Csite/Pop.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../../Scripts/jQuery-Timepicker-Addon/jquery-ui-timepicker-addon.css" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="../../Scripts/jQuery-Timepicker-Addon/jquery-ui-timepicker-addon.js"></script>
    <script type="text/javascript" src="../../Scripts/ajaxfileupload.js"></script>
    <script type='text/javascript' src='../../jquery-autocomplete/jquery.autocomplete.js'></script>
    <link rel="stylesheet" type="text/css" href="../../jquery-autocomplete/jquery.autocomplete.css" />
    <script type="text/javascript">
        var PuRequestIDs = "<%=PuRequestIDs%>";
    </script>
    <script type="text/javascript" src="../../JsLibrary/SEWC/GoodsReceipt/T3Operation.js"></script>
    <table border="0" id="tblOperation" style="width: 100%;">
        <tr>
            <td class="TitleColor">ReceiveDefectiveDate(T3)</td>
            <td style="width:90%">
                <input type="text" id="dtpReceiveDefectiveDate" class="dtpReceiveDefectiveDate dtpTime" runat="server" value=""  />

            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center;">
                <input id="btnSave" type="button" class="btn btn-primary btnSave" value="Save" runat="server"  limitCode="52002"   />
            </td>
        </tr>
    </table>
</asp:Content>
