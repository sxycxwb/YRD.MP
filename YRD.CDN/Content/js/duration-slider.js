/*购买时长 E*/
var F = new Object;
F.DurationConfig = {};
F.DurationConfig.data = [];
var vm_duration_config = [{"max":9,"min":1,"step":1,"unit":"month"},{"max":3,"min":1,"step":1,"unit":"year"},{"max":15,"min":1,"step":1,"unit":"day"}];
(function(){
    var i = 0, l = 0, _i = 0, _l = 0,
        step = 0,
        min = 0,
        max = 0,
        type;
    for(i = 0, l = vm_duration_config.length; i < l; i ++){
        type = vm_duration_config[i].unit;
        for(_i = vm_duration_config[i].min - 0, _l = vm_duration_config[i].max - 0; _i <= _l; _i ++){
            min = max;
            max = _i;
            max = type === 'year' ? max * 10 : max;
            step = max - min;
            F.DurationConfig.data.push({
                'unit': step,
                'min': min,
                'max': max
            });
        }
    }
    F.DurationConfig.defaultValue = 12;
})();

/*页面一加载，页面上显示单价&总价*/
$(function(){
    var mpLen = $('#online_upgrade').find('.mp_input').size();
    for(var i=0;i<mpLen;i++){
        var mp = $('#online_upgrade').find('.mp_input:eq('+i+')');
        var m = mp.val();
        mp.siblings('.mp_show').children('span').text(m);
        var tp = $('#online_upgrade').find('.tp_input:eq('+i+')');
        var t = tp.val();
        tp.parent().parent().siblings().find('.tp_show').text('￥'+ Number(t).toFixed(2));
    }
});

//微店版
var weiShop = new UC.slider("#uc-duration-weiShop",{
    data: F.DurationConfig.data,
    min: 0,
    bindInput: '.uc-duration'
});
weiShop.change(function () {
    //console.log(this.currentValue);
    //console.log('input',$('.uc-duration').val());
    /*var giveMonth = $('.gm_ws');
    if(this.currentValue == 10){
        giveMonth.val(2);
    }else{
        giveMonth.val(0);
    }
    var m_price = $('.mp_ws').val();
    var t_price = this.currentValue * m_price;
    $('.total_price_weiShop').html('￥'+ t_price.toFixed(2));
    $('.tp_ws').val(t_price.toFixed(2));*/
    var currentValue = this.currentValue;
    changeFun(currentValue,'.gm_ws','.mp_ws','.tp_ws','.total_price_weiShop');
});
//聚餐版
var jucan = new UC.slider("#uc-duration-jucan",{
    data: F.DurationConfig.data,
    min: 0,
    bindInput: '.uc-duration'
});
jucan.change(function () {
    var currentValue = this.currentValue;
    changeFun(currentValue,'.gm_jc','.mp_jc','.tp_jc','.total_price_jucan');
});
//宴会版
var banquet = new UC.slider("#uc-duration-banquet",{
    data: F.DurationConfig.data,
    min: 0,
    bindInput: '.uc-duration'
});
banquet.change(function () {
    var currentValue = this.currentValue;
    changeFun(currentValue,'.gm_bq','.mp_bq','.tp_bq','.total_price_banquet');
});
//云库存
var cloudInventory = new UC.slider("#uc-duration-cloudInventory",{
    data: F.DurationConfig.data,
    min: 0,
    bindInput: '.uc-duration'
});
cloudInventory.change(function () {
    var currentValue = this.currentValue;
    changeFun(currentValue,'.gm_ci','.mp_ci','.tp_ci','.total_price_cloudInventory');
});
/*给页面中的input赋值*/
function changeFun(currentValue,gmInput,mpInput,tpInput,tpTarget){
    var giveMonth = $(gmInput);
    if(currentValue == 10){
        giveMonth.val(2);
    }else{
        giveMonth.val(0);
    }
    var m_price = $(mpInput).val();
    var t_price = currentValue * m_price;
    $(tpTarget).html('￥'+ t_price.toFixed(2));
    $(tpInput).val(t_price.toFixed(2));
}