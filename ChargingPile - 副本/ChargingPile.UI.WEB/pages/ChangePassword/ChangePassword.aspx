<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs"
    Inherits="ChargingPile.UI.WEB.pages.ChangePassword.ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改密码</title>
    <link rel="stylesheet" type="text/css" href="../../Scripts/jquery-easyui-1.3.1/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../../Scripts/jquery-easyui-1.3.1/themes/icon.css" />
    <script src="../../Scripts/jquery-easyui-1.3.1/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-easyui-1.3.1/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-easyui-1.3.1/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-easyui-1.3.1/jquery.form.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Scripts/ChangePassword/changePassword.js"></script>
    <style type="text/css">
        .departmentTree
        {
            width: 200px;
            overflow: hidden;
        }
        .ztreeUL
        {
            width: 100%;
            height: 100%;
            overflow: auto;
            background: #E9EEF4;
            margin-top: 1px;
        }
        .content
        {
            margin: 0;
            padding: 0;
        }
        .content_table
        {
            width: 400px;
            margin: 100px 150px 0 330px;
        }
        .tablePanel
        {
            padding: 10px 0 10px 60px;
        }
        .tr
        {
            height: 40px;
        }
        .td
        {
            width: 90px;
        }
        .btn2
        {
            margin-top: 30px;
        }
        .depClass
        {
            width: 130px;
        }
        .inputWidth, #barcode, #lpeople2
        {
            width: 150px;
        }
        #linka, #linkb, #linkc
        {
            margin-left: 120px;
        }
        .menuContent
        {
            display: none;
            position: absolute;
        }
    </style>
</head>
<body class="easyui-layout">
    <form id="form1" runat="server">
    <div data-options="region:'center'">
        <div class="content">
            <div class="content_table">
                <div class="easyui-panel" title="修改密码" style="width: 400px">
                    <div class="tablePanel">
                        <table>
                            <tr class="tr">
                                <td class="td">
                                    登&nbsp;&nbsp;录&nbsp;&nbsp;名:
                                </td>
                                <td>
                                    <input id="txtWorkNum" type="text" readonly="readonly" value="<%=GetWorkNum() %>" />
                                </td>
                            </tr>
                            <tr class="tr">
                                <td class="td">
                                    用&nbsp;&nbsp;户&nbsp;&nbsp;名:
                                </td>
                                <td>
                                    <input id="txtName" type="text" readonly="readonly" value="<%=GetUserName() %>" />
                                </td>
                            </tr>
                            <tr class="tr">
                                <td class="td">
                                    原&nbsp;&nbsp;密&nbsp;&nbsp;码:
                                </td>
                                <td>
                                    <input id="txtPass" type="password" class="easyui-validatebox" data-options="required:true,validType:'length[4,60]'" />
                                </td>
                            </tr>
                            <tr class="tr">
                                <td class="td">
                                    新&nbsp;&nbsp;密&nbsp;&nbsp;码:
                                </td>
                                <td>
                                    <input id="txtNewPass" type="password" class="easyui-validatebox" data-options="required:true,validType:'length[4,60]'" />
                                </td>
                            </tr>
                            <tr class="tr">
                                <td class="td">
                                    确认新密码:
                                </td>
                                <td>
                                    <input id="txtNewPass2" type="password" class="easyui-validatebox" data-options="required:true,validType:'length[4,60]'"
                                        validtype="equals['#txtNewPass']" />
                                </td>
                            </tr>
                        </table>
                        <div class="btn2">
                            <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-save" onclick="btnAdd_click()">
                                保存</a> <a id="linka" href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-cancel"
                                    id="A1" onclick="btnClear_click()">清空</a></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
