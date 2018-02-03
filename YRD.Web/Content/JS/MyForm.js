$(document).ready(function () {
    $("#commentForm").Validform({
        tiptype: 3
    });
});
//增删改提交ajax
var SubAjax = {
    Loading: function () {
        $("#SubSave").attr("disabled", true).find("span").html("正在保存中...");
        if (typeof AjaxVaild == 'function') {
            var result = AjaxVaild();
            if (result) {
                return true;
            } else {
                $("#SubSave").attr("disabled", false).find("span").html("保 存")
                return false;
            }
        }
        return true;
    },
    Success: function (result) {
        SubAjax.Complete();
        if (result.Code == 1) {
            alert("操作提示", result.Message, function () {
                //如果返回结果中有 跳转url,操作成功则跳转
                if (result.Url != '' && result.Url != null) {
                    location.href = result.Url;
                }
            });
            if ("undefined" != typeof (oTable)) {
                oTable.ajax.reload()
            }
        } else if (result.Code == -200) {
            alert("操作提示", result.Message, function () {
                //如果返回结果中有 跳转url,操作成功则跳转
                if (result.Url != '' && result.Url != null) {
                    location.href = result.Url;
                }
            });
        } else {
            alertError("错误提示", result.Message);
        }
    },
    SuccessBack: function (result) {
        if (result.Code == 1) {
            alert("提示", result.Message, function () {
                history.go(-1);
            });
        } else if (result.Code == -200) {
            alert("操作提示", result.Message, function () {
                //如果返回结果中有 跳转url,操作成功则跳转
                if (result.Url != '' && result.Url != null) {
                    location.href = result.Url;
                }
            });
        }
        else {
            alertError("错误提示", result.Message);
            SubAjax.Complete();
        }
    },
    Failure: function (e) {
        alertError("错误提示", "网络超时,请稍后再试...");
        SubAjax.Complete();
    },
    Complete: function () {
        $("#SubSave").attr("disabled", false).find("span").html("保 存")
    }
};