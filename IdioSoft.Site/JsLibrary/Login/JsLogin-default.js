var exports = this;
jQuery(function ($) {
    var myModalError = $("<div id='myModalError' class='modal warning bg-color-blu hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'><div class='modal-body'><p class='pErrorTitle'></p></div><div class='modal-footer'><button class='btn btn-large' data-dismiss='modal'>Close</button></div></div>");
    exports.UserLogin = Controller.create({
        elements: {
            "#txtLoginName": "txtLoginName",
            "#txtLoginPwd": "txtLoginPwd",
            "#btnLogin": "btnLogin"
        },
        events: {
            "click #btnLogin": "fnLogin",
            "keyup #txtLoginPwd": "fnLoginEnter"
        },
        fnLoginEnter:function(e){
            if (event.keyCode == 13) {
                this.fnLogin(e);
            }
        },
        fnLogin: function (e) {
            var loginname =encodeURI(this.txtLoginName.val().trim());
            var loginpwd = encodeURI(this.txtLoginPwd.val().trim());
            if (loginname == "" || loginpwd == "") {
                myModalError.find(".pErrorTitle").text("登录名与密码不能为空! The login name and password can not be empty!");
                $(myModalError).modal({
                    keyboard: false,
                    Clickhide: true
                });
                return false;
            }
            var self = this;
            $(e.target).attr("disabled", "disabled");

            $.ajax({
                type: "POST",
                url: "InterfaceLibrary/Login/Login.ashx",
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: "loginname=" + loginname + "&loginpwd=" + loginpwd + "&stype=login",
                success: function (msg) {
                    var json = eval("(" + unescape(msg) + ")");
                    switch (json.loginStatus) {
                        case 0:
                            myModalError.find(".pErrorTitle").text("登录失败！ Login failed!");
                            $(myModalError).modal({
                                keyboard: false,
                                Clickhide: true
                            });
                            break;
                        case 1:
                            if (json.DefaultPage != "") {
                                window.location.href = json.DefaultPage;
                            }
                            else {
                                myModalError.find(".pErrorTitle").text("登录失败,请管理员设置登录默认页！ Login failed!");
                                $(myModalError).modal({
                                    keyboard: false,
                                    Clickhide: true
                                });
                            }
                            break;
                    }
                    $(e.target).removeAttr("disabled");
                }
            });
        }
    });
    var objUserLogin = new UserLogin({ el: $("#divLogin") });
});