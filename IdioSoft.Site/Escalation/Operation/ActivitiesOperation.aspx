<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivitiesOperation.aspx.cs" Inherits="IdioSoft.Site.Escalation.Operation.ActivitiesOperation" MasterPageFile="~/Master/Csite/Site.Master" %>

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
    <script type="text/javascript" src="../../Scripts/ajaxfileupload.js"></script>
    <script type="text/javascript">
        jsModuleName = "";
        EscalationID = "<%=EscalationID%>";
    </script>
    <div id="divMain" style="overflow-y:auto;height:600px;overflow-x:hidden;">
        <%--<uc2:TabNav ID="TabNav1" runat="server" />--%>
        <uc3:EscalationOperation ID="EscalationOperation1" runat="server" />

        <div id="divNavBar" style="margin-top:4px;margin-bottom:4px;">
          
                <input type="button" name="btnItemAddnew" id="btnItemAddnew" value="New" class="btn-primary clsItemAddnew" limitcode="60007" runat="server" />
                <input type="button" name="btnItemModify" id="btnItemModify" value="Modify" class="btn-info clsItemModify" limitcode="60007" runat="server"/>
                <input type="button" name="btnItemDelete" id="btnItemDelete" value="Delete" class="btn-danger clsItemDelete" limitcode="60007" runat="server"/>
                <input type="button" name="btnItemBack" id="btnItemBack" value="Back" class="btn-danger" />
     
        </div>
        <table id="list1"></table>
        <div id="pager1"></div>

        <div id="divActivitiesOperation">
            <div style="margin-right: 2px;" id="divRealOperation">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" id="tblOperation">
                    <tr>
                        <td colspan="2">
                            <input type="button" name="btnItemSave" id="btnItemSave" value="Save" class="btn-primary clsItemSave" limitcode="60007" runat="server"  />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table  style="width:100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>CurrentStatus</td>
                                    <td>
                                        <textarea id="txtCurrentStatus" cols="40" rows="4" class="clstxtCurrentStatus"  runat="server" ></textarea>
                   
                                    </td>
                                    <td rowspan="2">Comments</td>
                                    <td rowspan="2" width="80%">

                                        <textarea id="txtComments" name="txtComments" class="clstxtComments" runat="server" cols="20" rows="6" style="width:98%"></textarea>
                                    </td>   
                                </tr>
                                <tr>
                                    <td>NextStep</td>
                                    <td>
                                        <textarea id="txtNextStep" cols="40" rows="4" class="clstxtNextStep"  runat="server" ></textarea>
                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>Attachment Upload</td>
                                    <td style="border: 0px;" colspan="3">
                                        <input type="file" name="fileUpload" id="fileUpload" style="border: 1px #dddddd solid; background-color: #ffffff" />
                                        <input type="button" name="btnUpload" id="btnUpload" value="Upload" class="ui-button-success" style="height: 20px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="3" style="border: 0px; padding: 0px; padding-left: 20px; border-bottom: 1px #dddddd solid; border-top: 1px #dddddd solid;" id="tdAttachmentList" runat="server" class="clstdAttachmentList">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>

            <div class="ui-state-default ui-corner-bottom" style="padding: 2px; margin-right: 2px;">
                <span>Current Operation: </span><span id="spanAOperationTitle">View</span>
            </div>
        </div>
    </div>


    <script type="text/javascript" src="../../JsLibrary/Escalation/List/ActivitiesOperation.js"></script>

</asp:Content>
