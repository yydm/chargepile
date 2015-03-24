$(function () {
    $("#t_chargpiletype").datagrid({
        url: "/WebService/ChargPileTypeService.ashx",
        queryParams: { action: "getcpt" },
        fit: true,
        nowrap: false,
        fitColumns: true,
        singleSelect: true,
        rownumbers: true,
        striped: true,
        border: false,
        //pagination: true,
        columns: [[
                    { field: "PARSERKEY", title: "协议标识编码", width: 150, align: 'center' },
                    { field: "CHANGJIA", title: "桩厂家", width: 150, align: 'center' },
                    { field: "ZHUANGXING_H", title: "桩型号", width: 100, align: 'center' },
                    { field: "ZHUANGLEI_X", title: "桩类型", width: 150, align: 'center' },
                    { field: "CREATEDT", title: "创建时间", width: 100,align: 'center',
                        formatter: function (value, src) {
                            if (value != null) {
                                return eval("new " + value.split('/')[1]).Format("yyyy-MM-dd");
                            }

                        }
                    },
                    { field: "UPDATEDT", title: "更新时间", width: 100,align: 'center',
                        formatter: function (value, src) {
                            if (value != null) {
                                return eval("new " + value.split('/')[1]).Format("yyyy-MM-dd");
                            }

                        }
                    },
                    { field: "REMARK", title: "备注", width: 150, align: 'center' }
        //                    { field: 'action', title: '修改', width: 80, align: 'center',
        //                        formatter: function (value, row, index) {
        //                            return '<a href="javascript:editfunc(' + index + ')" class="easyui-linkbutton" plain="true" iconcls="icon-edit">修改</a>';
        //                        }
        //                    },
       //                    {field: 'action1', title: '删除', width: 80, align: 'center',
       //                    formatter: function (value, row, index) {
       //                        return '<a href="javascript:deletefunc(' + index + ')" class="easyui-linkbutton" plain="true" iconcls="icon-remove">删除</a>';
       //                    }
       //                }
                ]],
        onLoadSuccess: function () {
            $($('#t_chargpiletype').datagrid("getPanel")).find('a.easyui-linkbutton').linkbutton();
        }
    });
});


//修改方法
function editfunc(id) {
    $('#t_chargpiletype').datagrid("unselectAll");
    $('#t_chargpiletype').datagrid("selectRow", id);
    var selected = $('#t_chargpiletype').datagrid('getSelected');
    $("#dlg").dialog("open").dialog("setTitle", "充电桩类型编辑框");
    $("#PARSERKEY").val(selected.PARSERKEY);
    document.getElementById("PARSERKEY").disabled = true;
    $("#CHANGJIA").val(selected.CHANGJIA);
    $("#ZHUANGLEI_X").val(selected.ZHUANGLEI_X);
    $("#ZHUANGXING_H").val(selected.ZHUANGXING_H);
    if (selected.CREATEDT != null) {
        var CREATEDT = eval("new " + (selected.CREATEDT).split('/')[1]).Format("yyyy-MM-dd");
        $("#CREATEDT").val(CREATEDT);
    } else {
        $("#CREATEDT").val("");
    }
    $("#REMARK").val(selected.REMARK);
    url = "/WebService/ChargPileTypeService.ashx?action=edittype";
}
//添加方法
function addfunc(id) {
    $("#dlg").dialog("open").dialog("setTitle", "充电桩类型编辑框");
    $("#PARSERKEY,#CHANGJIA,#ZHUANGLEI_X,#ZHUANGXING_H,#CREATEDT,#REMARK").val("");
    document.getElementById("PARSERKEY").disabled = false;
    url = "/WebService/ChargPileTypeService.ashx?action=addtype";
}

//保存方法
var url;
function save() {
    document.getElementById("PARSERKEY").disabled = false;
    $('#fm').form('submit', {
        url: url,
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (result) {
            var result = eval('(' + result + ')');
            if (result.success) {
                $('#dlg').dialog('close');
                $("#t_chargpiletype").datagrid("reload");
                $.messager.alert('提示', result.msg);
            } else {
                $.messager.alert("提示", result.msg);
            }
        }
    });


}

//删除方法
function deletefunc(id) {
    var selected = $('#t_chargpiletype').datagrid('getSelected');
    $.messager.confirm('提示', '确定删除?',
                function (r) {
                    if (r) {
                        $.ajax({
                            url: "/webservice/chargpiletypeservice.ashx?action=deltype",
                            type: "post",
                            data: "parserkey=" + selected.PARSERKEY,
                            datatype: "json",
                            success: function (result) {
                                var result = eval('(' + result + ')');
                                if (result.success) {
                                    $('#dlg').dialog('close');
                                    $("#t_chargpiletype").datagrid("reload");
                                    $.messager.alert('提示', result.msg);
                                } else {
                                    $.messager.alert("提示", result.msg);
                                }
                            }
                        });
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