var oTable;
var idField = "ID";
/*************
用于列表页的常用js,比如激活会员 页
*************/
function toDate(str) {
    if (str != '') {
        var sd = str.substring(0, 10).split("-");
        return new Date(sd[0], sd[1], sd[2]);
    } else {
        return str;
    }
}
$(document).ready(function () {
    if (undefined != typeof (isPage)) {
        oTable = initTable();
    }
});

/**
* 表格初始化
* returns {*|jQuery}
*/
function initTable() {
    if (isPage == false) {
        var table = $("#datatable").DataTable({
            //bFilter: true,
            dom: '<f<t>>',
            searching: false,
            ordering: false,
            bAutoWidth: false,
            lengthMenu: [999999, 25, 50, "All"],
            //serverSide: true,
            //sPaginationType: "full_numbers", //详细分页组，可以支持直接跳转到某页
            language: {
                url: '/Content/DataTables/zh-CN.json'//汉化
            },
            ajax: {
                url: dataSource,
                type: 'post',
                data: searchData
            },   //异步加载数据           
            columns: columns,
            initComplete: function (settings, json) {
                if (json.exdata != null) {
                    try {
                        if (typeof exdata == 'function') {
                            exdata(json.exdata);
                        }
                    } catch (e) { }

                }
            }
        });
        return table;
    } else {
        var table = $("#datatable").DataTable({
            bFilter: false,
            dom: '<f<t>lp>',
            searching: false,
            ordering: false,
            bAutoWidth: false,
            serverSide: true,
            sPaginationType: "full_numbers", //详细分页组，可以支持直接跳转到某页
            language: {
                url: '/Content/DataTables/zh-CN.json'//汉化
            },
            ajax: {
                url: dataSource,
                type: 'post',
                data: searchData
            },   //异步加载数据
            columnDefs: [
                { "searchable": false, "targets": 0 },//第一列禁用搜索
                { "orderable": false, "targets": 0 }, //第一列禁用排序
            ],
            columns: columns,
            initComplete: function (settings, json) {
                if (json.exdata != null) {
                    try {
                        if (typeof exdata == 'function') {
                            exdata(json.exdata);
                        }
                    } catch (e) { }
                }
                //$("a[name='Restore']").css("visibility", $("#IsRestore").val());
            }
        });
        return table;
    }
}

$(document).ready(function () {
    ////权限验证控制按钮
    //PermissionsLoad(url, roleid);
    //if (ismember == 'True') {
    //    getMyMsg(id);
    //}
    //$('.sidebar-option').change()
    ////表格全选/反选
    //$("#checkAll").on("click", function () {
    //    $("input[name='checkList']").prop("checked", this.checked);
    //});
    //$(".form-horizontal").Validform({
    //    tiptype: 2
    //});
    document.onkeydown = function (event) {
        var e = event ? event : (window.event ? window.event : null);
        if (e.keyCode == 13) {
            //回车提交
            if (SearchList && typeof (SearchList) == "function") {
                SearchList();
                return false;
            }
        }
    }
});

function refreshcache() {
    $.post("/Ajax/RefreshCache", {}, function () {
        alert("刷新缓存完成");
    })
}

//前台权限设置
function PermissionsLoad(url, roleid) {
    $("#add").css("display", "none");
    $("#delete").css("display", "none");
    $("#Edit").css("visibility", "hidden");
    $("#backup").css("display", "none");
    $("#clear").css("display", "none");
    $("#Restore").css("visibility", "hidden");
    $.post("/Ajax/PermissionsLoad", { url: url, roleid: roleid }, function (d) {
        $("#add").css("display", d.IsAdd);
        $("#delete").css("display", d.IsDelete);
        $("#Edit").css("visibility", d.IsEdit);
        $("#backup").css("display", d.IsBackup);
        $("#clear").css("display", d.IsClear);
        $("#Restore").css("visibility", d.IsRestore);
    })
}

//双击禁用
function disabled(formId) {
    $("form[id='" + formId + "'] :text").attr("disabled", "enable");
    $("form[id='" + formId + "'] textarea").attr("disabled", "enable");
    $("form[id='" + formId + "'] :submit").attr("disabled", "enable");
    $("form[id='" + formId + "'] select").attr("disabled", "enable");
    $("form[id='" + formId + "'] :radio").attr("disabled", "enable");
    $("form[id='" + formId + "'] :checkbox").attr("disabled", "enable");
    $("form[id='" + formId + "'] :password").attr("disabled", "enable");
    $("#SubSave").attr("disabled", "enable");
    $("#ChildSave").attr("disabled", "enable");
}
//获取字符串
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

/**
* 删除（可复制）
* param id
* private
*/
function _deleteFun(id) {
    var url = window.location.href.split("?")[0].toLowerCase();
    if (url.lastIndexOf("/index") > 0) {
        url = url.substring(0, url.indexOf("/index"));
    }
    url = url + "/Delete";

    confirm("删除确认!", "删除记录后不可恢复，您确定吗？", function () {
        $.ajax({
            url: url,
            data: { idList: id },
            type: "post",
            success: function (backdata) {
                if (backdata.Status == "y") {
                    alert("操作提示", backdata.Msg);
                } else {
                    alertError("错误提示", backdata.Msg);
                }
                $("#checkAll").prop("checked", false);
                oTable.ajax.reload(null, false);
            }, error: function (error) {
                alert("提示", "删除失败，系统错误");
            }
        });
    })
}

/**
* 批量删除（可复制）
* param id list
* private
*/
function _deleteList() {
    var str = "";
    $("input[name='checkList']:checked").each(function (i, o) {
        str += $(this).val();
        str += ",";
    });
    if (str.length > 0) {
        var IDS = str.substr(0, str.length - 1);
        _deleteFun(IDS);
    } else {
        alert("操作提示", "至少选择一条记录操作");
    }
}

function getMyMsg(id) {
    $.post("/Ajax/getMyMsg", { id: id }, function (d) {
        var x = d.indexOf('_');
        var count = d.substring(0, x);
        var text = d.substring(x + 1);
        $("#lab_MyMsg_Count1").html(count);
        $("#lab_MyMsg_Count2").html(count);
        $("#ul_MyMsg").html(text);
    })
}

function getSelect() {
    var str = "";
    $("input[name='checkList']:checked").each(function (i, o) {
        str += $(this).val();
        str += ",";
    });
    if (str.length > 0) {
        var IDS = str.substr(0, str.length - 1);
        return IDS;
    } else {
        alert("操作提示", "至少选择一条记录操作");
    }
    return "";
}
function myAlert(d) {
    if (d.Status == "y") {
        alert("成功提示", d.Msg);
    } else {
        alertError("错误提示", d.Msg);
    }
}

function SearchList() {

    oTable.ajax.reload(function (json) {
        if (json.exdata != null) {
            try {
                if (typeof exdata == 'function') {
                    exdata(json.exdata);
                }
            } catch (e) { }
        }
    }, false);
}

function ToExcelFile(url, searchdata) {
    var url = url + "?" + $.param(searchdata);
    $('<form  method="post" action="' + url + '"></form>').appendTo('body').submit().remove();
}