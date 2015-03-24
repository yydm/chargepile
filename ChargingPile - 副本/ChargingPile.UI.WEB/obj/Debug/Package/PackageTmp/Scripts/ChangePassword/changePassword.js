var myurl;
var mydata;
var mytype = "POST";
var jsonType = "html";
var commonType = "application/json; charset=utf-8";
$(function () {
    $.extend($.fn.validatebox.defaults.rules, {
        equals: {
            validator: function (value, param) {
                return value == $(param[0]).val();
            },
            message: '两次输入的密码不一致！'
        }
    });


});
function btnClear_click() {
    $("#txtPass").val("");
    $("#txtNewPass").val("");
    $("#txtNewPass2").val("");
}


function btnAdd_click() {
    var valid1 = $("#txtPass").validatebox("isValid");
    var valid2 = $("#txtNewPass").validatebox("isValid");
    var valid3 = $("#txtNewPass2").validatebox("isValid");
    if (!valid1 || !valid2 || !valid3)
        return false;
    //var name = $("#txtName").val();
    var worknum = $("#txtWorkNum").val();
    var pass = $("#txtPass").val();
    var newpass = $("#txtNewPass").val();
    var newpass2 = $("#txtNewPass2").val();
    myurl = "../../WebService/PasswordService.ashx";
    mydata = { action: "modifypass", worknum: worknum, pass: pass, newpass: newpass, newpass2: newpass2 };
    saveData();

    return true;
}


//保存数据
function saveData() {
    var value;
    $.ajax({
        url: myurl,
        type: mytype,
        async: false,
        data: mydata,
        success: function (data) {
            value = data;
            switch (value) {
                case "true":
                    $.messager.alert("提示", "保存成功！");
                    btnClear_click();
                    break;
                case "false":
                    $.messager.alert("提示", "保存失败！");
                    btnClear_click();
                    break;
                case "falsepwd":
                    $.messager.alert("提示", "原密码错误！");
                    btnClear_click();
                    break;
                default: btnClear_click();
            }
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            $.messager.alert("提示", "error");
        }
    });
    switch (value) {
        case "true":
            return true;
        case "false":
            return false;
        default:
            return false;
    }
}