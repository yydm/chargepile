var zhanbh;
var zhuanbh;
var yxbh;
$(function () {
    zhuanbh = getQueryString("pileno");
    if (zhuanbh.length > 3) {
        zhanbh = zhuanbh.substr(0, 3);
    } else {
        zhanbh = zhuanbh;
    }
    getStation1();
    setTimeout(function () {
        $("#ZHANMC").val(zhanbh);
    }, 1);
    setTimeout(function () {
        zhanChange();
    }, 2);
    if (zhuanbh.length > 3) {
        setTimeout(function () {
            getZYXBH(zhuanbh);
        }, 20);
    }
    var zhuangbh = $("#zbh").val();
    $("#endtime").val((new Date()).Format("yyyy-MM-dd"));
    $("#begintime").val((new Date()).Format("yyyy-MM") + "-01");
    var begintime = $("#begintime").val();
    var endtime = $("#endtime").val();
    $("#t_chargpiletain").datagrid({
        url: "/WebService/ChargRecordService.ashx",
        queryParams: { action: "getcdjl", zhanbh: zhanbh, zhuangbh: zhuangbh, begintime: begintime, endtime: endtime, r: Math.random() },
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
                    { field: "ZHAN_JC", title: "充电场站名称", width: 100, align: 'center' },
                    { field: "YUNXING_BH", title: "桩运行编号", width: 100, align: 'center' },
                    { field: "STARTDT", title: "充电开始时间", width: 100, align: 'center',
                        formatter: function (value, src) {
                            if (value != null) {
                                return eval("new " + value.split('/')[1]).Format("yyyy-MM-dd hh:mm");
                            }

                        }
                    },
                    { field: "ENDDT", title: "充电结束时间", width: 100, align: 'center',
                        formatter: function (value, src) {
                            if (value != null) {
                                return eval("new " + value.split('/')[1]).Format("yyyy-MM-dd hh:mm");
                            }

                        }
                    },
                    { field: "CHARGE_POWER", title: "充电电量(KWH)", width: 100, align: 'center' },
                    { field: "CHARGE_MONEY", title: "充电金额(元)", width: 100, align: 'center' },
                    { field: "CARD_NO", title: "充值卡号", width: 100, align: 'center' }
                ]]
    });
});

//条件查询
function termsearch() {
    var begintime = $("#begintime").val();
    var endtime = $("#endtime").val();
    var zhuangbh = $("#zbh").val();
    var zhan_bh = $("#ZHANMC").val();
    $("#t_chargpiletain").datagrid("load", { action: "getcdjl", zhanbh: zhan_bh, zhuangbh: zhuangbh, begintime: begintime, endtime: endtime });
}



//加载充电站下拉菜单
function getStation1() {
    $.ajax({
        url: "/WebService/ChargPileMaintainService.ashx",
        type: "post",
        async: false,
        data: "action=getstation",
        dataType: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            var length = val.rows.length;
            $("#ZHANMC").html("<option value='' >—请选择—</option>");
            for (var i = 0; i < length; i++) {
                $("#ZHANMC").append("<option value=" + val.rows[i].ZhanBh + " >" + val.rows[i].Zhan_Jc + "</option>");
            }
        }
    });
}

//充电站变动方法
function zhanChange() {
    var zhuan_bh = $("#ZHANMC").val();
    if (zhuan_bh != "") {
        getPileYXBH(zhuan_bh);
    } else {
        $("#zbh").html("<option value='' >—请选择—</option>");
    }
    var zhanMc = $("#ZHANMC option:selected").text();
    if (zhanMc == "—请选择—") {
        $("#title").html("所有充电站");
    } else {
        $("#title").html(zhanMc);
    }
}


//加载桩运行编号下拉菜单
function getPileYXBH(id) {
    $.ajax({
        url: "/WebService/ChargPileMaintainService.ashx",
        type: "post",
        async: false,
        data: { action: "getyxbh", zhuan_bh: id },
        dataType: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            var length = val.rows.length;
            $("#zbh").html("<option value='' >—请选择—</option>");
            for (var i = 0; i < length; i++) {
                if (val.rows[i].YUNXING_BH != null) {
                    $("#zbh").append("<option value=" + val.rows[i].YUNXING_BH + " >" + val.rows[i].YUNXING_BH + "</option>");
                }
            }
        }
    });
}

//获取加载运行编号
function getZYXBH(id) {
    $.ajax({
        url: "/WebService/ChargPileMaintainService.ashx",
        type: "post",
        async: false,
        data: { action: "getzyxbh", zhuang_bh: id },
        dataType: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            yxbh = val.rows[0].YUNXING_BH;
            if (yxbh != null) {
                $("#zbh").val(yxbh);
            }
        }
    });
}


//日期时间格式化方法，可以格式化年、月、日、时、分、秒、周
Date.prototype.Format = function (formatStr) {
    var Week = ['日', '一', '二', '三', '四', '五', '六'];
    return formatStr.replace(/yyyy|YYYY/, this.getFullYear())
 	             .replace(/yy|YY/, (this.getYear() % 100) > 9 ? (this.getYear() % 100).toString() : '0' + (this.getYear() % 100))
 	             .replace(/MM/, (this.getMonth() + 1) > 9 ? (this.getMonth() + 1).toString() : '0' + (this.getMonth() + 1)).replace(/M/g, (this.getMonth() + 1))
 	             .replace(/w|W/g, Week[this.getDay()])
 	             .replace(/dd|DD/, this.getDate() > 9 ? this.getDate().toString() : '0' + this.getDate()).replace(/d|D/g, this.getDate())
 	             .replace(/HH|hh/g, this.getHours() > 9 ? this.getHours().toString() : '0' + this.getHours()).replace(/H|h/g, this.getHours())
 	             .replace(/mm/g, this.getMinutes() > 9 ? this.getMinutes().toString() : '0' + this.getMinutes()).replace(/m/g, this.getMinutes())
 	             .replace(/ss/g, this.getSeconds() > 9 ? this.getSeconds().toString() : '0' + this.getSeconds()).replace(/S|s/g, this.getSeconds());
};

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