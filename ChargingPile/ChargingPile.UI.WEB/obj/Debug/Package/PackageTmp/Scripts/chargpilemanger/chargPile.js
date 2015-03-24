$(function () {
    $("#dlg").parent().bgiframe(); 
    getStation();
    $("#t_chargpile").datagrid({
        url: "/WebService/ChargPileService.ashx",
        queryParams: { action: "getcp", zhanbh: $("#ZHUAN_MC").val() },
        fit: true,
        pagination: true,
        nowrap: false,
        fitColumns: true,
        rownumbers: true,
        singleSelect: true,
        toolbar: "#d_tb",   
        columns: [[
                    { field: "DEV_CHARGPILE", title: "充电桩编号", width: 10, align: 'center', hidden: true },
                    { field: "YUNXING_BH", title: "运行编号", width: 10, align: 'center', hidden: true },
                    { field: "TOUYOU_SJ", title: "投运时间", width: 10, align: 'center', hidden: true,
                        formatter: function (value, src) {
                            if (value != null) {
                                return eval("new " + value.split('/')[1]).Format("yyyy-MM-dd");
                            }

                        }
                    },
                    { field: "BOX_ID", title: "分支箱", width: 100, align: 'left' },
                    { field: "CHANGJIAO_BH", title: "厂家编号", width: 100, align: 'left' },
                    { field: "CHANGJIA", title: "厂家", width: 100, align: 'left' },
                    { field: "ZHUANGXING_H", title: "型号", width: 100 },
                    { field: "ZHUANGLEI_X", title: "类型", width: 100 },
                    { field: "ZHUANGTAI", title: "状态", width: 50 },
                    { field: 'action', title: '修改', width: 100, align: 'center',
                        formatter: function (value, row, index) {
                            return '<a href="javascript:editfunc(' + index + ')" class="easyui-linkbutton" plain="true" iconcls="icon-edit">修改</a>';
                        }
                    },
                    { field: 'action1', title: '删除', width: 100, align: 'center',
                        formatter: function (value, row, index) {
                            return '<a href="javascript:delfunc(' + index + ')" class="easyui-linkbutton" plain="true" iconcls="icon-remove">删除</a>';
                        }
                    }
                ]],
        onLoadSuccess: function () {
            $($('#t_chargpile').datagrid("getPanel")).find('a.easyui-linkbutton').linkbutton();
        }
    });
});
//充电站改变联动数据
function zhanChange() {
    var zhanbh = $("#ZHUAN_MC").val();
    $("#t_chargpile").datagrid("load", { action: "getcp", zhanbh: zhanbh });
}

//添加方法
function addfunc(id) {
    $("#ZHUANGXING_H").html("<option value='' >—请选择—</option>");
    $("#dlg").dialog("open").dialog("setTitle", "充电桩基本信息编辑");
    getBox();
    getCJ();
    $("#CHANGJIAO_BH,#YUNXING_BH,#ZHUANGLEI_X,#ZHUANGTAI,#TOUYOU_SJ").val("");
    ztchange();
    url = "/WebService/ChargPileService.ashx?action=addpile";
}
//修改方法
function editfunc(id) {
    var selected = $('#t_chargpile').datagrid('getSelected');
    $("#dlg").dialog("open").dialog("setTitle", "充电桩基本信息编辑");
    getBox();
    getCJ();
    $("#BOX_ID").val(selected.BOX_ID);
    $("#CHANGJIAO_BH").val(selected.CHANGJIAO_BH);
    $("#YUNXING_BH").val(selected.YUNXING_BH);
    $("#CHANGJIA").val(selected.CHANGJIA);
    CJchange();
    $("#ZHUANGXING_H").val(selected.ZHUANGXING_H);
    XHchange();
    $("#ZHUANGTAI").val(selected.ZHUANGTAI);
    ztchange();
    if (selected.TOUYOU_SJ != null || selected.TOUYOU_SJ != "") {
        var TOUYOU_SJ = eval("new " + (selected.TOUYOU_SJ).split('/')[1]).Format("yyyy-MM-dd");
        if (TOUYOU_SJ == "1-01-01") {
            $("#TOUYOU_SJ").val("");
        }
        else {
            $("#TOUYOU_SJ").val(TOUYOU_SJ);
        }
    } else {
        $("#TOUYOU_SJ").val("");
    }
    url = "/WebService/ChargPileService.ashx?action=editpile&pileID=" + selected.DEV_CHARGPILE;


}
//保存方法
var url;
function save() {
    var box = $("#BOX_ID").val();
    if (box == "") {
        $.messager.alert('提示', '请选择分支箱');
        return;
    }
    var cj = $("#CHANGJIA").val();
    if (cj == "") {
        $.messager.alert('提示', '请选择厂家');
        return;
    }
    var xh = $("#ZHUANGXING_H").val();
    if (xh == "") {
        $.messager.alert('提示', '请选择型号');
        return;
    }
    var zhuangtai = $("#ZHUANGTAI").val();
    if (zhuangtai == "") {
        $.messager.alert('提示', '请选择充电桩状态');
        return;
    }
    var tysj = $("#TOUYOU_SJ").val();
    if (zhuangtai == "已投运") {
        if (tysj == "") {
            $.messager.alert('提示', '投运时间不能为空');
            return;
        }
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
                $("#t_chargpile").datagrid("reload");
                $.messager.alert('提示', result.msg);
            } else {
                $.messager.alert("提示", result.msg);
            }
        }
    });


}
//删除方法
function delfunc(id) {
    var selected = $('#t_chargpile').datagrid('getSelected');
    $.messager.confirm('提示', '确定删除?',
                function (r) {
                    if (r) {
                        $.ajax({
                            url: "/webservice/chargpileservice.ashx?action=delpile",
                            type: "post",
                            data: "pileid=" + selected.DEV_CHARGPILE,
                            datatype: "json",
                            success: function (result) {
                                var result = eval('(' + result + ')');
                                if (result.success) {
                                    $('#dlg').dialog('close');
                                    $("#t_chargpile").datagrid("reload");
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
            $("#ZHUAN_MC").html("<option value='0' >—请选择—</option>");
            for (var i = 0; i < length; i++) {
                $("#ZHUAN_MC").append("<option value=" + val.rows[i].ZhanBh + " >" + val.rows[i].ZhuanMc + "</option>");
            }
        }
    });
}

//加载分支箱下拉菜单
function getBox() {
    var zhanbh = $("#ZHUAN_MC").val();
    $.ajax({
        url: "/WebService/ChargPileService.ashx",
        type: "post",
        async: false,
        data: { action: "getbox", zhanbh: zhanbh },
        dataType: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            var length = val.rows.length;
            $("#BOX_ID").html("<option value='' >—请选择—</option>");
            for (var i = 0; i < length; i++) {
                $("#BOX_ID").append("<option value=" + val.rows[i].BranchNo + " >" + val.rows[i].BranchNo + "</option>");
            }
        }
    });
}


//加载厂家数据
function getCJ() {
    $.ajax({
        url: "/WebService/ChargPileService.ashx",
        type: "post",
        async: false,
        data: "action=getcj",
        dataType: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            var length = val.rows.length;
            $("#CHANGJIA").html("<option value='' >—请选择—</option>");
            for (var i = 0; i < length; i++) {
                $("#CHANGJIA").append("<option value=" + val.rows[i].CHANGJIA + " >" + val.rows[i].CHANGJIA + "</option>");
            }
        }
    });
}

//加载型号数据
function getXH(cj) {
    $.ajax({
        url: "/WebService/ChargPileService.ashx",
        type: "post",
        async: false,
        data: "action=getxh&&cj=" + cj,
        dataType: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            var length = val.rows.length;
            $("#ZHUANGXING_H").html("<option value='' >—请选择—</option>");
            for (var i = 0; i < length; i++) {
                $("#ZHUANGXING_H").append("<option value=" + val.rows[i].ZHUANGXING_H + " >" + val.rows[i].ZHUANGXING_H + "</option>");
            }
        }
    });

}

//加载类型数据
function getLX(xh) {
    $.ajax({
        url: "/WebService/ChargPileService.ashx",
        type: "post",
        async: false,
        data: "action=getlx&&xh=" + xh,
        dataType: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            var length = val.rows.length;
            for (var i = 0; i < length; i++) {
                $("#ZHUANGLEI_X").val(val.rows[i].ZHUANGLEI_X);
            }
        }
    });

}

//厂家变动方法
function CJchange() {
    var cj = $("#CHANGJIA").val();
    if (cj != "") {
        getXH(cj);
    } else {
        $("#ZHUANGXING_H").html("<option value='' >—请选择—</option>");
        $("#ZHUANGLEI_X").val("");
    }
}

//型号变动方法
function XHchange() {
    var xh = $("#ZHUANGXING_H").val();
    if (xh != "") {
        getLX(xh);
    } else {
        $("#ZHUANGLEI_X").val("");
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

//充电桩状态改变联动方法
function ztchange() {
    var zt = $("#ZHUANGTAI").val();
    if (zt == "" || zt == "未投运") {
        $("#TOUYOU_SJ").val("");
        $("#tr_tysj").hide();
    } else if (zt == "已投运") {
        $("#tr_tysj").show();
    }
}