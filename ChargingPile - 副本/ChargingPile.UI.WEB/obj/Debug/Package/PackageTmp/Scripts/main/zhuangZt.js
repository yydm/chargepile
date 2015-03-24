$(function() {
    $('#d_dg').datagrid({
        url: '../../WebService/IndexService.ashx',
        queryParams: {
            action: 'queryzzt',
            cdcz: $("#s_cdcz").val(),
            zbh: $("#s_zyxbh").val(),
            dateBegin: $("#i_dateBegin").val(),
            dateEnd: $("#i_dateEnd").val(),
            r: Math.random()
        },
        fit: true,
        fitColumns: true,
        singleSelect: true,
        pagination: true,
        border: false,
        striped: true,
        rownumbers: true,
        pageSize: 20,
        toolbar: "#d_tb",
        columns: [[
            { field: 'ZhanJc', title: '站名称', align: 'center', width: 120 },
            {
                field: 'YunXingBh',
                title: '桩运行编号',
                align: 'center',
                width: 120,
                formatter: function(val, src) {
                    if (val) {
                        return val;
                    } else {
                        return "###";
                    }
                }
            },
            { field: 'DateTime', title: '时间', align: 'center', width: 120 },
            { field: 'Note', title: '充电状态', align: 'center', width: 120 },
            { field: 'ChargeTime', title: '充电时长', align: 'center', width: 120 },
            { field: 'ChargePower', title: '充电电量（KWH）', align: 'center', width: 120 },
            { field: 'CardNo', title: '充电卡号', align: 'center', width: 120 },
            { field: 'ChargeMoney', title: '充电金额（￥）', align: 'center', width: 120 }
        ]]
    });
    $.getJSON("/WebService/ChargPileMaintainService.ashx", { action: "getstation", r: Math.random() }, function(data) {
        var length = data.rows.length;
        $("#s_cdcz").html("<option value='' selected='selected' >—请选择—</option>");
        for (var i = 0; i < length; i++) {
            $("#s_cdcz").append("<option value='" + data.rows[i].ZhanBh + "' >" + data.rows[i].Zhan_Jc + "</option>");
        }
    });
});

function query() {
    $('#d_dg').datagrid("load", {
        action: 'queryzzt',
        cdcz: $("#s_cdcz").val(),
        zbh: $("#s_zyxbh").val(),
        dateBegin: $("#i_dateBegin").val(),
        dateEnd: $("#i_dateEnd").val(),
        r: Math.random()
    });
}

function zhanChange() {
    var zhanBh = $("#s_cdcz").val();
    if (zhanBh != "") {
        $.getJSON("/WebService/ChargPileMaintainService.ashx",
            { action: "getyxbh", zhuan_bh: zhanBh, r: Math.random() }, function(data) {
                var length = data.rows.length;
                $("#s_zyxbh").html("<option value='' selected='selected' >—请选择—</option>");
                for (var i = 0; i < length; i++) {
                    if (data.rows[i].YUNXING_BH != null) {
                        $("#s_zyxbh").append("<option value='" + data.rows[i].DEV_CHARGPILE + "' >" + data.rows[i].YUNXING_BH + "</option>");
                    }
                }
            });
    } else {
        $("#zbh").html("<option value='' >—请选择—</option>");
    }
}
