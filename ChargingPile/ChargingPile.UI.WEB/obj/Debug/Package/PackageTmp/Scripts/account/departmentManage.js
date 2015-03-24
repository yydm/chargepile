var myurl;
var mydata;
var mytype = "POST";
var jsonType = "json";
var htmlType = "html";
var commonType = "application/json; charset=utf-8";
var deptid;
var rowid;
var openform;


$(document).ready(function () {
    $('#dlg').dialog({
        title: 'My Dialog',
        width: 380,
        height: 155,
        buttons: '#btn2',
        closed: true
    });
    $.fn.zTree.init($("#treeDemo"), setting); //加载树
    initTable();
});

var setting = {
    async: {
        enable: true,
        url: "../../WebService/ZtreeService.ashx",
        autoParam: ["id", "name=n"],
        otherParam: { "action": "dep" },
        dataFilter: filter
    },
    callback: {
        beforeAsync: beforeAsync,
        onClick: onClick
    },
    data: {
        simpleData: {
            enable: true,
            idKey: "id",
            pIdKey: "pId",
            rootPId: 0
        }
    }
};

//var toolbar = [{
//    text: '添加',
//    iconCls: 'icon-add',
//    handler: function () {
//        btnAdd_click();
//    }
//},
//    {
//        text: '编辑',
//        iconCls: 'icon-edit',
//        handler: function () {
//            btnEdit_click();
//        }
//    }, {
//        text: '删除',
//        iconCls: 'icon-remove',
//        handler: function () {
//            btnDel_click();
//        }
//    }
//];

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
}

//点击树事件
function onClick(event, treeId, treeNode, clickFlag) {
    deptid = treeNode.id;
    $('#dg').datagrid('load', {
        action: 'getDept',
        id: deptid
    });
}

function onLoadSuccess() {
    $($('#dg').datagrid("getPanel")).find('a.easyui-linkbutton').linkbutton();
}

function clearForm() {
    $("#name").val("");
    rowid = "";
}

function initTable() {
    $('#dg').datagrid({
        url: '../../WebService/DepAndEmpManage.ashx',
        queryParams: { action: 'getDept', id: 0 },
        fit: true,
        fitColumns: true,
        singleSelect: true,
        striped: true,
        toolbar: '#tb',
        columns: [[
            { field: 'Id', hidden: true },
            { field: 'Name', title: '名称', align: 'center', width: 100 },
            { field: 'action', title: '操作',width: 10,  align: 'center',
                formatter: function (value, row, index) {
                    var str = "<a href='#' onclick='btnEdit_click(" + index + ")' class='easyui-linkbutton' plain='true' title='修改' iconcls='icon-edit'></a>";
                    str += "<a href='#' onclick='btnDel_click(" + index + ")' class='easyui-linkbutton' plain='true' title='删除' iconcls='icon-cancel'></a>";
                    return str;
                }
            }
        ]],
        onClickRow: function (rowIndex, rowData) {
            rowid = rowData.Id;
        },
        onLoadSuccess: onLoadSuccess
    });
}

//新增部门
function btnAdd_click() {
    if (!deptid) {
        $.messager.alert("提示", "请选择部门！");
        //$.messager.show({ title: '提示', msg: '请选择部门！' });
        return false;
    }
    openform = "add";
    $('#dlg').dialog('open').dialog('setTitle', '添加部门');
    clearForm();
    return true;
}
//编辑部门
function btnEdit_click(rowid) {
    $('#dg').datagrid("selectRow", rowid);
    var select = $("#dg").datagrid("getSelected");
    if (!select) {
        $.messager.alert("提示", "请选择一条数据！");
        //$.messager.show({ title: '提示', msg: '请选择一条数据！' });
        return false;
    }
    openform = "edit";
    $('#dlg').dialog('open').dialog('setTitle', '编辑部门');

    myurl = "../../WebService/DepAndEmpManage.ashx";
    mydata = { action: "queryDep", deptid: select.Id };
    var data = getData();
    var name = data[0].Name;
    $("#name").val(name);
    return false;
}
//删除部门
function btnDel_click(rowid) {
    $('#dg').datagrid("selectRow", rowid);
    var select = $("#dg").datagrid("getSelected");
    if (!select) {
        $.messager.alert("提示", "请选择一条数据！");
        //$.messager.show({ title: '提示', msg: '请选择一条数据！' });
        return false;
    }
    myurl = "../../WebService/DepAndEmpManage.ashx";
    mydata = { action: "delDep", id: select.Id, name: select.Name };
    deleteData(deptid);
    return false;
}

function btnSave_click() {
    var valid1 = $("#name").validatebox("isValid");
    if (!valid1)
        return false;
    var name = $("#name").val();

    myurl = "../../WebService/DepAndEmpManage.ashx";
    switch (openform) {
        case "add":
            mydata = { action: "addDep2", parid: deptid, name: name };
            break;
        case "edit":
            mydata = { action: "editDep", depid: rowid, depname: name, pId: deptid };
            break;
        default:
            break;
    }

    var reval = saveData();
    if (reval == "exist") {
        return false;
    }
    refresh("refresh", false, deptid);
    $('#dg').datagrid('reload');
    btnCancel_click();
    return true;
}

function btnCancel_click() {
    $('#dlg').dialog('close');
    openform = "";
}

// 获取数据

function getData() {
    var value;
    $.ajax({
        url: myurl,
        type: mytype,
        async: false,
        data: mydata,
        dataType: htmlType,
        success: function (data) {
            if (data) {
                var val = "";
                var ret = data.split("|")[0];
                eval("val=" + ret);
                var res = data.split("|")[1];
                if (ret == "0") {
                    value = "0";
                } if (ret == "2") {
                    setTimeout(function () { location.href = "../../Login.aspx"; }, 4000);
                    $.messager.alert("提示", "--登录过期，即将跳转到登陆页。");
                } else {
                    value = val;
                }
            }
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            //$.messager.show({ title: '提示', msg: 'error！' });
        }
    });
    return value;
}


//保存数据

function saveData() {
    var value;
    $.ajax({
        url: myurl,
        type: mytype,
        async: false,
        data: mydata,
        dataType: htmlType,
        success: function (data) {
            value = data;
            switch (value) {
                case "true":
                    $.messager.alert("提示", "保存成功！");
                    //$.messager.show({ title: '提示', msg: '保存成功！' });
                    break;
                case "false":
                    $.messager.alert("提示", "保存失败！");
                    //$.messager.show({ title: '提示', msg: '保存失败！' });
                    break;
                case "exist":
                    $.messager.alert("提示", "该部门已经存在！");
                    //$.messager.show({ title: '提示', msg: '该部门已经存在！' });
                    break;
                case "2":
                    setTimeout(function () { location.href = "../../Login.aspx"; }, 4000);
                    $.messager.alert("提示", "--登录过期，即将跳转到登陆页。");
                    break;
                default:
            }
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {

            //$.messager.show({ title: '提示', msg: 'error！' });
        }
    });
    return value;
}


//删除数据

function deleteData(id) {
    $.messager.confirm('提示', '确定删除部门?',
        function (r) {
            if (r) {
                $.post(myurl, mydata,
                    function (data, status) {
                        if (data == "true") {
                            $.messager.alert("提示", "删除成功！");
                            //$.messager.show({ title: '提示', msg: '删除成功！' });
                            $('#dg').datagrid('reload');
                            refresh("refresh", false, id);
                        } else if (data == "exist") {
                            $.messager.alert("提示", "该部门底下有人员，不能删除！");
                            //$.messager.show({ title: '提示', msg: '该部门底下有人员，不能删除！' });
                            //$('#dg').datagrid('reload');
                            //refresh("refresh", false, id);
                        } else if (data == "exist2") {
                            $.messager.alert("提示", "该部门底下有部门，不能删除！");
                            //$.messager.show({ title: '提示', msg: '该部门底下有人员，不能删除！' });
                            //$('#dg').datagrid('reload');
                            //refresh("refresh", false, id);
                        } else if (data == "2") {
                            setTimeout(function () { location.href = "../../Login.aspx"; }, 4000);
                            $.messager.alert("提示", value.msg + "--登录过期，即将跳转到登陆页。");
                        }
                        else {
                            $.messager.alert("提示", data);
                            //$.messager.show({ title: '提示', msg: data });
                            $('#dg').datagrid('reload');
                        }
                    });
            }
        });
}


//刷新树节点

function refresh(type, silent, nodeid) { //树节点刷新
    var zTree = $.fn.zTree.getZTreeObj("treeDemo");
    var node = null;
    if (nodeid != "") {
        node = zTree.getNodeByParam("id", nodeid); //根据节点id值获取节点对象
    }
    if (!node.isParent) {
        node.isParent = true;
    }
    if (node != null) {
        zTree.reAsyncChildNodes(node, type, silent);
        if (!silent) zTree.selectNode(node);
    }
}
