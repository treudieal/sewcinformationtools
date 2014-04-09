var exports = this;
jQuery(function ($) {
    exports.RequestSenderMsg = Controller.create({
        elements: {
            ".clstxtNotificationNo": "txtNotificationNo",
            ".clstxtAppMobile": "txtAppMobile",
            ".clstxtEnduserMobile": "txtEnduserMobile",
            ".clscboMsgTemplate": "cboMsgTemplate",
            ".clsTextareaMsg": "TextareaMsg",
            "#btnSave": "btnSave",
            "#btnClose": "btnClose"
        },
        events: {
            "click .clscboMsgTemplate": "fnMsgTemplate",
            "click #btnSave": "fnDBSave",
            "click #btnClose":"fnClose"
        },
        fnMsgTemplate: function () {
            debugger;
            var NotificationNo = encodeURI(this.txtNotificationNo.val());
            var uRequestID = PuRequestIDs;
            var MsgTemplate = encodeURI(this.cboMsgTemplate.children('option:selected').val());
            var thisMsgTemplate = this;

            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Request/getMsgTemplateInfo.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "uRequestID=" + uRequestID + "&NotificationNo=" + NotificationNo + "&MsgTemplate=" + MsgTemplate + "",
                success: function (msg) {
                    thisMsgTemplate.TextareaMsg.val(msg);
                }
            });

        },
        fnDBSave: function () {
            //debugger;
            var NotificationNo = encodeURI(this.txtNotificationNo.val());
            var AppMobile = encodeURI(this.txtAppMobile.val());
            var EndUserMobile = encodeURI(this.txtEndUserMobile.val());
            var Content = encodeURI(this.TextareaMsg.val());
            var uRequestID = PuRequestIDs;

            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Request/RequestSenderMsg.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "NotificationNo=" + NotificationNo + "&AppMobile=" + AppMobile + "&EndUserMobile=" + EndUserMobile + "&Content=" + Content + "&uRequestID=" + uRequestID + "",
                success: function (msg) {
                    //debugger;
                    switch (msg) {
                        case "0":
                            alert("Message Send Successfully!");
                            //parent.$.fn.colorbox.close();
                            window.close();
                            break;
                        case "1":
                            alert("Message Send Error!");
                            break;
                    }
                }
            });
        },
        fnClose: function () {
            window.close();
        }
    });
    var objRequestSenderMsg = new RequestSenderMsg({ el: $("#tblOperation"), KeyID: "", OpType: "" });
});