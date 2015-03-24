var zhanbh;
$(function () {

    urlinfo = window.location.href; //获取当前页面的url 
    len = urlinfo.length; //获取url的长度 
    offset = urlinfo.indexOf("?"); //设置参数字符串开始的位置 
    newsidinfo = urlinfo.substr(offset, len)//取出参数字符串 这里会获得类似“id=1”这样的字符串 
    newsids = newsidinfo.split("="); //对获得的参数字符串按照“=”进行分割 
    newsid = newsids[1]; //得到参数值 
    zhanbh = newsid;
    $("#h_zhanbh").val(zhanbh);

    $("#dgpile").datagrid({
        url: '/WebService/ChargStationService.ashx',
        queryParams: { action: 'getcp', zhanbh: zhanbh },
        onClickRow: onClickRow,
        fitColumns: true,
        rownumbers: true,
        singleSelect: true,
        width: '570px',
        height: 'auto',
        columns: [[
                    { field: 'DEV_CHARGPILE', width: 80, hidden: true, title: '充电桩编号' },
                    { field: 'BOX_ID', width: 80, title: '分支箱',
                        formatter: function (value, row) {
                            var xh1 = value.toString().substr(3, 2);
                            var xh2 = value.toString().substr(4, 1);
                            if (xh2 == 0) {
                                return '分支箱' + xh1;
                            }
                            else {
                                return '分支箱' + xh2;
                            }
                        }
                    },
                    { field: 'CHANGJIAO_BH', width: 100, align: 'center', editor: 'text', title: '桩出厂编号', required: true,
                        formatter: function (value, row) {
                            if (!value) {
                                value = "";
                            }
                            return "<input style='width:70px' onchange='bhchange()' type='text' id='i_cjbh_" + row.DEV_CHARGPILE + "' value='" + value + "'/>";
                        }
                    },
                    { field: 'YUNXING_BH', width: 100, align: 'center', editor: 'text', title: '桩运行编号', required: true,
                        formatter: function (value, row) {
                            if (!value) {
                                value = "";
                            }
                            return "<input style='width:70px' onchange='bhchange()' type='text' id='i_cjbh_" + row.DEV_CHARGPILE + "' value='" + value + "'/>";
                        }
                    },
                    { field: 'CHANGJIA', width: 110, title: '桩厂家',
                        formatter: function (value, row) {
                            var xhHtml = "";
                            $.ajax({
                                url: "/webservice/ChargPileService.ashx",
                                type: "post",
                                async: false,
                                data: { action: 'getcj1' },
                                datatype: "html",
                                success: function (html) {
                                    var val = null;
                                    eval("val=" + html);
                                    var length = val.length;
                                    xhHtml = "<select style='width:80px' id='s_cj_" + row.DEV_CHARGPILE
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
                   { field: 'ZHUANGXING_H', width: 100, title: '桩型号',
                       formatter: function (value, row) {
                           var xhHtml = "";
                           $.ajax({
                               url: "/webservice/ChargPileService.ashx",
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
                   { field: 'ZHUANGLEI_X', width: 110, align: 'left', title: '桩类型',
                       formatter: function (value, row) {
                           return "<input style='width:80px' readonly='readonly' type='text' id='i_lx_" + row.DEV_CHARGPILE + "' value='" + value + "'/>";
                       }
                   },
                   { field: 'ZHUANGTAI', width: 90, align: 'left', title: '状态',
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

});

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
            var input = $('<input type="text" class="datagrid-editable-input" onmouseover="this.focus()" onchange="updatepile()">').appendTo(container);
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
        url: "/WebService/ChargPileService.ashx",
        type: "post",
        async: false,
        data: { action: 'getxh', cj: $("#s_cj_" + pileId).val() },
        datatype: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            var length = val.rows.length;
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
    $('#dgpile').datagrid('selectRow', editIndex);
    var select = $('#dgpile').datagrid('getSelected');
    var id = select.DEV_CHARGPILE;

    var edbh = $('#dgpile').datagrid('getEditor', { index: editIndex, field: 'CHANGJIAO_BH' });
    var bh = $(edbh.target).val();

    var yxbh = $('#dgpile').datagrid('getEditor', { index: editIndex, field: 'YUNXING_BH' });
    var ybh = $(yxbh.target).val();
    var b = true;
    $.ajax({
        url: "/WebService/ChargStationService.ashx",
        type: "post",
        async: false,
        data: { action: 'checkyxbh', yxbh: ybh, id: id },
        dataType: "json",
        success: function (result) {
            if (result.success) {
                $(yxbh.target).val("");
                $.messager.alert('提示', result.msg);
                b = false;
                return ;
            }
            
        }
    });
    if (!b) {
        return;
    }

    var cj = $("#s_cj_" + select.DEV_CHARGPILE).val();
    var xh = $("#s_xh_" + select.DEV_CHARGPILE).find("option:selected").text();
    var zt = $("#s_zt_" + select.DEV_CHARGPILE).val();
    var lx = null;

    $.ajax({
        url: "/WebService/ChargPileService.ashx",
        type: "post",
        async: false,
        data: { action: 'getlx', xh: xh,cj:cj },
        dataType: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            var length = val.rows.length;
            lx = val.rows[0].ZHUANGLEI_X;
        }
    });


    $.ajax({
        url: "/WebService/ChargStationService.ashx",
        type: "post",
        async: false,
        data: { action: 'savepile', id: id, bh: bh, yxbh: ybh, cj: cj, xh: xh, zt: zt },
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

    //    var edbh = $('#dgpile').datagrid('getEditor', { index: editIndex, field: 'CHANGJIAO_BH' });
    //    if (!edbh) {
    //        $.messager.alert('提示', '请编辑桩未完成信息！');
    //        return;
    //    }
    //    var bh = $(edbh.target).val();
    //    if (bh == "") {
    //        $.messager.alert('提示', '桩出厂编号不能为空！');
    //        return;
    //    }

    //    var yxbh = $('#dgpile').datagrid('getEditor', { index: editIndex, field: 'YUNXING_BH' });
    //    if (!yxbh) {
    //        $.messager.alert('提示', '请编辑桩未完成信息！');
    //        return;
    //    }
    //    var ybh = $(yxbh.target).val();
    //    if (ybh == "") {
    //        $.messager.alert('提示', '桩运行编号不能为空！');
    //        return;
    //    }

    $.ajax({
        url: "/WebService/ChargStationService.ashx",
        type: "post",
        async: false,
        data: { action: 'savetypes', zhanbh: zhanbh },
        datatype: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            $.messager.alert('提示', '保存成功！');
            if (val.success) {
                parent.$("#contentFrame").attr("src", "/pages/ChargPileLedger/ChargStation.htm");
            }
        }
    });
}

//返回上一步
function back() {
    var zhanbh = $("#h_zhanbh").val();
    parent.$("#contentFrame").attr("src", "/pages/ChargPileLedger/AddBranch.htm?zhanbh=" + zhanbh);
}