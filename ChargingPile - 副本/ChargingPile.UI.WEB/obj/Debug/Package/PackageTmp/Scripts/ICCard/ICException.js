

$(function () {
    $("#t_iccardgs").datagrid({
        url: "../../WebService/IcCardService.ashx",
        queryParams: {
            action: "queryexp"
        },
        fit: true,
        //fitColumns: true,
        singleSelect: true,
        rownumbers: true,
        toolbar: "#d_tb",
        pagination: true,
        striped: true,
        border: false,
        pageSize: 20,
        columns: [[
            { field: "ID", title: "id", hidden: true },
            { field: "卡号", title: "卡号", align: "center", width: 120 },
            { field: "站名称", title: "站名称", align: "center", width: 120 },
            { field: "桩运行编号", title: "桩运行编号", align: "center", width: 120 },
            { field: "发生时间", title: "发生时间", align: "center", width: 120 },
            { field: "卡状态", title: "卡状态", align: "center", width: 90 },
            { field: "户主姓名", title: "户主姓名", align: "center", width: 100 },
            { field: "户主证件名称", title: "户主证件名称", align: "center", width: 100 },
            { field: "户主证件号码", title: "户主证件号码", align: "center", width: 130 },
            { field: "卡类型", title: "卡类型", align: "center", width: 90 },
            {
                field: "有效期",
                title: "有效期",
                align: "center",
                width: 90,
                formatter: function (val, src) {
                    return val.substr(0, val.lastIndexOf(" "));
                }
            },
            { field: "余额", title: "余额", align: "center", width: 60 },
            { field: "电话", title: "电话", align: "center", width: 90 },
            { field: "固话", title: "固话", align: "center", width: 90 },
            { field: "邮箱", title: "邮箱", align: "center", width: 90 },
            {
                field: "备注",
                title: "备注",
                align: "center",
                width: 130,
                formatter: function (val, src) {
                    return "<label title='" + val + "'>" + val + "</label>";
                }
            }
        ]]
    });
    $("#i_refresh").change(function () {
        if ($(this).attr("checked")) {
            $("#t_iccardgs").datagrid("load");
        }
    });
    var sh = setInterval(refreshGs, $("#i_refreshTime").val() * 60 * 1000);
    $("#i_refreshTime").change(function () {
        if (!isNaN(this.value)) {
            $("#t_iccardgs").datagrid("load");
            window.clearInterval(sh);
            sh = setInterval(refreshGs, this.value * 60 * 1000);
        }
    });
});

//查询方法
function refreshGs() {
    $("#t_iccardgs").datagrid("load");
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