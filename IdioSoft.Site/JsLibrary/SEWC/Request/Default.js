var exports = this;
jQuery(function ($) {
    var myModal = $("<div id='myModal' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true' style='width: 610px;'><div class='modal-header'><button type='button' class='close' data-dismiss='modal' aria-hidden='true'></button><h3 id='myModalLabel'><span data-icon='&#x0026;' style='font-size: 18px;'></span>Request</h3></div><div class='modal-body'></div></div>");
    var myModalError = $("<div id='myModalError' class='modal warning bg-color-blu hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'><div class='modal-body'><p class='pErrorTitle'></p></div><div class='modal-footer'><button class='btn btn-large' data-dismiss='modal'>Close</button></div></div>");
    var selectID = "";
    exports.RequestDefault = Controller.create({
        elements: {
            "#lnkAddNewRequest": "lnkAddNewRequest",
            "#lnkDetail": "lnkDetail",
            "#lnkExport": "lnkExport",
            "#list1": "list1",
            "#navToolbar": "navToolbar",
            "#lnkRefresh": "lnkRefresh"
        },
        events: {
            "click #lnkAddNewRequest": "fnAddNewRequest",
            "click #lnkDetail": "fnDetail",
            "click #lnkExport": "fnExport",
            "click #lnkRefresh": "fnRefresh"
        },
        fnRefresh: function () {
            grid.trigger("reloadGrid");
        },
        fnDetail: function (obj) {
            var aryRow;
            var sID = "";
            aryRow = $(list1).jqGrid('getGridParam', 'selarrrow');
            if (aryRow.length == 1) {
                for (var i = 0; i < aryRow.length; i++) {
                    sID = $(list1).getCell(aryRow[i], "uRequestID");
                }
            } else {
                myModalError.find(".pErrorTitle").text("Please select a record!");
                $(myModalError).modal({
                    keyboard: false,
                    Clickhide: true
                })
                return;
            }
            this.fnNavSelectItem(obj);
            window.open("../../SEWC/Request/SEWCRequestOperation.aspx?uRequestID=" + sID + "&OperationType=Modify", 'mywindow', 'width=740,height=550,top=250, left=300, toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no,status=no');
        },
        fnAddNewRequest: function (obj) {
            //debugger;
            this.fnNavSelectItem(obj);
            var sID = "".getGuid();
            window.open("../../SEWC/Request/SEWCRequestOperation.aspx?uRequestID=" + sID + "&OperationType=Addnew", 'mywindow', 'width=740,height=550,top=150, left=300, toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no,status=no');
        },
        fnExport: function () {
            $.ajax({
                type: "POST",
                url: "../../../InterfaceLibrary/Util/ExportExcelList.ashx?SQLInfoKey=1",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "",
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
    var objRequestDefault = new RequestDefault({ el: $("#divMain"), KeyID: "" });
    $('.nav-icon').tooltip();
});

datePick = function (elem) {
    jQuery(elem).datepicker({
        dateFormat: 'yy-mm-dd',
        changeYear: true,
        changeMonth: true
    });
}

jQuery("#list1").jqGrid({
    url: '../../InterfaceLibrary/SEWC/Request/Default.ashx',
    datatype: "json",
    mtype: 'Post',
    colNames: ['uRequestID', 'RequestID', 'NotificationNo', 'CreateUser', 'CreateDate', 'MLFB', 'SerialNo', 'ProductName', 'ProductDesc', 'ServiceType', 'Warranty'],
    colModel: [
        { name: 'uRequestID', index: 'uRequestID', hidden: true, align: 'left', search: false, frozen: true },
        { name: 'RequestID', index: 'RequestID', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'NotificationNo', index: 'NotificationNo', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'cn', 'eq', 'ew', 'en'] } },
        { name: 'CreateUser', index: 'CreateUser', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'cn', 'eq', 'ew', 'en'] } },
        {
            name: 'CreateDate', index: 'CreateDate', width: 160, align: 'left', formatter: 'date',
            formatoptions: {
                'srcformat': 'ISO8601Long', 'newformat': 'Y/m/d g:i A'
            }, searchoptions: { dataInit: datePick, attr: { title: '选择日期' }, sopt: ['eq', 'ne', 'le', 'lt', 'gt', 'ge'] }
        },
        { name: 'MLFB', index: 'MLFB', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'cn', 'eq', 'ew', 'en'] } },
        { name: 'SerialNo', index: 'SerialNo', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'cn', 'eq', 'ew', 'en'] } },
        {
            name: 'ProductName', index: 'ProductName', sorttype: 'string', searchoptions: {
                dataUrl: '../../InterfaceLibrary/SEWC/Request/getDropDownList.ashx?sType=productname',
                buildSelect: function (resp) {
                    return resp;
                }, sopt: ['eq']
            }, stype: 'select'
        },
        {
            name: 'ProductDesc', index: 'ProductDesc', stype: 'select', sorttype: 'string', searchoptions: {
                dataUrl: '../../InterfaceLibrary/SEWC/Request/getDropDownList.ashx?sType=productdesc',
                buildSelect: function (resp) {
                    return resp;
                }, sopt: ['eq']
            }, stype: 'select'
        },
        {
            name: 'ServiceType', index: 'ServiceType', stype: 'select', sorttype: 'string', searchoptions: {
                dataUrl: '../../InterfaceLibrary/SEWC/Request/getDropDownList.ashx?sType=servicetype',
                buildSelect: function (resp) {
                    return resp;
                }, sopt: ['eq']
            }, stype: 'select'
        },
        {
            name: 'Warranty', index: 'Warranty', stype: 'select', sorttype: 'string', searchoptions: {
                dataUrl: '../../InterfaceLibrary/SEWC/Request/getDropDownList.ashx?sType=warranty',
                buildSelect: function (resp) {
                    return resp;
                }, sopt: ['eq']
            }, stype: 'select'
        }
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
    caption: 'Request',
    multiselect: true,
    multiboxonly: true
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