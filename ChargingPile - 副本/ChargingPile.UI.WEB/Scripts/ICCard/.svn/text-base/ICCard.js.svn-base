

$(function () {
    $.getJSON("../../WebService/IcCardService.ashx", { action: "getzjmc" }, function (data) {
        if (!data.status) {
            var html = "<option value='0'>—所有—</option>";
            var zjmc = data.zjmc;
            for (var i = 0; i < zjmc.length; i++) {
                html += "<option value='" + zjmc[i].VALUE + "'>" + zjmc[i].NAME + "</option>";
            }
            $("#s_zjmc").html(html);
        }
    });
    $.getJSON("../../WebService/IcCardService.ashx", { action: "getkzt" }, function (data) {
        if (!data.status) {
            var html = "<option value='0'>—所有—</option>";
            var kzt = data.kzt;
            for (var i = 0; i < kzt.length; i++) {
                html += "<option value='" + kzt[i].VALUE + "'>" + kzt[i].NAME + "</option>";
            }
            $("#s_kzt").html(html);
        }
    });
    $.getJSON("../../WebService/IcCardService.ashx", { action: "getklx" }, function (data) {
        if (!data.status) {
            var html = "<option value='0'>—所有—</option>";
            var klx = data.klx;
            for (var i = 0; i < klx.length; i++) {
                html += "<option value='" + klx[i].VALUE + "'>" + klx[i].NAME + "</option>";
            }
            $("#s_klx").html(html);
        }
    });
    $("#t_iccardInfo").datagrid({
        url: "../../WebService/IcCardService.ashx",
        queryParams: {
            action: "queryinfo",
            cardNum: $("#i_cardNum").val(),
            name: $("#i_name").val(),
            zjmc: $("#s_zjmc").val() && $("#s_zjmc").val() != 0 ? $("#s_zjmc").val() : "",
            zjhm: $("#i_zjhm").val(),
            kzt: $("#s_kzt").val() && $("#s_kzt").val() != 0 ? $("#s_kzt").val() : "",
            klx: $("#s_klx").val() && $("#s_klx").val() != 0 ? $("#s_klx").val() : "",
            dateBegin: $("#i_dateBegin").val(),
            dateEnd: $("#i_dateEnd").val()
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
            { field: "户主姓名", title: "户主姓名", align: "center", width: 100 },
            { field: "户主证件名称1", title: "户主证件名称", align: "center", width: 100 },
            { field: "户主证件号码", title: "户主证件号码", align: "center", width: 130 },
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
            { field: "卡状态1", title: "卡状态", align: "center", width: 90 },
            { field: "卡类型1", title: "卡类型", align: "center", width: 90 },
            { field: "电话", title: "电话", align: "center", width: 90 },
            { field: "固话", title: "固话", align: "center", width: 90 },
            { field: "邮箱", title: "邮箱", align: "center", width: 90 },
            { field: "备注", title: "备注", align: "center", width: 130,
                formatter: function (val, src) {
                    return "<label title='" + val + "'>" + val + "</label>";
                }
            }
        ]]
    });
});

//查询方法
function query() {
    $("#t_iccardInfo").datagrid("load", {
        action: "queryinfo",
        cardNum: $("#i_cardNum").val(),
        name: $("#i_name").val(),
        zjmc: $("#s_zjmc").val() && $("#s_zjmc").val() != 0 ? $("#s_zjmc").val() : "",
        zjhm: $("#i_zjhm").val(),
        kzt: $("#s_kzt").val() && $("#s_kzt").val() != 0 ? $("#s_kzt").val() : "",
        klx: $("#s_klx").val() && $("#s_klx").val() != 0 ? $("#s_klx").val() : "",
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