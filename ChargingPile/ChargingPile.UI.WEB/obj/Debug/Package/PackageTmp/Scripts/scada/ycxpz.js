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
            action: "getYcxData",
            r: Math.random()
        },
        fit: true,
        //fitColumns: true,
        singleSelect: true,
        rownumbers: true,
        toolbar: "#d_tb",
        pageSize: 20,
        striped: true,
        border: false,
        pagination: true,
        columns: [[
            { field: "Id", title: "Id", hidden: true },
            { field: "Zhuangcj", title: "桩厂家", align: "center", width: 120 },
            { field: "PileTypeId", title: "桩型号", align: "center", width: 130 },
            { field: "ZhuangLeiX", title: "桩类型", align: "center", width: 130 },
            { field: "GatItemName", title: "数据项", align: "center", width: 140 },
            {
                field: "LimitMin",
                title: "阈值最小值",
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
                field: "LimitMax",
                title: "阈值最大值",
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
                width: 100,
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
        //加载数据项
        getSjx();
    });

    $("[name=i_cyxzgj],[name=i_cyzgj]").change(function () {
        if ($("[name=i_cyxzgj]:checked").val() == "1" || $("[name=i_cyzgj]:checked").val() == "1") {
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

//加载数据项
function getSjx() {
    //编辑时需要添加改配置的数据项+未使用的数据项
    $.getJSON("../../WebService/Yxxpz.ashx",
        { action: "getSjx", dataType: "YC", zhuangxing_h: $("#s_zxh").find("option:selected").text(), r: Math.random() },
        function (data) {
            $("#s_sjx").html("<option value='0' >—请选择—</option>");
            for (var i = 0; i < data.length; i++) {
                $("#s_sjx").append("<option value='" + data[i].ITEMNO + "'>" + data[i].ITEMNAME + "</option>");
            }
        });
}
//数据查询
function ycxQuery() {
    $("#t_yxx").datagrid("reload", {
        action: "GetYcxData",
        xh: $("#s_xh").val(),
        sjx: $("#i_sjx").val(),
        r: Math.random()
    });
}

function yxxAdd() {
    $("#dlg_yxx").dialog("open");
    editStatus = "add";
    formReset(); //重置表单所有数据及状态
    return false;
}
//数据项配置编辑
function yxxEdit(id) {
    formReset(); //重置表单所有数据及状态
    sub = true;
    $.getJSON("../../WebService/Yxxpz.ashx",
        { action: "GetSjxpz", id: id, r: Math.random() },
        function (data) {
            $("#h_id").val(data.Id);
            $("#s_zcj").val(data.Zhuangcj).attr("disabled", true);
            $("#s_zxh").html("<option>" + data.PileTypeId + "</option>").attr("disabled", true);
            $("#i_zlx").val(data.ZhuangLeiX).attr("disabled", true);
            $("#s_sjx").html("<option>" + data.GatItemName + "</option>").attr("disabled", true);
            $("#i_yzzxz").val(data.LimitMin);
            $("#i_yzzdz").val(data.LimitMax);
            if (data.IsOverLimtWarn == 1) {
                $("[name=i_cyzgj]").eq(0).attr("checked", true);
            } else {
                $("[name=i_cyzgj]").eq(1).attr("checked", true);
            }
            $("#i_yxzzxz").val(data.Eff_Min);
            $("#i_yxzzdz").val(data.Eff_Max);
            if (data.IsOverEffWarn == 1) {
                $("[name=i_cyxzgj]").eq(0).attr("checked", true);
            } else {
                $("[name=i_cyxzgj]").eq(1).attr("checked", true);
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
    $("#h_id").val(id);
    return false;
}
//数据项配置删除
function yxxDel(id) {
    $.messager.confirm('确认', '删除后将不可恢复，确定删除?', function (r) {
        if (r) {
            $("#t_yxx").datagrid("reload", {
                action: "sjxDel",
                sjlx: "YC",
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

//保存遥信项数据

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
    if ($("#i_cyzgj_y").is(":checked") && $("#i_yzzdz").val().length == 0 && $("#i_yzzxz").val().length == 0) {
        $.messager.alert("提示", "您已经选择超阈值告警，请至少录入阈值上下限中的一项。");
        if ($("#i_yzzxz").val().length == 0) {
            $("#i_yzzxz").focus();
            return false;
        }
    }
    if ($("#i_cyzgj_y").is(":checked") && $("#i_yzzdz").val().length > 0 && $("#i_yzzxz").val().length > 0 && parseFloat($("#i_yzzdz").val()) < parseFloat($("#i_yzzxz").val())) {
        $.messager.alert("提示", "阈值最大值不能小于阈值最小值");
        return false;
    }
    if ($("#i_cyxzgj_y").is(":checked") && $("#i_yxzzdz").val().length == 0 && $("#i_yxzzxz").val().length == 0) {
        $.messager.alert("提示", "您已经选择超有效值告警，请至少录入有效值上下限中的一项。");
        if ($("#i_yxzzxz").val().length == 0) {
            $("#i_yxzzxz").focus();
        }
        return false;
    }
    if ($("#i_cyxzgj_y").is(":checked") && $("#i_yxzzdz").val().length > 0 && $("#i_yxzzxz").val().length > 0 && parseFloat($("#i_yxzzdz").val()) < parseFloat($("#i_yxzzxz").val())) {
        $.messager.alert("提示", "有效值最大值不能小于有效值最小值");
        return false;
    }
    if ($("#i_cyzgj_y").is(":checked") && !$("#i_dx").is(":checked") && !$("#i_yj").is(":checked") && !$("#i_fs").is(":checked")) {
        $.messager.alert("提示", "您已经选择超阈值告警，请至少选择一种告警方式。");
        return false;
    }
    if ($("#i_cyxzgj_y").is(":checked") && !$("#i_dx").is(":checked") && !$("#i_yj").is(":checked") && !$("#i_fs").is(":checked")) {
        $.messager.alert("提示", "您已经选择超有效值告警，请至少选择一种告警方式。");
        return false;
    }
    if ($("#i_dx").is(":checked") && $("#i_sjh").val().length == 0) {
        $.messager.alert("提示", "您已经勾选短信告警，请输入手机号。");
        return false;
    }
    if ($("#i_dx").is(":checked") && $("#i_sjh").val().length != 0 && !checkNum($("#i_sjh").val())) {
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
    if ($("#i_yj").is(":checked") && $("#i_yxdz").val().length != 0 && !checkEmail($("#i_yxdz").val())) {
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
        saveMode = "ycxSave";
    } else {
        saveMode = "ycxEdit";
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
//                $("#t_yxx").datagrid("reload");
//                formReset(); //重置表单所有数据及状态
//                $("#dlg_yxx").dialog("close");
                $.messager.alert("提示", responseText.msg);
//                if (responseText.status == 2) {
//                    setTimeout(function () { location.href = "../../Login.aspx"; }, 4000);
//                    $.messager.alert("提示", responseText.msg + "--登录过期，即将跳转到登陆页。");
//                }
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
    $("#i_yzzxz,#i_yzzdz,#i_yxzzxz,#i_yxzzdz").val("");
    $("[name=i_cyzgj]").eq(1).attr("checked", true);
    $("[name=i_cyxzgj]").eq(1).attr("checked", true);
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