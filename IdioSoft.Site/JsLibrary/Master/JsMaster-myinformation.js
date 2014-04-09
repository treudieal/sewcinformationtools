var exports = this;
jQuery(function ($) {
    exports.MyInformation = Controller.create({
        elements: {
            ".clstxtEmail": "txtEmail",
            ".clstxtPassword": "txtPassword",
            ".clstxtEnUserName": "txtEnUserName",
            ".clstxtCnUserName": "txtCnUserName",
            ".clstxtTel": "txtTel",
            ".clstxtFax": "txtFax",
            ".clscboRegion": "cboRegion",
            ".cboServiceProvider": "cboServiceProvider",
            ".clstxtSetPage": "txtSetPage",
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
            var SetPage = encodeURI(this.txtSetPage.val());
            $.ajax({
                type: "POST",
                url: "../../InterfaceLibrary/User/User-operation.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "Email=" + Email + "&Password=" + Password + "&EnUserName=" + EnUserName + "&CnUserName=" + CnUserName + "&Fax=" + Fax + "&Tel=" + Tel + "&Region=" + Region + "&SetPage=" + SetPage + "&ServiceProvider=" + ServiceProvider + "&OpType=Myinformation",
                success: function (msg) {
                    //debugger;
                    switch (msg) {
                        case "0":
                            alert("保存成功!");
                            $("#divMaster-User").modal('hide');
                            break;
                        case "1":
                            alert("保存出错!");
                            break;
                        case "2":
                            alert("邮箱不能为空!");
                            break;
                    }
                }
            });
        }
    });
    var objMyInformation = new MyInformation({ el: $("#tblOperation") });
});

$(function () {
    //debugger;
    var ps = $(".clshidPassword").val();
    $(".clstxtPassword").val(ps);
    $(".clstxtPassword1").val(ps);
})