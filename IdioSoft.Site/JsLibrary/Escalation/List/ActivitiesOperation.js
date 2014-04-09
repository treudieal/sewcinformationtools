var exports = this;
var grid;
var SaveID = "";
var sID = EscalationID;
var objAllDefault;
jQuery(function ($) {
    var myModal = $("<div id='myModal' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true' style='width: 610px;'><div class='modal-header'><button type='button' class='close' data-dismiss='modal' aria-hidden='true'></button><h3 id='myModalLabel'><span data-icon='&#x0026;' style='font-size: 18px;'></span>Delivery</h3></div><div class='modal-body'></div></div>");
    var myModalError = $("<div id='myModalError' class='modal warning bg-color-blu hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'><div class='modal-body'><p class='pErrorTitle'></p></div><div class='modal-footer'><button class='btn btn-large' data-dismiss='modal'>Close</button></div></div>");
    var selectID = "";
    exports.AllDefault = Controller.create({
        elements: {
            ".clsItemAddnew": "btnItemAddnew",
            ".clsItemModify": "btnItemModify",
            ".clsItemDelete": "btnItemDelete",
            ".clsItemSave": "btnItemSave",
            "#spanAOperationTitle": "spanAOperationTitle",
            "#fileUpload": "fileUpload",
            "#btnUpload": "btnUpload",
            "#divActivitiesOperation": "divActivitiesOperation",
            ".clstdAttachmentList": "tdAttachmentList",
            ".clstxtCurrentStatus": "txtCurrentStatus",
            ".clstxtComments": "txtComments",
            ".clstxtNextStep": "txtNextStep",
            ".dellink": "dellink",
            "#btnItemBack":"btnItemBack"
        },
        events: {
            "click .clsItemSave": "fnSave",
            "click .clsItemAddnew": "fnAddnew",
            "click .clsItemModify": "fnModify",
            "click .clsItemDelete": "fnDelete",
            "click #btnUpload": "fnUpload",
            "click .dellink": "fnDeleteAttachment",
            "click #btnItemBack":"fnBack"
        },
        fnBack: function () {
            window.history.back();
        },
        fnSave: function () {
            if (SaveID == "") {
                alert("只有在Addnew,Modify才可以保存数据!");
                return;
            }
            var CurrentStatus = encodeURI(this.txtCurrentStatus.val());
            var NextStep = encodeURI(this.txtNextStep.val());
            var Comments = encodeURI(this.txtComments.val());

            var objParams = new Object();
            var objP = new Object();
            objP.CurrentStatus = CurrentStatus;
            objP.NextStep = NextStep;
            objP.Comments = Comments;
            objP.OperationType = "Save";
            objP.EscalationID = sID
            objP.ActivityID = SaveID;

            var myArray = new Array();
            myArray[0] = objP;
            objParams.ParamsList = myArray;
            var json = JSON.stringify(objParams);

            var vrthis = this;
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../../InterfaceLibrary/Escalation/List/wsEscalation.asmx/subDB_SaveActivity",
                dataType: "json",
                data: json,
                success: function (msg) {
                    switch (msg.d) {
                        case "":
                            grid.trigger("reloadGrid");
                            vrthis.fnOperationControlClear();
                            vrthis.fnOperationType("");
                            alert("Save Successfully!");
                            break;
                        case "error":
                            alert("Save Error!");
                            break;
                    }
                }
            });
        },
        fnAddnew: function () {
    
            this.fnOperationControl(true);
            this.fnOperationControlClear();
            this.fnOperationType("Addnew");
            SaveID = "".getGuid();
        },
        fnModify: function () {
            this.fnOperationControl(true);
            this.fnOperationType("Modify");

            var intRow;
            intRow = $(list1).jqGrid('getGridParam', 'selrow');
            var sID = $(list1).getCell(intRow, "ActivityID");
            SaveID = sID;

            this.fnLoadDetail(sID);
        },
        fnDelete: function () {
            var vrthis = this;

            var intRow;
            intRow = $(list1).jqGrid('getGridParam', 'selrow');
            var sID = $(list1).getCell(intRow, "ActivityID");

            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../../InterfaceLibrary/Escalation/List/wsEscalation.asmx/subDB_DeleteActivity",
                data: "{ActivityID:'" + sID + "'}",
                success: function (msg) {
                    switch (msg.d) {
                        case "0":
                            grid.trigger("reloadGrid");
                            vrthis.fnOperationControlClear();
                            alert("Delete Successfully!");
                            break;
                        case "1":
                            alert("Delete Error!");
                            break;
                    }
                }
            });
        },
        fnOperationControl: function (isDisable) {
            this.txtCurrentStatus.removeAttr("disabled");
            this.txtComments.removeAttr("disabled");
            this.txtNextStep.removeAttr("disabled");
            this.btnItemSave.removeAttr("disabled");
            if (!isDisable) {
                this.txtCurrentStatus.attr("disabled", "disabled");
                this.txtComments.attr("disabled", "disabled");
                this.txtNextStep.attr("disabled", "disabled");
                this.btnItemSave.attr("disabled", "disabled");
            }
        },
        fnOperationControlClear: function () {
            this.txtCurrentStatus.val("");
            this.txtComments.val("");
            this.txtNextStep.val("");
            $(".clstdAttachmentList").empty();
        },
        fnOperationType: function (OType) {
            OperType = OType;
            this.spanAOperationTitle.text(OperType);
        },
        fnLoadDetail: function (ActivityID) {
            var self = this;

            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../../InterfaceLibrary/Escalation/List/wsEscalation.asmx/ReturnActivityInfo",
                dataType: "json",
                data: "{ActivityID:'" + ActivityID + "'}",
                success: function (msg) {
                    var result = msg.d;
                    self.txtCurrentStatus.val(result.CurrentStatus.FieldValue);
                    self.txtNextStep.val(result.NextStep.FieldValue);
                    self.txtComments.val(result.Comments.FieldValue);
                    self.fnLoadDetailFile(ActivityID);
                   
                },
                error: function (e) {
                }
            });
        },
        fnLoadDetailFile: function (ActivityID) {
            var self = this;
            $(".clstdAttachmentList").empty();
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../../InterfaceLibrary/Escalation/List/wsEscalation.asmx/ReturnActivityInfoFile",
                dataType: "json",
                data: "{ActivityID:'" + ActivityID + "'}",
                success: function (msg) {
                    $(".clstdAttachmentList").append(msg.d);
                },
                error: function (e) {
                }
            });
        },
        fnDeleteAttachment: function (obj) {
            var fid = $(obj.target).attr("KeyID");

            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../../InterfaceLibrary/Escalation/List/wsEscalation.asmx/subDB_DeleteActivityFile",
                data: "{ActivityFileID:'" + fid + "'}",
                success: function (msg) {
                    switch (msg.d) {
                        case "0":
                            $(obj.target).parent().remove();
                            break;
                        case "1":
                            alert("Delete Error!");
                            break;
                    }
                }
            });
        },
        fnUpload: function () {
            var vr = $("#fileUpload").val();
            if (vr == "") {
                alert("请选择上传文件! please choose a document!");
                return;
            }

            this.subProccessLoad(this);
            $.ajaxFileUpload
            (
               {
                   url: '../../InterfaceLibrary/Escalation/List/FileUpLoad.ashx',
                   secureuri: false,
                   fileElementId: 'fileUpload',
                   dataType: 'json',
                   data: { ActivityID: SaveID },
                   success: function (data) {
                       if (data.iserror) {
                           alert("上传文件出现错误! Upload Error!");
                           return;
                       }
                       if (data.fileName != "") {
                           $(".clstdAttachmentList").append("<li><a href='../../Attachment/Escalation/" + data.fileName + "' target='_blank'>" + data.fileName + "</a> <a class='dellink' href='#' id='dellink' KeyID='" + data.fid + "'>[Delete]</a></li>");
                       }
                   },
                   error: function (data) {
                       alert("上传文件出现错误! Upload Error!");
                   }
               }
            )
        },
        subProccessLoad: function (obj) {
            $('body').ajaxStart(function () {
                $(obj).JLoading();
            });
            $('body').ajaxComplete(function () {
                $(obj).UnJLoading();
            });
        }
    });
    objAllDefault = new AllDefault({ el: $("#divMain"), KeyID: "" });
    $('.nav-icon').tooltip();
    objOperation.fnLoadDetail(sID);
});

function fngridLoad() {
    //debugger;
    if (grid != null) {
        grid.GridUnload();
    }
    var vrthis = this;
    var url = "../../InterfaceLibrary/Escalation/List/ActivitiesOperation.ashx?EscalationID=" + sID + "";

    jQuery("#list1").jqGrid({
        url: url,
        datatype: "json",
        mtype: 'Post',
        colNames: ['ActivityID', 'IssuedBy', 'IssuedDate', 'CurrentStatus', 'NextStep'],
        colModel: [
            { name: 'ActivityID', index: 'ActivityID', hidden: true, align: 'left', search: false, frozen: true },
            { name: 'CreateUser', index: 'CreateUser', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
            { name: 'CreatedDate', index: 'CreatedDate', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
            { name: 'CurrentStatus', index: 'CurrentStatus', width: 400, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
            { name: 'NextStep', index: 'NextStep', width: 400, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] }, frozen: true },
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
            var ActivityID = $(list1).getCell(rowid, "ActivityID");
            var self = this;
            objAllDefault.fnLoadDetail(ActivityID);
            objAllDefault.fnOperationControl(false);
        },
        ondblClickRow: function (rowid, iRow, iCol, e) {

        },

        viewrecords: true
    }).navGrid("#pager1", { edit: false, add: false, del: false, search: false })
    grid = jQuery("#list1").jqGrid();
}

fngridLoad();

$(window).resize(function () {
    $(window).unbind("onresize");
    fnResizeControl();
    $(window).bind("onresize", this);
});

function fnResizeControl() {
    //debugger;
    grid.setGridWidth($(window).width() * 0.99);
    var intHeight = $(window).height() - 90;
    $("#divMain").height(intHeight);
    //grid.setGridHeight($(window).height() / 2);
}
fnResizeControl();