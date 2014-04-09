var exports = this;
jQuery(function ($) {
    exports.RequestSendFax = Controller.create({
        elements: {
            ".clstxtSubject": "txtSubject",
            ".clstxtFaxNumber": "txtFaxNumber",
            ".clstxtReceiver": "txtReceiver",
            ".clstxtReceiverCompany": "txtReceiverCompany",
            ".clstxtReceiverTel": "txtReceiverTel",
            "#btnSave": "btnSave",
            "#btnClose": "btnClose"
        },
        events: {
            "click #btnSave": "fnSave",
            "click #btnClose": "fnClose"
        },
        fnSave: function () {
            //debugger;
            var TempText = strTmpFileName;
            var TempValue = strTmpFileNameValue;
            var uRequestID = PuRequestIDs;
            var Subject = encodeURI(this.txtSubject.val());
            var FaxNumber = encodeURI(this.txtFaxNumber.val());
            var Receiver = encodeURI(this.txtReceiver.val());
            var ReceiverCompany = encodeURI(this.txtReceiverCompany.val());
            var ReceiverTel = encodeURI(this.txtReceiverTel.val());

            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Request/RequestSendFax.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "ReceiverTel=" + ReceiverTel + "&ReceiverCompany=" + ReceiverCompany + "&Receiver=" + Receiver + "&FaxNumber=" + FaxNumber + "&Subject=" + Subject + "&TempText=" + TempText + "&TempValue=" + TempValue + "&uRequestID=" + uRequestID + "",
                success: function (msg) {
                    //debugger;
                    if (msg != "") {
                        alert(msg);
                    } else {
                        alert("OK!");
                    }
                }
            });
        },
        fnClose: function () {
            window.close();
        }
    });
    var objRequestSendFax = new RequestSendFax({ el: $("#tblOperation"), KeyID: "", OpType: "" });
});