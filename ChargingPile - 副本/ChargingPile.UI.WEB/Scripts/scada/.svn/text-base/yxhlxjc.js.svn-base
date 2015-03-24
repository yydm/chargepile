var cljlid = "";
var data = { "total": 0, "rows": [] };

$(function () {
    $("#t_yctbcl").datagrid({
        fit: true,
        singleSelect: true,
        rownumbers: true,
        toolbar: "#d_tb",
        pagination: true,
        striped: true,
        border: false,
        pageSize: 20,
        columns: [[
            { field: "ID", title: "id", hidden: true },
            { field: "ZHANMC", title: "充电站", align: "center", width: 100 },
            { field: "PARSERKEY", title: "桩型号", align: "center", width: 100 },
            { field: "ZHUANGLEIX", title: "桩类型", align: "center", width: 100 },
            { field: "YXBH", title: "桩编号", align: "center", width: 90 },
            { field: "ITEMNAME", title: "数据项", align: "center", width: 90 },
            { field: "MVALUE", title: "测量值", align: "center", width: 60 },
            { field: "YXSTATES", title: "状态值", align: "center", width: 90 },
            { field: "YXEFF", title: "设备有效值", align: "center", width: 90 },
            { field: "YXWARN", title: "设备告警值", align: "center", width: 90 },
            {
                field: "LOGDESC",
                title: "出错原因",
                align: "center",
                width: 120,
                formatter: function (val, src) {
                    return "<label title='" + val + "'>" + val + "</label>";
                }
            },
            {
                field: "PROCESSFLAG",
                title: "处理",
                align: "center",
                width: 60,
                formatter: function (val, src) {
                    if (val == "0") {
                        return "<a href='#' title='处理' onclick='gjcl(\"" + src.Id + "\")' class='easyui-linkbutton' plain='true' iconcls='icon-quench'></a>";
                    } else {
                        return "<a href='#' title='已处理' class='easyui-linkbutton' plain='true' iconcls='icon-ok'></a>";
                    }
                }
            }
        ]],
        onBeforeLoad: function (param) {
            InvokeService(param.page, param.rows);
            $("#t_yctbcl").datagrid("loading");
            return false;
        },
        onLoadSuccess: function () {
            $("#t_yctbcl").datagrid("getPanel").find("a.easyui-linkbutton").linkbutton();
        }
    });
    var sh = setInterval(refreshYctbcl, $("#i_refreshTime").val() * 60 * 1000);
    $("#i_refresh").change(function () {
        if ($(this).attr("checked")) {
            $("#t_yctbcl").datagrid("reload");
        } else {
            window.clearInterval(sh);
        }
    });
    $("#i_refreshTime").change(function () {
        if (!isNaN(this.value) && $("#i_refresh").attr("checked")) {
            $("#t_yctbcl").datagrid("reload");
            window.clearInterval(sh);
            sh = setInterval(refreshYctbcl, this.value * 60 * 1000);
        }
    });
});


function InvokeService(page, rows) {
    var req = {
        type: "jDao",
        method: "QueryDt",
        scope: 'Singleton',
        args:
        ["select * from (select rownum rn, count(*) over() DATACNT,ow.id, " +
            "(select dcs.zhuan_mc from dev_chargstation dcs where dcs.zhan_bh = " +
            "(select db.zhuan_bh from DEV_BRANCH db where db.branchno=dcp.box_id)) zhanmc," +
            "dppt.parserkey,dppt.zhuanglei_x zhuangleix,ow.dataitemid,ow.targetdev," +
            "(select dc.yunxing_bh from dev_chargpile dc where dc.dev_chargpile=ow.targetdev) yxbh," +
            "(select gi.itemname from gat_item gi where gi.itemno=ow.dataitemid) itemname," +
            "gp.yxstates,gp.yxeff,gp.yxwarn,gp.limitmin,gp.limitmax,gp.eff_min,gp.eff_max ," +
            "ow.m_value mvalue,ow.logdesc, ow.processflag as processflag from oth_warnrec ow " +
            "left join dev_chargpile dcp on ow.targetdev=dcp.dev_chargpile left join " +
            "DEV_POWERPILETYPES dppt on dppt.parserkey=dcp.piletypeid left join gat_pointcfg gp " +
            "on gp.gatitemid=ow.dataitemid and gp.piletypeid=dppt.parserkey where ow.processflag=0 " +
            "and ow.logtype=#logtype  ) abc where rn between  "
            + ((page - 1) * rows + 1) + " and " + page * rows,
            {
                "logtype": "003"
            }]
    };

    $.ajax({
        type: "POST",
        url: MJUrl,
        data: JSON2.stringify(req),
        success: function (resp) {
            if (!resp.success) {
                $.messager.alert('消息', resp.message, "info");
            } else {
                if (resp.data.length > 0) {
                    data.total = resp.data[0].DATACNT;
                    data.rows = resp.data;
                    $("#t_yctbcl").datagrid("loadData", data);
                } else {
                    $("#t_yctbcl").datagrid("loadData", { "totle": 0, "rows": [] });
                }
            }
            $("#t_yctbcl").datagrid("loaded");
        },
        error: function (xhr) {
            $.messager.alert('消息', xhr.message, "info");
        }
    });
}

//手动刷新
function refreshYctbcl() {
    $("#t_yctbcl").datagrid("reload");
}

//查看历史告警清单
function showHistory() {
    location.href = "yxhlxHistoryDetail.htm";
}

//打开告警处理界面
function gjcl(id) {
    $("#dlg").dialog("open");
    $("[name=r_gjcl]").eq(0).attr("checked", true);
    cljlid = id;
    return false;
}

//保存告警处理结果
function gjcl_save() {
    var clcz = $("[name=r_gjcl]:checked").val();
    if (clcz == 1) {
        var workNum = "";
        $.getJSON("../../WebService/PasswordService.ashx", { action: "getworknum" }, function (data) {
            if (data.flag) {
                workNum = data.worknum;
                var selected = $("#t_yctbcl").datagrid("getSelected");
                InvokeWarn(selected.TARGETDEV, selected.DATAITEMID, workNum);
            }
        });
    } else {
        $("#dlg").dialog("close");
    }
}

function invokeWarn_return_error(resp) {
    $.messager.alert('消息', "灭警失败，请重试。", "info");
    $("#dlg").dialog("close");
}

function invokeWarn_return_success(resp) {
    $.messager.alert('消息', "灭警成功。", "info");
    $("#dlg").dialog("close");
    refreshYctbcl();
}

function invokeWarn_error(xhr) {
    $.messager.alert('消息', "调用灭警功能出错。", "info");
    $("#dlg").dialog("close");
}