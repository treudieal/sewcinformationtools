String.prototype.trim = function () { 
    var tmp = this;
    if (tmp == "") {
        return "";
    }
    tmp = encodeURIComponent(tmp.replace(/(^\s*)|(\s*$)/g, ""));
    return tmp;
}

String.prototype.VerifyEmail = function () {
    var search_str = /^[\w\-\.]+@[\w\-\.]+(\.\w+)+$/;
    return search_str.test(this);
}

String.prototype.VerifyMobile = function () {
    var search_str = /^(?:13\d|15\d|18\d)\d{5}(\d{3}|\*{3})$/;
    return search_str.test(this);
}

String.prototype.getGuidID = function () {
    var guid = "";
    for (var i = 1; i <= 32; i++) {
        var n = Math.floor(Math.random() * 16.0).toString(16);
        guid += n;
        if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
            guid += "";
    }
    return guid;
}

String.prototype.getGuid = function () {
    var guid = "";
    for (var i = 1; i <= 32; i++) {
        var n = Math.floor(Math.random() * 16.0).toString(16);
        guid += n;
        if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
            guid += "-";
    }
    return guid;
}
String.prototype.VerifyTel = function () {
    var search_str = /^((0\d{2,3})-)(\d{7,8})(-(\d{2,4}))?$/;
    return search_str.test(this);
}
String.prototype.VerifyPostCode = function () {
    var search_str = /^[0-9]{6}$/;
    return search_str.test(this);
}

String.prototype.GetLenght = function () {
    ///<summary>获得字符串实际长度，中文2，英文1</summary>
    ///<param name="str">要获得长度的字符串</param>
    var realLength = 0, len = this.length, charCode = -1;
    for (var i = 0; i < len; i++) {
        charCode = this.charCodeAt(i);
        if (charCode >= 0 && charCode <= 128) realLength += 1;
        else realLength += 2;
    }
    return realLength;
}

String.prototype.checkPassword = function () {
    var ls = 0;
    if (pass.match(/([a-z])+/)) {
        ls++;
    }
    if (pass.match(/([0-9])+/)) {
        ls++;
    }
    if (pass.match(/([A-Z])+/)) {
        ls++;
    }
    if (pass.match(/[^a-zA-Z0-9]+/)) {
        ls++;
    }
    return ls
}

Date.prototype.Format = function (fmt) { 
    var o = {
        "M+": this.getMonth() + 1,                 //月份   
        "d+": this.getDate(),                    //日   
        "h+": this.getHours(),                   //小时   
        "m+": this.getMinutes(),                 //分   
        "s+": this.getSeconds(),                 //秒   
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度   
        "S": this.getMilliseconds()             //毫秒   
    };
    if (/(y+)/.test(fmt))
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt))
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}

String.prototype.VerifyNumber= function () {
    if (!this) return false;
    var strP = /^\d+(\.\d+)?$/;
    if (!strP.test(this)) return false;
    try {
        if (parseFloat(this) != this) return false;
    }
    catch (ex) {
        return false;
    }
    return true;
}
function parseMSJSONToDateTime(data, strformat) {
    try {
        //1363046400
        //1384582396
        var sdate=data.match(/\d+/)[0];
        sdate = sdate.substring(0, sdate.length - 3);
        var inttick = parseInt(sdate);
        var d = $.datetime.format(strformat, inttick);
        return d;
    }
    catch (e) { return null; }
}
String.prototype.replaceAll = function(reallyDo, replaceWith, ignoreCase) { 
    if (!RegExp.prototype.isPrototypeOf(reallyDo)) { 
        return this.replace(new RegExp(reallyDo, (ignoreCase ? "gi": "g")), replaceWith); 
    } else { 
        return this.replace(reallyDo, replaceWith); 
    } 
} 