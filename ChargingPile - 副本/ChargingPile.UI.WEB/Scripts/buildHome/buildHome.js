var myurl;
var mydata;
var postype = "POST";
var getype = "GET";
var jsontype = "json";
var htmltype = "html";
var contentype = "application/json; charset=utf-8";

//----------------------------  初始化  ---------------------------------
$(function () {
    var name = "id"; //充电桩id
    var zhanid = getQueryString(name); //获取url参数值

    //var zhanid = 100;

    $("#h_zhanid").val(zhanid);

    var myDate = new Date();
    var mytime = myDate.getFullYear().toString() + myDate.getMonth().toString() + myDate.getDay().toString() + myDate.getHours().toString() + myDate.getMinutes().toString() + myDate.getSeconds().toString() + myDate.getMilliseconds().toString();
    //alert(mytime);
    $("#buildHome").attr("src", "../../pages/Flex/swf.htm?swf=stationview.swf&title=" + escape("充电站") + "&stationcode=" + zhanid + "&tm=" + mytime);


    warnInfoQuery(zhanid);
    //setTimeout(warnInfoQuery,5000);//每隔5秒调用方法
    $(".info-row-2").css("float", "left");
});


//----------------------------  页面事件  ---------------------------------


//----------------------------  页面方法  ---------------------------------

//告警信息
function warnInfoQuery(zhanid) {
    myurl = "../../WebService/BuildHomeService.ashx";
    mydata = { action: "queryWarnInfo", zhanid: zhanid };
    getData();
}


function respose(data) {
    var resHtml = "";
    for (var i = data.Rows.length - 1; i >= 0; i--) {
        resHtml += "<li>" +
                            data.Rows[i].LogType + "&nbsp;&nbsp;" +
                            data.Rows[i].Yxbh +
                            eval("new " + data.Rows[i].Occurdt.split('/')[1]).Format("yyyy-MM-dd HH:mm:ss") + "&nbsp;&nbsp;" +
                            data.Rows[i].LogDesc + "&nbsp;&nbsp;" +
                  "</li>";
    }
    $("#response").html(resHtml);
}


//日期时间格式化方法，可以格式化年、月、日、时、分、秒、周
Date.prototype.Format = function (formatStr) {
    var week = ['日', '一', '二', '三', '四', '五', '六'];
    return formatStr.replace(/yyyy|YYYY/, this.getFullYear())
 	             .replace(/yy|YY/, (this.getYear() % 100) > 9 ? (this.getYear() % 100).toString() : '0' + (this.getYear() % 100))
 	             .replace(/MM/, (this.getMonth() + 1) > 9 ? (this.getMonth() + 1).toString() : '0' + (this.getMonth() + 1)).replace(/M/g, (this.getMonth() + 1))
 	             .replace(/w|W/g, week[this.getDay()])
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

//----------------------------  ajax方法  ---------------------------------

// 获取数据
function getData() {
    $.ajax({
        url: myurl,
        type: postype,
        async: false,
        data: mydata,
        dataType: jsontype,
        success: serviceSuccess,
        error: serviceError
    });
}

// ajax成功时返回
function serviceSuccess(resultObject) {
    if (resultObject.Status != null) {
        switch (resultObject.Status) {
            case 0:
                $.messager.alert("提示", resultObject.Msg);
                break;
            case 1:
                respose(resultObject);
                break;
            default:
        }
        return 1;
    }
}

// ajax失败时返回
function serviceError(result) {

}

//打开窗口方法
function winOpen(Url, width, height, scrollbar, resize) {
    //    Url     
    //    widht   
    //    height     
    //    scrollbar    0    yes    1    no     
    //    resize    0    true    1    false   

    ow = width;
    oh = height;
    os = scrollbar;
    or = resize;
    var xposition = 0;
    var yposition = 0;
    if ((parseInt(navigator.appVersion) >= 4)) {
        xposition = (screen.width - width) / 2;
        yposition = (screen.height - height - 25) / 2;
    }
    window.open(Url, "", "width    =" + ow + ",height=" + oh + ",scrollbars    =    " + os + ",resizable=" + or + ",left=" + xposition + ",top=" + yposition);
}


function stationinfo() {
    var zhanbh = $("#h_zhanid").val();
    winOpen("../../pages/ChargStation/StationInfo.htm?zhanbh=" + zhanbh, 1000, 610, 0, 1);
    //open("/pages/ChargStation/StationInfo.htm?zhanbh=" + zhanbh, "", "width=820,height=520,resizable=1");
    //$("#buildHome").attr("src", "/pages/ChargStation/StationInfo.htm");
}
function commMonitor() {
    var zhanbh = $("#h_zhanid").val();
    winOpen("../../pages/Flex/swf.htm?swf=commMonitor.swf&title=" + escape("厂站监视>>通讯监视>>通讯情况"), 1005, 610, 0, 1);
    //open("/pages/ChargStation/StationInfo.htm?zhanbh=" + zhanbh, "", "width=820,height=520,resizable=1");
    //$("#buildHome").attr("src", "/pages/ChargStation/StationInfo.htm");
}
function PowerCutImg() {
    var zhanbh = $("#h_zhanid").val();
    winOpen("../../pages/Flex/swf.htm?swf=PowerCutImg.swf&title=" + escape("厂站监视>>停电监视>>停电监视图"), 1005, 610, 0, 1);
    //open("/pages/ChargStation/StationInfo.htm?zhanbh=" + zhanbh, "", "width=820,height=520,resizable=1");
    //$("#buildHome").attr("src", "/pages/ChargStation/StationInfo.htm");
}
function StationUseChart() {
    var zhanbh = $("#h_zhanid").val();
    winOpen("../../pages/Flex/swf.htm?swf=StationUseChart.swf&title=" + escape("厂站监视>>使用监视>>充电站使用情况"), 1020, 610, 0, 1);
    //open("/pages/ChargStation/StationInfo.htm?zhanbh=" + zhanbh, "", "width=820,height=520,resizable=1");
    //$("#buildHome").attr("src", "/pages/ChargStation/StationInfo.htm");
}
function RunStatusTable() {
    var zhanbh = $("#h_zhanid").val();
    winOpen("../../pages/Flex/swf.htm?swf=RunStatusTable.swf&title=" + escape("厂站监视>>全景监视>>全景监视表"), 1005, 610, 0, 1);
    //open("/pages/ChargStation/StationInfo.htm?zhanbh=" + zhanbh, "", "width=820,height=520,resizable=1");
    //$("#buildHome").attr("src", "/pages/ChargStation/StationInfo.htm");
}
function stationYW() {
    var zhanbh = $("#h_zhanid").val();
    winOpen("../../pages/ChargStation/stationYW.htm?zhanbh=" + zhanbh, 1000, 610, 0, 1);
    //showModalDialog("/pages/ChargStation/stationYW.htm?zhanbh=" + zhanbh + "&r=" + Math.random(), "", "dialogWidth:820px;dialogHeight:520px;help:0;status:0;scroll:0;center:1");
    //$("#buildHome").attr("src", "/pages/ChargStation/stationYW.htm?zhanbh=" + zhanbh + "&r=" + Math.random());
}

function chargRecord() {
    var zhanbh = $("#h_zhanid").val();
    winOpen("../../pages/ChargStation/PileChargRecord.htm?pileno=" + zhanbh, 1000, 610, 0, 1);
    //showModalDialog("/pages/ChargStation/ChargRecord.htm?pileno=" + zhanbh, "", "dialogWidth:850px;dialogHeight:520px;help:0;status:0;scroll:0;center:1");
    //$("#buildHome").attr("src", "/pages/ChargStation/ChargRecord.htm");
}

//打开实景图
function openPicture_onclick() {
    var zhanbh = $("#h_zhanid").val();
    winOpen("../../pages/PictureChargStation/PictureChargStation.htm?zhanbh=" + zhanbh, 1020, 705, 0, 1);
    //showModalDialog("/pages/PictureChargStation/PictureChargStation.htm?zhanbh=" + zhanbh, "", "dialogWidth:1000px;dialogHeight:520px;help:0;status:0;scroll:0;center:1");
    //$("#buildHome").attr("src", "/pages/PictureChargStation/PictureChargStation.htm");
}

function chargCount() {
    var zhanbh = $("#h_zhanid").val();
    winOpen("../../pages/ChargStation/ChargCount.htm?pileno=" + zhanbh, 1000, 610, 0, 1);
    //showModalDialog("/pages/ChargStation/ChargCount.htm?pileno=" + zhanbh, "", "dialogWidth:850px;dialogHeight:520px;help:0;status:0;scroll:0;center:1");
    //$("#buildHome").attr("src", "/pages/ChargStation/ChargRecord.htm");
}

function useRank() {
    var zhanbh = $("#h_zhanid").val();
    winOpen("../../pages/ChargStation/PileUseRank.htm?pileno=" + zhanbh, 1000, 610, 0, 1);
    //showModalDialog("/pages/ChargStation/PileUseRank.htm?pileno=" + zhanbh, "", "dialogWidth:850px;dialogHeight:520px;help:0;status:0;scroll:0;center:1");
    //$("#buildHome").attr("src", "/pages/ChargStation/ChargRecord.htm");
}