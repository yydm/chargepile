<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditStation.aspx.cs" Inherits="ChargingPile.UI.WEB.pages.ChargPileLedger.EditStation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>充电站台账编辑</title>
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="expires" content="0" />
    <!--验证session是否过期-->
    <script type="text/javascript" src="../../WebService/Common.ashx?action=isoverdue"></script>
    <link rel="stylesheet" type="text/css" href="../../Scripts/jquery-easyui-1.3.1/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../../Scripts/jquery-easyui-1.3.1/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="../../Scripts/ZTree/css/zTreeStyle/zTreeStyle.css" />
    <script src="../../Scripts/jquery-easyui-1.3.1/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-easyui-1.3.1/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-easyui-1.3.1/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-easyui-1.3.1/easyui-validate.js" type="text/javascript"></script>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../../Scripts/ZTree/js/jquery.ztree.core-3.5.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-easyui-1.3.1/jquery.form.js" type="text/javascript"></script>
    <script src="../../Scripts/chargpilemanger/EditStation.js" type="text/javascript"></script>
    <style type="text/css">
        .textright
        {
            width: 100px;
            text-align: right;
        }
        *
        {
            margin: 0;
            padding: 0;
            font-size: 12px;
        }
        div#rMenu
        {
            position: absolute;
            visibility: hidden;
            top: 0;
            background-color: #555;
            text-align: left;
            padding: 2px;
        }
        
        div#rMenu ul li
        {
            margin: 1px 0;
            padding: 0 5px;
            cursor: pointer;
            list-style: none outside none;
            background-color: #DFDFDF;
        }
    </style>
</head>
<body>
    <input id="h_rightNodeID" type="hidden" runat="server" />
    <!--充电站编辑框-->
    <div id="dlg" style="width: 700px; margin: 0 auto; margin-top:10px; height: 600px; overflow: auto;" buttons="#dlg-buttons">
        <form action="" id="fm" method="post" runat="server">
        <table cellpadding="4" cellspacing="1" width="100%" style="border: 0; overflow: auto;"
            class="detailtable">
            <tr style="height: 28px" id="Tr5">
                <td style="width: 100px" class="textright">
                    充电场站名称：
                </td>
                <td class="textbox_b">
                    <asp:TextBox runat="server" ID="d_ZhuanMc" Style="width: 200px" class="easyui-validatebox"
                        required="true" validtype="maxLength[32]" onkeydown="if(event.keyCode==32) return false"></asp:TextBox>
                        <span style=" color:Red;">*</span>
                </td>
            </tr>
            <tr style="height: 28px" id="Tr1">
                <td style="width: 100px" class="textright">
                    充电场站简称：
                </td>
                <td class="textbox_b">
                    <asp:TextBox runat="server" ID="d_zhanjc" Style="width: 200px" class="easyui-validatebox"
                        required="true" validtype="maxLength[32]" onkeydown="if(event.keyCode==32) return false"></asp:TextBox>
                        <span style=" color:Red;">*</span>
                </td>
            </tr>
            <tr style="height: 28px">
                <td style="width: 100px" class="textright">
                    详细地址：
                </td>
                <td class="textbox_b">
                    <asp:TextBox runat="server" ID="d_XiangXiDz" Style="width: 200px" class="easyui-validatebox"
                        required="true" validtype="maxLength[32]" onkeydown="if(event.keyCode==32) return false"></asp:TextBox>
                        <span style=" color:Red;">*</span>
                </td>
            </tr>
            <tr style="height: 28px">
                <td style="width: 100px" class="textright">
                    经度：
                </td>
                <td class="textbox_b">
                    <asp:TextBox runat="server" ID="d_Longtude" Style="width: 200px" class="easyui-validatebox"
                        required="true" validtype="intOrFloat" onkeydown="if(event.keyCode==32) return false"></asp:TextBox>
                        <span style=" color:Red;">*</span>
                </td>
            </tr>
            <tr style="height: 28px">
                <td style="width: 100px" class="textright">
                    纬度：
                </td>
                <td class="textbox_b">
                    <asp:TextBox runat="server" ID="d_Latitude" Style="width: 200px" class="easyui-validatebox"
                        required="true" validtype="intOrFloat" onkeydown="if(event.keyCode==32) return false"></asp:TextBox>
                        <span style=" color:Red;">*</span>
                </td>
            </tr>
            <tr style="height: 28px">
                <td style="width: 100px" class="textright">
                    场地业主单位：
                </td>
                <td class="textbox_b">
                    <asp:TextBox runat="server" ID="d_YeZhuDw" Style="width: 200px" class="easyui-validatebox"
                        required="true" validtype="maxLength[32]" onkeydown="if(event.keyCode==32) return false"></asp:TextBox>
                        <span style=" color:Red;">*</span>
                </td>
            </tr>
            <tr style="height: 28px">
                <td style="width: 100px" class="textright">
                    场地业主联系人：
                </td>
                <td class="textbox_b">
                    <asp:TextBox runat="server" ID="d_LianXiR" Style="width: 200px" class="easyui-validatebox"
                        required="true" validtype="maxLength[32]" onkeydown="if(event.keyCode==32) return false"></asp:TextBox>
                        <span style=" color:Red;">*</span>
                </td>
            </tr>
            <tr style="height: 28px">
                <td style="width: 110px" class="textright">
                    场地业主联系电话：
                </td>
                <td class="textbox_b">
                    <asp:TextBox runat="server" ID="d_LianXiDh" Style="width: 200px" class="easyui-validatebox"
                        required="true" validtype="maxLength[32]" onchange="DHchange()" onkeydown="if(event.keyCode==32) return false"></asp:TextBox>
                        <span style=" color:Red;">*</span>
                </td>
            </tr>
            <tr style="height: 28px">
                <td style="width: 100px" class="textright">
                    建站时间：
                </td>
                <td class="textbox_b">
                    <asp:TextBox runat="server" placeholder=" —请选择— " ID="d_JianZhan_SJ" ReadOnly="true"
                        Style="width: 200px" class="Wdate" onclick="WdatePicker({isShowClear:false,dateFmt:'yyyy-MM-dd',startDate:'%y-%M-%d',maxDate:'#F{$dp.$D(\'d_TouYun_Sj\')||\'%y-%M-%d\'}'})"></asp:TextBox>
                    <span style=" color:Red;">*</span>
                </td>
            </tr>
            <tr style="height: 28px">
                <td style="width: 100px" class="textright">
                    投运时间：
                </td>
                <td class="textbox_b">
                    <asp:TextBox runat="server" placeholder=" —请选择— " ID="d_TouYun_Sj" ReadOnly="true"
                        Style="width: 200px" class="Wdate" onclick="WdatePicker({isShowClear:false,dateFmt:'yyyy-MM-dd',minDate:'#F{$dp.$D(\'d_JianZhan_SJ\')}',maxDate:'%y-%M-%d',startDate:'%y-%M-%d'})"></asp:TextBox>
                    <span style=" color:Red;">*</span>
                </td>
            </tr>
            <tr style="height: 28px">
                <td style="width: 100px" class="textright">
                    充电场站实景照片：
                </td>
                <td class="textbox_b">
                    <div>
                        <input type="hidden" id="h_guid" name="h_guid" value="<% = guidString %>" />
                        <input type="hidden" id="h_sign" name="h_sign" value="<% = sign %>" />
                        <asp:FileUpload ID="upImage" runat="server" Width="200px" />
                        <asp:Button ID="btnAdd" runat="server" Text="上传图片" OnClick="btnAdd_Click" />
                        <asp:Label runat="server" ForeColor="Red" >注：图片不能大于5M,格式支持gif,png,jpg,jpeg</asp:Label>
                        <hr style=" margin-top:5px; margin-right:20px;" />
                        <%--<asp:DataList ID="dlstImages" runat="server" RepeatColumns="3" Width="500px">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" Width="50px" ImageUrl='<%# Eval("Name", "~/EditImages/{0}") %>' />
                                    <br />
                                    <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("Name") %>'></asp:Literal>
                                    <asp:LinkButton runat="server" ID="del" plain="true" class="easyui-linkbutton" OnClientClick="delImg(this)"
                                        iconcls="icon-cancel" title="删除"></asp:LinkButton>
                                    <br />
                                    <br />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:DataList>--%>
                        <div id="thumbs" style="vertical-align: top; margin-top:5px; margin-right:20px; width:550px;">
                            <%= GetNewImg()%>
                        </div>
                    </div>
                </td>
            </tr>
            <tr style="height: 28px">
                <td style="width: 110px" class="textright">
                </td>
                <td class="textbox_b" style="margin-top:20px">
                    <asp:LinkButton runat="server" style=" margin-left:125px;" ID="save" OnClientClick="return save();" OnClick="save_Click"
                        class="easyui-linkbutton" iconcls="icon-save">保存</asp:LinkButton>
                </td>
            </tr>
        </table>
        <br />
        <%--<div id="Div9" style="float: right;">
            <asp:LinkButton runat="server" ID="save" OnClientClick="return save();" OnClick="save_Click"
                class="easyui-linkbutton" iconcls="icon-save">保存</asp:LinkButton>
        </div>--%>
        </form>
    </div>
</body>
</html>
