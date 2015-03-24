var myurl;
var mydata;
$(function () {
    urlinfo = window.location.href; //获取当前页面的url 
    len = urlinfo.length; //获取url的长度 
    offset1 = urlinfo.indexOf("?"); //设置参数字符串开始的位置 
    if (offset1 > 0) {
        newsidinfo = urlinfo.substr(offset1, len)//取出参数字符串 这里会获得类似“id=1”这样的字符串 
        data = newsidinfo.split("=")[1]; //对获得的参数字符串按照“=”进行分割 
        if (data == "time") {
            $("#endtime").val((new Date()).Format("yyyy-MM-dd"));
            $("#begintime").val((new Date()).Format("yyyy-MM-dd"));
        }
        else if (data == "type") {
            $("#PROTYPE").val("0");
            $("#endtime").val("");
            $("#begintime").val("");
        }
    } else {
        $("#endtime").val((new Date()).Format("yyyy-MM-dd"));
        $("#begintime").val((new Date()).Format("yyyy-MM") + "-01");
    }

    getStation1();
    var zhanbh = $("#ZHANMC").val();
    var protype = $("#PROTYPE").val();
    var begintime = $("#begintime").val();
    var endtime = $("#endtime").val();

    $("#t_txwarn").datagrid({
        url: "/WebService/DTUService.ashx",
        queryParams: { action: "gettxwarn", zhanbh: zhanbh, processtype: protype, begintime: begintime, endtime: endtime },
        fit: true,
        nowrap: false,
        fitColumns: true,
        striped: true,
        border: false,
        rownumbers: true,
        singleSelect: true,
        pagination: true,
        toolbar: "#d_tb",
        pageList: [10, 20, 30, 50],
        pageSize: 20,
        columns: [[
                    { field: "Id", title: "唯一id", width: 180, align: 'center', hidden: true },
                    { field: "Occurdt", title: "时间", width: 130, align: 'center',
                        formatter: function (value, src) {
                            if (value != null) {
                                return eval("new " + value.split('/')[1]).Format("yyyy-MM-dd hh:mm:ss");
                            }
                        }
                    },
                    { field: "ZHANMC", title: "充电场站名称", width: 180, align: 'center' },
                    { field: "DTUMC", title: "DTU名称", width: 180, align: 'center' },
                    { field: 'PP', title: '已处理', width: 80, align: 'center',
                        formatter: function (value, src) {
                            var id = src.Id;
                            if (src.ProcessFlag == "0") {
                                return '否';
                            } else if (src.ProcessFlag == "1" || src.ProcessFlag == "2") {
                                return '是';
                            }
                        }
                    },
                    { field: "ProcessFlag", title: "处理方式", width: 130, align: 'center',
                        formatter: function (value, src) {
                            if (value == "0") {
                                return "等待灭警";
                            } else if (value == "1") {
                                return "自动灭警";
                            } else if (value == "2") {
                                return "人工灭警";
                            }
                        }
                    },
                    { field: 'P', title: '操作', width: 50, align: 'center',
                        formatter: function (value, src) {
                            var param = new Array();
                            param[0] = src.TargetDev;
                            param[1] = src.DataItemId;
                            param[2] = src.WorkNum;
                            param[3] = src.Id;
                            if (src.ProcessFlag == "0") {
                                return '<a href="#" onclick="btnWarn_click(\'' + param + '\')" class="easyui-linkbutton" plain="true" title="" iconcls="icon-quench"></a>';
                            } else if (src.ProcessFlag == "1" || src.ProcessFlag == "2") {
                                return '<a href="javascript:void(0)" class="easyui-linkbutton" plain="true" title="" iconcls="icon-ok"></a>';
                            }
                        }
                    }

                ]],
        onLoadSuccess: function () {
            $($('#t_txwarn').datagrid("getPanel")).find('a.easyui-linkbutton').linkbutton();
        }

    });


});

/**
* *保存告警处理界面
**/
function btn_ok() {
    var targetdev = $("#h_targetdev").val();
    var dataitemid = $("#h_dataitemid").val();
    var vorknum = $("#h_worknum").val();
    var warnid = $("#hidd_warnid").val();
    var clcz = $("[name=r_gjcl]:checked").val();
    if (clcz == 1) {
        InvokeWarn(targetdev, dataitemid, vorknum); //调用远程接口

        myurl = "../../WebService/WarnRecService.ashx";
        mydata = {
            action: "offPolice",
            warnid: warnid
        };
        $.ajax({
            url: myurl,
            type: "post",
            async: false,
            data: mydata,
            dataType: "html",
            success: function (result) {
                $.messager.alert('消息', '灭警成功', "info");
                $("#t_txwarn").datagrid("reload");
            }
        });
    }
    btn_close();
    return false;
}


/**
* *打开告警处理界面
**/
function btnWarn_click(param) {
    $("#dlg").dialog("open");
    $("[name=r_gjcl]").eq(0).attr("checked", true);
    $("#h_targetdev").val(param.split(',')[0]);
    $("#h_dataitemid").val(param.split(',')[1]);
    $("#h_worknum").val(param.split(',')[2]);
    $("#hidd_warnid").val(param.split(',')[3]);
    return false;
}

/**
* *关闭告警处理界面
**/
function btn_close() {
    $('#dlg').dialog('close');
}


//条件查询
function search() {
    var zhanbh = $("#ZHANMC").val();
    var protype = $("#PROTYPE").val();
    var begintime = $("#begintime").val();
    var endtime = $("#endtime").val();
    $("#t_txwarn").datagrid("load", { action: "gettxwarn", zhanbh: zhanbh, processtype: protype, begintime: begintime, endtime: endtime });
}


//加载充电站下拉菜单
function getStation1() {
    $.ajax({
        url: "/WebService/ChargPileMaintainService.ashx",
        type: "post",
        async: false,
        data: "action=getstation",
        dataType: "html",
        success: function (html) {
            var val = null;
            eval("val=" + html);
            var length = val.rows.length;
            $("#ZHANMC").html("<option value='' >—请选择—</option>");
            for (var i = 0; i < length; i++) {
                $("#ZHANMC").append("<option value=" + val.rows[i].ZhanBh + " >" + val.rows[i].Zhan_Jc + "</option>");
            }
        }
    });
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