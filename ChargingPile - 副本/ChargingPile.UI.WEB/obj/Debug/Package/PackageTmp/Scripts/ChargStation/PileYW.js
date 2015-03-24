var zhanbh;
var zhuanbh;
$(function () {
    zhuanbh = getQueryString("pileno");
    zhanbh = zhuanbh.substr(0, 3);
    $("#dlg").parent().bgiframe();
    setTimeout(function () {
        getPileYXBH();
    }, 1);
    getJxlx();
    getJxjb();
    $("#endtime").val((new Date()).Format("yyyy-MM-dd"));
    $("#begintime").val(new Date().getFullYear() + "-01-01");
    var begintime = $("#begintime").val();
    var endtime = $("#endtime").val();
    setTimeout(function () {
        getZYXBH();
    }, 2);
    setTimeout(function () {
        $("#t_chargpiletain").datagrid({
            url: "/WebService/ChargPileMaintainService.ashx",
            queryParams: { action: "getpilejl", zhanbh: zhanbh, zhuangbh: $("#zbh").val(), begintime: begintime, endtime: endtime, jxlx: "" },
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
                    { field: "Id", title: "唯一id", width: 10, align: 'center', hidden: true },
                    { field: "Zhan_Bh", title: "充电站编号", width: 10, align: 'center', hidden: true },
                    { field: "Zhuan_Id", title: "桩id", width: 10, align: 'center', hidden: true },
                    { field: "jxlx", title: "运维类型", width: 10, align: 'center', hidden: true },
                    { field: "jxjb", title: "运维级别", width: 10, align: 'center', hidden: true },
                    { field: "Zhuan_Mc", title: "充电场站名称", width: 100, align: 'center', hidden: true },
                    { field: "YunXing_Bh", title: "桩运行编号", width: 100, align: 'center' },
                    { field: "ChangJia", title: "桩厂家", width: 100, align: 'center', hidden: true },
                    { field: "ZhuangLei_X", title: "桩类型", width: 100, hidden: true, align: 'center' },
                    { field: "JianXiu_Lx", title: "运维类型", width: 100, align: 'center' },
                    { field: "JianXiu_Jb", title: "运维级别", width: 100, align: 'center' },
                    { field: "JianXiu_Sj", title: "运维时间", width: 100, align: 'center',
                        formatter: function (value, src) {
                            if (value != null) {
                                return eval("new " + value.split('/')[1]).Format("yyyy-MM-dd");
                            }

                        }
                    },
                    { field: "JianXiu_Jl", title: "运维记录", width: 100, align: 'center' },
                    { field: "JianXiu_R", title: "运维人", width: 100, align: 'center' }
                ]]

        }); ;
    }, 3);

});


//条件查询
function termsearch() {
    var begintime = $("#begintime").val();
    var endtime = $("#endtime").val();
    var jxlx = $("#jxlx").val();
    var zhuangbh = $("#zbh").val();
    $("#t_chargpiletain").datagrid("load", { action: "getpilejl", zhanbh: zhanbh, zhuangbh: zhuangbh, begintime: begintime, endtime: endtime, jxlx: jxlx });
}

//加载桩运行编号下拉菜单
function getPileYXBH() {
    $.ajax({
        url: "/WebService/ChargPileMaintainService.ashx",
        type: "post",
        async: false,
        data: { action: "getyxbh", zhuan_bh: zhanbh },
        dataType: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            var length = val.rows.length;
            $("#zbh").html("<option value='' >—请选择—</option>");
            if (zhuanbh.length > 0) {
                for (var i = 0; i < length; i++) {
                    if (val.rows[i].YUNXING_BH != null) {
                        $("#zbh").append("<option value=" + val.rows[i].YUNXING_BH + " >" + val.rows[i].YUNXING_BH + "</option>");
                    }
                }
            }
        }
    });
}


//获取加载运行编号
function getZYXBH() {
    $.ajax({
        url: "/WebService/ChargPileMaintainService.ashx",
        type: "post",
        async: false,
        data: { action: "getzyxbh", zhuang_bh: zhuanbh },
        dataType: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            if (zhuanbh.length > 0) {
                yxbh = val.rows[0].YUNXING_BH;
                $("#zbh").val(yxbh);
            }
        }
    });
}

//加载检修类型下拉菜单
function getJxlx() {
    $.ajax({
        url: "/WebService/ChargPileMaintainService.ashx",
        type: "post",
        async: false,
        data: "action=getjxlx",
        dataType: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            var length = val.rows.length;
            $("#JIANXIU_LX").html("<option value='' >—请选择—</option>");
            $("#jxlx").html("<option value='' >—请选择—</option>");
            for (var i = 0; i < length; i++) {
                $("#JIANXIU_LX").append("<option value=" + val.rows[i].Code + " >" + val.rows[i].Codename + "</option>");
                $("#jxlx").append("<option value=" + val.rows[i].Code + " >" + val.rows[i].Codename + "</option>");
            }
        }
    });
}


//加载检修级别下拉菜单
function getJxjb() {
    $.ajax({
        url: "/WebService/ChargPileMaintainService.ashx",
        type: "post",
        async: false,
        data: "action=getjxjb",
        dataType: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            var length = val.rows.length;
            $("#JIANXIU_JB").html("<option value='' >—请选择—</option>");
            for (var i = 0; i < length; i++) {
                $("#JIANXIU_JB").append("<option value=" + val.rows[i].Code + " >" + val.rows[i].Codename + "</option>");
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