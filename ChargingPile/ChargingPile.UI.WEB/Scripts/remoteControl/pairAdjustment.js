var myurl;
var mydata;
var mytype = "POST";
var jsonType = "json";
var htmlType = "html";
var commonType = "application/json; charset=utf-8";
var editIndex = undefined;

var option_chargpileprice = {
    height: 330,
    width: 620,
    fitColumns: true,
    border: true,
    striped: true,
    queryParams: { action: 'getchargpilepair', csid: '' },
    url: '../../webservice/PairAdjustmentService.ashx',
    columns: [[
            { field: 'ck', checkbox: true },
            { field: 'DTUNAME', title: 'DTU名称 ', align: 'center', width: 150 },
            { field: 'ZID', title: '桩编号', align: 'center', width: 80 }, 
            { field: 'YXID', title: '运行编号', align: 'center', width: 80 },
            { field: 'CJ', title: '桩厂家', align: 'center', width: 200 },
            { field: 'ZXH', title: '桩型号', align: 'center', width: 120 },
            { field: 'ZLX', title: '桩类型', align: 'center', width: 100 }
    //            { field: 'Status', title: '峰单价', align: 'center', width: 80 },
    //            { field: 'Status2', title: '谷单价', align: 'center', width: 80 },
    //            { field: 'Status3', title: '平单价', align: 'center', width: 80 },
    //            { field: 'Status4', title: '尖单价', align: 'center', width: 80 }
        ]]
};

var option_schedule_detail = {
    height: 330,
    width: 630,
    border: false,
    striped: true,
    singleSelect: true,
    queryParams: { action: 'getschedultdetail', taskid: '' },
    url: '../../webservice/PairAdjustmentService.ashx',
    columns: [[
            { field: 'ZID', title: '桩编号', align: 'center', width: 80 },
            { field: 'YXID', title: '运行编号', align: 'center', width: 80 },
            { field: 'CJ', title: '桩厂家', align: 'center', width: 80 },
            { field: 'ZXH', title: '桩型号', align: 'center', width: 80 },
            { field: 'ZLX', title: '桩类型', align: 'center', width: 150 },
            { field: 'RUNDT', title: '执行时间', align: 'center', width: 130 },
            { field: 'RESULT', title: '执行结果', align: 'center', width: 80 }
        ]]
};

//-------------------------------------------------------------------------------------------------

$(function () {
    initDlg();
    initScheduleTable();
});

function btnAdd_click() {
    $('#dlg').dialog('open').dialog('setTitle', '添加远程对时计划');
    initSchedulePriceTable();
    bindChargStation();
    bindTime();
}

function bindTime() {
    myurl = "../../WebService/Common.ashx?action=getdatetime";
    mydata = {};
    var getDate = getData();
    $("#zxsj").val(getDate.h1ago);
}

function chargstation_onchanged() {
    $('#dg_schedule_pair').datagrid('load', {
        action: 'getchargpilepair',
        csid: $('#chargstation').val()
    });
}

function btnSave_click() {
    var zid = "";
    var selectrows = $("#dg_schedule_pair").datagrid("getChecked");
    if (selectrows.length == 0) {
        $.messager.alert("提示", "你没有选择任何数据！");
        return false;
    }
    for (var i = 0; i < selectrows.length; i++) {
        zid += selectrows[i].ZID + "|";
    }
    zid = zid.substring(0, zid.length - 1);

    var objRadios = document.getElementsByName("radios");
    var strSort = "";
    var runtime;
    for (var i = 0; i < objRadios.length; i++) {
        if (objRadios[i].checked == true) {
            strSort = objRadios[i].value;
            if (strSort == "once") {
                runtime = $("#zxsj").val();
            }
            if (strSort == "day") {
                runtime = $("#day").val();
            }
        }
    }
    if (strSort == "") {
        $.messager.alert("提示", "请选择类型！");
        return;
    }
    if (runtime == "") {
        $.messager.alert("提示", "请选择时间！");
        return;
    }
    myurl = "../../WebService/PairAdjustmentService.ashx";
    mydata = {
        action: "saveScheduleJobs",
        cdzmc: $("#chargstation option:selected").text(),
        zid: zid,
        runtime: runtime,
        sort: strSort
    };
    saveData();
    btnCancel_click();
    $('#dg_schedule').datagrid('reload');
    return true;
}

function btnCancel_click() {
    $('#dlg').dialog('close');
    $("#zxsj").val("");
}

function btnCancel2_click() {
    $('#dlg_schedule_detail').dialog('close');
}

function bindChargStation() {
    myurl = "../../WebService/PairAdjustmentService.ashx";
    mydata = { action: 'getChargStation' };
    var data = getData();
    $("#chargstation").empty();
    var length = data.rows.length;
    $("#chargstation").append("<option value='0'>—请选择—</option>");
    if (length == 0) {
        return;
    }
    for (var i = 0; i < length; i++) {
        $("#chargstation").append("<option value='" + data.rows[i].ZHAN_BH + "'>" + data.rows[i].ZHUAN_MC + "</option>");
    }
}

function initDlg() {
    $('#dlg').dialog({
        title: '远程对时计划',
        width: 650,
        height: 480,
        modal: true,
        closed: true
    });
    $('#dlg_schedule_detail').dialog({
        title: '计划明细执行结果',
        width: 650,
        height: 480,
        modal: true,
        closed: true
    });
}

function initScheduleTable() {
    $('#dg_schedule').datagrid({
        pagination: true,
        fitColumns: true,
        pageSize: 20,
        toolbar: '#tb',
        singleSelect: true,
        fit: true,
        rownumbers: true,
        title: "远控远调>>远程对时",
        queryParams: { action: 'inittable', cmdtype: 'AdjustDate' },
        url: '../../webservice/PairAdjustmentService.ashx',
        columns: [[
            { field: 'ID', hidden: true },
            { field: 'TASKNAME', title: '计划名称', align: 'center', width: 300 },
            { field: 'REMARK', title: '计划执行频率', align: 'center', width: 300 },
            { field: 'TASKSTATE', title: '状态', align: 'center', width: 200 }
//            { field: 'rate',
//                title: '执行率',
//                align: 'center',
//                width: 150,
//                formatter: function (value, row, index) {
//                    return '<a href="javascript:rate_click(\'' + row.ID + '\',\'' + row.TASKNAME + '\')">' + value + '%</a>';
//                }
//            }
        ]]
    });
}

function rate_click(taskid, taskname) {
    $('#dlg_schedule_detail').dialog('open').dialog('setTitle', '计划明细执行结果');
    initScheduleDetailTable(taskid, taskname);
}

function initScheduleDetailTable(taskid, taskname) {
    $("#txtTaskName").val(taskname);
    option_schedule_detail.queryParams.taskid = taskid;
    $('#dg_schedule_detail').datagrid(option_schedule_detail);
}

function initSchedulePriceTable() {
    $('#dg_schedule_pair').datagrid(option_chargpileprice);
}
//----------------------------------------------------------------------------------------------------

function getData() {
    var value;
    $.ajax({
        url: myurl,
        type: mytype,
        async: false,
        data: mydata,
        dataType: htmlType,
        success: function (data) {
            if (data) {
                var val = "";
                var ret = data.split("|")[0];
                eval("val=" + ret);
                var res = data.split("|")[1];
                if (ret == "0") {
                    value = "0";
                } else {
                    value = val;
                }
            }
        },
        error: function () {
            $.messager.alert("提示", "error");
        }
    });
    return value;
}

function saveData() {
    var value;
    $.ajax({
        url: myurl,
        type: mytype,
        async: false,
        data: mydata,
        success: function (data) {
            value = data;
            switch (value) {
                case "true":
                    $.messager.alert("提示", "保存成功！");
                    break;
                case "false":
                    $.messager.alert("提示", "保存失败！");
                    break;
                case "2":
                    setTimeout(function () { location.href = "../../Login.aspx"; }, 4000);
                    $.messager.alert("提示", "--登录过期，即将跳转到登陆页。");
                    break;
                case "exist":
                    $.messager.alert("提示", "该期刊号已经存在！");
                    break;
                default:
            }
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            $.messager.alert("提示", "error");
        }
    });
    switch (value) {
        case "true":
            return true;
        case "false":
            return false;
        case "exist":
            return "exist";
        default:
            return false;
    }
}