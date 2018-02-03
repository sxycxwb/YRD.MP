/********
 * 表格中操作
 * ********/
/*表格中的分类被选中时，激活'批量删除','绑定员工','绑定打印机','批量下载'按钮*/
var ids = [];
$('table').on('click', 'input[type="checkbox"]', function () {
    var check_length = $('table input[type="checkbox"]:checked').length;
    //当前id号
    var this_id = $(this).parent().parent().parent().next().html();
    if ($(this).parent().hasClass('checked')) {
        ids.push(this_id);
    } else {
        ids.pop(this_id);
    }
    //console.log(ids);
    if (check_length > 0) {
        //批量删除高亮
        $('.pl_delete').prop('disabled', false).addClass('purple').removeClass('grey');
        //绑定员工高亮
        $('.bind_worker').prop('disabled', false).addClass('royellow').removeClass('grey');
        //绑定打印机高亮
        $('.bind_printer').prop('disabled', false).addClass('newblue').removeClass('grey');
        //批量下载高亮
        //$('.pl_download').prop('disabled', false).addClass('blue').removeClass('grey');
        //绑定库房高亮
        $('.bind_warehouse').prop('disabled', false).addClass('guogreen').removeClass('grey');
    } else {
        $('.pl_delete').prop('disabled', true).addClass('grey').removeClass('purple');
        $('.bind_worker').prop('disabled', true).addClass('grey').removeClass('royellow');
        $('.bind_printer').prop('disabled', true).addClass('grey').removeClass('newblue');
        //$('.pl_download').prop('disabled', true).addClass('grey').removeClass('blue');
        $('.bind_warehouse').prop('disabled', true).addClass('grey').removeClass('guogreen');
    }
});
/*第一个复选框选中，后面的都选中*/
$('table>thead').on('click', 'input[type="checkbox"]', function () {
    var ischeck = $(this).prop('checked');
    if (ischeck) {
        $(this).parent('.cb').addClass('cb_check');
        $('table>tbody').find('input').prop('checked', true).parent('.cb').addClass('cb_check');
    } else {
        $(this).parent('.cb').removeClass('cb_check');
        $('table>tbody').find('input').prop('checked', false).parent('.cb').removeClass('cb_check');
    }
});
/*后面复选框选中，第一个选中*/
$('table>tbody').on('click', 'input[type="checkbox"]', function () {
    var ischeck = $(this).prop('checked');
    if (ischeck) {
        $(this).parent('.cb').addClass('cb_check');
    } else {
        $(this).parent('.cb').removeClass('cb_check');
    }
    var alllen = $('table>tbody').find('input[type="checkbox"]').size();
    var checklen = $('table>tbody').find('input[type="checkbox"]:checked').size();
    if (checklen == alllen) {
        $('table>thead').find('input').prop('checked', true).parent('.cb').addClass('cb_check');
    } else {
        $('table>thead').find('input').prop('checked', false).parent('.cb').removeClass('cb_check');
    }
});

/*表格中的操作行的操作*/
$('tbody').on('click', 'tr>td:last-child>a', function (e) {
    if ($(this).attr('href') == '' || $(this).attr("class") == "delete") {  //当href为空时，则不跳转，不为空，跳转
        e.preventDefault();
    }
    var self = this;
    var nowtr = $(this).parent().parent();
    var nowfl = $(this).parent().siblings().find('.fl_name').text();
    //重排序号
    var paixu = function () {
        var tbody = $(self).parent().parent().parent();
        var trlen = tbody.find('tr').size();
        for (var i = 0; i < trlen; i++) {
            tbody.find('tr:eq(' + i + ')').find('.fl_num').text(i + 1);
        }
    };

    if ($(this).hasClass('delete')) {//单个删除
        var table = $(this).attr('data-table');
        var curid = $(this).attr('data-id');
        var title = $(this).attr('data-title');
        var href = $(this).attr("href");
        if (href == '' || href == undefined) {
            href = "/Ajax/Delete";
        }
        //$('.dg_delete_dialog').show().find('.haselect-item').text(nowfl);
        $('.dg_delete_dialog').show().find('.haselect-item').text(title);
        //点击删除按钮,on前先unblind 避免重复绑定事件
        $('.dg_delete_dialog').unbind('click').on('click', '.check_btn', function () {
            $('.dg_delete_dialog').hide();
            if (href == "/Ajax/Delete") {
                $.post(href, { table: table, id: curid }, function (d) {
                    //alert(href);
                    if (d.Code == 1) {
                        //nowtr.remove();
                        if (oTable != null) {
                            oTable.ajax.reload(null, false);
                        }
                        alert(d.Message)

                    } else {
                        alertError(d.Message)
                    }
                })
            } else {
                $.post(href, {}, function (d) {
                    //alert(href);
                    if (d.Code == 1) {
                        //nowtr.remove();
                        if (oTable != null) {
                            oTable.ajax.reload(null, false);
                        }
                        alert(d.Message)

                    } else {
                        alertError(d.Message)
                    }
                })
            }
        });
    } else if ($(this).hasClass('moveup')) {//上移动
        //nowtr.insertBefore(nowtr.prev());
        //paixu();

    } else if ($(this).hasClass('movedown')) {//下移动
        //nowtr.insertAfter(nowtr.next());
        //paixu();
    } else if ($(this).hasClass('xiajia')) {//下架
        var b = $(this).children('b');
        if (b.hasClass('down-shelf')) {
            b.removeClass('down-shelf').addClass('up-shelf');
            nowtr.addClass('xiajia_row');
        } else if (b.hasClass('up-shelf')) {
            b.removeClass('up-shelf').addClass('down-shelf');
            nowtr.removeClass('xiajia_row');
        }
        //}else if($(this).hasClass('edit')){//编辑

    }
});

/******
 * 点击按钮，显示弹出框
 * *****/
//显示批量删除弹窗
$('.pl_delete').click(function () {
    var str = "";
    var name = "";
    var clen = 0;
    var table = $(this).attr("data-table");
    var href = $(this).attr("data-href");
    if (href == '' || href == undefined) {
        href = "/Ajax/Delete";
    }
    $("input[name='checkList']:checked").each(function (i, o) {
        str += $(this).val();
        name += $(this).parent().parent().nextAll().find("span.fl_name").text() + ",";
        str += ",";
        clen++;
    });
    $('.pl_delete_dialog').show().find('.haselect-item').find('span').text(name.slice(0, -1)).siblings('b').text(clen);
    $('.pl_delete_dialog').unbind('click').on('click', '.check_btn', function () {
        $('.pl_delete_dialog').hide();
        $.post(href, { table: table, id: str.slice(0, -1) }, function (d) {
            if (d.Code == 1) {
                //nowtr.remove();
                if (oTable != null) {
                    oTable.ajax.reload(null, false);
                }
                alert(d.Message)
            } else {
                alertError(d.Message)
            }
        })
    });
});
//显示批量绑定打印机弹窗
$('.bind_printer').click(function () {
    var str = "";
    var name = "";
    var clen = 0;
    var table = $(this).attr("data-table");
    $("input[name='checkList']:checked").each(function (i, o) {
        str += $(this).val();
        name += $(this).parent().parent().nextAll().find("span.fl_name").text() + ",";
        str += ",";
        clen++;
    });
    $('.bind_printer_dialog').show().find('.haselect-item').find('span').text(name.slice(0, -1)).siblings('b').text(clen);
    $('.bind_printer_dialog').unbind('click').on('click', '.check_btn', function () {
        $('.bind_printer_dialog').hide();
        var href = $(this).attr("data-href");
        var pid = $("#ddlprint").val();
        var id = str.slice(0, -1);
        $.post(href, { id: id, pid: pid }, function (d) {
            //alert(id + ",,," + pid);
            if (d.Code == 1) {
                if (oTable != null) {
                    oTable.ajax.reload(null, false);
                }
                alert(d.Message)
            } else {
                alertError(d.Message)
            }
        })
    });
});
//显示单个绑定打印机弹框
$('.caipin_category_content').on('click', 'table td>a.notbind', function (e) {
    e.preventDefault();
    var self = this;
    var nowfl = $(this).parent().siblings().find('.fl_name').text();
    $('.dg_bprinter_dialog').show().find('.haselect-item').text(nowfl);
    //点击绑定
    $('.dg_bprinter_dialog').on('click', '.check_btn', function () {
        $('.dg_bprinter_dialog').hide();
        $(self).parent().html('<b class="iconbg check"></b>');
    });
});
//显示绑定员工弹窗
$('.bind_worker').click(function () {
    //var clen = $('table>tbody input[type="checkbox"]').parent('.cb_check').size();
    //for (var i = 0, name = ''; i < clen; i++) {
    //    name += $('table>tbody input[type="checkbox"]').parent('.cb_check:eq(' + i + ')').parent().siblings('.fl_name').text();
    //    name += ',';
    //}
    //$('.bind_worker_dialog').show().find('.haselect-item').find('span').text(name.slice(0, -1)).siblings('b').text(clen);

    var str = "";
    var name = "";
    var clen = 0;
    var table = $(this).attr("data-table");
    $("input[name='checkList']:checked").each(function (i, o) {
        str += $(this).val();
        name += $(this).parent().parent().nextAll().find("span.fl_name").text() + ",";
        str += ",";
        clen++;
    });
    $('.bind_worker_dialog').show().find('.haselect-item').find('span').text(name.slice(0, -1)).siblings('b').text(clen);
    $('.bind_worker_dialog').unbind('click').on('click', '.check_btn', function () {
        $('.bind_worker_dialog').hide();
        var href = $(this).attr("data-href");
        var pid = $("#ddlmanager").val();
        var id = str.slice(0, -1);
        if (pid == '') {
            alertError("未选中要绑定的员工")
        } else {
            $.post(href, { id: id, pid: pid }, function (d) {
                //alert(id + ",,," + pid);
                if (d.Code == 1) {
                    if (oTable != null) {
                        oTable.ajax.reload(null, false);
                    }
                    alert(d.Message)
                } else {
                    alertError(d.Message)
                }
            })
        }
    });
});
//显示单个绑定员工弹框
$('.caipin_manage_content').on('click', 'table td>a.notbind', function (e) {
    e.preventDefault();
    var self = this;
    var nowfl = $(this).parent().siblings().find('.fl_name').text();
    $('.dg_bworker_dialog').show().find('.haselect-item').text(nowfl);
    //点击绑定按钮
    $('.dg_bworker_dialog').on('click', '.check_btn', function () {
        $('.dg_bworker_dialog').hide();
        alert("ddx");
        //$(self).parent().text('欧阳夏丹');
    });
});
//显示批量下载弹窗
/*$('.pl_download').click(function () {
    var clen = $('table>tbody input[type="checkbox"]').parent('.cb_check').size();
    for (var i = 0, name = ''; i < clen; i++) {
        name += $('table>tbody input[type="checkbox"]').parent('.cb_check:eq(' + i + ')').parent().siblings().find('.fl_name').text();
        name += ',';
        var img = $('table>tbody input[type="checkbox"]').parent('.cb_check:eq('+i+')').parent().siblings().children('img').attr('src');
        var h = '<li><img src="'+img+'"/></li>';
        $('.pl_download_dialog').find('.img_box').append(h);
    }
    var first = $('table>tbody input[type="checkbox"]').parent('.cb_check:eq(0)').parent().siblings().children('img').attr('src');
    $('.pl_download_dialog').find('.haselect>img').attr('src',first);
    $('.pl_download_dialog').show().find('.haselect-item').find('span').text(name.slice(0, -1)).siblings('b').text(clen);
});*/
//显示批量绑定库房弹窗
$('.bind_warehouse').click(function () {
    var str = "";
    var name = "";
    var clen = 0;
    var table = $(this).attr("data-table");
    $("input[name='checkList']:checked").each(function (i, o) {
        str += $(this).val();
        name += $(this).parent().parent().nextAll().find("span.fl_name").text() + ",";
        str += ",";
        clen++;
    });
    $('.bind_warehouse_dialog').show().find('.haselect-item').find('span').text(name.slice(0, -1)).siblings('b').text(clen);
    $('.bind_warehouse_dialog').unbind('click').on('click', '.check_btn', function () {
        $('.bind_warehouse_dialog').hide();
        var href = $(this).attr("data-href");
        var pid = $("#ddlwarehouse").val();
        var id = str.slice(0, -1);
        $.post(href, { id: id, pid: pid }, function (d) {
            //alert(id + ",,," + pid);
            if (d.Code == 1) {
                if (oTable != null) {
                    oTable.ajax.reload(null, false);
                }
                alert(d.Message)
            } else {
                alertError(d.Message)
            }
        })
    });
});

//弹出框的取消按钮
$('.cancel_btn').click(function () {
    $(this).parent().parent().parent().parent().parent().hide();
});
//弹出框工具条上的关闭按钮
$('.btn_dialog .tools>a.remove').click(function (e) {
    e.preventDefault();
    $(this).parent().parent().parent().parent().parent('.btn_dialog').hide();
});

/*
*点击表格中二维码图标显示大图
* */
$('table').on('click', 'tbody td>img', function () {
    var src = $(this).attr('src');
    $(this).siblings('.modal-backdrop').show().find('img').attr('src', src);
});
$('table').on('click', 'tbody .showImg>a.closed', function (e) {
    e.preventDefault();
    $(this).parent().parent().hide();
});



/*
 * 创建上传图片的块
 * */
var uploadItem = function (num, imgSrc, fileId, hiddId, hiddName, hiddVal) {
    var itemLen = $('.upload-multiImg').find('.upload-item').size();
    if (itemLen < num) {
        var html = '';
        html += '<div class="upload-item">' +
            '<img class="upload" src="' + imgSrc + '"/>' +
            '<a href="javascript:;" class="upload-delete"></a>' +
            '<input class="upload-file" type="file"  id="' + fileId + '"/>' +
            '<input type="hidden" id="' + hiddId + '" name="' + hiddName + '" value="' + hiddVal + '" data-file="0" />' +
            '</div>';
        $('.upload-multiImg').append(html);
    } else {
        // alert('最多上传'+num+'张');
    }
};
/*
 * 显示上传框的删除按钮
 * */
$('.upload-box').on('mouseenter', '.upload-item', function () {
    var dataFile = $(this).find('input[type="hidden"]').attr('data-file');
    var del = $(this).find('.upload-delete');
    if (dataFile == 0) {
        del.hide();
    } else {
        del.show();
    }
});
$('.upload-box').on('mouseleave', '.upload-item', function () {
    $(this).find('.upload-delete').hide();
});

/*
 * 上传框的删除方法
 * */
$('.upload-box>.upload-multiImg').on('click', '.upload-item a.upload-delete', function (e) {
    e.preventDefault();
    var multiImg = $(this).parent().parent('.upload-multiImg');
    var dataFile = multiImg.find('input[data-file="0"]').size();
    $(this).parent().remove();
    if (dataFile == 0) {
        var html = '';
        html += '<div class="upload-item">' +
            '<img class="upload" src="http://cdn.meiweiyun.cn/Content/image/upload.png"/>' +
            '<a href="javascript:;" class="upload-delete"></a>' +
            '<input class="upload-file" type="file"  id="uploadify"/>' +
            '<input type="hidden" id="imgurl" name="imgurl" value="" data-file="0"/>' +
            '</div>';
        multiImg.append(html);
    }
});
//单张图片
$('.upload-box>.upload-singleImg').on('click', '.upload-item a.upload-delete', function (e) {
    e.preventDefault();
    $(this).siblings('input[type="hidden"]').val('');
    $(this).siblings('input[type="hidden"]').attr('data-file', 0);
    $(this).siblings('img.upload').attr('src', 'http://cdn.meiweiyun.cn/Content/image/upload.png');
});


/******
 * 判断是否为价格格式
 * ******/
var regPrice = function (input) {
    $(document).on('blur', input, function () {
        var href = this;
        var v = $(this).val();
        var reg = /^[0-9]+(\.[0-9]{1,2})?$/g;
        if (v !== '') {
            if (!reg.test(v)) {
                var w = '<span class="regTip regWrong">价格格式不正确!</span>';
                $(this).siblings('.regTip').remove();
                $(this).parent().append(w);
            } else {
                $(this).siblings('.regTip').remove();
            }
        } else {
            $(this).siblings('.regTip').remove();
            $(this).val('0');
        }
    })
};
//regPrice('.regPrice');
/******
 * 判断是否为数字格式
 * ******/
var regNumber = function (input) {
    $(document).on('blur', input, function () {
        var href = this;
        var v = $(this).val();
        var reg = /^\d*$/g;
        if (v !== '') {
            if (!reg.test(v)) {
                var w = '<span class="regTip regWrong">价格格式不正确!</span>';
                $(this).siblings('.regTip').remove();
                $(this).parent().append(w);
            } else {
                $(this).siblings('.regTip').remove();
            }
        } else {
            $(this).siblings('.regTip').remove();
            $(this).val('0');
        }
    })
};
//regNumber('.regNumber');





/********
获得当前时间函数
********/
var getdate = function () {
    var now = new Date();
    var year = now.getFullYear();
    var month = now.getMonth() + 1;
    var date = now.getDate();
    var hour = now.getHours();
    var minute = now.getMinutes();
    var second = now.getSeconds();
    if (month < 10) { month = '0' + month; }
    if (date < 10) { date = '0' + date; }
    if (hour < 10) { hour = '0' + hour; }
    if (minute < 10) { minute = '0' + minute; }
    if (second < 10) { second = '0' + second; }
    //日期
    var nowdate = year + '-' + month + '-' + date;
    //日期时间
    var nowdatetime = nowdate + ' ' + hour + ':' + minute + ':' + second;
    return [nowdate, nowdatetime];
};
/******
显示与隐藏表单提示内容(placeholder)
*******/
var placeholder = function () {
    var pl;
    $('input.no-placeholder').focus(function () {
        var p = $(this).attr('placeholder');
        pl = p;
        $(this).attr('placeholder', '');
    });
    $('input.no-placeholder').blur(function () {
        if ($(this).val() == '') {
            $(this).attr('placeholder', pl);
        }
    });
};

/******
 * 单选/复选新样式的选中与不选中
 * ****/
//复选
$('.cb').on('click', function () {
    $(this).hasClass('cb_check') ?
        $(this).removeClass('cb_check')/*.children('input[type="checkbox"]').prop('checked',false)*/
        : $(this).addClass('cb_check')/*.children('input[type="checkbox"]').prop('checked',true)*/;
});
$(function () {
    $('.cb>input[type="checkbox"]:checked').parent('.cb').addClass('cb_check');
    $('.cb>input[type="checkbox"]:not(:checked)').parent('.cb').removeClass('cb_check');
});
//单选
$(".rd").on("click", function () {
    $(this).addClass("rd_check").children('input[type="radio"]').prop('checked', true);
    $(this).parent().siblings().find('.rd').removeClass("rd_check").children('input[type="radio"]').prop('checked', false);
});
$(function () {
    $('.rd>input[type="radio"]:checked').parent('.rd').addClass('rd_check');
    $('.rd>input[type="radio"]:not(:checked)').parent('.rd').removeClass('rd_check');
});


