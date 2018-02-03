/*手机号表单中有内容后，验证码按钮变色*/
$('.telphone').keydown(function(){
    $(this).next('.yzm-btn').addClass('active');
});
$('.telphone').blur(function(){
    if($(this).val() == ''){
        $(this).next('.yzm-btn').removeClass('active');
    }
});
/*点击获取验证码的后，60s倒计时*/
$('.get-yzm').click(function(e){
    e.preventDefault();
    if(!$(this).hasClass('active')){
        return;
    }else{
        getyzm(this);
    }
});
//注册、找回密码中的获取验证码
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


