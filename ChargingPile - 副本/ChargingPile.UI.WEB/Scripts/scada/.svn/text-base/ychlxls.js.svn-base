
$(function () {
    $("#t_ls").datagrid({
        url: "../../WebService/HistoryDetail.ashx",
        queryParams: {
            action: "getychlxls",
            r: Math.random()
        },
        fit: true,
        singleSelect: true,
        rownumbers: true,
        pageSize: 20,
        striped: true,
        border: false,
        toolbar: "#d_tb",
        pagination: true,
        columns: [[
            { field: "ZHANMC", title: "站名称", align: "center", width: 100 },
            { field: "PARSERKEY", title: "桩型号", align: "center", width: 100 },
            { field: "ZHUANGLEIX", title: "桩类型", align: "center", width: 100 },
            { field: "TARGETDEV", title: "桩编号", align: "center", width: 80 },
            { field: "ITEMNAME", title: "数据项", align: "center", width: 80 },
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
                field: "EFF_MIN",
                title: "有效值最小值",
                align: "center",
                width: 80,
                formatter: function (val, src) {
                    if (null == val || (val + "").length == 0) {
                        return "—";
                    } else {
                        return val;
                    }
                }
            },
            {
                field: "EFF_MAX",
                title: "有效值最大值",
                align: "center",
                width: 80,
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
        action: "getYchlxls",
        dateBegin: $("#i_dateBegin").val(),
        dateEnd: $("#i_dateEnd").val(),
        r: Math.random()
    });
}

function Expert() {
    window.open("../../WebService/HistoryDetail.ashx?action=expYchlxls&datebegin="
        + $("#i_dateBegin").val() + "&dateend=" + $("#i_dateEnd").val() + "&r=" + Math.random());
}