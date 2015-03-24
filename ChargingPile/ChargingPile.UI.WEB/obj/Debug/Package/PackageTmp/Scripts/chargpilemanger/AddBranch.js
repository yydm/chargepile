var boxcounts;
var zhanbh;
var id;
var gid;
$(function () {
    urlinfo = window.location.href; //获取当前页面的url 
    len = urlinfo.length; //获取url的长度 
    offset1 = urlinfo.indexOf("?"); //设置参数字符串开始的位置 
    newsidinfo = urlinfo.substr(offset1, len)//取出参数字符串 这里会获得类似“id=1”这样的字符串 
    offset2 = newsidinfo.indexOf("&");
    if (offset2 < 0) {
        newsids = newsidinfo.split("="); //对获得的参数字符串按照“=”进行分割 
        newsid = newsids[1]; //得到参数值 
        zhanbh = newsid;
        $.ajax({
            url: "/WebService/ChargStationService.ashx",
            type: "post",
            async: false,
            data: "action=getboxsl&zhanbh=" + zhanbh,
            dataType: "html",
            success: function (html) {
                var val = null;
                eval("val=" + html);
                var length = val.rows.length;
                for (var i = 0; i < length; i++) {
                    boxcounts = val.rows[i].BoxCounts
                }
            }
        });
    } else {
        newsids = newsidinfo.split("&"); //对获得的参数字符串按照“&”进行分割 
        newsid0 = newsids[0]; //得到参数值 
        newsid1 = newsids[1];
        newsid2 = newsids[2];
        newsid3 = newsids[3]
        boxcounts = newsid0.split('=')[1];
        id = newsid1.split('=')[1];
        gid = newsid2.split('=')[1];
        zhanbh = newsid3.split('=')[1];
        $.getJSON("../../WebService/PasswordService.ashx", { "action": "login1", "id": id }, function (data) { });

    }

    $("#h_boxcounts").val(boxcounts);
    $("#t_box").html("");
    var html = "";
    var thtml = "<tr><th>分支箱名称</th><th>桩数量</th><th>桩厂家</th><th>桩型号</th></tr>";
    for (var i = 0; i < boxcounts; i++) {
        html += " <tr style='height: 28px'><td style='width: 100px' align='center' class='text_b'>分支箱" + (i + 1) + ":</td>"
                + "<td align='center'><input type='text' id='ZhuangCounts_" + i + "' name='ZhuangCounts_" + i + "' style='width: 80px' /> <span style='color:Red;'>*</span></td>"
                + "<td align='center'><select onchange='clickcj(" + i + ")' id='ZhuangChangJia_" + i + "' name='ZhuangChangJia_" + i
                + "' style='width: 100px' ><option value=''>—请选择—</option></select> <span style='color:Red;'>*</span></td>"
                + "<td align='center'><select id='ZhuangXingH_" + i + "' name='ZhuangXingH_" + i
                + "' style='width: 100px' ><option value=''>—请选择—</option></select> <span style='color:Red;'>*</span></td></tr> ";
    }
    $("#t_box").append(thtml + html);
    for (var i = 0; i < boxcounts; i++) {
        getCJ("ZhuangChangJia_" + i);
    }
    url = "/WebService/ChargStationService.ashx?action=addBranch&boxcounts=" + boxcounts+"&zhanbh="+zhanbh;

});


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
    for (var i = 0; i < boxcounts; i++) {
        var zcounts = $("#ZhuangCounts_" + i).val();
        var zcj = $("#ZhuangChangJia_" + i).val();
        var zxh = $("#ZhuangXingH_" + i).val();
        var count = /^[+]?[1-9]+\d*$/;
        if (zcounts == "" || zcounts == "0") {
            $.messager.alert('提示', '桩数量不能为空或零！');
            return;
        }
        else {
            if (zcounts.match(count) == null) {
                $.messager.alert('提示', '桩数量应为非零整数！'); ;
                return;
            }
        }
        if (zcj == "") {
            $.messager.alert('提示', '请选择桩厂家！');
            return;
        }
        if (zxh == "") {
            $.messager.alert('提示', '请选择桩型号！');
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
                parent.$("#contentFrame").attr("src", "/pages/ChargPileLedger/AddPile.htm?zhanbh=" + zhanbh);
                // $.messager.alert('提示', result.msg);
            } else {
                // $.messager.alert("提示", result.msg);
            }
        }
    });
}

function back() {
//    getZhanID();
    var fzxsl = $("#h_boxcounts").val();
    parent.$("#contentFrame").attr("src", "/pages/ChargPileLedger/AddStation.aspx?zhanbh=" + zhanbh+"&fzxsl="+fzxsl+"&gid="+gid);

}


//关闭分支箱弹出框触发充电站数据更新
function onCloseNPile() {
    $("#t_chargstation").datagrid("reload");
}

//获取新建充电站编号方法
//function getZhanID() {
//    $.ajax({
//        url: "/WebService/ChargStationService.ashx",
//        type: "post",
//        async: false,
//        data: "action=getzhanid",
//        dataType: "html",
//        success: function (html) {
//            var val = null;
//            eval("val=" + html);
//            var length = val.rows.length;
//            for (var i = 0; i < length; i++) {
//                zhanbh = val.rows[i].ZhanBh
//            }
//        }
//    });
//}


//新建分支箱——加载厂家下拉菜单
function getCJ(id) {
    $.ajax({
        url: "/WebService/ChargStationService.ashx",
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
        url: "/WebService/ChargStationService.ashx",
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




