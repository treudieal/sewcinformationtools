var exports = this;
jQuery(function ($) {
    var objUser;
    exports.MasterHeader = Controller.create({
        elements: {
            "#lnkMyInformation": "lnkMyInformation",
            "#divMaster-User": "divMasterUser"
        },
        events: {
            "click #lnkMyInformation": "fnMyInfo"
        },
        fnMyInfo: function () {
            var divUser = "<div id='divMaster-User' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true' style='width: 620px;'><div class='modal-header'><button type='button' class='close' data-dismiss='modal' aria-hidden='true'></button><h3 id='myModalLabel'><span data-icon='&#x0026;' style='font-size: 18px;'></span>我的信息</h3></div><div class='modal-body'></div></div>";
            $(divUser).modal({
                keyboard: false,
                Clickhide: true,
                remote: '../../User/MyInformation.aspx'
            });
        }
    });
    var objMasterHeader = new MasterHeader({ el: $("#divHeader") });
});
