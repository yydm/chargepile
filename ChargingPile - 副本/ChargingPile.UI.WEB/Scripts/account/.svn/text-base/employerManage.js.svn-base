var myurl;
var mydata;
var mytype = "POST";
var jsonType = "html";
var commonType = "application/json; charset=utf-8";
//var deptid = "0";
var openform;
var empid;
$(document).ready(function () {
    $('#dlg').dialog({
        title: 'My Dialog',
        width: 380,
        height: 370,
        buttons: '#btn2',
        closed: true
    });
    $.fn.zTree.init($("#treeDemo"), setting); //加载树

    var deptid;
    var zTree = $.fn.zTree.getZTreeObj("treeDemo");
    var nodes = zTree.getSelectedNodes();
    if (nodes.length <= 0)
        deptid = 0;
    else
        deptid = nodes[0].id;
    $('#dg').datagrid({
        url: '../../WebService/DepAndEmpManage.ashx',
        queryParams: { action: 'getEmp', id: deptid },
        fit: true,
        fitColumns: true,
        striped: true,
        singleSelect: true,
        toolbar: '#tb',
        columns: [[
            { field: 'Id', hidden: true },
            { field: 'DeptName', title: '部门名称', align: 'center', width: 100 },
            { field: 'WorkNum', title: '登录名', align: 'center', width: 100 },
            { field: 'Name', title: '人员名称', align: 'center', width: 50 },
            { field: 'PhoneNum', title: '手机号码', align: 'center', width: 50 },
            { field: 'Email', title: '邮件', align: 'center', width: 100 },
            { field: 'action', title: '操作', width: 40, align: 'center',
                formatter: function (value, row, index) {
                    var str = "<a href='#' onclick='btnEdit_click(" + index + ")' class='easyui-linkbutton' plain='true' title='修改' iconcls='icon-edit'></a>";
                    str += "<a href='#' onclick='btnDel_click(" + index + ")' class='easyui-linkbutton' plain='true' title='删除' iconcls='icon-cancel'></a>";
                    return str;
                }
            }
        ]],
        view: detailview,
        detailFormatter: function (index, row) {
            return "<div style='padding:2px;'><table id='ddv-" + index + "'></table><div>";
        },
        onExpandRow: function (index, row) {
            $("#ddv-" + index).datagrid({
                url: "../../WebService/UseRoleService.ashx",
                queryParams: {
                    action: "getRole",
                    id: row.Id
                },
                singleSelect: true,
                rownumbers: true,
                loadMsg: "加载中...",
                height: "auto",
                columns: [[
                   { field: 'RoleName', title: '人员角色', align: 'center', width: 100 },
                ]],
                onLoadSuccess: function () {
                    setTimeout(function () {
                        $("#dg").datagrid("fixDetailRowHeight", index);
                    });
                },
                onResize: function () {
                    $("#dg").datagrid("fixDetailRowHeight", index);
                }
            });
        },
        onClickRow: function (rowIndex, rowData) {
            empid = rowData.Id;
        },
        onLoadSuccess: onLoadSuccess
    });
    bindCombo();
    $('#cc').combo({
        required: true,
        editable: false
    });
    $('#sp').appendTo($('#cc').combo('panel'));
    $('#role input').click(function () {
        var text = "";
        var value = "";
        $("#sp input[type=checkbox]:checked").each(function () {
            text += $(this).next('span').text() + '—';
            value += $(this).val() + '—';
        });
        value = value.substring(0, value.length - 1);
        text = text.substring(0, text.length - 1);
        $('#cc').combo('setValue', value).combo('setText', text);
    });

});

function onLoadSuccess() {
    $($('#dg').datagrid("getPanel")).find('a.easyui-linkbutton').linkbutton();
}

//----------------------------------------------------------------------------------------

function bindCombo() {
    myurl = "../../WebService/DepAndEmpManage.ashx";
    mydata = { action: "getrole" };
    var str = "";
    var val = getData();
    for (var i = 0; i < val.length; i++) {
        str += "<input type=\"checkbox\" name=\"lang\" value=\"" + val[i].RoleId + "\"><span>" + val[i].RoleName + "</span><br /> </input>";
    }
    $("#role").append(str);
}

var toolbar = [{
    text: '添加',
    iconCls: 'icon-add',
    handler: function () {
        btnAdd_click();
    }
},
    {
        text: '编辑',
        iconCls: 'icon-edit',
        handler: function () {
            btnEdit_click();
        }
    }, {
        text: '删除',
        iconCls: 'icon-remove',
        handler: function () {
            btnDel_click();
        }
    }
];

var setting = {
    async: {
        enable: true,
        url: "../../WebService/ZtreeService.ashx",
        autoParam: ["id", "name=n"],
        otherParam: { "action": "dep" }
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
    //deptid = treeNode.id;
    $('#dg').datagrid('load', {
        action: 'getEmp',
        id: treeNode.id
    });
}


//对电子邮件的验证
function regmail(mail) {
    var myreg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
    if (!myreg.test(mail)) {
        return false;
    }
    return true;
}

function clearForm() {
    $("#txtdlm").val("");
    $("#txtgh").val("");
    $("#mail").val("");
    $("#name").val("");
    $("#txtsh").val("");
    $('#cc').combo('setValue', '').combo('setText', '');
}

//新增人员
function btnAdd_click() {
    $("input[name=lang]").attr("checked", false);
    var zTree = $.fn.zTree.getZTreeObj("treeDemo");
    var nodes = zTree.getSelectedNodes();
    if (nodes.length <= 0) {
        $.messager.alert("提示", "请选择部门！");
        //$.messager.show({ title: '提示', msg: '请选择部门！' });
        return false;
    }
    clearForm();
    openform = "add";
    $('#dlg').dialog('open').dialog('setTitle', '添加人员');
   
    return false;
}
//编辑人员
function btnEdit_click(rowid) {
    $("input[name=lang]").attr("checked", false);
    $('#dg').datagrid("selectRow", rowid);
    var select = $("#dg").datagrid("getSelected");
    if (!select) {
        $.messager.alert("提示", "请选择一条数据！");
        //$.messager.show({ title: '提示', msg: '请选择一条数据！' });
        return false;
    }

    openform = "edit";
    $('#dlg').dialog('open').dialog('setTitle', '编辑人员');
    clearForm();
    myurl = "../../WebService/DepAndEmpManage.ashx";
    mydata = { action: "queryEmp", empid: select.Id };
    var data = getData();
    var name = data[0].Name;
    var mail = data[0].Email;
    var worknum = data[0].WorkNum;
    var phonenum = data[0].PhoneNum;
    $("#name").val(name);
    $("#mail").val(mail);
    $("#txtdlm").val(worknum);
    $("#txtsh").val(phonenum);

    myurl = "../../WebService/DepAndEmpManage.ashx";
    mydata = { action: "getrole2", empid: select.Id };
    data = getData();
    var text = "";
    var value = "";
    for (var i = 0; i < data.length; i++) {
        $("input[name=lang][value='" + data[i].RoleId + "']").attr("checked", true);
        text += data[i].RoleName + "—";
        value += data[i].RoleId + "—";
    }
    value = value.substring(0, value.length - 1);
    text = text.substring(0, text.length - 1);

    $('#cc').combo('setValue', value).combo('setText', text);
    return false;
}
//删除人员
function btnDel_click(rowid) {
    $('#dg').datagrid("selectRow", rowid);
    var select = $("#dg").datagrid("getSelected");
    if (!select) {
        $.messager.alert("提示", "请选择一条数据！");
        //$.messager.show({ title: '提示', msg: '请选择一条数据！' });
        return false;
    }
    myurl = "../../WebService/DepAndEmpManage.ashx";
    mydata = { action: "delEmp", id: select.Id };
    deleteData();
    return false;
}

function btnSave_click() {
    var valid3 = $("#txtdlm").validatebox("isValid");
    var valid1 = $("#name").validatebox("isValid");
    var valid2 = $("#mail").validatebox("isValid");
    var valid4 = $("#txtsh").validatebox("isValid");
    //var valid3 = $("#cc").validatebox("isValid");
    var rolename = $("#cc").combo('getText');

    var deptid;
    var zTree = $.fn.zTree.getZTreeObj("treeDemo");
    var nodes = zTree.getSelectedNodes();
    if (nodes.length <= 0)
        deptid = 0;
    else
        deptid = nodes[0].id;

    if (!valid1 || !valid2 || !valid3 || !valid4)
        return false;
    if (rolename == "")
        return false;
    var gh = $("#txtdlm").val();
    var name = $("#name").val();
    var sh = $("#txtsh").val();
    var email = $("#mail").val();
    var roleid = $("#cc").combo('getValue');

    //    if (!regmail(email)) {
    //        $.messager.alert("提示", "请输入正确的邮箱地址！");
    //        //$.messager.show({ title: '提示', msg: '请输入正确的邮箱地址！' });
    //        return false;
    //    }
    myurl = "../../WebService/DepAndEmpManage.ashx";

    switch (openform) {
        case "add":
            mydata = {
                action: "addEmp",
                parid: deptid,
                worknum: gh,
                empname: name,
                phonenum: sh,
                empmail: email,
                roleid: roleid
            };
            break;
        case "edit":
            mydata = {
                action: "editEmp",
                empid: empid,
                parid: deptid,
                worknum: gh,
                empname: name,
                phonenum: sh,
                empmail: email,
                roleid: roleid
            };
            break;
        default:
    }

    var vr = saveData();
    if (vr == "true") {
        $('#dg').datagrid('reload');
        btnCancel_click();
    }
    else if (vr == "2") {
        setTimeout(function () { location.href = "../../Login.aspx"; }, 4000);
        $.messager.alert("提示", "--登录过期，即将跳转到登陆页。");
    }

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
        dataType: jsonType,
        success: function (data) {
            if (data) {
                var val = "";
                var ret = data.split("|")[0];
                eval("val=" + ret);
                var res = data.split("|")[1];
                if (ret == "0") {
                    value = "0";
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
                    $.messager.alert("提示", "该工号人员已经存在！");
                    //$.messager.show({ title: '提示', msg: '该人员已经存在！' });
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

function deleteData() {
    $.messager.confirm('提示', '确定删除人员?',
        function (r) {
            if (r) {
                $.post(myurl, mydata,
                    function (data, status) {
                        if (data == "true") {
                            $.messager.alert("提示", "删除成功！");
                            //$.messager.show({ title: '提示', msg: '删除成功！' });
                            $('#dg').datagrid('reload');
                        } else {
                            $.messager.alert("提示", data);
                            //$.messager.show({ title: '提示', msg: data });
                            $('#dg').datagrid('reload');
                        }
                    });
            }
        });
}

//返回ztree的nodes节点
function commonZtree() {
    var treeObj = $.fn.zTree.getZTreeObj("treeDemo");
    var nodes = treeObj.getSelectedNodes();
    return nodes;
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
