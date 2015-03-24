$(function () {
        getStation();
        $("#t_rechargeablecard").datagrid({
            url: "/WebService/RequestHandling.ashx",
            queryParams: { action: "getListTotal", zhanId: "", sdt: "", edt: "" },
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
                        { field: "ZHUAN_MC", title: "充电场站", width: 100, align: 'center' },
//                        { field: "ZHUAN_ID", title: "桩编号", width: 60, align: 'center' },
                        { field: "ZHUANGXING_H", title: "桩型号", width: 75, align: 'center' },
                        { field: "ZHUANGLEI_X", title: "桩类型", width: 90, align: 'center' },
                        { field: "YUNXING_BH", title: "桩运行编号", width: 75, align: 'center' },
                        { field: "CHARGE_TIME_MIN", title: "累计充电时长", width: 60, align: 'center' },
                        { field: "CHARGE_NUMBER", title: "累计充电次数", width: 60, align: 'center' },
                        { field: "GAT_DATA_RECORD", title: "累计充电电量", width: 60, align: 'center' },
                        { field: "RUNRAT", title: "运行率", width: 60, align: 'center' },
                        { field: "USERAT", title: "使用率", width: 60, align: 'center' }
                    ]],
            onLoadSuccess: function () {
                $($('#t_rechargeablecard').datagrid("getPanel")).find('a.easyui-linkbutton').linkbutton();
            }

        });


});
//条件查询
function termsearch() {
    var zhanid = $("#zhanid").val();
    var sdt = $("#sdt").val();
    var edt = $("#edt").val();
    $("#t_rechargeablecard").datagrid("load", { action: "getListTotal", zhanid: zhanid, sdt: sdt, edt: edt });
}
//导出Excel
function OutExcel() {
    var zhanid = $("#zhanid").val();
    var sdt = $("#sdt").val();
    var edt = $("#edt").val();
    window.open("/WebService/RequestHandling.ashx?action=CardTotalOutExcel&zhanid=" + zhanid + "&sdt=" + sdt + "&edt=" + edt + "&r=" + Math.random());
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
            $("#zhanid").html("<option value='' >—请选择—</option>");
            for (var i = 0; i < length; i++) {
                $("#zhanid").append("<option value=" + val.rows[i].ZhanBh + " >" + val.rows[i].Zhan_Jc + "</option>");
            }
        }
    });
}