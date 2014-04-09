var exports = this;
var grid;
jQuery(function ($) {
    var myModal = $("<div id='myModal' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true' style='width: 610px;'><div class='modal-header'><button type='button' class='close' data-dismiss='modal' aria-hidden='true'></button><h3 id='myModalLabel'><span data-icon='&#x0026;' style='font-size: 18px;'></span>Delivery</h3></div><div class='modal-body'></div></div>");
    var myModalError = $("<div id='myModalError' class='modal warning bg-color-blu hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'><div class='modal-body'><p class='pErrorTitle'></p></div><div class='modal-footer'><button class='btn btn-large' data-dismiss='modal'>Close</button></div></div>");
    var selectID = "";
    exports.AllDefault = Controller.create({
        elements: {
            "#lnkExport": "lnkExport",
            "#list1": "list1",
            "#navToolbar": "navToolbar",
            "#lnkRefresh": "lnkRefresh",
        },
        events: {
            "click #lnkExport": "fnExport",
            "click #lnkRefresh": "fnRefresh"
        },
        fnRefresh:function(){
            grid.trigger("reloadGrid");
        },
        fnExport: function () {
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/Util/ws_Util.asmx/funString_ExportExcel",
                contentType: "application/json",
                dataType: "json",
                data: "{SQLInfoKey:8}",
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
                },
                error: function (msg) {
                    var dd = "";
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

//uRequestID, RequestID, MLFB, SerialNo, ProductGroup,ProductDesc, SEWCNotificationNo, ServiceType, Warranty, DeliveryCustomer, TrackingNo, CaseTime, ProductName, EndRepairDate, 
//DeliveryDate, AppCompanyName, EnduserCompanyName, [ReceiveDefectiveDate(T3)], NewMLFB, NewSerialNo, [Weight(Unit)], issueDNDate, WorkStationCode,
//[FuntinalState(original)], [FuntinalState(latest)], [Firmware(original)], [Firmware(latest)], ConfirmCompleteDate, StartRepairDate, Engineer, RepairResult, ReceiveCompany, Receiver, ReceiverTel,
//ReceiverAddress
jQuery("#list1").jqGrid({
    //url: '../../InterfaceLibrary/SEWC/All/ws_All.asmx/subLoadGridList',
    url: '../../InterfaceLibrary/SEWC/All/Default.ashx',
    datatype: "json",
    mtype: 'Post',
    colNames: ['uRequestID', 'RequestID', 'MLFB', 'SerialNo', 'ProductGroup', 'ProductName', 'ProductDesc', 'SEWCNotificationNo', 'ServiceType', 'Warranty', 'DeliveryCustomer', 'TrackingNo', 'CaseTime', 'EndRepairDate',
                'DeliveryDate', 'AppCompanyName', 'EnduserCompanyName', 'ReceiveDefectiveDateT3', 'NewMLFB', 'NewSerialNo', 'WeightUnit', 'issueDNDate', 'WorkStationCode',
                'FuntinalStateoriginal', 'FuntinalStatelatest', 'Firmwareoriginal', 'Firmwarelatest', 'ConfirmCompleteDate', 'Engineer', 'RepairResult', 'ReceiveCompany', 'Receiver', 'ReceiverTel',
                'ReceiverAddress'
    ],
    colModel: [
        { name: 'uRequestID', index: 'uRequestID', hidden: true, align: 'left', search: false, frozen: true },
        { name: 'RequestID', index: 'RequestID', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] }, frozen: true },
        { name: 'MLFB', index: 'MLFB', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'SerialNo', index: 'SerialNo', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'ProductGroup', index: 'ProductGroup', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'ProductName', index: 'ProductName', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'ProductDesc', index: 'ProductDesc', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'SEWCNotificationNo', index: 'SEWCNotificationNo', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'ServiceType', index: 'ServiceType', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'Warranty', index: 'Warranty', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'DeliveryCustomer', index: 'DeliveryCustomer', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'TrackingNo', index: 'TrackingNo', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        {
            name: 'CaseTime', index: 'CaseTime', width: 100, align: 'left', formatter: 'date',
            formatoptions: {
                'srcformat': 'ISO8601Long', 'newformat': 'Y-m-d H:i:s'
            }, searchoptions: { dataInit: datePick, attr: { title: '选择日期' }, sopt: ['eq', 'ne', 'le', 'lt', 'gt', 'ge'] }
        },
        {
            name: 'EndRepairDate', index: 'EndRepairDate', width: 100, align: 'left', formatter: 'date',
            formatoptions: {
                'srcformat': 'ISO8601Long', 'newformat': 'Y/m/d g:i A'
            }, searchoptions: { dataInit: datePick, attr: { title: '选择日期' }, sopt: ['eq', 'ne', 'le', 'lt', 'gt', 'ge'] }
        },
        {
            name: 'DeliveryDate', index: 'DeliveryDate', width: 100, align: 'left', formatter: 'date',
            formatoptions: {
                'srcformat': 'ISO8601Long', 'newformat': 'Y/m/d g:i A'
            }, searchoptions: { dataInit: datePick, attr: { title: '选择日期' }, sopt: ['eq', 'ne', 'le', 'lt', 'gt', 'ge'] }
        },
        { name: 'AppCompanyName', index: 'AppCompanyName', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'EnduserCompanyName', index: 'EnduserCompanyName', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        {
            name: 'ReceiveDefectiveDateT3', index: 'ReceiveDefectiveDateT3', width: 100, align: 'left', formatter: 'date',
            formatoptions: {
                'srcformat': 'ISO8601Long', 'newformat': 'Y/m/d g:i A'
            }, searchoptions: { dataInit: datePick, attr: { title: '选择日期' }, sopt: ['eq', 'ne', 'le', 'lt', 'gt', 'ge'] }
        },
        { name: 'NewMLFB', index: 'NewMLFB', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'NewSerialNo', index: 'NewSerialNo', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'WeightUnit', index: 'WeightUnit', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        {
            name: 'issueDNDate', index: 'issueDNDate', width: 100, align: 'left', formatter: 'date',
            formatoptions: {
                'srcformat': 'ISO8601Long', 'newformat': 'Y/m/d g:i A'
            }, searchoptions: { dataInit: datePick, attr: { title: '选择日期' }, sopt: ['eq', 'ne', 'le', 'lt', 'gt', 'ge'] }
        },

        { name: 'WorkStationCode', index: 'WorkStationCode', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'FuntinalStateoriginal', index: 'FuntinalStateoriginal', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'FuntinalStatelatest', index: 'FuntinalStatelatest', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'Firmwareoriginal', index: 'Firmwareoriginal', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'Firmwarelatest', index: 'Firmwarelatest', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        {
            name: 'ConfirmCompleteDate', index: 'ConfirmCompleteDate', width: 100, align: 'left', formatter: 'date',
            formatoptions: {
                'srcformat': 'ISO8601Long', 'newformat': 'Y/m/d g:i A'
            }, searchoptions: { dataInit: datePick, attr: { title: '选择日期' }, sopt: ['eq', 'ne', 'le', 'lt', 'gt', 'ge'] }
        },
        { name: 'Engineer', index: 'Engineer', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'RepairResult', index: 'RepairResult', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'ReceiveCompany', index: 'ReceiveCompany', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'Receiver', index: 'Receiver', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'ReceiverTel', index: 'ReceiverTel', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'ReceiverAddress', index: 'ReceiverAddress', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } }
    ],

    shrinkToFit: false,
    autowidth: true,
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
    caption: 'Delivery',
    multiselect: true,
    multiboxonly: true
}).navGrid("#pager1", { edit: false, add: false, del: false },
                {},
                {},
                {},
                { multipleSearch: true, multipleGroup: false }
                );
grid = jQuery("#list1").jqGrid('filterToolbar', { searchOperators: true, stringResult: true }, 'setFrozenColumns');
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