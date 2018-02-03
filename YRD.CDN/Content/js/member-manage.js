//显示与隐藏表单提示内容(placeholder)
placeholder();

/*
全部会员
*/
//点击更多条件按钮
$('#mm_all_members').on('click','button.more_conditions_btn',function(){
   $(this).parent().siblings('.more_conditions_dialog').show();
});
//关闭更多条件弹窗
$('.more_conditions_dialog').on('click','.tools>a.closed',function(e){
    e.preventDefault();
    $(this).parent().parent().parent().parent().hide();
});
$('.more_conditions_dialog .cancel_btn').click(function(){
   $('.more_conditions_dialog').hide();
});

//根据卡类型，点击卡号，进入卡详情
$('#mm_all_members').on('click','.table>tbody a.card-number',function(e){
    e.preventDefault();
    var num = $(this).text();
    var card = $(this).parent().siblings('.card-style').attr('data-card');
    var href = 'mm_am_'+card+'.html';
    $(this).attr('href',href);
    location.href = href;
});

//消费记录详情页-菜品列表显示
$('.expendcard-detail .dishes-btn').click(function(){
    $(this).siblings('.dishes-detail').slideToggle(1000);
});


/*
* 积分设置
* */
$('#mm_integral_set').on('click','.switchButton>input',function(){
    var check = $(this).prop('checked');
    if(check){
        $(this).parent().siblings('.hide').removeClass('hide').addClass('show');
    }else{
        $(this).parent().siblings('.show').addClass('hide').removeClass('show');
    }
});
$(function(){
    $('#mm_integral_set input[type="checkbox"]:checked')
        .parent().next('.hide').removeClass('hide').addClass('show');
    $('#mm_integral_set input[type="checkbox"]:not(:checked)')
        .parent().next('.show').removeClass('show').addClass('hide');
});



/*
* 规则设置
* */
//全选按钮
$('#mm_rule_set div.checkbox').on('click','input[type="checkbox"]',function(){
    var allcheck = $(this).prop('checked');
    $(this).parent().parent().siblings('ul').find('input[type="checkbox"]').prop('checked',allcheck);
    if(allcheck){
        $(this).parent().addClass('cb_check').parent().siblings('ul').find('input[type="checkbox"]').parent().addClass('cb_check');
    }else{
        $(this).parent().removeClass('cb_check').parent().siblings('ul').find('input[type="checkbox"]').parent().removeClass('cb_check');
    }
});
$(function(){
    $('#mm_rule_set div.checkbox input[type="checkbox"]:checked').parent('.cb').addClass('cb_check')
        .parent().siblings('ul').find('input[type="checkbox"]').prop('checked',true).parent().addClass('cb_check');
});
$('#mm_rule_set .item-caipin').on('click','input[type="checkbox"]',function(){
    var ul = $(this).parent().parent().parent();
    var len = ul.find('input').size();
    var check = ul.find('input:checked').size();
    if(check == len){
        ul.siblings('.checkbox').children('.cb').addClass('cb_check').children('input').prop('checked',true);
    }else{
        ul.siblings('.checkbox').children('.cb').removeClass('cb_check').children('input').prop('checked',false);
    }
});
$(function(){
    var cLen = $('#mm_rule_set .item-caipin input[type="checkbox"]:checked').size();
    var tLen = $('#mm_rule_set .item-caipin input[type="checkbox"]').size();
    if(cLen == tLen){
        $('#mm_rule_set div.checkbox').children('.cb').addClass('cb_check').children('input').prop('checked',true);
    }else{
        $('#mm_rule_set div.checkbox').children('.cb').removeClass('cb_check').children('input').prop('checked',false);
    }
});

//每种卡的名称自动生成
function inputBlur(card,target,input1,input2,input3,inputNow){
    $(inputNow).blur(function(){
        var v1 = $(input1).val();
        var v2 = $(input2).val();
        var v3 = $(input3).val();
        var reg1 = /^[0-9]+(\.[0-9]{1,2})?$/g;
        var reg2 = null;
        if(card == 'c'){
            reg2 = /^[0-9]+(\.[0-9]{1,2})?$/g;
        }else{
            reg2 = /^\d*$/g;
        }
        var reg3 = /^\d*$/g;
        if(!v1 == ''){
            if(!reg1.test(v1)){
                v1 = 0;
                $(input1).val(v1);
            }
        }else{
            v1 = 0;
            $(input1).val(v1);
        }
        if(!v2 == ''){
            if(!reg2.test(v2)){
                v2 = 0;
                $(input2).val(v2);
            }
        }else{
            v2 = 0;
            $(input2).val(v2);
        }
        if(!v3 == ''){
            if(!reg3.test(v3)){
                v3 = 0;
                $(input3).val(v3);
            }
        }else{
            v3 = 0;
            $(input3).val(v3);
        }
        if(card == 'c'){
            createRechargeCard(target,Number(v1).toFixed(2),Number(v2).toFixed(2));
        }else if(card == 'd'){
            if(v2 > 100){
                v2 = 0 ;
                $(input2).val(v2);
            }
            createDiscountCard(target,Number(v1).toFixed(2),Number(100 - v2));
        }else if(card == 't'){
            if(v2 > 100){
                v2 = 0 ;
                $(input2).val(v2);
            }
            createPrivilegeCard(target,Number(v1).toFixed(2),Number(100 - v2));
        }else if(card == 'h'){
            createVipCard(target,Number(v1).toFixed(2));
        }else if(card == 'j'){
            createTimeCard(target,Number(v1).toFixed(2),Number(v2),Number(v3));
        }
    });
}
function createRechargeCard(input,input1,input2){
    $(input).val('买'+ input1 +'元送'+ input2 +'元充值卡');
}
function createDiscountCard(input,input1,input2){
    var i2 = String(input2);
    if(i2.slice(-1) == 0){
        if(i2.slice(-2,-1) == 0){
            i2 = 0
        }else{
            i2 = i2.slice(-2,-1);
        }
    }
    $(input).val(input1 +'元打'+ i2 +'折打折卡');
}
function createPrivilegeCard(input,input1,input2){
    var i2 = String(input2);
    if(i2.slice(-1) == 0){
        if(i2.slice(-2,-1) == 0){
            i2 = 0
        }else{
            i2 = i2.slice(-2,-1);
        }
    }
    $(input).val(input1 +'元打'+ i2 +'折特惠卡');
}
function createVipCard(input,input1){
    $(input).val(input1 +'元会员卡');
}
function createTimeCard(input,input1,input2,input3){
    $(input).val(input1 +'元买' + input2 +'次送' + input3 + '次');
}
//充值卡
inputBlur('c','#mm_rule_set .cardName','#mm_rule_set .rcInput1','#mm_rule_set .rcInput2','','#mm_rule_set .rcInput1');
inputBlur('c','#mm_rule_set .cardName','#mm_rule_set .rcInput1','#mm_rule_set .rcInput2','','#mm_rule_set .rcInput2');
//打折卡
inputBlur('d','#mm_rule_set .cardName','#mm_rule_set .dcInput1','#mm_rule_set .dcInput2','','#mm_rule_set .dcInput1');
inputBlur('d','#mm_rule_set .cardName','#mm_rule_set .dcInput1','#mm_rule_set .dcInput2','','#mm_rule_set .dcInput2');
//特惠卡
inputBlur('t','#mm_rule_set .cardName','#mm_rule_set .pcInput1','#mm_rule_set .pcInput2','','#mm_rule_set .pcInput1');
inputBlur('t','#mm_rule_set .cardName','#mm_rule_set .pcInput1','#mm_rule_set .pcInput2','','#mm_rule_set .pcInput2');
//会员卡
inputBlur('h','#mm_rule_set .cardName','#mm_rule_set .vcInput1','','','#mm_rule_set .vcInput1');
//记次卡
inputBlur('j','#mm_rule_set .cardName','#mm_rule_set .tcInput1','#mm_rule_set .tcInput2','#mm_rule_set .tcInput3','#mm_rule_set .tcInput1');
inputBlur('j','#mm_rule_set .cardName','#mm_rule_set .tcInput1','#mm_rule_set .tcInput2','#mm_rule_set .tcInput3','#mm_rule_set .tcInput1');
inputBlur('j','#mm_rule_set .cardName','#mm_rule_set .tcInput1','#mm_rule_set .tcInput2','#mm_rule_set .tcInput3','#mm_rule_set .tcInput3');

