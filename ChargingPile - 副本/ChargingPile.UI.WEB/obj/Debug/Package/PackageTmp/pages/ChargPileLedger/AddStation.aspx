<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStation.aspx.cs" Inherits="ChargingPile.UI.WEB.pages.ChargPileLedger.AddStation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>充电站基本信息编辑框</title>
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="expires" content="0" />
    <link rel="stylesheet" type="text/css" href="../../Scripts/jquery-easyui-1.3.1/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../../Scripts/jquery-easyui-1.3.1/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="../../Scripts/ZTree/css/zTreeStyle/zTreeStyle.css" />
    <script src="../../Scripts/jquery-easyui-1.3.1/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-easyui-1.3.1/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-easyui-1.3.1/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-easyui-1.3.1/easyui-validate.js" type="text/javascript"></script>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../../Scripts/ZTree/js/jquery.ztree.core-3.5.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Scripts/ZTree/js/jquery.ztree.excheck-3.5.js"></script>
    <script type="text/javascript" src="../../Scripts/ZTree/js/jquery.ztree.exedit-3.5.js"></script>
    <script src="../../Scripts/jquery-easyui-1.3.1/jquery.form.js" type="text/javascript"></script>
    <script src="../../Scripts/chargpilemanger/AddStation.js" type="text/javascript"></script>
    <style type="text/css">
        .textright
        {
            width: 100px;
            text-align: right;
        }
        *
        {
            margin:0;
            padding:0;
            font-size: 12px;
        }
    </style>
</head>
<body class="easyui-layout">
    <div data-options="region:'center',title:'充电场站信息编辑'">
        <div id="dlg" style="width: 700px;  margin: 0 auto; margin-top:15px;margin-left:160px; height: 500px;" >
            <form action="" id="fm" method="post" runat="server">
            <table cellpadding="3" cellspacing="0" width="100%" style="font-size: 12px; border: 0;
                overflow: hidden;">
                <tr style="height: 28px" id="typeid">
                    <td style="width: 100px" class="textright">
                        充电场站名称：
                    </td>
                    <td class="textbox_b">
                        <asp:TextBox runat="server" ID="ZhuanMc" Style="width: 200px" class="easyui-validatebox"
                            required="true" validtype="maxLength[32]" onkeydown="if(event.keyCode==32) return false"></asp:TextBox>
                            <span style=" color:Red;">*</span>
                    </td>
                </tr>
                <tr style="height: 28px" id="Tr1">
                    <td style="width: 100px" class="textright">
                        充电场站简称：
                    </td>
                    <td class="textbox_b">
                        <asp:TextBox runat="server" ID="zhanjc" Style="width: 200px" class="easyui-validatebox"
                            required="true" validtype="maxLength[32]" onkeydown="if(event.keyCode==32) return false"></asp:TextBox>
                            <span style=" color:Red;">*</span>
                    </td>
                </tr>
                <tr style="height: 28px">
                    <td style="width: 100px" class="textright">
                        详细地址：
                    </td>
                    <td class="textbox_b">
                        <asp:TextBox runat="server" ID="XiangXiDz" Style="width: 200px" class="easyui-validatebox"
                            required="true" validtype="maxLength[32]" onkeydown="if(event.keyCode==32) return false"></asp:TextBox>
                            <span style=" color:Red;">*</span>
                    </td>
                </tr>
                <tr style="height: 28px">
                    <td style="width: 100px" class="textright">
                        经度：
                    </td>
                    <td class="textbox_b">
                        <asp:TextBox runat="server" ID="Longtude" Style="width: 200px" class="easyui-validatebox"
                            required="true" validtype="maxLength[32]" onkeydown="if(event.keyCode==32) return false"></asp:TextBox>
                            <span style=" color:Red;">*</span>
                    </td>
                </tr>
                <tr style="height: 28px">
                    <td style="width: 100px" class="textright">
                        纬度：
                    </td>
                    <td class="textbox_b">
                        <asp:TextBox runat="server" ID="Latitude" Style="width: 200px" class="easyui-validatebox"
                            required="true" validtype="maxLength[32]" onkeydown="if(event.keyCode==32) return false"></asp:TextBox>
                            <span style=" color:Red;">*</span>
                    </td>
                </tr>
                <tr style="height: 28px">
                    <td style="width: 100px" class="textright">
                        场地业主单位：
                    </td>
                    <td class="textbox_b">
                        <asp:TextBox runat="server" ID="YeZhuDw" Style="width: 200px" class="easyui-validatebox"
                            required="true" validtype="maxLength[32]" onkeydown="if(event.keyCode==32) return false"></asp:TextBox>
                            <span style=" color:Red;">*</span>
                    </td>
                </tr>
                <tr style="height: 28px">
                    <td style="width: 100px" class="textright">
                        场地业主联系人：
                    </td>
                    <td class="textbox_b">
                        <asp:TextBox runat="server" ID="LianXiR" Style="width: 200px" class="easyui-validatebox"
                            required="true" validtype="maxLength[32]" onkeydown="if(event.keyCode==32) return false"></asp:TextBox>
                            <span style=" color:Red;">*</span>
                    </td>
                </tr>
                <tr style="height: 28px">
                    <td style="width: 110px" class="textright">
                        场地业主联系电话：
                    </td>
                    <td class="textbox_b">
                        <asp:TextBox runat="server" ID="LianXiDh" Style="width: 200px" class="easyui-validatebox"
                            required="true" validtype="maxLength[32]" onchange="DHchange()" onkeydown="if(event.keyCode==32) return false"></asp:TextBox>
                            <span style=" color:Red;">*</span>
                    </td>
                </tr>
                <tr style="height: 28px">
                    <td style="width: 100px" class="textright">
                        分支箱数量：
                    </td>
                    <td class="textbox_b">
                        <asp:DropDownList ID="BoxCounts" runat="server" Style="width: 203px">
                            <asp:ListItem Value="" Text="—请选择—"></asp:ListItem>
                            <asp:ListItem Value="1" Text="1"></asp:ListItem>
                            <asp:ListItem Value="2" Text="2"></asp:ListItem>
                            <asp:ListItem Value="3" Text="3"></asp:ListItem>
                            <asp:ListItem Value="4" Text="4"></asp:ListItem>
                            <asp:ListItem Value="5" Text="5"></asp:ListItem>
                            <asp:ListItem Value="6" Text="6"></asp:ListItem>
                            <asp:ListItem Value="7" Text="7"></asp:ListItem>
                            <asp:ListItem Value="8" Text="8"></asp:ListItem>
                            <asp:ListItem Value="9" Text="9"></asp:ListItem>
                            <asp:ListItem Value="10" Text="10"></asp:ListItem>
                        </asp:DropDownList>
                        <span style=" color:Red;">*</span>
                    </td>
                </tr>
                <tr style="height: 28px">
                    <td style="width: 100px" class="textright">
                        建站时间：
                    </td>
                    <td class="textbox_b">
                        <asp:TextBox runat="server" placeholder=" —请选择— " ID="JianZhan_SJ" Style="width: 200px"
                            required="true" validtype="maxLength[32]" class="Wdate" onfocus="WdatePicker({isShowClear:false,readOnly:true,dateFmt:'yyyy-MM-dd',startDate:'%y-%M-%d',maxDate:'#F{$dp.$D(\'TouYun_Sj\')||\'%y-%M-%d\'}'})"></asp:TextBox>
                        <span style=" color:Red;">*</span>
                    </td>
                </tr>
                <tr style="height: 28px">
                    <td style="width: 100px" class="textright">
                        投运时间：
                    </td>
                    <td class="textbox_b">
                        <asp:TextBox runat="server" ID="TouYun_Sj" placeholder=" —请选择— " Style="width: 200px"
                            required="true" validtype="maxLength[32]" class="Wdate" onfocus="WdatePicker({isShowClear:false,readOnly:true,dateFmt:'yyyy-MM-dd',minDate:'#F{$dp.$D(\'JianZhan_SJ\')}',maxDate:'%y-%M-%d',startDate:'%y-%M-%d'})"></asp:TextBox>
                        <span style=" color:Red;">*</span>
                    </td>
                </tr>
                <tr style="height: 28px">
                    <td style="width: 110px" class="textright">
                        充电场站实景照片：
                    </td>
                    <td class="textbox_b">
                        <div>
                        <input type="hidden" id="h_guid" name="h_guid" value="<% = guidString %>" />
                            <asp:FileUpload ID="upImage" runat="server" Width="200px" />
                            <asp:Button ID="btnAdd" runat="server" Text="上传图片" OnClick="btnAdd_Click" />
                            <asp:Label ID="Label1" runat="server" ForeColor="Red" >注：图片不能大于5M,格式支持gif,png,jpg,jpeg</asp:Label>
                            <hr style=" margin-top:5px;" />
                            <%--<asp:DataList ID="dlstImages" runat="server" RepeatColumns="3" Width="500px">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" Width="50px" ImageUrl='<%# Eval("Name", "~/UpImages/{0}") %>' />
                                    <br />
                                    <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("Name") %>'></asp:Literal>
                                    <asp:LinkButton runat="server" ID="del" plain="true" class="easyui-linkbutton" OnClientClick="delImg(this)"
                                        iconcls="icon-cancel" title="删除"></asp:LinkButton>
                                    <br />
                                    <br />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:DataList>--%>
                            <div id="thumbs" style=" margin-top:5px;">
                            <%=GetNewImg()%>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
            <br />
            <div id="dlg-buttons" style=" margin-left:120px;">
                <a href="#" class="easyui-linkbutton" onclick="back()" iconcls="icon-pre">上一步</a>
                <asp:LinkButton runat="server" ID="save" OnClientClick="return save()" OnClick="save_Click" class="easyui-linkbutton" 
                    iconcls="icon-next">下一步</asp:LinkButton>
                
            </div>
            </form>
        </div>
    </div>
</body>
</html>
