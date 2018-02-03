//找回密码按钮
$('#forget_pwd_btn').click(function(e){
    e.preventDefault();
    $('.login-form').hide();
    $('.forget-form').show();
});
//现在登录按钮
$('#now_login_btn').click(function(e){
    e.preventDefault();
    $('.forget-form').hide();
    $('.login-form').show();
});
//找回密码->登录
$('#succ_to_login_btn').click(function(e){
    e.preventDefault();
    $('.login .succ-content').hide();
    $('.login .content').show();
});
/*用户名的验证*/
$('input[name="username"]').blur(function(){
    var username = $.trim($(this).val());
    if(username == ''){
        $(this).parent().siblings('.help-inline.error').show();
    }else{
        $(this).parent().siblings('.help-inline.error').hide();
        $(this).parent().siblings('.help-inline.succ').show();
    }
});
$('input[name="username"]').focus(function(){
    var tip = $(this).parent().siblings('.help-inline.succ');
    if(tip){
        tip.hide();
    }
});
/* 密码的验证*/
$('input[name="password"]').blur(function(){
    var pwd = $.trim($(this).val());
    if(pwd == ''){
        $(this).parent().siblings('.help-inline.error').show();
    }else  if(pwd.length<6||pwd.length>12){
        $(this).parent().siblings('.help-inline.error').show().children('span').text('密码的长度必须在6-12位之间');
    }else{
        $(this).parent().siblings('.help-inline.error').hide();
        $(this).parent().siblings('.help-inline.succ').show();
    }
});
$('input[name="password"]').focus(function(){
    var tip = $(this).parent().siblings('.help-inline.succ');
    if(tip){
        tip.hide();
    }
});
/*重复密码的验证*/
$('.forget-form input[name="repassword"]').blur(function(){
    var pwd1 = $('.forget-form input[name="password"]').val();
    var pwd2 = $.trim($(this).val());
    if(pwd2 == ''){
        $(this).parent().siblings('.help-inline.error').show();
    }else  if(pwd2.length<6||pwd2.length>12){
        $(this).parent().siblings('.help-inline.error').show().children('span').text('密码的长度必须在6-12位之间');
    }else  if(pwd1!==pwd2){
        $(this).parent().siblings('.help-inline.error').show().children('span').text('两次输入的密码不一致');
    }else{
        $(this).parent().siblings('.help-inline.error').hide();
        $(this).parent().siblings('.help-inline.succ').show();
    }
});
$('.forget-form input[name="repassword"]').focus(function(){
    var tip = $(this).parent().siblings('.help-inline.succ');
    if(tip){
        tip.hide();
    }
});
/*手机号的验证*/
$('input[type="tel"]').blur(function(){
    var phone = $.trim($(this).val());
    var phoneReg = /^[1][34578]\d{9}$/;
    if(phone == ''){
        $(this).parent().siblings('.help-inline.error').show();
    }else if(!phoneReg.test(phone)){
        $(this).parent().siblings('.help-inline.error').show().children('span').text('手机号格式不正确');
    }else{
        $(this).parent().siblings('.help-inline.error').hide();
        $(this).parent().siblings('.help-inline.succ').show();
    }
});
$('input[type="tel"]').focus(function(){
    var tip = $(this).parent().siblings('.help-inline.succ');
    if(tip){
        tip.hide();
    }
});
/*登录页面的验证码的验证*/
$('.login-form input[name="login-yzm"]').blur(function(){
    var ma = $('.login-form .yzm-img').attr('data-ma');
    console.log(ma);
    var inputMa = $.trim($(this).val());
    console.log(inputMa);
    if(inputMa == ''){
        $(this).parent().siblings('.help-inline.error').show();
    }else if(inputMa.toLowerCase() !== ma.toLowerCase()){
        $(this).parent().siblings('.help-inline.error').show().children('span').text('输入验证码错误');
    }else{
        $(this).parent().siblings('.help-inline.error').hide();
        $(this).parent().siblings('.help-inline.succ').show();
    }
});
$('.login-form input[name="login-yzm"]').focus(function(){
    var tip = $(this).parent().siblings('.help-inline.succ');
    if(tip){
        tip.hide();
    }
});
/*忘记密码页面的验证码的验证*/
$('.forget-form input[name="phone-yzm"]').blur(function(){
    var inputMa = $.trim($(this).val());
    if(inputMa == ''){
        $(this).parent().siblings('.help-inline.error').show();
    }else{
        $(this).parent().siblings('.help-inline.error').hide();
        $(this).parent().siblings('.help-inline.succ').show();
    }
});
$('.forget-form input[name="phone-yzm"]').focus(function(){
    var tip = $(this).parent().siblings('.help-inline.succ');
    if(tip){
        tip.hide();
    }
});
/*忘记密码页面的获取验证码*/
//点击次数
var c = 0;
$('#get_yzm_btn').click(function(){
    $(this).hide().siblings('#reget_yzm_btn').show();
    c += 1;
    if(c > 5){
        $(this).attr('disabled',true).show().siblings('#reget_yzm_btn').hide();
        $(this).siblings('.danger').show();
    }else{
        var self = $(this).siblings('#reget_yzm_btn');
        var second = $(self).find('.second').text();
        var timer = setInterval(function(){
            second--;
            $(self).attr('disabled',true).find('.second').text(second);
            if(second <= 0){
                clearInterval(timer);
                $(self).attr('disabled',false).find('.second').text('60');
                $(self).hide().siblings('#get_yzm_btn').show();
            }
        },1000)
    }
});
