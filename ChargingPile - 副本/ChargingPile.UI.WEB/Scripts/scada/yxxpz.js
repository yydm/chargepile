var mb = ""; //模板
var sub = false; //是否在提交数据
var editStatus = "add"; //编辑状态
var dxmbStatic = "【充电站简称】【装编号】桩，【数据项】【告警原因】，请及时处理。";
var yjmbStatic = "充电站管理员，你好：\r\n    【充电站简称】【装编号】桩，【数据项】【告警原因】，请及时处理。 \r\n----------------------------------------\r\n合肥供电公司\r\n【告警时间】";

$(function () {
    //主表加载数据
    $("#t_yxx").datagrid({
        url: "../../WebService/Yxxpz.ashx",
        queryParams: {
            action: "getYxxData",
            r: Math.random()
        },
        fit: true,
        //fitColumns: true,
        singleSelect: true,
        rownumbers: true,
        toolbar: "#d_tb",
        pageSize: 20,
        pagination: true,
        striped: true,
        border: false,
        columns: [[
            { field: "Id", title: "Id", hidden: true },
            { field: "Zhuangcj", title: "桩厂家", align: "center", width: 80 },
            { field: "PileTypeId", title: "桩型号", align: "center", width: 100 },
            { field: "ZhuangLeiX", title: "桩类型", align: "center", width: 120 },
            { field: "GatItemName", title: "数据项", align: "center", width: 120 },
            {
                field: "YxStates",
                title: "状态值",
                align: "center",
                width: 100,
                formatter: function (val, src) {
                    if (null == val || (val + "").length == 0) {
                        return "—";
                    } else {
                        return val;
                    }
                }
            },
            {
                field: "YxEff",
                title: "正常值",
                align: "center",
                width: 100,
                formatter: function (val, src) {
                    if (null == val || (val + "").length == 0) {
                        return "—";
                    } else {
                        return val;
                    }
                }
            },
            {
                field: "YxWarn",
                title: "告警值",
                align: "center",
                width: 100,
                formatter: function (val, src) {
                    if (null == val || (val + "").length == 0) {
                        return "—";
                    } else {
                        return val;
                    }
                }
            },
            {
                field: "IsOverLimtWarn",
                title: "超阈值告警",
                align: "center",
                width: 80,
                formatter: function (val, src) {
                    if (val == 1) {
                        return "是";
                    } else {
                        return "否";
                    }
                }
            },
            {
                field: "IsUse",
                title: "是否启用",
                align: "center",
                width: 80,
                formatter: function (val, src) {
                    if (val == 1) {
                        return "是";
                    } else {
                        return "否";
                    }
                }
            },
            {
                field: 'action1',
                title: '操作',
                width: 80,
                align: 'center',
                formatter: function (value, row, index) {
                    return '<a href="#" title="编辑" onclick="yxxEdit(\'' + row.Id + '\')" class="easyui-linkbutton" plain="true" iconcls="icon-edit"></a>'
                        + '<a href="#" title="删除" onclick="yxxDel(\'' + row.Id + '\')" class="easyui-linkbutton" plain="true" iconcls="icon-cancel"></a>';
                }
            }
        ]],
        onLoadSuccess: function () {
            $('#t_yxx').datagrid("getPanel").find('a.easyui-linkbutton').linkbutton();
        }
    });
    //加载厂家
    $.getJSON("../../WebService/Yxxpz.ashx",
        { action: "getChangJia", r: Math.random() },
        function (data) {
            for (var i = 0; i < data.length; i++) {
                $("#s_zcj").append("<option>" + data[i].CHANGJIA + "</option>");
            }
        });

    $.getJSON("../../WebService/Yxxpz.ashx",
            { action: "getXhByChangJia", changjia: "", r: Math.random() },
            function (data) {
                $("#s_xh").html("<option value='' >—请选择—</option>");
                for (var i = 0; i < data.length; i++) {
                    $("#s_xh").append("<option value='" + data[i].PARSERKEY + "'>" + data[i].PARSERKEY + "</option>");
                }
            });
    //桩厂家与桩型号联动
    $("#s_zcj").change(function () {
        $.getJSON("../../WebService/Yxxpz.ashx",
            { action: "getXhByChangJia", changjia: $("#s_zcj").val(), r: Math.random() },
            function (data) {
                $("#s_zxh").html("<option value='0' >—请选择—</option>");
                for (var i = 0; i < data.length; i++) {
                    $("#s_zxh").append("<option value='" + data[i].ZHUANGLEI_X + "'>" + data[i].PARSERKEY + "</option>");
                }
            });
        $("#i_zlx").val("");
        $("#s_sjx").html("<option value='0' >—请选择—</option>");
    });
    //桩型号与桩类型联动
    $("#s_zxh").change(function () {
        $("#i_zlx").val($("#s_zxh").val() == "0" ? "" : $("#s_zxh").val());
        //编辑时需要添加改配置的数据项+未使用的数据项
        $.getJSON("../../WebService/Yxxpz.ashx",
        { action: "getSjx", dataType: "YX", zhuangxing_h: $("#s_zxh").find("option:selected").text(), r: Math.random() },
        function (data) {
            $("#s_sjx").html("<option value='0' >—请选择—</option>");
            for (var i = 0; i < data.length; i++) {
                $("#s_sjx").append("<option value='" + data[i].ITEMNO + "'>" + data[i].ITEMNAME + "</option>");
            }
        });
    });

    $("[name=i_cyzgj]").change(function () {
        if (this.value == "1") {
            $("#tr_gj").find("input").attr("disabled", false);
        } else {
            $("#tr_gj").find("input").attr("disabled", true);
        }
    });

    $("[name=i_sfzdmj]").change(function () {
        if (this.value == "1") {
            $("#s_zdmjgz").attr("disabled", false);
        } else {
            $("#s_zdmjgz").attr("disabled", true);
        }
    });
});

function yxxAdd() {
    $("#dlg_yxx").dialog("open");
    editStatus = "add";
    formReset(); //重置表单所有数据及状态
    return false;
}
//数据查询
function yxxQuery() {
    $("#t_yxx").datagrid("reload", {
        action: "GetYxxData",
        xh: $("#s_xh").val(),
        sjx: $("#i_sjx").val(),
        r: Math.random()
    });
}

//数据项配置编辑
function yxxEdit(id) {
    sub = true;
    $.getJSON("../../WebService/Yxxpz.ashx",
        { action: "GetSjxpz", id: id, r: Math.random() },
        function (data) {
            if (!data.Id) {
                $.messager.alert("提示", "获取数据出错。");
                return false;
            }
            $("#h_id").val(data.Id);
            $("#s_zcj").val(data.Zhuangcj).attr("disabled", true);
            $("#s_zxh").html("<option>" + data.PileTypeId + "</option>").attr("disabled", true);
            $("#i_zlx").val(data.ZhuangLeiX).attr("disabled", true);
            $("#s_sjx").html("<option>" + data.GatItemName + "</option>").attr("disabled", true);
            if (!data.YxStates || (data.YxStates + "").length == 0) {
                $("#i_ztz").val("");
            } else {
                $("#i_ztz").val(data.YxStates);
            }
//            if (!data.YxEff || (data.YxEff + "").length == 0) {
//                $("#i_sbzcz").val("");
//            } else {
//                $("#i_sbzcz").val(data.YxEff);
//            }
            if (!data.YxWarn || (data.YxWarn + "").length == 0) {
                $("#i_sbgjz").val("");
            } else {
                $("#i_sbgjz").val(data.YxWarn);
            }
            if (data.IsOverLimtWarn == 1) {
                $("[name=i_cyzgj]").eq(0).attr("checked", true);
            } else {
                $("[name=i_cyzgj]").eq(1).attr("checked", true);
            }
            if (data.Dx == 1) {
                $("#i_dx").attr("checked", true);
                $("#i_sjh").val(data.Sjh);
                $("#h_dxmb").val(data.Dxmb);
            } else {
                $("#i_dx").attr("checked", false);
                $("#i_sjh").val("");
                $("#h_dxmb").val(dxmbStatic);
            }
            if (data.Yj == 1) {
                $("#i_yj").attr("checked", true);
                $("#i_yxdz").val(data.Yxdz);
                $("#h_yjmb").val(data.Yjmb);
            } else {
                $("#i_yj").attr("checked", false);
                $("#i_yxdz").val("");
                $("#h_yjmb").val(yjmbStatic);
            }
            if (data.Sy == 1) {
                $("#i_fs").attr("checked", true);
                $("#h_sylx").val(data.SndFileType);
            } else {
                $("#i_fs").attr("checked", false);
                $("#h_sylx").val("");
            }
            if (data.IsAutoCleanWarn == 1) {
                $("[name=i_sfzdmj]").eq(0).attr("checked", true);
                $("#s_zdmjgz").val(data.CleanWarnRule).attr("disabled", false);
            } else {
                $("[name=i_sfzdmj]").eq(1).attr("checked", true);
                $("#s_zdmjgz").attr("disabled", true);
            }
            if ($("[name=i_cyzgj]:checked").val() == 1 || $("[name=i_cyxzgj]:checked").val() == 1) {
                $("#tr_gj").find("input").attr("disabled", false);
            }
            if (data.IsUse == 1) {
                $("[name=i_sfqy]:eq(1)").removeAttr("checked");
                $("[name=i_sfqy]:eq(0)").attr("checked", 'checked');
            } else {
                $("[name=i_sfqy]:eq(0)").removeAttr("checked");
                $("[name=i_sfqy]:eq(1)").attr("checked", 'checked');
            }
            sub = false;
        }
    );
    $("#dlg_yxx").dialog("open");
    editStatus = "edit";
    return false;
}
//数据项配置删除
function yxxDel(id) {
    $.messager.confirm('确认', '删除后将不可恢复，确定删除?', function (r) {
        if (r) {
            $("#t_yxx").datagrid("reload", {
                action: "sjxDel",
                sjlx: "YX",
                Id: id,
                r: Math.random()
            });
        }
    });
    return false;
}

function dxmb() {
    $("#ta_mb").html($("#h_dxmb").val());
    $("#dlg_mb").dialog("open").dialog("setTitle", "短信模板");
    mb = "dx";
    return false;
}

function yjmb() {
    $("#ta_mb").html($("#h_yjmb").val());
    $("#dlg_mb").dialog("open").dialog("setTitle", "邮件模板");
    mb = "yj";
    return false;
}

//模板确认按钮
function mbOk() {
    if (mb == "dx") {
        $("#h_dxmb").val($("#ta_mb").html());
    } else {
        $("#h_yjmb").val($("#ta_mb").html());
    }
    $("#dlg_mb").dialog("close");
}

//保存遥信/测项数据
function yxxSave() {
    if ($("#s_zcj").val() == 0) {
        $.messager.alert("提示", "桩厂家未选择");
        return false;
    }
    if ($("#s_zxh").val() == 0) {
        $.messager.alert("提示", "桩型号未选择");
        return false;
    }
    if ($("#s_sjx").val() == 0) {
        $.messager.alert("提示", "数据项未选择");
        return false;
    }
    if ($("#i_ztz").val().length != 0 && !checkInt($("#i_ztz").val())) {
        $.messager.alert("提示", "状态值只能为数字,多个值需要用英文状态下的逗号(,)分隔。");
        return false;
    }
//    if ($("#i_sbzcz").val().length != 0 && !checkInt($("#i_sbzcz").val())) {
//        $.messager.alert("提示", "设备正常值只能为数字,多个值需要用英文状态下的逗号(,)分隔。");
//        return false;
//    }
    if ($("#i_sbgjz").val().length != 0 && !checkInt($("#i_sbgjz").val())) {
        $.messager.alert("提示", "设备告警值只能为数字,多个值需要用英文状态下的逗号(,)分隔。");
        return false;
    }
    if ($("#i_cyzgj_y").is(":checked") && !$("#i_dx").is(":checked") && !$("#i_yj").is(":checked") && !$("#i_fs").is(":checked")) {
        $.messager.alert("提示", "您已经选择超阈值告警，请至少选择一种告警方式。");
        return false;
    }
    if ($("#i_dx").is(":checked") && $("#i_sjh").val().length == 0) {
        $.messager.alert("提示", "您已经勾选短信告警，请输入手机号。");
        return false;
    }
    if ($("#i_dx").is(":checked") && !checkNum($("#i_sjh").val())) {
        $.messager.alert("提示", "输入手机号格式不正确。");
        return false;
    }
    if ($("#i_dx").is(":checked") && $("#h_dxmb").val().length == 0) {
        $.messager.alert("提示", "您已经勾选短信告警，请输入短信模板。");
        return false;
    }
    if ($("#i_yj").is(":checked") && $("#i_yxdz").val().length == 0) {
        $.messager.alert("提示", "您已经勾选邮件告警，请输入邮箱地址。");
        return false;
    }
    if ($("#i_yj").is(":checked") && !checkEmail($("#i_yxdz").val())) {
        $.messager.alert("提示", "输入邮箱地址格式不正确。");
        return false;
    }
    if ($("#i_yj").is(":checked") && $("#h_yjmb").val().length == 0) {
        $.messager.alert("提示", "您已经勾选邮件告警，请输入邮件模板。");
        return false;
    }
    if ($("#i_fs").is(":checked") && $("#i_sywj").val().length == 0 && $("#h_sylx").val().length == 0) {
        $.messager.alert("提示", "您已经勾选声音告警，请声音文件。"); //编辑状态、声音类型不为空时，不判断是否有文件
        return false;
    }
    var saveMode = "";
    if (editStatus == "add") {
        saveMode = "yxxSave";
    } else {
        saveMode = "yxxEdit";
    }
    $("#form1").ajaxSubmit({
        url: "../../WebService/Yxxpz.ashx",
        data: { action: saveMode, r: Math.random() },
        dataType: "json",
        beforeSubmit: function () {
            var b = $("#form1").form("validate");
            if (sub) {
                $.messager.alert("提示", "数据处理中，请稍后。");
                return false;
            } else {
                sub = b;
                return b;
            }
        },
        success: function (responseText, statusText) {
            if (statusText == "success" && responseText.status != 0) {
                $("#t_yxx").datagrid("reload");
                formReset(); //重置表单所有数据及状态
                $("#dlg_yxx").dialog("close");
                $.messager.alert("提示", responseText.msg);
                if (responseText.status == 2) {
                    setTimeout(function () { location.href = "../../Login.aspx"; }, 4000);
                    $.messager.alert("提示", responseText.msg + "--登录过期，即将跳转到登陆页。");
                }
            } else {
                $.messager.alert("提示", responseText.msg);
            }
            sub = false;
        }
    });
    return false;
}

function yxxCancel() {
    if (sub) {
        $.messager.alert("提示", "数据处理中，请稍后。");
        return false;
    } else {
        $('#dlg_yxx').dialog('close');
        return false;
    }
}

//重置表单所有数据及状态
function formReset() {
    $("#h_id").val("");
    $("#s_zcj").val(0).attr("disabled", false);
    $("#s_zxh").html("<option value='0' >—请选择—</option>").attr("disabled", false);
    $("#i_zlx").val("").attr("disabled", false);
    $("#s_sjx").html("<option value='0' >—请选择—</option>").attr("disabled", false);
    //$("#i_ztz,#i_sbzcz,#i_sbgjz").val("");
    $("[name=i_cyzgj]").eq(1).attr("checked", true);
    $("#i_dx,#i_yj,#i_fs").attr("checked", false);
    $("#i_sjh,#i_yxdz,#h_sylx").val("");
    var file = $("#i_sywj");
    file.after(file.clone().val(""));
    file.remove();
    $("#h_dxmb").val(dxmbStatic);
    $("#h_yjmb").val(yjmbStatic);
    $("#tr_gj").find("input").attr("disabled", true);
    $("[name=i_sfzdmj]").eq(1).attr("checked", true);
    $("#s_zdmjgz").val(1).attr("disabled", true);
    $("[name=i_sfqy]:eq(1)").removeAttr("checked");
    $("[name=i_sfqy]:eq(0)").attr("checked", "checked");
}


//验证手机号字符串，参数为手机号字符串（,分隔）
function checkNum(numSurce) {
    if (numSurce.length == 0) {
        return false;
    }
    var numList = numSurce.split(","); //号码之间使用引文分好分隔
    var vadRes = true;
    for (var i = 0; i < numList.length; i++) {
        vadRes = vadRes && isMobilePhoneNum(numList[i]);
        if (vadRes != true) {
            return false;
        }
    }
    return vadRes;
}
//逐个手机号验证
function isMobilePhoneNum(val) {
    var patrn = /^(13|14|15|18)\d{9}$/;
    if (!patrn.exec(val)) return false;
    return true;
}

//验证邮箱地址字符串，参数为邮箱地址字符串（,分隔）
function checkEmail(emailSurce) {
    if (emailSurce.length == 0) {
        return false;
    }
    var emailList = emailSurce.split(","); //号码之间使用引文分好分隔
    var vadRes = true;
    for (var i = 0; i < emailList.length; i++) {
        vadRes = vadRes && isEmailStr(emailList[i]);
        if (vadRes != true) {
            return false;
        }
    }
    return vadRes;
}
//逐个邮箱地址验证
function isEmailStr(val) {
    var patrn = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    if (!patrn.exec(val)) return false;
    return true;
}

//逐个验证数字
function checkInt(intSource) {
    if (intSource.length == 0) {
        return false;
    }
    var intList = intSource.split(","); //号码之间使用引文分好分隔
    var vadRes = true;
    for (var i = 0; i < intList.length; i++) {
        vadRes = vadRes && isIntStr(intList[i]);
        if (vadRes != true) {
            return false;
        }
    }
    return vadRes;
}

//逐个邮箱地址验证
function isIntStr(val) {
    var patrn = /^[+]?[0-9]+\d*$/;
    if (!patrn.exec(val)) return false;
    return true;
}