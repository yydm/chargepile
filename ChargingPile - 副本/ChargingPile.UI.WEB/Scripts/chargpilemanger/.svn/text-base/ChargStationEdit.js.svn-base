$(function () {

    urlinfo = window.location.href; //获取当前页面的url 
    len = urlinfo.length; //获取url的长度 
    offset = urlinfo.indexOf("?"); //设置参数字符串开始的位置 
    if (offset < 0) {
        $("#div_station").css("display", "none");
        $("#div_box").css("display", "none");
        $("#div_pile").css("display", "none");
        addtree();

    } else {
        newsidinfo = urlinfo.substr(offset, len)//取出参数字符串 这里会获得类似“id=1”这样的字符串 
        newsids = newsidinfo.split("="); //对获得的参数字符串按照“=”进行分割 
        id = newsids[1]
        alert(id);
        $.getJSON("../../WebService/PasswordService.ashx", { "action": "login1", "id": id }, function (data) { });

    }

})


function addtree() {
    var setting = {
        async: {
            enable: true,
            url: "/WebService/StationTreeService.ashx",
            autoParam: ["id", "name=n"],
            otherParam: { "treetype": "piletree" }
        },
        callback: {
            onClick: onClick,
            onRightClick: OnRightClick,
            onExpand: expandAllChild
        },
        view: {
            dblClickExpand: false
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

    $.fn.zTree.init($("#treeDemo"), setting); //加载树

    zTree = $.fn.zTree.getZTreeObj("treeDemo");
    rMenu = $("#rMenu");
}


var zTree, rMenu;
var rightSelectNode = null;
var parentNode = null;
var leftSelectNode = null;

function expandAllChild(event, treeId, treeNode) {
    var treeObj = $.fn.zTree.getZTreeObj(treeId);
    treeObj.expandNode(treeNode, true, true, true);
}


function showRMenu(type, x, y) {
    $("#rMenu ul").show();
    if (type == "station") {
        $("#m_addbox").show();
        $("#m_editstation").show();
        $("#m_addpile").hide();
        $("#m_editpile").hide();
        $("#m_delbox").hide();
        $("#m_delpile").hide();
    } else if (type == "pile") {
        $("#m_delbox").hide();
        $("#m_addpile").hide();
        $("#m_editstation").hide();
        $("#m_addbox").hide();
        $("#m_editpile").show();
        $("#m_delpile").show();
    } else {
        $("#m_addpile").show();
        $("#m_delbox").show();
        $("#m_addbox").hide();
        $("#m_editstation").hide();
        $("#m_editpile").hide();
        $("#m_delpile").hide();
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
function m_addbox() {
    hideRMenu();
    $("#h_leftORright").val("right");
    edit_addfunc();
}
function m_addpile() {
    hideRMenu();
    $("#h_leftORright").val("right");
    edit_addfunc();
}
function m_delbox() {
    hideRMenu();
    $("#h_leftORright").val("right");
    edit_delfunc();
}
function m_delpile() {
    hideRMenu();
    $("#h_leftORright").val("right");
    edit_delfunc();
}
function m_editstation() {
    hideRMenu();
    $("#h_leftORright").val("right");
    edit_editfunc();
}
function m_editpile() {
    hideRMenu();
    $("#h_leftORright").val("right");
    edit_editfunc();
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

//节点右击事件
function OnRightClick(event, treeId, treeNode) {
    if (treeNode) {
        var arrId = (treeNode.id).split('_');
        if (arrId[1] == "z") {
            zTree.cancelSelectedNode();
            showRMenu("station", event.clientX, event.clientY);
        }
        else if (arrId[1] == "f") {
            zTree.cancelSelectedNode();
            showRMenu("box", event.clientX, event.clientY);
        }
        else if (arrId[1] == "zu") {
            zTree.selectNode(treeNode);
            showRMenu("pile", event.clientX, event.clientY);
        }
        rightSelectNode = treeNode;
        $("#h_NodeID").val(treeNode.id);

    }
}

//节点点击方法
function onClick(event, treeId, treeNode, clickFlag) {
    id = treeNode.id;
    name = treeNode.name;
    var type = id.split('_')[1];
    if (type != "f") {
        $("#h_NodeID").val(id);
        leftSelectNode = treeNode;
        $("#h_leftORright").val("left");
        edit_editfunc();
    } else {
        $("#editFrame").attr("src", "");
    }

}

//新增刷新树节点
function updateTreeNode() {
    var treeObj = $.fn.zTree.getZTreeObj("treeDemo");
    treeObj.reAsyncChildNodes(rightSelectNode, "refresh", false);
    setTimeout(function(){ 
        treeObj.expandNode(rightSelectNode, true, true, true);
    }, 1000);
}

//删除编辑桩时刷新树节点
function delrefresh() {
    var treeObj = $.fn.zTree.getZTreeObj("treeDemo");
    var leftORright = $("#h_leftORright").val();
    if (leftORright == "left") {
        parentNode = leftSelectNode.getParentNode();
    } else if (leftORright == "right") {
        parentNode = rightSelectNode.getParentNode();
    }
    treeObj.reAsyncChildNodes(parentNode, "refresh", true);
    setTimeout(function () {
        treeObj.expandNode(parentNode, true, true, true);
    }, 1000);
}

//编辑站时刷新树节点
function StationRefresh(name) {
    var CurrentNode = null;
    var treeObj = $.fn.zTree.getZTreeObj("treeDemo");
    var leftORright = $("#h_leftORright").val();
    if (leftORright == "left") {
        CurrentNode = leftSelectNode;
    } else if (leftORright == "right") {
        CurrentNode = rightSelectNode;
    }
    CurrentNode.name = name;
    treeObj.updateNode(CurrentNode);
    //treeObj.reAsyncChildNodes(parentNode, "refresh", true);
//    setTimeout(function () {
//        treeObj.expandNode(parentNode, true, true, true);
//    }, 100);
    $.messager.alert('提示', '保存成功！');
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
    var selectNode = $("#h_NodeID").val();
    var type = selectNode.split('_')[1];
    if (type == "z") {
        var zhanbh = selectNode.split('_')[0];
        $("#editFrame").attr("src", "/pages/ChargPileLedger/EditBranch.htm?zhanbh=" + zhanbh);

    } else if (type == "f") {
        var branchno = selectNode.split('_')[0];
        $("#editFrame").attr("src", "/pages/ChargPileLedger/EditPile.htm?branchno=" + branchno);
    } else if (type == "zu") {
        $.messager.alert('提示', '充电桩不能增加下级节点，请点击树上的充电站或分支箱节点！');
        return;
    }

}

//编辑充电站——关闭充电站编辑框方法
function onClosediv_zhan() {
    $("#t_chargstation").datagrid("reload");
}

//编辑充电站——删除方法
function edit_delfunc() {
    $("#editFrame").attr("src", "");
    var selectNode = $("#h_NodeID").val();
    var type = selectNode.split('_')[1];
    if (type == "z") {
        $.messager.alert('提示', '充电站不能删除，请点击树上的充电桩或分支箱节点！');
        return;
    } else if (type == "f") {
        var branchno = selectNode.split('_')[0];
        $.messager.confirm('提示', '确定删除?',
                function (r) {
                    if (r) {
                        $.ajax({
                            url: "/webservice/ChargStationService.ashx?action=delbranch",
                            type: "post",
                            data: "id=" + branchno,
                            datatype: "json",
                            success: function (result) {
                                var result = eval('(' + result + ')');
                                if (result.success) {
                                    delrefresh();
                                    $.messager.alert('提示', result.msg);
                                } else {
                                    $.messager.alert("提示", result.msg);
                                }
                            }
                        });
                    }
                });
    } else if (type == "zu") {
        var zhuangbh = selectNode.split('_')[0];
        $.messager.confirm('提示', '确定删除?',
                function (r) {
                    if (r) {
                        $.ajax({
                            url: "/webservice/ChargStationService.ashx?action=delpile",
                            type: "post",
                            data: "pileid=" + zhuangbh,
                            datatype: "json",
                            success: function (result) {
                                var result = eval('(' + result + ')');
                                if (result.success) {
                                    delrefresh();
                                    $.messager.alert('提示', result.msg);
                                } else {
                                    $.messager.alert("提示", result.msg);
                                }
                            }
                        });
                    }
                });

    }
}

//编辑充电站——编辑方法
function edit_editfunc() {
    var selectNode = $("#h_NodeID").val();
    var type = selectNode.split('_')[1];
    if (type == "z") {
        var zhanbh = selectNode.split('_')[0];
        $("#editFrame").attr("src", "/pages/ChargPileLedger/EditStation.aspx?zhanbh=" + zhanbh);
    } else if (type == "zu") {
        var zhuangbh = selectNode.split('_')[0];
        $("#editFrame").attr("src", "/pages/ChargPileLedger/EditPile.htm?pileid=" + zhuangbh);
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