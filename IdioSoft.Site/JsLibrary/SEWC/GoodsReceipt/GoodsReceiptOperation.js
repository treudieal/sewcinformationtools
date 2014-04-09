var exports = this;
jQuery(function ($) {
    $(".dtpTime").datetimepicker({ dateFormat: 'yy-mm-dd', timeFormat: "HH:mm:ss", defaultValue: new Date().Format("yyyy-MM-dd hh:mm:ss") });
    var myModal = $("<div id='myModal' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true' style='width: 610px;'><div class='modal-header'><button type='button' class='close' data-dismiss='modal' aria-hidden='true'></button><h3 id='myModalLabel'><span data-icon='&#x0026;' style='font-size: 18px;'></span>ReceiveDefectiveDate</h3></div><div class='modal-body'></div></div>");
    var myModalError = $("<div id='myModalError' class='modal warning bg-color-blu hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'><div class='modal-body'><p class='pErrorTitle'></p></div><div class='modal-footer'><button class='btn btn-large' data-dismiss='modal'>Close</button></div></div>");
    exports.ReceiveDefectiveDateOperation = Controller.create({
        elements: {
            ".clstxtSEWCNotificationNo": "txtSEWCNotificationNo",
            ".clscboWarranty": "cboWarranty",
            ".dtpReceiveDefectiveDate": "dtpReceiveDefectiveDate",
            ".clschkIsReject": "chkIsReject",
            ".clstxtRejectReason": "txtRejectReason",
            ".clstrRejectReason": "trRejectReason",
            ".clstrRejectFile": "trRejectFile",
            ".btnSave": "btnSave",
            ".btnSubmit": "btnSubmit",
            ".clsfileToUpload": "fileToUpload",
            ".clsbtnUploadfile": "btnUploadfile",
            "#tdAttachmentlist": "tdAttachmentlist",
            ".clsbtnDeletefile": "btnDeletefile",
            ".clstxtFuntinalStateoriginal": "txtFuntinalStateoriginal",
            ".clstxtFirmwareoriginal": "txtFirmwareoriginal",
            ".clsProductName": "cboProductName",
            ".clsProductDesc": "cboProductDesc",
            ".clstxtMLFB": "txtMLFB",
            ".clstxtSerialNo": "txtSerialNo",
            ".clstxtQty": "txtQty"
        },
        events: {
            "click .clschkIsReject": "fnIsReject",
            "click .btnSave": "fnDBSave",
            "click .btnSubmit": "fnSubmit",
            "click .clsbtnUploadfile": "fnFileUpload",
            "click .clsbtnDeletefile": "fnDeletefile",
            "change .clsProductName": "fnProductNameChange"
        },
        fnProductNameChange: function () {
            var ServiceProvider = "SEWC";
            var ProductName = encodeURI(this.cboProductName.val());
            var self = this;
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Request/getMaterialProducDescInfo.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "ServiceProvider=" + ServiceProvider + "&MaterialProductName=" + ProductName + "",
                success: function (msg) {
                    self.cboProductDesc.empty();
                    var aryProductName = eval("(" + unescape(msg) + ")");
                    self.cboProductDesc.append("<option value=''> </option>");
                    if (aryProductName != "") {
                        for (var i = 0; i < aryProductName.length; i++) {
                            self.cboProductDesc.append("<option value='" + aryProductName[i] + "'>" + aryProductName[i] + "</option>");
                        }
                    }
                }
            });
        },
        fnIsReject: function () {
            var IsReject = this.chkIsReject.is(":checked");
            if (IsReject == true) {
                $(".clstrRejectReason").show();
                $(".clstrRejectFile").show();
            } else {
                $(".clstrRejectReason").hide();
                $(".clstrRejectFile").hide();
            }
        },
        fnFileUpload: function () {
            var RejectReason = encodeURI(this.txtRejectReason.val());
            $.ajaxFileUpload({
                url: '../../InterfaceLibrary/SEWC/GoodsReceipt/ws_GoodsReceipt.asmx/subUploadFile',
                secureuri: false,
                fileElementId: "fileToUpload",
                dataType: 'json',
                type: "post",
                data: { uRequestID: PuRequestIDs, Reason: RejectReason },
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
                        $(".clstdAttachmentlist").append("<a href='../../Attachment/SEWC/" + data.fileName + "' target='_blank'>" + data.fileName + "</a>");
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
                url: "../../InterfaceLibrary/SEWC/GoodsReceipt/ws_GoodsReceipt.asmx/subDB_DeleteFile",
                contentType: "application/json",
                dataType: "json",
                data: "{\"uRequestID\":'" + PuRequestIDs + "'}",
                success: function (msg) {
                    switch (msg.d) {
                        case "":
                            $(".clstdAttachmentlist").text("");
                            alert("Delete Successfully!");
                            break;
                        case "error":
                            myModalError.find(".pErrorTitle").text("delete file error!");
                            $(myModalError).modal({
                                keyboard: false,
                                Clickhide: true
                            });
                            break;
                    }
                },
                error: function (msg) {

                }
            });
        },
        fnSaveProcess: function (intType, e) {
            //debugger;
            var ProductName = "";
            var ProductDesc = "";
            var MLFB = "";
            var SerialNo = "";
            var Qty = "";
            var SEWCNotificationNo = encodeURI(this.txtSEWCNotificationNo.val());
            var Warranty = encodeURI(this.cboWarranty.val());
            var ReceiveDefectiveDate = encodeURI(this.dtpReceiveDefectiveDate.val());
            var IsReject = encodeURI(this.chkIsReject.is(":checked"));
            var FuntinalStateOriginal = encodeURI(this.txtFuntinalStateoriginal.val());
            var FirmwareOriginal = encodeURI(this.txtFirmwareoriginal.val());
            ProductName = encodeURI(this.cboProductName.val());
            ProductDesc = encodeURI(this.cboProductDesc.val());
            MLFB = encodeURI(this.txtMLFB.val());
            SerialNo = encodeURI(this.txtSerialNo.val());
            if (!this.txtQty.val().VerifyNumber()) {
                myModalError.find(".pErrorTitle").text("Qty is not number!");
                $(myModalError).modal({
                    keyboard: false,
                    Clickhide: true
                })
                $(e.target).removeAttr("disabled");
                return;
            }
            Qty = this.txtQty.val();
            var sID = PuRequestIDs;
            if (intType == 1) {
                if (ReceiveDefectiveDate == "") {
                    $(e.target).removeAttr("disabled");
                    alert("ReceiveDefectiveDateT3 is Null!")
                    return;
                }
            }

            var RejectReason = encodeURI(this.txtRejectReason.val());
            var objParams = new Object();
            var objP = new Object();
            objP.FuntinalStateOriginal = FuntinalStateOriginal;
            objP.FirmwareOriginal = FirmwareOriginal;
            objP.isSubmit = intType;
            objP.OperationType = "Save";
            objP.SEWCNotificationNo = SEWCNotificationNo;
            objP.ProductName = ProductName;
            objP.ProductDesc = ProductDesc;
            objP.MLFB = MLFB;
            objP.SerialNo = SerialNo;
            objP.Qty = Qty;
            objP.RejectReason = RejectReason;
            objP.Warranty = Warranty;
            objP.ReceiveDefectiveDateT3 = ReceiveDefectiveDate;
            objP.IsReject = IsReject;
            objP.uRequestID = sID;
            var myArray = new Array();
            myArray[0] = objP;
            objParams.ParamsList = myArray;
            var json = JSON.stringify(objParams);
            
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../../InterfaceLibrary/SEWC/GoodsReceipt/ws_GoodsReceipt.asmx/subDB_Save",
                dataType: "json",
                data: json,
                success: function (msg) {
                    switch (msg.d) {
                        case "":
                            $(e.target).removeAttr("disabled");
                            alert("Save Successfully!");
                            window.close();
                            break;
                        case "error":
                            $(e.target).removeAttr("disabled");
                            alert("Save Error!");
                            break;
                    }
                },
                error: function (msg) {
                }
            });
        },
        fnDBSave: function (e) {
            $(e.target).attr("disabled", "disabled");
            this.fnSaveProcess(0, e);

        },
        fnSubmit: function (e) {
            $(e.target).attr("disabled", "disabled");
            this.fnSaveProcess(1, e);

        }
    });
    var objReceiveDefectiveDateOperation = new ReceiveDefectiveDateOperation({ el: $("#tblOperation"), KeyID: "", OpType: "" });
});

function JsonString() {
    for (i = 0; i < arguments.length; i++) {

    }
}