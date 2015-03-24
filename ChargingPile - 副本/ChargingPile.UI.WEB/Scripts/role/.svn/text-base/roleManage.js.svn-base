var myurl;
var mydata;
var mytype = "POST";
var jsonType = "json";
var htmlType = "html";
var commonType = "application/json; charset=utf-8";

$(function () {
    $("#d_tb").fadeIn(1000);
    $.fn.zTree.init($("#treeRole"), settingRole); //加载菜单树
    $.fn.zTree.init($("#treeMenu"), settingMenu); //加载菜单树
});

//获取菜单树
var settingMenu = {
    async: {
        enable: true,
        url: "../../WebService/ZtreeRoleService.ashx",
        autoParam: ["id", "name=n"],
        otherParam: { "action": "menu", "roleid": "" }
    },
    check: {
        enable: true
    },
    data: {
        simpleData: {
            enable: true
        }
    }
};

//获取角色树
var settingRole = {
    async: {
        enable: true,
        url: "../../WebService/ZtreeRoleService.ashx",
        autoParam: ["id", "name=n"],
        otherParam: { "action": "role" }
    },
    callback: {
        onClick: onClick
    },
    data: {
        simpleData: {
            enable: true
        }
    }
};

//节点点击方法
function onClick(event, treeId, treeNode, clickFlag) {
    settingMenu.async.otherParam.roleid = treeNode.id;
    $.fn.zTree.init($("#treeMenu"), settingMenu); //加载树
}

function getAllNodes() {
    var treeObj = $.fn.zTree.getZTreeObj("treeRole");
    var nodes = treeObj.getNodes();
    return nodes;
}


//获取选中节点的对象
function getSelectNode() {
    var selectnode = null;
    var zTree = $.fn.zTree.getZTreeObj("treeRole");
    var nodes = zTree.getSelectedNodes();
    var length = nodes.length;
    if (length == 1) {
        selectnode = nodes[0];
    }
    return selectnode;
}

//获取选中节点的对象
function getCheckNode() {
    var zTree = $.fn.zTree.getZTreeObj("treeMenu");
    var nodes = zTree.getCheckedNodes(true);
    return nodes;
}

function clearForm() {
    $("form").clearForm();
}

//----------------------------------- CLick 事件 -----------------------------------------------
function addRole_click() {
    clearForm();
    $("#dlg").children().children().css("display", "block");
    $("#dlg").dialog("open").dialog("setTitle", "角色编辑");

}

function save_click() {
    var selectedNode = getSelectNode();
    if (!selectedNode) {
        $.messager.alert("提示", "请先点击选择角色！");
        return false;
    }

    var checkedNode = getCheckNode();
    if (checkedNode.length <= 0) {
        $.messager.alert("提示", "请给角色分配权限！");
        return false;
    }

    var menuid = "";

    for (var i = 0; i < checkedNode.length; i++) {
        if (!checkedNode[i].isParent) {
            menuid += checkedNode[i].id + ",";
        }
    }
    menuid = menuid.substring(0, menuid.length - 1);
    myurl = "../../WebService/RoleService.ashx";
    mydata = { action: 'SaveMenuRole', roleid: selectedNode.id, menuid: menuid };
    save();
    return true;
}

function delRole_click() {
    myurl = "../../WebService/RoleService.ashx";
    var selectNode = getSelectNode();
    if (selectNode == null) {
        $.messager.alert("提示", "请点击角色列表中的角色！");
        return;
    }
    var nodeId = selectNode.id; //选中节点的类型\
    mydata = { action: 'DelRole', nodeid: nodeId };
    delrole();
}


function roleForm_Save_click() {
    var nodes = getAllNodes();
    var name = $("#jsmc").val();
    for (var i = 0; i < nodes.length; i++) {
        if (nodes[i].name == name) {
            $.messager.alert("提示", "已存在该角色！");
            return false;
        }
    }
    myurl = "../../WebService/RoleService.ashx";
    mydata = { action: 'SaveRole' };
    saverole();
}

//----------------------------------------------------------------------------------

function save() {
    $.ajax({
        url: myurl, // ajax 调用后台方法
        type: mytype,
        data: mydata, // 参数
        dataType: htmlType,
        success: function (responseText, statusText) {
            if (statusText == "success") {
                if (responseText == "2") {
                    setTimeout(function () { location.href = "../../Login.aspx"; }, 4000);
                    $.messager.alert("提示", "--登录过期，即将跳转到登陆页。");
                    return true;
                }
                $.messager.alert("提示", responseText);
            }
            else {
                $.messager.alert("提示", responseText);
            }
        }
    });
}

//保存角色信息
function saverole() {
    $("form").ajaxSubmit({
        url: myurl,
        data: mydata,
        complete: function () {
        },
        beforeSubmit: function () {
            return $("form").form('validate');
        },
        success: function (responseText, statusText) {
            if (statusText == "success") {
                if (responseText == "2") {
                    setTimeout(function () { location.href = "../../Login.aspx"; }, 4000);
                    $.messager.alert("提示", "--登录过期，即将跳转到登陆页。");
                    return true;
                }
                $('#dlg').dialog('close');
                $.messager.alert("提示", responseText);
                $.fn.zTree.init($("#treeRole"), settingRole); //加载树
                settingMenu.async.otherParam.roleid = "";
                $.fn.zTree.init($("#treeMenu"), settingMenu); //加载树
            }
            else {
                $.messager.alert("提示", responseText);
            }
        }
    });

}


//删除角色信息

function delrole() {
    $.messager.confirm('提示', '确定删除选中的数据?<br />如果删除，将会删除该角色与人员的对应关系！',
        function(r) {
            if (r) {
                $.ajax({
                    url: myurl,
                    type: mytype,
                    data: mydata,
                    dataType: htmlType,
                    success: function(data, status) {
                        if (status == "success") {
                            if (data == "2") {
                                setTimeout(function() { location.href = "../../Login.aspx"; }, 4000);
                                $.messager.alert("提示", "--登录过期，即将跳转到登陆页。");
                                return true;
                            }
                            else if (data == "3") {
                                $.messager.alert("提示", "该角色不能删除。");
                                return true;
                            }
                            $.messager.alert("提示", data);
                            $.fn.zTree.init($("#treeRole"), settingRole); //加载树
                            settingMenu.async.otherParam.roleid = "";
                            $.fn.zTree.init($("#treeMenu"), settingMenu); //加载树
                            //getPersonJs();//获取角色列表
                        } else {
                            $.messager.alert("提示", status);
                        }
                    }
                });

            }
        });
}
