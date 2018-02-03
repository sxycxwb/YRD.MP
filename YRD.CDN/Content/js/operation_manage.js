//显示与隐藏表单提示内容(placeholder)
placeholder();

/*
* 营业记录
* */
//点击单号，进入详情页面
$('#om_operation_record').on('click','table a',function(e){
   e.preventDefault();
    var num = $(this).text();
    $('.breadcrumb').append('<li><b class="iconbg angle-right-solid"></b> <a href="">订单详情</a></li>');
    $('#om_operation_record').hide().siblings('.operation_record_detail').show();
    $('.operation_record_detail').find('.table-detail .order_num').text(num);
});
/*
* 外卖记录
* */
//点击订单号，查看详情页
$('#om_takeout_record').on('click','table a',function(e){
   e.preventDefault();
    var num = $(this).text();
    console.log(num);
    $('.breadcrumb').append('<li><b class="iconbg angle-right-solid"></b> <a href="">订单详情</a></li>');
    $('#om_takeout_record').hide().siblings('.takeout_record_detail').show();
    $('.takeout_record_detail').find('.table-detail .order_num').text(num);
});
/*
* 退菜赠菜记录
* */
//下拉框选择退菜和赠菜
$('#om_foodback_record').on('change','select.contents',function(){
   var val = $(this).val();
    $(this).val(val);
    $('#om_foodback_record').children('.'+val+'_content').show().siblings('div').hide();
});