/*
获取验证码
*/
//点击次数
var c = 0;
$('#get_yzm_btn').click(function(e){
    var phoneNo = $("#Phone").val();
    if (phoneNo == "") {
        alert("手机号不能为空");
    }
    else {

        alert(phoneNo);

        $.ajax({
            type: 'POST',
            url: "/home/SendVcode",
            data: {
                phone: phoneNo

            },
            success: function (data) {
                alert(data);
            }
        });
    }


    e.preventDefault();
    $(this).hide().siblings('#reget_yzm_btn').show().attr('disabled',true);
    c += 1;
    if(c > 5){
        $(this).attr('disabled',true).show().siblings('#reget_yzm_btn').hide();
        $(this).siblings('.help-inline').show();
    }else{
        var self = $(this).siblings('#reget_yzm_btn');
        var second = $(self).find('.second').text();
        var timer = setInterval(function(){
            second--;
            $(self).find('.second').text(second);
            if(second<=0){
                clearInterval(timer);
                $(self).attr('disabled',false).find('.second').text(60);
                $(self).hide().siblings('#get_yzm_btn').show();
            }
        },1000);
    }
});

