function InvokeWarn(targetDev, dataItemId, workNum) {
    var req = {
        type: "DataGatherRpc",
        method: "ManBreakWarn",
        scope: 'Singleton',
        args: [targetDev, dataItemId, workNum]
    };
    var p_url = MJUrl;
    $.ajax({
        type: "POST",
        url: p_url,
        data: JSON2.stringify(req),
        success: function (resp) {
            if (!resp.success) {
                //操作失败回调函数,这个函数在调用界面根据具体情况写，
                invokeWarn_return_error(resp);
            } else {
                invokeWarn_return_success(resp);
            }
        },
        error: function (xhr) {
            invokeWarn_error(xhr, p_url);
        }
    });
}
function InvokeWarn2(targetDev, dataItemId, workNum, warntype) {
    var req = {
        type: "DataGatherRpc",
        method: "ManBreakWarn",
        scope: 'Singleton',
        args: [targetDev, dataItemId, workNum]
    };
    var p_url = MJUrl;

    $.ajax({
        type: "POST",
        url: p_url,
        data: JSON2.stringify(req),
        success: function (resp) {
            if (!resp.success) {
                //操作失败回调函数,这个函数在调用界面根据具体情况写，
                invokeWarn_return_error(resp, warntype);
            } else {
                invokeWarn_return_success(resp, warntype);
            }
        },
        error: function (xhr) {
            invokeWarn_error(xhr, p_url);
        }
    });

}

