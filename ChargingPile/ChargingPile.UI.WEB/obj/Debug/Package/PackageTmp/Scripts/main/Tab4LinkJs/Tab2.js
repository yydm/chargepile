var myurl;
var mydata;
var postype = "POST";
var getype = "GET";
var jsontype = "json";
var htmltype = "html";
var contentype = "application/json; charset=utf-8";

//----------------------------  初始化  ---------------------------------
$(function () {
    rankZje(); //初始化datagrid
});
/**
* *设置datagrid对象
**/
var rank_obj = {
    url: '../../../WebService/IndexService.ashx',
    queryParams: { action: 'FindByRankAvgZdl2', kssj: '', jssj: '' },
    fit: true,
    pagination: true,
    pageSize: 20,
    singleSelect: true,
    fitColumns: true,
    border: false,
    striped: true,
    toolbar: "#tb"
};

//----------------------------  页面方法  ---------------------------------

/**
* *按充电总金额
**/
function rankZje() {
    rank_obj.queryParams.action = 'FindByRankAvgZdl2';
    rank_obj.columns = [[
       { field: 'RowNum', title: '序号', align: 'center', width: 42 },
        { field: 'ZhanJc', title: '场站简称', align: 'center', width: 140 },
        { field: 'Pjcdl', title: '平均充电量(KWH）', align: 'center', width: 110,
            formatter: function (value, row, index) {
                if (row.Pjcdl == null) {
                    return 0;
                }
                return row.Pjcdl;
            }
        }
    ]];
    $('#dg').datagrid(rank_obj);
}


//----------------------------  页面事件  ---------------------------------

/**
* *点击查询
**/
function btn_query() {
    var kssj = $("#begintime").val();
    var jssj = $("#endtime").val();
    if (kssj.length == 0 || jssj.length == 0) {
        $.messager.alert("提示", "请选择开始时间和结束时间！");
        return;
    }
    rank_obj.queryParams.kssj = kssj;
    rank_obj.queryParams.jssj = jssj;
    $('#dg').datagrid(rank_obj);
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