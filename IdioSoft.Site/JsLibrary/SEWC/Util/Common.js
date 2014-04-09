var Utils = this;
jQuery(function ($) {
    var myModalError = $("<div id='myModalError' class='modal warning bg-color-blu hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'><div class='modal-body'><p class='pErrorTitle'></p></div><div class='modal-footer'><button class='btn btn-large' data-dismiss='modal'>Close</button></div></div>");
    var selectID = "";
    Utils.divNavBar = Controller.create({
        elements: {
            "#lnkNavRequest": "lnkNavRequest",
            "#lnkNavGoodsReceipt": "lnkNavGoodsReceipt",
            "#lnkNavIssueRepairOrder": "lnkNavIssueRepairOrder",
            "#lnkNavRepair": "lnkNavRepair",
            "#lnkNavDelivery": "lnkNavDelivery",
            "#list1": "list1",
            "#lnkNavModifyRequest": "lnkNavModifyRequest",
            "#lnkNavModifyGoodsReceipt": "lnkNavModifyGoodsReceipt",
            "#lnkNavModifyIssueRepairOrder": "lnkNavModifyIssueRepairOrder",
            "#lnkNavModifyRepair": "lnkNavModifyRepair",
            "#lnkNavModifyDelivery": "lnkNavModifyDelivery"
        },
        events: {
            "click #lnkNavRequest": "fnRequestClick",
            "click #lnkNavGoodsReceipt": "fnGoodsReceiptClick",
            "click #lnkNavIssueRepairOrder": "fnIssueRepairOrderClick",
            "click #lnkNavRepair": "fnRepairClick",
            "click #lnkNavDelivery": "fnDeliveryClick",
            "click #lnkNavModifyRequest": "fnRequestClickModify",
            "click #lnkNavModifyGoodsReceipt": "fnGoodsReceiptClickModify",
            "click #lnkNavModifyIssueRepairOrder": "fnIssueRepairOrderClickModify",
            "click #lnkNavModifyRepair": "fnRepairClickModify",
            "click #lnkNavModifyDelivery": "fnDeliveryClickModify"
        },
        fnRequestClickModify: function () {
            var sID = this.fnCurrentGridID();
            if (sID == "") {
                return;
            }
            window.open("../../SEWC/Request/SEWCRequestOperation.aspx?uRequestID=" + sID + "&OperationType=Modify", 'mywindow', 'width=740,height=550,top=250, left=300, toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no,status=no');
        },
        fnGoodsReceiptClickModify: function () {
            var sID = this.fnCurrentGridID();
            if (sID == "") {
                return;
            }
            window.open("../../SEWC/GoodsReceipt/GoodsReceiptOperation.aspx?sID=" + sID + "&OperationType=Modify", 'mywindow', 'width=740,height=500,top=150, left=300, toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no,status=no');
        },
        fnIssueRepairOrderClickModify: function () {
            var sID = this.fnCurrentGridID();
            if (sID == "") {
                return;
            }
            window.open("../../SEWC/IssueRepairOrder/IssueRepairOrderOperation.aspx?sID=" + sID + "&OperationType=Modify", 'mywindow', 'width=740,height=500,top=150, left=300, toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no,status=no');
        },
        fnRepairClickModify: function () {
            var sID = this.fnCurrentGridID();
            if (sID == "") {
                return;
            }
            window.open("../../SEWC/Repair/RepairOperation.aspx?sID=" + sID + "&OperationType=Modify", 'mywindow', 'width=770,height=560,top=150, left=300, toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no,status=no');
        },
        fnDeliveryClickModify: function () {
            var sID = this.fnCurrentGridID();
            if (sID == "") {
                return;
            }
            window.open("../../SEWC/Delivery/DeliveryOperation.aspx?sID=" + sID + "&OperationType=Modify", 'mywindow', 'width=700,height=500,top=150, left=300, toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no,status=no');
        },
        fnRequestClick: function () {
            var sID = this.fnCurrentGridID();
            if (sID == "") {
                return;
            }
            window.open("../../SEWC/Request/SEWCRequestOperation.aspx?uRequestID=" + sID + "&OperationType=Detail", 'mywindow', 'width=740,height=550,top=250, left=300, toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no,status=no');
        },
        fnGoodsReceiptClick:function(){
            var sID = this.fnCurrentGridID();
            if (sID == "") {
                return;
            }
            window.open("../../SEWC/GoodsReceipt/GoodsReceiptOperation.aspx?sID=" + sID + "&OperationType=Detail", 'mywindow', 'width=740,height=500,top=150, left=300, toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no,status=no');
        },
        fnIssueRepairOrderClick: function () {
            var sID = this.fnCurrentGridID();
            if (sID == "") {
                return;
            }
            window.open("../../SEWC/IssueRepairOrder/IssueRepairOrderOperation.aspx?sID=" + sID + "&OperationType=Detail", 'mywindow', 'width=740,height=500,top=150, left=300, toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no,status=no');
        },
        fnRepairClick: function () {
            var sID = this.fnCurrentGridID();
            if (sID == "") {
                return;
            }
            window.open("../../SEWC/Repair/RepairOperation.aspx?sID=" + sID + "&OperationType=Detail", 'mywindow', 'width=770,height=560,top=150, left=300, toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no,status=no');
        },
        fnDeliveryClick: function () {
            var sID = this.fnCurrentGridID();
            if (sID == "") {
                return;
            }
            window.open("../../SEWC/Delivery/DeliveryOperation.aspx?sID=" + sID + "&OperationType=Detail", 'mywindow', 'width=700,height=500,top=150, left=300, toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no,status=no');
        },
        fnCurrentGridID: function () {
            var aryRow;
            var sID = "";
            aryRow = $(list1).jqGrid('getGridParam', 'selarrrow');
            if (aryRow.length > 1 || aryRow.length == 0) {
                myModalError.find(".pErrorTitle").text("Please select a record!");
                $(myModalError).modal({
                    keyboard: false,
                    Clickhide: true
                })
                return "";
            }
            sID = $(list1).getCell(aryRow[0], "uRequestID");
            return sID;
        }
    });
    var objdivNavBar = new divNavBar({ el: $("#divNavBar"), KeyID: "" });
});
