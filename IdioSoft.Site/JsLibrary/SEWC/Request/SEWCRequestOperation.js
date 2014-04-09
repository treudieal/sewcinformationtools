var exports = this;
var VuRequestID = PuRequestIDs;
jQuery(function ($) {
    exports.SEWCRequestOperation = Controller.create({
        elements: {
            ".clstxtNotificationNo": "txtNotificationNo",
            ".clscboServiceProvider": "cboServiceProvider",
            ".clscboServiceType": "cboServiceType",
            ".clscboArea": "cboArea",
            ".clscboProductName": "cboProductName",
            ".clscboProductDesc": "cboProductDesc",
            ".clscboTransferUser": "cboTransferUser",
            ".clscboCaseProperty": "cboCaseProperty",
            ".clstxtSirot": "txtSirot",
            ".clstxtTransferID": "txtTransferID",
            ".clstxtTroubleDesc": "txtTroubleDesc",
            ".clschkRepair": "chkRepair",
            ".clscboWarranty": "cboWarranty",
            ".clschkisRepeat": "chkisRepeat",
            ".clstxtOriCase": "txtOriCase",
            ".clscboOrderType": "cboOrderType",
            ".clstxtRSVNo": "txtRSVNo",
            ".clstxtCreateUser": "txtCreateUser",
            ".clstxtCreateDate": "txtCreateDate",
            ".clstxtProjectNOExchExpend": "txtProjectNOExchExpend",
            ".clstxtProjectNameExchExpend": "txtProjectNameExchExpend",
            ".clschkAppExchExpend": "chkAppExchExpend",
            ".clschkEndExchExpend": "chkEndExchExpend",
            ".clstxtFSPostAddressExchExpend": "txtFSPostAddressExchExpend",
            ".clsbtnSelectAppCustomer": "btnSelectAppCustomer",
            ".clstxtAppCompanyName": "txtAppCompanyName",
            ".clstxtAppCustomerID": "txtAppCustomerID",
            ".clstxtAppProvince": "txtAppProvince",
            ".clstxtAppCity": "txtAppCity",
            ".clscboAppCustomerType": "cboAppCustomerType",
            ".clstxtAppContactName": "txtAppContactName",
            ".clstxtAppTel": "txtAppTel",
            ".clstxtAppFax": "txtAppFax",
            ".clstxtAppMobile": "txtAppMobile",
            ".clstxtAppAddress": "txtAppAddress",
            ".clstxtAppSubOffice": "txtAppSubOffice",
            ".clstxtAppPostCode": "txtAppPostCode",
            ".clstxtAppEmail": "txtAppEmail",
            ".clstxtAppVIPID": "txtAppVIPID",
            ".clstxtAppCountry": "txtAppCountry",
            ".clscboAppBranch": "cboAppBranch",
            ".clscboAppIsGroupDamex": "cboAppIsGroupDamex",
            ".clstxtAppSFAEVIPID": "txtAppSFAEVIPID",
            ".clsbtnSelectEndCustomer": "btnSelectEndCustomer",
            ".clsbtnClearEndUser": "btnClearEndUser",
            ".clstxtEnduserCompanyName": "txtEnduserCompanyName",
            ".clstxtEnduserCustomerID": "txtEnduserCustomerID",
            ".clstxtEnduserProvince": "txtEnduserProvince",
            ".clstxtEnduserCity": "txtEnduserCity",
            ".clscboEnduserCustomerType": "cboEnduserCustomerType",
            ".clstxtEnduserContactName": "txtEnduserContactName",
            ".clstxtEnduserTel": "txtEnduserTel",
            ".clstxtEnduserFax": "txtEnduserFax",
            ".clstxtEnduserMobile": "txtEnduserMobile",
            ".clstxtEnduserAddress": "txtEnduserAddress",
            ".clstxtEnduserSubOffice": "txtEnduserSubOffice",
            ".clstxtEnduserPostCode": "txtEnduserPostCode",
            ".clstxtEnduserEmail": "txtEnduserEmail",
            ".clstxtEnduserVIPID": "txtEnduserVIPID",
            ".clstxtEnduserCountry": "txtEnduserCountry",
            ".clscboEnduserBranch": "cboEnduserBranch",
            ".clscboEndIsGroupDamex": "cboEndIsGroupDamex",
            ".clstxtMachineManufacturer": "txtMachineManufacturer",
            ".clstxtTypeOfMachine": "txtTypeOfMachine",
            ".clstxtMachineSerialNo": "txtMachineSerialNo",
            ".clstxtControllerType": "txtControllerType",
            ".clstxtDriverType": "txtDriverType",
            ".clstxtSoftwareVersion": "txtSoftwareVersion",
            ".clstxtProcessingTechnology": "txtProcessingTechnology",
            ".clschkifdown": "chkifdown",
            ".clstxtRSCNo": "txtRSCNo",
            ".clstxtLocalRSCNo": "txtLocalRSCNo",
            ".clsdtpCaseTime": "dtpCaseTime",
            ".clstxtText": "txtText",
            ".clstxtCallagentComments": "txtCallagentComments",
            ".clstrMC1": "trMC1",
            ".clstrMC2": "trMC2",
            ".clstrMC3": "trMC3",
            ".clstrMC4": "trMC4",
            ".clstrMC5": "trMC5",
            ".clstrordertype": "trordertype",
            ".clstdName": "tdName",
            ".clstdValue": "tdValue",
            ".clstrSfaeExchProjectInfo": "trSfaeExchProjectInfo",
            ".lnkaddother": "lnkaddother",
            ".lnkdelother": "lnkdelother",
            ".tdItems": "tdItems",
            ".clsbtnSave": "btnSave",
            ".clsbtnTSave": "btnTSave",
            ".clsbtnSubmit": "btnSubmit",
            ".clsbtnTSubmit": "btnTSubmit",
            ".clsbtnModify": "btnModify",
            ".clsbtnDelete": "btnDelete",
            ".clsbtnCancel": "btnCancel",
            ".clsbtnPrint": "btnPrint",
            ".clsbtnSenderMessage": "btnSenderMessage",
            ".clsbtnSendMail": "btnSendMail",
            ".clsbtnCopy": "btnCopy",
            ".clscboMaterialProductName": "cboMaterialProductName",
            ".clscboMaterialProducDesc": "cboMaterialProducDesc",
            ".clscboMaterialFault": "cboMaterialFault",
            ".clsfileToUpload": "fileToUpload",
            ".clsbtnUploadfile": "btnUploadfile",
            "#tdAttachmentlist": "tdAttachmentlist",
            ".clsbtnDeletefile": "btnDeletefile",
            ".clscboDeliveryType": "cboDeliveryType",
            ".clsbtnCopyDeliveryInfo": "btnCopyDeliveryInfo",
            ".clstxtReceiveCompany": "txtReceiveCompany",
            ".clstxtReceiver": "txtReceiver",
            ".clstxtReceiverTel": "txtReceiverTel",
            ".clstxtReceiverAddress": "txtReceiverAddress"
        },
        events: {
            "click .lnkaddother": "fnAddother",
            "click .lnkdelother": "fnLnkdelother",
            "change .clscboServiceProvider": "fnServiceProviderSelectedIndexChanged",
            "change .clscboServiceType": "fnServiceTypeSelectedIndexChanged",
            "change .clscboArea": "fnAreaSelectedIndexChanged",
            "change .clscboProductName": "fnProductNameSelectedIndexChanged",
            "change .clscboCaseProperty": "fnCasePropertySelectedIndexChanged",
            "change .clscboOrderType": "fnOrderTypeSelectedIndexChanged",
            "change .clscboAppCustomerType": "fnAppCustomerTypeSelectedIndexChanged",
            "click .clsbtnSave": "fnSave",
            "click .clsbtnTSave": "fnSave",
            "click .clsbtnSubmit": "fnSubmit",
            "click .clsbtnTSubmit": "fnSubmit",
            "click .clsbtnModify": "fnModify",
            "click .clsbtnDelete": "fnDelete",
            "click .clsbtnCancel": "fnCancel",
            "click .clsbtnPrint": "fnPrint",
            "click .clsbtnSenderMessage": "fnSenderMessage",
            "click .clsbtnSendMail": "fnSendMail",
            "click .clsbtnCopy": "fnCopy",
            "change .clscboMaterialProductName": "fnMaterialProductNameSelectedIndexChanged",
            "click .clsbtnSelectAppCustomer": "fnSelectAppCustomer",
            "click .clsbtnSelectEndCustomer": "fnSelectEndCustomer",
            "click .clsbtnClearEndUser": "fnClearEndUser",
            "click .clsbtnUploadfile": "fnFileUpload",
            "click .clsbtnDeletefile": "fnDeletefile",
            "change .clscboDeliveryType": "fnDeliveryTypeChange",
            "click #btnCopyDeliveryInfo":"fnCopyDeliveryInfo"
        },
        fnCopyDeliveryInfo: function () {
            var cs = this.txtReceiveCompany.val() + "\\" + this.txtReceiver.val() + "\\" + this.txtReceiverTel.val() + "\\" + this.txtReceiverAddress.val();
            window.clipboardData.clearData();
            window.clipboardData.setData("Text", cs);
        },
        fnDeliveryTypeChange:function(obj){
            switch ($(obj.target).val()) {
                case "Applicant":
                    this.txtReceiveCompany.val(this.txtAppCompanyName.val());
                    this.txtReceiver.val(this.txtAppContactName.val());
                    this.txtReceiverTel.val(this.txtAppTel.val());
                    this.txtReceiverAddress.val(this.txtAppAddress.val());
                    break;
                case "Enduser":
                    this.txtReceiveCompany.val(this.txtEnduserCompanyName.val());
                    this.txtReceiver.val(this.txtEnduserContactName.val());
                    this.txtReceiverTel.val(this.txtEnduserTel.val());
                    this.txtReceiverAddress.val(this.txtEnduserAddress.val());
                    break;
                default:
                    this.txtReceiveCompany.val("");
                    this.txtReceiver.val("");
                    this.txtReceiverTel.val("");
                    this.txtReceiverAddress.val("");
            }

        },
        fnAddother: function (obj) {
            var vtr = $(".tdItems table").eq(0);
            var vtrNew = vtr.clone();
            $(vtrNew).find(".lnkaddother").remove();
            $(".tdItems").append(vtrNew);
            this.fnMLFBNoAutoLoad();
        },
        fnLnkdelother: function (obj) {
            //debugger;
            var $curtbl = $($(obj.target).parent().parent().parent().parent());
            var curIndex = $curtbl.index();
            if (curIndex == 0) {
                return false;
            }
            if ($(".tdItems table").length == 1) {
                return;
            }
            var vtr = $(obj.target).parents("table")[0];
            $(vtr).remove();
        },
        fnsubDB_LoadTransferID: function () {
            var ServiceProvider = encodeURI(this.cboServiceProvider.val());
            var ProductName = encodeURI(this.cboProductName.val());
            var Area = encodeURI(this.cboArea.val());
            var ServiceType = encodeURI(this.cboServiceType.val());
            var thisTransferID = this;
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Request/getTransferIDInfo.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "ServiceProvider=" + ServiceProvider + "&ProductName=" + ProductName + "&Area=" + Area + "&ServiceType=" + ServiceType + "",
                success: function (msg) {
                    //debugger;
                    thisTransferID.txtTransferID.val("");
                    var aryTransferID = eval("(" + unescape(msg) + ")");
                    thisTransferID.txtTransferID.val(aryTransferID[0]);

                    $.ajax({
                        type: "POST",
                        url: "../../InterfaceLibrary/Request/getTransferUserInfo.ashx",
                        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                        data: "TransferID=" + thisTransferID.txtTransferID.val() + "&ServiceProvider=" + ServiceProvider + "",
                        success: function (msg) {
                            thisTransferID.cboTransferUser.empty();
                            var aryTransferUser = eval("(" + unescape(msg) + ")");
                            thisTransferID.cboTransferUser.append("<option value=''> </option>");
                            if (aryTransferUser != "") {
                                //debugger;
                                for (var i = 0; i < aryTransferUser.length; i++) {
                                    var vruser = aryTransferUser[i];
                                    var ss = vruser.split('$$$');

                                    thisTransferID.cboTransferUser.append("<option value='" + ss[0] + "'>" + ss[1] + "</option>");
                                }
                            }
                        }
                    });
                }
            });

        },
        fnServiceProviderSelectedIndexChanged: function () {
            var ServiceProvider = encodeURI(this.cboServiceProvider.val());
            var ProductName = encodeURI(this.cboProductName.val());
            var Area = encodeURI(this.cboArea.val());
            var ServiceType = encodeURI(this.cboServiceType.val());
            var thisServiceProvider = this;
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Request/getAreaInfo.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "ServiceProvider=" + ServiceProvider + "",
                success: function (msg) {
                    thisServiceProvider.cboArea.empty();
                    var aryArea = eval("(" + unescape(msg) + ")");
                    thisServiceProvider.cboArea.append("<option value=''> </option>");
                    if (aryArea != "") {
                        for (var i = 0; i < aryArea.length; i++) {
                            thisServiceProvider.cboArea.append("<option value='" + aryArea[i] + "'>" + aryArea[i] + "</option>");
                        }
                    }
                }
            });
            //thisServiceProvider.fnsubDB_LoadTransferID();
        },
        fnServiceTypeSelectedIndexChanged: function () {
            var ServiceProvider = encodeURI(this.cboServiceProvider.val());
            var ProductName = encodeURI(this.cboProductName.val());
            var Area = encodeURI(this.cboArea.val());
            var ServiceType = encodeURI(this.cboServiceType.val().toLowerCase());
            var thisServiceType = this;
            switch (ServiceType) {
                case "ihr":
                    thisServiceType.trMC1.show();
                    thisServiceType.trMC2.show();
                    thisServiceType.trMC3.show();
                    thisServiceType.trMC4.show();
                    thisServiceType.trMC5.show();
                    //thisServiceType.trordertype.hide();
                    break;
                case "exch":
                    thisServiceType.trMC1.show();
                    thisServiceType.trMC2.show();
                    thisServiceType.trMC3.show();
                    thisServiceType.trMC4.show();
                    thisServiceType.trMC5.show();
                    //thisServiceType.trordertype.show();
                    break;
            }

            //thisServiceType.fnsubDB_LoadTransferID();
        },
        fnAreaSelectedIndexChanged: function () {
            var thisArea = this;
            //thisArea.fnsubDB_LoadTransferID();
        },
        fnProductNameSelectedIndexChanged: function () {
            var thisProductName = this;
            var ServiceProvider = encodeURI(this.cboServiceProvider.val())
            var ProductName = encodeURI(this.cboProductName.val());
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Request/getProductDescInfo.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "ServiceProvider=" + ServiceProvider + "&ProductName=" + ProductName + "",
                success: function (msg) {
                    thisProductName.cboProductDesc.empty();
                    var aryProductName = eval("(" + unescape(msg) + ")");
                    thisProductName.cboProductDesc.append("<option value=''> </option>");
                    if (aryProductName != "") {
                        for (var i = 0; i < aryProductName.length; i++) {
                            thisProductName.cboProductDesc.append("<option value='" + aryProductName[i] + "'>" + aryProductName[i] + "</option>");
                        }
                    }
                }
            });
            //thisProductName.fnsubDB_LoadTransferID();
        },
        fnCasePropertySelectedIndexChanged: function () {
            var thisCaseProperty = this;
            var CaseProperty = thisCaseProperty.cboCaseProperty.val().toLowerCase();
            if (CaseProperty == "international order") {
                thisCaseProperty.txtSirot.removeAttr("disabled");
            } else {
                thisCaseProperty.txtSirot.attr("disabled", "disabled");
            }
        },
        fnOrderTypeSelectedIndexChanged: function () {
            var thisOrderType = this;
            var OrderType = thisOrderType.cboOrderType.val().toLowerCase();
            if (OrderType == "project expend") {
                thisOrderType.trSfaeExchProjectInfo.show();
            } else {
                thisOrderType.trSfaeExchProjectInfo.hide();
            }
        },
        fnAppCustomerTypeSelectedIndexChanged: function () {
            var thisAppCustomerType = this;
            thisAppCustomerType.txtAppCompanyName.removeAttr("style");
            var AppVIPID = thisAppCustomerType.txtAppVIPID.val().toLowerCase();
            if (AppVIPID.indexOf("sfae-b") >= 0 || AppVIPID.indexOf("sfae-s") >= 0) {
                thisAppCustomerType.txtAppCompanyName.attr("style", "width: 490px;border:1px solid blue;");
            } else {
                thisAppCustomerType.txtAppCompanyName.attr("style", "width: 490px;border-left-color: #7F9DB9; border-bottom-color: #7F9DB9; border-top-style: solid; border-top-color: #7F9DB9; border-right-style: solid; border-left-style: solid; border-right-color: #7F9DB9; border-bottom-style: solid;");
            }
        },
        fnMaterialProductNameSelectedIndexChanged: function (obj) {
            var ServiceProvider = encodeURI(this.cboServiceProvider.val());
            var MaterialProductName = encodeURI($(obj.target).val()); //encodeURI(this.cboMaterialProductName.val());
            var thisMaterialProductName = this;

            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Request/getMaterialProducDescInfo.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "ServiceProvider=" + ServiceProvider + "&MaterialProductName=" + MaterialProductName + "",
                success: function (msg) {
                    //thisMaterialProductName.cboMaterialProducDesc.empty();
                    $(obj.target).parent().parent().find("td").eq(3).find("select").empty();
                    var aryMaterialProducDesc = eval("(" + unescape(msg) + ")");
                    //thisMaterialProductName.cboMaterialProducDesc.append("<option value=''> </option>");
                    $(obj.target).parent().parent().find("td").eq(3).find("select").append("<option value=''> </option>");
                    if (aryMaterialProducDesc != "") {
                        for (var i = 0; i < aryMaterialProducDesc.length; i++) {
                            //thisMaterialProductName.cboMaterialProducDesc.append("<option value='" + aryMaterialProducDesc[i] + "'>" + aryMaterialProducDesc[i] + "</option>");
                            $(obj.target).parent().parent().find("td").eq(3).find("select").append("<option value='" + aryMaterialProducDesc[i] + "'>" + aryMaterialProducDesc[i] + "</option>");
                        }
                    }
                }
            });

            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Request/getMaterialFaultInfo.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "ServiceProvider=" + ServiceProvider + "&MaterialProductName=" + MaterialProductName + "",
                success: function (msg) {
                    //thisMaterialProductName.cboMaterialFault.empty();
                    $(obj.target).parent().parent().parent().find("tr").eq(2).find("td").eq(1).find("select").empty();
                    var aryMaterialFault = eval("(" + unescape(msg) + ")");
                    //thisMaterialProductName.cboMaterialFault.append("<option value=''> </option>");
                    $(obj.target).parent().parent().parent().find("tr").eq(2).find("td").eq(1).find("select").append("<option value=''> </option>");
                    if (aryMaterialFault != "") {
                        for (var i = 0; i < aryMaterialFault.length; i++) {
                            //thisMaterialProductName.cboMaterialFault.append("<option value='" + aryMaterialFault[i] + "'>" + aryMaterialFault[i] + "</option>");
                            $(obj.target).parent().parent().parent().find("tr").eq(2).find("td").eq(1).find("select").append("<option value='" + aryMaterialFault[i] + "'>" + aryMaterialFault[i] + "</option>");
                        }
                    }
                }
            });
        },
        fnSaveProcess: function (intType,e) {
            var TransferUser = "";//encodeURI(this.cboTransferUser.val());
            var CaseTime = "";
            if (encodeURI(this.dtpCaseTime.val()) != "") {
                CaseTime = encodeURI(this.dtpCaseTime.val());
            }
            var ServiceType = encodeURI(this.cboServiceType.val());
            var ProductName = "";// encodeURI(this.cboProductName.val());
            var ProductDesc = "";//encodeURI(this.cboProductDesc.val());
            var CaseProperty = encodeURI(this.cboCaseProperty.val());
            var ServiceProvider = encodeURI(this.cboServiceProvider.val());
            var Area = encodeURI(this.cboArea.val());

            var AppAccountID = "";
            var AppContactID = "";
            var EnduserAccountID = "";
            var EnduserContactID = "";

            var AppIsGroupDamex = encodeURI(this.cboAppIsGroupDamex.is(":checked"));
            var EnduserIsGroupDamex = encodeURI(this.cboEndIsGroupDamex.is(":checked"));
            var Status = "";
            if (intType == 1)
            {
                Status = "OPEN";
            }
            var ExchExpendProjectName = encodeURI(this.txtProjectNameExchExpend.val());
            var ExchExpendProjectNO = encodeURI(this.txtProjectNOExchExpend.val());
            var ExchExpendSelectCompany = encodeURI(this.chkAppExchExpend.is(":checked"));
            var ExchExpendFSPostAddress = encodeURI(this.txtFSPostAddressExchExpend.val());
            var OrderType = encodeURI(this.cboOrderType.val());
            var RSVNO = encodeURI(this.txtRSVNo.val());
            var MachineManufacturer = encodeURI(this.txtMachineManufacturer.val());
            var TypeOfMachine = encodeURI(this.txtTypeOfMachine.val());
            var MachineSerialNo = encodeURI(this.txtMachineSerialNo.val());
            var ControllerType = encodeURI(this.txtControllerType.val());
            var DriverType = encodeURI(this.txtDriverType.val());
            var SoftwareVersion = encodeURI(this.txtSoftwareVersion.val());
            var ProcessingTechnology = encodeURI(this.txtProcessingTechnology.val());
            var IfDown = encodeURI(this.chkifdown.is(":checked"));
            var Warranty = encodeURI(this.cboWarranty.val());
            var RSCNo = encodeURI(this.txtRSCNo.val());
            var LocalRSCNo = encodeURI(this.txtLocalRSCNo.val());
            var isRepair = encodeURI(this.chkRepair.is(":checked"));
            var isRepeat = encodeURI(this.chkisRepeat.is(":checked"));
            var SFAEVIPID = encodeURI(this.txtAppSFAEVIPID.val());
            var OriCase = encodeURI(this.txtOriCase.val());
            var CaseVIP = "";
            if (encodeURI(this.txtAppVIPID.val()) != "") {
                CaseVIP = encodeURI(this.txtAppVIPID.val());
            }
            if (encodeURI(this.txtEnduserVIPID.val()) != "") {
                CaseVIP = encodeURI(this.txtEnduserVIPID.val());
            }
            var NotificationNo = encodeURI(this.txtNotificationNo.val());
            var Sirot = encodeURI(this.txtSirot.val());
            var TroubleDesc = encodeURI(this.txtTroubleDesc.val());

            var AppCompanyName = encodeURI(this.txtAppCompanyName.val());
            var AppSubOffice = encodeURI(this.txtAppSubOffice.val());
            var AppCustomerID = encodeURI(this.txtAppCustomerID.val());
            var AppProvince = encodeURI(this.txtAppProvince.val());
            var AppCity = encodeURI(this.txtAppCity.val());
            var AppCustomerType = encodeURI(this.cboAppCustomerType.val());
            var AppContactName = encodeURI(this.txtAppContactName.val());
            var AppTel = encodeURI(this.txtAppTel.val());
            var AppMobile = encodeURI(this.txtAppMobile.val());
            var AppFax = encodeURI(this.txtAppFax.val());
            var AppAddress = encodeURI(this.txtAppAddress.val());
            var AppPostCode = encodeURI(this.txtAppPostCode.val());
            var AppEmail = encodeURI(this.txtAppEmail.val());

            var EnduserCompanyName = encodeURI(this.txtEnduserCompanyName.val());
            var EnduserSubOffice = encodeURI(this.txtEnduserSubOffice.val());
            var EnduserCustomerID = encodeURI(this.txtEnduserCustomerID.val());
            var EnduserProvince = encodeURI(this.txtEnduserProvince.val());
            var EnduserCity = encodeURI(this.txtEnduserCity.val());
            var EnduserCustomerType = encodeURI(this.cboEnduserCustomerType.val());
            var EnduserContactName = encodeURI(this.txtEnduserContactName.val());
            var EnduserTel = encodeURI(this.txtEnduserTel.val());
            var EnduserMobile = encodeURI(this.txtEnduserMobile.val());
            var EnduserFax = encodeURI(this.txtEnduserFax.val());
            var EnduserAddress = encodeURI(this.txtEnduserAddress.val());
            var EnduserPostCode = encodeURI(this.txtEnduserPostCode.val());
            var EnduserEmail = encodeURI(this.txtEnduserEmail.val());

            var Text = encodeURI(this.txtText.val());
            var CallagentComments = encodeURI(this.txtCallagentComments.val());
            var DutyID = encodeURI(this.txtTransferID.val());

            var AppCountry = encodeURI(this.txtAppCountry.val());
            var AppBranch = encodeURI(this.cboAppBranch.val());
            var EnduserCountry = encodeURI(this.txtEnduserCountry.val());
            var EnduserBranch = encodeURI(this.cboEnduserBranch.val());
            var AppVIPID = encodeURI(this.txtAppVIPID.val());
            var EnduserVIPID = encodeURI(this.txtEnduserVIPID.val());

            var uRequestID = VuRequestID;
            if (ServiceType == "") {
                alert("ServiceType is Null!")
                return;
            }

            var vAll1 = "";
            var vAll = "";
            var vCount = $(".tdItems table").length;
            for (var i = 0; i < vCount; i++) {
                var MLFBNo = $(".tdItems table").eq(i).find("tr").eq(0).find("td").eq(1).find("input").val();
                if (MLFBNo == "") {
                    alert("Product Info is Null！");
                    return;
                }
                var SerialNo = $(".tdItems table").eq(i).find("tr").eq(0).find("td").eq(3).find("input").val();

                var MaterialProductName = $(".tdItems table").eq(i).find("tr").eq(1).find("td").eq(1).find(".clscboMaterialProductName").val();
                var MaterialProducDesc = $(".tdItems table").eq(i).find("tr").eq(1).find("td").eq(3).find(".clscboMaterialProducDesc").val();

                var MaterialFault = $(".tdItems table").eq(i).find("tr").eq(2).find("td").eq(1).find(".clscboMaterialFault").val();
                var Quantity = $(".tdItems table").eq(i).find("tr").eq(2).find("td").eq(3).find("input").val();

                var TransferUser = $(".tdItems table").eq(i).find("tr").eq(3).find("td").eq(1).find(".clscboTransferUser").val();

                vAll1 = "[" + MLFBNo + "$$$" + SerialNo + "$$$" + MaterialProductName + "$$$" + MaterialProducDesc + "$$$" + MaterialFault + "$$$" + Quantity + "$$$" + TransferUser + "]";
                vAll = vAll + vAll1;
            }

            var VIPSalesEmail = "";

            var DeliveryType = encodeURI(this.cboDeliveryType.val());
            var ReceiveCompany = encodeURI(this.txtReceiveCompany.val());
            var Receiver = encodeURI(this.txtReceiver.val());
            var ReceiverTel = encodeURI(this.txtReceiverTel.val());
            var ReceiverAddress = encodeURI(this.txtReceiverAddress.val());

            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Request/SEWCRequestOperation.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "isRepair=" + isRepair + "&uRequestID=" + uRequestID + "&OperationType=save&Items=" + vAll
                    + "&VIPSalesEmail=" + VIPSalesEmail + "&CaseVIP=" + CaseVIP + "&SFAEVIPID=" + SFAEVIPID + "&isRepeat=" + isRepeat
                    + "&OriCase=" + OriCase + "&LocalRSCNo=" + LocalRSCNo + "&RSCNo=" + RSCNo + "&IfDown=" + IfDown
                    + "&ProcessingTechnology=" + ProcessingTechnology + "&EnduserIsGroupDamex=" + EnduserIsGroupDamex + "&AppIsGroupDamex="
                    + AppIsGroupDamex + "&SoftwareVersion=" + SoftwareVersion + "&DriverType=" + DriverType + "&ControllerType=" + ControllerType
                    + "&MachineSerialNo=" + MachineSerialNo + "&TypeOfMachine=" + TypeOfMachine + "&MachineManufacturer=" + MachineManufacturer
                    + "&RSVNO=" + RSVNO + "&OrderType=" + OrderType + "&ExchExpendFSPostAddress=" + ExchExpendFSPostAddress
                    + "&ExchExpendSelectCompany=" + ExchExpendSelectCompany + "&ExchExpendProjectNO=" + ExchExpendProjectNO
                    + "&ExchExpendProjectName=" + ExchExpendProjectName + "&EnduserContactID=" + EnduserContactID + "&EnduserAccountID=" + EnduserAccountID
                    + "&EnduserVIPID=" + EnduserVIPID + "&AppContactID=" + AppContactID + "&AppAccountID=" + AppAccountID + "&AppVIPID=" + AppVIPID + "&Warranty=" + Warranty
                    + "&Status=" + Status + "&EnduserBranch=" + EnduserBranch + "&EnduserCountry=" + EnduserCountry + "&AppBranch=" + AppBranch + "&AppCountry=" + AppCountry
                    + "&TransferUser=" + TransferUser + "&isSubmit=" + intType + "&DutyID=" + DutyID + "&CallagentComments=" + CallagentComments + "&Text=" + Text + "&CaseTime=" + CaseTime
                    + "&EnduserEmail=" + EnduserEmail + "&EnduserPostCode=" + EnduserPostCode + "&EnduserAddress=" + EnduserAddress + "&EnduserFax=" + EnduserFax
                    + "&EnduserMobile=" + EnduserMobile + "&EnduserTel=" + EnduserTel + "&EnduserContactName=" + EnduserContactName + "&EnduserCustomerType="
                    + EnduserCustomerType + "&EnduserCity=" + EnduserCity + "&EnduserProvince=" + EnduserProvince + "&EnduserCustomerID=" + EnduserCustomerID
                    + "&EnduserSubOffice=" + EnduserSubOffice + "&EnduserCompanyName=" + EnduserCompanyName + "&AppEmail=" + AppEmail + "&AppPostCode=" + AppPostCode
                    + "&AppAddress=" + AppAddress + "&AppFax=" + AppFax + "&AppMobile=" + AppMobile + "&AppTel=" + AppTel + "&AppContactName=" + AppContactName
                    + "&AppCustomerType=" + AppCustomerType + "&AppCity=" + AppCity + "&AppProvince=" + AppProvince + "&AppCustomerID=" + AppCustomerID
                    + "&AppSubOffice=" + AppSubOffice + "&AppCompanyName=" + AppCompanyName + "&TroubleDesc=" + TroubleDesc + "&Sirot=" + Sirot
                    + "&CaseProperty=" + CaseProperty + "&ServiceProvider=" + ServiceProvider + "&Area=" + Area + "&ProductDesc=" + ProductDesc
                    + "&NotificationNo=" + NotificationNo + "&ServiceType=" + ServiceType
                    + "&ProductName=" + ProductName + "&DeliveryType=" + DeliveryType + "&ReceiveCompany=" + ReceiveCompany
                    + "&Receiver=" + Receiver + "&ReceiverTel=" + ReceiverTel + "&ReceiverAddress=" + ReceiverAddress,
                success: function (msg) {
                    switch (msg) {
                        case "0":
                            $(e.target).removeAttr("disabled");
                            alert("Save Successfully!");
                            //parent.$.fn.colorbox.close();
                            window.close();
                            break;
                        case "1":
                            $(e.target).removeAttr("disabled");
                            alert("Save Error!");
                            break;
                        case "2":
                            $(e.target).removeAttr("disabled");
                            alert("Warranty is Null!");
                            break;
                    }
                }
            });
        },
        fnSave: function (e) {
            $(e.target).attr("disabled", "disabled");
            this.fnSaveProcess(0,e);
   
        },
        fnSubmit: function (e) {
            $(e.target).attr("disabled", "disabled");
            this.fnSaveProcess(1,e);
            
        },
        fnClearEndUser: function () {
            this.txtEnduserAddress.val("");
            this.txtEnduserCity.val("");
            this.txtEnduserCompanyName.val("");
            this.txtEnduserContactName.val("");
            this.txtEnduserCountry.val("");
            this.txtEnduserCustomerID.val("");
            this.txtEnduserEmail.val("");
            this.txtEnduserFax.val("");
            this.txtEnduserMobile.val("");
            this.txtEnduserPostCode.val("");
            this.txtEnduserProvince.val("");
            this.txtEnduserSubOffice.val("");
            this.txtEnduserTel.val("");
            this.txtEnduserVIPID.val("");

            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Request/SEWCRequestOperation.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "uRequestID=" + PuRequestIDs + "&OperationType=ClearEndUser",
                success: function (msg) {
                    switch (msg) {
                        case "0":
                            $(".clstdAttachmentlist").text("");
                            alert("Delete Successfully!");
                            //parent.$.fn.colorbox.close();
                            //window.close();
                            break;
                        case "1":
                            alert("Delete Error!");
                            break;
                    }
                }
            });
        },
        fnsubControl_EnableALL: function (blen) {

            $(".clstxtMLFBNo").attr("disabled", !blen);
            $(".clstxtSerialNo").attr("disabled", !blen);
            $(".clscboMaterialProductName").attr("disabled", !blen);
            $(".clscboMaterialProducDesc").attr("disabled", !blen);
            $(".clscboMaterialFault").attr("disabled", !blen);
            $(".clstxtQuantity").attr("disabled", !blen);
            $(".clscboTransferUser").attr("disabled", !blen);

            this.txtNotificationNo.attr("disabled", !blen);
            this.cboProductDesc.attr("disabled", !blen);
            this.cboTransferUser.attr("disabled", !blen);
            this.cboCaseProperty.attr("disabled", !blen);
            this.txtSirot.attr("disabled", !blen);
            this.txtTroubleDesc.attr("disabled", !blen);
            this.chkRepair.attr("disabled", !blen);
            this.cboWarranty.attr("disabled", !blen);
            this.chkisRepeat.attr("disabled", !blen);
            this.txtOriCase.attr("disabled", !blen);
            this.txtAppSFAEVIPID.attr("disabled", !blen);
            this.dtpCaseTime.attr("disabled", !blen);
            this.txtText.attr("disabled", !blen);
            this.txtCallagentComments.attr("disabled", !blen);

            this.txtAppVIPID.attr("disabled", !blen);
            this.txtEnduserVIPID.attr("disabled", !blen);

            this.cboAppIsGroupDamex.attr("disabled", !blen);
            this.cboEndIsGroupDamex.attr("disabled", !blen);

            this.txtEnduserCountry.attr("disabled", !blen);


            this.txtAppAddress.removeAttr("disabled");
            this.txtAppAddress.attr("disabled", !blen);
            this.txtEnduserAddress.attr("disabled", !blen);

            this.txtAppCity.removeAttr("disabled");
            this.txtAppCity.attr("disabled", !blen);
            this.txtEnduserCity.attr("disabled", !blen);

            this.txtAppCompanyName.removeAttr("disabled");
            this.txtAppCompanyName.attr("disabled", !blen);
            this.txtEnduserCompanyName.attr("disabled", !blen);

            this.txtAppContactName.removeAttr("disabled");
            this.txtAppContactName.attr("disabled", !blen);
            this.txtEnduserContactName.attr("disabled", !blen);

            this.txtAppCustomerID.removeAttr("disabled");
            this.txtAppCustomerID.attr("disabled", !blen);
            this.txtEnduserCustomerID.attr("disabled", !blen);

            this.txtAppEmail.removeAttr("disabled");
            this.txtAppEmail.attr("disabled", !blen);
            this.txtEnduserEmail.attr("disabled", !blen);

            this.txtAppFax.removeAttr("disabled");
            this.txtAppFax.attr("disabled", !blen);
            this.txtEnduserFax.attr("disabled", !blen);

            this.txtAppMobile.removeAttr("disabled");
            this.txtAppMobile.attr("disabled", !blen);
            this.txtEnduserMobile.attr("disabled", !blen);

            this.txtAppPostCode.removeAttr("disabled");
            this.txtAppPostCode.attr("disabled", !blen);
            this.txtEnduserPostCode.attr("disabled", !blen);

            this.txtAppProvince.removeAttr("disabled");
            this.txtAppProvince.attr("disabled", !blen);
            this.txtEnduserProvince.attr("disabled", !blen);

            this.txtAppSubOffice.removeAttr("disabled");
            this.txtAppSubOffice.attr("disabled", !blen);
            this.txtEnduserSubOffice.attr("disabled", !blen);

            this.txtAppTel.removeAttr("disabled");
            this.txtAppTel.attr("disabled", !blen);
            this.txtEnduserTel.attr("disabled", !blen);

            this.cboAppBranch.removeAttr("disabled");
            this.cboAppBranch.attr("disabled", !blen);
            this.cboEnduserBranch.attr("disabled", !blen);

            this.cboServiceType.removeAttr("disabled");
            this.cboServiceType.attr("disabled", !blen);

            this.cboArea.removeAttr("disabled");
            this.cboArea.attr("disabled", !blen);

            this.cboProductName.removeAttr("disabled");
            this.cboProductName.attr("disabled", !blen);

            this.cboAppCustomerType.removeAttr("disabled");
            this.cboAppCustomerType.attr("disabled", !blen);
            this.cboEnduserCustomerType.attr("disabled", !blen);

            this.cboServiceProvider.removeAttr("disabled");
            this.cboServiceProvider.attr("disabled", !blen);

            this.cboOrderType.removeAttr("disabled");
            this.cboOrderType.attr("disabled", !blen);

            this.txtRSVNo.removeAttr("disabled");
            this.txtRSVNo.attr("disabled", !blen);
        },
        fnModify: function () {
            this.fnsubControl_EnableALL(true);

            this.btnSave.removeAttr("disabled");
            this.btnSubmit.removeAttr("disabled");
            this.btnTSave.removeAttr("disabled");
            this.btnTSubmit.removeAttr("disabled");


            this.btnSelectAppCustomer.removeAttr("disabled");
            this.btnSelectEndCustomer.removeAttr("disabled");
            //this.btnAddNewMainMaterial.removeAttr("disabled");
            //this.btnAddNewMainMaterial.attr("disabled", false);
        },
        fnDelete: function () {
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Request/SEWCRequestOperation.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "uRequestID=" + PuRequestIDs + "&OperationType=Delete",
                success: function (msg) {
                    switch (msg) {
                        case "0":
                            alert("Delete Successfully!");
                            //parent.$.fn.colorbox.close();
                            window.close();
                            break;
                        case "1":
                            alert("Delete Error!");
                            break;
                    }
                }
            });
        },
        fnCancel: function () {
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Request/SEWCRequestOperation.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "uRequestID=" + PuRequestIDs + "&OperationType=Cancel",
                success: function (msg) {
                    switch (msg) {
                        case "0":
                            alert("Cancel Successfully!");
                            //parent.$.fn.colorbox.close();
                            window.close();
                            break;
                        case "1":
                            alert("Cancel Error!");
                            break;
                    }
                }
            });
        },
        fnPrint: function () {
            window.open("RequestPrintTemplate.aspx?uRequestID=" + PuRequestIDs + "", 'mywindow', 'width=500,height=160,top=250, left=300, toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no');
        },
        fnSenderMessage: function () {
            window.open("RequestSenderMsg.aspx?uRequestID=" + PuRequestIDs + "", 'mywindow', 'width=390,height=260,top=250, left=300, toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no');
        },
        fnSendMail: function () {
            window.open("RequestSendMail.aspx?uRequestID=" + PuRequestIDs + "", 'mywindow', 'width=400,height=260,top=250, left=300, toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no');
        },
        fnCopy: function () {
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Request/SEWCRequestOperation.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "uRequestID=" + PuRequestIDs + "&OperationType=Copy",
                success: function (msg) {
                    if (msg != "") {
                        window.location = "SEWCRequestOperation.aspx?uRequestID=" + PuRequestIDs + "&OperationType=Modify";
                    } else {
                        alert("Copy Error!");
                    }
                }
            });
        },
        fnSelectAppCustomer: function () {
            var dateObj = new Date();
            //$.colorbox({
            //    href: "SelectCustomerAndContactInfo.aspx?uRequestID=" + PuRequestIDs + "&OperationType=app",
            //    ifname:true,
            //    innerWidth: 680,
            //    innerHeight: 490,
            //    opacity: 0.85,
            //    scrolling:false,
            //    overlayClose:false
            //});
            //window.open("SelectCustomerAndContactInfo.aspx?OperationType=app&uRequestID=" + PuRequestIDs + "", 'mywindow', 'width=680,height=450,top=250, left=300, toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no');
            window.showModalDialog("SelectCustomerAndContactInfo.aspx?uRequestID=" + PuRequestIDs + "&OperationType=app&t=" + dateObj.toString(), window, 'dialogWidth=860px;dialogHeight=490px;;resizable=no');
        },
        fnSelectEndCustomer: function () {
            var dateObj = new Date();
            //$.colorbox({
            //    href: "SelectCustomerAndContactInfo.aspx?uRequestID=" + PuRequestIDs + "&OperationType=end",
            //    ifname: true,
            //    innerWidth: 680,
            //    innerHeight: 490,
            //    opacity: 0.85,
            //    scrolling: false,
            //    overlayClose: false
            //});
            //window.open("SelectCustomerAndContactInfo.aspx?uRequestID=" + PuRequestIDs + "", 'mywindow', 'width=720,height=550,top=250, left=300, toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no');
            window.showModalDialog("SelectCustomerAndContactInfo.aspx?uRequestID=" + PuRequestIDs + "&OperationType=end&t=" + dateObj.toString(), window, 'dialogWidth=860px;dialogHeight=490px;;resizable=no');
        },
        fnAppSelectCustomerLoad: function (AccountID, CustomerID, CompanyName, SubOffice, Province, City, CustomerType, CompanyAddress, PostAddress, RegAddress, ConsignorAddress, TaxCode, AccountCode,
                       BankName, FinanceTel, Country, Branch, VIPID, IsGroupDamex, BeiDeVIP, SFAEVIPID, ContactID, ContactName, Tel, Fax, Mobile, Address, PostCode, Email) {
            this.txtAppCompanyName.val(CompanyName);
            this.txtAppCustomerID.val(CustomerID);
            this.txtAppProvince.val(Province);
            this.txtAppCity.val(City);
            this.cboAppCustomerType.val(CustomerType);
            this.txtAppContactName.val(ContactName);
            this.txtAppTel.val(Tel);
            this.txtAppFax.val(Fax);
            this.txtAppMobile.val(Mobile);
            this.txtAppAddress.val(Address);
            this.txtAppSubOffice.val(SubOffice);
            this.txtAppPostCode.val(PostCode);
            this.txtAppEmail.val(Email);
            this.txtAppVIPID.val(VIPID);
            this.txtAppCountry.val(Country);
            this.cboAppBranch.val(Branch);
            this.cboAppIsGroupDamex.val(IsGroupDamex);
            this.txtAppSFAEVIPID.val(SFAEVIPID);
        },
        fnEndUserSelectCustomerLoad: function (AccountID, CustomerID, CompanyName, SubOffice, Province, City, CustomerType, CompanyAddress, PostAddress, RegAddress, ConsignorAddress, TaxCode, AccountCode,
                       BankName, FinanceTel, Country, Branch, VIPID, IsGroupDamex, BeiDeVIP, SFAEVIPID, ContactID, ContactName, Tel, Fax, Mobile, Address, PostCode, Email) {
            this.txtEnduserCompanyName.val(CompanyName);
            this.txtEnduserCustomerID.val(CustomerID);
            this.txtEnduserProvince.val(Province);
            this.txtEnduserCity.val(City);
            this.cboEnduserCustomerType.val(CustomerType);
            this.txtEnduserContactName.val(ContactName);
            this.txtEnduserTel.val(Tel);
            this.txtEnduserFax.val(Fax);
            this.txtEnduserMobile.val(Mobile);
            this.txtEnduserAddress.val(Address);
            this.txtEnduserSubOffice.val(SubOffice);
            this.txtEnduserPostCode.val(PostCode);
            this.txtEnduserEmail.val(Email);
            this.txtEnduserVIPID.val(VIPID);
            this.txtEnduserCountry.val(Country);
            this.cboEnduserBranch.val(Branch);
            this.cboEndIsGroupDamex.val(IsGroupDamex);
        },
        fnFileUpload: function () {
            var sf = PuRequestIDs;
            $.ajaxFileUpload({
                url: '../../InterfaceLibrary/SEWC/Request/doajaxfileupload.ashx',
                secureuri: false,
                fileElementId: "fileToUpload",
                dataType: 'json',
                data: { uRequestID: PuRequestIDs },
                success: function (data) {
                    if (data.iserror) {
                        alert("出现错误!");
                        return;
                    }
                    if (data.fileName != "") {
                        $.ajax({
                            type: "POST",
                            url: "../../InterfaceLibrary/Request/getRequestDocumentInfo.ashx",
                            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                            data: "uRequestID=" + PuRequestIDs + "",
                            success: function (msg) {
                                var aryArea = eval("(" + unescape(msg) + ")");
                                if (aryArea != "") {
                                    for (var i = 0; i < aryArea.length; i++) {
                                        if (aryArea[i] != "") {
                                            var filename = aryArea[i].substring(aryArea[i].lastIndexOf("/") + 1);
                                            $(".clstdAttachmentlist").append("<a href='../../RequestDocument/" + aryArea[i] + "' target='_blank'>" + filename + "</a>");
                                        }
                                    }
                                }
                            }
                        });
                    }
                },
                error: function (data) {
                    alert("error");
                }
            });
            return false;
        },
        fnDeletefile: function () {
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Request/SEWCRequestOperation.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "uRequestID=" + PuRequestIDs + "&OperationType=DeleteFile",
                success: function (msg) {
                    switch (msg) {
                        case "0":
                            $(".clstdAttachmentlist").text("");
                            alert("Delete Successfully!");
                            //parent.$.fn.colorbox.close();
                            //window.close();
                            break;
                        case "1":
                            alert("Delete Error!");
                            break;
                    }
                }
            });
        },
        fnMLFBNoAutoLoad: function () {
            var self = this;
            $(".clstxtMLFBNo").autocomplete("../../InterfaceLibrary/SEWC/Request/getMLFBNoList.ashx?sType=mlfb", {
                multiple: false,
                mustMatch: false,
                multipleSeparator: "",
                autoFill: false,
                selectFirst: false
            }).result(function (event, data, formatted) {
                $.ajax({
                    type: "POST",
                    url: "../../InterfaceLibrary/SEWC/Request/getMLFBNoList.ashx",
                    contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                    data: "MLFB=" + data + "&sType=product",
                    success: function (msg) {
                        if (msg != "") {
                            var json = eval('(' + msg + ')');
                            var gb = $(event.target).parent().parent().parent();
                            //self.cboMaterialProductName.val(json.ProductGroup);
                        }
                    }
                });
            });
        }
    });
    var objSEWCRequestOperation = new SEWCRequestOperation({ el: $("#tblOperation"), KeyID: "", OpType: "" });


    exports.CustomerOpReturn = Controller.create({
        fnSelectCustomerReturn: function (AccountID, CustomerID, CompanyName, SubOffice, Province, City, CustomerType, CompanyAddress, PostAddress, RegAddress, ConsignorAddress, TaxCode, AccountCode,
                       BankName, FinanceTel, Country, Branch, VIPID, IsGroupDamex, BeiDeVIP, SFAEVIPID, ContactID, ContactName, Tel, Fax, Mobile, Address, PostCode,Email, sType) {
            if (sType == "app") {
                objSEWCRequestOperation.fnAppSelectCustomerLoad(AccountID, CustomerID, CompanyName, SubOffice, Province, City, CustomerType, CompanyAddress, PostAddress, RegAddress, ConsignorAddress, TaxCode, AccountCode,
                       BankName, FinanceTel, Country, Branch, VIPID, IsGroupDamex, BeiDeVIP, SFAEVIPID, ContactID, ContactName, Tel, Fax, Mobile, Address, PostCode, Email);
            } else {
                objSEWCRequestOperation.fnEndUserSelectCustomerLoad(AccountID, CustomerID, CompanyName, SubOffice, Province, City, CustomerType, CompanyAddress, PostAddress, RegAddress, ConsignorAddress, TaxCode, AccountCode,
                       BankName, FinanceTel, Country, Branch, VIPID, IsGroupDamex, BeiDeVIP, SFAEVIPID, ContactID, ContactName, Tel, Fax, Mobile, Address, PostCode, Email);
            }
        }
    });

    objSEWCRequestOperation.fnMLFBNoAutoLoad();
    //$(function ($) {
    //    objSEWCRequestOperation.fnAppSelectCustomerLoad();
    //    objSEWCRequestOperation.fnEndUserSelectCustomerLoad();
    //});
});