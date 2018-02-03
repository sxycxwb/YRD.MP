//显示与隐藏表单提示内容(placeholder)
placeholder();

/*
'账户中心'->'商家资料'
*/
//一加载选中'支持'后，显示手机和验证码
$(function(){
    if($('.support_book').prop('checked')){
        $('.book_phone,.book_yzm,.book_arrow').show();
    }else{
        $('.book_phone,.book_yzm,.book_arrow').hide();
    }
});
//点击支持预订
$('.support_book').click(function(){
    $('.book_phone,.book_yzm,.book_arrow').show();
});
$('.disupport_book').click(function(){
    $('.book_phone,.book_yzm,.book_arrow').hide();
});
//点击获取验证码
$('.book_yzm .getma').click(function(e){
    e.preventDefault();
    $(this).hide().next('.regetma').show();
    getMa();
});
function getMa(){
    var t = $('.regetma').find('span').text();
    var timer = setInterval(function(){
        t--;
        $('.regetma').find('span').text(t);
        if(t<=0){
            t = 60;
            $('.regetma').find('span').text(t);
            clearInterval(timer);
            $('.regetma').hide().prev('.getma').show();
        }
    },1000)
}
//点击商家许可证，显示大图
$('#business_info .business_certificate').on('click','.businessImg>img',function(){
    var src = $(this).attr('src');
   $(this).siblings('.modal-backdrop').show().find('img').attr('src',src);
});
$('#business_info .business_certificate').on('click','a.closed',function(e){
   e.preventDefault();
    $(this).parent().parent().hide();
});
//显示'全部店面'按钮
$(function(){
   var style = $('#business_info input.shopstyle');
    if(style.val()!=='独立店铺'){
        style.siblings('.all_stores_btn').removeClass('hide');
    }else{
        style.siblings('.all_stores_btn').addClass('hide');
    }
});
//营业时间的联动
var businessTime = function(now,start,end){
    $('#business_info ' + now).change(function(){
        var s = $(start).find('option:selected').index();
        var e = $(end).find('option:selected').index();
        var es = e - s;
        if(es <= 0){
            $(end).val('').focus();
        }
    });
};
businessTime('.lunch-start','.lunch-start','.lunch-end');
businessTime('.lunch-end','.lunch-start','.lunch-end');
businessTime('.dinner-start','.dinner-start','.dinner-end');
businessTime('.dinner-end','.dinner-start','.dinner-end');


/*
'账户中心'->'权限设置'
*/
//点击角色中的标题，后面的都选中
$('.perm_bind_content').on('click','.perm_title>.cb>input[type="checkbox"]',function(){
    var all = $(this).prop('checked');
    var div = $(this).parent().parent('.perm_title').siblings('.span2');
    if(all){
        $(this).parent('.cb').addClass('cb_check');
        div.children('.cb').addClass('cb_check').children('input').prop('checked',true);
    }else{
        $(this).parent('.cb').removeClass('cb_check');
        div.children('.cb').removeClass('cb_check').children('input').prop('checked',false);
    }
});
$('.perm_bind_content').on('click','.row-fluid>div:not(.perm_title) input[type="checkbox"]',function(){
   var r =  $('.perm_bind_content .row-fluid').size();
    for(var i=0;i<r;i++){
        var item = $('.perm_bind_content .row-fluid:eq('+i+')>div:not(.perm_title) input').size();
        var check = $('.perm_bind_content .row-fluid:eq('+i+')>div:not(.perm_title) input:checked').size();
        var all = $('.perm_bind_content .row-fluid:eq('+i+')>.perm_title input');
        if(item!==0 && item==check){
           all.prop('checked',true).parent('.cb').addClass('cb_check');
        }else{
            all.prop('checked',false).parent('.cb').removeClass('cb_check');
        }
    }
});


/*
 '账户中心'->'短信设置'
 '系统管理'->'收银设置'
 */
//点击开关，显示弹框
$('#message_set,#sm_cs_content').on('click','input[type="checkbox"]',function(){
    var check = $(this).prop('checked');
    var now = $(this).attr('id');
    if(check){
        $('.'+now).show(300);
    }else{
        $('.'+now).hide(300);
    }
});
$(function(){
    $('#message_set input[type="checkbox"]:checked')
        .parent().parent().parent().next('.switchButton-dialog').show(300);
    $('#message_set input[type="checkbox"]:not(:checked)')
        .parent().parent().parent().next('.switchButton-dialog').hide(300);
});
$(function(){
    $('#sm_cs_content input[type="checkbox"]:checked')
        .parent().parent().parent().next('.switchButton-dialog').show(300);
    $('#sm_cs_content input[type="checkbox"]:not(:checked)')
        .parent().parent().parent().next('.switchButton-dialog').hide(300);
});
/*系统管理--收银设置*/
//点击'查看案例'按钮
$('#sm_cs_content').on('click','.showCaseBtn',function(){
    $('#sm_cs_content').find('.caseDialog').show();
});
$('#sm_cs_content').on('click','.caseDialog .closed',function(){
    $('#sm_cs_content').find('.caseDialog').hide();
});



/*
 账户管理--版本开通
 * */
$('#online_upgrade').on('click','.nav-tabs>li',function(e){
    var self = $(this);
    if(self.hasClass('disabled')){
        e.stopPropagation();
    }
});
$(function(){
    var navList = $('#online_upgrade .nav-tabs');
    var navListLen = navList.children('li').size();
    for(var i = 0 ; i < navListLen ; i++){
        var item = navList.children(':eq('+i+')');
        if(item.hasClass('disabled')){
            item.children('a').attr('href','javascript:;');
        }
    }
});


/*
* '账户中心'->'账户余额'
*/
//返佣充值内容
$(function(){
    var rebateLen = $('#ab_rebate_recharge input.recharge-money').size();
    for(var i=0;i<rebateLen;i++){
        var now = $('#ab_rebate_recharge').find('input.recharge-money:eq('+i+')');
        var v = now.val();
        now.parent().siblings('.text-inline').text(v);
    }
    var checkMoney = $('#ab_rebate_recharge input.recharge-money:checked').val();
    $('#ab_rebate_recharge .pay-money').text('￥'+checkMoney);
});

$('#ab_rebate_recharge input.recharge-money').click(function(){
    var rm = $('#ab_rebate_recharge input.recharge-money:checked').val();
    $('#ab_rebate_recharge .pay-money').text('￥'+rm);
});
//短信充值内容
$(function(){
    $('#ab_message_recharge').find('.recharge-btns>button:eq(0)').addClass('select');
    var p = $('#ab_message_recharge').find('.recharge-btns>button.select').attr('data-price');
    var a = $('#ab_message_recharge').find('.recharge-btns>button.select').attr('data-account');
    $('#ab_message_recharge .pay-money').text('￥'+p);
    $('#ab_message_recharge .mess-price').val(p);
    $('#ab_message_recharge .mess-account').val(a);
});

$('#ab_message_recharge').on('click','.recharge-btns>button',function(){
    $(this).addClass('select').siblings('.select').removeClass('select');
    var p = $(this).attr('data-price');
    var a = $(this).attr('data-account');
    $('#ab_message_recharge .pay-money').text('￥'+p);
    $('#ab_message_recharge .mess-price').val(p);
    $('#ab_message_recharge .mess-account').val(a);
});


/*
 * '打印机设置'
 * */
//'添加打印机',选择类别为'无线'时，显示机器唯一码
$('#ps_add_printer_content .printer_category select').change(function(){
    var val = $(this).val();
    if(val == 1){
        $('.printer_category').siblings('.unique_code').show();
    }else{
        $('.printer_category').siblings('.unique_code').hide();
    }
});
$(function(){
    var v = $('#ps_add_printer_content .printer_category').find('select').val();
    if(v == 1){
        $('.printer_category').siblings('.unique_code').show();
    }else{
        $('.printer_category').siblings('.unique_code').hide();
    }
});


/*
* '打印机设置'-'传单设置'
* */
$('#ps_leaflet_set_content .print_rule select').change(function(){
    var isneed = $(this).find('option:selected').attr('data-print');
    var print_rule = $(this).parent().parent();
    if(isneed == 'yes'){
        $(print_rule).siblings('.print_select').show();
        var isstyle = $(this).find('option:selected').attr('data-need');
        var src1 = $(print_rule).siblings('.print_style').find('img').attr('src');
        var src2 = src1.slice(0,src1.lastIndexOf('_')+1)+isstyle+src1.slice(src1.lastIndexOf('.'));
        $(print_rule).siblings('.print_style').show().find('img').attr('src',src2);
    }else{
        $(print_rule).siblings('.print_select,.print_style').hide();
    }
});


/*
 * '完善资料'
 * */
/*手机号表单中有内容后，验证码按钮变色*/
$('#complete_info .telphone').keydown(function(){
    $(this).next('.yzm-btn').addClass('active');
});
$('#complete_info .telphone').blur(function(){
    if($(this).val() == ''){
        $(this).next('.yzm-btn').removeClass('active');
    }
});
$(function(){
    var tel = $('#complete_info .telphone').val();
    if(tel !== ''){
        $('#complete_info .telphone').next('.yzm-btn').addClass('active');
    }else{
        $('#complete_info .telphone').next('.yzm-btn').removeClass('active');
    }
});
/*点击获取验证码的后，60s倒计时*/
$('#complete_info .get-yzm').click(function(e){
    e.preventDefault();
    if(!$(this).hasClass('active')){
        return;
    }else{
        getyzm(this);
    }
});
var getyzm = function(i){
    $(i).hide().next('.reget-yzm').show();
    var reget = $(i).next('.reget-yzm');
    var second = $(reget).find('.second').text();
    var timer = setInterval(function(){
        second--;
        $(reget).find('.second').text(second);
        if(second<=0){
            clearInterval(timer);
            $(reget).find('.second').text(60);
            $(reget).hide().prev('.get-yzm').show();
        }
    },1000);
};

