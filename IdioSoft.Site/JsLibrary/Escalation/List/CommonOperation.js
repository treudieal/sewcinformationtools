var Cexport = this;
var objOperation;
var sID;
var OperType;
jQuery(function ($) {
    $(".dtpTime").datepicker();
    var myModal = $("<div id='myModal' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true' style='width: 610px;'><div class='modal-header'><button type='button' class='close' data-dismiss='modal' aria-hidden='true'></button><h3 id='myModalLabel'><span data-icon='&#x0026;' style='font-size: 18px;'></span>Delivery</h3></div><div class='modal-body'></div></div>");
    var myModalError = $("<div id='myModalError' class='modal warning bg-color-blu hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'><div class='modal-body'><p class='pErrorTitle'></p></div><div class='modal-footer'><button class='btn btn-large' data-dismiss='modal'>Close</button></div></div>");
    var selectID = "";
    Cexport.COperation = Controller.create({
        elements: {
            "#divRealOperation": "divRealOperation",
            ".clstxtERNo": "txtERNo",
            ".clstxtSRNo": "txtSRNo",
            ".clstxtAppCompany": "txtAppCompany",
            ".clstxtEndUser": "txtEndUser",
            ".clstxtContact": "txtContact",
            ".clstxtOC": "txtOC",
            ".clstxtProductDesc": "txtProductDesc",
            ".clstxtMLFB": "txtMLFB",
            ".clstxtSN": "txtSN",
            ".clstxtAbstract": "txtAbstract",
            ".clstxtRemark": "txtRemark",
            ".clscboStatus": "cboStatus",
            ".clscboType": "cboType",
            ".clscboPriority": "cboPriority",
            ".clsdtpCreatedDate": "dtpCreatedDate",
            ".clscboOwner": "cboOwner",
            ".clstxtEscalationBy": "txtEscalationBy",
            "#spanOperationTitle": "spanOperationTitle",
            ".clsModify": "btnModify",
            ".clsSave": "btnSave",
            ".clsDelete": "btnDelete",
            ".clsLoadSR": "btnLoadSR"
        },
        events: {

            "click .clsModify": "fnModify",
            "click .clsSave": "fnSave",
            "click .clsDelete": "fnDelete",
            "click .clsLoadSR": "fnLoadSR"
        },
        fnLoadSR: function () {
            var self = this;
            var srID = this.txtSRNo.val();
            if (srID == "") {
                return;
            }
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../../InterfaceLibrary/Escalation/List/wsEscalation.asmx/funReturn_LoadRequest",
                dataType: "json",
                data: "{SRID:'" + srID + "'}",
                success: function (msg) {
                    var result = msg.d;
                    self.txtAppCompany.val(result.AppCompanyName.FieldValue);
                    self.txtEndUser.val(result.EnduserCompanyName.FieldValue);
                    self.txtMLFB.val(result.MLFB.FieldValue);
                    self.txtSN.val(result.SerialNo.FieldValue);
                    self.txtProductDesc.val(result.ProductDesc.FieldValue);
                },
                error: function (ex) {
                    var e = ex;
                }
            });
        },
        fnModify: function () {
            this.fnOperationControl(true);
            this.fnOperationType("Modify");
        },
        fnSave: function () {
            if (OperType == "" || OperType=="View") {
                alert("请先选取Addnew或Modify再点Save!");
                return;
            }
            var ERNo = encodeURI(this.txtERNo.val());
            var SRNo = encodeURI(this.txtSRNo.val());
            var AppCompany = encodeURI(this.txtAppCompany.val());
            var EndUser = encodeURI(this.txtEndUser.val());
            var Contact = encodeURI(this.txtContact.val());
            var OC = encodeURI(this.txtOC.val());
            var ProductDesc = encodeURI(this.txtProductDesc.val());
            var MLFB = encodeURI(this.txtMLFB.val());
            var SN = encodeURI(this.txtSN.val());
            var Abstract = encodeURI(this.txtAbstract.val());
            var Remark = encodeURI(this.txtRemark.val());
            var Status = encodeURI(this.cboStatus.children('option:selected').val());
            var Type = encodeURI(this.cboType.children('option:selected').val()).replace("undefined", "");
            var Priority = encodeURI(this.cboPriority.children('option:selected').val()).replace("undefined", "");
            var CreatedDate = encodeURI(this.dtpCreatedDate.val());
            var Owner = encodeURI(this.cboOwner.children('option:selected').val()).replace("undefined", "");
            var EscalationBy = encodeURI(this.txtEscalationBy.val());


            if (CreatedDate == "") {
                alert("Date created is null");
                return;
            }

            var objParams = new Object();
            var objP = new Object();
            objP.ERNo = ERNo;
            objP.SRNo = SRNo;
            objP.AppCompany = AppCompany;
            objP.EndUser = EndUser;
            objP.Contact = Contact;
            objP.OC = OC;
            objP.ProductDesc = ProductDesc;
            objP.MLFB = MLFB;
            objP.SN = SN;
            objP.Abstract = Abstract;
            objP.Remark = Remark;
            objP.Status = Status;
            objP.Type = Type;
            objP.Priority = Priority;
            objP.CreatedDate = CreatedDate;
            objP.Owner = Owner;
            objP.EscalationBy = EscalationBy;
            objP.OperationType = "Save";
            objP.EscalationID = sID;

            var myArray = new Array();
            myArray[0] = objP;
            objParams.ParamsList = myArray;
            var json = JSON.stringify(objParams);

            var vrthis = this;
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../../InterfaceLibrary/Escalation/List/wsEscalation.asmx/subDB_Save",
                dataType: "json",
                data: json,
                success: function (msg) {
                    switch (msg.d) {
                        case "":
                            if (jsModuleName !="") {
                                grid.trigger("reloadGrid");
                                vrthis.fnOperationControlClear();
                            }
                            else {
                                vrthis.fnOperationControl(false);
                            }
                            alert("Save Successfully!");
                            break;
                        case "error":
                            alert("Save Error!");
                            break;
                    }
                }
            });
        },
        fnDelete: function () {
            if (!confirm("您确定删除记录吗?")) {
                return;
            }
            var vrthis = this;
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../../InterfaceLibrary/Escalation/List/wsEscalation.asmx/subDB_Delete",
                dataType: "json",
                data: "{EscalationID:'" + sID + "'}",
                success: function (msg) {
                    switch (msg.d) {
                        case "0":
                            if (jsModuleName != "") {
                                grid.trigger("reloadGrid");
                                vrthis.fnOperationControlClear();
                            }
                            else {
                                window.location.href = '../List/InProcessList.aspx'
                            }
                            alert("Save Successfully!");
                            break;
                        case "1":
                            alert("Save Error!");
                            break;
                    }
                }
            });
        },
        fnLoadDetail: function (EscalationID) {
            var self = this;
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../../InterfaceLibrary/Escalation/List/wsEscalation.asmx/ReturnEscalationMainInfo",
                dataType: "json",
                data: "{EscalationID:'" + EscalationID + "'}",
                success: function (msg) {
                    var result = msg.d;
                    self.txtERNo.val(result.ERNo.FieldValue);
                    self.txtSRNo.val(result.SRNo.FieldValue);
                    self.txtAppCompany.val(result.AppCompany.FieldValue);
                    self.txtEndUser.val(result.EndUser.FieldValue);
                    self.txtContact.val(result.Contact.FieldValue);
                    self.txtOC.val(result.OC.FieldValue);
                    self.txtMLFB.val(result.MLFB.FieldValue);
                    self.txtSN.val(result.SN.FieldValue);
                    self.txtAbstract.val(result.Abstract.FieldValue);
                    self.txtRemark.val(result.Remark.FieldValue);
                    self.cboStatus.val(result.Status.FieldValue);
                    self.cboType.val(result.Type.FieldValue);
                    self.dtpCreatedDate.val(parseMSJSONToDateTime(result.CreatedDate.FieldValue, '%Y-%m-%d %H:%M:%S'));
                    self.cboOwner.val(result.Owner.FieldValue);
                    self.txtEscalationBy.val(result.EscalationBy.FieldValue);
                },
                error: function (e) {
                }
            });

        },
        fnOperationType: function (OType) {
            OperType = OType;
            this.spanOperationTitle.text(OperType);
            var self = this;
            if (OType == "Addnew") {
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "../../InterfaceLibrary/Escalation/List/wsEscalation.asmx/funString_MaxEscalationNo",
                    dataType: "json",
                    data: "",
                    success: function (msg) {
                        var result = msg.d;
                        self.txtERNo.val(result);
                        var timestamp = Date.parse(new Date()) / 1000;
                        self.dtpCreatedDate.val($.datetime.format('%Y-%m-%d', timestamp));
                    },
                    error: function (e) {
                    }
                });
            }
        },
        fnOperationControlClear: function () {
            this.txtERNo.val("");
            this.txtSRNo.val("");
            this.txtAppCompany.val("");
            this.txtEndUser.val("");
            this.txtContact.val("");
            this.txtOC.val("");
            this.txtProductDesc.val("");
            this.txtMLFB.val("");
            this.txtSN.val("");
            this.txtAbstract.val("");
            this.txtRemark.val("");
            this.cboStatus.val("");
            this.cboType.val("");
            this.cboPriority.val("");
            this.dtpCreatedDate.val("");
            this.cboOwner.val("");
            this.txtEscalationBy.val("");
        },
        fnOperationControl: function (isDisable) {
            //this.txtERNo.removeAttr("disabled");
            this.txtSRNo.removeAttr("disabled");
            this.txtAppCompany.removeAttr("disabled");
            this.txtEndUser.removeAttr("disabled");
            this.txtContact.removeAttr("disabled");
            this.txtOC.removeAttr("disabled");
            this.txtProductDesc.removeAttr("disabled");
            this.txtMLFB.removeAttr("disabled");
            this.txtSN.removeAttr("disabled");
            this.txtAbstract.removeAttr("disabled");
            this.txtRemark.removeAttr("disabled");
            this.cboStatus.removeAttr("disabled");
            this.cboType.removeAttr("disabled");
            this.cboPriority.removeAttr("disabled");
            this.dtpCreatedDate.removeAttr("disabled");
            this.cboOwner.removeAttr("disabled");
            this.txtEscalationBy.removeAttr("disabled");
            if (!isDisable) {
                //this.txtERNo.attr("disabled", "disabled");
                this.txtSRNo.attr("disabled", "disabled");
                this.txtAppCompany.attr("disabled", "disabled");
                this.txtEndUser.attr("disabled", "disabled");
                this.txtContact.attr("disabled", "disabled");
                this.txtOC.attr("disabled", "disabled");
                this.txtProductDesc.attr("disabled", "disabled");
                this.txtMLFB.attr("disabled", "disabled");
                this.txtSN.attr("disabled", "disabled");
                this.txtAbstract.attr("disabled", "disabled");
                this.txtRemark.attr("disabled", "disabled");
                this.cboStatus.attr("disabled", "disabled");
                this.cboType.attr("disabled", "disabled");
                this.cboPriority.attr("disabled", "disabled");
                this.dtpCreatedDate.attr("disabled", "disabled");
                this.cboOwner.attr("disabled", "disabled");
                this.txtEscalationBy.attr("disabled", "disabled");
            }
        }
    });
    objOperation = new COperation({ el: $("#divOperation"), KeyID: "" });
});