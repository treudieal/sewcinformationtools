var exports = this;
jQuery(function ($) {
    $(".dtpTime").datetimepicker({ dateFormat: 'yy-mm-dd', timeFormat: "HH:mm:ss", defaultValue: new Date().Format("yyyy-MM-dd hh:mm:ss") });
    var myModalError = $("<div id='myModalError' class='modal warning bg-color-blu hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'><div class='modal-body'><p class='pErrorTitle'></p></div><div class='modal-footer'><button class='btn btn-large' data-dismiss='modal'>Close</button></div></div>");
    exports.RepairOperation = Controller.create({
        elements: {
            ".clscboWorkStationCode": "cboWorkStationCode",
            ".clstxtFuntinalStateoriginal": "txtFuntinalStateoriginal",
            ".clstxtFuntinalStatelatest": "txtFuntinalStatelatest",
            ".clstxtFirmwareoriginal": "txtFirmwareoriginal",
            ".clstxtFirmwarelatest": "txtFirmwarelatest",
            ".clscboWarranty": "cboWarranty",
            ".dtpConfirmCompleteDate": "dtpConfirmCompleteDate",
            ".clscboServiceType": "cboServiceType",
            ".clstxtEngineer": "txtEngineer",
            ".dtpEndRepairDate": "dtpEndRepairDate",
            ".clscboRepairResult": "cboRepairResult",
            ".clstxtRemarks": "txtRemarks",
            ".lnkaddother": "lnkaddother",
            ".lnkdelother": "lnkdelother",
            ".tdItems": "tdItems",
            ".btnSave": "btnSave",
            ".btnSubmit": "btnSubmit",
            ".btnReport": "btnReport",
            ".clstrRejectFile": "trRejectFile",
            ".clsfileToUpload": "fileToUpload",
            ".clsbtnUploadfile": "btnUploadfile",
            "#tdAttachmentlist": "tdAttachmentlist",
            ".clstxtMLFB": "txtMLFB",
            ".clstxtSerialNo": "txtSerialNo",
            ".clstxtQty": "txtQty",
            ".clstxtPCBA5ENo": "txtPCBA5ENo",
            ".clsRepairedComponentA5E": "txtRepairedComponentA5E",
            ".clscboFailureType": "cboFailureType",
            ".clscboFailureKind": "cboFailureKind",
            ".clstxtFcode": "txtFcode",
            ".clscboFailureCasedType": "cboFailureCasedType",
            ".clstxtLaborCost": "txtLaborCost"
        },
        events: {
            "click .lnkaddother": "fnAddother",
            "click .lnkdelother": "fnLnkdelother",
            "click .btnSave": "fnDBSave",
            "click .btnSubmit": "fnDBSubmit",
            "click .btnReport": "fnReport",
            "change .clscboFailureType": "fncboFailureTypeChange",
            "change .clscboFailureKind": "fncboFCodeChange",
            "change .clscboRepairResult": "fnRepariResultChange",
            "click .clsbtnUploadfile": "fnFileUpload",
            "click .clsbtnDeletefile": "fnDeletefile"
        },
        fnPCBA5ENoLoad: function () {
            $(".clstxtPCBA5ENo").autocomplete("../../InterfaceLibrary/SEWC/Repair/OperationUtil.ashx?Type=PCBA5ENo", {
                width: 180,
                selectFirst: false
            });
            //this.fnCalLaborCost();
        },
        fnRepairedComponentLoad: function () {
            $(".clsRepairedComponentA5E").autocomplete("../../InterfaceLibrary/SEWC/Repair/OperationUtil.ashx?Type=RepairedComponent", {
                width: 180,
                selectFirst: false
            });
            //this.fnCalLaborCost();
        },
        fnFileUpload: function () {
            //UpLoadFile.ashx
            var RepairResult = encodeURI(this.cboRepairResult.val());
            $.ajaxFileUpload({
                url: '../../InterfaceLibrary/SEWC/Repair/ws_Repair.asmx/funString_UploadFile',
                secureuri: false,
                fileElementId: "fileToUpload",
                dataType: 'json',
                type:"post",
                data: { uRequestID: PuRequestIDs, RepairResult: RepairResult },
                success: function (data) {
                    //debugger;
                    var fs = data.fileName;
                    if (data.iserror) {
                        myModalError.find(".pErrorTitle").text("upload file error!");
                        $(myModalError).modal({
                            keyboard: false,
                            Clickhide: true
                        });
                        return false;
                    }
                    if (data.fileName != "") {
                        $(".clstdAttachmentlist").html("");
                        $(".clstdAttachmentlist").append("<a href='../../Attachment/Sewc/" + data.fileName + "' target='_blank'>" + data.fileName + "</a>");
                    }
                },
                error: function (data) {
                    myModalError.find(".pErrorTitle").text("upload file error!");
                    $(myModalError).modal({
                        keyboard: false,
                        Clickhide: true
                    });
                    return false;
                }
            });
            return false;
        },
        fnDeletefile: function () {
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Repair/RepairOperation.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "uRequestID=" + PuRequestIDs + "&OperationType=DeleteFile",
                success: function (msg) {
                    switch (msg) {
                        case "0":
                            $(".clstdAttachmentlist").text("");
                            alert("Delete Successfully!");
                            break;
                        case "1":
                            myModalError.find(".pErrorTitle").text("delete file error!");
                            $(myModalError).modal({
                                keyboard: false,
                                Clickhide: true
                            });
                            break;
                    }
                }
            });
        },
        fnRepariResultChange: function () {
            switch (this.cboRepairResult.val().toLowerCase()) {
                case "scrap":
                case "reject":
                    this.trRejectFile.show();
                    break;
                default:
                    this.trRejectFile.hide();
                    break;
            }
        },
        fnAddother: function (obj) {
            var vtr = $(".tdItems table").eq(0);
            var $vtrNew = $(vtr.clone());
            $vtrNew.find("input").val("");
            $vtrNew.find("select").val("");
            $vtrNew.find(".lnkaddother").remove();
            $vtrNew.find(".lnkdelother").show();
            $(".tdItems").append($vtrNew);
            this.fnPCBA5ENoLoad();
            this.fnRepairedComponentLoad();
            var inttop = $vtrNew.offset().top;
            $(".clsMainForm").animate({ scrollTop: inttop }, 200);
            this.fnCalLaborCost();
        },
        fnLnkdelother: function (obj) {
            //debugger;
            var $curtbl = $($(obj.target).parent().parent().parent().parent());
            var curIndex = $curtbl.index();
            if (curIndex == 0) {
                return false;
            }
            if ($(".tdItems table").length == 1) {
                return false;
            }
            var vtr = $(obj.target).parents("table")[0];
            $(vtr).remove();
            this.fnCalLaborCost();
            return false;
        },
        fnCalLaborCost: function () {
            //if (!this.txtLaborCost.is(":disabled")) {
            //    return;
            //}
            var intcount = 0;
            var vCount = $(".tdItems table").length;
            for (var i = 0; i < vCount; i++) {
                var $tbl = $($(".tdItems table").eq(i));
                var PCBA5ENo = $tbl.find(".clstxtPCBA5ENo").val();
                var RepairedComponentA5E = $tbl.find(".clsRepairedComponentA5E").val();

                if ((PCBA5ENo != null && PCBA5ENo != "") && (RepairedComponentA5E != null && RepairedComponentA5E != "")) {
                    intcount++;
                }
            }
            if (intcount == 0) {
                this.txtLaborCost.val("75");
            }
            if (intcount == 1) {
                this.txtLaborCost.val("90");
            }
            if (intcount >=2) {
                this.txtLaborCost.val("105");
            }
        },
        fnSaveProcess: function (intType, e) {
            //debugger;
            var WorkStationCode = encodeURI(this.cboWorkStationCode.val());
            var FuntinalStateoriginal = encodeURI(this.txtFuntinalStateoriginal.val());
            var FuntinalStatelatest = encodeURI(this.txtFuntinalStatelatest.val());
            var Firmwareoriginal = encodeURI(this.txtFirmwareoriginal.val());
            var Firmwarelatest = encodeURI(this.txtFirmwarelatest.val());
            var Warranty = encodeURI(this.cboWarranty.val());
            var ConfirmCompleteDate = encodeURI(this.dtpConfirmCompleteDate.val());
            var ServiceType = encodeURI(this.cboServiceType.val());
            var Engineer = encodeURI(this.txtEngineer.val());

            var EndRepairDate = encodeURI(this.dtpEndRepairDate.val());
            var RepairResult = encodeURI(this.cboRepairResult.val());
            var Remarks = encodeURI(this.txtRemarks.val());
            var sID = PuRequestIDs;
            var FailureCasedType = encodeURI(this.cboFailureCasedType.val());
 
            var LaborCost = encodeURI(this.txtLaborCost.val());
            var MLFB = "";
            var SerialNo = "";
            var Qty = "";

            MLFB = encodeURI(this.txtMLFB.val());
            SerialNo = encodeURI(this.txtSerialNo.val());
            if (!this.txtQty.val().VerifyNumber()) {
                myModalError.find(".pErrorTitle").text("Qty is not number!");
                $(myModalError).modal({
                    keyboard: false,
                    Clickhide: true
                });
                $(e.target).removeAttr("disabled");
                return;
            }
            Qty = this.txtQty.val();

            if (intType == 1 && RepairResult != 'Reject') {
                if (EndRepairDate == "" || ConfirmCompleteDate == "") {
                    myModalError.find(".pErrorTitle").text("EndRepairDate or ConfirmCompleteDate is Null!");
                    $(myModalError).modal({
                        keyboard: false,
                        Clickhide: true
                    });
                    $(e.target).removeAttr("disabled");
                    return;
                }
            }

            var vAll1 = "";
            var vAll = "";
            var vCount = $(".tdItems table").length;
            for (var i = 0; i < vCount; i++) {
                var $tbl = $($(".tdItems table").eq(i));
                var PCBA5ENo = $tbl.find(".clstxtPCBA5ENo").val();
                var RepairedComponentA5E = $tbl.find(".clsRepairedComponentA5E").val();
                var blnPCB = (PCBA5ENo != null && PCBA5ENo != "");
                var blnRepaired = (RepairedComponentA5E != null && RepairedComponentA5E != "");

                if (blnPCB || blnRepaired) {
                    var ComponentLocation = encodeURI($tbl.find(".clsComponentLocation").val());

                    var FailureType = encodeURI($tbl.find(".clscboFailureType").val());

                    var FailureKind = encodeURI($tbl.find(".clscboFailureKind").val());
                    var Fcode = encodeURI($tbl.find(".clstxtFcode").val());

                    var RepairAction = encodeURI($tbl.find(".clscboRepairAction").val());

                    vAll1 = "[" + PCBA5ENo + "$$$" + ComponentLocation + "$$$" + RepairedComponentA5E + "$$$" + FailureType + "$$$" + FailureKind + "$$$" + Fcode + "$$$" + RepairAction + "$$$" + i + "]";
                    vAll = vAll + vAll1;
                }
            }

            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Repair/RepairOperation.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "isSubmit=" + intType + "&Items=" + vAll + "&Remarks=" + Remarks + "&RepairResult=" + RepairResult + "&EndRepairDate=" + EndRepairDate
                    + "&MLFB=" + MLFB + "&SerialNo=" + SerialNo + "&Qty=" + Qty
                    + "&Engineer=" + Engineer + "&ServiceType=" + ServiceType + "&ConfirmCompleteDate=" + ConfirmCompleteDate + "&LaborCost=" + LaborCost
                    + "&Warranty=" + Warranty + "&WorkStationCode=" + WorkStationCode + "&FuntinalStateoriginal=" + FuntinalStateoriginal + "&FailureCasedType=" + FailureCasedType
                    + "&FuntinalStatelatest=" + FuntinalStatelatest + "&Firmwareoriginal=" + Firmwareoriginal + "&Firmwarelatest=" + Firmwarelatest + "&uRequestID=" + sID + "&OperationType=save",
                success: function (msg) {
                    //debugger;
                    switch (msg) {
                        case "0":
                            $(e.target).removeAttr("disabled");
                            alert("Save Successfully!");
                            //parent.$.fn.colorbox.close();
                            window.close();
                            break;
                        case "1":
                            $(e.target).removeAttr("disabled");
                            alert("Save Error!");
                            break;
                    }
                }
            });
        },
        fnDBSave: function (e) {
            $(e.target).attr("disabled", "disabled");
            this.fnSaveProcess(0, e);

        },
        fnDBSubmit: function (e) {
            $(e.target).attr("disabled", "disabled");
            this.fnSaveProcess(1, e);

        },
        fnReport: function (e) {
            $(e.target).attr("disabled", "disabled");
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Repair/RepairReport.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "uRequestID=" + PuRequestIDs + "",
                success: function (msg) {
                    if (msg != "") {
                        $(e.target).removeAttr("disabled");
                        window.open("../../temp/" + msg);
                    } else {
                        myModalError.find(".pErrorTitle").text("Report Error!");
                        $(myModalError).modal({
                            keyboard: false,
                            Clickhide: true
                        });
                        $(e.target).removeAttr("disabled");
                        return false;
                    }
                }
            });
        },
        fncboFailureTypeChange: function (obj) {
            var FailureType = encodeURI($(obj.target).val());
            var self = this;
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Repair/OperationUtil.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "FailureType=" + FailureType + "&Type=FailureType",
                success: function (msg) {
                    var FailureKind = eval("(" + unescape(msg) + ")");
                    var $cbo = $($(obj.target).parent().parent().parent().find(".clscboFailureKind"));
                    $cbo.empty();
                    $cbo.append("<option value=''> </option>");
                    if (FailureKind != "") {
                        for (var i = 0; i < FailureKind.length; i++) {
                            $cbo.append("<option value='" + FailureKind[i] + "'>" + FailureKind[i] + "</option>");
                        }
                    }
                }
            });

        },
        fncboFCodeChange: function (obj) {
            var FailureKind = encodeURI($(obj.target).val());
            var FailureType = $(obj.target).parent().parent().parent().find(".clscboFailureType").val();
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Repair/OperationUtil.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "FailureKind=" + FailureKind + "&Type=FailureKind&FailureType=" + FailureType,
                success: function (msg) {
                    var $txt = $($(obj.target).parent().parent().parent().find(".clstxtFcode"));
                    $txt.val(msg);
                }
            });
        }
    });
    var objRepairOperation = new RepairOperation({ el: $("#tblOperation"), KeyID: "", OpType: "" });
    objRepairOperation.fnPCBA5ENoLoad();
    objRepairOperation.fnRepairedComponentLoad();
    if (PuOperationType == "detail") {
        objRepairOperation.lnkaddother.hide();
    }
});
