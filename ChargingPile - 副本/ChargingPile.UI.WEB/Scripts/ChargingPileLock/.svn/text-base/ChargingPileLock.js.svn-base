$(function () {

    $("#t_chargingpilelock").datagrid({
        url: "/WebService/RequestHandling.ashx",
        queryParams: { action: "getPileLockQuery"},
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
        striped:true,
        columns: [[
                    { field: "ZHUANMC", title: "充电场站名称", width: 100, align: 'center' },
                    { field: "YUNXING_BH", title: "桩运行编号", width: 100, align: 'center' },
                    { field: "POWERPILENAME", title: "充电桩名称", width: 100, align: 'center' },
                    { field: "LOGDESC", title: "异常说明", width: 500, align: 'left' }
                ]],
        onLoadSuccess: function () {
            $($('#t_chargingpilelock').datagrid("getPanel")).find('a.easyui-linkbutton').linkbutton();
        }
    });
});
//条件查询
function termsearch() {
    $("#t_chargingpilelock").datagrid("load", { action: "getPileLockQuery"});
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
    window.open("/WebService/RequestHandling.ashx?action=PileLockQueryOutExcel&tm=" + Math.random());
}