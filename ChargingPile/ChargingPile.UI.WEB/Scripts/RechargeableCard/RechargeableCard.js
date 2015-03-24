$(function () {
    getStation();
    $("#t_rechargeablecard").datagrid({
        url: "/WebService/RequestHandling.ashx",
        queryParams: { action: "getListQuery", cardno: "", sdt: "", edt: "",zhanid:"" },
        fit: true,
        nowrap: false,
        fitColumns: true,
        border: false,
        rownumbers: true,
        singleSelect: true,
        pagination: true,
        toolbar: "#d_tb",
        pageList: [20, 30, 50],
        pageSize: 20,
        striped: true,
        columns: [[
                    { field: "CARD_NO", title: "充值卡", width: 100, align: 'center' },
                    { field: "ZHUAN_MC", title: "充电场站", width: 110, align: 'center' },
//                    { field: "ZHUAN_ID", title: "桩编号", width: 50, align: 'center' },
                    { field: "YUNXING_BH", title: "桩运行编号", width: 60, align: 'center' },
                    { field: "STARTDT", title: "充电开始时间", width: 100, align: 'center'
                        //                        formatter: function (value, src) {
                        //                            if (value != null) {
                        //                                return eval("new " + value.split('/')[1]).Format("yyyy-MM-dd");
                        //                            }
                        //                        }
                    },
                    { field: "ENDDT", title: "充电结束时间", width: 100, align: 'center'
                        //                        formatter: function (value, src) {
                        //                            if (value != null) {
                        //                                return eval("new " + value.split('/')[1]).Format("yyyy-MM-dd");
                        //                            }
                        //                        }
                    },
                    { field: "VALUE_HIGH", title: "电价-峰", width: 40, align: 'center' },
                    { field: "VALUE_NORMAL", title: "电价-平", width: 40, align: 'center' },
                    { field: "VALUE_LOW", title: "电价-谷", width: 40, align: 'center' },
                    { field: "VALUE_TIP", title: "电价-尖", width: 40, align: 'center' },
                    { field: "POWER_HIGH", title: "电量-峰", width: 40, align: 'center' },
                    { field: "POWER_NORMAL", title: "电量-平", width: 40, align: 'center' },
                    { field: "POWER_LOW", title: "电量-谷", width: 40, align: 'center' },
                    { field: "POWER_TIP", title: "电量-尖", width: 40, align: 'center' },
                    { field: "CHARGE_POWER", title: "电量-总", width: 40, align: 'center' },
                    { field: "CHARGE_MONEY", title: "总金额", width: 40, align: 'center' }
                ]],
        onLoadSuccess: function () {
            $($('#t_rechargeablecard').datagrid("getPanel")).find('a.easyui-linkbutton').linkbutton();
        }
    });
});
//条件查询
function termsearch() {
    var cardno = $("#cardno").val();
    var sdt = $("#sdt").val();
    var edt = $("#edt").val();
    var zhanid = $("#ZHANMC").val();
    var zhuangid = $("#zhuangid").val();
    $("#t_rechargeablecard").datagrid("load", { action: "getListQuery", cardno: cardno, sdt: sdt, edt: edt, zhanid: zhanid, zhuangid: zhuangid });
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
//导出Excel
function OutExcel() {
    var cardno = $("#cardno").val();
    var sdt = $("#sdt").val();
    var edt = $("#edt").val();
    var zhanid = $("#ZHANMC").val();
    var zhuangid = $("#zhuangid").val();
    window.open("/WebService/RequestHandling.ashx?action=CardQueryOutExcel&cardno=" + cardno + "&sdt=" + sdt + "&edt=" + edt + "&zhanid=" + zhanid + "&zhuangid=" + zhuangid + "&r=" + Math.random());
}
//加载充电站下拉菜单
function getStation() {
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