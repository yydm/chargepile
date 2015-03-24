<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChargePileDetailInfomation.aspx.cs"
    Inherits="ChargingPile.UI.WEB.pages.ChargePileDetailInfo.ChargePileDetailInfomation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>充电桩详细信息</title>
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="expires" content="0" />
    <link href="../../Styles/chargePileDetailInfomation.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Scripts/jquery-easyui-1.3.1/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../../Scripts/jquery-easyui-1.3.1/themes/icon.css" />
    <link href="../../Scripts/jquery-easyui-1.3.1/demo.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-easyui-1.3.1/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-easyui-1.3.1/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-easyui-1.3.1/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../../Scripts/highCharts/highcharts.js" type="text/javascript"></script>
    <script src="../../Scripts/highCharts/highcharts-more.js" type="text/javascript"></script>
    <script src="../../Scripts/highCharts/modules/exporting.src.js" type="text/javascript"></script>
    <script src="../../Scripts/json2.js" type="text/javascript"></script>
    <script src="../../Scripts/ChargePileDetailInfo/thisClass.js" type="text/javascript"></script>
    <script src="../../Scripts/WarnRecService/InvokeWarn.js" type="text/javascript"></script>
    <script src="../../Scripts/ChargePileDetailInfo/chargePileDetailInfomation.js" type="text/javascript"></script>
</head>
<body class="easyui-layout" data-opyions="minHeight:700"  style="width:1024px; margin: 0 auto;height:700px;min-height: 700px;overflow: auto; ">
    <input type="hidden" id="hzhuangid"/>
    <form id="form1" runat="server" >
    <div id="border-rig" data-options="region:'center'" style="overflow: hidden;" border="false">
        <div class="easyui-panel" style="height: 180px;" border="false" title="实时信息" iconcls="icon-form">
            <div class="ssxx">
                <div id="ssxx-v" class="ssxx-column1">
                </div>
                <div class="ssxx-column2">
                    <div class="ssxx-column2-css">
                    </div>
                </div>
                <div id="ssxx-u" class="ssxx-column1">
                </div>
            </div>
        </div>
        <div class="easyui-panel" style="height: 150px;" border="false" title="交易信息" iconcls="icon-form">
            <div class="tabs-css">
                <table class="tabs-css-table">
                    <tr>
                        <td class="td-lable">
                            <label>
                                充电开始时间：</label>
                        </td>
                        <td>
                            <input type="text" id="cdkssj" class="cls-txt2" />
                        </td>
                        <td class="td-lable">
                            <label>
                                峰电量：</label>
                        </td>
                        <td>
                            <input type="text" id="fdl" class="cls-txt" />
                        </td>
                        <td class="td-lable">
                            <label>
                                充电卡号：</label>
                        </td>
                        <td>
                            <input type="text" id="kh" class="cls-txt2" />
                        </td>
                    </tr>
                    <tr>
                        <td class="td-lable">
                            <label>
                                充电结束时间：</label>
                        </td>
                        <td>
                            <input type="text" id="cdjssj" class="cls-txt2" />
                        </td>
                        <td class="td-lable">
                            <label>
                                平电量：</label>
                        </td>
                        <td>
                            <input type="text" id="pdl" class="cls-txt" />
                        </td>
                        <td class="td-lable">
                            <label>
                                充电卡余额：</label>
                        </td>
                        <td>
                            <input type="text" id="kye" class="cls-txt" />
                        </td>
                    </tr>
                    <tr>
                        <td class="td-lable">
                            <label>
                                充电总时长：</label>
                        </td>
                        <td>
                            <input type="text" id="cdzsc" class="cls-txt2" />
                        </td>
                        <td class="td-lable">
                            <label>
                                谷电量：</label>
                        </td>
                        <td>
                            <input type="text" id="gdl" class="cls-txt" />
                        </td>
                        <td class="td-lable">
                            <label>
                                充电总金额：</label>
                        </td>
                        <td>
                            <input type="text" id="zje" class="cls-txt" />
                        </td>
                    </tr>
                    <tr>
                        <td class="td-lable">
                            <label>
                                充电总电量：</label>
                        </td>
                        <td>
                            <input type="text" id="zdl" class="cls-txt" />
                        </td>
                        <td class="td-lable">
                            <label>
                                尖电量：</label>
                        </td>
                        <td>
                            <input type="text" id="jdl" class="cls-txt" />
                        </td>
                        <td class="td-lable">
                            <label>
                                结算状态：</label>
                        </td>
                        <td>
                            <input type="text" id="jszt" class="cls-txt2" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="easyui-panel" style="height: 150px;" border="false" iconcls="icon-form"
            title="桩基本信息">
            <div class="tabs-css">
                <table class="tabs-css-table2">
                    <tr>
                        <td class="td-lable">
                            <label>
                                生产厂家：</label>
                        </td>
                        <td>
                            <input type="text" id="sccj" class="cls-txt3" />
                        </td>
                        <td class="td-lable">
                            <label>
                                执行峰电价：</label>
                        </td>
                        <td>
                            <input type="text" id="fdj" class="cls-txt4" />
                        </td>
                        <td class="td-lable">
                            <label>
                                投运时间：</label>
                        </td>
                        <td>
                            <input type="text" id="tysj" class="cls-txt3" />
                        </td>
                    </tr>
                    <tr>
                        <td class="td-lable">
                            <label>
                                厂家编号：</label>
                        </td>
                        <td>
                            <input type="text" id="cjbh" class="cls-txt3" />
                        </td>
                        <td class="td-lable">
                            <label>
                                执行平电价：</label>
                        </td>
                        <td>
                            <input type="text" id="pdj" class="cls-txt4" />
                        </td>
                        <td class="td-lable">
                            <label>
                                最高允许电流：</label>
                        </td>
                        <td>
                            <input type="text" id="yxdl" class="cls-txt3" />
                        </td>
                    </tr>
                    <tr>
                        <td class="td-lable">
                            <label>
                                桩运行编号：</label>
                        </td>
                        <td>
                            <input type="text" id="zyxbh" class="cls-txt3" />
                        </td>
                        <td class="td-lable">
                            <label>
                                执行谷电价：</label>
                        </td>
                        <td>
                            <input type="text" id="gdj" class="cls-txt4" />
                        </td>
                        <td class="td-lable">
                            <label>
                                最高允许电压：</label>
                        </td>
                        <td>
                            <input type="text" id="yxdy" class="cls-txt3" />
                        </td>
                    </tr>
                    <tr>
                        <td class="td-lable">
                            <label>
                                充电桩类型：</label>
                        </td>
                        <td>
                            <input type="text" id="zlx" class="cls-txt3" />
                        </td>
                        <td class="td-lable">
                            <label>
                                执行尖电价：</label>
                        </td>
                        <td>
                            <input type="text" id="jdj" class="cls-txt4" />
                        </td>
                        <td class="td-lable">
                            <label>
                                执行分摊电价：</label>
                        </td>
                        <td>
                            <input type="text" id="ftdj" class="cls-txt4" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div data-options="region:'south'" style="overflow: hidden;" border="false">
        <div id="response" class="easyui-panel" style="height: 160px;" iconcls="icon-warning"
            title="告警">
        </div>
    </div>
    <div data-options="region:'west'" style="width: 200px; padding: 1px; overflow: hidden;">
        <div id="panel-west" class="easyui-panel" style="height: 210px;" border="false" title=" ">
            <%--<div class="easyui-tabs" style="height: 210px;" border="false">--%>
            <div id="status" >
                <div id="gatDt" style="text-align: center;"></div>
                <img width="100px" height="100px" />
                <span id="content-status"></span>
            </div>
            
        </div>
        <div class="easyui-tabs" style="height: 330px;" border="false">
            <div title="导航" style="padding: 5px">
                <div class="info-row">
                    <div class="info-row-1" id="Div1">
                        <a href="#">
                            <img src="../../Images/通信信息.png" title="通信信息" width="53px" height="48px" onclick="txinfo()" />通信信息</a>
                    </div>
                    <div class="info-row-2" id="Div2">
                        <a href="#">
                            <img src="../../Images/停电信息.png" title="停电信息" width="53px" height="48px" onclick="tdinfo()" />停电信息</a>
                    </div>
                </div>
                <div class="info-row">
                    <div class="info-row-1" id="lk1">
                        <a href="#">
                            <img src="../../Images/交易信息.png" title="交易信息" width="53px" height="48px" onclick="jyinfo()" />交易信息</a>
                    </div>
                    <div class="info-row-2" id="lk2">
                        <a href="#">
                            <img src="../../Images/运行信息.png" title="运行信息" width="53px" height="48px" onclick="yxinfo()" />运行信息</a>
                    </div>
                </div>
                <div class="info-row">
                    <div class="info-row-1" id="lk3">
                        <a href="#">
                            <img src="../../Images/运维信息.png" title="运维信息" width="53px" height="48px" onclick="ywinfo()" />运维信息</a>
                    </div>
                    <div class="info-row-2" id="lk4">
                        <a href="#">
                            <img src="../../Images/使用信息.png" title="使用信息" width="53px" height="48px" onclick="syinfo()" />使用信息</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="dlg" class="easyui-dialog" data-options="closed:true,modal:true,buttons:'#dlg_buttons',title:'告警处理',iconCls: 'icon-info'">
        <div style="height: 100px; width: 100%;">
            <div id="dlg-select">
                <input type="radio" id="r_gjcl_done" name="r_gjcl" checked="checked" value="1" />
                <label for="r_gjcl_done">
                    灭警完成</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="radio" id="r_gjcl_wait" name="r_gjcl" value="0" /><label for="r_gjcl_wait">继续等待</label>
            </div>
        </div>
        <div id="dlg_buttons">
            <a href="#" class="easyui-linkbutton" iconcls="icon-save" onclick="btn_ok2();">确定</a>
            <a href="#" class="easyui-linkbutton" iconcls="icon-remove" onclick="btn_close();">取消</a>
        </div>
    </div>
    <input id="hidd_warnid" type="hidden" />
    <input id="hidd_itemno" type="hidden" />
    <input id="hidd_TargetDev" type="hidden" />
    <input id="hidd_DataItemId" type="hidden" />
    <input id="hidd_WorkNum" type="hidden" />
    </form>
</body>
</html>
