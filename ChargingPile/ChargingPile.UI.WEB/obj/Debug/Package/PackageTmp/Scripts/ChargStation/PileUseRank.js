var zhanbh;
var zhuanbh;
$(function () {
    zhuanbh = getQueryString("pileno");
    if (zhuanbh.length > 3) {
        zhanbh = zhuanbh.substr(0, 3);
    } else {
        zhanbh = zhuanbh;
    }
    $("#t_chargpiletain").datagrid({
        url: "/WebService/ChargRecordService.ashx",
        queryParams: { action: "getyspm",zhanbh: zhanbh},
        fit: true,
        nowrap: false,
        fitColumns: true,
        striped: true,
        border: false,
        rownumbers: true,
        singleSelect: true,
        pagination: true,
        toolbar: "#d_tb",
        pageList: [10, 20, 30, 50],
        pageSize: 20,
        columns: [[
                    { field: "ZHAN_JC", title: "充电场站名称", width: 100, align: 'center',
                        formatter: function (value, src) {
                            if (value != null) {
                                $("#title").html(value);
                                return value;
                            }

                        },
                        hidden: false
                    },
                    { field: "YUNXING_BH", title: "桩运行编号", width: 100, align:"center" },
                    { field: "CHARGE_POWER", title: "充电总电量(KWH)", width: 100, align: "center" }
                ]]
    });
});



/*
* 获取url参数值
*/
function getQueryString(name) {
    var url = location.href;
    var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
    var paraObj = {};
    for (var i = 0; j = paraString[i]; i++) {
        paraObj[j.substring(0, j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=") + 1, j.length);
    }
    var returnValue = paraObj[name.toLowerCase()];
    if (typeof (returnValue) == "undefined") {
        return "";
    } else {
        return returnValue;
    }
}





