var myurl;
var mydata;
var postype = "POST";
var getype = "GET";
var jsontype = "json";
var htmltype = "html";
var contentype = "application/json; charset=utf-8";

//----------------------------  初始化  ---------------------------------
$(function () {
    $(".panel-fit, .panel-fit body").css("overflow", "auto");
    func();
    setInterval(func, 600000); //每隔10分钟调用方法
});

function func() {
    setInputDom(); //设置input表单
    var name = "PowerPileNo"; //充电桩id
    var zhuanid = getQueryString(name); //获取url参数值
    $("#hzhuangid").val(zhuanid);
    queryChargePileInfo(zhuanid);
    //var zhuanid = "10001022"; //10102002  10001011 10001022
    //---------------
    //var aHref1 = $("#lk1").find("a");
    //aHref1.attr("href", aHref1.attr("href") + "?pileno=" + zhuanid);
    //    var aHref2 = $("#lk2").find("a");
    //    aHref2.attr("href", aHref2.attr("href") + "?pileno=" + zhuanid);
    //var aHref3 = $("#lk3").find("a");
    //aHref3.attr("href", aHref3.attr("href") + "?pileno=" + zhuanid);
    //    var aHref4 = $("#lk4").find("a");
    //    aHref4.attr("href", aHref4.attr("href") + "?pileno=" + zhuanid);
    //---------------
    if (zhuanid != null && zhuanid.length != 0) {
        queryChargePileStates(zhuanid); //查询充电桩状态(含有交易信息)

        setCurrentTimeInfo(zhuanid); //设置实时信息

        setChargePileInfo(zhuanid); //设置桩基本信息

        warnInfoQuery(zhuanid); //查询告警信息

    } else {
        $.messager.alert("提示", "桩id不能为空!");
    }
}


/*
* 设置电流表对象
*/
var highChartsSettingA = {
    chart: {
        margin: [5, 2, 5, 4],
        type: 'gauge',
        plotBorderWidth: 1,
        plotBackgroundColor: {
            linearGradient: { x1: 0, y1: 0 },
            //设置默认背景着色
            stops: [
                        [0, '#FFF4C6'],
                        [0.3, '#FFFFFF'],
                        [1, '#FFF4C6']
                ]
        },
        plotBackgroundImage: '../../images/skies.jpg',
        height: 150
    },

    //去掉highcharts.com商标
    credits: {
        enabled: false
    },

    //去掉chart不必要属性
    exporting: {
        enabled: false
    },
    title: null,

    pane: [{
        startAngle: -45,
        endAngle: 45,
        background: null,
        center: ['51%', '155%'],
        size: 380
    }
],

    //设置charts显示样式
    yAxis: [{
        minorTickPosition: 'outside',
        minorTickInterval: 'auto',
        tickPosition: 'outside',
        tickLength: 15,
        labels: {
            step: 0,
            rotation: 'auto',
            distance: -25
        },

        title: {
            text: '<span style="font-size:8px">输出电流(A)</span>',
            y: -40
        }
    }],


    plotOptions: {
        gauge: {
            dataLabels: {
                enabled: false
            },
            dial: {
                radius: '100%'
            }
        }
    },

    //设置指针指向值
    series: [{
        data: [{
            y: 10
        }]
    }]
};

/*
* 设置电压表对象
*/
var highChartsSettingU = {
    chart: {
        margin: [5, 1, 5, 4],
        type: 'gauge',
        plotBorderWidth: 1,
        plotBackgroundColor: {
            linearGradient: { x1: 0, y1: 0 },
            stops: [
                    [0, '#FFF4C6'],
                    [0.3, '#FFFFFF'],
                    [1, '#FFF4C6']
                   ]
        },
        plotBackgroundImage: '../../images/skies.jpg',
        height: 150
    },
    credits: {
        enabled: false
    },
    exporting: {
        enabled: false
    },
    title: null,

    pane: [{
        startAngle: -45,
        endAngle: 45,
        background: null,
        center: ['51%', '155%'],
        size: 380
    }
],

    yAxis: [{
        minorTickPosition: 'outside',
        minorTickInterval: 'auto',
        //tickColor:'blue',
        tickPosition: 'outside',
        labels: {
            rotation: 'auto',
            distance: -25
        },
        tickLength: 15,
        plotBands: [],
        pane: 0,
        title: {
            text: '<span style="font-size:8px">输出电压(V)</span>',
            y: -40
        }
    }],

    plotOptions: {
        gauge: {
            dataLabels: {
                enabled: false
            },
            dial: {
                radius: '100%'
            }
        }
    },

    //设置指针指向值
    series: [{
        data: [{
            y: 0
        }]
    }]
};

;
//----------------------------  页面方法  ---------------------------------

/*
* *根据充电桩id获取充电站名称和充电桩编号
*/
function queryChargePileInfo(id) {
    myurl = "../../pages/ChargePileDetailInfo/ChargePileDetailInfomation.aspx/QueryChargePileInfo";
    if (id == "undefined") {
        id = "";
    }
    mydata = "{'chargpileid':'" + id + "'}";
    ajaxSuccess_queryChargePileInfo();
}
/*
* *根据充电桩id获取充电站名称和充电桩编号(后台返回成功时调用)
*/
function csAjaxSuccess_queryChargePileInfo(data) {
    if (data.d == null) {
        $('#panel-west').panel('setTitle', "&nbsp;");
        return false;
    }
    var ret = data.d.replace(/\r\n/ig, "");
    var obj = eval('(' + ret + ')'); //转换后的JSON对象
    if (obj.Status == 1) {
        $('#panel-west').panel('setTitle', obj.Rows[0].Zhan_Jc + ">>" + obj.Rows[0].YunXing_Bh);
        return true;
    }
    $('#panel-west').panel('setTitle', "&nbsp;");
    return false;
}

/*
* 查询充电桩状态
*/
function queryChargePileStates(id) {
    myurl = "../../pages/ChargePileDetailInfo/ChargePileDetailInfomation.aspx/ChargePileStates";
    mydata = "{'chargpileid':'" + id + "'}";
    chargePileStates_remoteAjaxData();
}

/**
*  ajax成功返回时
*  显示查询充电桩状态data到页面
**/
function remoteAjaxSuccess_queryChargePileStates(data) {
    var ret = data.d.replace(/\r\n/ig, "");
    var obj = eval('(' + ret + ')'); //转换后的JSON对象
    if (!obj.success || obj.data.length <= 0) {
        setChargePileStatus(6);
        return false;
    }
    switch (obj.success) {
        case true:
            var chargePileStates = obj.data[0].POWERPILESTATUS;
            setChargePileStatus(chargePileStates); //桩状设置充电态图片
            setBusinessInfo(obj.data[0].POWERPILENO, chargePileStates); //设置交易信息
            break;
        default:
            break;
    }
    return true;
}

/*
* 设置电流表
*/
function setA(current) {
    // current.CurrentTime='2013-10-29 10:23:56';
    if (current.getCurrentTime() == null) {
        highChartsSettingA.series[0].name = '电流表值';
    } else {
        highChartsSettingA.series[0].name = '采集时间:' + current.getCurrentTime() + '<br />电流表值';
    }

    highChartsSettingA.series[0].data[0].y = current.getCurrentPointer();
    highChartsSettingA.yAxis[0].min = current.getCurrentThresholdMin();
    highChartsSettingA.yAxis[0].max = current.getCurrentThresholdMax();


    highChartsSettingA.yAxis[0].plotBands = [{
        from: current.getCurrentEffectiveMin(),
        to: current.getCurrentEffectiveMax(),
        color: '#55BF3B' // green
    }, {
        from: current.getCurrentEffectiveMax(),
        to: current.getCurrentThresholdMax(),
        color: '#DDDF0D' // red
    }];

    $('#ssxx-v').highcharts(highChartsSettingA);
}

/*
* 设置电压表
*/
function setU(voltage) {
    if (voltage.getVoltageTime() == null) {
        highChartsSettingU.series[0].name = '电压表值';
    } else {
        highChartsSettingU.series[0].name = '采集时间:' + voltage.getVoltageTime() + '<br />电压表值';
    }
    highChartsSettingU.series[0].data[0].y = voltage.getVoltagePointer();
    highChartsSettingU.yAxis[0].min = voltage.getVoltageThresholdMin();
    highChartsSettingU.yAxis[0].max = voltage.getVoltageThresholdMax();

    highChartsSettingU.yAxis[0].plotBands = [{
        from: voltage.getVoltageEffectiveMin(),
        to: voltage.getVoltageEffectiveMax(),
        color: '#55BF3B' // green
    }, {
        from: voltage.getVoltageEffectiveMax(),
        to: voltage.getVoltageThresholdMax(),
        color: '#DDDF0D' // red
    }];
    $('#ssxx-u').highcharts(highChartsSettingU);
}

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

/**
* *设置实时信息
**/
function setCurrentTimeInfo(id) {
    myurl = "../../pages/ChargePileDetailInfo/ChargePileDetailInfomation.aspx/ChargePileCurrentTime";
    mydata = "{'chargpileid':'" + id + "'}";
    chargePileCurrentTime_remoteAjaxData();
}

/**
*  ajax成功返回时
*  显示查询实时信息data到页面
**/
function remoteAjaxSuccess_setCurrentTimeInfo(data) {
    var currenttime = "";
    var voltagetime = "";
    var resHtml = "";
    var redHtml = "";
    var greenHtml = "";
    var grayHtml = "";
    var ret = data.d.replace(/\r\n/ig, "");
    var obj = eval('(' + ret + ')'); //转换后的JSON对象
    switch (obj.Status) {
        case 0:
            $.messager.alert("提示", obj.Msg);
            //alert(obj.Msg);
            return false;
        case 1:
            if (obj.Rows == null) {
                $.messager.alert("提示", "没有数据!");
                //alert(obj.Msg);
                return false;
            }
        case 2:
            $.messager.alert("提示", obj.Msg);
            //alert(obj.Msg);
            return false;
        default:
    }
    var current = new Current();
    current.setCurrentPointer(obj.Current.CurrentPointer);
    current.setCurrentEffectiveMax(obj.Current.CurrentEffectiveMax);
    current.setCurrentEffectiveMin(obj.Current.CurrentEffectiveMin);
    current.setCurrentThresholdMax(obj.Current.CurrentThresholdMax);
    current.setCurrentThresholdMin(obj.Current.CurrentThresholdMin);
    currenttime = obj.Current.CurrentTime;
    current.setCurrentTime(currenttime);
    setA(current); //设置电流表

    var voltage = new Voltage();
    voltage.setVoltagePointer(obj.Voltage.VoltagePointer);
    voltage.setVoltageEffectiveMax(obj.Voltage.VoltageEffectiveMax);
    voltage.setVoltageEffectiveMin(obj.Voltage.VoltageEffectiveMin);
    voltage.setVoltageThresholdMax(obj.Voltage.VoltageThresholdMax);
    voltage.setVoltageThresholdMin(obj.Voltage.VoltageThresholdMin);
    voltagetime = obj.Voltage.VoltageTime;
    voltage.setVoltageTime(voltagetime);
    setU(voltage); //设置电压表
    for (var i = 0, l = obj.Rows.length; i < l; i++) {
        switch (obj.Rows[i].IsItemShowColor) {
            case "red":
                var param = new Array();
                param[0] = obj.Rows[i].ItemNo;
                param[1] = obj.Rows[i].TargetDev;
                param[2] = obj.Rows[i].WorkNum;
                redHtml += "<input id='" + obj.Rows[i].ItemNo + "' name='" + obj.Rows[i].ItemNo + "' type='button' class='ssxx-column2-btn2' title='" +
            obj.Rows[i].ItemName + "' value='" + obj.Rows[i].ItemName + "' onclick='btnWarn_click(\"" + param + "\")'></button>";
                break;
            case "green":
                greenHtml += "<input type='button' class='ssxx-column2-btn1' title='" +
            obj.Rows[i].ItemName + "' value='" + obj.Rows[i].ItemName + "'></button>";
                break;
            case "gray":
                grayHtml += "<input type='button' class='ssxx-column2-btn3' title='" +
            obj.Rows[i].ItemName + "' value='" + obj.Rows[i].ItemName + "'></button>";
                break;
            default:
        }
    }
    resHtml = redHtml + greenHtml + grayHtml;
    $(".ssxx-column2-css").html(resHtml);
    if (currenttime != null && voltagetime != null) {
        $("#gatDt").html("数据时间:" + currenttime.split('.')[0]).css("color", "#666");
    } else if (currenttime == null && voltagetime != null) {
        $("#gatDt").html("数据时间:" + voltagetime.split('.')[0]).css("color", "#666"); ;
    }
    else if (currenttime != null && voltagetime == null) {
        $("#gatDt").html("数据时间:" + currenttime.split('.')[0]).css("color", "#666");
    }
    return true;
}

/**
*  ajax成功返回时
*  显示数据项data到页面
**/
function ajaxSuccess_remoteAjaxSuccess_setCurrentTimeInfo(data) {
    var resHtml = "";
    resHtml += "<input type='button' class='ssxx-column2-btn' title='"
               + data.values[i].value + "' value='"
               + data.values[i].value + "'></button>";
    $(".ssxx-column2-css").html(resHtml);
}


/**
* *设置交易信息
**/
function setBusinessInfo(id, states) {
    myurl = "../../WebService/ChargePileDetailInfoService.ashx";
    mydata = { action: "getBusinessInfo", zhuanid: id, zhuanstates: states };
    ajaxData();
}

/**
*  ajax成功返回时
*  显示交易信息data到页面
**/
function ajaxSuccess_setBusinessInfo(data) {
    setBusinessInputEmpty();
    if (data.Rows.length <= 0) {
        return false;
    }
    switch (data.msg) {
        case "1": //待充电  1 如果是待机，就要显示最近一次交易信息
        case "3": //已充满  3 
            $("#cdjssj").val(data.Rows[0].Enddt);
            break;
        case "2": //充电中  2 
            $("#cdjssj").val("");
            break;
        case "5": //故障异常  5
            $("#cdjssj").val(data.Rows[0].Enddt);
            break;
        default: //离线  4 未知
    }

    var interval = data.Rows[0].Interval;
    var interval1 = interval.substring(0, 1);
    var interval2 = interval.substring(3, interval.length - 1);
    if (interval1 == "0") {
        $("#cdzsc").val(interval2);
    } else {
        $("#cdzsc").val(interval);
    }
    $("#cdkssj").val(data.Rows[0].Startdt);
    $("#cdjssj").val(data.Rows[0].Enddt);
    $("#zdl").val(data.Rows[0].Charge_power== "undefined" || data.Rows[0].Charge_power== "0" ? "" : data.Rows[0].Charge_power);
    $("#fdl").val(data.Rows[0].Power_high == "undefined" || data.Rows[0].Power_high == "0" ? "" : data.Rows[0].Power_high);
    $("#pdl").val(data.Rows[0].Power_normal == "undefined" || data.Rows[0].Power_normal == "0" ? "" : data.Rows[0].Power_normal);
    $("#gdl").val(data.Rows[0].Power_low == "undefined" || data.Rows[0].Power_low == "0" ? "" : data.Rows[0].Power_low);
    $("#jdl").val(data.Rows[0].Power_tip == "undefined" || data.Rows[0].Power_tip == "0" ? "" : data.Rows[0].Power_tip);

    if (data.Rows[0].Charge_money == null || data.Rows[0].Charge_money == "0") {
        $("#zje").val("");
    } else {
        $("#zje").val(data.Rows[0].Charge_money + "元");
    }

    $("#kh").val(data.Rows[0].Card_no);

    if (data.Rows[0].Card_end_money == null || data.Rows[0].Charge_money == "0") {
        $("#kye").val("");
    } else {
        $("#kye").val(data.Rows[0].Card_end_money + "元");
    }

    if ((data.Rows[0].CheckOut_No != 0 && data.Rows[0].CheckOut_No != null) || data.Rows[0].CreditCardDt != null) {
        $("#jszt").val("已结算");
    } else {
        $("#jszt").val("未结算");
    }

    $("#fdj").val(data.Rows[0].Value_high == "undefined" || data.Rows[0].fdj == "0" ? "" : data.Rows[0].Value_high);
    $("#pdj").val(data.Rows[0].Value_normal == "undefined" || data.Rows[0].pdj == "0" ? "" : data.Rows[0].Value_normal);
    $("#gdj").val(data.Rows[0].Value_low == "undefined" || data.Rows[0].gdj == "0" ? "" : data.Rows[0].Value_low);
    $("#jdj").val(data.Rows[0].Value_tip == "undefined" || data.Rows[0].jdj == "0" ? "" : data.Rows[0].Value_tip);

    return true;
}

/**
* *设置桩基本信息
**/
function setChargePileInfo(id) {
    myurl = "../../WebService/ChargePileDetailInfoService.ashx";
    mydata = { action: "getDetailInfo", zhuanid: id };
    ajaxData();
}

/**
*  ajax成功返回时
*  显示桩基本信息data到页面
**/
function ajaxSuccess_setChargePileInfo(data) {
    setChargePileInputEmpty();
    if (data.Rows.length <= 0) {
        return false;
    }
    var tysj = "";
    if (data.Rows[0].Tysj != null) {
        tysj = data.Rows[0].Tysj.split('-');
        tysj = tysj[0] + "年" + tysj[1] + "月";
    }
    $("#sccj").val(data.Rows[0].ChangJia);
    $("#cjbh").val(data.Rows[0].ChangJiao_Bh);
    $("#zyxbh").val(data.Rows[0].YunXing_Bh);
    $("#zlx").val(data.Rows[0].ZhuangLei_X);
//    $("#yxdy").val(data.Rows[0].Zgyxdy);
//    $("#yxdl").val(data.Rows[0].Zgyxdl);
    $("#tysj").val(tysj);
//    $("#fdj").val(data.Rows[0].Fjg == null ? "/" : data.Rows[0].Fjg.toFixed(2) + "元");
//    $("#pdj").val(data.Rows[0].Pjg == null ? "/" : data.Rows[0].Pjg.toFixed(2) + "元");
//    $("#gdj").val(data.Rows[0].Gjg == null ? "/" : data.Rows[0].Gjg.toFixed(2) + "元");
//    $("#jdj").val(data.Rows[0].Jjg == null ? "/" : data.Rows[0].Jjg.toFixed(2) + "元");

//    if (data.Rows[0].Ftjg == null) {
//        $("#ftdj").val();
//    } else {
//        $("#ftdj").val(data.Rows[0].Ftjg + "元");
//    }

    return true;
}

/**
* *查询告警信息
**/
function warnInfoQuery(id) {
    myurl = "../../WebService/BuildHomeService.ashx";
    mydata = { action: "queryWarnInfoByZhuanId", zhuanid: id };
    ajaxData();
}

/**
*  ajax成功返回时
*  显示告警信息data到页面
**/
function ajaxSuccess_warnInfoQuery(data) {
    var resHtml = "";
    $("#response").html(resHtml);
    for (var i = data.Rows.length - 1; i >= 0; i--) {
        resHtml += "<li>" +
                            data.Rows[i].LogType + "&nbsp;&nbsp;" +
                            eval("new " + data.Rows[i].Occurdt.split('/')[1]).Format("yyyy-MM-dd HH:mm:ss") + "&nbsp;&nbsp;" +
                            data.Rows[i].LogDesc + "&nbsp;&nbsp;" +
                  "</li>";
    }
    $("#response").html(resHtml);
}

/**
* 日期时间格式化方法，
* 可以格式化年、月、日、时、分、秒、周
**/
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

//----------------------------  页面事件  ---------------------------------

/**
* *保存告警处理界面
**/
function btn_ok() {
    var clcz = $("[name=r_gjcl]:checked").val();
    if (clcz == 1) {
        myurl = "../../WebService/ChargePileDetailInfoService.ashx";
        mydata = {
            action: "offPolice",
            warnid: $("#hidd_warnid").val(),
            itemno: $("#hidd_itemno").val()
        };
        ajaxData();
    }
    btn_close();
    return false;
}

/**
* *保存告警处理界面2
**/
function btn_ok2() {
    var targetDev = $("#hidd_TargetDev").val();
    var dataItemId = $("#hidd_DataItemId").val();
    var workNum = $("#hidd_WorkNum").val();
    var clcz = $("[name=r_gjcl]:checked").val();
    if (clcz == 1) {
        InvokeWarn(targetDev, dataItemId, workNum); //调用远程接口
    }
    btn_close();
}


/**
* *InvokeWarn.js文件ajax方法里success返回的方法之一
**/
function invokeWarn_return_success(resp) {
    //$.messager.alert('消息',JSON2.stringify(resp),"info");
    //调用成功，
    $.messager.alert('消息', resp.success, "info"); //判断resp.success是否等于true，等于true则说明调用成功。继续执行其他操作。
    var hiddId = $("#hidd_DataItemId").val();
    $("#" + hiddId).removeClass("ssxx-column2-btn2").addClass("ssxx-column2-btn1").removeAttr("onclick");
}

/**
* *InvokeWarn.js文件ajax方法里success返回的方法之一
**/
function invokeWarn_return_error(resp) {
    //$.messager.alert('消息',JSON2.stringify(resp),"info");
    if (resp.message.length > 30) {
        $.messager.alert('消息', resp.message, "info");
    } else {
        $.messager.alert('消息', resp.message, "error");
    }
    var hiddId = $("#hidd_DataItemId").val();
    $("#" + hiddId).removeClass("ssxx-column2-btn2").addClass("ssxx-column2-btn1").removeAttr("onclick");
}

/**
* *InvokeWarn.js文件ajax方法里error返回的方法
**/
function invokeWarn_error(xhr, url) {
    $.messager.alert('消息', 'Ajax错误\r\n' + '调用地址' + url + "发生错误", "error");
}


/**
* *告警处理ajax成功时调用的方法
**/
function ajaxSuccess_btn_ok(data) {
    switch (data.Status) {
        case 0:
            $.messager.alert("提示", data.Msg);
            break;
        case 1:
            var hiddId = $("#hidd_itemno").val();
            $("#" + hiddId).removeClass("ssxx-column2-btn2").addClass("ssxx-column2-btn1").removeAttr("onclick");
        default:
    }
}


/**
* *打开告警处理界面
**/
function btnWarn_click(param) {
    $("#dlg").dialog("open");
    $("[name=r_gjcl]").eq(0).attr("checked", true);
    //$("#hidd_warnid").val(warnid);
    //$("#hidd_itemno").val(itemno);
    //这个要对应好
    $("#hidd_DataItemId").val(param.split(',')[0]);
    $("#hidd_TargetDev").val(param.split(',')[1]);
    $("#hidd_WorkNum").val(param.split(',')[2]);
    return false;
}

/**
* *关闭告警处理界面
**/
function btn_close() {
    $('#dlg').dialog('close');
}
//----------------------------  jquery操作页面DOM  ---------------------------------

/**
* *设置充电桩状态图片
**/
function setChargePileStatus(chargePileStates) {
    $("#status img").removeAttr("src");
    $("#status img").removeAttr("title");
    $("#content-status").empty();
    switch (chargePileStates) {
        case 1:
            $("#status img").attr("src", "../../Images/dcd.png");
//            $("#status img").attr("title", "待充电");
//            $("#content-status").append("待充电");
            $("#status img").attr("title", "待机");
            $("#content-status").append("待机");
            break;
        case 2:
            $("#status img").attr("src", "../../Images/cdz.png");
            $("#status img").attr("title", "充电中");
            $("#content-status").append("充电中");
            break;
        case 3:
            $("#status img").attr("src", "../../Images/ycm.png");
//            $("#status img").attr("title", "已充电");
//            $("#content-status").append("已充电");
            $("#status img").attr("title", "已充满");
            $("#content-status").append("已充满");
            break;
        case 4: case 5:
            $("#status img").attr("src", "../../Images/cdgz.png");
            $("#status img").attr("title", "故障");
            $("#content-status").append("故障");

            break;

        default:
            $("#status img").attr("src", "../../Images/help.png");
            $("#status img").attr("title", "未知状态");
            $("#content-status").append("未知状态");
            break;
    }

}

/**
* *设置input表单
**/
function setInputDom() {
    $(".tabs-css-table input").attr("readonly", true);
    $(".tabs-css-table2 input").attr("readonly", true);
    //$(".tabs-css-table input").css("font-weight", "bold");
    //$(".tabs-css-table2 input").css("font-weight", "bold");
}

/**
* *清空交易信息input表单
**/
function setBusinessInputEmpty() {
    $(".tabs-css-table input").empty();
}

/**
* *清空桩基本信息input表单
**/
function setChargePileInputEmpty() {
    $(".tabs-css-table2 input").empty();
}


//----------------------------  ajax方法  ---------------------------------
/**
* *根据充电桩id获取充电站名称和充电桩编号ajax方法
**/
function ajaxSuccess_queryChargePileInfo() {
    $.ajax({
        url: myurl,
        type: postype,
        async: false,
        data: mydata,
        dataType: jsontype,
        contentType: contentype,
        success: csAjaxSuccess_queryChargePileInfo,
        error: serviceError
    });
}

/**
* *充电桩状态ajax方法
**/
function chargePileStates_remoteAjaxData() {
    $.ajax({
        url: myurl,
        type: postype,
        async: false,
        data: mydata,
        dataType: jsontype,
        contentType: contentype,
        success: remoteAjaxSuccess_queryChargePileStates,
        error: serviceError
    });
}


/**
* *实时状态ajax方法
**/
function chargePileCurrentTime_remoteAjaxData() {
    $.ajax({
        url: myurl,
        type: postype,
        async: false,
        data: mydata,
        dataType: jsontype,
        contentType: contentype,
        success: remoteAjaxSuccess_setCurrentTimeInfo,
        error: serviceError
    });
}


/**
* *ajax增删改查方法
**/
function ajaxData() {

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

/**
* *ajax成功时返回resultObject是json数据
**/
function serviceSuccess(resultObject) {
    if (resultObject == null) {
        return true;
    }
    switch (resultObject.Status) {
        case 0:
        case 2:
            $.messager.alert("提示", resultObject.Msg);
            break;
        case 1:
            eval(resultObject.JsExecuteMethod + "(resultObject)");
            break;
        default:
    }
    return true;
}

/**
* *ajax失败时返回
**/
function serviceError(result) {
    return false;
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


function txinfo() {
    winOpen("../Flex/swf.htm?swf=commMonitor.swf&title=" + escape("厂站监视 >> 通讯监视 >> 通讯情况"), 1005, 610, 0, 1);
}

function tdinfo() {
    winOpen("../Flex/swf.htm?swf=PowerCutImg.swf&title=" + escape("厂站监视>>停电监视>>停电监视图"), 1005, 610, 0, 1);
}

function jyinfo() {
    var zhuangid = $("#hzhuangid").val();
    winOpen("../../pages/ChargStation/ChargRecord.htm?pileno=" + zhuangid, 1000, 610, 0, 1);
}

function yxinfo() {
    winOpen("../Flex/swf.htm?swf=RunStatusTable.swf&title=" + escape("厂站监视>>全景监视>>全景监视表"), 1005, 610, 0, 1);
}

function ywinfo() {
    var zhuangid = $("#hzhuangid").val();
    winOpen("../../pages/ChargStation/PileYW.htm?pileno=" + zhuangid, 1000, 600, 0, 1);
}

function syinfo() {
    winOpen("../Flex/swf.htm?swf=StationUseChart.swf&title=" + escape("厂站监视>>使用监视>>充电站使用情况"), 1020, 610, 0, 1);
}
