var myurl;
var mydata;
var mytype = "POST";
var jsonType = "json";
var htmlType = "html";
var commonType = "application/json; charset=utf-8";
var editIndex = undefined;
var _type = "";
var _timespan = 100;

var option_chargpile_state =
{
    toolbar: '#tb',
    fit: true,
    striped: true,
    fitColumns: true,
    queryParams: { action: 'getchargpilestate', csid: '' },
    url: '../../webservice/RemoteControlService.ashx',
    columns: [[
                { field: 'ck', checkbox: true },
                { field: 'ZID', title: '桩编号', align: 'center', width: 80,hidden:true},
                { field: 'YXID', title: '桩运行编号', align: 'center', width: 80 },
                { field: 'CJ', title: '桩厂家', align: 'center', width: 200 },
                { field: 'ZLX', title: '桩类型', align: 'center', width: 100 },
                { field: 'ZHUANGTAI', title: '桩状态', align: 'center', width: 120 }


        ]]
};

var option_chargpile_stated =
{
    height: 330,
    width: 400,
    border: false,
    striped: true,
    rownumbers: true,
    fitColumns: true,
    columns: [[
                { field: 'ck', checkbox: true },
                { field: 'ZID', title: '桩编号', align: 'center', width: 150 },
                {
                    field: 'SUCCESS',
                    title: '操作结果',
                    align: 'center',
                    width: 100,
                    formatter: function (value, row, index) {
                        var message = row.MESSAGE;
                        var regexp = /\B'|'\B/g;
                        message = message.replace(regexp, "");
                        if (row.SUCCESS == "失败") {
                            return '<a href="javascript:message_click(\'' + message + '\')">' + value + '</a>';
                        }
                        return value;
                    }
                }
        ]],
    onLoadSuccess: onLoadSuccess
};

//------------------------------------------------------
$(function () {
    initDlg();
    inittable();
    bindChargStation();
    var progressbar = $("#progressbar");
    var progressLabel = $(".progress-label");

    progressbar.progressbar({
        value: false,
        change: function () {
            progressLabel.text(progressbar.progressbar("value") + "%");
        },
        complete: function () {
            progressLabel.text("完成!");
        }
    });
    setprogresscolor();
});
function progress() {
    var progressbar = $("#progressbar");
    //var progressLabel = $(".progress-label");
    var val = progressbar.progressbar("value") || 0;

    progressbar.progressbar("value", val + 1);

    if (val < 99) {
        setTimeout(progress, 1000 * _timespan);
    } else {
        $('#dlgprogress').dialog('close');
        $('#dgchargpile').datagrid('reload');
    }
}

function setprogresscolor() {
    var progressbar = $("#progressbar");
    var progressbarValue = progressbar.find(".ui-progressbar-value");
    progressbarValue.css({
        "background": '#fbec88'
    });
}

function initDlg() {
    $('#dlg').dialog({
        title: '操作结果',
        width: 430,
        height: 400,
        modal: true,
        closed: true
    });

    $('#dlgprogress').dialog({
        title: ' ',
        width: 500,
        height: 150,
        modal: true,
        closed: true
    });
}

function inittable() {
    $('#dgchargpile').datagrid(option_chargpile_state);
}

function inittabled(data) {
    $('#dg_chargpile_stated').datagrid(option_chargpile_stated);
    $('#dg_chargpile_stated').datagrid("loadData", data);
}

function bindChargStation() {
    myurl = "../../WebService/RemoteControlService.ashx";
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


//--------------------------------------------------------

function onLoadSuccess(data) {
    var success = 0, faile = 0;
    for (var i = 0; i < data.rows.length; i++) {
        if (data.rows[i].SUCCESS == "成功") {
            success++;
        } else {
            faile++;
        }
    }

    $("#txtSuccess").val(success);
    $("#txtFaile").val(faile);
}

function btnReturn_click() {
    $('#dlg').dialog('close');
    $('#dgchargpile').datagrid('reload');
}

// 继续操作
function btnOk_click() {
    _timespan = 0;
    var zid = "";
    var selectrows = $("#dg_chargpile_stated").datagrid("getChecked");
    if (selectrows.length == 0) {
        $.messager.alert("提示", "你没有选择任何数据！");
        //        $.messager.show({
        //            title: '提示',
        //            msg: '你没有选择任何数据！',
        //            showType: 'slide'
        //        });
        return false;
    }
    _timespan = selectrows.length;
    for (var i = 0; i < selectrows.length; i++) {
        switch (_type) {
            case "Start":
                if (selectrows[i].SUCCESS == '成功') {
                    $.messager.alert("提示", "桩编号为" + selectrows[i].ZID + "已成功投运,请重新选择！！");
                    //                    $.messager.show({
                    //                        title: '提示',
                    //                        msg: "桩编号为" + selectrows[i].ZID + "已成功投运,请重新选择！",
                    //                        showType: 'slide'
                    //                    });
                    return false;
                }
                break;
            case "Stop":
                if (selectrows[i].SUCCESS == '成功') {
                    $.messager.alert("提示", "桩编号为" + selectrows[i].ZID + "已停止投运,请重新选择！");
                    //                    $.messager.show({
                    //                        title: '提示',
                    //                        msg: "桩编号为" + selectrows[i].ZID + "已停止投运,请重新选择！",
                    //                        showType: 'slide'
                    //                    });
                    return false;
                }
                break;
            default:
        }
        zid += selectrows[i].ZID + "|";
    }
    zid = zid.substring(0, zid.length - 1);
    $('#dlg').dialog('close');
    $('#dgchargpile').datagrid('reload');
    $('#dlgprogress').dialog('open').dialog('setTitle', '显示');


    var progressbar = $("#progressbar");
    progressbar.progressbar("value", 0);
    progress();
    myurl = "StartStopManage.aspx/StartOrStop";
    mydata = "{'chargpileid':'" + zid + "','type':'" + _type + "'}";
    remotecontrol();
    return true;
}

function message_click(message) {
    $.messager.alert("提示", message);
    //    $.messager.show({
    //        title: '提示',
    //        msg: message,
    //        showType: 'slide'
    //    });
}

function chargstation_onchanged() {
    $('#dgchargpile').datagrid('load', {
        action: 'getchargpilestate',
        csid: $('#chargstation').val()
    });
}

function btnStart_click() {
    alert("南瑞和许继充电桩厂家未按协议实现，无法使用该功能！");
    return false;

    _timespan = 0;
    _type = "Start";
    var zid = "";
    var selectrows = $("#dgchargpile").datagrid("getChecked");
    if (selectrows.length == 0) {
        $.messager.alert("提示", "你没有选择任何数据！");
        //        $.messager.show({
        //            title: '提示',
        //            msg: '你没有选择任何数据！',
        //            showType: 'slide'
        //        });
        return false;
    }

    _timespan = selectrows.length;
    for (var i = 0; i < selectrows.length; i++) {
        if (selectrows[i].ZHUANGTAI == '已投运') {
            $.messager.alert("提示", "桩编号为" + selectrows[i].ZID + "已投运,请重新选择！");
            //            $.messager.show({
            //                title: '提示',
            //                msg: "桩编号为" + selectrows[i].ZID + "已投运,请重新选择！",
            //                showType: 'slide'
            //            });
            return false;
        }
        zid += selectrows[i].ZID + "|";
    }
    zid = zid.substring(0, zid.length - 1);
    $('#dlgprogress').dialog('open').dialog('setTitle', '显示');


    var progressbar = $("#progressbar");
    progressbar.progressbar("value", 0);
    progress();
    myurl = "StartStopManage.aspx/StartOrStop";
    mydata = "{'chargpileid':'" + zid + "','type':'Start'}";
    remotecontrol();
    return true;
}

function btnStop_click() {
    alert("该充电桩厂家未按协议实现，无法使用该功能！");
    return false;

    _timespan = 0;
    _type = "Stop";
    var zid = "";
    var selectrows = $("#dgchargpile").datagrid("getChecked");
    if (selectrows.length == 0) {
        $.messager.alert("提示", "你没有选择任何数据！");
        //        $.messager.show({
        //            title: '提示',
        //            msg: '你没有选择任何数据！',
        //            showType: 'slide'
        //        });
        return false;
    }

    _timespan = selectrows.length;
    for (var i = 0; i < selectrows.length; i++) {
        if (selectrows[i].ZHUANGTAI == '未投运') {
            $.messager.alert("提示", "桩编号为" + selectrows[i].ZID + "已处于未投运状态,请重新选择！");
            //            $.messager.show({
            //                title: '提示',
            //                msg: "桩编号为" + selectrows[i].ZID + "已处于未投运状态,请重新选择！",
            //                showType: 'slide'
            //            });
            return false;
        }
        zid += selectrows[i].ZID + "|";
    }
    zid = zid.substring(0, zid.length - 1);
    $('#dlgprogress').dialog('open').dialog('setTitle', '显示');


    var progressbar = $("#progressbar");
    progressbar.progressbar("value", 0);
    progress();
    myurl = "StartStopManage.aspx/StartOrStop";
    mydata = "{'chargpileid':'" + zid + "','type':'Stop'}";
    remotecontrol();
    return true;
}

//function btnPause_click() {

//    var zid = "";
//    var selectrows = $("#dgchargpile").datagrid("getChecked");
//    if (selectrows.length == 0) {
//        $.messager.show({
//            title: '提示',
//            msg: '你没有选择任何数据！',
//            showType: 'slide'
//        });
//        return false;
//    }


//    for (var i = 0; i < selectrows.length; i++) {
//        if (selectrows[i].ZHUANGTAI == '未投运') {
//            $.messager.show({
//                title: '提示',
//                msg: "桩编号为" + selectrows[i].ZID + "未投运,不能暂停,请重新选择！",
//                showType: 'slide'
//            });
//            return false;
//        }
//        zid += selectrows[i].ZID + "|";
//    }
//    zid = zid.substring(0, zid.length - 1);
//    myurl = "../../WebService/PriceAdjustmentService.ashx";
//    mydata = {
//        action: "",
//        cdzmc: $("#chargstation option:selected").text(),
//        zid: zid
//    };


//}

function btnCancel_click() {
}

//---------------------------------------------------------


function remotecontrol() {
    var progressbar = $("#progressbar");
    $.ajax({
        url: myurl,
        type: mytype,
        data: mydata,
        contentType: commonType,
        dataType: jsonType,
        success: function (data) {
            var ret = data.d.replace(/\r\n/ig, "<br \/>");
            var obj = eval('(' + ret + ')'); //转换后的JSON对象
            //if (obj.success) {
            progressbar.progressbar("value", 100);
            $('#dlgprogress').dialog('close');
            inittabled(obj);
            $('#dlg').dialog('open').dialog('setTitle', '操作结果');
            //            } else {
            //                $.messager.show({
            //                    title: '提示',
            //                    msg: obj.message,
            //                    showType: 'slide'
            //                });
            //                $('#dlgprogress').dialog('close');
            //            }
        },
        error: function () {
            //            $.messager.show({
            //                title: '提示',
            //                msg: "error",
            //                showType: 'slide'
            //            });
            $('#dlgprogress').dialog('close');
        }
    });

}

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
            //$.messager.alert("提示", "error");
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
                case "exist":
                    $.messager.alert("提示", "该期刊号已经存在！");
                    break;
                default:
            }
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            //$.messager.alert("提示", "error");
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