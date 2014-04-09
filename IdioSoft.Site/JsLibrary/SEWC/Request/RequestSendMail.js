var exports = this;
jQuery(function ($) {
    exports.RequestSendMail = Controller.create({
        elements: {
            ".clstxtSendMail": "txtSendMail",
            ".clstxtSendCC": "txtSendCC",
            "#btnSendMail": "btnSendMail"
        },
        events: {
            "click #btnSendMail": "fnSendMail"
        },
        fnSendMail: function () {
            //debugger;
            var SendMail = encodeURI(this.txtSendMail.val());
            var SendCC = encodeURI(this.txtSendCC.val());
            var uRequestID = PuRequestIDs;

            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Request/RequestSendMail.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "SendMail=" + SendMail + "&SendCC=" + SendCC + "&uRequestID=" + uRequestID + "",
                success: function (msg) {
                    //debugger;
                    switch (msg) {
                        case "0":
                            alert("Mail Send Successfully!");
                            //parent.$.fn.colorbox.close();
                            window.close();
                            break;
                        case "1":
                            alert("Mail Send Error!");
                            break;
                    }
                }
            });
        }
    });
    var objRequestSendMail = new RequestSendMail({ el: $("#tblOperation"), KeyID: "", OpType: "" });
});