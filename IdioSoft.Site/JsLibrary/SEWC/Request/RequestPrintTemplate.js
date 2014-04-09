var exports = this;
jQuery(function ($) {
    exports.RequestPrintTemplate = Controller.create({
        elements: {
            ".clslstTemp": "lstTemp",
            "#btnPrint": "btnPrint",
            "#btnClose": "btnClose",
            "#btnPrintXml": "btnPrintXml"
        },
        events: {
            "click #btnPrint": "fnPrint",
            "click #btnClose": "fnClose",
            "click #btnPrintXml": "fnPrintXml"
        },
        fnPrint: function () {
            //debugger;
            var TempText = encodeURI(this.lstTemp.children('option:selected').text());
            var TempValue = encodeURI(this.lstTemp.children('option:selected').val());
            var uRequestID = PuRequestIDs;

            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Request/RequestPrintTemplate.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "TempText=" + TempText + "&TempValue=" + TempValue + "&uRequestID=" + uRequestID + "",
                success: function (msg) {
                    //debugger;
                    if (msg != "") {
                        window.open("../../temp/" + msg + "");
                    }
                }
            });
        },
        fnClose: function () {
            window.close();
        },
        fnPrintXml: function () {
            var TempText = encodeURI(this.lstTemp.children('option:selected').text());
            var TempValue = encodeURI(this.lstTemp.children('option:selected').val());
            //$.colorbox({
            //    href: "RequestSendFax.aspx?uRequestID=" + PuRequestIDs + "&TempText=" + TempText + "&TempValue=" + TempValue + "",
            //    iframe: true,
            //    innerWidth: 550,
            //    innerHeight: 140,
            //    opacity: 0.85,
            //    overlayClose: false
            //});
            window.open("RequestSendFax.aspx?uRequestID=" + PuRequestIDs + "&TempText=" + TempText + "&TempValue=" + TempValue + "", 'mywindow', 'width=550,height=140,top=250, left=300, toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no');
        }
    });
    var objRequestPrintTemplate = new RequestPrintTemplate({ el: $("#tblOperation"), KeyID: "", OpType: "" });
});