<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StartStopManage.aspx.cs"
    Inherits="ChargingPile.UI.WEB.pages.RemoteControl.StartStopManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>远程启动停止</title>
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="expires" content="0" />
    <link rel="stylesheet" type="text/css" href="../../Scripts/jquery-easyui-1.3.1/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../../Scripts/jquery-easyui-1.3.1/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/Style.css" />
    <link rel="stylesheet" href="../../Scripts/jquery-ui-1.10.3.custom/css/demos.css" />
    <link rel="stylesheet" href="../../Scripts/jquery-ui-1.10.3.custom/development-bundle/themes/base/jquery.ui.all.css" />
    <script src="../../Scripts/jquery-easyui-1.3.1/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-easyui-1.3.1/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-easyui-1.3.1/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-easyui-1.3.1/jquery.form.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.10.3.custom/development-bundle/ui/jquery.ui.core.js"
        type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.10.3.custom/development-bundle/ui/jquery.ui.widget.js"
        type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.10.3.custom/development-bundle/ui/jquery.ui.progressbar.js"
        type="text/javascript"></script>
    <script src="../../Scripts/remoteControl/startStopManage.js" type="text/javascript"></script>
    <style type="text/css">
       
        #chargstation
        {
            width: 150px;
            height: 20px;
            font-size: 14px;
        }
        .tdrundate, #btnok
        {
            padding-left: 30px;
        }
        #progressbar
        {
            margin-top: 40px;
            margin-left: 15px;
            margin-right: 15px;
        }
        .ui-progressbar
        {
            position: relative;
        }
        .progress-label
        {
            position: absolute;
            left: 50%;
            top: 4px;
            font-weight: bold;
            text-shadow: 1px 1px 0 #fff;
        }
        .txtsf
        {
            border: none;
            background: none;
            width: 50px;
        }
        .btnokreturn
        {
            width: 240px;
        }
        .txtwid
        {
            width: 100px;
        }
    </style>
</head>
<body class="easyui-layout">
    <form id="form1" runat="server">
    <div data-options="region:'center',title:'远控远调>>远程控制'" border="false">
        <div id="tb" style="padding-top: 5px;">
            <div style="float: left; margin-left: 10px;">
                请选择充电站:
                <select id="chargstation" name="chargstation" onchange="chargstation_onchanged()">
                </select>
            </div>
            <div style="float: right; margin-right: 20px;">
                <a href="#" class="easyui-linkbutton" iconcls="icon-start" plain="true" onclick="btnStart_click()">
                    启动</a> <a id="pause" href="#" class="easyui-linkbutton" iconcls="icon-stop" plain="true"
                        onclick="btnStop_click()">停止</a>
                <%--<a href="#" class="easyui-linkbutton" plain="true"
                            iconcls="icon-pause" onclick="btnPause_click()">暂停</a> --%><%--<a href="#" class="easyui-linkbutton"
                                plain="true" iconcls="icon-cancel" onclick="btnCancel_click()">取消</a>--%>
            </div>
        </div>
        <table id="dgchargpile">
        </table>
    </div>
    <div id="dlg" class="easyui-dialog">
        <div class="tableForm">
            <table>
                <tr>
                    <td colspan="3">
                        <table id="dg_chargpile_stated">
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="txtwid">
                        成功:<input id="txtSuccess" type="text" class="txtsf" />
                    </td>
                    <td class="txtwid">
                        失败:<input id="txtFaile" type="text" class="txtsf" />
                    </td>
                    <td class="btnokreturn">
                        <a id="btnok" href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-continue"
                            onclick="btnOk_click()">继续</a> <a href="javascript:void(0)" class="easyui-linkbutton"
                                iconcls="icon-cancel" onclick="btnReturn_click()">返回</a>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="dlgprogress" class="easyui-dialog">
        <div id="progressbar">
            <div class="progress-label">
                正在处理...</div>
        </div>
        <h3 style="margin-left: 150px;">
            遥控指令已发出，请稍等！</h3>
    </div>
    </form>
</body>
</html>
