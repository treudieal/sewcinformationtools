var exports = this;
jQuery(function ($) {
    var myModal = $("<div id='myModal' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true' style='width: 610px;'><div class='modal-header'><button type='button' class='close' data-dismiss='modal' aria-hidden='true'></button><h3 id='myModalLabel'><span data-icon='&#x0026;' style='font-size: 18px;'></span>Select</h3></div><div class='modal-body'></div></div>");
    var myModalError = $("<div id='myModalError' class='modal warning bg-color-blu hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'><div class='modal-body'><p class='pErrorTitle'></p></div><div class='modal-footer'><button class='btn btn-large' data-dismiss='modal'>Close</button></div></div>");
    var selectID = "";
    exports.SelectCustomerAndContactInfo = Controller.create({
        elements: {
            ".clsSelectCustomerAndContactInfo": "clsSelectCustomerAndContactInfo",
            ".clsbtnClose": "btnClose",
            ".clsbtnAddnewCustomer": "btnAddnewCustomer",
            ".clsbtnAddnewContact": "btnAddnewContact",
            ".clsbtnModifyCustomer": "btnModifyCustomer",
            ".clsbtnModifyContact": "btnModifyContact",
            ".clsbtnDelCustomer": "btnDelCustomer",
            ".clsbtnDelContact": "btnDelContact",
            "#list1": "list1",
            "#pager1": "pager1",
            ".clstblCompany": "tblCompany",
            ".clstxtCompanyName": "txtCompanyName",
            ".clstxtCompanyKeyWords": "txtCompanyKeyWords",
            ".clscboProvince": "cboProvince",
            ".clstxtCity": "txtCity",
            ".clstxtCompanyAddress": "txtCompanyAddress",
            ".clstxtPostCode": "txtPostCode",
            ".clscboCustomerType": "cboCustomerType",
            ".clstxtCustomerID": "txtCustomerID",
            ".clstxtConsignorAddress": "txtConsignorAddress",
            ".clstxtTaxCode": "txtTaxCode",
            ".clstxtAccountCode": "txtAccountCode",
            ".clstxtBankName": "txtBankName",
            ".clstxtRegAddress": "txtRegAddress",
            ".clstxtFinanceTel": "txtFinanceTel",
            ".clstxtCountry": "txtCountry",
            ".clscboBranch": "cboBranch",
            ".clstxtPostAddress": "txtPostAddress",
            ".clstxtVipID": "txtVipID",
            ".clstxtVipENCompanyName": "txtVipENCompanyName",
            ".clstxtVipCNCompanyName": "txtVipCNCompanyName",
            ".clscboIsGroupDamex": "cboIsGroupDamex",
            ".clstxtSubOffice": "txtSubOffice",
            ".clscboBeiDeVIP": "cboBeiDeVIP",
            ".clsbtnSaveCompany": "btnSaveCompany",
            ".clsbtnCloseCompany": "btnCloseCompany",
            ".clstblContact": "tblContact",
            ".clstxtContactName": "txtContactName",
            ".clstxtTel": "txtTel",
            ".clstxtFax": "txtFax",
            ".clstxtMobile": "txtMobile",
            ".clstxtAddress": "txtAddress",
            ".clstxtContractPostCode": "txtContractPostCode",
            ".clstxtEmail": "txtEmail",
            ".clsbtnSaveContact": "btnSaveContact",
            ".clsbtnCloseContact": "btnCloseContact",
            "#divDataGrid": "divDataGrid",
            "#divCompanyInfo": "divCompanyInfo",
            "#divContactInfo": "divContactInfo",
            "#txtSearchContactName": "txtSearchContactName"
        },
        events: {
            //"click .clsSelectCustomerAndContactInfo":"fnSelect",
            "click .clsbtnClose": "fnClose",
            "click .clsbtnAddnewCustomer": "fnAddnewCustomer",
            "click .clsbtnModifyCustomer": "fnModifyCustomer",
            "click .clsbtnDelCustomer": "fnDelCustomer",
            "click .clsbtnAddnewContact": "fnAddnewContact",
            "click .clsbtnModifyContact": "fnModifyContact",
            "click .clsbtnDelContact": "fnDelContact",
            "click .clsbtnSaveCompany": "fnSaveCompany",
            "click .clsbtnSaveContact": "fnSaveContact",
            "click .clsbtnCloseCompany": "fnHide",
            "click .clsbtnCloseContact": "fnHide",
            "click #SelectCustomerAndContactInfo": "fnSelectCustomerAndContactInfo",
            "keydown #txtSearchContactName": "fnGridLoad"
        },
        fnGridLoad: function () {
            if (event.keyCode == 13) {
                fngridLoad(this.txtSearchContactName.val());
            }
        },
        fnAddnewCustomer: function () {
            $("#myModal").hide();
            $("#myModalError").hide();
            $("#divDataGrid").hide();

            $(".clstblCompany").show();
            $(".clstblContact").hide();

            $("#SelectCustomerAndContactInfo").removeClass("active");
            $("#EditCustomerAndContactInfo").addClass("active");

            EditCustomerType = "addnew";
        },
        fnModifyCustomer: function () {
            //debugger;
            $("#myModal").hide();
            $("#myModalError").hide();
            $("#divDataGrid").hide();

            $(".clstblCompany").show();
            $(".clstblContact").hide();

            $("#SelectCustomerAndContactInfo").removeClass("active");
            $("#EditCustomerAndContactInfo").addClass("active");

            EditCustomerType = "modify";

            this.txtCompanyName.val(CompanyName);
            this.cboProvince.val(Province);
            this.txtCity.val(City);
            this.txtCompanyAddress.val(CompanyAddress);
            this.txtPostCode.val(PostCode);
            this.cboCustomerType.val(CustomerType);
            this.txtCustomerID.val(CustomerID);
            this.txtConsignorAddress.val(ConsignorAddress);
            this.txtTaxCode.val(TaxCode);
            this.txtAccountCode.val(AccountCode);
            this.txtBankName.val(BankName);
            this.txtRegAddress.val(RegAddress);
            this.txtFinanceTel.val(FinanceTel);
            this.txtCountry.val(Country);
            this.cboBranch.val(Branch);
            this.txtPostAddress.val(PostAddress);
            this.txtVipID.val(VIPID);
            var varIsGroupDamex = "0";
            if (IsGroupDamex.toLowerCase() == "true") {
                varIsGroupDamex = "1";
            }
            this.cboIsGroupDamex.val(varIsGroupDamex);
            this.txtSubOffice.val(SubOffice);
            this.cboBeiDeVIP.val(BeiDeVIP);
        },
        fnClose: function () {
            //debugger;
            //parent.$.fn.colorbox.close();
            //$("#cboxClose").click();
            window.close();
        },
        fnSaveCompanyProcess: function (AccountID, OperationType) {
            debugger;
            var vCustomerID = encodeURI(this.txtCustomerID.val());
            var vCompanyName = encodeURI(this.txtCompanyName.val());
            var vSubOffice = encodeURI(this.txtSubOffice.val());
            var vProvince = encodeURI(this.cboProvince.val());
            var vCity = encodeURI(this.txtCity.val());
            var vCustomerType = encodeURI(this.cboCustomerType.val());
            var vCompanyAddress = encodeURI(this.txtCompanyAddress.val());
            var vPostAddress = encodeURI(this.txtPostAddress.val());
            var vRegAddress = encodeURI(this.txtRegAddress.val());
            var vConsignorAddress = encodeURI(this.txtConsignorAddress.val());
            var vTaxCode = encodeURI(this.txtTaxCode.val());
            var vAccountCode = encodeURI(this.txtAccountCode.val());
            var vBankName = encodeURI(this.txtBankName.val());
            var vPostCode = encodeURI(this.txtPostCode.val());
            var vFinanceTel = encodeURI(this.txtFinanceTel.val());
            var vCountry = encodeURI(this.txtCountry.val());
            var vBranch = encodeURI(this.cboBranch.val());
            var vVipID = encodeURI(this.txtVipID.val());
            var vVIPCompanyENName = encodeURI(this.txtVipENCompanyName.val());
            var vVIPCompanyCNName = encodeURI(this.txtVipCNCompanyName.val());
            var vIsGroupDamex = encodeURI(this.cboIsGroupDamex.val());
            var vBeiDeVIP = encodeURI(this.cboBeiDeVIP.val());
            var vCompanyKeyWords = encodeURI(this.txtCompanyKeyWords.val());

            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/Request/EditCompanyOperation.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "AccountID=" + AccountID + "&OperationType=" + OperationType + "&CompanyKeyWords=" + vCompanyKeyWords + "&BeiDeVIP=" + vBeiDeVIP + "&IsGroupDamex=" + vIsGroupDamex + "&VIPCompanyCNName=" + vVIPCompanyCNName + "&VIPCompanyENName=" + vVIPCompanyENName + "&VipID=" + vVipID + "&Branch=" + vBranch + "&Country=" + vCountry + "&FinanceTel=" + vFinanceTel + "&PostCode=" + vPostCode + "&BankName=" + vBankName + "&AccountCode=" + vAccountCode + "&TaxCode=" + vTaxCode + "&ConsignorAddress=" + vConsignorAddress + "&RegAddress=" + vRegAddress + "&PostAddress=" + vPostAddress + "&CompanyAddress=" + vCompanyAddress + "&CustomerType=" + vCustomerType + "&CustomerID=" + vCustomerID + "&CompanyName=" + vCompanyName + "&SubOffice=" + vSubOffice + "&Province=" + vProvince + "&City=" + vCity + "",
                success: function (msg) {
                    switch (msg) {
                        case "0":
                            alert("Save Successfully!");
                            //parent.$.fn.colorbox.close();
                            $(".clstblCompany").hide();
                            $(".clstblContact").show();
                            window.close();
                            //$("#cboxClose").click();
                            break;
                        case "1":
                            alert("Save Error!");
                            break;
                    }
                }
            });
        },
        fnSaveCompany: function () {
            var thisSaveCompany = this;
            if (EditCustomerType == "addnew") {
                thisSaveCompany.fnSaveCompanyProcess("", EditCustomerType);
            } else {
                thisSaveCompany.fnSaveCompanyProcess(AccountID, EditCustomerType);
            }
        },
        fnDelCustomer: function () {
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/Request/EditCompanyOperation.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "AccountID=" + AccountID + "&OperationType=delete",
                success: function (msg) {
                    switch (msg) {
                        case "0":
                            alert("Delete Successfully!");
                            //parent.$.fn.colorbox.close();
                            window.close();
                            //$("#cboxClose").click();
                            break;
                        case "1":
                            alert("Delete Error!");
                            break;
                    }
                }
            });
        },

        fnAddnewContact: function () {
            $("#myModal").hide();
            $("#myModalError").hide();
            $("#divDataGrid").hide();

            $(".clstblCompany").hide();
            $(".clstblContact").show();

            $("#SelectCustomerAndContactInfo").removeClass("active");
            $("#EditCustomerAndContactInfo").addClass("active");

            EditContactType = "addnew";
        },
        fnModifyContact: function () {
            $("#myModal").hide();
            $("#myModalError").hide();
            $("#divDataGrid").hide();

            $(".clstblCompany").hide();
            $(".clstblContact").show();

            $("#SelectCustomerAndContactInfo").removeClass("active");
            $("#EditCustomerAndContactInfo").addClass("active");

            EditContactType = "modify";

            this.txtContactName.val(ContactName);
            this.txtTel.val(Tel);
            this.txtMobile.val(Mobile);
            this.txtFax.val(Fax);
            this.txtAddress.val(Address);
            this.txtContractPostCode.val(PostCode)
            this.txtEmail.val(Email)
        },
        fnSaveContactProcess: function (ContactID, OperationType) {
            var vAccountID = AccountID;
            var vContactName = encodeURI(this.txtContactName.val());
            var vTel = encodeURI(this.txtTel.val());
            var vMobile = encodeURI(this.txtMobile.val());
            var vFax = encodeURI(this.txtFax.val());
            var vAddress = encodeURI(this.txtAddress.val());
            var vPostCode = encodeURI(this.txtContractPostCode.val());
            var vEmail = encodeURI(this.txtEmail.val());

            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Request/EditContactOperation.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "ContactID=" + ContactID + "&OperationType=" + OperationType + "&Email=" + Email + "&PostCode=" + PostCode + "&AccountID=" + AccountID + "&ContactName=" + ContactName + "&Tel=" + Tel + "&Mobile=" + Mobile + "&Fax=" + Fax + "&Address=" + Address + "",
                success: function (msg) {
                    switch (msg) {
                        case "0":
                            alert("Save Successfully!");
                            //parent.$.fn.colorbox.close();
                            window.close();
                            //$("#cboxClose").click();
                            break;
                        case "1":
                            alert("Save Error!");
                            break;
                    }
                }
            });
        },
        fnSaveContact: function () {
            var thisSaveContact = this;
            if (EditContactType == "addnew") {
                thisSaveContact.fnSaveContactProcess("", EditContactType);
            } else {
                thisSaveContact.fnSaveContactProcess(ContactID, EditContactType);
            }
        },
        fnDelContact: function () {
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/SEWC/Request/EditContactOperation.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "ContactID=" + ContactID + "&OperationType=delete",
                success: function (msg) {
                    switch (msg) {
                        case "0":
                            alert("Delete Successfully!");
                            //parent.$.fn.colorbox.close();
                            window.close();
                            //$("#cboxClose").click();
                            break;
                        case "1":
                            alert("Delete Error!");
                            break;
                    }
                }
            });
        },

        fnHide: function () {
            $("#myModal").show();
            $("#myModalError").show();
            $("#list1").show();
            $("#pager1").show();

            $(".clstblCompany").hide();
            $(".clstblContact").hide();
        },

        fnSelectCustomerAndContactInfo: function () {
            //debugger;
            $("#myModal").show();
            $("#myModalError").show();
            $("#divDataGrid").show();

            $(".clstblCompany").hide();
            $(".clstblContact").hide();

            $("#SelectCustomerAndContactInfo").addClass("active");
            $("#EditCustomerAndContactInfo").removeClass("active");

            EditCustomerType = "";
        },

        fnNavSelectItem: function (obj) {
            $(navToolbar).find("li").each(function (index) {
                $(this).removeClass("active");
            });
            $(obj.target).parent().addClass("active");
        }
    });
    var objSelectCustomerAndContactInfo = new SelectCustomerAndContactInfo({ el: $("#divMain"), KeyID: "" });
});

datePick = function (elem) {
    jQuery(elem).datepicker({
        dateFormat: 'yy-mm-dd',
        changeYear: true,
        changeMonth: true,
        onSelect: function (dateText, inst) {
            setTimeout(function () {
                $('#list1')[0].triggerToolbar();
            }, 50);
        }
    });
}
var EditCustomerType = "addnew";
var EditContactType = "addnew";

//客户信息
var AccountID = "";
var CustomerID = "";
var CompanyName = "";
var SubOffice = "";
var Province = "";
var City = "";
var CustomerType = "";
var CompanyAddress = "";
var PostAddress = "";
var RegAddress = "";
var ConsignorAddress = "";
var TaxCode = "";
var AccountCode = "";
var BankName = "";
var FinanceTel = "";
var Country = "";
var Branch = "";
var VIPID = "";
var IsGroupDamex = "0";
var BeiDeVIP = "";
var SFAEVIPID = "";

//联系人信息
var ContactID = "";
var ContactName = "";
var Tel = "";
var Mobile = "";
var Fax = "";
var Address = "";
var PostCode = "";
var Email = "";
var grid;
function fngridLoad(ps) {
    //debugger;
    if (grid != null) {
        grid.GridUnload();
    }
    var url = "../../InterfaceLibrary/SEWC/Request/SelectCustomerAndContactInfo.ashx";
    if (ps != null && ps != "") {
        url = url + "?contactname=" + encodeURI(ps);
    }
    jQuery("#list1").jqGrid({
        url: url,
        datatype: "json",
        mtype: 'Post',
        colNames: ['ID', 'CompanyName', 'VIPID', 'CustomerID', 'SubOffice', 'Province', 'City', 'CustomerType', 'CompanyAddress', 'PostAddress', 'RegAddress', 'ConsignorAddress', 'TaxCode', 'AccountCode', 'BankName', 'PostCode', 'FinanceTel', 'Country', 'Branch', 'CreateDate'],
        colModel: [
            { name: 'ID', index: 'ID', hidden: true, align: 'left', search: false, frozen: true },
            { name: 'CompanyName', index: 'CompanyName', width: 200, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
            { name: 'VIPID', index: 'VIPID', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
            { name: 'CustomerID', index: 'CustomerID', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
            { name: 'SubOffice', index: 'SubOffice', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] }, frozen: true },
            { name: 'Province', index: 'Province', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] }, frozen: true },
            { name: 'City', index: 'City', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] }, frozen: true },
            { name: 'CustomerType', index: 'CustomerType', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
            { name: 'CompanyAddress', index: 'CompanyAddress', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
            { name: 'PostAddress', index: 'PostAddress', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
            { name: 'RegAddress', index: 'RegAddress', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
            { name: 'ConsignorAddress', index: 'ConsignorAddress', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
            { name: 'TaxCode', index: 'TaxCode', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
            { name: 'AccountCode', index: 'AccountCode', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
            { name: 'BankName', index: 'BankName', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
            { name: 'PostCode', index: 'PostCode', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
            { name: 'FinanceTel', index: 'FinanceTel', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
            { name: 'Country', index: 'Country', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
            { name: 'Branch', index: 'Branch', width: 100, align: 'left', sorttype: 'string', searchoptions: { sopt: ['cn', 'bw', 'bn', 'eq', 'nc', 'ew', 'en'] } },
            {
                name: 'CreateDate', index: 'CreateDate', width: 100, align: 'left', formatter: 'date',
                formatoptions: {
                    'srcformat': 'ISO8601Long', 'newformat': 'Y/m/d g:i A'
                }, searchoptions: { dataInit: datePick, attr: { title: '选择日期' }, sopt: ['eq', 'ne', 'le', 'lt', 'gt', 'ge'] }
            },
        ],
        shrinkToFit: false,
        autowidth: false,
        jsonReader: {
            page: "page",
            total: "total",
            repeatitems: false
        },
        height: 220,
        width: 840,
        pager: jQuery('#pager1'),
        rowNum: 30,
        rowList: [10, 20, 30],
        sortname: 'CompanyName',
        sortorder: 'asc',
        onSelectRow: function (rowid) {
            $(".clsbtnModifyCustomer").removeAttr("disabled");
            $(".clsbtnDelCustomer").removeAttr("disabled");

            AccountID = $(list1).getCell(rowid, "ID");
            CustomerID = $(list1).getCell(rowid, "CustomerID");
            CompanyName = $(list1).getCell(rowid, "CompanyName");
            SubOffice = $(list1).getCell(rowid, "SubOffice");
            Province = $(list1).getCell(rowid, "Province");
            City = $(list1).getCell(rowid, "City");
            CustomerType = $(list1).getCell(rowid, "CustomerType");
            CompanyAddress = $(list1).getCell(rowid, "CompanyAddress");
            PostAddress = $(list1).getCell(rowid, "PostAddress");
            RegAddress = $(list1).getCell(rowid, "RegAddress");
            ConsignorAddress = $(list1).getCell(rowid, "ConsignorAddress");
            TaxCode = $(list1).getCell(rowid, "TaxCode");
            AccountCode = $(list1).getCell(rowid, "AccountCode");
            BankName = $(list1).getCell(rowid, "BankName");
            FinanceTel = $(list1).getCell(rowid, "FinanceTel");
            Country = $(list1).getCell(rowid, "Country");
            Branch = $(list1).getCell(rowid, "Branch");
            VIPID = $(list1).getCell(rowid, "VIPID");
        },
        ondblClickRow: function (rowid, iRow, iCol, e) {
            if (ContactName != "") {
                return;
            }
            AccountID = $(list1).getCell(iRow, "ID");
            CustomerID = $(list1).getCell(iRow, "CustomerID");
            CompanyName = $(list1).getCell(iRow, "CompanyName");
            SubOffice = $(list1).getCell(iRow, "SubOffice");
            Province = $(list1).getCell(iRow, "Province");
            City = $(list1).getCell(iRow, "City");
            CustomerType = $(list1).getCell(iRow, "CustomerType");
            CompanyAddress = $(list1).getCell(iRow, "CompanyAddress");
            PostAddress = $(list1).getCell(iRow, "PostAddress");
            RegAddress = $(list1).getCell(iRow, "RegAddress");
            ConsignorAddress = $(list1).getCell(iRow, "ConsignorAddress");
            TaxCode = $(list1).getCell(iRow, "TaxCode");
            AccountCode = $(list1).getCell(iRow, "AccountCode");
            BankName = $(list1).getCell(iRow, "BankName");
            FinanceTel = $(list1).getCell(iRow, "FinanceTel");
            Country = $(list1).getCell(iRow, "Country");
            Branch = $(list1).getCell(iRow, "Branch");
            VIPID = $(list1).getCell(iRow, "VIPID");

            //var objCustomerOpReturn = new parent.exports.CustomerOpReturn();
            var objCustomerOpReturn = new window.dialogArguments.CustomerOpReturn();//模式窗体弹出该窗口后，通过此方法执行父窗口的方法
            objCustomerOpReturn.fnSelectCustomerReturn(AccountID, CustomerID, CompanyName, SubOffice, Province, City, CustomerType, CompanyAddress, PostAddress, RegAddress, ConsignorAddress, TaxCode, AccountCode,
                   BankName, FinanceTel, Country, Branch, VIPID, IsGroupDamex, BeiDeVIP, SFAEVIPID, "", "", "", "", "", "", "", "", POperationType);
            //$("#cboxClose").click();
            window.close();
        },
        viewrecords: true,
        caption: 'SelectCustomerAndContactInfo',
        subGrid: true,
        subGridRowExpanded: function (subgrid_id, row_id) {
            var aryRow;
            AccountID = $(list1).getCell(row_id, "ID");
            CustomerID = $(list1).getCell(row_id, "CustomerID");
            CompanyName = $(list1).getCell(row_id, "CompanyName");
            SubOffice = $(list1).getCell(row_id, "SubOffice");
            Province = $(list1).getCell(row_id, "Province");
            City = $(list1).getCell(row_id, "City");
            CustomerType = $(list1).getCell(row_id, "CustomerType");
            CompanyAddress = $(list1).getCell(row_id, "CompanyAddress");
            PostAddress = $(list1).getCell(row_id, "PostAddress");
            RegAddress = $(list1).getCell(row_id, "RegAddress");
            ConsignorAddress = $(list1).getCell(row_id, "ConsignorAddress");
            TaxCode = $(list1).getCell(row_id, "TaxCode");
            AccountCode = $(list1).getCell(row_id, "AccountCode");
            BankName = $(list1).getCell(row_id, "BankName");
            FinanceTel = $(list1).getCell(row_id, "FinanceTel");
            Country = $(list1).getCell(row_id, "Country");
            Branch = $(list1).getCell(row_id, "Branch");
            VIPID = $(list1).getCell(row_id, "VIPID");

            var subgrid_table_id, pager_id;
            subgrid_table_id = subgrid_id + "_t";
            pager_id = "p_" + subgrid_table_id;
            $("#" + subgrid_id).html("<table id='" + subgrid_table_id + "' class='scroll'></table><div id='" + pager_id + "' class='scroll'></div>");

            jQuery("#" + subgrid_table_id).jqGrid({
                url: "../../InterfaceLibrary/SEWC/Request/SelectCustomerAndContactItemInfo.ashx?q=2&id=" + AccountID,
                datatype: "json",
                mtype: 'Post',
                colNames: ['ID', 'ContactName', 'Tel', 'Mobile', 'Fax', 'Address', 'PostCode', 'Email'],
                colModel: [
                    { name: "ID", index: "ID", width: 80, key: true, hidden: true },
                    { name: "ContactName", index: "CreateDate", width: 130 },
                    { name: "Tel", index: "Tel", width: 70, align: "right" },
                    { name: "Mobile", index: "Mobile", width: 70, align: "right" },
                    { name: "Fax", index: "Fax", width: 70, align: "right" },
                    { name: "Address", index: "Address", width: 130 },
                    { name: "PostCode", index: "PostCode", width: 130 },
                    { name: "Email", index: "Email", width: 130 }
                ],
                rowNum: 20,
                pager: pager_id,
                sortname: 'ContactName',
                sortorder: "asc",
                height: '100%',
                onSelectRow: function (rowid) {
                    ContactID = rowid;
                    $(".clsbtnModifyContact").removeAttr("disabled");
                    $(".clsbtnDelContact").removeAttr("disabled");

                    $.ajax({
                        type: "POST",
                        url: "../../InterfaceLibrary/SEWC/Request/getContactInfo.ashx",
                        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                        data: "ContactID=" + rowid + "",
                        success: function (msg) {
                            var aryContact = eval("(" + unescape(msg) + ")");
                            if (aryContact != "") {
                                //debugger;
                                for (var i = 0; i < aryContact.length; i++) {
                                    var vrc = aryContact[i];
                                    var ss = vrc.split('$$$');

                                    ContactName = ss[0];
                                    Tel = ss[1];
                                    Mobile = ss[2];
                                    Fax = ss[3];
                                    Address = ss[4];
                                    PostCode = ss[5];
                                    Email = ss[6];
                                }
                            }
                        }
                    });
                },
                ondblClickRow: function (rowid, iRow, iCol, e) {
                    ContactID = rowid;
                    ContactName = $($(this).find("tr")[iRow]).find("td").eq(1).text();
                    Tel = $($(this).find("tr")[iRow]).find("td").eq(2).text();
                    Mobile = $($(this).find("tr")[iRow]).find("td").eq(3).text();
                    Fax = $($(this).find("tr")[iRow]).find("td").eq(4).text();
                    Address = $($(this).find("tr")[iRow]).find("td").eq(5).text();
                    PostCode = $($(this).find("tr")[iRow]).find("td").eq(6).text();
                    Email = $($(this).find("tr")[iRow]).find("td").eq(7).text();


                    //var objCustomerOpReturn = new parent.exports.CustomerOpReturn();
                    var objCustomerOpReturn = new window.dialogArguments.CustomerOpReturn();//模式窗体弹出该窗口后，通过此方法执行父窗口的方法
                    objCustomerOpReturn.fnSelectCustomerReturn(AccountID, CustomerID, CompanyName, SubOffice, Province, City, CustomerType, CompanyAddress, PostAddress, RegAddress, ConsignorAddress, TaxCode, AccountCode,
                           BankName, FinanceTel, Country, Branch, VIPID, IsGroupDamex, BeiDeVIP, SFAEVIPID, ContactID, ContactName, Tel, Fax, Mobile, Address, PostCode, Email, POperationType);
                
                    //$("#cboxClose").click();
                    window.close();
                }
            });
            jQuery("#" + subgrid_table_id).jqGrid('navGrid', "#" + pager_id, { edit: false, add: false, del: false })
        },
    }).navGrid("#pager1", { edit: false, add: false, del: false,search:false })
    grid = jQuery("#list1").jqGrid('filterToolbar', { searchOperators: true, stringResult: true });
}

fngridLoad("");