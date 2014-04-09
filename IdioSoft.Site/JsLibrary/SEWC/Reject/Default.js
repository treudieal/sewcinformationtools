var exports = this;
jQuery(function ($) {
    var myModal = $("<div id='myModal' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true' style='width: 610px;'><div class='modal-header'><button type='button' class='close' data-dismiss='modal' aria-hidden='true'></button><h3 id='myModalLabel'><span data-icon='&#x0026;' style='font-size: 18px;'></span>Reject</h3></div><div class='modal-body'></div></div>");
    var myModalError = $("<div id='myModalError' class='modal warning bg-color-blu hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'><div class='modal-body'><p class='pErrorTitle'></p></div><div class='modal-footer'><button class='btn btn-large' data-dismiss='modal'>Close</button></div></div>");
    var selectID = "";
    exports.RejectDefault = Controller.create({
        elements: {
            "#lnkReverse": "lnkReverse",
            "#lnkExport": "lnkExport",
            "#list1": "list1",
            "#navToolbar": "navToolbar",
            "#lnkRefresh": "lnkRefresh"
        },
        events: {
            "click #lnkReverse": "fnReverse",
            "click #lnkExport": "fnExport",
            "click #lnkRefresh": "fnRefresh"
        },
        fnRefresh: function () {
            grid.trigger("reloadGrid");
        },
        fnReverse: function (obj) {
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
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Reject/ReverseOperation.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "sID=" + sID + "",
                success: function (msg) {
                    switch (msg) {
                        case "0":
                            alert("Reverse Successfully!");
                            //parent.$.fn.colorbox.close();
                            //window.close();
                            break;
                        case "1":
                            alert("Reverse Error!");
                            break;
                    }
                }
            });
        },
        fnExport: function () {
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/Util/ws_Util.asmx/funString_ExportExcel",
                contentType: "application/json",
                dataType: "json",
                data: "{SQLInfoKey:7}",
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
        fnNavSelectItem: function (obj) {
            $(navToolbar).find("li").each(function (index) {
                $(this).removeClass("active");
            });
            $(obj.target).parent().addClass("active");
        }
    });
    var objRejectDefault = new RejectDefault({ el: $("#divMain"), KeyID: "" });
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
    url: '../../InterfaceLibrary/SEWC/Reject/Default.ashx',
    datatype: "json",
    mtype: 'Post',
    colNames: ['uRequestID', 'RequestID', 'SEWCNotificationNo', 'MLFB', 'SerialNo', 'Warranty', 'RejectReason', 'RejectFile'],
    colModel: [
        { name: 'uRequestID', index: 'uRequestID', hidden: true, align: 'left', search: false, frozen: true },
        { name: 'RequestID', index: 'RequestID', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] }, frozen: true },
        { name: 'SEWCNotificationNo', index: 'SEWCNotificationNo', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'MLFB', index: 'MLFB', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'SerialNo', index: 'SerialNo', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'Warranty', index: 'Warranty', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        { name: 'RejectReason', index: 'RejectReason', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] }, frozen: true },
        { name: 'RejectFile', index: 'RejectFile', align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
        
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
    caption: 'Reject',
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