var myurl;
var mydata;
var postype = "POST";
var getype = "GET";
var jsontype = "json";
var htmltype = "html";
var contentype = "application/json; charset=utf-8";

//----------------------------  初始化  ---------------------------------
$(function () {
    //TODO:这个电场名称是？
    var dotype = getQueryString("dotype");
    $("#hidden").val(dotype);
    var zhanbh = getQueryString("zhanbh");
    bindWarnType(); //绑定站告警类型select
    bindZhanMc(); //绑定站名称select
    bindZhanYxBh(dotype); //绑定桩运行编号select
    zhanname_onchanged(); //站名称和站运行编号联动
    setDateTime(dotype); //设置起始时间和结束时间(如果从当日实时告警点[更多]链接进来，开始、结束时间默认当日)
    realTimeWarnQuery(dotype); //初始化datagrid
    //如果进入具体场站，仅显示当前场站告警信息(此时，场站名称不可选择)
    setDom(zhanbh);
    bindDoTypeAndQuery(dotype); //根据type绑定处理方式(如果从当日实时告警点[待灭警数量]链接进来，处理结果默认条件为“等待灭警”  )
});
/**
* *设置datagrid对象
**/
var dgObj = {
    url: '../../WebService/WarnRecService.ashx',
    queryParams: { action: 'findbytelesignallingwarn2', warnType: '', zhanBh: '', yunXinBh: '', kssj: '', jssj: '', clfs: '' },
    fit: true,
    pagination: true,
    pageSize: 20,
    singleSelect: true,
    border: false,
    striped: true,
    toolbar: "#tb",
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
        {
            field: 'content',
            title: '处理方式',
            align: 'center',
            width: 100,
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
        {
            field: 'ProcessFlag',
            title: '操作',
            width: 60,
            align: 'center',
            formatter: function (value, row, index) {
                var str = "";
                var param = new Array();
                param[0] = row.TargetDev;
                param[1] = row.DataItemId;
                param[2] = row.WorkNum;
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
    onLoadSuccess: function () {
        $($('#dg').datagrid("getPanel")).find('a.easyui-linkbutton').linkbutton();
    }
};

//----------------------------  页面方法  ---------------------------------
/*
* *根据type绑定处理方式
*/
function bindDoTypeAndQuery(type) {
    if (type == "0") {
        $("#sel-dotype").val(type);
        btn_query();
    } else if (type == "more" || type == "more#") {
        btn_query();
    }
}

/*
* *如果进入具体场站，仅显示当前场站告警信息(此时，场站名称不可选择)
*/
function setDom(zhanbh) {
    if (zhanbh.length != 0) {
        $("#sel-zhanname").val(zhanbh);
        $("#sel-zhanname").attr("disabled", true);
        myurl = "../../WebService/WarnRecService.ashx";
        mydata = { action: 'getxunxingbh', zhanBh: zhanBh };
        ajaxData();
    }
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
* *初始化datagrid
**/
function realTimeWarnQuery(dotype) {
    var kssj = $("#begintime").val();
    var jssj = $("#endtime").val();
    dgObj.queryParams.kssj = kssj;
    dgObj.queryParams.jssj = jssj;

    $('#dg').datagrid(dgObj);
    if (dotype == "hidden" || dotype == "hidden#") {
        $('#dg').datagrid("hideColumn", "ProcessFlag");
    }
}

/**
* *设置起始时间和结束时间
**/
function setDateTime(type) {
    var date = new Date();
    var months = new Array("01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12");
    var year = date.getFullYear();
    var month = months[date.getMonth()];
    var day = "01";
    switch (type) {
        case "0":
            //$("#begintime").val("—请选择—");
            //day = date.getDate();
            //$("#endtime").val(year + "-" + month + "-" + day);
            break;
        case "more":
            day = date.getDate();
            $("#begintime").val(year + "-" + month + "-" + day);
            $("#endtime").val(year + "-" + month + "-" + day);
            break;
        case "more#":
            day = date.getDate();
            $("#begintime").val(year + "-" + month + "-" + day);
            $("#endtime").val(year + "-" + month + "-" + day);
            break;
        case "":
            $("#begintime").val(year + "-" + month + "-" + day);
            day = date.getDate();
            $("#endtime").val(year + "-" + month + "-" + day);
            break;
        case "hidden":
            $("#begintime").val(year + "-" + month + "-" + day);
            day = date.getDate();
            $("#endtime").val(year + "-" + month + "-" + day);
            break;
        case "hidden#":
            $("#begintime").val(year + "-" + month + "-" + day);
            day = date.getDate();
            $("#endtime").val(year + "-" + month + "-" + day);
            break;
        default:
    }

}

/**
* *绑定站告警类型select
**/
function bindWarnType() {
    myurl = "../../WebService/WarnRecService.ashx";
    mydata = { action: 'GetWarnType' };
    ajaxData();
}

/**
* *绑定桩运行编号select
**/
function bindZhanYxBh(type) {
    $("#sel-yunxingbh").empty();
    $("#sel-yunxingbh").append("<option value=''>—请选择—</option>");
}

/**
* *ajax成功返回
* *绑定站告警类型select
**/
function ajaxSuccess_bindWarnType(data) {
    if (data.Rows.length <= 0 || data == null) {
        return false;
    }
    $("#sel-warntype").empty();
    var l = data.Rows.length;
    $("#sel-warntype").append("<option value=''>—请选择—</option>");
    for (var i = 0; i < l; i++) {
        $("#sel-warntype").append("<option value='" + data.Rows[i].Code + "'>" + data.Rows[i].Codename + "</option>");
    }
    return true;
}

/**
* *绑定站名称select
**/
function bindZhanMc(zhanbh) {
    myurl = "../../WebService/WarnRecService.ashx";
    mydata = { action: 'getzhanmc' };
    ajaxData();
}

/**
* *ajax成功返回
* *绑定站名称select
**/
function ajaxSuccess_bindZhanMc(data) {
    if (data.Rows.length <= 0 || data == null) {
        return false;
    }
    $("#sel-zhanname").empty();
    var l = data.Rows.length;
    $("#sel-zhanname").append("<option value=''>—请选择—</option>");
    for (var i = 0; i < l; i++) {
        $("#sel-zhanname").append("<option value='" + data.Rows[i].Zhan_Bh + "'>" + data.Rows[i].Zhan_Jc + "</option>");
    }
    return true;
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
            warnid: $("#hidd_warnid").val()
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
    //$.messager.alert('消息', resp.success, "info"); //判断resp.success是否等于true，等于true则说明调用成功。继续执行其他操作。
    $.messager.alert('消息', "灭警成功！", "info");
    $('#dg').datagrid("reload");
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
    $('#dg').datagrid("reload");
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
            $('#dg').datagrid("reload");
            break;

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
}

/**
* *站名称和站运行编号联动
**/
function zhanname_onchanged() {
    $("#sel-zhanname").change(function () {
        var zhanBh = $("#sel-zhanname").val();
        if (zhanBh.length == 0) {
            bindZhanYxBh();
            return false;
        }
        myurl = "../../WebService/WarnRecService.ashx";
        mydata = { action: 'getxunxingbh', zhanBh: zhanBh };
        ajaxData();
        return true;
    });
}

/**
* *ajax成功返回
* *绑定运行编号select
**/
function ajaxSuccess_bindXunXinBh(data) {
    if (data.Rows.length <= 0 || data == null) {
        return false;
    }
    $("#sel-yunxingbh").empty();
    var l = data.Rows.length;
    $("#sel-yunxingbh").append("<option value=''>—请选择—</option>");
    for (var i = 0; i < l; i++) {
        if (data.Rows[i].YUNXING_BH == null) {
            continue;
        }
        $("#sel-yunxingbh").append("<option value='" + data.Rows[i].YUNXING_BH + "'>" + data.Rows[i].YUNXING_BH + "</option>");
    }
    return true;
}

/**
* *点击查询
**/
function btn_query() {
    var warntype = $("#sel-warntype").val(); var zhanBh = $("#sel-zhanname").val(); var yunXinbh = $("#sel-yunxingbh").val();
    var kssj = $("#begintime").val(); var jssj = $("#endtime").val(); var clfs = $("#sel-dotype").val();
    dgObj.queryParams.warnType = warntype;
    dgObj.queryParams.zhanBh = zhanBh;
    dgObj.queryParams.yunXinBh = yunXinbh;
    dgObj.queryParams.kssj = kssj;
    dgObj.queryParams.jssj = jssj;
    dgObj.queryParams.clfs = clfs;
    $('#dg').datagrid(dgObj);
    var hidden = $("#hidden").val();
    if (hidden == "hidden" || hidden == "hidden#") {
        $('#dg').datagrid("hideColumn", "ProcessFlag");
    }
}

//----------------------------  ajax方法  ---------------------------------

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