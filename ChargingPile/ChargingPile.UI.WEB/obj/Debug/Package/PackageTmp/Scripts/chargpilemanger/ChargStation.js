$(function () {
    $("#t_chargstation").datagrid({
        url: "../../WebService/ChargStationService.ashx",
        queryParams: { action: "getstation" },
        fit: true,
        nowrap: false,
        fitColumns: true,
        striped: true,
        border: false,
        rownumbers: true,
        singleSelect: true,
        pagination: true,
        toolbar: "#tb",
        pageList: [10, 20, 30, 50],
        pageSize: 20,
        columns: [[
                    { field: "ZhanBh", title: "充电站编号", width: 100, align: 'center', hidden: true },
                    { field: "XiangXiDz", title: "详细地址", width: 100, align: 'center', hidden: true },
                    { field: "Longtude", title: "经度坐标", width: 100, align: 'center', hidden: true },
                    { field: "Latitude", title: "纬度坐标", width: 100, align: 'center', hidden: true },
                    { field: "YeZhuDw", title: "场地业主单位", width: 100, align: 'center', hidden: true },
                    { field: "LianXiR", title: "场地业主联系人", width: 100, align: 'center', hidden: true },
                    { field: "LianXiDh", title: "场地业主联系电话", width: 100, align: 'center', hidden: true },
                    { field: "TouYun_Sj", title: "投运时间", width: 100, align: 'center', hidden: true,
                        formatter: function (value, src) {
                            if (value != null) {
                                return eval("new " + value.split('/')[1]).Format("yyyy-MM-dd");
                            }
                        }
                    },
                    { field: "CreateDT", title: "建站时间", width: 100, align: 'center', hidden: true,
                        formatter: function (value, src) {
                            if (value != null) {
                                return eval("new " + value.split('/')[1]).Format("yyyy-MM-dd");
                            }
                        }
                    },
                    { field: "Zhan_Jc", title: "充电场站名称", width: 150, align: 'center' },
                    { field: "Counts", title: "桩数量", width: 100, align: 'center' },
                    { field: "ZhuangChangJ", title: "桩厂家", width: 150, align: 'center' },
                    { field: "ZhuangXing_H", title: "桩型号", width: 200, align: 'center' },
                    { field: "ZhuangLeiX", title: "桩类型", width: 310, align: 'center' },
                    { field: 'action1', title: '操作', width: 50, align: 'center',
                        formatter: function (value, row, index) {
                            return '<a href="javascript:delfunc(' + index + ')" class="easyui-linkbutton" plain="true" title="删除" iconcls="icon-cancel"></a>';
                        }
                    }
                ]],
        onLoadSuccess: function () {
            $($('#t_chargstation').datagrid("getPanel")).find('a.easyui-linkbutton').linkbutton();
        }
    });
});
//充电站增加方法
function addfunc(id) {
    parent.$("#contentFrame").attr("src", "../../pages/ChargPileLedger/AddStation.aspx");
    return false;
    $("#dlg").dialog("open").dialog("setTitle", "充电站基本信息编辑");
    $("#ZhuanMc,#XiangXiDz,#Longtude,#Latitude,#YeZhuDw,#LianXiR,#LianXiDh,#BoxCounts,#CreateDT,#TouYun_Sj").val("");
    //清空file文本框
    if (/MSIE/.test(navigator.userAgent)) {
        $('#picfile').replaceWith($('#picfile').clone(true));
    } else {
        $('#picfile').val('');
    }
    url = "/WebService/ChargStationService.ashx?action=addstation";
}


//验证联系电话格式是否正确
function DHchange() {
    var phone = /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/;
    var mobile = /^(13|14|15|18)\d{9}$/;
    var LianXiDh = $("#LianXiDh").val();
    if (LianXiDh != "") {
        if (LianXiDh.match(phone) == null && LianXiDh.match(mobile) == null) {
            $.messager.show({ title: '提示', msg: '联系电话不正确，请输入正确的手机号码和电话号码，电话号码格式：0551-88888888' });
            return;
        }
    }
}

//保存充电站方法
var url;
function save() {
    var phone = /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/;
    var mobile = /^(13|14|15|18)\d{9}$/;
    var LianXiDh = $("#LianXiDh").val();
    if (LianXiDh != "") {
        if (LianXiDh.match(phone) == null && LianXiDh.match(mobile) == null) {
            $.messager.show({ title: '提示', msg: '联系电话不正确，请输入正确的手机号码和电话号码，电话号码格式：0551-88888888' });
            return;
        }
    }
    var jd = $("#Longtude").val();
    if (jd > 180 || jd < 0) {
        $.messager.alert('提示', '经度应处于0-180之间！');
        return;
    }
    var wd = $("#Latitude").val();
    if (wd > 90 || wd < 0) {
        $.messager.alert('提示', '纬度应处于0-90之间！');
        return;
    }

    var boxcounts = $("#BoxCounts").val();
    if (boxcounts == "") {
        $.messager.alert('提示', '请选择分支箱数量！');
        return;
    }
    var jzsj = $("#CreateDT").val();
    if (jzsj == "") {
        $.messager.alert('提示', '请选择建站时间！');
        return;
    }
    var tysj = $("#TouYun_Sj").val();
    if (tysj == "") {
        $.messager.alert('提示', '请选择投运时间！');
        return;
    }
    var file = $("#picfile").val();
    if (file == "") {
        $.messager.alert('提示', '图片不能为空，请选择.rar或.zip图片压缩文件！');
        return;
    }
    var boxcounts = $("#BoxCounts").val();
    $("#boxcounts").val(boxcounts);
    $("#fm").ajaxSubmit({
        url: url,
        dataType: "json",
        beforeSubmit: function () {
            return $("#fm").form('validate');
        },
        success: function (result) {
            if (result.success) {
                $('#dlg').dialog('close');
                AddBranch();
                $.messager.alert('提示', result.msg);
            } else {
                $.messager.alert("提示", result.msg);
            }
        }
    });


}

//充电站删除方法
function delfunc(id) {
    var selected = $('#t_chargstation').datagrid('getSelected');
    $.messager.confirm('提示', '确定删除?',
                function (r) {
                    if (r) {
                        $.ajax({
                            url: "../../webservice/ChargStationService.ashx?action=delstation",
                            type: "post",
                            data: "id=" + selected.ZhanBh,
                            datatype: "json",
                            success: function (result) {
                                var result = eval('(' + result + ')');
                                if (result.success) {
                                    $('#dlg').dialog('close');
                                    $("#t_chargstation").datagrid("reload");
                                    $.messager.alert('提示', result.msg);
                                } else {
                                    $.messager.alert("提示", result.msg);
                                }
                            }
                        });
                    }
                });
}

//新建分支箱方法
function AddBranch() {
    $("#t_box").html("");
    $("#newpile").dialog("open").dialog("setTitle", "新建充电桩");
    var boxcounts = $("#boxcounts").val();
    var html = "";
    var thtml = "<tr><th>分支箱名称</th><th>桩数量</th><th>桩厂家</th><th>桩型号</th></tr>";
    //     $("#t_box").html(thtml)
    for (var i = 0; i < boxcounts; i++) {
        html += " <tr style='height: 28px'><td style='width: 100px' align='center' class='text_b'>分支箱" + (i + 1) + ":</td>"
                + "<td align='center'><input type='text' id='ZhuangCounts_" + i + "' name='ZhuangCounts_" + i + "' style='width: 80px' /></td>"
                + "<td align='center'><select onchange='clickcj(" + i + ")' id='ZhuangChangJia_" + i + "' name='ZhuangChangJia_" + i
                + "' style='width: 100px' ><option value=''>—请选择—</option></select></td>"
                + "<td align='center'><select id='ZhuangXingH_" + i + "' name='ZhuangXingH_" + i
                + "' style='width: 100px' ><option value=''>—请选择—</option></select></td></tr> ";

        //          getCJ("ZhuangChangJia_" + i);

    }
    $("#t_box").append(thtml + html);
    for (var i = 0; i < boxcounts; i++) {
        getCJ("ZhuangChangJia_" + i);
    }
    url = "../../WebService/ChargStationService.ashx?action=addBranch&boxcounts=" + boxcounts;
}

//新建分支箱—厂家联动方法
function clickcj(id) {
    var cj = $("#ZhuangChangJia_" + id).val();
    if (cj != "") {
        getXH("ZhuangXingH_" + id, cj);
    } else {
        $("#ZhuangXingH_" + id).html("<option value='' >—请选择—</option>");
    }

}

//保存分支箱
function saveBranch() {
    getZhanID();
    var boxcounts = $("#boxcounts").val();
    for (var i = 0; i < boxcounts; i++) {
        var zcounts = $("#ZhuangCounts_" + i).val();
        var zcj = $("#ZhuangChangJia_" + i).val();
        var zxh = $("#ZhuangXingH_" + i).val();
        var count = /^[+]?[1-9]+\d*$/;
        if (zcounts == "" || zcounts == "0") {
            $.messager.alert('提示', '桩数量不能为空或0');
            return;
        }
        else {
            if (zcounts.match(count) == null) {
                $.messager.alert('提示', '桩数量应为非零整数'); ;
                return;
            }
        }
        if (zcj == "") {
            $.messager.alert('提示', '请选择桩厂家');
            return;
        }
        if (zxh == "") {
            $.messager.alert('提示', '请选择桩型号');
            return;
        }
    }
    $('#Form1').form('submit', {
        url: url,
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (result) {
            var result = eval('(' + result + ')');
            if (result.success) {
                $('#newpile').dialog('close');
                AddChargPile();
                $.messager.alert('提示', result.msg);
            } else {
                $.messager.alert("提示", result.msg);
            }
        }
    });
}

//关闭分支箱弹出框触发充电站数据更新
function onCloseNPile() {
    $("#t_chargstation").datagrid("reload");
}

//获取新建充电站编号方法
function getZhanID() {
    $.ajax({
        url: "../../WebService/ChargStationService.ashx",
        type: "post",
        async: false,
        data: "action=getzhanid",
        dataType: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            var length = val.rows.length;
            for (var i = 0; i < length; i++) {
                $("#h_zhanbh").val(val.rows[i].ZhanBh);
            }
        }
    });
}


//新建分支箱——加载厂家下拉菜单
function getCJ(id) {
    $.ajax({
        url: "../../WebService/ChargStationService.ashx",
        type: "post",
        async: false,
        data: "action=gettype",
        dataType: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            var length = val.rows.length;
            $("#" + id).html("<option value='' >—请选择—</option>");
            for (var i = 0; i < length; i++) {
                $("#" + id).append("<option value=" + val.rows[i].CHANGJIA + " >" + val.rows[i].CHANGJIA + "</option>");
            }
        }
    });
}

//新建分支箱——加载型号下拉菜单
function getXH(id, cj) {
    $.ajax({
        url: "../../WebService/ChargStationService.ashx",
        type: "post",
        async: false,
        data: "action=gettypexh&&cj=" + cj,
        dataType: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            var length = val.rows.length;
            $("#" + id).html("<option value='' >—请选择—</option>");
            for (var i = 0; i < length; i++) {
                $("#" + id).append("<option value=" + val.rows[i].ZHUANGXING_H + " >" + val.rows[i].ZHUANGXING_H + "</option>");
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

//=======================================================================================分割线===========================================================================

//充电桩基本信息——表格中编辑方法
var editIndex = undefined;
var Id = "";
function endEditing() {
    if (editIndex == undefined) { return true }
    if ($('#dgpile').datagrid('validateRow', editIndex)) {
        $('#dgpile').datagrid('endEdit', editIndex);
        editIndex = undefined;
        return true;
    } else {
        return false;
    }
}
function onClickRow(index) {
    if (editIndex != index) {
        if (endEditing()) {
            $('#dgpile').datagrid('selectRow', index).datagrid('beginEdit', index);
            editIndex = index;
        } else {
            $('#dgpile').datagrid('selectRow', editIndex);
        }
    }
}


//充电桩基本信息——datagrid的editors配置
$.extend($.fn.datagrid.defaults.editors, {
    text: {
        init: function (container, options) {
            var input = $('<input type="text" class="datagrid-editable-input" onchange="updatepile()">').appendTo(container);
            return input;
        },
        getValue: function (target) {
            return $(target).val();
        },
        setValue: function (target, value) {
            $(target).val(value);
        },
        resize: function (target, width) {
            var input = $(target);
            if ($.boxModel == true) {
                input.width(width - (input.outerWidth() - input.width()));
            } else {
                input.width(width);
            }
        }
    }
});

//充电桩基本信息——打开充电桩弹出框加载数据
function AddChargPile() {
    $("#pileinfo").dialog("open").dialog("setTitle", "充电桩基本信息");
    $("#dgpile").datagrid({
        url: '../../WebService/ChargStationService.ashx',
        queryParams: { action: 'getcp', zhanbh: $('#h_zhanbh').val() },
        onClickRow: onClickRow,
        fitColumns: true,
        rownumbers: true,
        singleSelect: true,
        width: '570px',
        height: 'auto',
        columns: [[
                    { field: 'DEV_CHARGPILE', width: 80, hidden: true, title: '充电桩编号' },
                    { field: 'BOX_ID', width: 80, title: '分支箱' },
                    { field: 'CHANGJIAO_BH', width: 80, align: 'center', editor: 'text', title: '厂家编号', required: true,
                        formatter: function (value, row) {
                            if (!value) {
                                value = "";
                            }
                            return "<input style='width:70px' onchange='bhchange()' type='text' id='i_cjbh_" + row.DEV_CHARGPILE + "' value='" + value + "'/>";
                        }
                    },
                    { field: 'CHANGJIA', width: 100, title: '厂家',
                        formatter: function (value, row) {
                            var xhHtml = "";
                            $.ajax({
                                url: "../../webservice/ChargPileService.ashx",
                                type: "post",
                                async: false,
                                data: { action: 'getcj1' },
                                datatype: "html",
                                success: function (html) {
                                    var val = null;
                                    eval("val=" + html);
                                    var length = val.length;
                                    xhHtml = "<select style='width:90px' id='s_cj_" + row.DEV_CHARGPILE
                                            + "' onchange='cjChange(\"" + row.DEV_CHARGPILE + "\")' >";
                                    for (var i = 0; i < length; i++) {
                                        if (row.CHANGJIA == val[i].CHANGJIA) {
                                            xhHtml += "<option value='" + val[i].CHANGJIA + "' selected='selected' >" + val[i].CHANGJIA + "</option>";
                                        } else {
                                            xhHtml += "<option value='" + val[i].CHANGJIA + "'>" + val[i].CHANGJIA + "</option>";
                                        }
                                    }
                                    xhHtml += "</select>";
                                }
                            });
                            return xhHtml;
                            $("#s_cj_" + row.DEV_CHARGPILE).val(row.CHANGJIA);
                        }
                    },
                   { field: 'ZHUANGXING_H', width: 80, title: '型号',
                       formatter: function (value, row) {
                           var xhHtml = "";
                           $.ajax({
                               url: "../../webservice/ChargPileService.ashx",
                               type: "post",
                               async: false,
                               data: { action: 'getxh1', cj: row.CHANGJIA },
                               datatype: "html",
                               success: function (html) {
                                   var val = null;
                                   eval("val=" + html);
                                   var length = val.length;
                                   xhHtml = "<select style='width:70px' id='s_xh_" + row.DEV_CHARGPILE
                                            + "' onchange='xhChange(\"" + row.DEV_CHARGPILE + "\")' >";
                                   for (var i = 0; i < length; i++) {
                                       if (row.ZHUANGXING_H == val[i].ZHUANGXING_H) {
                                           xhHtml += "<option value='" + val[i].ZHUANGLEI_X + "' selected='selected'>" + val[i].ZHUANGXING_H + "</option>";
                                       } else {
                                           xhHtml += "<option value='" + val[i].ZHUANGLEI_X + "'>" + val[i].ZHUANGXING_H + "</option>";
                                       }
                                   }
                                   xhHtml += "</select>";
                               }
                           });
                           return xhHtml;
                       }
                   },
                   { field: 'ZHUANGLEI_X', width: 100, align: 'center', title: '类型',
                       formatter: function (value, row) {
                           return "<input style='width:90px' readonly='readonly' type='text' id='i_lx_" + row.DEV_CHARGPILE + "' value='" + value + "'/>";
                       }
                   },
                   { field: 'ZHUANGTAI', width: 90, align: 'center', title: '状态',
                       formatter: function (value, row) {
                           var xhHtml = "";
                           xhHtml = "<select style='width:70px' id='s_zt_" + row.DEV_CHARGPILE + "' onchange='ztChange()' >";
                           if (row.ZHUANGTAI == "" || row.ZHUANGTAI == '未投运' || row.ZHUANGTAI == null) {
                               xhHtml += "<option value='未投运' selected='selected'>未投运</option>";
                               xhHtml += "<option value='已投运'>已投运</option>";
                           } else if (row.ZHUANGTAI == '已投运') {
                               xhHtml += "<option value='未投运'>未投运</option>";
                               xhHtml += "<option value='已投运' selected='selected'>已投运</option>";
                           }
                           xhHtml += "</select>";
                           return xhHtml;
                       }
                   }

                ]]
    });

}

function bhchange() {
    updatepile();
}
function ztChange() {
    updatepile();
}

function xhChange(pileId) {
    $("#i_lx_" + pileId).val($("#s_xh_" + pileId).val());
    updatepile();
}

function cjChange(pileId) {
    $('#s_xh_' + pileId).html("");
    $.ajax({
        url: "../../WebService/ChargPileService.ashx",
        type: "post",
        async: false,
        data: { action: 'getxh', cj: $("#s_cj_" + pileId).val() },
        datatype: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            var length = val.rows.length; ;
            for (var i = 0; i < length; i++) {
                $("#s_xh_" + pileId).append("<option value='" + val.rows[i].ZHUANGLEI_X + "' >" + val.rows[i].ZHUANGXING_H + "</option>");
            }
            xhChange(pileId);
        }
    });
    updatepile();
}


//充电桩基本信息——表格中实时更新充电桩信息方法
function updatepile() {

    var edbh = $('#dgpile').datagrid('getEditor', { index: editIndex, field: 'CHANGJIAO_BH' });
    var bh = $(edbh.target).val();

    $('#dgpile').datagrid('selectRow', editIndex);
    var select = $('#dgpile').datagrid('getSelected');
    var cj = $("#s_cj_" + select.DEV_CHARGPILE).val();
    var xh = $("#s_xh_" + select.DEV_CHARGPILE).find("option:selected").text();
    var zt = $("#s_zt_" + select.DEV_CHARGPILE).val();
    var lx = null;

    $.ajax({
        url: "../../WebService/ChargPileService.ashx",
        type: "post",
        async: false,
        data: { action: 'getlx', xh: xh },
        dataType: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            var length = val.rows.length;
            lx = val.rows[0].ZHUANGLEI_X;
        }
    });

    var id = select.DEV_CHARGPILE;
    $.ajax({
        url: "../../WebService/ChargStationService.ashx",
        type: "post",
        async: false,
        data: { action: 'savepile', id: id, bh: bh, cj: cj, xh: xh, zt: zt },
        datatype: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            if (val.success) {
                select.CHANGJIA = cj;
                select.ZHUANGXING_H = xh;
                select.ZHUANGLEI_X = lx;
                select.ZHUANGTAI = zt;
            } else {
                return false;
            }
        }
    });
}
//充电桩基本信息——关闭充电桩弹出框，触发保存充电桩的类型信息
function onClosePile() {
    var zhanbh = $("#h_zhanbh").val();
    $.ajax({
        url: "../../WebService/ChargStationService.ashx",
        type: "post",
        async: false,
        data: { action: 'savetypes', zhanbh: zhanbh },
        datatype: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            if (val.success) {
                $("#t_chargstation").datagrid("reload");
            }
        }
    });
}



//gis关联地图
function gisfunc() {
    var selected = $('#t_chargstation').datagrid('getSelected');
    if (selected == null) {
        alert("请选择需要访问的充电站！");
    }
    else {
        var zhanbh = selected.ZhanBh;
        location.href = "../../pages/Gis/gis.htm?ZHAN_BH=" + zhanbh + "&querytype=1";
    }
}
//gis地图标注
function gisAdd() {
    var selected = $('#t_chargstation').datagrid('getSelected');
    if (selected == null) {
        alert("请选择需要访问的充电站！");
    }
    else {
        var zhanbh = selected.ZhanBh;
        $.ajax({
            url: "/WebService/RequestHandling.ashx",
            type: "get",
            async: false,
            data: "action=gisAdd&zhanbh=" + zhanbh,
            dataType: "json",
            success: function (result) {
                var result = eval(result);
                if (result.success) {
                    $.messager.alert('提示', result.msg);
                } else {
                    $.messager.alert("提示", result.msg);
                }
            }
        });
    }
}
//gis地图标注删除
function gisDelete() {
    var selected = $('#t_chargstation').datagrid('getSelected');
    if (selected == null) {
        alert("请选择需要访问的充电站！");
    }
    else {
        var zhanbh = selected.ZhanBh;
        $.ajax({
            url: "/WebService/RequestHandling.ashx",
            type: "get",
            async: false,
            data: "action=gisDelete&zhanbh=" + zhanbh,
            dataType: "json",
            success: function (result) {
                var result = eval(result);
                if (result.success) {
                    $.messager.alert('提示', result.msg);
                } else {
                    $.messager.alert("提示", result.msg);
                }
            }
        });
    }
}


///////////===================================================================================xiugai============================================================================

//充电站编辑方法
function editStation() {
    var selected = $('#t_chargstation').datagrid('getSelected');
    if (selected == null) {
        $.messager.alert('提示', '请先点击选中一行充电站数据');
        return;
    }
    $("#d_zhanbh").val(selected.ZhanBh);

    $("#d_ZhuanMc,#d_XiangXiDz,#d_Longtude,#d_Latitude,#d_YeZhuDw,#d_LianXiR,#d_LianXiDh,#d_CreateDT,#d_TouYun_Sj,#d_pilepic").val("");
    $("#div_station").css("display", "none");
    $("#div_box").css("display", "none");
    $("#div_pile").css("display", "none");

    $("#div_zhan").dialog("open").dialog("setTitle", "充电站编辑");
    addtree(selected.ZhanBh);


}



function addtree(zhanbh) {
    var setting = {
        async: {
            enable: true,
            url: "../../WebService/StationTreeService.ashx",
            autoParam: ["id", "name=n"],
            otherParam: { "treetype": "piletree", "zhanbh": zhanbh }
        },
        callback: {
            onClick: onClick,
            onRightClick: OnRightClick
        },
        view: {
            dblClickExpand: false
        },
        data: {
            simpleData: {
                enable: true,
                idKey: "id",
                pIdKey: "pId",
                rootPId: -1
            }
        }
    };

    $.fn.zTree.init($("#treeDemo"), setting); //加载树

    zTree = $.fn.zTree.getZTreeObj("treeDemo");
    rMenu = $("#rMenu");
}


var zTree, rMenu;

//右击事件
function OnRightClick(event, treeId, treeNode) {
    if (treeNode) {
        zTree.selectNode(treeNode);
        showRMenu("node", event.clientX, event.clientY);
    }
}
function showRMenu(type, x, y) {
    $("#rMenu ul").show();
    if (type == "root") {
        $("#m_del").hide();
    } else {
        $("#m_del").show();
    }
    rMenu.css({ "top": y + "px", "left": x + "px", "visibility": "visible" });

    $("body").bind("mousedown", onBodyMouseDown);
}
function hideRMenu() {
    if (rMenu) rMenu.css({ "visibility": "hidden" });
    $("body").unbind("mousedown", onBodyMouseDown);
}
function onBodyMouseDown(event) {
    if (!(event.target.id == "rMenu" || $(event.target).parents("#rMenu").length > 0)) {
        rMenu.css({ "visibility": "hidden" });
    }
}
var addCount = 1;
function addTreeNode() {
    hideRMenu();
    var newNode = { name: "增加" + (addCount++) };
    if (zTree.getSelectedNodes()[0]) {
        newNode.checked = zTree.getSelectedNodes()[0].checked;
        zTree.addNodes(zTree.getSelectedNodes()[0], newNode);
    } else {
        zTree.addNodes(null, newNode);
    }
}
function removeTreeNode() {
    hideRMenu();
    var nodes = zTree.getSelectedNodes();
    if (nodes && nodes.length > 0) {
        if (nodes[0].children && nodes[0].children.length > 0) {
            var msg = "要删除的节点是父节点，如果删除将连同子节点一起删掉。\n\n请确认！";
            if (confirm(msg) == true) {
                zTree.removeNode(nodes[0]);
            }
        } else {
            zTree.removeNode(nodes[0]);
        }
    }
}





//ztree过滤器
function filter(treeId, parentNode, childNodes) {
    if (!childNodes) return null;
    for (var i = 0, l = childNodes.length; i < l; i++) {
        childNodes[i].name = childNodes[i].name.replace(/\.n/g, '.');
    }
    return childNodes;
}
//异步调用前事件
function beforeAsync(treeId, treeNode) {
    return treeNode ? treeNode.level < 5 : true;
};

//节点点击方法
function onClick(event, treeId, treeNode, clickFlag) {
    id = treeNode.id;
    name = treeNode.name;

}

//树节点刷新方法	
function refresh(type, silent, nodeid) {
    var zTree = $.fn.zTree.getZTreeObj("tree");
    var node = null;
    if (nodeid != "") {
        node = zTree.getNodeByParam("id", nodeid); //根据节点id值获取节点对象
        if (!node.isParent) {
            node.isParent = true;
        }
    }
    if (node != null) {
        zTree.reAsyncChildNodes(node, type, silent);
        if (!silent) zTree.selectNode(node);
    }

}

//获取选中节点的对象
function getSelectNode() {
    var selectnode = null;
    var zTree = $.fn.zTree.getZTreeObj("treeDemo");
    var nodes = zTree.getSelectedNodes();
    var length = nodes.length;
    if (length == 1) {
        selectnode = nodes[0];
    }
    return selectnode;
}

//编辑充电站——添加分支箱，充电桩的方法
function edit_addfunc() {
    var selectNode = getSelectNode();
    if (selectNode == null) {
        $.messager.alert('提示', '请先点击树上的充电站或分支箱节点！');
        return;
    }

    var type = selectNode.id.split('_')[1];
    if (type == "z") {
        $("#div_pile").css("display", "none");
        $("#div_station").css("display", "none");
        $("#d_zcounts").val("");
        $("#d_changjia").html("<option value='' >—请选择—</option>");
        $("#d_xinghao").html("<option value='' >—请选择—</option>");
        var zhanbh = selectNode.id.split('_')[0];
        getCJ("d_changjia");
        $("#div_box").css("display", "block");

        url = "/WebService/ChargStationService.ashx?action=d_addbranch&zhanbh=" + zhanbh;
    } else if (type == "f") {
        $("#div_box").css("display", "none");
        $("#div_station").css("display", "none");
        $("#d_xh").html("<option value='' >—请选择—</option>");
        getpileCJ();
        $("#d_cjbh,#d_yxbh,#d_lx,#d_zt,#d_tysj").val("");
        ztchange();
        var branchno = selectNode.id.split('_')[0];
        $("#div_pile").css("display", "block");

        url = "/WebService/ChargStationService.ashx?action=d_addpile&branchno=" + branchno;
    } else if (type == "zu") {
        $.messager.alert('提示', '充电桩不能增加下级节点，请点击树上的充电站或分支箱节点！');
        return;
    }

}

//编辑充电站——关闭充电站编辑框方法
function onClosediv_zhan() {
    $("#t_chargstation").datagrid("reload");
}

//编辑分支箱—厂家联动方法
function d_cjclick() {
    var cj = $("#d_changjia").val();
    if (cj != "") {
        getXH("d_xinghao", cj);
    } else {
        $("#d_xinghao").html("<option value='' >—请选择—</option>");
    }

}
//编辑分支箱——保存方法
function d_box_save() {
    var zcounts = $("#d_zcounts").val();
    var zcj = $("#d_changjia").val();
    var zxh = $("#d_xinghao").val();
    var count = /^[+]?[1-9]+\d*$/;
    if (zcounts == "" || zcounts == "0") {
        $.messager.alert('提示', '桩数量不能为空或0');
        return;
    }
    else {
        if (zcounts.match(count) == null) {
            $.messager.alert('提示', '桩数量应为非零整数'); ;
            return;
        }
    }
    if (zcj == "") {
        $.messager.alert('提示', '请选择桩厂家');
        return;
    }
    if (zxh == "") {
        $.messager.alert('提示', '请选择桩型号');
        return;
    }

    $('#Form3').form('submit', {
        url: url,
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (result) {
            var result = eval('(' + result + ')');
            if (result.success) {
                $("#div_box").css("display", "none");
                var d_zhanbh = $("#d_zhanbh").val();
                addtree(d_zhanbh);
                $.messager.alert('提示', result.msg);
            } else {
                $.messager.alert("提示", result.msg);
            }
        }
    });
}

//编辑充电桩——加载厂家数据
function getpileCJ() {
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
            $("#d_cj").html("<option value='' >—请选择—</option>");
            for (var i = 0; i < length; i++) {
                $("#d_cj").append("<option value=" + val.rows[i].CHANGJIA + " >" + val.rows[i].CHANGJIA + "</option>");
            }
        }
    });
}

//编辑充电桩——加载型号数据
function getpileXH(cj) {
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
            $("#d_xh").html("<option value='' >—请选择—</option>");
            for (var i = 0; i < length; i++) {
                $("#d_xh").append("<option value=" + val.rows[i].ZHUANGXING_H + " >" + val.rows[i].ZHUANGXING_H + "</option>");
            }
        }
    });

}

//编辑充电桩——加载类型数据
function getpileLX(xh) {
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
                $("#d_lx").val(val.rows[i].ZHUANGLEI_X);
            }
        }
    });

}

//编辑充电桩——厂家变动方法
function pileCJchange() {
    var cj = $("#d_cj").val();
    if (cj != "") {
        getpileXH(cj);
    } else {
        $("#d_xh").html("<option value='' >—请选择—</option>");
        $("#d_lx").val("");
    }
}

//编辑充电桩——型号变动方法
function pileXHchange() {
    var xh = $("#d_xh").val();
    if (xh != "") {
        getpileLX(xh);
    } else {
        $("#d_lx").val("");
    }
}
//编辑充电桩——保存方法
function d_pile_save() {
    var cj = $("#d_cj").val();
    if (cj == "") {
        $.messager.alert('提示', '请选择厂家');
        return;
    }
    var xh = $("#d_xh").val();
    if (xh == "") {
        $.messager.alert('提示', '请选择型号');
        return;

    }
    var zhuangtai = $("#d_zt").val();
    if (zhuangtai == "") {
        $.messager.alert('提示', '请选择充电桩状态');
        return;
    }
    var tysj = $("#d_tysj").val();
    if (zhuangtai == "已投运") {
        if (tysj == "") {
            $.messager.alert('提示', '投运时间不能为空');
            return;
        }
    }
    $('#Form4').form('submit', {
        url: url,
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (result) {
            var result = eval('(' + result + ')');
            if (result.success) {
                $("#div_pile").css("display", "none");
                var d_zhanbh = $("#d_zhanbh").val();
                addtree(d_zhanbh);
                $.messager.alert('提示', result.msg);
            } else {
                $.messager.alert("提示", result.msg);
            }
        }
    });
}

//编辑充电站——删除方法
function edit_delfunc() {
    var selectNode = getSelectNode();
    if (selectNode == null) {
        $.messager.alert('提示', '请先点击树上的充电桩或分支箱节点！');
        return;
    }
    var type = selectNode.id.split('_')[1];
    if (type == "z") {
        $.messager.alert('提示', '充电站不能删除，请点击树上的充电桩或分支箱节点！');
        return;
    } else if (type == "f") {
        var branchno = selectNode.id.split('_')[0];
        var res = confirm("确认删除？");
        if (!res) {
            return;
        }
        $.ajax({
            url: "/webservice/ChargStationService.ashx?action=delbranch",
            type: "post",
            data: "id=" + branchno,
            datatype: "json",
            success: function (result) {
                var result = eval('(' + result + ')');
                if (result.success) {
                    var d_zhanbh = $("#d_zhanbh").val();
                    addtree(d_zhanbh);
                    $.messager.alert('提示', result.msg);
                } else {
                    $.messager.alert("提示", result.msg);
                }
            }
        });
    } else if (type == "zu") {
        var zhuangbh = selectNode.id.split('_')[0];
        var res = confirm("确认删除？");
        if (!res) {
            return;
        }
        $.ajax({
            url: "/webservice/ChargStationService.ashx?action=delpile",
            type: "post",
            data: "pileid=" + zhuangbh,
            datatype: "json",
            success: function (result) {
                var result = eval('(' + result + ')');
                if (result.success) {
                    var d_zhanbh = $("#d_zhanbh").val();
                    addtree(d_zhanbh);
                    $.messager.alert('提示', result.msg);
                } else {
                    $.messager.alert("提示", result.msg);
                }
            }
        });
    }
}
//编辑充电站——编辑方法
function edit_editfunc() {
    var selectNode = getSelectNode();
    if (selectNode == null) {
        $.messager.alert('提示', '请先点击树上的充电站或充电桩节点！');
        return;
    }
    var type = selectNode.id.split('_')[1];
    if (type == "z") {
        $("#div_box").css("display", "none");
        $("#div_pile").css("display", "none");
        var zhanmc = "";
        var xxdz = "";
        var jd = "";
        var wd = "";
        var yzdw = "";
        var yzlxr = "";
        var yzlxdh = "";
        var jzsj = "";
        var tysj = "";
        var zhanbh = selectNode.id.split('_')[0];
        $.ajax({
            url: "/WebService/ChargStationService.ashx",
            type: "post",
            async: false,
            data: { action: 'getstationbyid', zhanbh: zhanbh },
            dataType: "html",
            success: function (html) {
                var val = null;
                eval("val=" + html);
                zhanmc = val.rows[0].ZhuanMc;
                xxdz = val.rows[0].XiangXiDz;
                jd = val.rows[0].Longtude;
                wd = val.rows[0].Latitude;
                yzdw = val.rows[0].YeZhuDw;
                yzlxr = val.rows[0].LianXiR;
                yzlxdh = val.rows[0].LianXiDh;
                jzsj = val.rows[0].CreateDT;
                tysj = val.rows[0].TouYun_Sj;
            }
        });
        $("#d_ZhuanMc").val(zhanmc);
        $("#d_XiangXiDz").val(xxdz);
        $("#d_Longtude").val(jd);
        $("#d_Latitude").val(wd);
        $("#d_YeZhuDw").val(yzdw);
        $("#d_LianXiR").val(yzlxr);
        $("#d_LianXiDh").val(yzlxdh);
        if (jzsj != null) {
            var CreateDT = eval("new " + (jzsj).split('/')[1]).Format("yyyy-MM-dd");
            $("#d_CreateDT").val(CreateDT);
        } else {
            $("#d_CreateDT").val("");
        }
        if (tysj != null) {
            var TouYun_Sj = eval("new " + (tysj).split('/')[1]).Format("yyyy-MM-dd");
            $("#d_TouYun_Sj").val(TouYun_Sj);
        } else {
            $("#d_TouYun_Sj").val("");
        }
        $("#div_station").css("display", "block");
        url = "/webservice/ChargStationService.ashx?action=editstation&zhanbh=" + zhanbh;



    } else if (type == "f") {
        $.messager.alert('提示', '分支箱不能编辑，请先点击树上的充电站或充电桩节点！');
        return;
    } else if (type == "zu") {
        $("#div_box").css("display", "none");
        $("#div_station").css("display", "none");
        var pilebh = "";
        var cjbh = "";
        var yxbh = "";
        var cj = "";
        var xh = "";
        var lx = "";
        var zt = "";
        var tysj = "";
        var zhuangbh = selectNode.id.split('_')[0];
        $.ajax({
            url: "/WebService/ChargStationService.ashx",
            type: "post",
            async: false,
            data: { action: 'getpile', zhuangbh: zhuangbh },
            dataType: "html",
            success: function (html) {
                var val = null;
                eval("val=" + html);
                pilebh = val.rows[0].DEV_CHARGPILE;
                cjbh = val.rows[0].CHANGJIAO_BH;
                yxbh = val.rows[0].YUNXING_BH;
                cj = val.rows[0].CHANGJIA;
                xh = val.rows[0].ZHUANGXING_H;
                lx = val.rows[0].ZHUANGLEI_X;
                zt = val.rows[0].ZHUANGTAI;
                tysj = val.rows[0].TOUYOU_SJ;
            }
        });
        $("#d_cjbh").val(cjbh);
        $("#d_yxbh").val(yxbh);
        $("#d_zt").val(zt);
        ztchange();
        getpileCJ();
        $("#d_cj").val(cj);
        pileCJchange();
        $("#d_xh").val(xh);
        $("#d_lx").val(lx);
        if (tysj != null) {
            var TOUYOU_SJ = eval("new " + tysj.split('/')[1]).Format("yyyy-MM-dd");
            if (TOUYOU_SJ == "1-01-01") {
                $("#d_tysj").val("");
            }
            else {
                $("#d_tysj").val(TOUYOU_SJ);
            }
        } else {
            $("#d_tysj").val("");
        }

        $("#div_pile").css("display", "block");
        url = "/webservice/ChargStationService.ashx?action=editbranch&zhuangbh=" + zhuangbh;
    }
}


//编辑充电站——保存充电站方法
function d_station_save() {
    var phone = /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/;
    var mobile = /^(13|14|15|18)\d{9}$/;
    var LianXiDh = $("#d_LianXiDh").val();
    if (LianXiDh != "") {
        if (LianXiDh.match(phone) == null && LianXiDh.match(mobile) == null) {
            $.messager.show({ title: '提示', msg: '联系电话不正确，请输入正确的手机号码和电话号码，电话号码格式：0551-88888888' });
            return;
        }
    }
    var jd = $("#d_Longtude").val();
    if (jd > 180 || jd < 0) {
        $.messager.alert('提示', '经度应处于0-180之间');
        return;
    }
    var wd = $("#d_Latitude").val();
    if (wd > 90 || wd < 0) {
        $.messager.alert('提示', '纬度应处于0-90之间');
        return;
    }
    var jzsj = $("#d_CreateDT").val();
    if (jzsj == "") {
        $.messager.alert('提示', '请选择建站时间');
        return;
    }
    var tysj = $("#d_TouYun_Sj").val();
    if (tysj == "") {
        $.messager.alert('提示', '请选择投运时间');
        return;
    }
    $("#Form5").ajaxSubmit({
        url: url,
        dataType: "json",
        beforeSubmit: function () {
            return $("#Form5").form('validate');
        },
        success: function (result) {
            if (result.success) {
                $("#div_station").css("display", "none");
                var d_zhanbh = $("#d_zhanbh").val();
                addtree(d_zhanbh);
                $.messager.alert('提示', result.msg);
            } else {
                $.messager.alert("提示", result.msg);
            }
        }
    });
}

//充电桩状态改变联动方法
function ztchange() {
    var zt = $("#d_zt").val();
    if (zt == "" || zt == "未投运") {
        $("#d_tysj").val("");
        $("#d_tr_tysj").hide();
    } else if (zt == "已投运") {
        $("#d_tr_tysj").show();
    }
}