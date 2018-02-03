/*
对数字的处理：每三位加逗号
*/
function formatNum(str){
    var newStr = "";
    var count = 0;
    if(str.indexOf(".")==-1){   //无小数点
        for(var i=str.length-1;i>=0;i--){
            if(count % 3 == 0 && count != 0){
                newStr = str.charAt(i) + "," + newStr;
            }else{
                newStr = str.charAt(i) + newStr;
            }
            count++;
        }
        str = newStr + ".00"; //自动补小数点后两位
        return str;
    }else{  //有小数点
        for(var i = str.indexOf(".")-1;i>=0;i--){
            if(count % 3 == 0 && count != 0){
                newStr = str.charAt(i) + "," + newStr;
            }else{
                newStr = str.charAt(i) + newStr; //逐个字符相接起来
            }
            count++;
        }
        str = newStr + (str + "00").substr((str + "00").indexOf("."),3);
        return str;
    }
}
function addThreePoint(container,target){
    var balanceBox = $(container).find(target);
    var balance = balanceBox.text();
    var newBalance = formatNum(balance);
    balanceBox.text(newBalance);
}
/*
账户余额--账户余额
* */
addThreePoint('#account_balance','.balanceBox>b');
/*
 三级分销--分销账户
 * */
addThreePoint('#promise_money','.balanceBox>b');
/*
短信余额--短信余额
* */
$(function(){
    var messageNumBox = $('#message_balance').find('.messageNum').children('b');
    var messageNum = messageNumBox.text();
    var newMessageNum = formatNum(messageNum);
    messageNumBox.text(newMessageNum.slice(0,newMessageNum.indexOf('.')));
});
/*
三级分销--返利设置
*/
//返利比例不低于8
$('#td_rebate_set').on('blur','.setRate',function(){
    var setRate = $(this).val();
    var reg = /^[0-9]+(\.[0-9]{1,2})?$/g;
    if(setRate !== ''){
        if(!reg.test(setRate) || setRate < 8){
            var w = '<span class="regTip regWrong">比例不符合要求</span>';
            $(this).siblings('.regTip').remove();
            $(this).parent().append(w);
        }else{
            $(this).siblings('.regTip').remove();
            var userRate = Number(setRate) - 1.8;
            $('#td_rebate_set .userRate').html(userRate);
        }
    }else{
        $(this).siblings('.regTip').remove();
        $(this).val('8');
    }
});
/*
三级分销--签署合同
*/
//点击'我同意'后，按钮可以点击
$('#td_sign_contract').on('click','#agreeBtn',function(){
    var greyBtn = $('#td_sign_contract .agree-btns').children('button.grey');
    var blueBtn = $('#td_sign_contract .agree-btns').children('button.blue');
    var c = $(this).prop('checked');
    if(c){
        $(this).prop('checked',true).parent().addClass('cb_check');
        greyBtn.addClass('hide');
        blueBtn.removeClass('hide');
    }else{
        $(this).prop('checked',false).parent().removeClass('cb_check');
        greyBtn.removeClass('hide');
        blueBtn.addClass('hide');
    }
});