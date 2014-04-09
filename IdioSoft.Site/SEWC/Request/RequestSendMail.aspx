<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestSendMail.aspx.cs" Inherits="IdioSoft.Site.SEWC.Request.RequestSendMail" MasterPageFile="~/Master/Csite/Pop.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript">
        var PuRequestIDs = "<%=PuRequestIDs%>";
    </script>
    <script type="text/javascript" src="../../JsLibrary/SEWC/Request/RequestSendMail.js"></script>
    <div id="divUpload">
        <table style="width: 400px;" id="tblOperation">
            <thead>
                <tr>
                    <th colspan="2">Send Mail</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Mail</td>
                    <td>
                        <input type="text" size="200" id="txtSendMail" class="clstxtSendMail" style="width: 300px;" />
                    </td>
                </tr>
                <tr>
                    <td>CC</td>
                    <td>
                        <input type="text" size="200" id="txtSendCC" class="clstxtSendCC" style="width: 300px;" /></td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <input id="btnSendMail" class="btn btn-primary" name="btnSendMail" type="button" value="Send Mail" />
                    </td>
                </tr>
            </tfoot>

        </table>
    </div>
</asp:Content>
