var exports = this;
jQuery(function ($) {
    exports.UserOperation = Controller.create({
        elements: {
            ".clstxtEmail": "txtEmail",
            ".clstxtPassword": "txtPassword",
            ".clstxtEnUserName": "txtEnUserName",
            ".clstxtCnUserName": "txtCnUserName",
            ".clstxtTel": "txtTel",
            ".clstxtFax": "txtFax",
            ".clscboRegion": "cboRegion",
            ".clscboServiceProvider": "cboServiceProvider",
            ".clschkEngineer": "chkEngineer",
            ".clscboDistributors": "cboDistributors",
            ".clsDdlDefaultpage": "DdlDefaultpage",
            ".clstxtStockNo": "txtStockNo",
            ".clschkSfaeSpareSalesBU": "chkSfaeSpareSalesBU",
            ".clschkSIASRepairCategoryType": "chkSIASRepairCategoryType",
            ".clschkListModuleLimited": "chkListModuleLimited",
            "#btnSave": "btnSave"
        },
        events: {
            "click #btnSave": "fnDBSave"
        },
        fnDBSave: function () {
            var Email = encodeURI(this.txtEmail.val());
            var Password = encodeURI(this.txtPassword.val());
            var EnUserName = encodeURI(this.txtEnUserName.val());
            var CnUserName = encodeURI(this.txtCnUserName.val());
            var Tel = encodeURI(this.txtTel.val());
            var Fax = encodeURI(this.txtFax.val());
            var Region = encodeURI(this.cboRegion.val());
            var ServiceProvider = encodeURI(this.cboServiceProvider.val());
            var IsEngineer = encodeURI(this.chkEngineer.attr("checked"));
            var Distributors = encodeURI(this.cboDistributors.val());
            var DdlDefaultpage = encodeURI(this.DdlDefaultpage.val());
            var StockNo = encodeURI(this.txtStockNo.val());
            var IsSfaeSpareSalesBU = encodeURI(this.chkSfaeSpareSalesBU.attr("checked"));
            var IsSIASRepairCategoryType = encodeURI(this.chkSIASRepairCategoryType.attr("checked"));
            var IsListModuleLimited = encodeURI(this.chkListModuleLimited.attr("checked"));
            debugger;
            var getModuleLimited = "";

            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/User/User-operation.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "Email=" + Email + "&Password=" + Password + "&EnUserName=" + EnUserName + "&CnUserName=" + CnUserName + "&Tel=" + Tel + "&Fax=" + Fax + "&Region=" + Region + "&ServiceProvider=" + ServiceProvider + "&IsEngineer=" + IsEngineer + "&Distributors=" + Distributors + "&DdlDefaultpage=" + DdlDefaultpage + "&StockNo=" + StockNo + "&IsSfaeSpareSalesBU=" + IsSfaeSpareSalesBU + "&IsSIASRepairCategoryType=" + IsSIASRepairCategoryType + "&IsListModuleLimited=" + IsListModuleLimited + "&OpType=" + this.OpType + "&OpID=" + this.KeyID,
                success: function (msg) {
                    //debugger;
                    switch (msg) {
                        case "0":
                            alert("Save Successfully!");
                            $("#myModal").modal('hide');
                            grid.trigger("reloadGrid");
                            break;
                        case "1":
                            alert("Save Error!");
                            break;
                        case "2":
                            alert("Email is Null!");
                            break;
                    }
                }
            });
        }
    })
});
var objUserOperation = new UserOperation({ el: $("#tblOperation"), KeyID: "", OpType: "" });
$(function () {
    //debugger;
    var ps = $(".clshidPassword").val();
    $(".clstxtPassword").val(ps);
    $(".clstxtPassword1").val(ps);
})