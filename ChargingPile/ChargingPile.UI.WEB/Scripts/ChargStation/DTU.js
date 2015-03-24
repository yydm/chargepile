$(function () {
    $("#dlg").parent().bgiframe();
    getStation1();
    getStation2();
    $("#t_dtu").datagrid({
        url: "/WebService/DTUService.ashx",
        queryParams: { action: "getdtu", zhanbh: "" },
        fit: true,
        pagination: true,
        nowrap: false,
        fitColumns: true,
        rownumbers: true,
        singleSelect: true,
        striped: true,
        border: false,
        toolbar: "#d_tb",
        pageList: [10, 20, 30, 50],
        pageSize: 20,
        columns: [[
                    { field: "ID", title: "唯一id", width: 10, align: 'center', hidden: true },
                    { field: "ZHAN_MC", title: "充电场站名称", width: 120, align: 'center' },
                    { field: "PILECOUNTS", title: "匹配桩数量", width: 100, align: 'center' },
                    { field: "SERVERID", title: "服务器id", width: 90, align: 'center' },
                    { field: "DTUID", title: "DTUID", width: 90, align: 'center' },
                    { field: "DTUTYPE", title: "设备型号", width: 100, align: 'center' },
                    { field: "DTUNAME", title: "设备名称", width: 100, align: 'center' },
                    { field: "PHONE", title: "SIM卡号", width: 100, align: 'center' },
                    { field: "SVRPWD", title: "服务器登陆密码", width: 100, align: 'center',
                        formatter: function (value, src) {
                            if (value != null&&value!="") {
                                return "*****";
                            }

                        }
                     },
                    { field: "CREATEDT", title: "创建时间", width: 80, align: 'center',
                        formatter: function (value, src) {
                            if (value != null) {
                                return eval("new " + value.split('/')[1]).Format("yyyy-MM-dd");
                            }

                        }
                    },
                    { field: 'action', title: '操作', width: 80, align: 'center',
                        formatter: function (value, row, index) {
                            var html = '<a href="javascript:editfunc(' + index + ')" class="easyui-linkbutton" plain="true" title="修改" iconcls="icon-edit"></a>' +
                                       '<a href="javascript:delfunc(' + index + ')" class="easyui-linkbutton" plain="true" title="删除" iconcls="icon-cancel"></a>';
                            return html;
                        }
                    }
                ]],
        onLoadSuccess: function () {
            $($('#t_dtu').datagrid("getPanel")).find('a.easyui-linkbutton').linkbutton();
        }
    });
});
//充电站改变联动数据
function zhanChange() {
    var zhanbh = $("#ZHANMC").val();
    $("#t_dtu").datagrid("load", { action: "getdtu", zhanbh: zhanbh });
}

//添加方法
function addfunc(id) {
    $("#dlg").dialog("open").dialog("setTitle", "DTU基本信息编辑");
    $("#ZHUAN_MC").val("");
    $("#SERVERID,#DTUID,#DTUTYPE,#DTUNAME,#PHONE,#SVRPWD").val("");
    url = "/WebService/DTUService.ashx?action=adddtu";
}
//修改方法
function editfunc(id) {
    var selected = $('#t_dtu').datagrid('getSelected');
    $("#dlg").dialog("open").dialog("setTitle", "DTU基本信息编辑");

    $("#ZHUAN_MC").val(selected.ZHUAN_BH);
    $("#SERVERID").val(selected.SERVERID);
    $("#DTUID").val(selected.DTUID);
    $("#DTUTYPE").val(selected.DTUTYPE);
    $("#DTUNAME").val(selected.DTUNAME);
    $("#PHONE").val(selected.PHONE);
    $("#SVRPWD").val(selected.SVRPWD);
//    if (selected.TOUYOU_SJ != null || selected.TOUYOU_SJ != "") {
//        var TOUYOU_SJ = eval("new " + (selected.TOUYOU_SJ).split('/')[1]).Format("yyyy-MM-dd");
//        if (TOUYOU_SJ == "1-01-01") {
//            $("#TOUYOU_SJ").val("");
//        }
//        else {
//            $("#TOUYOU_SJ").val(TOUYOU_SJ);
//        }
//    } else {
//        $("#TOUYOU_SJ").val("");
//    }
    url = "/WebService/DTUService.ashx?action=editdtu&id=" + selected.ID;


}
//保存方法
var url;
function save() {
    
    var zhanbh = $("#ZHUAN_MC").val();
    if (zhanbh == "") {
        $.messager.alert('提示', '请选择充电场站！');
        return;
    }
    $('#fm').form('submit', {
        url: url,
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (result) {
            var result = eval('(' + result + ')');
            if (result.success) {
                $('#dlg').dialog('close');
                $("#t_dtu").datagrid("reload");
                $.messager.alert('提示', result.msg);
            } else {
                $.messager.alert("提示", result.msg);
            }
        }
    });


}
//删除方法
function delfunc(id) {
    var selected = $('#t_dtu').datagrid('getSelected');
    $.messager.confirm('提示', '确定删除?',
                function (r) {
                    if (r) {
                        $.ajax({
                            url: "/webservice/DTUService.ashx?action=deldtu",
                            type: "post",
                            data: "id=" + selected.ID,
                            datatype: "json",
                            success: function (result) {
                                var result = eval('(' + result + ')');
                                if (result.success) {
                                    $('#dlg').dialog('close');
                                    $("#t_dtu").datagrid("reload");
                                    $.messager.alert('提示', result.msg);
                                } else {
                                    $.messager.alert("提示", result.msg);
                                }
                            }
                        });
                    }
                });
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

function getStation2() {
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
            $("#ZHUAN_MC").html("<option value='' >—请选择—</option>");
            for (var i = 0; i < length; i++) {
                $("#ZHUAN_MC").append("<option value=" + val.rows[i].ZhanBh + " >" + val.rows[i].Zhan_Jc + "</option>");
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

