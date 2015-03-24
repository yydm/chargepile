$(function() {

    addtree();
    getUnit();

});


function addtree() {
    var setting = {
        async: {
            enable: true,
            url: "/WebService/StationTreeService.ashx",
            autoParam: ["id", "name=n"],
            otherParam: { "treetype": "dtutree" }
        },
        callback: {
            onClick: onClick,
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

    
}

function expandAllChild(event, treeId, treeNode) {
    var treeObj = $.fn.zTree.getZTreeObj(treeId);
    treeObj.expandNode(treeNode, true, true, true);
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
    var dj = id.split(':')[1];
    if(dj=="d")
    {
        parentNode = treeNode.getParentNode();
        pid = parentNode.id;
//      getUnit(id.split(':')[0], pid.split(':')[0]);
        $("#pile_dtu").datagrid("load", { action: "getunit", dtuid: id.split(':')[0], zhanid: pid.split(':')[0] });
        $("#h_dtuid").val(id.split(':')[0]);
    }
    
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
//获取关联显示
function getUnit() {
    $("#pile_dtu").datagrid({
        url: "/WebService/DTUService.ashx",
        queryParams: { action: "getunit", dtuid: "", zhanid: 0 },
        fit: true,
        nowrap: false,
        fitColumns: true,
        rownumbers: true,
        toolbar: "#tb",
        columns: [[
                    { field: 'ck', checkbox: true, width: 50 },
                    { field: "DEV_CHARGPILE", title: "充电桩id", width: 100, align: 'center',hidden:true},
                    { field: "YUNXING_BH", title: "充电桩", width: 100, align: 'center',
                        formatter: function (value, src) {
                            if (value != null) {
                                return "充电桩—" + value;
                            } else {
                                return "充电桩";
                            }

                        }
                    }
                ]],
        onLoadSuccess: function (data) {
            for (var i = 0; i < data.rows.length; i++) {
                if (data.rows[i].NOTE == "1") {
                    $('#pile_dtu').datagrid('selectRow', i);
                }
            }
        }
    });

}


//保存关联关系
function save() {
    var dtuid = $("#h_dtuid").val();
    var rows = $("#pile_dtu").datagrid("getSelections");
    var pzxs = "";
    for (var i = 0; i < rows.length; i++) {
        var row = rows[i];
        var pzx = row.DEV_CHARGPILE;
        pzxs += pzx + ":";
    }
    pzxs = pzxs.substr(0, pzxs.length - 1);
    $.ajax({
        url: "/WebService/DTUService.ashx",
        type: "post",
        async: false,
        data: "action=save&&dtuid=" + dtuid + "&&pileid=" + pzxs,
        dataType: "json",
        success: function (result) {
            if (result.success) {
                $.messager.alert('提示', result.msg);
            } else {
                $.messager.alert("提示", result.msg);
            }
        }
    });

}