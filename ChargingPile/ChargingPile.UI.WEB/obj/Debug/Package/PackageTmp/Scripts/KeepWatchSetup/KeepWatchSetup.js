$(function () {
    $("#t_KeepWatchSetup").datagrid({
        url: "/WebService/RequestHandling.ashx",
        queryParams: { action: "getChargStation" },
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
        columns: [[
                    { field: "ISMONITOR", title: "监视状态", width: 0.7, align: 'center',
                        formatter: function (value, row, index) {
                            var html = "";
                            if (value == "1") {
                                var html = '<input type="image" name="imageField"  width="18" height="17" src="../../Images/view.gif" />';
                            }
                            return html;
                        }
                    },
                    { field: "ZHAN_BH", title: "充电场站编号", width: 1, align: 'center', hidden: true },
                    { field: "ZHUAN_MC", title: "充电场站名称", width: 10, align: 'left' },

                    { field: "ISMONITORNEW", title: "操作", width: 0.5, align: 'center',
                        formatter: function (value, row, index) {
                            var html = "" ;
                            if (value == "0") {
                                html = '<a href="javascript:ViewFunc(' + index + ',1)" class="easyui-linkbutton" plain="true" title="监视" iconcls="icon-ok"></a>';
                            }
                            if (value == "1") {
                                html += '<a href="javascript:ViewFunc(' + index + ',0)" class="easyui-linkbutton" plain="true" title="取消" iconcls="icon-cancel"></a>';
                            }
                            return html;
                        }
                    }

                ]],
        onLoadSuccess: function () {
            $($('#t_KeepWatchSetup').datagrid("getPanel")).find('a.easyui-linkbutton').linkbutton();
        }

    });


});
//监视和取消方法
function ViewFunc(index, sort) {
    var selected = $('#t_KeepWatchSetup').datagrid('getSelected');
    var msg;
    if (sort == "1")
        msg = "您真的确认监视吗？";
    else
        msg = "您真的确认取消监视吗？";
    $.messager.confirm('提示', msg,
                function (r) {
                    if (r) {
                        $.ajax({
                            url: "/webservice/RequestHandling.ashx",
                            type: "post",
                            data: "action=setView&zhanid=" + selected.ZHAN_BH + "&sort=" + sort,
                            datatype: "json",
                            success: function (result) {
                                var result = eval('(' + result + ')');
                                if (result.success) {
                                    $("#t_KeepWatchSetup").datagrid("reload");
                                    $.messager.alert('提示', result.msg);
                                } else {
                                    $.messager.alert("提示", result.msg);
                                }
                            }
                        });
                    }
                });


}