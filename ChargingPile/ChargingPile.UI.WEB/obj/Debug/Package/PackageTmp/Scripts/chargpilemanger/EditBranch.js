
var zhanbh;
$(function () {
    getCJ();

    urlinfo = window.location.href; //获取当前页面的url 
    len = urlinfo.length; //获取url的长度 
    offset1 = urlinfo.indexOf("?"); //设置参数字符串开始的位置 
    newsidinfo = urlinfo.substr(offset1, len)//取出参数字符串 这里会获得类似“id=1”这样的字符串 
    newsids = newsidinfo.split("="); //对获得的参数字符串按照“=”进行分割 
    newsid = newsids[1]; //得到参数值 
    zhanbh = newsid;


});


function getCJ() {
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
            $("#d_changjia").html("<option value='' >—请选择—</option>");
            for (var i = 0; i < length; i++) {
                $("#d_changjia").append("<option value=" + val.rows[i].CHANGJIA + " >" + val.rows[i].CHANGJIA + "</option>");
            }
        }
    });
}


function d_cjclick() {
    var cj = $("#d_changjia").val();
    if (cj != "") {
        getXH(cj);
    } else {
        $("#d_xinghao").html("<option value='' >—请选择—</option>");
    }

}

function getXH(cj) {
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
            $("#d_xinghao").html("<option value='' >—请选择—</option>");
            for (var i = 0; i < length; i++) {
                $("#d_xinghao").append("<option value=" + val.rows[i].ZHUANGXING_H + " >" + val.rows[i].ZHUANGXING_H + "</option>");
            }
        }
    });
}

function save() {
    url = "/WebService/ChargStationService.ashx?action=d_addbranch&zhanbh=" + zhanbh;
    var zcounts = $("#d_zcounts").val();
    var zcj = $("#d_changjia").val();
    var zxh = $("#d_xinghao").val();
    var count = /^[+]?[1-9]+\d*$/;
    if (zcounts == "" || zcounts == "0") {
        parent.$.messager.alert('提示', '桩数量不能为空或零！');
        return false;
    }
    else {
        if (zcounts.match(count) == null) {
            parent.$.messager.alert('提示', '桩数量应为非零整数！'); ;
            return false;
        }
    }
    if (zcj == "") {
        parent.$.messager.alert('提示', '请选择桩厂家！');
        return false;
    }
    if (zxh == "") {
        parent.$.messager.alert('提示', '请选择桩型号！');
        return false;
    }
    $("#Form3").ajaxSubmit({
        url: url,
        dataType: "json",
        beforeSubmit: function () {
            return $("#Form3").form('validate');
        },
        success: function (result) {
            if (result.success) {
                parent.updateTreeNode();
                parent.$.messager.alert('提示', result.msg);
            } else {
                parent.$.messager.alert("提示", result.msg);
            }
        }
    });


}