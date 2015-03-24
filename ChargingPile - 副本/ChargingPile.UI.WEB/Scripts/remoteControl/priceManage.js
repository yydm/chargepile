var myurl;
var mydata;
var mytype = "POST";
var jsonType = "json";
var htmlType = "html";
var commonType = "application/json; charset=utf-8";
var editIndex = undefined;
var edit_before_val;
var edit_after_val;

//=============================================================================================
$(function () {
    initTable();
});
function disshowBorder() {
    $("input[name=price]").addClass("disshowBorder");
    $("input[name=price]").attr("readonly", true);
    $("input[name=price]").blur(function () {
        var txt = $(this).val();
        if (!txt) {
            $("#id_" + this.id).removeAttr("readonly");
            $(this).select();
            return false;
        }
        var v = checkMoney(txt);
        if (!v) {
            $("#id_" + this.id).removeAttr("readonly");
            $(this).select();
            return false;
        }
        return true;
    }
        );
}

function showBorder(rowid) {
    var hasattr = true;
    var hasfalse = false;
    edit_before_val = $("#id_" + rowid).val();
    $("input[name='price']").each(function (index) {
        hasattr = $("input[name=price]").eq(index).attr("readonly");
        if (!hasattr) {
            hasfalse = true;
        }
    });
    if (!hasfalse) {
        $("#id_" + rowid).removeAttr("readonly");
        $("#id_" + rowid).removeClass("disshowBorder").css("text-align", "left");
        $("#id_" + rowid).select();
    }
}

function onLoadSuccess() {
    disshowBorder();
    $($('#dg').datagrid("getPanel")).find('a.easyui-linkbutton').linkbutton();
}

function initTable() {
    $('#dg').datagrid({
        singleSelect: true,
        fit: true,
        striped: true,
        rownumbers: true,
        title: "系统配置>>价格维护",
        queryParams: { action: 'inittable' },
        url: '../../webservice/PriceService.ashx',
        //toolbar: '#tb',
        columns: [[
            { field: 'Id', hidden: true },
            { field: 'Name', title: '名称', align: 'center', width: 775 },
            { field: 'Price',
                title: '价格(单位:元)',
                align: 'center',
                editor: 'text',
                width: 150,
                formatter: function (val, src) {
                    return "<input type='text' id='id_" + src.Id + "' name='price' value='"
                        + val + "' onchange='price_onchange(\"" + src.Id + "\",\"" + src.Name + "\");' class='easyui-validatebox' required='true' validtype='integer' style='width:140px;'/>";
                }
            },
            { field: 'action', title: '操作', width: 50, align: 'center',
                formatter: function (value, row, index) {
                    return '<a href="javascript:showBorder(\'' + row.Id + '\')" class="easyui-linkbutton" plain="true" iconcls="icon-edit" title="修改"></a>';
                }
            }
        ]],
        onLoadSuccess: onLoadSuccess
    });


}

function checkMoney(str) {
    var myRegExp = /^(\d)*(\.)?(\d)*$/;
    return myRegExp.test(str);
}


function price_onchange(rowid, rowname) {
    var txt = $("#id_" + rowid).val();
    edit_after_val = txt;
    if (!txt) {
        $.messager.alert("提示", "输入数值有误，请重新输入！");
        //$.messager.show({ title: '提示', msg: '输入数值有误，请重新输入！' });
        return false;
    }
    var v = checkMoney(txt);
    if (!v) {
        $.messager.alert("提示", "输入数值有误，请重新输入！");
        //$.messager.show({ title: '提示', msg: '输入数值有误，请重新输入！' });
        return false;
    }
    $.messager.confirm('提示',
        '是否将价格改为:' + txt + '元',
         function (r) {
             if (r) {
                 myurl = "../../webservice/PriceService.ashx";
                 mydata = {
                     action: "addchargprice",
                     id: rowid,
                     before_price: edit_before_val,
                     after_price: edit_after_val,
                     rowname: rowname
                 };
                 saveData();
                 btnRefresh_click();
                 $("input[name=price]").attr("readonly", true);
                 $("#id_" + rowid).removeAttr("readonly");
                 $("#id_" + rowid).addClass("disshowBorder").css("text-align", "right");
             } else {
                 $("#id_" + rowid).val(edit_before_val);
                 $("input[name=price]").attr("readonly", true);
                 $("#id_" + rowid).removeAttr("readonly");
                 $("#id_" + rowid).addClass("disshowBorder").css("text-align", "right");
                 btnRefresh_click();
             }
         });


    return true;
}

/*
* 刷新datagrid
*/
function btnRefresh_click() {
    $('#dg').datagrid('reload');
}

function saveData() {
    var value;
    $.ajax({
        url: myurl,
        dataType: htmlType,
        type: mytype,
        async: false,
        data: mydata,
        success: function (data) {
            eval("val=" + data);
            value = val.status;
            switch (val.status) {
                case true:
                    $.messager.alert("提示", "保存成功！");
                    //$.messager.show({ title: '提示', msg: '保存成功！' });
                    //                    $("input[name=price]").attr("readonly", true);
                    //                    $("#" + warnid).removeAttr("readonly");
                    //                    $("#"+_rowid).addClass("disshowBorder").css("text-align", "right");
                    //                    warnid = "";
                    break;
                case "2":
                    setTimeout(function () { location.href = "../../Login.aspx"; }, 4000);
                    $.messager.alert("提示", value.msg + "<br />--登录过期，即将跳转到登陆页。");
                    break;
                case false:
                    $.messager.alert("提示", "保存失败！");
                    //$.messager.show({ title: '提示', msg: '保存失败！' });
                    break;
                default:
            }
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            $.messager.alert("提示", "error");
        }
    });
    return value;
}