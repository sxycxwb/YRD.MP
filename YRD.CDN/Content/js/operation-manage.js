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

//显示与隐藏表单提示内容(placeholder)
placeholder();

/*
* 预定退订记录
* */
//下拉框选择类型：全部，成功记录，退订记录
$('#om_subscribe_record').on('click','.subscribe-style .select-box>li',function(){
    var style = $(this).attr('data-record');
    if(style=='all'){
        location.href = 'om_subscribe_record.html';
        return;
    }
    var href = 'om_sr_'+style+'_record.html';
    location.href = href;
});

/*
* 退菜赠菜记录
* */
//下拉框选择退菜和赠菜
$('#om_foodsend_record').on('click','.foodstyle .select-box>li',function(){
    var style = $(this).attr('data-food');
    var href = 'om_'+style+'_record.html';
    location.href = href;
});

