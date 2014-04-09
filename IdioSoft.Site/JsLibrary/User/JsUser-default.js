var exports = this;
jQuery(function ($) {
    var myModal = $("<div id='myModal' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true' style='width: 610px;'><div class='modal-header'><button type='button' class='close' data-dismiss='modal' aria-hidden='true'></button><h3 id='myModalLabel'><span data-icon='&#x0026;' style='font-size: 18px;'></span>用户管理</h3></div><div class='modal-body'></div></div>");
    var myModalError = $("<div id='myModalError' class='modal warning bg-color-blu hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'><div class='modal-body'><p class='pErrorTitle'></p></div><div class='modal-footer'><button class='btn btn-large' data-dismiss='modal'>Close</button></div></div>");
    var selectID = "";
    exports.UserDefault = Controller.create({
        elements: {
            "#lnkAddnew": "lnkAddnew",
            "#lnkEdit": "lnkEdit",
            "#lnkDelete": "lnkDelete",
            "#lnkDetail": "lnkDetail",
            "#list1": "list1",
            "#navToolbar": "navToolbar",
            "#myModalConfirm":"myModalConfirm",
            "#btnSaveUser": "btnSaveUser",
            "#btnDelete": "btnDelete"
        },
        events: {
            "click #lnkAddnew": "fnAddnew",
            "click #lnkEdit": "fnEdit",
            "click #lnkDelete": "fnDelete",
            "click #lnkDetail": "fnDetail",
            "click #btnDelete": "fnbtnDelete"
        },
        fnAddnew: function (obj) {
            this.fnNavSelectItem(obj);
            myModal.modal({
                keyboard: false,
                Clickhide: false,
                remote: 'Operation.aspx'
            }).on("shown", function () {
                objUserOperation.OpType = "Addnew";
            });
        },
        fnEdit: function (obj) {
            debugger;
            var aryRow;
            var sID = "";
            aryRow = $(list1).jqGrid('getGridParam', 'selarrrow');
            if (aryRow.length ==1) {
                sID = $(list1).getCell(aryRow[0], "ID");
            }
            else {
                myModalError.find(".pErrorTitle").text("修改记录时只能选取一条记录");
                $(myModalError).modal({
                    keyboard: false,
                    Clickhide: true
                })
                return;
            }
            this.fnNavSelectItem(obj);
            if (sID != "") {
                myModal.modal({
                    keyboard: false,
                    Clickhide: false,
                    remote: 'Operation.aspx?KeyID=' + sID
                }).on("shown", function () {
                    objUserOperation.KeyID = sID;
                    objUserOperation.OpType = "Modify";
                });
            }
        },
        fnDelete: function (obj) {
            var intRow;
            intRow = $(list1).jqGrid('getGridParam', 'selrow');
            var sID = $(list1).getCell(intRow, "ID");
            if (sID != "") {
                $(myModalConfirm).modal({
                    keyboard: false,
                    Clickhide: false
                }).on("shown", function () {
                    selectID = sID;
                });
            }
            this.fnNavSelectItem(obj);
        },
        fnbtnDelete: function () {
            if (selectID == null || selectID == "") {
                return;
            }
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/User/User-operation.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "OpType=Delete&opID=" + selectID,
                success: function (msg) {
                    debugger;
                    switch (msg) {
                        case "0":
                            alert("Delete Successfully!");
                             myModal.modal('hide');
                            break;
                        case "1":
                            alert("Delete Error!");
                            break;
                    }
                }
            });
        },
        fnDetail: function (obj) {
            var aryRow;
            var sID = "";
            aryRow = $(list1).jqGrid('getGridParam', 'selarrrow');
            if (aryRow.length == 1) {
                sID = $(list1).getCell(aryRow[0], "ID")
            }
            else {
                myModalError.find(".pErrorTitle").text("查看详细记录时只能选取一条记录");
                myModalError.modal({
                    keyboard: false,
                    Clickhide: true
                })
                return;
            }
            //s = $(list1).getCell(intRow, "ID");
            this.fnNavSelectItem(obj);
            if (sID != "") {
               myModal.modal({
                    keyboard: false,
                    Clickhide: false,
                    remote: 'Detail.aspx?KeyID=' + sID
                });
            }
        },
        fnNavSelectItem: function (obj) {
            $(navToolbar).find("li").each(function (index) {
                $(this).removeClass("active");
            });
            $(obj.target).parent().addClass("active");
        }
    });
    var objUserDefault = new UserDefault({ el: $("#divMain"),KeyID:"" });
    jQuery('.nav-icon').tooltip();
});

datePick = function (elem) {
    jQuery(elem).datepicker({
        dateFormat: 'yy-mm-dd',
        changeYear: true,
        changeMonth: true,
        onSelect: function (dateText, inst) {
            setTimeout(function () {
                $('#list1')[0].triggerToolbar();
            }, 50);
        }
    });
}
jQuery("#list1").jqGrid({
    url: '../../InterfaceLibrary/User/User-derfault.ashx',
    datatype: "json",
    mtype: 'Post',
    colNames: ['ID', 'Email', 'EnUserName', 'CnUserName', 'Tel', 'Fax', 'Region', 'ServiceProvider'],
    colModel: [
        { name: 'ID', index: 'ID', hidden: true, align: 'left', search: false, frozen: true },
        { name: 'Email', index: 'Email', width: 120, align: 'left', sorttype: 'string', searchoptions: { value: ':Any', sopt: ['eq', 'bw', 'bn', 'cn', 'nc', 'ew', 'en'] }, stype: 'select', frozen: true },
        { name: 'EnUserName', index: 'EnUserName', sortable: false, align: 'left', searchoptions: { sopt: ['eq', 'bw', 'bn', 'cn', 'nc', 'ew', 'en'] } },
        { name: 'CnUserName', index: 'CnUserName', align: 'left', searchoptions: { sopt: ['eq', 'bw', 'bn', 'cn', 'nc', 'ew', 'en'] } },
        { name: 'Tel', index: 'Tel', align: 'left', sorttype: 'string', searchoptions: { sopt: ['eq', 'bw', 'bn', 'cn', 'nc', 'ew', 'en'] } },
        { name: 'Fax', index: 'Fax', align: 'left', sorttype: 'string', searchoptions: { sopt: ['eq', 'bw', 'bn', 'cn', 'nc', 'ew', 'en'] } },
        { name: 'Region', index: 'Region', align: 'left', sorttype: 'string', searchoptions: { opt: ['eq', 'bw', 'bn', 'cn', 'nc', 'ew', 'en'] } },
        { name: 'ServiceProvider', index: 'ServiceProvider', align: 'left', sorttype: 'string', searchoptions: { sopt: ['eq', 'ne', 'le', 'lt', 'gt', 'ge'] } },
    ],
    shrinkToFit: false,
    autowidth: true,
    jsonReader: {
        page: "page",
        total: "total",
        repeatitems: false
    },
    height: 400,
    pager: jQuery('#pager1'),
    rowNum: 30,
    rowList: [10, 20, 30],
    sortname: 'Email',
    sortorder: 'desc',
    viewrecords: true,
    caption: 'User list',
    multiselect: true
}).navGrid("#pager1", { edit: false, add: false, del: false },
                {},
                {},
                {},
                { multipleSearch: true, multipleGroup: false }
                );
var grid = jQuery("#list1").jqGrid('filterToolbar', { searchOperators: true, stringResult: true }, 'setFrozenColumns');
jQuery("#list1").jqGrid('setFrozenColumns');

$(window).resize(function () {
    $(window).unbind("onresize");
    grid.setGridWidth($(window).width() * 0.99);
    $(window).bind("onresize", this);
});