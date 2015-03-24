var url;
var branchno;
var pileid;
$(function () {
    //$("#dlg").parent().bgiframe();
    getpileCJ();
    ztchange();

    urlinfo = window.location.href; //获取当前页面的url 
    len = urlinfo.length; //获取url的长度 
    offset1 = urlinfo.indexOf("?"); //设置参数字符串开始的位置 
    newsidinfo = urlinfo.substr(offset1, len)//取出参数字符串 这里会获得类似“id=1”这样的字符串 
    newsids = newsidinfo.split("="); //对获得的参数字符串按照“=”进行分割 
    newsid = newsids[1]; //得到参数值 
    if (newsid.length > 5) {
        pileid = newsid;
        if (pileid != 0) {
            var pilebh = "";
            var zmc = "";
            var zxdz = "";
            var cjbh = "";
            var yxbh = "";
            var cj = "";
            var xh = "";
            var lx = "";
            var zt = "";
            var tysj = "";
            var bz = "";
            $.ajax({
                url: "/WebService/ChargStationService.ashx",
                type: "post",
                async: true,
                data: { action: 'getpile', zhuangbh: pileid },
                dataType: "html",
                success: function (html) {
                    var val = null;
                    eval("val=" + html);
                    pilebh = val.rows[0].DEV_CHARGPILE;
                    zxdz = val.rows[0].ZONGXIAN_DZ;
                    cjbh = val.rows[0].CHANGJIAO_BH;
                    yxbh = val.rows[0].YUNXING_BH;
                    cj = val.rows[0].CHANGJIA;
                    xh = val.rows[0].ZHUANGXING_H;
                    lx = val.rows[0].ZHUANGLEI_X;
                    zt = val.rows[0].ZHUANGTAI;
                    tysj = val.rows[0].TOUYOU_SJ;
                    bz = val.rows[0].REMARK;
                    $("#d_cjbh").val(cjbh);
                    $("#d_zxdz").val(zxdz);
                    $("#d_yxbh").val(yxbh);
                    $("#d_cj").val(cj);
                    pileCJchange();

                    setTimeout(function () {
                        $("#d_xh").val(xh);
                    }, 0.5);

                    $("#d_lx").val(lx);
                    $("#d_zt").val(zt);
                    ztchange();

                    if (tysj != null) {
                        var TOUYOU_SJ = eval("new " + tysj.split('/')[1]).Format("yyyy-MM-dd");
                        if (TOUYOU_SJ == "1-01-01") {
                            $("#d_tysj").val("");
                        }
                        else {
                            $("#d_tysj").val(TOUYOU_SJ);
                        }
                    } else {
                        $("#d_tysj").val("");
                    }

                    $("#d_bz").val(bz);
                }
            });
        }
        url = "/WebService/ChargStationService.ashx?action=editbranch&zhuangbh=" + pileid;
    } else {
        branchno = newsid;
        url = "/WebService/ChargStationService.ashx?action=d_addpile&branchno=" + branchno;
    }

});


//编辑充电桩——加载厂家数据
function getpileCJ() {
    $.ajax({
        url: "/WebService/ChargPileService.ashx",
        type: "post",
        async: false,
        data: "action=getcj",
        dataType: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            var length = val.rows.length;
            $("#d_cj").html("<option value='' >—请选择—</option>");
            for (var i = 0; i < length; i++) {
                $("#d_cj").append("<option value=" + val.rows[i].CHANGJIA + " >" + val.rows[i].CHANGJIA + "</option>");
            }
        }
    });
}

//编辑充电桩——加载型号数据
function getpileXH(cj) {
    $.ajax({
        url: "/WebService/ChargPileService.ashx",
        type: "post",
        async: false,
        data: "action=getxh&&cj=" + cj,
        dataType: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            var length = val.rows.length;
            $("#d_xh").html("<option value='' >—请选择—</option>");
            for (var i = 0; i < length; i++) {
                $("#d_xh").append("<option value=" + val.rows[i].ZHUANGXING_H + " >" + val.rows[i].ZHUANGXING_H + "</option>");
            }
        }
    });

}

//编辑充电桩——加载类型数据
function getpileLX(xh,cj) {
    $.ajax({
        url: "/WebService/ChargPileService.ashx",
        type: "post",
        async: false,
        data: "action=getlx&&cj=" + cj + "&&xh=" + xh,
        dataType: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            var length = val.rows.length;
            for (var i = 0; i < length; i++) {
                $("#d_lx").val(val.rows[i].ZHUANGLEI_X);
            }
        }
    });

}

//编辑充电桩——厂家变动方法
function pileCJchange() {
    var cj = $("#d_cj").val();
    if (cj != "") {
        getpileXH(cj);
    } else {
        $("#d_xh").html("<option value='' >—请选择—</option>");
        $("#d_lx").val("");
    }
}

//编辑充电桩——型号变动方法
function pileXHchange() {
    var xh = $("#d_xh").val();
    var cj = $("#d_cj").val();
    if (xh != "") {
        getpileLX(xh, cj);
    } else {
        $("#d_lx").val("");
    }
}
//编辑充电桩——保存方法
function save() {
    var zxdz = $("#d_zxdz").val();
    if(zxdz.length>10)
    {
        parent.$.messager.alert('提示', '总线地址不能多于10个字节！');
        return;
    }
    var cj = $("#d_cj").val();
    if (cj == "") {
        parent.$.messager.alert('提示', '请选择桩厂家！');
        return;
    }
    var xh = $("#d_xh").val();
    if (xh == "") {
        parent.$.messager.alert('提示', '请选择桩型号！');
        return ;

    }
    var zhuangtai = $("#d_zt").val();
    if (zhuangtai == "") {
        parent.$.messager.alert('提示', '请选择充电桩状态！');
        return ;
    }
    var tysj = $("#d_tysj").val();
    if (zhuangtai == "已投运") {
        if (tysj == "") {
            parent.parent.$.messager.alert('提示', '投运时间不能为空！');
            return ;
        }
    }
    var bz = $("#d_bz").val();
    if (bz.length > 200) {
        parent.$.messager.alert('提示', '备注不能多于200字！');
        return;
    }

    $("#Form4").ajaxSubmit({
        url: url,
        dataType: "json",
        beforeSubmit: function () {
            return $("#Form4").form('validate');
        },
        success: function (result) {
            if (result.success) {
                if (branchno == null) {
                    parent.delrefresh();
                } else {
                    parent.updateTreeNode();
                }
                parent.$.messager.alert('提示', result.msg);
            } else {
                parent.$.messager.alert("提示", result.msg);
            }
        }
    });
}

//充电桩状态改变联动方法
function ztchange() {
    var zt = $("#d_zt").val();
    if (zt == "" || zt == "未投运") {
        $("#d_tysj").val("");
        $("#d_tr_tysj").hide();
    } else if (zt == "已投运") {
        $("#d_tr_tysj").show();
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