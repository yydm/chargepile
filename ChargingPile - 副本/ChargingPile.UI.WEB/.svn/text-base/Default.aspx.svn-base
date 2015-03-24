<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChargingPile.UI.WEB.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>充电桩在线监测系统</title>
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="expires" content="0" />
    <link href="Scripts/superfish-1.4.8/css/superfish.css" rel="stylesheet" type="text/css" />
    <link href="Scripts/jquery-easyui-1.3.1/themes/default/easyui.css" rel="stylesheet"
        type="text/css" />
    <!--验证session是否过期-->
    <script type="text/javascript" src="WebService/Common.ashx?action=isoverdue"></script>
    <script src="Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="Scripts/superfish-1.4.8/js/superfish.js" type="text/javascript"></script>
    <script src="Scripts/superfish-1.4.8/js/hoverIntent.js" type="text/javascript"></script>
    <script src="Scripts/jquery-easyui-1.3.1/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="Scripts/superfish-1.4.8/js/jquery.bgiframe.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-easyui-1.3.1/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("ul.sf-menu").superfish().find('ul').bgIframe({ opacity: false });
            //$("#contentFrame").attr("src", mainSrc);
            var mf_height = window.screen.availHeight - 200;
            var bro = $.browser;
            var h = 695;
            if (bro.mozilla || (bro.msie && bro.version == "8.0")) {
                mf_height = mf_height - 40;
                h = 685;
            }
            mf_height = mf_height > h ? mf_height : h;
            $("#contentFrame").css("height", mf_height);
            $("body").css("width", window.screen.availWidth - 23);
            $("#form1").css("padding-left", (window.screen.availWidth - 1024 - 5) / 2);
        });
        function sf(url, obj) {
            url = url.substr(0, url.lastIndexOf('?') + 1) + escape(url.substr(url.lastIndexOf('?') + 1, url.length));
            $("#contentFrame").attr("src", url);
            $(obj).parent().parent().fadeOut(1000);
        }

        function logout() {
            location.href = "Login.aspx";
        }

        function messager(title, msg, icon) {
            if (!icon) {
                icon = "info";
            }
            $.messager.alert(title, msg, icon);
            $(".messager-window").bgIframe();
        }

        function changePwd() {
            $("#contentFrame").attr("src", "pages/ChangePassword/ChangePassword.aspx");
        }
    </script>
    <style type="text/css">
        *
        {
            margin: 0;
            padding: 0;
            font-family: 宋体;
            font-size: 12px;
        }
        li li
        {
            background: RGB(233, 238, 244);
        }
        .sf-menu li a, .sf-menu li a:visited
        {
            color: #efefef;
        }
        .sf-menu li li a, .sf-menu li li a:visited
        {
            color: #333;
        }
        .sf-menu li:hover, .sf-menu li.sfHover, .sf-menu a:focus, .sf-menu a:hover, .sf-menu a:active
        {
            background: url( 'Images/banner2.png' );
            background-repeat: repeat-x;
            outline: 0;
            color: #fff;
        }
        .aa
        {
            color: #000;
            text-decoration: none;
        }
        .aa:hover
        {
            color: #00f;
            text-decoration: underline;
        }
        .sf-menu:first-child>li:first-child>a:first-child
        {
            border: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table id="tb1" cellspacing="0" border="0" cellpadding="0" style="width: 1024px;">
        <tr style="background-image: url('images/top.png');">
            <td nowrap="nowrap" style="height: 80px; overflow: hidden; vertical-align: top;">
                <div style="float: right; padding-right: 3px; padding-left: 3px; margin-top: 3px;
                    padding-top: 3px; height: 25px; background-color: RGBA(217,2234,249,0.5);">
                    <a href="#" class="aa" onclick="sf('pages/main/index.htm',null)">
                        <img src="Images/home.png" style="margin: 3px 1px; border: 0; height: 14px; width: 14px;
                            margin-bottom: -2px;" alt="首页" />首页</a><span style="color: #000; margin: 2px;">|</span><a
                                href="#" onclick="changePwd()" class="aa">修改密码</a><span style="color: #000; margin: 2px;">|</span><a
                                    href="#" onclick="logout()" class="aa">注销</a>
                </div>
            </td>
        </tr>
        <tr style="height: 30px; vertical-align: bottom; background-image: url('Images/banner2.png');
            background-repeat: repeat-x;">
            <td>
                <ul class="sf-menu">
                    <li><a href="#" onclick="sf('pages/main/index.htm',null)">首页</a></li>
                    <%=OutPutMenu()%>
                </ul>
                <span style="float: right; margin-top: 8px; font-size: 13px; color: #efefef;">
                    <asp:Literal ID="txtWelcome" runat="server" Text="您好，管理员！"></asp:Literal>&nbsp;
                </span>
            </td>
        </tr>
        <tr>
            <td style="height: 100%;" valign="top">
                <iframe id="contentFrame" width="100%" src="pages/main/index.htm" frameborder="0"
                    runat="server" scrolling="no" height="100%"></iframe>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
