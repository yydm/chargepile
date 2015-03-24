var zhanbh;
$(function () {
    zhanbh = getQueryString("zhanbh");
    var zhanmc = "";
    var zhanjc = "";
    var xxdz = "";
    var jd = "";
    var wd = "";
    var yzdw = "";
    var lxr = "";
    var lxdh = "";
    var jzsj = "";
    var tysj = "";
    $.ajax({
        url: "/WebService/ChargStationService.ashx",
        type: "post",
        async: false,
        data: { action: 'getstationbyid', zhanbh: zhanbh },
        dataType: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            zhanmc = val.rows[0].ZhuanMc;
            zhanjc = val.rows[0].Zhan_Jc;
            xxdz = val.rows[0].XiangXiDz;
            jd = val.rows[0].Longtude;
            wd = val.rows[0].Latitude;
            yzdw = val.rows[0].YeZhuDw;
            lxr = val.rows[0].LianXiR;
            lxdh = val.rows[0].LianXiDh;
            jzsj = val.rows[0].CreateDT;
            tysj = val.rows[0].TouYun_Sj;
        }
    });
    $("#zhanmc").val(zhanmc);
    $("#title").html(zhanmc);
    $("#zhanjc").val(zhanjc);
    $("#xxdz").val(xxdz);
    $("#jd").val(jd + "°");
    $("#wd").val(wd + "°");
    $("#yzdw").val(yzdw);
    $("#lxr").val(lxr);
    $("#lxdh").val(lxdh);
    var CreateDT = eval("new " + (jzsj).split('/')[1]).Format("yyyy-MM-dd");
    $("#jzsj").val(CreateDT);
    var TouYun_Sj = eval("new " + (tysj).split('/')[1]).Format("yyyy-MM-dd");
    $("#tysj").val(TouYun_Sj);

});

//日期时间格式化方法，可以格式化年、月、日、时、分、秒、周
Date.prototype.Format = function (formatStr) {
    var Week = ['日', '一', '二', '三', '四', '五', '六'];
    return formatStr.replace(/yyyy|YYYY/, this.getFullYear())
 	             .replace(/yy|YY/, (this.getYear() % 100) > 9 ? (this.getYear() % 100).toString() : '0' + (this.getYear() % 100))
 	             .replace(/MM/, (this.getMonth() + 1) > 9 ? (this.getMonth() + 1).toString() : '0' + (this.getMonth() + 1)).replace(/M/g, (this.getMonth() + 1))
 	             .replace(/w|W/g, Week[this.getDay()])
 	             .replace(/dd|DD/, this.getDate() > 9 ? this.getDate().toString() : '0' + this.getDate()).replace(/d|D/g, this.getDate())
 	             .replace(/HH|hh/g, this.getHours() > 9 ? this.getHours().toString() : '0' + this.getHours()).replace(/H|h/g, this.getHours())
 	             .replace(/mm/g, this.getMinutes() > 9 ? this.getMinutes().toString() : '0' + this.getMinutes()).replace(/m/g, this.getMinutes())
 	             .replace(/ss/g, this.getSeconds() > 9 ? this.getSeconds().toString() : '0' + this.getSeconds()).replace(/S|s/g, this.getSeconds());
};

/*
* 获取url参数值
*/
function getQueryString(name) {
    var url = location.href;
    var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
    var paraObj = {};
    for (var i = 0; j = paraString[i]; i++) {
        paraObj[j.substring(0, j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=") + 1, j.length);
    }
    var returnValue = paraObj[name.toLowerCase()];
    if (typeof (returnValue) == "undefined") {
        return "";
    } else {
        return returnValue;
    }
}