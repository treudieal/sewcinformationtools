var exports = this;
jQuery(function ($) {
    var myModal = $("<div id='myModal' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true' style='width: 610px;'><div class='modal-header'><button type='button' class='close' data-dismiss='modal' aria-hidden='true'></button><h3 id='myModalLabel'><span data-icon='&#x0026;' style='font-size: 18px;'></span>ReceiveDefectiveDate</h3></div><div class='modal-body'></div></div>");
    var myModalError = $("<div id='myModalError' class='modal warning bg-color-blu hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'><div class='modal-body'><p class='pErrorTitle'></p></div><div class='modal-footer'><button class='btn btn-large' data-dismiss='modal'>Close</button></div></div>");
    var selectID = "";
    exports.GoodsReceiptDefault = Controller.create({
        elements: {
            "#lnkDetail": "lnkDetail",
            "#lnkEdit": "lnkEdit",
            "#lnkExport": "lnkExport",
            "#list1": "list1",
            "#navToolbar": "navToolbar",
            "#lnkRefresh": "lnkRefresh",
            "#lnkT3": "lnkT3"
        },
        events: {
            "click #lnkEdit": "fnEditGoodReceipt",
            "click #lnkExport": "fnExport",
            "click #lnkRefresh": "fnRefresh",
            "click #lnkT3": "fnT3"
        },
        fnRefresh: function () {
            grid.trigger("reloadGrid");
        },
        fnEditGoodReceipt: function (obj) {
            var aryRow;
            var sID = "";
            aryRow = $(list1).jqGrid('getGridParam', 'selarrrow');
            if (aryRow.length == 1) {
                sID = $(list1).getCell(aryRow[0], "uRequestID");
            }
            else {
                myModalError.find(".pErrorTitle").text("Please select a record!");
                $(myModalError).modal({
                    keyboard: false,
                    Clickhide: true
                })
                return;
            }
            window.open("GoodsReceiptOperation.aspx?sID=" + sID + "", 'mywindow', 'width=740,height=500,top=150, left=300, toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no,status=no');
        },
        fnT3: function (obj) {
            var aryRow;
            var sID = "";
            aryRow = $(list1).jqGrid('getGridParam', 'selarrrow');
            if (aryRow.length > 0) {
                for (var i = 0; i < aryRow.length; i++) {
                    sID = sID + $(list1).getCell(aryRow[i], "uRequestID") + ",";
                }
            }
            else {
                myModalError.find(".pErrorTitle").text("Please select records!");
                $(myModalError).modal({
                    keyboard: false,
                    Clickhide: true
                })
                return;
            }
            if (sID != "") {
                sID = sID.substring(0, sID.length - 1);
            }
            window.open("T3Operation.aspx?sID=" + sID + "", 'mywindow', 'width=500,height=450,top=150, left=300, toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no,status=no');
        },
        fnExport: function () {
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/Util/ws_Util.asmx/funString_ExportExcel",
                contentType: "application/json",
                dataType: "json",
                data: "{SQLInfoKey:2}",
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
    });
    var objGoodsReceiptDefault = new GoodsReceiptDefault({ el: $("#divMain"), KeyID: "" });
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
    url: '../../InterfaceLibrary/SEWC/GoodsReceipt/Default.ashx',
    datatype: "json",
    mtype: 'Post',
    colNames: ['uRequestID', 'Flag', 'RequestID', 'AppCompanyName', 'EnduserCompanyName', 'MLFB', 'SerialNo', 'ProductName', 'ProductDesc', 'SEWCNotificationNo', 'ServiceType', 'Warranty', 'ReceiveDefectiveDateT3'],
    colModel: [
        { name: 'uRequestID', index: 'uRequestID', hidden: true, align: 'left', search: false, frozen: true },

                {
                    name: 'FormatFlag', index: 'FormatFlag', width: 40, align: 'center', search: false, sortable: false, frozen: true, formatter: function (val, opts, rowdata) {
                        var IDays = rowdata.IDays;
                        var returnValue = "";
                        if (IDays > 60) {
                            returnValue = "<img src='../../Style/images/red.png' title='" + IDays + "'/>"
                            return returnValue;
                        }
                        if (IDays > 30) {
                            returnValue = "<img src='../../Style/images/yellow.png' title='" + IDays + "'/>"
                            return returnValue;
                        }
                        if (IDays > 20) {
                            returnValue = "<img src='../../Style/images/blue.png' title='" + IDays + "'/>"
                            return returnValue;
                        }
                        if (IDays > 10) {
                            returnValue = "<img src='../../Style/images/green.png' title='" + IDays + "'/>"
                            return returnValue;
                        }
                        returnValue = "<img src='../../Style/images/black.png'  title='" + IDays + "'/>"
                        return returnValue;
                    }
                },
        { name: 'RequestID', index: 'RequestID', align: 'left', width: '120px', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] }, frozen: true },
        { name: 'AppCompanyName', index: 'AppCompanyName', width: '200px', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'EnduserCompanyName', index: 'EnduserCompanyName', width: '200px', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'MLFB', index: 'MLFB', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'cn', 'eq', 'ew', 'en'] } },
        { name: 'SerialNo', index: 'SerialNo', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },

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

        { name: 'SEWCNotificationNo', index: 'SEWCNotificationNo', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] }, frozen: true },
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
        },
        {
            name: 'ReceiveDefectiveDateT3', index: 'ReceiveDefectiveDate(T3)', width: '160px', align: 'left', formatter: 'date',
            formatoptions: {
                'srcformat': 'ISO8601Long', 'newformat': 'Y/m/d g:i A'
            }, searchoptions: { dataInit: datePick, attr: { title: '选择日期' }, sopt: ['eq', 'ne', 'le', 'lt', 'gt', 'ge'] }
        }
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
    caption: 'GoodsReceipt',
    multiselect: true,
    multiboxonly: true
}).navGrid("#pager1", { edit: false, add: false, del: false },
                {},
                {},
                {},
                { multipleSearch: true, multipleGroup: false }
                );
var grid = jQuery("#list1").jqGrid('filterToolbar', { searchOperators: true, stringResult: true }, 'setFrozenColumns');
//grid.jqGrid('setFrozenColumns');

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