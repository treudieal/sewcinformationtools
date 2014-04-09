var exports = this;
jQuery(function ($) {
    $(".dtpTime").datetimepicker({ dateFormat: 'yy-mm-dd', timeFormat: "HH:mm:ss", defaultValue: new Date().Format("yyyy-MM-dd hh:mm:ss") });
    var myModal = $("<div id='myModal' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true' style='width: 610px;'><div class='modal-header'><button type='button' class='close' data-dismiss='modal' aria-hidden='true'></button><h3 id='myModalLabel'><span data-icon='&#x0026;' style='font-size: 18px;'></span>ReceiveDefectiveDate</h3></div><div class='modal-body'></div></div>");
    var myModalError = $("<div id='myModalError' class='modal warning bg-color-blu hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'><div class='modal-body'><p class='pErrorTitle'></p></div><div class='modal-footer'><button class='btn btn-large' data-dismiss='modal'>Close</button></div></div>");
    exports.T3Operation = Controller.create({
        elements: {
            ".dtpReceiveDefectiveDate": "dtpReceiveDefectiveDate",
            ".btnSave": "btnSave"
        },
        events: {
            "click .btnSave": "fnDBSave"
        },
        fnDBSave: function (e) {
            $(e.target).attr("disabled", "disabled");
            //debugger;
            var ReceiveDefectiveDate = encodeURI(this.dtpReceiveDefectiveDate.val());
            var sID = PuRequestIDs;
            if (ReceiveDefectiveDate == "") {
                $(e.target).removeAttr("disabled");
                alert("ReceiveDefectiveDateT3 is Null!")
                return;
            }

            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/GoodsReceipt/T3Operation.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "ReceiveDefectiveDate=" + ReceiveDefectiveDate + "&uRequestID=" + sID + "",
                success: function (msg) {
                    //debugger;
                    switch (msg) {
                        case "0":
                            $(e.target).removeAttr("disabled");
                            alert("Save Successfully!");
                            window.close();
                            break;
                        case "1":
                            myModalError.find(".pErrorTitle").text("Save Error!");
                            $(myModalError).modal({
                                keyboard: false,
                                Clickhide: true
                            });
                            $(e.target).removeAttr("disabled");
                            break;
                    }
                }
            });
        }
    });
    var objT3Operation = new T3Operation({ el: $("#tblOperation"), KeyID: "", OpType: "" });
});
