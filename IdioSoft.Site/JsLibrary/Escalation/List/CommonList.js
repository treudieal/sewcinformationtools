var exports = this;
var grid;
var blFirstLoad = false;

jQuery(function ($) {
    var myModal = $("<div id='myModal' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true' style='width: 610px;'><div class='modal-header'><button type='button' class='close' data-dismiss='modal' aria-hidden='true'></button><h3 id='myModalLabel'><span data-icon='&#x0026;' style='font-size: 18px;'></span>Delivery</h3></div><div class='modal-body'></div></div>");
    var myModalError = $("<div id='myModalError' class='modal warning bg-color-blu hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'><div class='modal-body'><p class='pErrorTitle'></p></div><div class='modal-footer'><button class='btn btn-large' data-dismiss='modal'>Close</button></div></div>");
    var selectID = "";
    exports.AllDefault = Controller.create({
        elements: {
            "#lnkNew": "lnkNew",
            "#lnkSearch": "lnkSearch",
            "#lnkExport": "lnkExport",
            "#lnkActivities": "lnkActivities",
            "#lnkRefresh":"lnkRefresh"
        },
        events: {
            "click #lnkNew": "fnNew",
            "click #lnkActivities": "fnActivities",
            "click #lnkRefresh":"fnRefresh"
        },
        fnRefresh: function () {
            window.location.reload();
        },
        fnNew: function () {
            grid.trigger("reloadGrid");
            objOperation.fnOperationControl(true);
            objOperation.fnOperationControlClear();
            objOperation.fnOperationType("Addnew");
        },
        fnActivities: function () {
            var intRow;
            intRow = $(list1).jqGrid('getGridParam', 'selrow');
            var EscalationID = $(list1).getCell(intRow, "EscalationID");

            window.location = "../Operation/ActivitiesOperation.aspx?EscalationID=" + EscalationID + "";
        },
        fnExport: function () {

        }
    });
    var objAllDefault = new AllDefault({ el: $("#divMain"), KeyID: "" });
    $('.nav-icon').tooltip();
  
});
datePick = function (elem) {
    jQuery(elem).datepicker({
        dateFormat: 'yy-mm-dd',
        changeYear: true,
        changeMonth: true
    });
}
function fngridLoad() {
    //debugger;
    if (grid != null) {
        grid.GridUnload();
    }
    var title = "";
    var url = "../../InterfaceLibrary/Escalation/List/CommonList.ashx";
    switch (jsModuleName) {
        case "openlist":
            url = "../../InterfaceLibrary/Escalation/List/CommonList.ashx?Status=Open";
            title = "Open List";
            break;
        case "inprocesslist":
            url = "../../InterfaceLibrary/Escalation/List/CommonList.ashx?Status=InProcess";
            title = "InProcess List";
            break;
        case "pendinglist":
            url = "../../InterfaceLibrary/Escalation/List/CommonList.ashx?Status=Pending";
            title = "Pending List";
            break;
        case "finishlist":
            url = "../../InterfaceLibrary/Escalation/List/CommonList.ashx?Status=Finish";
            title = "Finish List";
            break;
        case "alllist":
            url = "../../InterfaceLibrary/Escalation/List/CommonList.ashx?Status=All";
            title = "All List";
            break;
        default:
            break;
    }
    //EscalationID, ERNo, SRNo, AppCompany, EndUser, Contact, OC, ProductDesc, MLFB, SN, Abstract, Remark, Status, Type, Priority, EscalationBy, Owner, CreatedDate
    jQuery("#list1").jqGrid({
        url: url,
        datatype: "json",
        mtype: 'Post',
        colNames: ['EscalationID', 'ERNo', 'Status', 'SRNo', 'MLFB', 'OC', 'Type', 'Priority', 'Owner', 'CreatedDate', 'Abstract', 'EscalationBy'],
        colModel: [
            { name: 'EscalationID', index: 'EscalationID', hidden: true, align: 'left', search: false, frozen: true },
                {
                    name: 'ERNo', index: 'ERNo', width: 100, align: 'center', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'], defaultValue: $.cookies.get('ckgs_ERNo') == null ? "" : $.cookies.get('ckgs_ERNo') }, formatter: function (val, opts, rowdata) {
                        var ERNo = rowdata.ERNo;
                        var EscalationID = rowdata.EscalationID;
                        var returnValue = "";

                        returnValue = "<a href='../Operation/ActivitiesOperation.aspx?EscalationID=" + EscalationID + "' title='" + ERNo + "' class='aLink'>" + ERNo + "</a>"

                        return returnValue;
                    }
                },
            { name: 'Status', index: 'Status', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'], defaultValue: $.cookies.get('ckgs_Status') == null ? "" : $.cookies.get('ckgs_Status') } },
            { name: 'SRNo', index: 'SRNo', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'], defaultValue: $.cookies.get('ckgs_SRNo') == null ? "" : $.cookies.get('ckgs_SRNo') } },
            { name: 'MLFB', index: 'MLFB', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'], defaultValue: $.cookies.get('ckgs_MLFB') == null ? "" : $.cookies.get('ckgs_MLFB') } },
            { name: 'OC', index: 'OC', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'], defaultValue: $.cookies.get('ckgs_OC') == null ? "" : $.cookies.get('ckgs_OC') }, frozen: true },
            { name: 'Type', index: 'Type', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'], defaultValue: $.cookies.get('ckgs_Type') == null ? "" : $.cookies.get('ckgs_Type') }, frozen: true },
            { name: 'Priority', index: 'Priority', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'], defaultValue: $.cookies.get('ckgs_Priority') == null ? "" : $.cookies.get('ckgs_Priority') }, frozen: true },
            { name: 'Owner', index: 'Owner', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'], defaultValue: $.cookies.get('ckgs_Owner') == null ? "" : $.cookies.get('ckgs_Owner') } },
            {
                name: 'CreatedDate', index: 'CreatedDate', width: 200, align: 'left', formatter: 'date',
                formatoptions: {
                    'srcformat': 'ISO8601Long', 'newformat': 'Y/m/d g:i A'
                }, searchoptions: { dataInit: datePick, attr: { title: '选择日期' }, sopt: ['eq', 'ne', 'le', 'lt', 'gt', 'ge'] }
            },
            { name: 'Abstract', index: 'Abstract', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
            { name: 'EscalationBy', index: 'EscalationBy', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } }
        ],
        shrinkToFit: false,
        autowidth: false,
        jsonReader: {
            page: "page",
            total: "total",
            repeatitems: false
        },
        height: 100,
        width: 840,
        pager: jQuery('#pager1'),
        rowNum: 30,
        rowList: [10, 20, 30],
        sortname: 'CreatedDate',
        sortorder: 'asc',
        onSelectRow: function (rowid) {
            objOperation.fnOperationControl(false);
            objOperation.fnOperationType("View");
            var EscalationID = $(list1).getCell(rowid, "EscalationID");
            sID = EscalationID;
            objOperation.fnLoadDetail(EscalationID);
        },
        ondblClickRow: function (rowid, iRow, iCol, e) {

        },
        onHeaderClick: function (gridstate) {
            var status = false;
            if (gridstate == "hidden") {
                status = true;
            }
            else {
                status = false;
            }
        },
        loadComplete: function () {
            setTimeout("funReloadTools()", 500);
        },
        viewrecords: true,
        subGrid: true,
        subGridRowExpanded: function (subgrid_id, row_id) {
            var aryRow;
            var EscalationID = $(list1).getCell(row_id, "EscalationID");
            var subgrid_table_id, pager_id;
            subgrid_table_id = subgrid_id + "_t";
            pager_id = "p_" + subgrid_table_id;
            $("#" + subgrid_id).html("<table id='" + subgrid_table_id + "' class='scroll'></table><div id='" + pager_id + "' class='scroll'></div>");
            //ActivityID, CurrentStatus, NextStep, Comments, CreatedDate, CreateUser
            jQuery("#" + subgrid_table_id).jqGrid({
                url: "../../InterfaceLibrary/Escalation/List/ActivityList.ashx?EscalationID=" + EscalationID,
                datatype: "json",
                mtype: 'Post',
                colNames: ['ActivityID', 'CurrentStatus', 'NextStep', 'Comments', 'CreatedDate', 'CreateUser'],
                colModel: [
                    { name: "ActivityID", index: "ActivityID", width: 80, key: true, hidden: true },
                    { name: "CurrentStatus", index: "CurrentStatus", width: 200, align: "left" },
                    { name: "NextStep", index: "NextStep", width: 200, align: "left" },
                    { name: "Comments", index: "Comments", width: 200, align: "left" },
                    { name: "CreatedDate", index: "CreatedDate", width: 200, align: "left" },
                    { name: "CreateUser", index: "CreateUser", width: 130 }
                ],
                rowNum: 20,
                pager: pager_id,
                sortname: 'CreatedDate',
                sortorder: "asc",
                height: '100%',
                onSelectRow: function (rowid) {
                },
                ondblClickRow: function (rowid, iRow, iCol, e) {
                }
            });
            jQuery("#" + subgrid_table_id).jqGrid('navGrid', "#" + pager_id, { edit: false, add: false, del: false, search: false })
        },
    }).navGrid("#pager1", { edit: false, add: false, del: false, search: false })
    //jQuery("#list1").jqGrid()[0].triggerToolbar();
    grid = jQuery("#list1").jqGrid('filterToolbar', { searchOperators: true, stringResult: true, searchOnEnter: true });

}
function funReloadTools() {
    if (!blFirstLoad) {
        blFirstLoad = true;
        $(grid)[0].triggerToolbar();
        //var obj = $($(".ui-search-input")[0]).find("input");
        //var e = jQuery.Event("keypress");//模拟一个键盘事件 
        //e.keyCode = 13;//keyCode=13是回车 
        //$(obj).trigger(e);//模拟页码框按下回车 
    }
}

fngridLoad();
//grid.trigger('change');

$(window).resize(function () {
    $(window).unbind("onresize");
    fnResizeControl();
    $(window).bind("onresize", this);
});

function fnResizeControl() {
    //debugger;
    grid.setGridWidth($(window).width() * 0.99);
    //grid.setGridHeight($(window).height() / 2);
    var intHeight = $(window).height() - 90;
    $("#divMain").height(intHeight);
    switch (jsModuleName) {
        case "openlist":
            break;
        case "inprocesslist":
        case "pendinglist":
        case "finishlist":
        case "alllist":
            grid.setGridHeight(intHeight - 200);
            break;
    }
}
fnResizeControl();