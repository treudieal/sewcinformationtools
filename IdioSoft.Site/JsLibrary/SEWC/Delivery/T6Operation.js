﻿var exports = this;
jQuery(function ($) {
    $(".dtpTime").datetimepicker({ dateFormat: 'yy-mm-dd', timeFormat: "HH:mm:ss", defaultValue: new Date().Format("yyyy-MM-dd hh:mm:ss") });
    var myModal = $("<div id='myModal' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true' style='width: 610px;'><div class='modal-header'><button type='button' class='close' data-dismiss='modal' aria-hidden='true'></button><h3 id='myModalLabel'><span data-icon='&#x0026;' style='font-size: 18px;'></span>ReceiveDefectiveDate</h3></div><div class='modal-body'></div></div>");
    var myModalError = $("<div id='myModalError' class='modal warning bg-color-blu hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'><div class='modal-body'><p class='pErrorTitle'></p></div><div class='modal-footer'><button class='btn btn-large' data-dismiss='modal'>Close</button></div></div>");
    exports.T3Operation = Controller.create({
        elements: {
            ".dtpDeliveryDate": "dtpDeliveryDate",
            ".btnSave": "btnSave"
        },
        events: {
            "click .btnSave": "fnDBSave"
        },
        fnDBSave: function () {
            //debugger;
            var DeliveryDate = encodeURI(this.dtpDeliveryDate.val());
            var sID = PuRequestIDs;
            if (DeliveryDate == "") {
                alert("DeliveryDate is Null!")
                return;
            }

            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Delivery/ws_Delivery.asmx/funSaveT6",
                contentType: "application/json",
                dataType: "json",
                data: "{DeliveryDate:\"" + DeliveryDate + "\",uRequestIDs:\"" + sID + "\"}",
                success: function (msg) {
                    //debugger;
                    switch (msg.d) {
                        case "0":
                            alert("Save Successfully!");
                            window.close();
                            break;
                        case "1":
                            myModalError.find(".pErrorTitle").text("Save Error!");
                            $(myModalError).modal({
                                keyboard: false,
                                Clickhide: true
                            });
                            break;
                    }
                },
                error: function (msg) {
                    var dd = "";
                }
            });
        }
    });
    var objT3Operation = new T3Operation({ el: $("#tblOperation"), KeyID: "", OpType: "" });
});
