//显示与隐藏表单提示内容(placeholder)
placeholder();

/*'菜品管理->添加菜品',限制规格名称最多为5个汉字*/
/******
 * 判断汉字个数
 * ******/
var regChineseLen = function(input){
    $(document).on('blur',input,function(){
        var href = this;
        var v = $(this).val();
        var vLen = v.length;
        if(v !== ''){
            if(vLen > 5){
                var w = '<span class="regTip regWrong">最多包含5个汉字!</span>';
                $(this).siblings('.regTip').remove();
                $(this).parent().append(w);
            }else{
                $(this).siblings('.regTip').remove();
            }
        }else{
            $(this).siblings('.regTip').remove();
        }
    })
};
regChineseLen('.regChineseLen');



/*'菜品管理->添加菜品',根据半成品与成品，选择不同的打印行*/
$(function(){
    $('input.iscp.bcp:checked').parent().parent().parent().parent()
        .siblings('.bcp_printer').removeClass('hide')
        .siblings('.bcp_warehouse').removeClass('hide');
    $('input.iscp.cp:checked').parent().parent().parent().parent()
        .siblings('.cp_printer').removeClass('hide');
});
$('input.iscp.bcp').click(function(){
    var p = $(this).parent().parent().parent().parent();
    p.siblings('.bcp_printer').removeClass('hide');
    p.siblings('.bcp_warehouse').removeClass('hide');
    p.siblings('.cp_printer').addClass('hide');
});
$('input.iscp.cp').click(function(){
    var p = $(this).parent().parent().parent().parent();
    p.siblings('.cp_printer').removeClass('hide');
    p.siblings('.bcp_printer').addClass('hide');
    p.siblings('.bcp_warehouse').addClass('hide');
});

/*'菜品管理->添加菜品',点击'有特价弹出框'中的a时，添加背景颜色*/
//点击a添加索引值到input，在根据input中的索引值体现到a上
$('.hasdiscount_dialog').on('click', 'a', function (e) {
    e.preventDefault();
    var h = $(this).attr('data-index');
    var input1 = $(this).siblings('input').val();
    var input2 = '';
    if ($(this).hasClass('active')) {
        $(this).removeClass('active').css('textDecoration', 'none');
        input2 = input1.replace('-' + h + '-', '');
    } else {
        $(this).addClass('active');
        input2 = input1 + '-' + h + '-';
    }
    $(this).siblings('input').val(input2);
    //点哪个，让哪个前面的单选框选中;
    $(this).parent().siblings('.rd').addClass('rd_check').children('input').prop('checked',true);
    var otherBlock = $(this).parent().parent().siblings();
    otherBlock.find('.rd').removeClass('rd_check').children('input').prop('checked',false);
    //另一个中的a去掉active;并清空下面的input值；
    otherBlock.find('div a.active').removeClass('active')
        .siblings('input.checkedDate').val('');
    //timestyle的value值要变;
    var t1 = $(this).parent().siblings('.rd').children('input').val();
    var t2 = otherBlock.find('.rd').find('input').val();
    var time = $(this).parent().parent().parent().siblings('.timestyle');
    var v = time.val();
    time.val(t1);
    v.replace(t2,'');
});
$(function () {
    //根据input的值显示到具体的日期上
    var checkedLen = $('.hasdiscount_dialog').find('input.checkedDate').size();
    for (var i = 0; i < checkedLen; i++) {
        var val = $('.hasdiscount_dialog').find('input.checkedDate:eq(' + i + ')').val();
        var reg1 = new RegExp('--', 'g');
        var reg2 = new RegExp('-', 'g');
        val = val.replace(reg1, '|');
        val = val.replace(reg2, '');

        var arr = val.split('|');
        for (var j = 0; j < arr.length; j++) {
            $('.hasdiscount_dialog').find('input.checkedDate:eq(' + i + ')')
                .siblings('a[data-index=' + arr[j] + ']').addClass('active');
        }
    }
    //根据input中的值显示到每周或每月
    var timestyleLen = $('.hasdiscount_dialog').find('input.timestyle').size();
    for(var t=0;t<timestyleLen;t++){
        var now = $('.hasdiscount_dialog').find('input.timestyle:eq('+t+')');
        var style = now.val();
        now.siblings().find('input[value="'+style+'"]').prop('checked',true)
            .parent('.rd').addClass('rd_check')
            .parent().siblings().find('.rd').removeClass('rd_check')
            .find('input[type="radio"]').prop('checked',false);
    }

});
/*特价框的内容*/
var discount_cont = '<div class="discount_cont">'
    +'<div class="control-group disc_price">'
    +'<label class="control-label">价格</label>'
    +'<div class="controls">'
    +'<input type="text" name="dis_price" class="m-wrap small regPrice"/>'
    +'<span class="help-inline">元</span>'
    +'</div>'
    +'</div>'
    +'<div class="control-group disc_time">'
    +'<label class="control-label">使用时间</label>'
    +'<div class="controls">'
    +'<div class="inline-block">'
    +'<span class="rd rd_check">'
    +'<input type="radio" class="cbrd" value="week" name="times" checked="checked"/>'
    +'</span>'
    +'<span class="text-inline">每周</span>'
    +'<div class="weeks">'
    +'<a href="" data-index="1">星期一</a> '
    +'<a href="" data-index="2">星期二</a> '
    +'<a href="" data-index="3">星期三</a> '
    +'<a href="" data-index="4">星期四</a> '
    +'<a href="" data-index="5">星期五</a> '
    +'<a href="" data-index="6">星期六</a> '
    +'<a href="" data-index="7">星期日</a>'
    +'<input type="hidden" class="checkedDate" name="times_weeks" value=""/>'
    +'</div>'
    +'</div>'
    +'<div class="inline-block">'
    +'<span class="rd">'
    +'<input type="radio" class="cbrd" value="month" name="times"/>'
    +'</span>'
    +'<span class="text-inline">每月</span>'
    +'<div class="months">'
    +'<a href="" data-index="1">1</a> '
    +'<a href="" data-index="2">2</a> '
    +'<a href="" data-index="3">3</a> '
    +'<a href="" data-index="4">4</a> '
    +'<a href="" data-index="5">5</a> '
    +'<a href="" data-index="6">6</a> '
    +'<a href="" data-index="7">7</a> '
    +'<a href="" data-index="8">8</a> '
    +'<a href="" data-index="9">9</a> '
    +'<a href="" data-index="10">10</a> '
    +'<a href="" data-index="11">11</a> '
    +'<a href="" data-index="12">12</a> '
    +'<a href="" data-index="13">13</a> '
    +'<a href="" data-index="14">14</a> '
    +'<a href="" data-index="15">15</a> '
    +'<a href="" data-index="16">16</a> '
    +'<a href="" data-index="17">17</a> '
    +'<a href="" data-index="18">18</a> '
    +'<a href="" data-index="19">19</a> '
    +'<a href="" data-index="20">20</a> '
    +'<a href="" data-index="21">21</a> '
    +'<a href="" data-index="22">22</a> '
    +'<a href="" data-index="23">23</a> '
    +'<a href="" data-index="24">24</a> '
    +'<a href="" data-index="25">25</a> '
    +'<a href="" data-index="26">26</a> '
    +'<a href="" data-index="27">27</a> '
    +'<a href="" data-index="28">28</a> '
    +'<a href="" data-index="29">29</a> '
    +'<a href="" data-index="30">30</a> '
    +'<a href="" data-index="31">31</a>'
    +'<input type="hidden" class="checkedDate" name="times_months" value=""/>'
    +'</div>'
    +'</div>'
    +'</div>'
    +'<input type="hidden" class="timestyle" name="timestyle" value=""/>'
    +'</div>'
    +'</div>';

/*点击有特价时，弹出特价框，并判断是否有规格特价*/
$('input.hasdiscount').click(function(){
    $('.hasdiscount_dialog').fadeIn();
    var disc_len = $('.hasdiscount_dialog').find('.discount_cont').size();
    var hasguige = $('.add_caipin input.hasguige').prop('checked');
    if(hasguige){
        var gg_len = $('.hasguige_dialog .guige_item').size();
        if(gg_len == 0){
            $('.hasdiscount_dialog>.discount_cont').find('.disc_price .control-label').text('价格');
        }else{
            for(var i=0;i<gg_len-disc_len;i++){
                $('.hasdiscount_dialog').append(discount_cont);
            }
            var cont_len = $('.hasdiscount_dialog .discount_cont').size();
            for(var j=0;j<cont_len;j++){
                var gg_name = $('.hasguige_dialog .guige_item:eq('+j+')').find('.gg_name').text();
                $('.hasdiscount_dialog .discount_cont:eq('+j+')').find('.disc_price .control-label').text(gg_name);
                $('.hasdiscount_dialog .discount_cont:eq('+j+')').find('input[type="radio"]').attr('name','times'+j);
            }
        }
    }else{
        $('.hasdiscount_dialog>div:gt(0)').remove();
        $('.hasdiscount_dialog>.discount_cont').find('.disc_price .control-label').text('价格');
    }
});
$('input.nodiscount').click(function () {
    $('.hasdiscount_dialog').fadeOut()
        .find('input[type="text"]').val('');
});
/*点击特价弹框中的radio单选框*/
$(".hasdiscount_dialog").on("click",'.rd',function(){
    $(this).addClass("rd_check").children('input').attr('checked',true);
    var otherBlock = $(this).parent().siblings();
    otherBlock.find('.rd').removeClass("rd_check").children('input').attr('checked',false);
    //timestyle的值要切换
    var t1 = $(this).find('input').val();
    var t2 = otherBlock.find('.rd').find('input').val();
    var time = $(this).parent().parent().siblings('.timestyle');
    var v = time.val();
    time.val(t1);
    v.replace(t2,'');
    //选中一个时间，让另一个时间里面的a去掉active;并清空该时间下的input的值；
    otherBlock.find('div a.active').removeClass('active')
        .siblings('input.checkedDate').val('');


});
//一开始有特价，显示特价框
$(function(){
    var hasdiscount = $('.add_caipin input.hasdiscount').prop('checked');
    if(hasdiscount){
        $('.add_caipin .hasdiscount_dialog').fadeIn();
    }else{
        $('.add_caipin .hasdiscount_dialog').fadeOut();
    }
});



/*'菜品管理'->'添加菜品',点击'有'规格时，显示有规格弹出框*/
$('.add_caipin input.hasguige').click(function () {
    $('.add_caipin .hasguige_dialog').addClass('show')
        .children('.hide').removeClass('hide').addClass('show');
    $('.hasguige_dialog').children('.lingshou,.huiyuan,.waimai').find('input[type="text"]').val('');
});
$('.add_caipin input.noguige').click(function () {
    $('.add_caipin .hasguige_dialog').removeClass('show')
        .children('.show').removeClass('show').addClass('hide');
    $('.hasguige_dialog').find('.guige_item').remove();
    $('.hasguige_dialog').children('.lingshou,.huiyuan,.waimai').find('input[type="text"]').val('');
    $('.guige .gg').hide();
});
$(function(){
    var hasguige = $('.add_caipin input.hasguige').prop('checked');
    if(hasguige){
        $('.add_caipin .hasguige_dialog').addClass('show')
            .children('.hide').removeClass('hide').addClass('show');
    }else{
        $('.add_caipin .hasguige_dialog').removeClass('show')
            .children('.show').removeClass('show').addClass('hide');
    }
});
/*菜品管理->添加菜品->有规格弹窗－>'继续添加' 按钮*/
$('.add_more_guige').click(function (e) {
    e.preventDefault();
    //判断价格是否存在错误提示
    var regWrong = $('.hasguige_dialog').find('.regWrong').size();
    if(regWrong !== 0){
        return;
    }else{
        $('.hasguige_dialog').find('.regTip').remove();
    }
    //添加内容：
    var txt = $(this).text();
    if(txt == '保存'){
        $(this).text('继续添加');
        $('.hasguige_dialog').find('.guige_name').find('input').attr('disabled',false);
    }
    var gi_length = $('.hasguige_dialog').find('.guige_item').length;
    if(gi_length>=5){
        $(this).attr('disabled',true);
    }
    var guige_name = $('.hasguige_dialog .guige_name').find('input').val();
    var ls = $('.hasguige_dialog .lingshou').find('input').val();
    var hy = $('.hasguige_dialog .huiyuan').find('input').val();
    var wm = $('.hasguige_dialog .waimai').find('input').val();
    if (gi_length < 0) {
        var html1 = '';
        html1 += '<div class="control-group guige_item">' +
        '<label class="control-label">规格' + (gi_length + 1) + '</label>' +
        '<div class="controls">' +
        '<span class="help-inline gg gg_name">' + guige_name + '</span> ' +
        '<input type="hidden" name="gg_name2" value="' + guige_name + '"/>' +
        '<input type="hidden" name="gg_ls2" value="' + ls + '"/>' +
        '<input type="hidden" name="gg_hy2" value="' + hy + '"/>' +
        '<input type="hidden" name="gg_wm2" value="' + wm + '"/>' +
        '<span class="help-inline gg gg_ls">' + ls + '元</span> ' +
        '<span class="help-inline gg gg_hy">' + hy + '元</span> ' +
        '<span class="help-inline gg gg_wm">' + wm + '元</span> ' +
        '<span class="help-inline gg modify_guige"><a href="">修改</a></span> ' +
        '<span class="help-inline gg remove_guige"><a href="">移去</a></span>' +
        '</div>' +
        '</div>';
        $('.hasguige_dialog .guige_name').before(html1);
    } else {
        for (var i = 0; i < gi_length + 1; i++) {
            var gg_name = $('.hasguige_dialog .guige_item:eq(' + i + ')').find('.gg_name').text();
            if (guige_name == gg_name) {
                $('.hasguige_dialog .guige_item:eq(' + i + ')')
                    .find('.gg_ls').text(ls + '元')
                    .siblings('.gg_hy').text(hy + '元')
                    .siblings('.gg_wm').text(wm + '元')
                    .siblings('input[name="gg_ls2"]').val(ls)
                    .siblings('input[name="gg_hy2"]').val(hy)
                    .siblings('input[name="gg_wm2"]').val(wm);
                return;
            }
        }
        var html2 = '';
        html2 += '<div class="control-group guige_item">' +
        '<label class="control-label">规格' + (gi_length + 1) + '</label>' +
        '<div class="controls">' +
        '<span class="help-inline gg gg_name">' + guige_name + '</span> ' +
        '<input type="hidden" name="gg_name2" value="' + guige_name + '"/>' +
        '<input type="hidden" name="gg_ls2" value="' + ls + '"/>' +
        '<input type="hidden" name="gg_hy2" value="' + hy + '"/>' +
        '<input type="hidden" name="gg_wm2" value="' + wm + '"/>' +
        '<span class="help-inline gg gg_ls">' + ls + '元</span> ' +
        '<span class="help-inline gg gg_hy">' + hy + '元</span> ' +
        '<span class="help-inline gg gg_wm">' + wm + '元</span> ' +
        '<span class="help-inline gg modify_guige"><a href="">修改</a></span> ' +
        '<span class="help-inline gg remove_guige"><a href="">移去</a></span>' +
        '</div>' +
        '</div>';
        $('.hasguige_dialog .guige_name').before(html2);
    }
    if (gi_length >= 4) {
        $(this).attr('disabled', true);
    }
    //判断特价框是否已经显示，如果已经显示，开始添加特价操作
    var hasdisc = $('.add_caipin input.hasdiscount').prop('checked');
    if(hasdisc){
        var discLen = $('.hasdiscount_dialog').find('.discount_cont').size();
        var ggLen = $('.hasguige_dialog').find('.guige_item').size();
        for(var z=0;z<ggLen-discLen;z++){
            $('.hasdiscount_dialog').append(discount_cont);
        }
        var contLen = $('.hasdiscount_dialog .discount_cont').size();
        for(var l=0;l<contLen;l++){
            var ggName = $('.hasguige_dialog .guige_item:eq('+l+')').find('.gg_name').text();
            $('.hasdiscount_dialog .discount_cont:eq('+l+')').find('.disc_price .control-label').text(ggName);
            $('.hasdiscount_dialog .discount_cont:eq('+l+')').find('input[type="radio"]').attr('name','times'+l);
        }
    }else{
        return;
    }
});
/*菜品管理->添加菜品->有规格弹窗－>'移除' 按钮*/
$('.hasguige_dialog').on('click', '.remove_guige', function (e) {
    e.preventDefault();
    var ggName = $(this).parent().siblings('.gg_name').text();
    $(this).parent().parent().parent().remove();
    var gi_length = $('.hasguige_dialog').find('.guige_item').length;
    for(var i=0;i<gi_length;i++){
        $('.hasguige_dialog').find('.guige_item:eq('+i+')').find('.control-label').text('规格'+(i+1));
    }
    if(gi_length<=4){
        $('.hasguige_dialog .add_more_guige').attr('disabled',false);
    }
    // 判断特价框是否已经显示，如果已经显示，开始删除特价操作
    //注意删除到最后一个时
    var hasdisc = $('.add_caipin input.hasdiscount').prop('checked');
    if(hasdisc){
        if(gi_length > 0){
            $('.hasdiscount_dialog').find('.disc_price label:contains('+ggName+')')
                .parent().parent().remove();
        }else{
            $('.hasdiscount_dialog').find('.disc_price label').text('价格');
        }
    }else{
        return;
    }
});
/*有规格弹框--'修改'按钮*/
$('.hasguige_dialog').on('click','.modify_guige>a',function(e){
    e.preventDefault();
    var p = $(this).parent();
    var name = p.siblings('.gg_name').text();
    var ls = p.siblings('.gg_ls').text().slice(0,-1);
    var hy = p.siblings('.gg_hy').text().slice(0,-1);
    var wm = p.siblings('.gg_wm').text().slice(0,-1);
    var dialog = $('.hasguige_dialog');
    dialog.find('.guige_name').find('input').val(name).attr('disabled',true);
    dialog.find('.lingshou').find('input').val(ls);
    dialog.find('.huiyuan').find('input').val(hy);
    dialog.find('.waimai').find('input').val(wm);
    dialog.find('.add_more_guige').text('保存');
    var itemLen = dialog.find('.guige_item').size();
    if(itemLen<=5){
        dialog.find('.add_more_guige').attr('disabled',false);
    }
});
/*菜品管理->添加菜品->有规格弹窗－>'没有更多了' 按钮*/
$('.no_more_guige').click(function (e) {
    e.preventDefault();
    var gi_length = $('.hasguige_dialog').find('.guige_item').length;
    $('.hasguige_dialog').removeClass('show').children('.show').removeClass('show').addClass('hide');
    $('.hasguige_dialog .lingshou').hide().siblings('.huiyuan').hide().siblings('.waimai').hide();
    $('.hasguige_dialog .guige_item').hide();
    $('.add_caipin').find('.guige .gg').show().children('.hasadd_count').text('已添加' + gi_length);
});
/*菜品管理->添加菜品->有规格－>'继续添加' 按钮*/
$('.add_caipin').on('click','.continue_add',function(e){
    e.preventDefault();
    $('.hasguige_dialog').addClass('show').children('.hide').removeClass('hide').addClass('show');
    $('.hasguige_dialog .lingshou').show().siblings('.huiyuan').show().siblings('.waimai').show();
    $('.hasguige_dialog .guige_item').show()
        .find('.modify_guige,.remove_guige').show();
});
/*菜品管理->添加菜品->有规格－>'已添加' 按钮*/
$('.add_caipin').on('click','.hasadd_count',function(e){
    e.preventDefault();
    $('.hasguige_dialog').find('.show').removeClass('show').addClass('hide');
    $('.hasguige_dialog .lingshou').hide().siblings('.huiyuan').hide().siblings('.waimai').hide();
    $('.hasguige_dialog').addClass('show').children('b').removeClass('hide').addClass('show');
    $('.hasguige_dialog .guige_item').show()
        //去掉修改和移去按钮
        .find('.modify_guige,.remove_guige').hide();

});


/*'菜品管理-添加套餐'，是否为自助*/
$(function(){
    var self = $('.add_combo').find('.rowSelfService');
    var card = $('.add_combo').find('.rowCard');
    var notSelfInput = self.find('input.notSelfService');
    var isSelfInput = self.find('input.isSelfService');
    if(notSelfInput.prop('checked')){
        card.hide();
    }else{
        card.show();
    }
});
$('.add_combo .rowSelfService').on('click','input',function(){
    var card = $('.add_combo').find('.rowCard');
    $(this).prop('checked',true);
    if($(this).hasClass('notSelfService')){
        card.hide();
    }else if($(this).hasClass('isSelfService')){
        card.show();
    }
});
/*'菜品管理-添加套餐'，菜品选择中添加菜品*/
$('.table-multi1').on('dblclick', 'td', function () {
    var select1 = $(this).parent().html();
    var cpid = $(this).parent().find('.cp_id').val();
    var ggid = $(this).parent().find('.gg_id').val();

    var s1name = $(this).parent().find('.cp_name').text();
    var s1guige = $(this).parent().find('.cp_guige').text();
    var s1price = $(this).parent().find('.cp_price').text();
    var s2len = $('.table-multi2>tbody>tr').size();
    if (s2len == 0) {
        var select2 = '<tr>' + select1 + '<td class="cp_count">1</td><td class="cp_total"><input type="hidden" name="cpid2" value="' + cpid + '" class="cph_foodid"/><input type="hidden" name="ggid2" value="' + ggid + '" /><input type="hidden" name="count2" value="1" class="cph_count"/><span class="cp_total2">' + s1price + '</span></td><td><a href="" class="toup" title="上移"><b class="iconbg comboup"></b></a><a href="" class="todown" title="下移"><b class="iconbg combodown"></b></a><a href="" class="delete" title="删除"><b class="iconbg combotrash"></b></a></td></tr>';
        $('.table-multi2>tbody').append(select2);
    } else {
        for (var i = 0, cp_num = 1; i < s2len; i++) {
            var s2name = $('.table-multi2>tbody>tr:eq(' + i + ')').find('.cp_name').text();
            var s2guige = $('.table-multi2>tbody>tr:eq(' + i + ')').find('.cp_guige').text();
            if (s2name == s1name && s2guige == s1guige) {
                var count = $('.table-multi2>tbody>tr:eq(' + i + ')').find('.cp_count').text();
                count++;
                $('.table-multi2>tbody>tr:eq(' + i + ')').find('.cp_count').text(count);
                $('.table-multi2>tbody>tr:eq(' + i + ')').find('.cp_total').find('.cp_total2').text((count * Number(s1price)).toFixed(2));
                $('.table-multi2>tbody>tr:eq(' + i + ')').find('.cph_count').val(count);
                //alert($('.table-multi2>tbody>tr:eq(' + i + ')').find('.cph_count').val());
                return;
            }
        }
        //var sel2 = '<tr>'+select1+'<td class="cp_count">1</td><td class="cp_total">'+s1price+'</td><td><a href="" class="toup" title="上移"><b class="iconbg comboup"></b></a><a href="" class="todown" title="下移"><b class="iconbg combodown"></b></a><a href="" class="delete" title="删除"><b class="iconbg combotrash"></b></a></td></tr>';
        var sel2 = '<tr>' + select1 + '<td class="cp_count">1</td><td class="cp_total"><input type="hidden" name="cpid2" value="' + cpid + '"  class="cph_foodid"/><input type="hidden" name="ggid2" value="' + ggid + '" /><input type="hidden" name="count2" value="1" class="cph_count"/><span class="cp_total2">' + s1price + '</span></td><td><a href="" class="toup" title="上移"><b class="iconbg comboup"></b></a><a href="" class="todown" title="下移"><b class="iconbg combodown"></b></a><a href="" class="delete" title="删除"><b class="iconbg combotrash"></b></a></td></tr>';
        $('.table-multi2>tbody').append(sel2);
    }

});
/*'添加套餐'，菜品选择中取消菜品*/
$('.table-multi2').on('click', 'tbody>tr>td>a.delete', function (e) {
    e.preventDefault();
    var count = $(this).parent().siblings('.cp_count').text();
    var thistotal = $(this).parent().siblings('.cp_total').text();
    var thisnum = $(this).parent().siblings('.cp_count').text();
    var single = Number(thistotal) / thisnum;
    if (count <= 1) {
        //改总数量
        var n = $('.caipin_count').find('.select2_num').text();
        n -= 1;
        $('.caipin_count').find('.select2_num').text(n);
        //改总价格
        var t = $('.caipin_count').find('.select2_total').text();
        t -= Number(thistotal);
        $('.caipin_count').find('.select2_total').text(t.toFixed(2));
        //移除
        $(this).parent().parent().remove();
    } else {
        count--;
        $(this).parent().siblings('.cp_count').text(count);
        $(this).parent().siblings('.cp_total').text((count * single).toFixed(2));
        //改总数量
        var n = $('.caipin_count').find('.select2_num').text();
        n -= 1;
        $('.caipin_count').find('.select2_num').text(n);
        //改总价格
        var t = $('.caipin_count').find('.select2_total').text();
        t -= Number(single);
        $('.caipin_count').find('.select2_total').text(t.toFixed(2));
    }
});
/*'添加套餐',菜品选择中的上移*/
$('.table-multi2').on('click', 'tbody>tr>td>a.toup', function (e) {
    e.preventDefault();
    var nowtr = $(this).parent().parent();
    nowtr.insertBefore(nowtr.prev());
});
/*'添加套餐',菜品选择中的下移*/
$('.table-multi2').on('click', 'tbody>tr>td>a.todown', function (e) {
    e.preventDefault();
    var nowtr = $(this).parent().parent();
    nowtr.insertAfter(nowtr.next());
});
/*'添加套餐',已选菜品数量和价格*/
$('.table-multi1').on('dblclick', 'td', function () {
    var s2len = $('.table-multi2>tbody>tr').size();
    for (var j = 0, cp_num = 0, cp_total = 0; j < s2len; j++) {
        //改总数量
        var s2num = $('.table-multi2>tbody>tr:eq(' + j + ')').find('.cp_count').text();
        cp_num += parseInt(s2num);
        $('.caipin_count').find('.select2_num').text(cp_num);
        //改总价格
        var s2total = $('.table-multi2>tbody>tr:eq(' + j + ')').find('.cp_total').text();
        cp_total += Number(s2total);
        $('.caipin_count').find('.select2_total').text(cp_total.toFixed(2));
    }
});
/*'添加套餐',菜品总数&总金额*/
$(function(){
    //左边
    var count1 = $('.table-multi1>tbody>tr').size();
    $('.caipin_count').find('.select1_num').text(count1);
    //右边
    var count2 = $('.table-multi2>tbody>tr').size();
    if(count2==0){
        $('.caipin_count').find('.select2_num').text(count2);
        $('.caipin_count').find('.select2_total').text(count2.toFixed(2));
    }else{
        for(var i= 0,c= 0,t=0;i<count2;i++){
            var cpcount = $('.table-multi2>tbody').find('tr:eq('+i+')').find('.cp_count').text();
            var cptotal = $('.table-multi2>tbody').find('tr:eq('+i+')').find('.cp_total').text();
            c += Number(cpcount);
            t += Number(cptotal);
        }
        $('.caipin_count').find('.select2_num').text(c);
        $('.caipin_count').find('.select2_total').text(t.toFixed(2));
    }
});
/*'添加套餐'下的优惠时间，显示为当前时间*/
$(function () {
    $('.add_combo .privilege-date #d1').val(getdate()[0]);
});



/*'房间管理'->'添加房间','继续添加'按钮,'移出'按钮*/
$('.add_room_content').on('click', '.add_more_room', function (e) {
    e.preventDefault();
    var room_length = $('.add_room_content').find('div.room').length;
    var html = '';
    html += '<div class="control-group room"> <label class="control-label">房间' + (room_length + 1) + '</label> <div class="controls"> <input type="text" class="m-wrap small no-placeholder" placeholder="名称" name="RoomName"/> <input type="text" class="m-wrap small no-placeholder" placeholder="面积" name="Acreage"/> <span class="help-inline">平方</span> <a href="" class="remove_room">移去</a> </div> </div>';
    $('.add_room_content div.form-actions').before(html);
    //移除或显示placeholder
    placeholder();
});
$('.add_room_content').on('click', '.remove_room', function (e) {
    e.preventDefault();
    $(this).parent().parent().remove();
    var room_length = $('.add_room_content').find('.room').length;
    for (var i = 0; i < room_length; i++) {
        $('.add_room_content').find('.room:eq(' + i + ')').find('.control-label').text('房间' + (i + 1));
    }
});
/*'房间管理'->'添加楼层','继续添加'按钮,'移出'按钮*/
$('.add_floor_content').on('click', '.add_more_floor', function (e) {
    e.preventDefault();
    var floor_length = $('.add_floor_content').find('div.floor').length;
    var html = '';
    html += '<div class="control-group floor"> <label class="control-label">楼层' + (floor_length + 1) + '</label> <div class="controls"> <input type="text" class="m-wrap medium" name="department"/> <a href="" class="remove_floor">移去</a> </div> </div>';
    $('.add_floor_content div.form-actions').before(html);
});
$('.add_floor_content').on('click', '.remove_floor', function (e) {
    e.preventDefault();
    $(this).parent().parent().remove();
    var floor_length = $('.add_floor_content').find('.floor').length;
    for (var i = 0; i < floor_length; i++) {
        $('.add_floor_content').find('.floor:eq(' + i + ')').find('.control-label').text('楼层' + (i + 1));
    }
});


/*'餐桌管理'->'批量添加'，超出餐桌显示提示*/
$('#pl_add input.t-end').blur(function () {
    var end = $(this).val();
    var start = $(this).parent().parent().prev().find('.t-start').val();
    if (end - start > 15) {
        $(this).next('.help-inline').removeClass('hide');
    } else {
        $(this).next('.help-inline').addClass('hide');
    }
});
$('#pl_add input.t-start').blur(function () {
    var start = $(this).val();
    var end = $(this).parent().parent().next().find('.t-end').val();
    if (end - start > 15) {
        $(this).parent().parent().next().find('.help-inline').removeClass('hide');
    } else {
        $(this).parent().parent().next().find('.help-inline').addClass('hide');
    }
});

