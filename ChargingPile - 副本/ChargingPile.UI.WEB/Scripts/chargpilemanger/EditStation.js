var zhanbh;
var url;
$(function () {

    urlinfo = window.location.href; //获取当前页面的url 
    len = urlinfo.length; //获取url的长度 
    offset1 = urlinfo.indexOf("?"); //设置参数字符串开始的位置 
    newsidinfo = urlinfo.substr(offset1, len)//取出参数字符串 这里会获得类似“id=1”这样的字符串 
    newsids = newsidinfo.split("="); //对获得的参数字符串按照“=”进行分割 
    newsid = newsids[1]; //得到参数值 
    zhanbh = newsid;

    var zhanmc = "";
    var xxdz = "";
    var jd = "";
    var wd = "";
    var yzdw = "";
    var yzlxr = "";
    var yzlxdh = "";
    var jzsj = "";
    var tysj = "";
    var zhanjc = "";
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
    $("#d_ZhuanMc").val(zhanmc);
    $("#d_zhanjc").val(zhanjc);
    $("#d_XiangXiDz").val(xxdz);
    $("#d_Longtude").val(jd);
    $("#d_Latitude").val(wd);
    $("#d_YeZhuDw").val(yzdw);
    $("#d_LianXiR").val(yzlxr);
    $("#d_LianXiDh").val(yzlxdh);
    if (jzsj != null) {
        var JianZhan_Sj = eval("new " + (jzsj).split('/')[1]).Format("yyyy-MM-dd");
        $("#d_JianZhan_SJ").val(JianZhan_Sj);
    } else {
        $("#d_JianZhan_SJ").val("");
    }
    if (tysj != null) {
        var TouYun_Sj = eval("new " + (tysj).split('/')[1]).Format("yyyy-MM-dd");
        $("#d_TouYun_Sj").val(TouYun_Sj);
    } else {
        $("#d_TouYun_Sj").val("");
    }


    var guid = $("#h_guid").val();
    $("#dlstImages").find("img").each(function (obj) {
        var ImgSrc = this.src;
        ImgSrc = "/EditImages/" + guid + ImgSrc.substring(ImgSrc.lastIndexOf('/'));
        $(this).attr("src", ImgSrc);
    });

    loadPicture();

    refresh();

});



//图片删除方法
function delImg(i) {
    var imgSrc = $("#pic_" + i).attr("src");
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
                $("#pic_" + i).remove();
                $("#delpic_" + i).remove();
                parent.$.messager.alert('提示', result.msg);
            } else {
                parent.$.messager.alert("提示", result.msg);
            }
        }
    });
}

function delthumbs(id, i) {
    $.ajax({
        url: "/WebService/ChargStationService.ashx",
        type: "post",
        async: false,
        data: { action: 'delpicture', id: id },
        datatype: "json",
        success: function (result) {
            var result = eval('(' + result + ')');
            if (result.success) {
                $("#img_" + i).remove();
                $("#bj_" + i).remove();
                parent.$.messager.alert('提示', result.msg);
            } else {
                parent.$.messager.alert("提示", result.msg);
            }
        }
    });
}

//加载原图片
function loadPicture() {
    var data = getPicture();
    var thumbsHtml = "";
    for (var i = 0; i < data.rows.length; i++) {
        thumbsHtml += "<img id='img_" + i + "' alt='img_" + i + "' width='50' height='40'style='margin-bottom:5px;' />" +
        "<img id='bj_" + i + "' src='../../images/cancel.png' width='10px' height='10px' align='top' title='删除' style='cursor:pointer;margin-right:5px;margin-bottom:5px;' onclick='delthumbs(\"" + data.rows[i].Id + "\"," + i + ")'/>"
    }
    $("#thumbs").append(thumbsHtml);
    for (var j = 0; j < data.rows.length; j++) {
        $("#img_" + j).attr("src", "/WebService/ChargStationService.ashx?action=loadpicture&fileid=" + data.rows[j].Id);
    }

}

//获取原图片
function getPicture() {
    var result;
    $.ajax({
        url: "/WebService/ChargStationService.ashx",
        type: "post",
        async: false,
        data: { action: 'getpicture', zhanbh: zhanbh },
        dataType: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            result = val;
        }
    });
    return result;
}

function save() {
    var phone = /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/;
    var mobile = /^(13|14|15|18)\d{9}$/;
    var LianXiDh = $("#d_LianXiDh").val();
    if (LianXiDh != "") {
        if (LianXiDh.match(phone) == null && LianXiDh.match(mobile) == null) {
           // $.messager.show({ title: '提示', msg: '联系电话不正确，请输入正确的手机号码和电话号码，电话号码格式：0551-88888888' });
            parent.$.messager.alert('提示', '联系电话不正确，请输入正确的手机号码或电话号码！');
            return false;
        }
    }
    var jd = $("#d_Longtude").val();
    if (jd > 117.9 || jd < 117.1) {
        parent.$.messager.alert('提示', '经度应处于117.1-117.9度之间！');
        return false;
    }
    var wd = $("#d_Latitude").val();
    if (wd > 31.9 || wd < 31.1) {
        parent.$.messager.alert('提示', '纬度应处于31.1-31.9度之间！');
        return false;
    }
    var jzsj = $("#d_JianZhan_SJ").val();
    if (jzsj == "") {
        parent.$.messager.alert('提示', '请选择建站时间！');
        return false;
    }
    var tysj = $("#d_TouYun_Sj").val();
    if (tysj == "") {
        parent.$.messager.alert('提示', '请选择投运时间！');
        return false;
    }
    return $("#fm").form('validate');
}

//保存成功之后站刷新
function refresh() {
    var sign = $("#h_sign").val();
    var sname = $("#d_zhanjc").val();
    if (sign == "refresh") {
        parent.StationRefresh(sname);
    }

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