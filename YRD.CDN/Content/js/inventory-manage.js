placeholder();
/*
* 基础设置
* */

/*
 物料设置
 */
//添加计量单位
$(function(){
    $('#material_set input.unitStyle:checked').hasClass('mainUnit') ?
        $('#material_set').find('.viceUnitDialog').hide() :
        $('#material_set').find('.viceUnitDialog').show();
});
$('#material_set').on('click','input.mainUnit',function(){
    $(this).parent().parent().parent().parent()
        .siblings('.viceUnitDialog').hide();
});
$('#material_set').on('click','input.viceUnit',function(){
    $(this).parent().parent().parent().parent()
        .siblings('.viceUnitDialog').show();
});
//监听'换算比例'表单
$('input.exchangeRate').blur(function(){
    var v = $(this).val();
    var reg = /^\+?[1-9]\d*$/;
    if(!reg.test(v)){
        alert('换算比例必须是大于0的整数！');
        $(this).val('');
    }
});

/*菜品成本*/
//点击'待添加'
$('#food_cost').on('click','table .add_fc',function(e){
    e.preventDefault();
    var h = $(this).attr('href');
    location.href = h;
});
//页面一开始显示菜品类型
$(function(){
    if($('#food_cost input[name="FinishType"]').val() == 1){
        $('#food_cost input[name="FinishType"]').siblings().text('成品');
        $('#food_cost .vicem_cost').addClass('hide');
    }else{
        $('#food_cost input[name="FinishType"]').siblings().text('半成品');
        $('#food_cost .vicem_cost').removeClass('hide');
    }
});
//页面一开始的'添加进来的主料和辅料'的个数
$(function(){
    if($('#food_cost .item_mainm').size() > 0){
        $('#food_cost .item_mainmTitle').show();
    }
    if($('#food_cost .item_vicem').size() > 0){
        $('#food_cost .item_vicemTitle').show();
    }
});
//'待添加'下，点击'添加主料或者辅料'按钮，显示弹框
$('#food_cost .add_mainm_btn').click(function(e){
    e.preventDefault();
    $('.add_mainm_dialog').show();
});
$('#food_cost .add_vicem_btn').click(function(e){
    e.preventDefault();
    $('.add_vicem_dialog').show();
});
//关闭主料和辅料的添加弹出框
$('.add_material_dialog').on('click','.close_mdialog',function(){
    $(this).parent().parent('.add_material_dialog').hide();
});
//'添加主料','添加辅料',改变数量和单价，计算小计
$('#food_cost').on('change','.add_material_dialog input.m_quantity',function(){
   var quan = $(this).val();
    var price = $(this).parent().siblings().find('.m_price').text();
    var total = quan * price;
    $(this).parent().siblings().find('.m_total_price').text(total.toFixed(2));
});
//全局变量
var material_cost = 0;
var mainm_cost = 0;
var vicem_cost = 0;
//一开始显示的主料成本、辅料成本、物料成本
$(function(){
    $('#food_cost .material_cost').find('.costs>span').text(
        Number($('#food_cost .material_cost .input_mcost').val()).toFixed(2)
    );
    material_cost += Number($('#food_cost .material_cost .input_mcost').val());
    $('#food_cost .mainm_cost').find('.costs>span').text(
        Number($('#food_cost .mainm_cost .input_mmcost').val()).toFixed(2)
    );
    mainm_cost += Number($('#food_cost .mainm_cost .input_mmcost').val());
    $('#food_cost .vicem_cost').find('.costs>span').text(
        Number($('#food_cost .vicem_cost .input_vmcost').val()).toFixed(2)
    );
    vicem_cost += Number($('#food_cost .vicem_cost .input_vmcost').val());
    //如果是成品，只保留一条添加的主料
    var foodType = $('#food_cost').find('input[name="FinishType"]').val();
    if(foodType == 1){
        $('#food_cost').find('.item_mainm:not(:eq(0))').remove();
    }
});
//'添加主料弹框'下的添加按钮
$('.add_mainm_dialog').on('click','a.m_add_material',function(e){
   e.preventDefault();
    var foodType = $('#food_cost').find('input[name="FinishType"]').val();
    var td = $(this).parent();
    var materialId = $(this).siblings('.m_materialid').text();
    var mainType = td.siblings().find('.m_mainType').text();
    var childType = td.siblings().find('.m_childType').text();
    var name = td.siblings().find('.m_name').text();
    var guige = td.siblings().find('.m_guige').text();
    var unit = td.siblings().find('.m_unit').text();
    var quan = td.siblings().find('input.m_quantity').val();
    var price = td.siblings().find('.m_price').text();
    var total = td.siblings().find('.m_total_price').text();
    var mainm_num = $('#food_cost').find('.item_mainm').size();
    //显示主料标题
    $('#food_cost .item_mainmTitle').show();
    if(mainm_num == 0){
        var mainHtml1 =
            '<div class="control-group item_mainm">'+
            '<label class="control-label"></label>'+
            '<div class="controls">'+
            '<input type="hidden" name="FirstMaterialID" value="' + materialId + '"/>' +
            '<div class="span2 percent12 mainm_category">'+mainType+'</div>'+
            '<div class="span2 percent12 mainm_smallCategory">'+childType+'</div>'+
            '<div class="span2 percent12 mainm_name">'+name+'</div>'+
            '<div class="span2 percent8 mainm_guige">'+guige+'</div>'+
            '<input type="hidden" name="FirstTitle" value="'+name+'"/>'+
            '<input type="hidden" name="FirstSpecName" value="'+guige+'"/>'+
            '<input type="hidden" name="FirstShopID"/>'+
            '<input type="hidden" name="FirstMaterialTypeMainID"/>'+
            '<input type="hidden" name="FirstMaterialTypeMainName" value="'+mainType+'"/>'+
            '<input type="hidden" name="FirstMaterialTypeChildID"/>'+
            '<input type="hidden" name="FirstMaterialTypeChildName" value="'+childType+'"/>'+
            '<div class="span2 percent8 mainm_unit">'+unit+'</div>'+
            '<input type="hidden" name="FirstMaterialUnitID"/>'+
            '<input type="hidden" name="FirstMaterialUnitName" value="'+unit+'"/>'+
            '<div class="span2 percent8 mainm_quantity">'+quan+'</div>'+
            '<input type="hidden" name="FirstCountNum" value="'+quan+'"/>'+
            '<div class="span2 percent8 mainm_price"><span>'+price+'</span>元</div>'+
            '<input type="hidden" name="FirstAveragePrice" value="'+price+'"/>'+
            '<input type="hidden" name="FirstReferPrice"/>'+
            '<div class="span2 percent8 mainm_total"><span>'+total+'</span>元</div>'+
            '<div class="span2 percent8"><a href="javascript:;" class="c860 remove_material">移去</a></div>'+
            '</div>'+
            '</div>';
        $('.add_mainm_dialog').before(mainHtml1);
    }else{
        if(foodType == 1){  //成品
            //只允许增加一条
            return;
        }else{  //半成品
            for(var i=0;i<mainm_num;i++){
                var imm = $('#food_cost').find('.item_mainm:eq('+i+')');
                var mainm_name = imm.find('.mainm_name').text();
                var mainm_unit = imm.find('.mainm_unit').text();
                var mainm_total = imm.find('.mainm_total').children('span').text();
                if(name ==  mainm_name && unit == mainm_unit){
                    imm.find('.mainm_quantity').text(quan);
                    imm.find('input[name="FirstCountNum"]').val(quan);
                    imm.find('.mainm_price').children('span').text(price);
                    imm.find('.mainm_total').children('span').text(total);
                    //价格变动：
                    //主料成本
                    mainm_cost += Number(total - mainm_total);
                    $('#food_cost .mainm_cost').find('.costs>span').text(mainm_cost.toFixed(2));
                    $('#food_cost .mainm_cost').find('.input_mmcost').val(mainm_cost.toFixed(2));
                    //总成本
                    material_cost = Number(mainm_cost)+ Number(vicem_cost);
                    $('#food_cost .material_cost').find('.costs>span').text(material_cost.toFixed(2));
                    $('#food_cost .material_cost').find('.input_mcost').val(material_cost.toFixed(2));
                    return;
                }
            }
            var mainHtml2 =
                '<div class="control-group item_mainm">'+
                '<label class="control-label"></label>'+
                '<div class="controls">'+
                '<input type="hidden" name="FirstMaterialID" value="' + materialId + '"/>' +
                '<div class="span2 percent12 mainm_category">'+mainType+'</div>'+
                '<div class="span2 percent12 mainm_smallCategory">'+childType+'</div>'+
                '<div class="span2 percent12 mainm_name">'+name+'</div>'+
                '<div class="span2 percent8 mainm_guige">'+guige+'</div>'+
                '<input type="hidden" name="FirstTitle" value="'+name+'"/>'+
                '<input type="hidden" name="FirstSpecName" value="'+guige+'"/>'+
                '<input type="hidden" name="FirstShopID"/>'+
                '<input type="hidden" name="FirstMaterialTypeMainID"/>'+
                '<input type="hidden" name="FirstMaterialTypeMainName" value="'+mainType+'"/>'+
                '<input type="hidden" name="FirstMaterialTypeChildID"/>'+
                '<input type="hidden" name="FirstMaterialTypeChildName" value="'+childType+'"/>'+
                '<div class="span2 percent8 mainm_unit">'+unit+'</div>'+
                '<input type="hidden" name="FirstMaterialUnitID"/>'+
                '<input type="hidden" name="FirstMaterialUnitName" value="'+unit+'"/>'+
                '<div class="span2 percent8 mainm_quantity">'+quan+'</div>'+
                '<input type="hidden" name="FirstCountNum" value="'+quan+'"/>'+
                '<div class="span2 percent8 mainm_price"><span>'+price+'</span>元</div>'+
                '<input type="hidden" name="FirstAveragePrice" value="'+price+'"/>'+
                '<input type="hidden" name="FirstReferPrice"/>'+
                '<div class="span2 percent8 mainm_total"><span>'+total+'</span>元</div>'+
                '<div class="span2 percent8"><a href="javascript:;" class="c860 remove_material">移去</a></div>'+
                '</div>'+
                '</div>';
            $('.add_mainm_dialog').before(mainHtml2);
        }
    }

    //主料成本增加
    mainm_cost += Number(total);
    $('#food_cost .mainm_cost').find('.costs>span').text(mainm_cost.toFixed(2));
    $('#food_cost .mainm_cost').find('.input_mmcost').val(mainm_cost.toFixed(2));
    //总成本
    material_cost = Number(mainm_cost)+ Number(vicem_cost);
    $('#food_cost .material_cost').find('.costs>span').text(material_cost.toFixed(2));
    $('#food_cost .material_cost').find('.input_mcost').val(material_cost.toFixed(2));
});
//'添加辅料弹框'下的添加按钮
$('.add_vicem_dialog').on('click','a.m_add_material',function(e){
    e.preventDefault();
    var td = $(this).parent();
    var materialId = $(this).siblings('.m_materialid').text();
    var mainType = td.siblings().find('.m_mainType').text();
    var childType = td.siblings().find('.m_childType').text();
    var name = td.siblings().find('.m_name').text();
    var guige = td.siblings().find('.m_guige').text();
    var unit = td.siblings().find('.m_unit').text();
    var quan = td.siblings().find('input.m_quantity').val();
    var price = td.siblings().find('.m_price').text();
    var total = td.siblings().find('.m_total_price').text();
    var vicem_num = $('#food_cost').find('.item_vicem').size();
    //显示辅料标题
    $('#food_cost .item_vicemTitle').show();
    if(vicem_num == 0){
        var viceHtml1 =
            '<div class="control-group item_vicem">'+
            '<label class="control-label"></label>'+
            '<div class="controls">'+
            '<input type="hidden" name="SecondMaterialID" value="' + materialId + '"/>' +
            '<div class="span2 percent12 vicem_category">'+mainType+'</div>'+
            '<div class="span2 percent12 vicem_smallCategory">'+childType+'</div>'+
            '<div class="span2 percent12 vicem_name">'+name+'</div>'+
            '<div class="span2 percent8 vicem_guige">'+guige+'</div>'+
            '<input type="hidden" name="SecondTitle" value="'+name+'"/>'+
            '<input type="hidden" name="SecondSpecName" value="'+guige+'"/>'+
            '<input type="hidden" name="SecondShopID"/>'+
            '<input type="hidden" name="SecondMaterialTypeMainID"/>'+
            '<input type="hidden" name="SecondMaterialTypeMainName" value="'+mainType+'"/>'+
            '<input type="hidden" name="SecondMaterialTypeChildID"/>'+
            '<input type="hidden" name="SecondMaterialTypeChildName" value="'+childType+'"/>'+
            '<div class="span2 percent8 vicem_unit">'+unit+'</div>'+
            '<input type="hidden" name="SecondMaterialUnitID"/>'+
            '<input type="hidden" name="SecondMaterialUnitName" value="'+unit+'"/>'+
            '<div class="span2 percent8 vicem_quantity">'+quan+'</div>'+
            '<input type="hidden" name="SecondCountNum" value="'+quan+'"/>'+
            '<div class="span2 percent8 vicem_price"><span>'+price+'</span>元</div>'+
            '<input type="hidden" name="SecondAveragePrice" value="'+price+'"/>'+
            '<input type="hidden" name="SecondReferPrice"/>'+
            '<div class="span2 percent8 vicem_total"><span>'+total+'</span>元</div>'+
            '<div class="span2 percent8"><a href="javascript:;" class="c860 remove_material">移去</a></div>'+
            '</div>'+
            '</div>';
        $('.add_vicem_dialog').before(viceHtml1);
    }else{
        for(var i=0;i<vicem_num;i++){
            var ivm = $('#food_cost').find('.item_vicem:eq('+i+')');
            var vicem_name = ivm.find('.vicem_name').text();
            var vicem_unit = ivm.find('.vicem_unit').text();
            var vicem_total = ivm.find('.vicem_total').children('span').text();
            if(name ==  vicem_name && unit == vicem_unit){
                ivm.find('.vicem_quantity').text(quan);
                ivm.find('input[name="SecondCountNum"]').val(quan);
                ivm.find('.vicem_price').children('span').text(price);
                ivm.find('.vicem_total').children('span').text(total);
                //价格变动：
                //辅料成本
                vicem_cost += Number(total - vicem_total);
                $('#food_cost .vicem_cost').find('.costs>span').text(vicem_cost.toFixed(2));
                $('#food_cost .vicem_cost').find('.input_vmcost').val(vicem_cost.toFixed(2));
                //总成本
                material_cost = Number(mainm_cost)+ Number(vicem_cost);
                $('#food_cost .material_cost').find('.costs>span').text(material_cost.toFixed(2));
                $('#food_cost .material_cost').find('.input_mcost').val(material_cost.toFixed(2));
                return;
            }
        }
        var viceHtml2 =
            '<div class="control-group item_vicem">'+
            '<label class="control-label"></label>'+
            '<div class="controls">'+
            '<input type="hidden" name="SecondMaterialID" value="' + materialId + '"/>' +
            '<div class="span2 percent12 vicem_category">'+mainType+'</div>'+
            '<div class="span2 percent12 vicem_smallCategory">'+childType+'</div>'+
            '<div class="span2 percent12 vicem_name">'+name+'</div>'+
            '<div class="span2 percent8 vicem_guige">'+guige+'</div>'+
            '<input type="hidden" name="SecondTitle" value="'+name+'"/>'+
            '<input type="hidden" name="SecondSpecName" value="'+guige+'"/>'+
            '<input type="hidden" name="SecondShopID"/>'+
            '<input type="hidden" name="SecondMaterialTypeMainID"/>'+
            '<input type="hidden" name="SecondMaterialTypeMainName" value="'+mainType+'"/>'+
            '<input type="hidden" name="SecondMaterialTypeChildID"/>'+
            '<input type="hidden" name="SecondMaterialTypeChildName" value="'+childType+'"/>'+
            '<div class="span2 percent8 vicem_unit">'+unit+'</div>'+
            '<input type="hidden" name="SecondMaterialUnitID"/>'+
            '<input type="hidden" name="SecondMaterialUnitName" value="'+unit+'"/>'+
            '<div class="span2 percent8 vicem_quantity">'+quan+'</div>'+
            '<input type="hidden" name="SecondCountNum" value="'+quan+'"/>'+
            '<div class="span2 percent8 vicem_price"><span>'+price+'</span>元</div>'+
            '<input type="hidden" name="SecondAveragePrice" value="'+price+'"/>'+
            '<input type="hidden" name="SecondReferPrice"/>'+
            '<div class="span2 percent8 vicem_total"><span>'+total+'</span>元</div>'+
            '<div class="span2 percent8"><a href="javascript:;" class="c860 remove_material">移去</a></div>'+
            '</div>'+
            '</div>';
        $('.add_vicem_dialog').before(viceHtml2);
    }
    //辅料成本增加
    vicem_cost += Number(total);
    $('#food_cost .vicem_cost').find('.costs>span').text(vicem_cost.toFixed(2));
    $('#food_cost .vicem_cost').find('.input_vmcost').val(vicem_cost.toFixed(2));
    //总成本
    material_cost = Number(vicem_cost)+Number(mainm_cost);
    $('#food_cost .material_cost').find('.costs>span').text(material_cost.toFixed(2));
    $('#food_cost .material_cost').find('.input_mcost').val(material_cost.toFixed(2));
});
//'添加弹框'下的移去按钮
$('#food_cost').on('click','a.remove_material',function(e){
   e.preventDefault();
    var m_total = $(this).parent().siblings('.mainm_total').children('span').text();
    var v_total = $(this).parent().siblings('.vicem_total').children('span').text();
    $(this).parent().parent().parent().remove();
    //隐藏主料标题
    var mainmLen = $('#food_cost .item_mainm').size();
    if(mainmLen <= 0){
        $('#food_cost .item_mainmTitle').hide();
    }
    //隐藏辅料标题
    var vicemLen = $('#food_cost .item_vicem').size();
    if(vicemLen <= 0){
        $('#food_cost .item_vicemTitle').hide();
    }
    //主料成本减少
    mainm_cost -= Number(m_total);
    $('#food_cost .mainm_cost').find('.costs>span').text(mainm_cost.toFixed(2));
    $('#food_cost .mainm_cost').find('.input_mmcost').val(mainm_cost.toFixed(2));
    //辅料成本减少
    vicem_cost -= Number(v_total);
    $('#food_cost .vicem_cost').find('.costs>span').text(vicem_cost.toFixed(2));
    $('#food_cost .vicem_cost').find('.input_vmcost').val(vicem_cost.toFixed(2));
    //总成本
    material_cost = Number(vicem_cost)+Number(mainm_cost);
    $('#food_cost .material_cost').find('.costs>span').text(material_cost.toFixed(2));
    $('#food_cost .material_cost').find('.input_mcost').val(material_cost.toFixed(2));
});

/*期初建账*/
//计算小计
function calcTotalCost(input){
    $('#initial_account').on('blur',input,function(){
        var v1 = $(this).val();
        var v2 = $(this).parent().siblings().find('input').val();
        var total = Number(v1) * Number(v2);
        $(this).parent().siblings().find('.totalCost').text(Number(total).toFixed(2));
    });
}
calcTotalCost('.initialCount');
calcTotalCost('.costAverage');
//选择库房
$('#initial_account form').on('click','input.warehouse',function(){
    var p = $(this).parent().parent();
    $(this).prop('checked',true).parent('.rd').addClass('rd_check');
    p.siblings().find('input').prop('checked',false).parent('.rd_check').removeClass('rd_check');
    var val = $(this).val();
    var next = $('#initial_account form').find('.nextBtn');
    var href = next.attr('href');
    var href1 = href.slice(0,href.indexOf('=')+1) + val;
    next.attr('href',href1);
});

/*
* 订单中心
* */
$(function(){
    $('.selectime input[data-time="day"]:checked').parent().parent().parent()
        .siblings('.startTime').val(getDay()[0])
        .siblings('.endTime').val(getDay()[1]);
    $('.selectime input[data-time="week"]:checked').parent().parent().parent()
        .siblings('.startTime').val(getWeek()[0])
        .siblings('.endTime').val(getWeek()[1]);
    $('.selectime input[data-time="month"]:checked').parent().parent().parent()
        .siblings('.startTime').val(getMonth()[0])
        .siblings('.endTime').val(getMonth()[1]);
});
//点击时间选择为'自定义'，才显示日期框
$('.selectime').on('click','input',function(){
    var parent = $(this).parent().parent().parent('.selectime');
    var dt = $(this).attr('data-time');
    if(dt == 'auto'){
        var c = $(this).prop('checked');
        if(c){
            parent.siblings().show();
            $('#d1').blur(function(){
                parent.siblings('.startTime').val(($(this).val()+' 00:00:00'));
            });
            $('#d2').blur(function(){
                parent.siblings('.endTime').val(($(this).val()+' 00:00:00'));
            });
        }else{
            parent.siblings().hide();
        }
    }else if(dt == 'day'){
        parent.siblings('.startTime').val(getDay()[0]);
        parent.siblings('.endTime').val(getDay()[1]);
        parent.siblings().hide();
    }else if(dt == 'week'){
        parent.siblings('.startTime').val(getWeek()[0]);
        parent.siblings('.endTime').val(getWeek()[1]);
        parent.siblings().hide();
    }else if(dt == 'month'){
        parent.siblings('.startTime').val(getMonth()[0]);
        parent.siblings('.endTime').val(getMonth()[1]);
        parent.siblings().hide();
    }
});
/*获得当天时间*/
function getDay(){
    var date = new Date();
    var time = date.getTime();
    var nextDay = new Date(time + 24*3600*1000);
    var startDate = transferDate(date);
    var endDate = transferDate(nextDay);
    return [startDate,endDate];
}
/*获得本周时间*/
function getWeek(Fn) {
    var date = new Date();
    var today = date.getDay();
    var stepSunDay = -today + 1;
    if (today == 0) {
        stepSunDay = -7;
    }
    var stepMonday = 7 - today;
    var time = date.getTime();
    var monday = new Date(time + stepSunDay * 24 * 3600 * 1000);
    var sunday = new Date(time + stepMonday * 24 * 3600 * 1000 + 24*3600*1000);
    var startDate = transferDate(monday);
    var endDate = transferDate(sunday);
    return [startDate,endDate];
}
/*获得本月时间*/
function getMonth(Fn) {
    var start = new Date();
    start.setDate(1);
    var date = new Date();
    var currentMonth = date.getMonth();
    var nextMonth = ++currentMonth;
    var nextMonthFirstDay = new Date(date.getFullYear(), nextMonth, 1);
    var oneDay = 1000 * 60 * 60 * 24;
    var end = new Date(nextMonthFirstDay - oneDay + 24*3600*1000);
    var startDate = transferDate(start);
    var endDate = transferDate(end);
    return [startDate,endDate];
}
/*日期转换方法*/
function transferDate(date) {
    var year = date.getFullYear();
    var month = date.getMonth() + 1;
    var day = date.getDate();
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (day >= 0 && day <= 9) {
        day = "0" + day;
    }
    var dateString = year + '-' + month + '-' + day + ' 00:00:00';
    return dateString;
}


//点击签名图，显示图片
$('#im_order_center').on('click','.signImg',function(e){
    e.preventDefault();
    $(this).parent().parent().siblings('.modal-backdrop').show();
});
$('.modal-backdrop').on('click','.closed',function(e){
   e.preventDefault();
    $(this).parent().parent().hide();
});

/*出库订单*/
//自动出库详情--根据类型进入产品页
$('#outbound_order').on('click','table>tbody a.autonum',function(e){
    e.preventDefault();
    location.href = $(this).attr('href');
});
/*盘点订单*/
//选中原料名称，改变数量和按钮激活
$('#inventory_order>form').on('click', '.material_name input[type="checkbox"]', function () {
    var c = $(this).prop('checked');
    if (c) {
        $(this).parent('.cb').addClass('cb_check');
    } else {
        $(this).parent('.cb').removeClass('cb_check');
    }
   var num = $('.material_name').find('input:checked').size();
    $('.material_name').find('p>span').text(num);
    if(num!==0){
        $('#inventory_order>form').find('.form-actions>button').attr('disabled',false);
    }else{
        $('#inventory_order>form').find('.form-actions>button').attr('disabled',true);
    }
});
$(function(){
    $('.material_name .material_checked').find('span').text(
        $('.material_name').find('input:checked').size()
    );
});
//点击'原料名称'中的'全选'按钮
$('#inventory_order').on('click','.material_checked .checkAllMaterial',function(e){
    e.preventDefault();
    var pBox = $(this).parent();
    var inputBox = pBox.siblings();
    var inputLen = inputBox.find('input.cbrd').size();
    inputBox.find('input.cbrd').prop('checked',true).parent('.cb').addClass('cb_check');
    pBox.find('span').text(inputLen);
    $(this).addClass('hide');
    $(this).siblings('.cancelCheckAllMaterial').removeClass('hide');
});
//点击'原料名称'中的'反选'按钮
$('#inventory_order').on('click','.material_checked .cancelCheckAllMaterial',function(e){
    e.preventDefault();
    var pBox = $(this).parent();
    var inputBox = pBox.siblings();
    inputBox.find('input.cbrd').prop('checked',false).parent('.cb').removeClass('cb_check');
    pBox.find('span').text(0);
    $(this).addClass('hide');
    $(this).siblings('.checkAllMaterial').removeClass('hide');
});

