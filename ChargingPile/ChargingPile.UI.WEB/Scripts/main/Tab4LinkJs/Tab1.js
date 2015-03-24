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
    queryParams: { action: 'findbyrankzje2', kssj: '', jssj: '' },
    pagination: true,
    pageSize: 20,
    fit: true,
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
    rank_obj.queryParams.action = 'findbyrankzje2';
    rank_obj.queryParams.kssj = $("#begintime").val();
    rank_obj.queryParams.jssj = $("#endtime").val();
    rank_obj.columns = [[
        { field: 'RowNum', title: '序号', align: 'center', width: 42 },
        { field: 'ZhanJc', title: '场站简称', align: 'center', width: 140 },
        { field: 'Zje', title: '充电总金额(￥)', align: 'center', width: 110,
            formatter: function (value, row, index) {
                if (row.Zje == null) {
                    return 0;
                }
                return row.Zje;
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