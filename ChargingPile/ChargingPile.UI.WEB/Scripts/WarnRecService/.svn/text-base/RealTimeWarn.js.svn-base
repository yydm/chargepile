var myurl;
var mydata;
var postype = "POST";
var getype = "GET";
var jsontype = "json";
var htmltype = "html";
var contentype = "application/json; charset=utf-8";
//----------------------------  初始化  ---------------------------------
$(function () {
    //TODO:场站名称是什么？
    var name = "Zhan_Bh"; //充电站编号(id)
    var zhanbh = getQueryString(name); //获取url参数值
    func(zhanbh);
    setInterval(func, 120000); //每隔两分钟刷新一次
});

//----------------------------  页面方法  ---------------------------------

function func(zhanbh) {
    telesignallingWarn(zhanbh); //获取异常告警
    cardWarn(zhanbh); //获取充电卡异常使用告警
    communicationWarn(zhanbh); //获取通信告警告警
    powerFailure(zhanbh); //停电告警
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
    window.open(Url, "", "width=" + ow + ",height=" + oh + ",scrollbars=" + os + ",resizable=" + or + ",left=" + xposition + ",top=" + yposition + ",location = no");
}


//更多实时告警信息
function rtMore() {
    winOpen("../../pages/WarnRecService/RealTimeQuery.htm?dotype=more", 1024, 650, 0, 1);
}

//更多充电卡告警信息
function ccMore() {
    winOpen("../../pages/WarnRecService/ChargCardWarn.htm?cs=time", 1024, 650, 0, 1);
}

//更多通信告警信息
function cmMore() {
    winOpen("../../pages/WarnRecService/CommunicateWarn.htm?cs=time", 1024, 650, 0, 1);
}

//更多停电告警信息
function pcMore() {
    winOpen("../../pages/WarnRecService/PowerCutWarn.htm?cs=time", 1024, 650, 0, 1);
}

//具体实时告警信息
function rtnum() {
    winOpen("../../pages/WarnRecService/RealTimeQuery.htm?dotype=0", 1024, 650, 0, 1);
}

//具体充电卡告警信息
function ccnum() {
    winOpen("../../pages/WarnRecService/ChargCardWarn.htm?cs=type", 1024, 650, 0, 1);
}

//具体通信告警信息
function cmnum() {
    winOpen("../../pages/WarnRecService/CommunicateWarn.htm?cs=type", 1024, 650, 0, 1);
}

//具体停电告警信息
function pcnum() {
    winOpen("../../pages/WarnRecService/PowerCutWarn.htm?cs=type", 1024, 650, 0, 1);
}

/**
* *获取异常告警
**/
function telesignallingWarn(zhanbh) {
    $('#dg_telesignalling_warn').datagrid({
        url: '../../WebService/WarnRecService.ashx',
        queryParams: { action: 'findbytelesignallingwarn', zhanbh: zhanbh },
        fit: true,
        singleSelect: true,
        border: false,
        striped: true,
        columns: [[
            { field: 'Id', hidden: true },
            { field: 'CodeName', title: '类型', align: 'center', width: 60 },
            { field: 'OccurDt', title: '时间', align: 'center', width: 130 },
            { field: 'ZhanJc', title: '场站名称', align: 'center', width: 100 },
            { field: 'YunXing_Bh', title: '桩运行编号', align: 'center', width: 70 },
            { field: 'ItemName', title: '数据项名称', align: 'center', width: 120 },
            { field: 'LogDesc', title: '内容', align: 'center', width: 306 },
             { field: 'ycl', title: '已处理', align: 'center', width: 66,
                 formatter: function (value, row, index) {
                     var str = "";
                     switch (row.ProcessFlag) {
                         case 0:
                             str = "否";
                             break;
                         case 1:
                         case 2:
                             str = "是";
                             break;

                         default:
                     }
                     return str;
                 }
             },
         { field: 'content', title: '处理方式', align: 'center', width: 100,
             formatter: function (value, row, index) {
                 var str = row.ProcessFlag;
                 switch (str) {
                     case 0:
                         str = "等待灭警";
                         break;
                     case 1:
                         str = "自动灭警";
                         break;
                     case 2:
                         str = "人工灭警";
                         break;

                     default:
                 }
                 return str;
             }
         },
            { field: 'ProcessFlag', title: '操作', width: 60, align: 'center',
                formatter: function (value, row, index) {
                    var param = new Array();
                    param[0] = row.TargetDev;
                    param[1] = row.DataItemId;
                    param[2] = row.WorkNum;
                    param[3] = "telesignallingWarn";
                    var str = "";
                    switch (row.ProcessFlag) {
                        case 0:
                            str = "<a href='#' onclick='OffPolice_click(\"" + param + "\")' class='easyui-linkbutton' plain='true' title='' iconcls='icon-quench'></a>";
                            break;
                        case 1:
                        case 2:
                            str = "<a href='#' class='easyui-linkbutton' plain='true' title='' iconcls='icon-ok'></a>";
                            break;

                        default:
                    }
                    return str;
                }
            }
        ]],
        onLoadSuccess: function (data) {
            $($('#dg_telesignalling_warn').datagrid("getPanel")).find('a.easyui-linkbutton').linkbutton();
            $("#telesignalling_warn").panel("setTitle", "异常告警(等待灭警<a class='linka' href='#' onclick='rtnum()'>" + data.status + "</a>条)");
        }
    });
}


/**
* *获取充电卡异常使用告警
**/
function cardWarn(zhanbh) {
    $('#dg_Card_Warn').datagrid({
        url: '../../WebService/WarnRecService.ashx',
        queryParams: { action: 'findbycardwarn', zhanbh: zhanbh },
        fit: true,
        singleSelect: true,
        border: false,
        striped: true,
        columns: [[
            { field: 'Id', hidden: true },
            { field: 'OccurDt', title: '时间', align: 'center', width: 146 },
            { field: 'ZhanJc', title: '场站名称', align: 'center', width: 200 },
            { field: 'YunXing_Bh', title: '桩运行编号', align: 'center', width: 200 },
            { field: 'TargetDataKey', title: '卡号', align: 'center', width: 150 },
            { field: 'ycl', title: '已处理', align: 'center', width: 50,
                formatter: function (value, row, index) {
                    var str = "";
                    switch (row.ProcessFlag) {
                        case 0:
                            str = "否";
                            break;
                        case 1:
                        case 2:
                            str = "是";
                            break;

                        default:
                    }
                    return str;
                }
            },
         { field: 'content', title: '处理方式', align: 'center', width: 150,
             formatter: function (value, row, index) {
                 var str = row.ProcessFlag;
                 switch (str) {
                     case 0:
                         str = "等待灭警";
                         break;
                     case 1:
                         str = "自动灭警";
                         break;
                     case 2:
                         str = "人工灭警";
                         break;

                     default:
                 }
                 return str;
             }
         },
            { field: 'ProcessFlag', title: '操作', width: 115, align: 'center',
                formatter: function (value, row, index) {
                    var str = "";
                    var param = new Array();
                    param[0] = row.TargetDev;
                    param[1] = row.DataItemId;
                    param[2] = row.WorkNum;
                    param[3] = "cardWarn";
                    switch (row.ProcessFlag) {
                        case 0:
                            str = "<a href='#' onclick='OffPolice_click(\"" + param + "\")' class='easyui-linkbutton' plain='true' title='' iconcls='icon-quench'></a>";
                            break;
                        case 1:
                        case 2:
                            str = "<a href='#' class='easyui-linkbutton' plain='true' title='' iconcls='icon-ok'></a>";
                            break;
                        default:
                    }
                    return str;
                }
            }
        ]],
        onLoadSuccess: function (data) {
            $($('#dg_Card_Warn').datagrid("getPanel")).find('a.easyui-linkbutton').linkbutton();
            $("#card_Warn").panel("setTitle", "充电卡异常使用告警(异常使用<a class='linka' href='#' onclick='ccnum()'>" + data.status + "</a>张)");
        }
    });
}

/**
* *获取通信告警告警
**/
function communicationWarn(zhanbh) {
    $('#dg_communication_warn').datagrid({
        url: '../../WebService/WarnRecService.ashx',
        queryParams: { action: 'findbycommunicationwarn', zhanbh: zhanbh },
        fit: true,
        singleSelect: true,
        border: false,
        striped: true,
        columns: [[
            { field: 'Id', hidden: true },
            { field: 'OccurDt', title: '时间', align: 'center', width: 130 },
            { field: 'ZhanJc', title: '场站名称', align: 'center', width: 130 },
            { field: 'DtuName', title: 'DTU名称', align: 'center', width: 80 },
            { field: 'ycl', title: '已处理', align: 'center', width: 50,
                formatter: function (value, row, index) {
                    var str = "";
                    switch (row.ProcessFlag) {
                        case 0:
                            str = "否";
                            break;
                        case 1:
                        case 2:
                            str = "是";
                            break;

                        default:
                    }
                    return str;
                }
            },
         { field: 'content', title: '处理方式', align: 'center', width: 65,
             formatter: function (value, row, index) {
                 var str = row.ProcessFlag;
                 switch (str) {
                     case 0:
                         str = "等待灭警";
                         break;
                     case 1:
                         str = "自动灭警";
                         break;
                     case 2:
                         str = "人工灭警";
                         break;

                     default:
                 }
                 return str;
             }
         },
            { field: 'ProcessFlag', title: '操作', width: 46, align: 'center',
                formatter: function (value, row, index) {
                    var str = "";
                    var param = new Array();
                    param[0] = row.TargetDev;
                    param[1] = row.DataItemId;
                    param[2] = row.WorkNum;
                    param[3] = "communicationWarn";
                    switch (row.ProcessFlag) {
                        case 0:
                            str = "<a href='#' onclick='OffPolice_click(\"" + param + "\")' class='easyui-linkbutton' plain='true' title='' iconcls='icon-quench'></a>";
                            break;
                        case 1:
                        case 2:
                            str = "<a href='#' class='easyui-linkbutton' plain='true' title='' iconcls='icon-ok'></a>";
                            break;

                        default:
                    }
                    return str;
                }
            }
        ]],
        onLoadSuccess: function (data) {
            $($('#dg_communication_warn').datagrid("getPanel")).find('a.easyui-linkbutton').linkbutton();
            $("#communication_warn").panel("setTitle", "通信告警(通信异常<a class='linka' href='#' onclick='cmnum()'>" + data.status + "</a>个)");
        }
    });
}


/**
* *停电告警
**/
function powerFailure(zhanbh) {
    $('#dg_power_failure').datagrid({
        url: '../../WebService/WarnRecService.ashx',
        queryParams: { action: 'findbypowerfailure', zhanbh: zhanbh },
        fit: true,
        singleSelect: true,
        border: false,
        striped: true,
        columns: [[
            { field: 'Id', hidden: true },
            { field: 'OccurDt', title: '时间', align: 'center', width: 130 },
            { field: 'ZhanJc', title: '场站名称', align: 'center', width: 130 },
            //{ field: 'DtuName', title: 'DTU名称', align: 'center', width: 80 },
            { field: 'ycl', title: '已处理', align: 'center', width: 50,
                formatter: function (value, row, index) {
                    var str = "";
                    switch (row.ProcessFlag) {
                        case 0:
                            str = "否";
                            break;
                        case 1:
                        case 2:
                            str = "是";
                            break;

                        default:
                    }
                    return str;
                }
            },
         { field: 'content', title: '处理方式', align: 'center', width: 65,
             formatter: function (value, row, index) {
                 var str = row.ProcessFlag;
                 switch (str) {
                     case 0:
                         str = "等待灭警";
                         break;
                     case 1:
                         str = "自动灭警";
                         break;
                     case 2:
                         str = "人工灭警";
                         break;

                     default:
                 }
                 return str;
             }
         }, { field: 'ProcessFlag', title: '操作', width: 46, align: 'center',
             formatter: function (value, row, index) {
                 var str = "";
                 var param = new Array();
                 param[0] = row.TargetDev;
                 param[1] = row.DataItemId;
                 param[2] = row.WorkNum;
                 param[3] = "powerFailureWarn";
                 switch (row.ProcessFlag) {
                     case 0:
                         str = "<a href='#' onclick='OffPolice_click(\"" + param + "\")' class='easyui-linkbutton' plain='true' title='' iconcls='icon-quench'></a>";
                         break;
                     case 1:
                     case 2:
                         str = "<a href='#' class='easyui-linkbutton' plain='true' title='' iconcls='icon-ok'></a>";
                         break;

                     default:
                 }
                 return str;
             }
         }
        ]],
        onLoadSuccess: function (data) {
            $($('#dg_power_failure').datagrid("getPanel")).find('a.easyui-linkbutton').linkbutton();
            $("#power_failure").panel("setTitle", "停电告警(停电数量<a class='linka' href='#' onclick='pcnum()'>" + data.status + "</a>个)");
        }
    });
}


//----------------------------  页面事件  ---------------------------------

/**
* *保存告警处理界面
**/
function btn_ok() {
    var clcz = $("[name=r_gjcl]:checked").val();
    if (clcz == 1) {
        myurl = "../../WebService/WarnRecService.ashx";
        mydata = {
            action: "offPolice",
            warnid: $("#hidd_warnid").val(),
            warntype: $("#hidd_warntype").val()
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
    var warntype = $("#hidd_warntype").val();
    var clcz = $("[name=r_gjcl]:checked").val();
    if (clcz == 1) {
        InvokeWarn2(targetDev, dataItemId, workNum,warntype); //调用远程接口
    }
    btn_close();
}

/**
* *InvokeWarn.js文件ajax方法里success返回的方法之一
**/
function invokeWarn_return_success(resp, warntype) {
    //$.messager.alert('消息',JSON2.stringify(resp),"info");
    //调用成功，
    //$.messager.alert('消息', resp.success, "info"); //判断resp.success是否等于true，等于true则说明调用成功。继续执行其他操作。
    $.messager.alert('消息', "灭警成功！", "info");
    switch (warntype) {
        case "telesignallingWarn":
            telesignallingWarn();
            break;
        case "cardWarn":
            cardWarn();
            break;
        case "communicationWarn":
            communicationWarn();
            break;
        case "powerFailureWarn":
            powerFailure();
            break;
        default:
    }

}

/**
* *InvokeWarn.js文件ajax方法里success返回的方法之一
**/
function invokeWarn_return_error(resp, warntype) {
    //$.messager.alert('消息',JSON2.stringify(resp),"info");
    if (resp.message.length > 30) {
        $.messager.alert('消息', resp.message, "info");
    } else {
        $.messager.alert('消息', resp.message, "error");
    }
    switch (warntype) {
        case "telesignallingWarn":
            telesignallingWarn();
            break;
        case "cardWarn":
            cardWarn();
            break;
        case "communicationWarn":
            communicationWarn();
            break;
        case "powerFailureWarn":
            powerFailure();
            break;
        default:
    }
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
            switch (data.Msg) {
                case "telesignallingWarn":
                    telesignallingWarn();
                    break;
                case "cardWarn":
                    cardWarn();
                    break;
                case "communicationWarn":
                    communicationWarn();
                    break;
                case "powerFailureWarn":
                    powerFailure();
                    break;
                default:
            }
        default:
    }
}

/**
* *关闭告警处理界面
**/
function btn_close() {
    $('#dlg').dialog('close');
}

/**
* *打开告警处理界面
**/
function OffPolice_click(param) {
    $("#hidd_warnid").val("");
    $("#dlg").dialog("open");
    $("[name=r_gjcl]").eq(0).attr("checked", true);
    //$("#hidd_warnid").val(warnid);
    $("#hidd_TargetDev").val(param.split(',')[0]);
    $("#hidd_DataItemId").val(param.split(',')[1]);
    $("#hidd_WorkNum").val(param.split(',')[2]);
    $("#hidd_warntype").val(param.split(',')[3]);
}


//----------------------------  ajax方法  ---------------------------------

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