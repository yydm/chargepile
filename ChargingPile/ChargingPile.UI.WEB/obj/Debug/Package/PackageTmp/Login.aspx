<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ChargingPile.UI.WEB.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>充电桩在线监测系统</title>
    <script src="Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            var h = $(window).height() > 600 ? $(window).height() : 600;
            $("#tm").css("margin-top", (h - 288) / 2).css("margin-bottom", (h - 288) / 2);
            $("body").height(h);
            $(window).resize(function () {
                h = $(window).height() > 600 ? $(window).height() : 600;
                $("#tm").css("margin-top", (h - 288) / 2).css("margin-bottom", (h - 288) / 2);
                $("body").height(h);
            });
            $("#txt_user").focus();
        });

        if (window != window.top) {
            window.top.location.href = window.location.href;
        }

        function cancel() {
            $("#txt_user").val("");
            $("#txt_password").val("");
            return false;
        }

        function login() {
            var name = $("#txt_user").val();
            var pwd = $("#txt_password").val();
            if (name.length == 0) {
                alert("用户名不能为空。");
                $("#txt_user").focus();
                return false;
            }
            if (pwd.length == 0) {
                alert("密码不能为空。");
                $("#txt_password").focus();
                return false;
            }
            $.ajax({
                url: "WebService/PasswordService.ashx",
                type: "POST",
                data: { action: "login", name: name, pwd: pwd, r: Math.random() },
                success: function (data) {
                    if (data == 1) {
                        location.href = "Default.aspx";
                    } else {
                        alert("用户名或密码错误！");
                        $("#txt_password").val("").focus();
                    }
                }
            });
            return false;
        }
    </script>
    <style type="text/css">
        *
        {
            margin: 0;
            padding: 0;
        }
    </style>
</head>
<body style="background-color: rgb(99,215,238); width: 100%; height: 100%; overflow: auto;">
    <form id="form1" runat="server">
    <table id="tm" style="width: 100%; height: 258px;">
        <tr>
            <td style="text-align: center;">
                <table style="width: 630px; height: 258px; background-image: url(Images/login.png);
                    background-position: center; margin: 0 auto;">
                    <tr>
                        <td>
                            <div style="position: relative; left: 159px; top: -20px;">
                                <asp:TextBox ID="txt_user" runat="server" Width="155px" Style="background-color: transparent;
                                    line-height: 21px; border: #777 1px solid; height: 23px; width: 160px;"></asp:TextBox>
                            </div>
                            <div style="position: relative; left: 159px; top: 0px;">
                                <asp:TextBox ID="txt_password" runat="server" TextMode="password" Width="155px" Style="background-color: transparent;
                                    line-height: 21px; border: #777 1px solid; height: 23px; width: 160px;"></asp:TextBox>
                            </div>
                            <div style="position: relative; left: 176px; top: 23px;">
                                <asp:ImageButton ID="btnLogin" runat="server" ImageUrl="Images/btn_ok.png" OnClientClick="return login()" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
