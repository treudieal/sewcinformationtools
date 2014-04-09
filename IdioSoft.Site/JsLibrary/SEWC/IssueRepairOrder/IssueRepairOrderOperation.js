var exports = this;
jQuery(function ($) {
    $(".dtpTime").datetimepicker({ dateFormat: 'yy-mm-dd', timeFormat: "HH:mm:ss", defaultValue: new Date().Format("yyyy-MM-dd hh:mm:ss") });
    var myModal = $("<div id='myModal' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true' style='width: 610px;'><div class='modal-header'><button type='button' class='close' data-dismiss='modal' aria-hidden='true'></button><h3 id='myModalLabel'><span data-icon='&#x0026;' style='font-size: 18px;'></span>ReceiveDefectiveDate</h3></div><div class='modal-body'></div></div>");
    var myModalError = $("<div id='myModalError' class='modal warning bg-color-blu hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'><div class='modal-body'><p class='pErrorTitle'></p></div><div class='modal-footer'><button class='btn btn-large' data-dismiss='modal'>Close</button></div></div>");
    exports.IssueRepairOrderOperation = Controller.create({
        elements: {
            ".clscboWarranty": "cboWarranty",
            ".clschkIsReveiveBankReceipt": "chkIsReveiveBankReceipt",
            ".clschkIsGoodWill": "chkIsGoodWill",
            ".clstxtGoodWillNo": "txtGoodWillNo",
            ".dtpCancelDate": "dtpCancelDate",
            ".clstxtCancelReason": "txtCancelReason",
            ".dtpIssueRepairOrderDate": "dtpIssueRepairOrderDate",
            ".dtpCustomerConfirmDate": "dtpCustomerConfirmDate",
            ".clscboRepairble": "cboRepairble",
            ".btnSave": "btnSave",
            ".btnSubmit": "btnSubmit",
            "#btnReport": "btnReport",
            ".clscboRepairble": "cboRepairble",
            ".clsbtnQuotation": "btnQuotation",
            ".clstdQuotation": "tdQuotation",
            ".clstxtMLFB": "txtMLFB",
            ".clstxtSerialNo": "txtSerialNo",
            ".clstxtQty": "txtQty",
            ".clschkQuotation": "chkQuotation",
            ".clstrQuotation": "trQuotation",
            ".clstrCancelDate": "trCancelDate",
            ".clstrCancelReason": "trCancelReason",
            ".clsbtnSendMail": "btnSendMail",
            ".clsbtnSendTest": "btnSendTest",
            ".clstrDate": "trDate",
            ".clstrGoodWill": "trGoodWill",
            ".clstrRepairble": "trRepairble",
            ".clstrSendMail": "trSendMail",
            ".clstrSendCancelMail": "trSendCancelMail",
            ".clscboOrderType": "cboOrderType",
            ".clsbtnSendCancelMail": "btnSendCancelMail",
            ".clscboServiceType": "cboServiceType",
            ".clschkOneTotalPrice": "chkOneTotalPrice",
            ".clstxtTotalPrice": "txtTotalPrice"
        },
        events: {
            "change .clscboWarranty": "fnWarranty",
            "click .btnSave": "fnDBSave",
            "click .btnSubmit": "fnSubmit",
            "click #btnReport": "fnReport",
            "change .clscboRepairble": "fnRepairble",
            "click .clschkQuotation": "fnchkQuotation",
            "click .clsbtnSendMail": "fnSendMail",
            "click .clsbtnSendTest": "fnSendTest",
            "click .clsbtnSendCancelMail": "fnSendCancelMail",
            "change .clschkOneTotalPrice": "fnchkOneTotalPriceChange"
        },
        fnchkOneTotalPriceChange: function () {
            if (this.chkOneTotalPrice.is(":checked") == true) {
                this.txtTotalPrice.removeAttr("disabled");
            }
            else {
                this.txtTotalPrice.attr("disabled", "disabled");
            }
        },
        fnWarranty: function () {
            var Warranty = this.cboWarranty.val();
            if (Warranty.toLowerCase() == "in warranty" || Warranty.toLowerCase() == "ow change to iw") {
             
                this.trRepairble.hide();
                this.trSendMail.hide();
                this.trSendCancelMail.hide();
                this.trQuotation.hide();
                this.trCancelDate.hide();
                this.trCancelReason.hide();
                this.trSendCancelMail.hide();
                this.trSendMail.hide();
            } else {
             
                this.trRepairble.show();
            }
            if (Warranty.toLowerCase() == "in warranty" || Warranty.toLowerCase() == "ow change to iw") {
                this.trDate.hide();
                this.trGoodWill.hide();
            }
            else {
                this.trDate.show();
                this.trGoodWill.show();
            }
            this.cboRepairble.val("");
            this.fnQuotaionLoad();
        },
        fnQuotaionLoad: function () {
            var MLFB = encodeURI(this.txtMLFB.val());
            var Warranty = this.cboWarranty.val();
            if ((Warranty.toLowerCase() == "out warranty" || Warranty.toLowerCase() == "iw change to ow") && this.cboRepairble.val() == "Y") {
                var self = this;
                $.ajax({
                    type: "POST",
                    url: "../../InterfaceLibrary/SEWC/IssueRepairOrder/IssueRepairOrderOperation.ashx",
                    contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                    data: "uRequestID=" + PuRequestIDs + "&Warranty=" + Warranty + "&OperationType=SelectWarranty&MLFB=" + MLFB + "",
                    success: function (msg) {
                        //debugger;
                        if (msg != "") {
                            self.tdQuotation.text("");
                            self.tdQuotation.append(msg);
                            self.trQuotation.show();
                            self.trSendMail.show();
                        } else {
                            self.trQuotation.hide();
                            self.trSendMail.hide();
                        }
                    }
                });
            }
            else {
                this.tdQuotation.text("");
                this.trQuotation.hide();
            }
        },
        fnchkQuotation: function (obj) {
            //debugger;
            var self = this;
            var QuotationChecked = $(obj.target).is(":checked");
            var ProductType = encodeURI($(obj.target).parent().attr("ProductType"));
            var MLFB = encodeURI($(obj.target).parent().attr("MLFB"));
            var Component = encodeURI($(obj.target).parent().attr("Component"));
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/IssueRepairOrder/IssueRepairOrderOperation.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "uRequestID=" + PuRequestIDs + "&OperationType=chkQuotation&ProductType=" + ProductType + "&MLFB=" + MLFB + "&Component=" + Component + "&QuotationChecked=" + QuotationChecked + "",
                success: function (msg) {
                    //debugger;
                    //$(".clstdQuotation").text("");
                    //$(".clstdQuotation").append(msg);
                    var ary = msg.split(':');
                    //if (ary.length > 1) {
                        $(obj.target).parent().parent().parent().find("input").val(ary[0]);
                        self.txtTotalPrice.val(ary[1]);
                    //}
                }
            });
        },
        fnRepairble: function () {
            var Repairble = encodeURI(this.cboRepairble.val());
            switch (Repairble) {
                case "Y":
                    this.trQuotation.show();
                    this.trCancelDate.hide();
                    this.trCancelReason.hide();
                    this.trSendCancelMail.hide();
                    this.trSendMail.show();
                    break;
                case "N":
                    this.trQuotation.hide();
                    this.trCancelDate.show();
                    this.trCancelReason.show();
                    this.trSendCancelMail.show();
                    this.trSendMail.hide();
                    break;
                default:
                    this.trQuotation.hide();
                    this.trCancelDate.hide();
                    this.trCancelReason.hide();
                    this.trSendCancelMail.hide();
                    this.trSendMail.hide();
                    break;
            }
            this.fnQuotaionLoad();
        },
        fnSaveProcess: function (intType, e) {
            //debugger;
            var Warranty = encodeURI(this.cboWarranty.val());
            var ReveiveBankReceipt = encodeURI(this.chkIsReveiveBankReceipt.is(":checked"));
            var IsGoodWill = encodeURI(this.chkIsGoodWill.is(":checked"));
            var GoodWillNo = encodeURI(this.txtGoodWillNo.val());
            var CancelDate = encodeURI(this.dtpCancelDate.val());
            var CancelReason = encodeURI(this.txtCancelReason.val());
            var IssueRepairOrderDate = encodeURI(this.dtpIssueRepairOrderDate.val());
            var Repairble = encodeURI(this.cboRepairble.val());
            var CustomerConfirmDate = encodeURI(this.dtpCustomerConfirmDate.val());
            var OrderType = encodeURIComponent(this.cboOrderType.val());
            var MLFB = encodeURI(this.txtMLFB.val());
            var SerialNo = encodeURI(this.txtSerialNo.val());
            var ServiceType = this.cboServiceType.val();
            var TotalPrice = this.txtTotalPrice.val();
            var FixPrice = this.chkOneTotalPrice.is(":checked");
            if (!this.txtQty.val().VerifyNumber()) {
                myModalError.find(".pErrorTitle").text("Qty is not number!");
                $(myModalError).modal({
                    keyboard: false,
                    Clickhide: true
                });
                $(e.target).removeAttr("disabled");
                return;
            }
            if (ServiceType == "") {
                myModalError.find(".pErrorTitle").text("ServiceType is null!");
                $(e.target).removeAttr("disabled");
                return;
            }
            var Qty = this.txtQty.val();
            var sID = PuRequestIDs;
            if (intType == 1 && Repairble == "Y") {
                if (IssueRepairOrderDate == "") {
                    myModalError.find(".pErrorTitle").text("IssueRepairOrderDate is null!");
                    $(myModalError).modal({
                        keyboard: false,
                        Clickhide: true
                    });
                    $(e.target).removeAttr("disabled");
                    return;
                }
            }
            var data = "CustomerConfirmDate=" + CustomerConfirmDate + "&isSubmit=" + intType + "&OperationType=Save&Repairble=" + Repairble
                    + "&IssueRepairOrderDate=" + IssueRepairOrderDate + "&Warranty=" + Warranty
                    + "&ReveiveBankReceipt=" + ReveiveBankReceipt + "&IsGoodWill=" + IsGoodWill + "&GoodWillNo=" + GoodWillNo
                    + "&OrderType=" + OrderType + "&MLFB=" + MLFB + "&SerialNo=" + SerialNo + "&Qty=" + Qty + "&ServiceType=" + ServiceType
                    + "&TotalPrice=" + TotalPrice + "&FixPrice=" + FixPrice
                    + "&CancelDate=" + CancelDate + "&CancelReason=" + CancelReason + "&sID=" + sID + "";
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/IssueRepairOrder/IssueRepairOrderOperation.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: data,
                success: function (msg) {
                    //debugger;
                    switch (msg) {
                        case "0":
                            $(e.target).removeAttr("disabled");
                            alert("Save Successfully!");
                            if (intType == 1) {
                                window.close();
                            }

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
        },
        fnDBSave: function (e) {
            $(e.target).attr("disabled", "disabled");
            this.fnSaveProcess(0, e);

        },
        fnSubmit: function (e) {
            $(e.target).attr("disabled", "disabled");
            this.fnSaveProcess(1, e);

        },
        fnSendCancelMail: function (e) {
            $(e.target).attr("disabled", "disabled");
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/IssueRepairOrder/IssueRepairOrderOperation.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "uRequestID=" + PuRequestIDs + "&OperationType=SendCancelMail",
                success: function (msg) {
                    switch (msg) {
                        case "0":
                            $(e.target).removeAttr("disabled");
                            alert("信息保存成功，邮件已发送！");
                            //parent.$.fn.colorbox.close();
                            window.close();
                            break;
                        case "1":
                            $(e.target).removeAttr("disabled");
                            alert("操作失败！");
                            break;
                    }
                }
            });
        },
        fnSendMail: function (e) {
            $(e.target).attr("disabled", "disabled");
            var Warranty = encodeURI(this.cboWarranty.val());
            var ReveiveBankReceipt = encodeURI(this.chkIsReveiveBankReceipt.is(":checked"));
            var IsGoodWill = encodeURI(this.chkIsGoodWill.is(":checked"));
            var GoodWillNo = encodeURI(this.txtGoodWillNo.val());
            var CancelDate = encodeURI(this.dtpCancelDate.val());
            var CancelReason = encodeURI(this.txtCancelReason.val());
            var ServiceType = this.cboServiceType.val();
            //var ConfirmWarrantyDate = encodeURI(this.dtpConfirmWarrantyDate.val());
            var IssueRepairOrderDate = encodeURI(this.dtpIssueRepairOrderDate.val());
            var Repairble = encodeURI(this.cboRepairble.val());
            var CustomerConfirmDate = encodeURI(this.dtpCustomerConfirmDate.val());
            var OrderType = encodeURI(this.cboOrderType.val());
            var MLFB = encodeURI(this.txtMLFB.val());
            var SerialNo = encodeURI(this.txtSerialNo.val());
            if (!this.txtQty.val().VerifyNumber()) {
                myModalError.find(".pErrorTitle").text("Qty is not number!");
                $(myModalError).modal({
                    keyboard: false,
                    Clickhide: true
                })
                $(e.target).removeAttr("disabled");
                return;
            }
            var Qty = this.txtQty.val();

            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/IssueRepairOrder/IssueRepairOrderOperation.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "ServiceType=" + ServiceType + "&CustomerConfirmDate=" + CustomerConfirmDate + "&isSubmit=0&OperationType=SendMail&Repairble=" + Repairble
                    + "&IssueRepairOrderDate=" + IssueRepairOrderDate + "&Warranty=" + Warranty
                    + "&ReveiveBankReceipt=" + ReveiveBankReceipt + "&IsGoodWill=" + IsGoodWill + "&GoodWillNo=" + GoodWillNo
                    + "&OrderType=" + OrderType + "&MLFB=" + MLFB + "&SerialNo=" + SerialNo + "&Qty=" + Qty
                    + "&CancelDate=" + CancelDate + "&CancelReason=" + CancelReason + "&uRequestID=" + PuRequestIDs + "",
                success: function (msg) {
                    switch (msg) {
                        case "0":
                            $(e.target).removeAttr("disabled");
                            alert("信息保存成功，邮件已发送！");
                            //parent.$.fn.colorbox.close();
                            //window.close();
                            break;
                        case "1":
                            $(e.target).removeAttr("disabled");
                            alert("操作失败！");
                            break;
                    }
                }
            });
        },
        fnSendTest: function (e) {
            $(e.target).attr("disabled", "disabled");
            var Warranty = encodeURI(this.cboWarranty.val());
            var ReveiveBankReceipt = encodeURI(this.chkIsReveiveBankReceipt.is(":checked"));
            var IsGoodWill = encodeURI(this.chkIsGoodWill.is(":checked"));
            var GoodWillNo = encodeURI(this.txtGoodWillNo.val());
            var CancelDate = encodeURI(this.dtpCancelDate.val());
            var CancelReason = encodeURI(this.txtCancelReason.val());
            var ServiceType = this.cboServiceType.val();
            var IssueRepairOrderDate = encodeURI(this.dtpIssueRepairOrderDate.val());
            var Repairble = encodeURI(this.cboRepairble.val());
            var CustomerConfirmDate = encodeURI(this.dtpCustomerConfirmDate.val());
            var OrderType = encodeURI(this.cboOrderType.val());
            var MLFB = encodeURI(this.txtMLFB.val());
            var SerialNo = encodeURI(this.txtSerialNo.val());
            if (!this.txtQty.val().VerifyNumber()) {
                myModalError.find(".pErrorTitle").text("Qty is not number!");
                $(myModalError).modal({
                    keyboard: false,
                    Clickhide: true
                })
                $(e.target).removeAttr("disabled");
                return;
            }
            var Qty = this.txtQty.val();

            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/IssueRepairOrder/IssueRepairOrderOperation.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "ServiceType=" + ServiceType + "&CustomerConfirmDate=" + CustomerConfirmDate + "&isSubmit=0&OperationType=SendTest&Repairble=" + Repairble
                    + "&IssueRepairOrderDate=" + IssueRepairOrderDate + "&Warranty=" + Warranty
                    + "&ReveiveBankReceipt=" + ReveiveBankReceipt + "&IsGoodWill=" + IsGoodWill + "&GoodWillNo=" + GoodWillNo
                    + "&OrderType=" + OrderType + "&MLFB=" + MLFB + "&SerialNo=" + SerialNo + "&Qty=" + Qty
                    + "&CancelDate=" + CancelDate + "&CancelReason=" + CancelReason + "&uRequestID=" + PuRequestIDs + "",
                success: function (msg) {
                    switch (msg) {
                        case "0":
                            $(e.target).removeAttr("disabled");
                            alert("信息保存成功，邮件已发送！");
                            //parent.$.fn.colorbox.close();
                            window.close();
                            break;
                        case "1":
                            $(e.target).removeAttr("disabled");
                            alert("操作失败！");
                            break;
                    }
                }
            });
        },
        fnReport: function (e) {
            $(e.target).attr("disabled", "disabled");
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/IssueRepairOrder/IssueRepairOrderReport.ashx",
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
        }
    });
    var objIssueRepairOrderOperation = new IssueRepairOrderOperation({ el: $("#tblOperation"), KeyID: "", OpType: "" });
});
