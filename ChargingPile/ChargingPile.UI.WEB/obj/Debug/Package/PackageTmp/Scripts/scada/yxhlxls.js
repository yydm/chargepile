
$(function () {
    $("#t_ls").datagrid({
        url: "../../WebService/HistoryDetail.ashx",
        queryParams: {
            action: "getyxhlxls",
            r: Math.random()
        },
        fit: true,
        singleSelect: true,
        rownumbers: true,
        toolbar: "#d_tb",
        pageSize: 20,
        pagination: true,
        striped: true,
        border: false,
        columns: [[
            { field: "ZHANMC", title: "站名称", align: "center", width: 130 },
            { field: "PARSERKEY", title: "桩型号", align: "center", width: 130 },
            { field: "ZHUANGLEIX", title: "桩类型", align: "center", width: 100 },
            { field: "TARGETDEV", title: "桩编号", align: "center", width: 100 },
            { field: "ITEMNAME", title: "数据项", align: "center", width: 120 },
            { field: "MVALUE", title: "测量值", align: "center", width: 60,
                formatter: function (val, src) {
                    if (null == val || (val + "").length == 0) {
                        return "—";
                    } else {
                        return val;
                    }
                }
            },
            {
                field: "YXSTATES",
                title: "设备状态值",
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
                field: "YXWARN",
                title: "设备告警值",
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
                field: "LOGDESC",
                title: "出错原因",
                align: "center",
                width: 150,
                formatter: function (val, src) {
                    if (null == val || val.length == 0) {
                        return "—";
                    } else {
                        return "<label title='" + val + "'>" + val + "</label>";
                    }
                }
            },
            {
                field: "PF",
                title: "是否处理",
                align: "center",
                width: 80,
                formatter: function (val, src) {
                    if (0 == src.PROCESSFLAG) {
                        return "未处理";
                    } else {
                        return "已处理";
                    }
                }
            },
            {
                field: "PROCESSFLAG",
                title: "灭警方式",
                align: "center",
                width: 80,
                formatter: function (val, src) {
                    if (0 == val) {
                        return "未处理";
                    } else if (1 == val) {
                        return "自动灭警";
                    } else if (2 == val) {
                        return "手动灭警";
                    } else {
                        return "—";
                    }
                }
            },
            {
                field: "PROCESSDT",
                title: "灭警时间",
                align: "center",
                width: 100,
                formatter: function (val, src) {
                    return val;
                }
            },
            { field: "PROCESSEEP", title: "灭警人", align: "center", width: 80 }
        ]]
    });
    $.getJSON("../../WebService/Common.ashx", { action: "getDate", r: Math.random() }, function (data) {
        $("#i_dateBegin").val(data.d1ago);
        $("#i_dateEnd").val(data.now);
    });
});

function Query() {
    $("#t_ls").datagrid("load", {
        action: "getYxhlxls",
        dateBegin: $("#i_dateBegin").val(),
        dateEnd: $("#i_dateEnd").val(),
        r: Math.random()
    });
}

function Expert() {
    window.open("../../WebService/HistoryDetail.ashx?action=expYxhlxls&datebegin="
        + $("#i_dateBegin").val() + "&dateend=" + $("#i_dateEnd").val() + "&r=" + Math.random());
}