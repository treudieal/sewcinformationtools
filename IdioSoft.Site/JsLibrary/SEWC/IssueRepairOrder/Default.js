var exports = this;
jQuery(function ($) {
    var myModal = $("<div id='myModal' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true' style='width: 610px;'><div class='modal-header'><button type='button' class='close' data-dismiss='modal' aria-hidden='true'></button><h3 id='myModalLabel'><span data-icon='&#x0026;' style='font-size: 18px;'></span>Quotation</h3></div><div class='modal-body'></div></div>");
    var myModalError = $("<div id='myModalError' class='modal warning bg-color-blu hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'><div class='modal-body'><p class='pErrorTitle'></p></div><div class='modal-footer'><button class='btn btn-large' data-dismiss='modal'>Close</button></div></div>");
    var selectID = "";
    exports.IssueRepairOrder = Controller.create({
        elements: {
            "#lnkEdit": "lnkEdit",
            "#lnkExport": "lnkExport",
            "#list1": "list1",
            "#navToolbar": "navToolbar",
            "#lnkRefresh": "lnkRefresh",
            "#lnkReport": "lnkReport"
        },
        events: {
            "click #lnkEdit": "fnEdit",
            "click #lnkExport": "fnExport",
            "click #lnkRefresh": "fnRefresh",
            "click #lnkReport": "fnReport"
        },
        fnRefresh: function () {
            grid.trigger("reloadGrid");
        },
        fnEdit: function (obj) {
            //debugger;
            var aryRow;
            var sID = "";
            aryRow = $(list1).jqGrid('getGridParam', 'selarrrow');
            if (aryRow.length > 0) {
                for (var i = 0; i < aryRow.length; i++) {
                    sID = sID + $(list1).getCell(aryRow[i], "uRequestID") + ",";
                }
            }
            else {
                myModalError.find(".pErrorTitle").text("Please select a record!");
                $(myModalError).modal({
                    keyboard: false,
                    Clickhide: true
                })
                return;
            }
            if (sID != "") {
                sID = sID.substring(0, sID.length - 1);
            }
            this.fnNavSelectItem(obj);
            window.open("IssueRepairOrderOperation.aspx?sID=" + sID + "", 'mywindow', 'width=740,height=500,top=150, left=300, toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no,status=no');
        },
        fnExport: function () {
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/Util/ws_Util.asmx/funString_ExportExcel",
                contentType: "application/json",
                dataType: "json",
                data: "{SQLInfoKey:3}",
                success: function (msg) {
                    if (msg.d != "") {
                        window.open("../../temp/" + msg.d);
                    } else {
                        myModalError.find(".pErrorTitle").text("Report Error!");
                        $(myModalError).modal({
                            keyboard: false,
                            Clickhide: true
                        });
                        return false;
                    }
                }
            });
        },
        fnReport: function (obj) {
            var aryRow;
            var sID = "";
            aryRow = $(list1).jqGrid('getGridParam', 'selarrrow');
            if (aryRow.length == 1) {
                for (var i = 0; i < aryRow.length; i++) {
                    sID = $(list1).getCell(aryRow[i], "uRequestID") + ",";
                }
            }
            else {
                myModalError.find(".pErrorTitle").text("Please select a record!");
                $(myModalError).modal({
                    keyboard: false,
                    Clickhide: true
                })
                return;
            }
            this.fnNavSelectItem(obj);
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/IssueRepairOrder/IssueRepairOrderReport.ashx?SQLInfoKey=3",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "uRequestID=" + sID + "",
                success: function (msg) {
                    if (msg != "") {
                        window.open("../../temp/" + msg);
                    } else {
                        myModalError.find(".pErrorTitle").text("Report Error!");
                        $(myModalError).modal({
                            keyboard: false,
                            Clickhide: true
                        });
                        return false;
                    }
                }
            });
        },
        fnNavSelectItem: function (obj) {
            $(navToolbar).find("li").each(function (index) {
                $(this).removeClass("active");
            });
            $(obj.target).parent().addClass("active");
        }
    });
    var objIssueRepairOrder = new IssueRepairOrder({ el: $("#divMain"), KeyID: "" });
    $('.nav-icon').tooltip();
});

datePick = function (elem) {
    jQuery(elem).datepicker({
        dateFormat: 'yy-mm-dd',
        changeYear: true,
        changeMonth: true
    });
}

function fnLoad() {
}
jQuery("#list1").jqGrid({
    //url: '../../InterfaceLibrary/SEWC/IssueRepairOrder/ws_IssueRepairOrder.asmx/subLoadGridList',
    url: '../../InterfaceLibrary/SEWC/IssueRepairOrder/Default.ashx',
    datatype: "json",
    mtype: 'Post',
    colNames: ['uRequestID', 'Flag', 'RequestID', 'MLFB', 'SerialNo', 'ProductGroup', 'ProductDesc', 'SEWCNotificationNo', 'ServiceType', 'Warranty'
        , 'DeliveryCustomer', 'ReceiveDefectiveDateT3', 'CustomerConfirmDate', 'IssueRepairOrderDate', 'ReveiveBankReceipt', 'CreateUser', 'CreateDate'],
    colModel: [
        { name: 'uRequestID', index: 'uRequestID', hidden: true, align: 'left', search: false, frozen: true },
        {
            name: 'FormatFlag', index: 'FormatFlag', width: 40, align: 'center', search: false, sortable: false, frozen: true, formatter: function (val, opts, rowdata) {
                var uID = rowdata.uRequestID;
                var returnValue = "";
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../../InterfaceLibrary/SEWC/IssueRepairOrder/ws_IssueRepairOrder.asmx/funString_StatusImage",
                    contentType: "application/json",
                    dataType: "json",
                    data: "{uRequestID:\"" + uID + "\"}",
                    success: function (msg) {
                        returnValue = msg.d;
                    }
                });
                return returnValue;
            }
        },
        { name: 'RequestID', index: 'RequestID', align: 'left', width: '120px', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] }, frozen: true },
        { name: 'MLFB', index: 'MLFB', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'SerialNo', index: 'SerialNo', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'ProductGroup', index: 'ProductGroup', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'ProductDesc', index: 'ProductDesc', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'SEWCNotificationNo', index: 'SEWCNotificationNo', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'ServiceType', index: 'ServiceType', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'Warranty', index: 'Warranty', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'DeliveryCustomer', index: 'DeliveryCustomer', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        {
            name: 'ReceiveDefectiveDate(T3)', index: 'ReceiveDefectiveDateT3', width: '160px', align: 'left', formatter: 'date',
            formatoptions: {
                'srcformat': 'ISO8601Long', 'newformat': 'Y/m/d g:i A'
            }, searchoptions: { dataInit: datePick, attr: { title: '选择日期' }, sopt: ['eq', 'ne', 'le', 'lt', 'gt', 'ge'] }
        },
        {
            name: 'CustomerConfirmDate', index: 'CustomerConfirmDate', width: '160px', align: 'left', formatter: 'date',
            formatoptions: {
                'srcformat': 'ISO8601Long', 'newformat': 'Y/m/d g:i A'
            }, searchoptions: { dataInit: datePick, attr: { title: '选择日期' }, sopt: ['eq', 'ne', 'le', 'lt', 'gt', 'ge'] }
        },
        {
            name: 'IssueRepairOrderDate', index: 'IssueRepairOrderDate', width: '160px', align: 'left', formatter: 'date',
            formatoptions: {
                'srcformat': 'ISO8601Long', 'newformat': 'Y/m/d g:i A'
            }, searchoptions: { dataInit: datePick, attr: { title: '选择日期' }, sopt: ['eq', 'ne', 'le', 'lt', 'gt', 'ge'] }
        },
        { name: 'ReveiveBankReceipt', index: 'ReveiveBankReceipt', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'CreateUser', index: 'CreateUser', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        {
            name: 'CreateDate', index: 'CreateDate', width: 100, align: 'left', formatter: 'date',
            formatoptions: {
                'srcformat': 'ISO8601Long', 'newformat': 'Y/m/d g:i A'
            }, searchoptions: { dataInit: datePick, attr: { title: '选择日期' }, sopt: ['eq', 'ne', 'le', 'lt', 'gt', 'ge'] }
        },

    ],
    shrinkToFit: false,
    autowidth: false,
    jsonReader: {
        page: "page",
        total: "total",
        repeatitems: false
    },
    height: 350,
    pager: jQuery('#pager1'),
    rowNum: 30,
    rowList: [10, 20, 30],
    sortname: 'RequestID',
    sortorder: 'desc',
    viewrecords: true,
    caption: 'IssueRepairOrder',
    multiselect: true
}).navGrid("#pager1", { edit: false, add: false, del: false },
                {},
                {},
                {},
                { multipleSearch: true, multipleGroup: false }
                );
var grid = jQuery("#list1").jqGrid('filterToolbar', { searchOperators: true, stringResult: true }, 'setFrozenColumns');
//jQuery("#list1").jqGrid('setFrozenColumns');

$(window).resize(function () {
    $(window).unbind("onresize");
    fnResizeControl();
    $(window).bind("onresize", this);
});

function fnResizeControl() {
    //debugger;
    grid.setGridWidth($(window).width() * 0.99);
    grid.setGridHeight($(window).height() - 260);
}
fnResizeControl();