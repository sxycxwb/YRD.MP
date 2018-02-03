//设置页面主体的高度
var bodyHeight = function(){
    var wHeight = $(window).height();
    var header = $('.header').outerHeight();
    var footer = $('.footer').outerHeight();
    //console.log(wHeight,header,footer);
    //console.log(wHeight-header-footer);
    $('.page-container').height(wHeight-header-footer);
};