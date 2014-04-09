var exports = this;
jQuery(function ($) {
    $(".dtpTime").datetimepicker({ dateFormat: 'yy-mm-dd', timeFormat: "HH:mm:ss", defaultValue: new Date().Format("yyyy-MM-dd hh:mm:ss") });
    var myModal = $("<div id='myModal' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true' style='width: 610px;'><div class='modal-header'><button type='button' class='close' data-dismiss='modal' aria-hidden='true'></button><h3 id='myModalLabel'><span data-icon='&#x0026;' style='font-size: 18px;'></span>Delivery</h3></div><div class='modal-body'></div></div>");
    var myModalError = $("<div id='myModalError' class='modal warning bg-color-blu hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'><div class='modal-body'><p class='pErrorTitle'></p></div><div class='modal-footer'><button class='btn btn-large' data-dismiss='modal'>Close</button></div></div>");
    var selectID = "";
    exports.ReportDefault = Controller.create({
        elements: {
            "#lnkLUReport": "lnkLUReport",
            "#lnkPUReport": "lnkPUReport",
            "#lnkQAFMSReport": "lnkQAFMSReport",
            "#lnkQAKPIInvoiceReport": "lnkQAKPIInvoiceReport",
            ".dtpStartDate": "dtpStartDate",
            ".dtpEndDate": "dtpEndDate",
            ".dtpConfirmStartdate": "dtpConfirmStartdate",
            ".dtpConfirmEnddate": "dtpConfirmEnddate",
            "#lnkGoodwillReport":"lnkGoodwillReport"
        },
        events: {
            "click #lnkLUReport": "fnLUReport",
            "click #lnkPUReport": "fnPUReport",
            "click #lnkQAFMSReport": "fnQAFMSReport",
            "click #lnkQAKPIInvoiceReport": "fnQAKPIInvoiceReport",
            "click #lnkGoodwillReport": "fnGoodwillReport"
        },
        fnVerifyGoodWill: function () {
            var retVerify = "";
            if (this.dtpConfirmStartdate.val() == "") {
                retVerify = "Start Date is null;";
            }
            if (this.dtpConfirmEnddate.val() == "") {
                retVerify += "End Date is null;";
            }
            if (retVerify != "") {
                myModalError.find(".pErrorTitle").text(retVerify);
                $(myModalError).modal({
                    keyboard: false,
                    Clickhide: true
                });
                return false;
            }
            return true;
        },
        fnVerify: function () {
            var retVerify = "";
            if (this.dtpStartDate.val() == "") {
                retVerify = "Start Date is null;";
            }
            if (this.dtpEndDate.val() == "") {
                retVerify += "End Date is null;";
            }
            if (retVerify != "") {
                myModalError.find(".pErrorTitle").text(retVerify);
                $(myModalError).modal({
                    keyboard: false,
                    Clickhide: true
                });
                return false;
            }
            return true;
        },
        fnLUReport: function (e) {
            if (!this.fnVerify()) {
                return;
            }
            $(e.target).after("<img src='../../Style/images/loading.gif' />");
            var self = this;
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../../InterfaceLibrary/SEWC/Report/wsReport.asmx/doLUReport",
                dataType: "json",
                data: "{StartDate:'" + self.dtpStartDate.val() + "',EndDate:'" + self.dtpEndDate.val() + "'}",
                success: function (msg) {
                    if (msg.d != "") {
                        $(e.target).next().remove();
                        window.location.href = "../../Temp/" + msg.d;
                    }
                    else {
                        myModalError.find(".pErrorTitle").text("Export Report Error!");
                        $(myModalError).modal({
                            keyboard: false,
                            Clickhide: true
                        });
                        $(e.target).next().remove();
                    }
                },
                error: function (msg) {
                    myModalError.find(".pErrorTitle").text("Export Report Error!");
                    $(myModalError).modal({
                        keyboard: false,
                        Clickhide: true
                    });
                    $(e.target).next().remove();
                }
            });
            return false;
        },
        fnPUReport: function (e) {
            if (!this.fnVerify()) {
                return;
            }
            $(e.target).after("<img src='../../Style/images/loading.gif' />");
            var self = this;
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../../InterfaceLibrary/SEWC/Report/wsReport.asmx/doPUReport",
                dataType: "json",
                data: "{StartDate:'" + self.dtpStartDate.val() + "',EndDate:'" + self.dtpEndDate.val() + "'}",
                success: function (msg) {
                    if (msg.d != "") {
                        $(e.target).next().remove();
                        window.location.href = "../../Temp/" + msg.d;
                    }
                    else {
                        myModalError.find(".pErrorTitle").text("Export Report Error!");
                        $(myModalError).modal({
                            keyboard: false,
                            Clickhide: true
                        });
                        $(e.target).next().remove();
                    }
                },
                error: function (msg) {
                    myModalError.find(".pErrorTitle").text("Export Report Error!");
                    $(myModalError).modal({
                        keyboard: false,
                        Clickhide: true
                    });
                    $(e.target).next().remove();
                }
            });
            return false;
        },
        fnQAFMSReport: function (e) {
            if (!this.fnVerify()) {
                return;
            }
            $(e.target).after("<img src='../../Style/images/loading.gif' />");
            var self = this;
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../../InterfaceLibrary/SEWC/Report/wsReport.asmx/doQAFMSReport",
                dataType: "json",
                data: "{StartDate:'" + self.dtpStartDate.val() + "',EndDate:'" + self.dtpEndDate.val() + "'}",
                success: function (msg) {
                    if (msg.d != "") {
                        $(e.target).next().remove();
                        window.location.href = "../../Temp/" + msg.d;
                    }
                    else {
                        myModalError.find(".pErrorTitle").text("Export Report Error!");
                        $(myModalError).modal({
                            keyboard: false,
                            Clickhide: true
                        });
                        $(e.target).next().remove();
                    }
                },
                error: function (msg) {
                    myModalError.find(".pErrorTitle").text("Export Report Error!");
                    $(myModalError).modal({
                        keyboard: false,
                        Clickhide: true
                    });
                    $(e.target).next().remove();
                }
            });
            return false;
        },
        fnQAKPIInvoiceReport: function (e) {
            if (!this.fnVerify()) {
                return;
            }
            $(e.target).after("<img src='../../Style/images/loading.gif' />");
            var self = this;
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../../InterfaceLibrary/SEWC/Report/wsReport.asmx/doQAKPIInvoiceReport",
                dataType: "json",
                data: "{StartDate:'" + self.dtpStartDate.val() + "',EndDate:'" + self.dtpEndDate.val() + "'}",
                success: function (msg) {
                    if (msg.d != "") {
                        $(e.target).next().remove();
                        window.location.href = "../../Temp/" + msg.d;
                    }
                    else {
                        myModalError.find(".pErrorTitle").text("Export Report Error!");
                        $(myModalError).modal({
                            keyboard: false,
                            Clickhide: true
                        });
                        $(e.target).next().remove();
                    }
                },
                error: function (msg) {
                    myModalError.find(".pErrorTitle").text("Export Report Error!");
                    $(myModalError).modal({
                        keyboard: false,
                        Clickhide: true
                    });
                    $(e.target).next().remove();
                }
            });
            return false;
        },
        fnGoodwillReport: function (e) {
            if (!this.fnVerifyGoodWill()) {
                return;
            }
            $(e.target).after("<img src='../../Style/images/loading.gif' />");
            var self = this;
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../../InterfaceLibrary/SEWC/Report/wsReport.asmx/doGoodwillReport",
                dataType: "json",
                data: "{StartDate:'" + self.dtpConfirmStartdate.val() + "',EndDate:'" + self.dtpConfirmEnddate.val() + "'}",
                success: function (msg) {
                    if (msg.d != "") {
                        $(e.target).next().remove();
                        window.location.href = "../../Temp/" + msg.d;
                    }
                    else {
                        myModalError.find(".pErrorTitle").text("Export Report Error!");
                        $(myModalError).modal({
                            keyboard: false,
                            Clickhide: true
                        });
                        $(e.target).next().remove();
                    }
                },
                error: function (msg) {
                    myModalError.find(".pErrorTitle").text("Export Report Error!");
                    $(myModalError).modal({
                        keyboard: false,
                        Clickhide: true
                    });
                    $(e.target).next().remove();
                }
            });
            return false;
        }
    });
    var objReportDefault = new ReportDefault({ el: $("#divMain"), KeyID: "" });
    $('.nav-icon').tooltip();
});