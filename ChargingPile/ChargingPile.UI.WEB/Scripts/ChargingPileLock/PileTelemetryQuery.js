$(function () {

    $("#t_PileTelemetryQuery").datagrid({
        url: "/WebService/RequestHandling.ashx",
        queryParams: {action: "getPileTelemetryQuery", pileno: "", sdt: "", edt: "",itemname:""},
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
                    { field: "ZHUAN_MC", title: "站名称", width: 50, align: 'center' },
        //                    { field: "ZHUAN_ID", title: "充电桩编号", width: 50, align: 'center' },
                    {field: "YUNXING_BH", title: "桩运行编号", width: 50, align: 'center' },
                    { field: "ZONGXIAN_DZ", title: "桩总线地址", width: 50, align: 'center' },
                    { field: "GATITEMID", title: "采集项标识", width: 60, align: 'left' },
                    { field: "ITEMNAME", title: "名称", width: 110, align: 'left' },
                    { field: "M_UNITS", title: "单位", width: 50, align: 'left' },
                    { field: "ITEMDESC", title: "描述", width: 150, align: 'left' },
                    { field: "GATDT", title: "采集时间",width: 100, align: 'center' },
                    { field: "M_VALUE", title: "值", width: 80, align: 'left' },
                ]],
        onLoadSuccess: function () {
            $($('#t_PileTelemetryQuery').datagrid("getPanel")).find('a.easyui-linkbutton').linkbutton();
        }
    });
});




//条件查询
function termsearch() {
    var pileno = $("#pileno").val();
    var sdt = $("#sdt").val();
    var edt = $("#edt").val();
    var itemname = $("#itemname").val();
    $("#t_PileTelemetryQuery").datagrid("load", { action: "getPileTelemetryQuery", pileno: pileno, sdt: sdt, edt: edt, itemname: itemname });
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
    var pileno = $("#pileno").val();
    var sdt = $("#sdt").val();
    var edt = $("#edt").val();
    var itemname = $("#itemname").val();
    window.open("/WebService/RequestHandling.ashx?action=PileTelemetryQueryOutExcel&pileno=" + pileno + "&sdt=" + sdt + "&edt=" + edt + "&itemname="+ itemname +"&r=" + Math.random());
}