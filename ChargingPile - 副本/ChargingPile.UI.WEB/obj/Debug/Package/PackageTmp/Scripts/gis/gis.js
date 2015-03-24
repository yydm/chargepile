$(function () {
    var myDate = new Date();
    var mytime = myDate.getFullYear().toString() + myDate.getMonth().toString() + myDate.getDay().toString() + myDate.getHours().toString() + myDate.getMinutes().toString() + myDate.getSeconds().toString() + myDate.getMilliseconds().toString();
    var zhanbh = getQueryString("ZHAN_BH");
    //alert(zhanbh + ";" + mytime);
    $("#gis").attr("src", "");
    $("#gis").attr("src", GisUrl + "#ZHAN_BH=" + zhanbh + "&querytype=1#tm=" + mytime);
    //gis.location.reload();
});
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