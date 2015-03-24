var url;
var zhanbh;
var fzxsl;
var gid;
$(function () {

    var guid = $("#h_guid").val();
    $("#dlstImages").find("img").each(function (obj) {
        var ImgSrc = this.src;
        ImgSrc = "/UpImages/" + guid + ImgSrc.substring(ImgSrc.lastIndexOf('/'));
        $(this).attr("src", ImgSrc);
    });

    urlinfo = window.location.href; //获取当前页面的url 
    len = urlinfo.length; //获取url的长度 
    offset = urlinfo.indexOf("?"); //设置参数字符串开始的位置 
    if (offset < 0) {
        //        $("#ZhuanMc,#XiangXiDz,#Longtude,#Latitude,#YeZhuDw,#LianXiR,#LianXiDh,#BoxCounts,#CreateDT,#TouYun_Sj").val("");
        //        //清空file文本框
        //        if (/MSIE/.test(navigator.userAgent)) {
        //            $('#picfile').replaceWith($('#picfile').clone(true));
        //        } else {
        //            $('#picfile').val('');
        //        }
        url = "/WebService/ChargStationService.ashx?action=addstation";
    }
    else {

        newsidinfo = urlinfo.substr(offset, len)//取出参数字符串 这里会获得类似“id=1”这样的字符串 
        newsids = newsidinfo.split("&"); //对获得的参数字符串按照“=”进行分割 
        newsid0 = newsids[0]; //得到参数值 
        newsid1 = newsids[1];
        newsid2 = newsids[2];
        zhanbh = newsid0.split('=')[1];
        fzxsl = newsid1.split('=')[1];
        gid = newsid2.split('=')[1];
        $("#dlstImages").find("img").each(function (obj) {
            var ImgSrc = this.src;
            ImgSrc = "/UpImages/" + gid + ImgSrc.substring(ImgSrc.lastIndexOf('/'));
            $(this).attr("src", ImgSrc);
        });
        if (zhanbh != null && zhanbh != "") {
            var zhanmc = "";
            var zhanjc = "";
            var xxdz = "";
            var jd = "";
            var wd = "";
            var yzdw = "";
            var yzlxr = "";
            var yzlxdh = "";
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
                    yzlxr = val.rows[0].LianXiR;
                    yzlxdh = val.rows[0].LianXiDh;
                    jzsj = val.rows[0].JianZhan_Sj;
                    tysj = val.rows[0].TouYun_Sj;
                }
            });
            $("#ZhuanMc").val(zhanmc);
            $("#zhanjc").val(zhanjc);
            $("#XiangXiDz").val(xxdz);
            $("#Longtude").val(jd);
            $("#Latitude").val(wd);
            $("#YeZhuDw").val(yzdw);
            $("#LianXiR").val(yzlxr);
            $("#LianXiDh").val(yzlxdh);
            $("#BoxCounts").val(fzxsl);
            if (jzsj != null) {
                var CreateDT = eval("new " + (jzsj).split('/')[1]).Format("yyyy-MM-dd");
                $("#JianZhan_SJ").val(CreateDT);
            } else {
                $("#JianZhan_SJ").val("");
            }
            if (tysj != null) {
                var TouYun_Sj = eval("new " + (tysj).split('/')[1]).Format("yyyy-MM-dd");
                $("#TouYun_Sj").val(TouYun_Sj);
            } else {
                $("#TouYun_Sj").val("");
            }
            url = "/webservice/ChargStationService.ashx?action=editstation1&zhanbh=" + zhanbh;
        }

    }

});

//验证联系电话格式是否正确
function DHchange() {
    var phone = /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/;
    var mobile = /^(13|14|15|18)\d{9}$/;
    var LianXiDh = $("#LianXiDh").val();
    if (LianXiDh != "") {
        if (LianXiDh.match(phone) == null && LianXiDh.match(mobile) == null) {
            $.messager.show({ title: '提示', msg: '联系电话不正确，请输入正确的手机号码和电话号码，电话号码格式：0551-88888888' });
            return;
        }
    }
}

//保存充电站方法
var url;
function save() {
    var phone = /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/;
    var mobile = /^(13|14|15|18)\d{9}$/;
    var LianXiDh = $("#LianXiDh").val();
    if (LianXiDh != "") {
        if (LianXiDh.match(phone) == null && LianXiDh.match(mobile) == null) {
          //$.messager.show({ title: '提示', msg: '联系电话不正确，请输入正确的手机号码和电话号码，电话号码格式：0551-88888888' });
            $.messager.alert('提示', '联系电话不正确，请输入正确的手机号码或电话号码！');
            return false;
        }
    }
    var jd = $("#Longtude").val();
    if (jd > 117.9 || jd < 117.1) {
        $.messager.alert('提示', '经度应处于117.1-117.9度之间！');
        return false;
    }
    var wd = $("#Latitude").val();
    if (wd>31.9||wd<31.1) {
        $.messager.alert('提示', '纬度应处于31.1-31.9度之间！');
        return false;
    }
    var boxcounts = $("#BoxCounts").val();
    if (boxcounts == "") {
        $.messager.alert('提示', '请选择分支箱数量！');
        return false;
    }
    var jzsj = $("#JianZhan_SJ").val();
    if (jzsj == "") {
        $.messager.alert('提示', '请选择建站时间！');
        return false;
    }
    var tysj = $("#TouYun_Sj").val();
    if (tysj == "") {
        $.messager.alert('提示', '请选择投运时间！');
        return false;
    }
    return $("#fm").form('validate');
    

}

//返回上一步
function back() {
    parent.$("#contentFrame").attr("src", "/pages/ChargPileLedger/ChargStation.htm");
}


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

//图片删除方法
//function delImg(i) {
//    var imgSrc = $(obj).parent().find("img").attr("src");
//    $.ajax({
//        url: "/WebService/ChargStationService.ashx",
//        type: "post",
//        async: false,
//        data: { action: 'delimage', imgSrc: imgSrc },
//        datatype: "json",
//        success: function (result) {
//            var result = eval('(' + result + ')');
//            if (result.success) {
//                $.messager.alert('提示', result.msg);
//            } else {
//                $.messager.alert("提示", result.msg);
//            }
//        }
//    });
//}

function delImg(i) {
    var imgSrc = $("#img_" + i).attr("src");
    imgSrc = imgSrc.substring(5);
    $.ajax({
        url: "/WebService/ChargStationService.ashx",
        type: "post",
        async: false,
        data: { action: 'delimage', imgSrc: imgSrc },
        datatype: "json",
        success: function (result) {
            var result = eval('(' + result + ')');
            if (result.success) {
                $("#img_" + i).remove();
                $("#bj_" + i).remove();
                $.messager.alert('提示', result.msg);
            } else {
                $.messager.alert("提示", result.msg);
            }
        }
    });
}