//页面一加载，显示今天时间
$(function(){
    $('.selectime').find('input#d1').val(getdate()[0]+' 00:00:00');
    $('.selectime').find('input#d2').val(getdate()[1]);
});
//点击前天，昨天，今天显示不同的时间
$('.selectime').on('click','a',function(e){
    e.preventDefault();
    $(this).removeClass('c333').addClass('f60').siblings('a.f60').removeClass('f60').addClass('c333');
    //将时间填入进去
    if($(this).hasClass('today')){
        $(this).siblings('#d1').val(getdate()[0]+' 00:00:00');
        $(this).siblings('#d2').val(getdate()[1]);
    }
});

