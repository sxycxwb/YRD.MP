/*��������������л�active*/
$('#header').on('click','ul>li>a',function(e){
    e.preventDefault();
    $(this).parent().addClass('active').siblings('.active').removeClass('active');
    location.href = $(this).attr('href');
});
/*��������Ʒ���ܣ���ʾ��������*/
$('#header').on('mouseenter','ul>li>a',function(e){
    e.preventDefault();
    if($(this).parent().hasClass('product_intro')){
        $('nav').animate({'height':'60px','opacity':1},500);
    }else{
        $('nav').animate({'height':0,'opacity':0},500);
    }
});
/*��������������л�active*/
$('.product_item>a').click(function(e){
    e.preventDefault();
    $(this).parent().addClass('active').siblings('.active').removeClass('active');
    location.href = $(this).attr('href');
});
