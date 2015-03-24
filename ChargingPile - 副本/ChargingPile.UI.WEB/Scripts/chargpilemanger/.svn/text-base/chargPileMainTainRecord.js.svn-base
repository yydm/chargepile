$(function () {
    $("#dlg").parent().bgiframe();
    getStation1();
    getJxlx();
    getJxjb();
    $("#endtime").val((new Date()).Format("yyyy-MM-dd"));
    $("#begintime").val(new Date().getFullYear() + "-01-01");
    var begintime = $("#begintime").val();
    var endtime = $("#endtime").val();
    $("#t_chargpiletain").datagrid({
        url: "/WebService/ChargPileMaintainService.ashx",
        queryParams: { action: "getjl", zhanbh: "", zhuangbh: "", begintime: begintime, endtime: endtime, jxlx: "" },
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
                    { field: "JianXiu_Jb", title: "运维级别", width: 10, align: 'center', hidden: true },
                    { field: "jxjb", title: "运维级别", width: 10, align: 'center', hidden: true },
                    { field: "JianXiu_Jl", title: "运维记录", width: 10, align: 'center', hidden: true },
                    { field: "JianXiu_R", title: "运维人", width: 10, align: 'center', hidden: true },
                    { field: "jxlx", title: "运维类型", width: 10, align: 'center', hidden: true },
                    { field: "Zhan_Jc", title: "充电场站名称", width: 180, align: 'center' },
                    { field: "YunXing_Bh", title: "桩运行编号", width: 140, align: 'center' },
                    { field: "ChangJia", title: "桩厂家", width: 120, align: 'center' },
                    { field: "ZhuangLei_X", title: "桩类型", width: 180, align: 'center' },
                    { field: "JianXiu_Lx", title: "运维类型", width: 130, align: 'center' },
                    { field: "JianXiu_Sj", title: "运维时间", width: 130, align: 'center',
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
            $($('#t_chargpiletain').datagrid("getPanel")).find('a.easyui-linkbutton').linkbutton();
        }

    });


});
//条件查询
function termsearch() {
    var zhanbh = $("#ZHANMC").val();
    var begintime = $("#begintime").val();
    var endtime = $("#endtime").val();
    var jxlx = $("#jxlx").val();
    $("#t_chargpiletain").datagrid("load", { action: "getjl", zhanbh: zhanbh, zhuangbh: "", begintime: begintime, endtime: endtime, jxlx: jxlx });
}
//添加方法
function addfunc() {
    $("#JIANXIU_LX,#JIANXIU_JB,#JIANXIU_SJ,#JIANXIU_JL,#JIANXIU_R").val("");
    getStation2();
    $("#YUNXING_BH").html("<option value='' >—请选择—</option>");
    $("#ZHUANGCHANG_J,#ZHUANGLEI_X").val("");
    $("#dlg").dialog("open").dialog("setTitle", "充电桩检修记录编辑");
    url = "/WebService/ChargPileMaintainService.ashx?action=addjl";
}

function set_select_val(sel, val) {
    if ($.browser.msie && $.browser.version == "6.0") {
        setTimeout(function () {
            sel.val(val);
        }, 1);
    } else {
        sel.val(val);
    }
} 

//修改方法
function editfunc(id) {
    var selected = $('#t_chargpiletain').datagrid('getSelected');
    $("#dlg").dialog("open").dialog("setTitle", "充电桩检修记录编辑");
    getStation2();

    setTimeout(function () {
        $("#ZHUAN_MC").val(selected.Zhan_Bh);
    }, 1);
    setTimeout(function () {
        zhanChange();
    }, 10);
    setTimeout(function () {
        $("#YUNXING_BH").val(selected.YunXing_Bh);
    }, 20);
    setTimeout(function () {
        yxbhChange();
    }, 30);

    

    $("#JIANXIU_LX").val(selected.jxlx);
    $("#JIANXIU_JB").val(selected.jxjb);
    $("#JIANXIU_JL").val(selected.JianXiu_Jl);
    $("#JIANXIU_R").val(selected.JianXiu_R);
    if (selected.JianXiu_Sj != null) {
        var JianXiu_Sj = eval("new " + (selected.JianXiu_Sj).split('/')[1]).Format("yyyy-MM-dd");
        $("#JIANXIU_SJ").val(JianXiu_Sj);
    } else {
        $("#JIANXIU_SJ").val("");
    }
    url = "/WebService/ChargPileMaintainService.ashx?action=editjl&id=" + selected.Id;
}
//保存方法
var url;
function save() {
    var zhanmc = $("#ZHUAN_MC").val();
    var yxbh = $("#YUNXING_BH").val();
    var lx = $("#JIANXIU_LX").val();
    var jb = $("#JIANXIU_JB").val();
    var sj = $("#JIANXIU_SJ").val();
    if (zhanmc == "") {
        $.messager.alert('提示', '请选择充电场站！');
        return;
    }
    if (yxbh == "") {
        $.messager.alert('提示', '请选择桩运行编号！');
        return;
    }
    if (lx == "") {
        $.messager.alert('提示', '请选择运维类型！');
        return;
    }
    if (jb == "") {
        $.messager.alert('提示', '请选择运维级别！');
        return;
    }
    if (sj == "") {
        $.messager.alert('提示', '请选择运维时间！');
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
                $.messager.alert('提示', result.msg);
                $("#t_chargpiletain").datagrid("reload");
            } else {
                $.messager.alert("提示", result.msg);
            }
        }
    });


}
//删除方法
function delfunc(id) {
    var selected = $('#t_chargpiletain').datagrid('getSelected');
    $.messager.confirm('提示', '确定删除?',
                function (r) {
                    if (r) {
                        $.ajax({
                            url: "/webservice/ChargPileMaintainService.ashx?action=deljl",
                            type: "post",
                            data: "id=" + selected.Id,
                            datatype: "json",
                            success: function (result) {
                                var result = eval('(' + result + ')');
                                if (result.success) {
                                    $('#dlg').dialog('close');
                                    $("#t_chargpiletain").datagrid("reload");
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

//加载运行编号
function getYunxingbh(id) {
    $.ajax({
        url: "/WebService/ChargPileMaintainService.ashx",
        type: "post",
        async: false,
        data: "action=getyxbh&&zhuan_bh=" + id,
        dataType: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            var length = val.rows.length;
            $("#YUNXING_BH").html("<option value='' >—请选择—</option>");
            for (var i = 0; i < length; i++) {
                if (val.rows[i].YUNXING_BH != null)
                    $("#YUNXING_BH").append("<option value=" + val.rows[i].YUNXING_BH + " >" + val.rows[i].YUNXING_BH + "</option>");
            }

        }
    });
}

//加载桩厂家和桩类型
function getCjAndLx(yid,zid) {
    $.ajax({
        url: "/WebService/ChargPileMaintainService.ashx",
        type: "post",
        async: false,
        data: "action=getcjlx&yxbh=" + yid+"&zhanbh="+zid,
        dataType: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            var length = val.rows.length;
            for (var i = 0; i < length; i++) {
                $("#ZHUANGCHANG_J").val(val.rows[i].CHANGJIA);
                $("#ZHUANGLEI_X").val(val.rows[i].ZHUANGLEI_X);
            }
        }
    });

}

//充电站变动方法
function zhanChange() {
    var zhuan_bh = $("#ZHUAN_MC").val();
    if (zhuan_bh != "") {
        getYunxingbh(zhuan_bh);
    } else {
        $("#YUNXING_BH").html("<option value='' >—请选择—</option>");
        $("#ZHUANGCHANG_J,#ZHUANGLEI_X").val("");
    }
}


//运行编号变动方法
function yxbhChange() {
    var yxbh = $("#YUNXING_BH").val();
    var zhanbh = $("#ZHUAN_MC").val();
    if (yxbh == "") {
        $("#ZHUANGCHANG_J,#ZHUANGLEI_X").val("");
    } else {
        getCjAndLx(yxbh,zhanbh);
    }

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