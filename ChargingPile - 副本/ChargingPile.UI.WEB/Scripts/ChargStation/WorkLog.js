$(function () {
    
    $("#endtime").val((new Date()).Format("yyyy-MM-dd"));
    $("#begintime").val((new Date()).Format("yyyy-MM") + "-01");
   
    var begintime = $("#begintime").val();
    var endtime = $("#endtime").val();

    $("#t_worklog").datagrid({
        url: "/WebService/DTUService.ashx",
        queryParams: { action: "getworklog",begintime: begintime, endtime: endtime },
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
                    { field: "Id", title: "唯一id", width: 180, align: 'center', hidden: true },
                    { field: "LogDate", title: "时间", width: 100, align: 'center',
                        formatter: function (value, src) {
                            if (value != null) {
                                return eval("new " + value.split('/')[1]).Format("yyyy-MM-dd hh:mm:ss");
                            }
                        }
                    },
                    { field: "Worknum", title: "登录工号", width: 100, align: 'center' },
                    { field: "Operator", title: "登录姓名", width: 100, align: 'center' },
                    { field: 'OprSrc', title: '内容', width: 200, align: 'center' }

                ]],
        onLoadSuccess: function () {
            $($('#t_worklog').datagrid("getPanel")).find('a.easyui-linkbutton').linkbutton();
        }

    });


});



//条件查询
function search() {
    var begintime = $("#begintime").val();
    var endtime = $("#endtime").val();
    $("#t_worklog").datagrid("load", { action: "getworklog",begintime: begintime, endtime: endtime });
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