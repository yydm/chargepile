var myurl;
var mydata;
var postype = "POST";
var getype = "GET";
var jsontype = "json";
var htmltype = "html";
var contentype = "application/json; charset=utf-8";
var nextflag = "kwh";

//----------------------------  初始化  ---------------------------------
$(function () {
    chargeingpileinfo();
    yxycwarn();
    chargepileCardwarn();
    //设置每10分钟更新一次
    setInterval(function () {
        chargeingpileinfo();
        yxycwarn();
        chargepileCardwarn();
    }, 600000);
    setInputReadonly();
//    setChargePileCount();
//    setChargeingPileCount();
    setWillChargeingPileCount();

    setChargingPileZdl();
    setChargingPileZje();
    setChargingPileZsc();
    rankZje_onclick();
    //设置每5秒更新一次
    setInterval(function () {
        setSecondFoo();
    }, 5000);
    $('#tabs-tool').removeAttr("style");

    var browser = $.browser;
    if (browser.msie && browser.version == "6.0") {

    }
    changeBorder();
});

var loadsec = true;
var rank_obj = {
    url: '../../WebService/IndexService.ashx',
    queryParams: { action: 'FindByRankZje' },
    fit: true,
    singleSelect: true,
    border: false,
    showFooter: true,
    toolbar: '#toolbal'
};
//----------------------------  页面方法  ---------------------------------

function changeBorder() {
    $('#dg_chargeingpile_info').datagrid('getPanel').removeClass('lines-both lines-no lines-right lines-bottom').addClass('lines-no');
    $('#dg_yxyc_warn').datagrid('getPanel').removeClass('lines-both lines-no lines-right lines-bottom').addClass('lines-no');
    $('#dg_chargepile_warn').datagrid('getPanel').removeClass('lines-both lines-no lines-right lines-bottom').addClass('lines-no');
}

/*
* *快捷导航连接
*/


//实时交易
function ssjy() {
    winOpen("../Flex/swf.htm?swf=RunStatusTable.swf&title=" + escape("场站监视>>全景监视表"), 1005, 610, 0, 1);
}
//实时交易
function ssjs() {
    winOpen("../Flex/swf.htm?swf=StationUseChart.swf&title=" + escape("场站监视>>充电站使用情况"), 1020, 610, 0, 1);
}
//实时信息
function gisjy() {
    winOpen("../../pages/gis/gis.htm", 1024, 600, 0, 1);
}
//告警服务
function gjfw() {
    winOpen("../WarnRecService/RealTimeWarn.htm", 1024, 650, 0, 1);
}
//充电卡
function cdk() {
    winOpen("../ICCard/ICCard.htm", 1235, 620, 0, 1);
}
//充电卡
function czsc() {
    //alert('下载操作手册');
    winOpen("../../充电桩在线监测系统用户手册.doc");
}
//更多桩充电信息
function ztMore() {
    winOpen("zhuangZt.htm", 1024, 650, 0, 1);
}
//更多实时告警信息
function gjMore() {
    winOpen("../../pages/WarnRecService/RealTimeQuery.htm?dotype=hidden", 1024, 770, 0, 1);
}
//更多充电卡告警信息
function cwMore() {
    winOpen("../../pages/WarnRecService/ChargCardWarn.htm?do=hidden", 1024, 650, 0, 1);
}
/* *
* * 每5秒更换一页
* */
function setSecondFoo() {
    switch (nextflag) {
        case "zje":
            rankZje_onclick();
            break;
        case "kwh":
            rankKWH_onclick();
            break;
        case 'gzl':
            rankGzl_onclick();
            break;
        case 'cardzje':
            rankCardZje_onclick();
            break;
        default:
    }
}

function setTableShow() {
    $(".datagrid-header-row").eq(3).css('display', 'block');
}


//打开窗口方法
function winOpen(Url, width, height, scrollbar, resize) {
    //    Url     
    //    widht   
    //    height     
    //    scrollbar    0    yes    1    no     
    //    resize    0    true    1    false   

    ow = width;
    oh = height;
    os = scrollbar;
    or = resize;
    var xposition = 0;
    var yposition = 0;
    if ((parseInt(navigator.appVersion) >= 4)) {
        xposition = (screen.width - width) / 2;
        yposition = (screen.height - height - 25) / 2;
    }
    window.open(Url, "", "width=" + ow + ",height=" + oh + ",scrollbars=" + os + ",resizable=" + or + ",left=" + xposition + ",top=" + yposition + ",location = no");
}


/* *
* *充电桩充电信息datagrid
* */
function chargeingpileinfo() {
    $('#dg_chargeingpile_info').datagrid({
        url: '../../WebService/IndexService.ashx',
        queryParams: { action: 'findbychargingpileinfo' },
        fit: true,
        singleSelect: true,
        border: false,
        showHeader: false,
        columns: [[
            {
                field: 'Note',
                title: '充电状态',
                align: 'left',
                width: 720,
                formatter: function (val, src) {
                    var yxbh = null;
                    if (!src.YunXingBh) {
                        yxbh = "###";
                    } else {
                        yxbh = src.YunXingBh;
                    }
                    return "<img src='../../Images/bullet-blue.png' width='10px' height='10px' />"
                        + "<span class='fontcolor'>" + src.ZhanJc + yxbh + "号桩    在    "
                        + src.DateTime + "    " + src.Note + "    卡号：" + src.CardNo + "     [ " + src.CreateDtPara + " ]</span>";
                }
            }
        ]],
        onClickRow: function (index, row) {
            if (row.YunXingBh) {
                //location.href = "/pages/ChargePileDetailInfo/ChargePileDetailInfomation.aspx?PowerPileNo=" + row.TargetDev2;
                winOpen("../../pages/ChargePileDetailInfo/ChargePileDetailInfomation.aspx?PowerPileNo=" + row.TargetDev2, 1150, 700, 0, 1);
            }

        }
    });
}

/**
* *异常告警datagrid(以前是遥测遥信，现在改为异常告警，区别就个名称，注意下ok)
**/
function yxycwarn() {
    $('#dg_yxyc_warn').datagrid({
        url: '../../WebService/IndexService.ashx',
        queryParams: { action: 'findbywarninfo' },
        fit: true,
        singleSelect: true,
        border: false,
        showHeader: false,
        columns: [[{ field: 'Id', hidden: true },
            {
                field: 'ItemName',
                title: '异常告警',
                align: 'left',
                width: 720,
                formatter: function (val, src) {
                    var yxbh = null;
                    if (!src.YunXingBh) {
                        yxbh = "###";
                    } else {
                        yxbh = src.YunXingBh;
                    }
                    var dtstr = null;
                    if (src.ProcessFlag == 0) {
                        if (src.OccurDt != null || src.OccurDt != "" || src.OccurDt != undefined) {
                            dtstr = "<span class='fontcolor'>在    " + src.OccurDt + "</span>告警";
                        } else {
                            dtstr = "";
                        }
                    } else {
                        if (src.UpdateDt != null || src.UpdateDt != "" || src.UpdateDt != undefined) {
                            dtstr = "<span class='fontcolor'>在    " + src.UpdateDt + "</span>灭警";
                        } else {
                            dtstr = "";
                        }
                    }

                    var content = "<img src='../../Images/bullet-blue.png' width='10px' height='10px' />"
                        + "<span class='fontcolor'>" + src.ZhanJc + yxbh + "号桩    在    " + src.OccurDt
                        + "    发生    " + src.ItemName + "</span>异常，";
                    return "<lable title='异常内容：&#13;" + src.LogDesc + "&#13;[ " + src.CreateDtPara + " ]'>" + content + dtstr + "</lable>";
                }
            }
        ]],
        onClickRow: function (index, row) {
            if (row.YunXingBh) {
                //location.href = "/pages/ChargePileDetailInfo/ChargePileDetailInfomation.aspx?PowerPileNo=" + row.TargetDev;
                winOpen("../../pages/ChargePileDetailInfo/ChargePileDetailInfomation.aspx?PowerPileNo=" + row.TargetDev, 1150, 700, 0, 1);
            }

        }
    });
}

/**
* *充电卡异常使用告警datagrid
**/
function chargepileCardwarn() {
    $('#dg_chargepile_warn').datagrid({
        url: '../../WebService/IndexService.ashx',
        queryParams: { action: 'findbycardwarninfo' },
        fit: true,
        singleSelect: true,
        border: false,
        showHeader: false,
        striped: true,
        columns: [[
            {
                field: 'TargetDataKey',
                title: '卡号',
                align: 'left',
                showHeader: false,
                width: 720,
                formatter: function (val, src) {
                    var yxbh = null;
                    if (!src.YunXingBh) {
                        yxbh = "###";
                    } else {
                        yxbh = src.YunXingBh;
                    }
                    return "<img src='../../Images/bullet-blue.png' width='10px' height='10px' />"
                        + "<span class='fontcolor'>" + src.ZhanJc + src.YunXingBh
                        + "号桩    在    " + src.OccurDt + "    卡号："
                        + src.TargetDataKey + "    使用异常    [ " + src.CreateDtPara + " ]</span>";
                }
            }/// <reference path="../jquery-easyui-1.3.1/themes/" />

        ]],
        onClickRow: function (index, row) {
            if (row.YunXingBh) {
                //location.href = "/pages/ChargePileDetailInfo/ChargePileDetailInfomation.aspx?PowerPileNo=" + row.TargetDev;
                winOpen("../../pages/ChargePileDetailInfo/ChargePileDetailInfomation.aspx?PowerPileNo=" + row.TargetDev, 1150, 700, 0, 1);
            }
        }
    });
}

/**
* *在id为da_rank的父节点外面添加id为toolbar的div
**/
function insertHtmlInDom() {
    $('#dg_rank').parent().after($('.datagrid-toolbar'));
    setTableShow();
}

/**
* *设置input只读
**/
function setInputReadonly() {
    $(".txt-input").attr("readonly", true);
}

///**
//* *设置充电桩总数量
//**/
//function setChargePileCount() {
//    myurl = "../../WebService/IndexService.ashx";
//    mydata = {
//        action: "findbychargepilecount"
//    };
//    ajaxData();
//}

///**
//* *设置充电桩总数量
//* *ajax成功返回
//**/
//function ajaxsuccess_setChargePileCount(data) {
//    $("#zsl").val("");
//    $("#zsl").val(data.Total + "个");
//}

///**
//* *设置充电桩充电中总数量
//**/
//function setChargeingPileCount() {
//    myurl = "../../WebService/IndexService.ashx";
//    mydata = {
//        action: "FindByChargingPileCount"
//    };
//    ajaxData();
//}

///**
//* *设置充电桩充电中总数量
//* *ajax成功返回
//**/
//function ajaxsuccess_setChargeingPileCount(data) {
//    $("#cdz").val("");
//    $("#cdz").val(data.Total + "个");
//}

/**
* *设置充电桩待充电总数量
**/
function setWillChargeingPileCount() {
    //    var zsl = $("#zsl").val();
    //    var cdz = $("#cdz").val();
    //    var izsl = parseInt(zsl);
    //    var icdz = parseInt(cdz);
    var rpc = new DataGatherRpc;
    /*异步调用：*/
    rpc.QueryPileWorkStatus(function (resp) {
        var str = JSON2.stringify(resp);
        //var str = '{"data":[{"ZHAN_BH":100,"ZHUAN_MC":"南七大院","cnt":36,"cnt1":17,"cnt2":6,"cnt3":0,"cnt4":3,"cnt5":2},{"ZHAN_BH":300,"ZHUAN_MC":"江淮本部","cnt":58,"cnt1":16,"cnt2":18,"cnt3":3,"cnt4":2,"cnt5":0}],"success":true} ';
        var obj = eval("(" + str + ")");
        if (obj.success) {
            var len = obj.data.length;
            var cnt = 0, cnt1 = 0, cnt2 = 0;
            for (var i = 0; i < len; i++) {
                cnt += parseInt(obj.data[i].cnt); //充电桩总数量
                cnt1 += parseInt(obj.data[i].cnt1); //待充电总数量
                cnt2 += parseInt(obj.data[i].cnt2); //充电中总数量
            }
            $("#zsl").val(cnt + "个");
            $("#dcd").val(cnt1 + "个");
            $("#cdz").val(cnt2 + "个");
        }
    });
    //$("#dcd").val(izsl - icdz + "个");
}

/**
* *设置查询本月累计充电总电量
**/
function setChargingPileZdl() {
    myurl = "../../WebService/IndexService.ashx";
    mydata = {
        action: "findbychargingpilezdl"
    };
    ajaxData();
}

/**
* *查询本月累计充电总电量
* *ajax成功返回
**/
function ajaxsuccess_setChargingPileZdl(data) {
    $("#zdl").val("");
    $("#zdl").val(data.Msg + "KWH");
}

/**
* *查询本月累计充电总金额
**/
function setChargingPileZje() {
    myurl = "../../WebService/IndexService.ashx";
    mydata = {
        action: "FindByChargingPileZje"
    };
    ajaxData();
}

/**
* *查询本月累计充电总金额
* *ajax成功返回
**/
function ajaxsuccess_setChargingPileZje(data) {
    $("#zje").val("");
    $("#zje").val("" + data.Msg + "元");
}

/**
* *查询本月累计充电总时长
**/
function setChargingPileZsc() {
    myurl = "../../WebService/IndexService.ashx";
    mydata = {
        action: "FindByChargingPileZsc"
    };
    ajaxData();
}

/**
* *查询本月累计充电总时长
* *ajax成功返回
**/
function ajaxsuccess_setChargingPileZsc(data) {
    $("#zsc").val("");
    $("#zsc").val(data.Msg);
}
//----------------------------  页面事件  ---------------------------------

/**
* *按充电总金额
**/
function rankZje_onclick() {
    rank_obj.queryParams.action = 'FindByRankZje';
    rank_obj.columns = [[
        { field: 'RowNum', title: '序号', align: 'center', width: 42 },
        { field: 'ZhanJc', title: '场站简称', align: 'center', width: 140 },
        { field: 'Zje', title: '充电总金额', align: 'center', width: 110,
            formatter: function (value, row, index) {
                if (row.Zje == null) {
                    return "0.00";
                }
                return row.Zje;
            }
        }
    ]];
    $('#dg_rank').datagrid(rank_obj);
    $('#dg_rank').datagrid({
        onLoadSuccess: function () {
            nextflag = "kwh";
            $("#t_rank a").unbind("click");
            $("#t_rank a").bind("click", function () {
                winOpen("../../pages/main/Tab4LinkPage/Tab1.htm", 500, 600, 0, 1);
            });
            insertHtmlInDom();
            $("#toolbar a").removeClass("aLinkHover");
            $("#toolbar a").eq(0).addClass("aLinkHover");
            $("#tabs-rank").tabs('update', {
                tab: $('#tabs-rank').tabs('getSelected'),
                options: {
                    title: '按充电总金额'
                }
            });
        }
    });
}

/**
* *按平均充电量
**/
function rankKWH_onclick() {
    rank_obj.queryParams.action = 'findbyrankavgzdl';
    rank_obj.columns = [[
        { field: 'RowNum', title: '序号', align: 'center', width: 42 },
        { field: 'ZhanJc', title: '场站简称', align: 'center', width: 140 },
        { field: 'Pjcdl', title: '平均充电量(KWH）', align: 'center', width: 110 }
    ]];
    $('#dg_rank').datagrid(rank_obj);
    $('#dg_rank').datagrid({
        onLoadSuccess: function () {
            nextflag = 'gzl';
            $("#t_rank a").unbind("click");
            $("#t_rank a").bind("click", function () {
                winOpen("../../pages/main/Tab4LinkPage/Tab2.htm", 500, 600, 0, 1);
            });
            insertHtmlInDom();
            $("#toolbar a").removeClass("aLinkHover");
            $("#toolbar a").eq(1).addClass("aLinkHover");
            $("#tabs-rank").tabs('update', {
                tab: $('#tabs-rank').tabs('getSelected'),
                options: {
                    title: '按平均充电量'
                }
            });
        }
    });
}

/**
* *按运行故障率
**/
function rankGzl_onclick() {
    rank_obj.queryParams.action = 'FindByRankFailureRate';
    rank_obj.columns = [[
        { field: 'RowNum', title: '序号', align: 'center', width: 42 },
        { field: 'ZhanJc', title: '场站简称', align: 'center', width: 140 },
        { field: 'Gzl', title: '故障率(%)', align: 'center', width: 110 }
    ]];
    $('#dg_rank').datagrid(rank_obj);
    $('#dg_rank').datagrid({
        onLoadSuccess: function () {
            nextflag = 'cardzje';
            $("#t_rank a").unbind("click");
            $("#t_rank a").bind("click", function () {
                winOpen("../../pages/main/Tab4LinkPage/Tab3.htm", 500, 600, 0, 1);
            });
            insertHtmlInDom();
            $("#toolbar a").removeClass("aLinkHover");
            $("#toolbar a").eq(2).addClass("aLinkHover");
            $("#tabs-rank").tabs('update', {
                tab: $('#tabs-rank').tabs('getSelected'),
                options: {
                    title: '按运行故障率'
                }
            });
        }
    });
}

/**
* *按卡消费总额
**/
function rankCardZje_onclick() {
    rank_obj.queryParams.action = 'findbyrankcardzje';
    rank_obj.columns = [[
        { field: 'RowNum', title: '序号', align: 'center', width: 42 },
        { field: 'CardNo', title: '卡号', align: 'center', width: 140 },
        { field: 'Je', title: '消费总金额(￥)', align: 'center', width: 110 }
    ]];
    $('#dg_rank').datagrid(rank_obj);
    $('#dg_rank').datagrid({
        onLoadSuccess: function () {
            nextflag = 'zje';
            $("#t_rank a").unbind("click");
            $("#t_rank a").bind("click", function () {
                winOpen("../../pages/main/Tab4LinkPage/Tab4.htm", 500, 600, 0, 1);
            });
            insertHtmlInDom();
            $("#toolbar a").removeClass("aLinkHover");
            $("#toolbar a").eq(3).addClass("aLinkHover");
            $("#tabs-rank").tabs('update', {
                tab: $('#tabs-rank').tabs('getSelected'),
                options: {
                    title: '按卡消费总额'
                }
            });
        }
    });
}

/**
* *保存告警处理界面
**/
function btn_ok() {
    var clcz = $("[name=r_gjcl]:checked").val();
    if (clcz == 1) {
        myurl = "../../WebService/WarnRecService.ashx";
        mydata = {
            action: "offPolice",
            warnid: $("#hidd_warnid").val(),
            warntype: $("#hidd_warntype").val()
        };
        ajaxData();
    }
    btn_close();
    return false;
}

/**
* *告警处理ajax成功时调用的方法
**/
function ajaxSuccess_btn_ok(data) {
    switch (data.Status) {
        case 0:
            $.messager.alert("提示", data.Msg);
            break;
        case 1:
            switch (data.Msg) {
                case "telesignallingWarn":
                    yxycwarn();
                    break;
                case "cardWarn":
                    chargepileCardwarn();
                    break;
                default:
            }

        default:
    }
}
/**
* *关闭告警处理界面
**/
function btn_close() {
    $('#dlg').dialog('close');
}


/**
* *打开告警处理界面
**/
function OffPolice_click(warnid, warntype) {
    $("#hidd_warnid").val("");
    $("#dlg").dialog("open");
    $("[name=r_gjcl]").eq(0).attr("checked", true);
    $("#hidd_warnid").val(warnid);
    $("#hidd_warntype").val(warntype);
}
//----------------------------  ajax方法  ---------------------------------

/**
* *ajax增删改查方法
**/
function ajaxData() {
    $.ajax({
        url: myurl,
        type: postype,
        async: false,
        data: mydata,
        dataType: jsontype,
        success: serviceSuccess,
        error: serviceError
    });
}

/**
* *ajax成功时返回resultObject是json数据
**/
function serviceSuccess(resultObject) {
    if (resultObject == null) {
        return true;
    }
    switch (resultObject.Status) {
        case 0:
        case 2:
            $.messager.alert("提示", resultObject.Msg);
            break;
        case 1:
            eval(resultObject.JsExecuteMethod + "(resultObject)");
            break;
        default:
    }
    return true;
}

/**
* *ajax失败时返回
**/
function serviceError(result) {
    return false;
}