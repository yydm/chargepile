$(function () {
    $("#t_chargpile").datagrid({
        url: "/WebService/ChargPileCollectionManage.ashx",
        queryParams: { action: "getcpc" },
        fit: true,
        nowrap: false,
        fitColumns: true,
        rownumbers: true,
        striped: true,
        border: false,
        //pagination: true,
        columns: [[
                    { field: "PARSERKEY", title: "充电桩类型Id", width: 30, align: 'center', hidden: true },
                    { field: "CHANGJIA", title: "桩厂家", width: 150, align: 'center' },
                    { field: "ZHUANGXING_H", title: "桩型号", width: 150, align: 'center' },
                    { field: "ZHUANGLEI_X", title: "桩类型", width: 150, align: 'center' },
                    { field: "COUNTS", title: "数据项数量", width: 150, align: 'center' },
                    { field: 'action', title: '操作', width: 80, align: 'center',
                        formatter: function (value, row, index) {
                            return '<a href="javascript:editfunc(' + index + ')" class="easyui-linkbutton" plain="true" iconcls="icon-edit">配置</a>';
                        }
                    }
                ]],
        onLoadSuccess: function () {
            $($('#t_chargpile').datagrid("getPanel")).find('a.easyui-linkbutton').linkbutton();
        }
    });
});
//打开配置项
function editfunc(id) {
    $('#t_chargpile').datagrid("unselectAll");
    $('#t_chargpile').datagrid("selectRow", id);
    var selected = $('#t_chargpile').datagrid('getSelected');
    $("#dlg").dialog("open").dialog("setTitle", "采集项列表");
    $("#h_typeid").val(selected.PARSERKEY);
    getCollection(selected.PARSERKEY);

}
//查看配置项
function getCollection(typeid) {
    $("#t_collection").datagrid({
        url: "/WebService/ChargPileCollectionManage.ashx",
        queryParams: { action: "getcollect", id: typeid },
        fit: true,
        nowrap: false,
        fitColumns: true,
        border: true,
        //rownumbers: true,
        //pagination: true,
        columns: [[
                    { field: 'ck', checkbox: true, width: 50 },
                    { field: "ITEMNO", title: "采集项标识", width: 30, align: 'center', hidden: true },
                    { field: "ITEMNAME", title: "采集项名称", width: 80, align: 'center' }
                ]],
        onLoadSuccess: function (data) {
            for (var i = 0; i < data.rows.length; i++) {
                if (data.rows[i].NOTE == "1") {
                    $('#t_collection').datagrid('selectRow', i);
                }
            }
          //  $("input[type='checkbox']").attr("disabled", "disabled");
        }
    });
}

//保存配置项
function savepzx() {
    var typeid = $("#h_typeid").val();
    var rows = $("#t_collection").datagrid("getSelections");
    var pzxs = "";
    for (var i = 0; i < rows.length; i++) {
        var row = rows[i];
        var pzx = row.ITEMNO;
        pzxs += pzx + ":";
    }
    pzxs = pzxs.substr(0, pzxs.length - 1);
    $.ajax({
        url: "/WebService/ChargPileCollectionManage.ashx",
        type: "post",
        async: false,
        data: "action=savepzx&&typeid=" + typeid + "&&pzxs=" + pzxs,
        dataType: "json",
        success: function (result) {
            if (result.success) {
                $('#dlg').dialog('close');
                $("#t_chargpile").datagrid("reload");
                $.messager.alert('提示', result.msg);
               // parent.$("#contentFrame").attr("src", "/pages/scada/ycxpz.htm");
            } else {
                $.messager.alert("提示", result.msg);
            }
        }
    });
    
}