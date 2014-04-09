var exports = this;
jQuery(function ($) {
    $(".dtpTime").datetimepicker({ dateFormat: 'yy-mm-dd', timeFormat: "HH:mm:ss", defaultValue: new Date().Format("yyyy-MM-dd hh:mm:ss") });
    var myModalError = $("<div id='myModalError' class='modal warning bg-color-blu hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'><div class='modal-body'><p class='pErrorTitle'></p></div><div class='modal-footer'><button class='btn btn-large' data-dismiss='modal'>Close</button></div></div>");
    exports.DeliveryOperation = Controller.create({
        elements: {
            ".clscboWarranty": "cboWarranty",
            ".clsdtpissueDNDate": "dtpissueDNDate",
            ".dtpDeliveryDate": "dtpDeliveryDate",
            ".clstxtTrackingNo": "txtTrackingNo",
            ".clstxtWeight": "txtWeight",
            ".btnSave": "btnSave",
            ".btnSubmit": "btnSubmit",
            "#btnReport": "btnReport",
            ".clstxtReceiveCompany": "txtReceiveCompany",
            ".clstxtReceiver": "txtReceiver",
            ".clstxtReceiverTel": "txtReceiverTel",
            ".clstxtReceiverAddress": "txtReceiverAddress",
 
            ".clstxtNewSerialNo": "txtNewSerialNo",
            ".clstxtMLFB": "txtMLFB",
            ".clstxtSerialNo": "txtSerialNo",
            ".clstxtQty": "txtQty"
        },
        events: {
            "click .btnSave": "fnDBSave",
            "click .btnSubmit": "fnDBSubmit",
            "click #btnReport": "fnReport"
        },
        fnSaveProcess: function (intType,e) {
            //debugger;
            var Warranty = encodeURI(this.cboWarranty.val());
            var issueDNDate = encodeURI(this.dtpissueDNDate.val());
            var DeliveryDate = encodeURI(this.dtpDeliveryDate.val());
            var TrackingNo = encodeURI(this.txtTrackingNo.val());
            var Weight = encodeURI(this.txtWeight.val());

            var ReceiveCompany = encodeURI(this.txtReceiveCompany.val());
            var Receiver = encodeURI(this.txtReceiver.val());
            var ReceiverTel = encodeURI(this.txtReceiverTel.val());
            var ReceiverAddress = encodeURI(this.txtReceiverAddress.val());

            var NewMLFB = "";
            var NewSerialNo = encodeURI(this.txtNewSerialNo.val());


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

            var sID = PuRequestIDs;
            if (intType == 1) {
                if (DeliveryDate == "") {
                    myModalError.find(".pErrorTitle").text("DeliveryDate is Null!");
                    $(myModalError).modal({
                        keyboard: false,
                        Clickhide: true
                    });
                    $(e.target).removeAttr("disabled");
                    return;
                }
            }

            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Delivery/DeliveryOperation.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "isSubmit=" + intType + "&Weight=" + Weight + "&Warranty=" + Warranty + "&issueDNDate=" + issueDNDate
                    + "&MLFB=" + MLFB + "&SerialNo=" + SerialNo + "&Qty=" + Qty
                    + "&DeliveryDate=" + DeliveryDate + "&NewMLFB=" + NewMLFB + "&NewSerialNo=" + NewSerialNo + "&TrackingNo=" + TrackingNo
                    + "&ReceiveCompany=" + ReceiveCompany + "&Receiver=" + Receiver + "&ReceiverTel=" + ReceiverTel + "&ReceiverAddress=" + ReceiverAddress
                    + "&sID=" + sID + "",
                success: function (msg) {
                    //debugger;
                    switch (msg) {
                        case "0":
                            $(e.target).removeAttr("disabled");
                            alert("Save Successfully!");
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
            this.fnSaveProcess(0,e);
            
        },
        fnDBSubmit: function (e) {
            $(e.target).attr("disabled", "disabled");
            this.fnSaveProcess(1,e);
        },
        fnReport: function (e) {
            $(e.target).attr("disabled", "disabled");
            var Warranty = encodeURI(this.cboWarranty.val());
            var DeliveryDate = encodeURI(this.dtpDeliveryDate.val());
            var issueDNDate = encodeURI(this.dtpissueDNDate.val());
            var TrackingNo = encodeURI(this.txtTrackingNo.val());
            var Weight = encodeURI(this.txtWeight.val());

            var ReceiveCompany = encodeURI(this.txtReceiveCompany.val());
            var Receiver = encodeURI(this.txtReceiver.val());
            var ReceiverTel = encodeURI(this.txtReceiverTel.val());
            var ReceiverAddress = encodeURI(this.txtReceiverAddress.val());

            var NewMLFB = "";
            var NewSerialNo = encodeURI(this.txtNewSerialNo.val());

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

            var sID = PuRequestIDs;
            
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Delivery/DeliveryReport.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "Weight=" + Weight + "&Warranty=" + Warranty + "&issueDNDate=" + issueDNDate
                    + "&MLFB=" + MLFB + "&SerialNo=" + SerialNo + "&Qty=" + Qty
                    + "&DeliveryDate=" + DeliveryDate + "&NewMLFB=" + NewMLFB + "&NewSerialNo=" + NewSerialNo + "&TrackingNo=" + TrackingNo
                    + "&ReceiveCompany=" + ReceiveCompany + "&Receiver=" + Receiver + "&ReceiverTel=" + ReceiverTel + "&ReceiverAddress=" + ReceiverAddress
                    + "&uRequestID=" + sID + "&OperationType=Operation",
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
    });
    var objDeliveryOperation = new DeliveryOperation({ el: $("#tblOperation"), KeyID: "", OpType: "" });
});
 