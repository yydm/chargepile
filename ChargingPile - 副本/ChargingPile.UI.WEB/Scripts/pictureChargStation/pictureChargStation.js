var myurl;
var mydata;
var mytype = "POST";
var jsonType = "json";
var htmlType = "html";
var commonType = "application/json; charset=utf-8";
var editIndex = undefined;
var zhanbh;

//--------------------------------------------------------------
$(function () {
    initcoolcarousel();
    zhanbh = getQueryString("zhanbh");
    bindChargStation();
    $("#chargstation").val(zhanbh);
    //getChargStationPicture();
    chargstation_onchanged();

    $("#wrapper").css("position", "absolute");
    $(window).resize(function () {
        if ($(window).width() > 1020) {
            $("#wrapper").css("left", "24%");
        } else {
            $("#wrapper").removeAttr("style");
        }
        $(".pic-content").css("position", "relative");
        $("#wrapper").css("position", "absolute");
    });
});

function initcoolcarousel() {
    $('#images').carouFredSel({
        circular: false,
        auto: false,
        width: 'auto',
        height: 'auto',
        items: {
            visible: 1
        },
        scroll: {
            fx: 'directscroll'
        }
    });
    $('#thumbs').carouFredSel({
        circular: false,
        infinite: false,
        auto: false,
        width: 770,
        items: {
            visible: 7
        },
        prev: '#prev',
        next: '#next',
        pagination: "#foo2_pag"
    });

    $('#thumbs img').click(function () {
        $('#images').trigger('slideTo', "#" + this.alt);
        $('#thumbs img').removeClass('selected');
        $(this).addClass('selected');
        return false;
    });
    $('#thumbs img:eq(0)').addClass('selected');
}

function bindChargStation() {

    myurl = "../../WebService/PictureChargStationService.ashx";
    mydata = { action: 'getChargStation' };
    var data = getDatas();
    $("#chargstation").empty();
    var length = data.rows.length;
    $("#chargstation").append("<option value='0'>—请选择—</option>");
    if (length == 0) {
        return;
    }
    for (var i = 0; i < length; i++) {
        $("#chargstation").append("<option value='" + data.rows[i].ZHAN_BH + "'>" + data.rows[i].ZHUAN_MC + "</option>");
    }
}


function getChargStationPicture() {
    myurl = "../../WebService/PictureChargStationService.ashx";
    mydata = { action: 'getChargStationFile', id: $("#chargstation option:selected").val() };
    var data = getDatas();
    for (var k = 0; k <= count; k++) {
        $("#images").trigger("removeItem", 0);
        $("#thumbs").trigger("removeItem", 0);
    }
    var imagesHtml = "", thumbsHtml = "";
    if (!data || data == "empty" || data.Rows.length == 0) {
        imagesHtml += "<img id='non-img' src='../../images/noimage.png' alt='non-img' width='450' height='450' />";
        thumbsHtml += "<img src='../../images/noimage.png' alt='non-img' width='70' height='70' />";
    }
    else {
        for (var i = 0; i < data.Rows.length; i++) {
            imagesHtml += "<img id='img_" + i + "' alt='img_" + i + "'/>";
            thumbsHtml += "<img id='" + i + "_img' alt='img_" + i + "' width='70' height='70' />";
        }
    }
    count = data.Rows.length;
    $("#images").trigger("insertItem", imagesHtml);
    $("#thumbs").trigger("insertItem", thumbsHtml);
    for (var j = 0; j < data.Rows.length; j++) {
        $("#img_" + j).attr("src", "../../Scripts/pictureChargStation/SaveChargeStationFile/" + data.Rows[j].Id + "." + data.Rows[j].FileMime);
        var w = data.Rows[j].Width;
        var h = data.Rows[j].Height;
        var hw = 450;
        var ptop = 0;
        if (w >= h) {
            h = (h * hw) / w;
            w = hw;
            ptop = (hw - h) / 2;
        } else {
            w = (w * hw) / h;
            h = hw;
        }
        $("#img_" + j).attr("width", w).attr("height", h).css("padding-top", ptop);
        $("#" + j + "_img").attr("src", $("#img_" + j).attr("src"));
    }
    initcoolcarousel();
}


//----------------------------------------------------------------------------------------------------
var count = 0;
function chargstation_onchanged() {

    myurl = "../../WebService/PictureChargStationService.ashx";
    mydata = { action: 'getAddress', id: $("#chargstation option:selected").val() };
    var data = getDatas();
    if (data.rows.length == 0) {
        $("#csaddress").val("");
        $("#cscount").val("");
        return false;
    }
    $("#csaddress").val(data.rows[0].XIANGXI_DZ);
    //mydata = { action: 'getChargPileCount', id: $("#chargstation option:selected").val() };
    mydata = { action: 'getCoordinates', id: $("#chargstation option:selected").val() };
    data = getDatas();
    $("#jd").val(data.rows[0].LONGTUDE);
    $("#wd").val(data.rows[0].LATITUDE);
    getChargStationPicture();

    return true;
}


//----------------------------------------------------------------------------------------------------

function getDatas() {
    var value;
    $.ajax({
        url: myurl,
        type: mytype,
        async: false,
        data: mydata,
        dataType: htmlType,
        success: function (data) {
            if (data) {
                var val = "";
                var ret = data.split("|")[0];
                eval("val=" + ret);
                var res = data.split("|")[1];
                if (ret == "0") {
                    value = "0";
                } else {
                    value = val;
                }
            }
        },
        error: function () {
            $.messager.alert("提示", "error");
        }
    });
    return value;
}


/*
* 获取url参数值
*/
function getQueryString(name) {
    var url = location.href;
    var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
    var paraObj = {};
    for (var i = 0; j = paraString[i]; i++) {
        paraObj[j.substring(0, j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=") + 1, j.length);
    }
    var returnValue = paraObj[name.toLowerCase()];
    if (typeof (returnValue) == "undefined") {
        return "";
    } else {
        return returnValue;
    }
}



