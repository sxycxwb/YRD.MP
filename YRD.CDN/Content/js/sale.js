//显示与隐藏表单提示内容(placeholder)
placeholder();

/*
* 优惠促销
* */
//点击不同优惠条件设置，启用下面的内容
$('#privilege_sale').on('change','.condi-select',function(){
    var c = $(this).find('option:selected').attr('data-condi');
    $('#privilege_sale').find('.condi-content').hide().siblings('.condi-content.condi-'+c).show();
});
