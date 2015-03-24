

$(function () {
    $.getJSON("../../WebService/IcCardService.ashx", { action: "getczfs" }, function (data) {
        if (!data.status) {
            var html = "<option value='0'>—所有—</option>";
            var czfs = data.czfs;
            for (var i = 0; i < czfs.length; i++) {
                html += "<option value='" + czfs[i].VALUE + "' " + (czfs[i].VALUE == 1 ? "selected='selected'" : "")
                    + " >" + czfs[i].NAME + "</option>";
            }
            $("#s_czfs").html(html);
        }
    });
    $("#t_icRecharge").datagrid({
        url: "../../WebService/IcCardService.ashx",
        queryParams: {
            action: "queryczjl",
            cardNum: $("#i_cardNum").val(),
            czy: $("#i_czy").val(),
            czwd: $("#i_czwd").val(),
            czfs: $("#s_czfs").val() && $("#s_czfs").val() != 0 ? $("#s_czfs").val() : "",
            dateBegin: $("#i_dateBegin").val(),
            dateEnd: $("#i_dateEnd").val()
        },
        fit: true,
        fitColumns: true,
        singleSelect: true,
        rownumbers: true,
        toolbar: "#d_tb",
        pagination: true,
        striped: true,
        border: false,
        pageSize: 20,
        columns: [[
            { field: "ID", title: "id", hidden: true },
            { field: "IC卡号", title: "卡号", align: "center", width: 120 },
            { field: "充值金额", title: "充值金额", align: "center", width: 100 },
            { field: "充值方式1", title: "充值方式", align: "center", width: 100 },
            { field: "转账卡号", title: "转账卡号", align: "center", width: 90 },
            {
                field: "充值时间",
                title: "充值时间",
                align: "center",
                width: 150,
                formatter: function (val, src) {
                    return val;
                }
            },
            { field: "充值网点代码", title: "充值网点代码", align: "center", width: 100 },
            { field: "操作员工号", title: "操作员工号", align: "center", width: 100 }
        ]]
    });
});

//查询方法
function query() {
    $("#t_icRecharge").datagrid("load", {
        action: "queryczjl",
        cardNum: $("#i_cardNum").val(),
        czy: $("#i_czy").val(),
        czwd: $("#i_czwd").val(),
        czfs: $("#s_czfs").val() && $("#s_czfs").val() != 0 ? $("#s_czfs").val() : "",
        dateBegin: $("#i_dateBegin").val(),
        dateEnd: $("#i_dateEnd").val()
    });
}

//充电卡发行
function cdkfx() {
    alert("充电卡发行");
    //location.href = "";
}
//充电卡充值
function cdkcz() {
    alert("充电卡充值");
    //location.href = "";
}