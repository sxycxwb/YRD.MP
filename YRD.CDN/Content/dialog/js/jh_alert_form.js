/**
 * 范围：今合网 用户后台
 * 内容：弹框套用表单
 * 作者：马英武
 * 时间：2016-08-01
 * 备注：
 *     1. 只适用于弹窗里边嵌套表单的情况，如果只是简单的信息提示，请查看 jh_alert_tips.js
 *     2. 此弹窗按钮可以按照需求来控制显示或者隐藏，如果不需要弹窗自带按钮时，请另行写弹窗关闭方法
 *     3. 此方法返回当前弹窗DOM元素
 */
(function ($) {
    $.jhNotifyForm = function (options) {
        var rand = parseInt(Math.random() * 100000000, 0),
            text_wrapper, asTime,
            $bar = {},
            settings = {};

        settings = $.extend({
            title           : "this is title",                                  // 弹窗标题
            jqObject        : null,                                             // 被弹的 jquery 对象
            html            : "<p>this is form</p>",                            // 被弹出的内容
            delay           : 3000,                                             // 显示延迟时间    
            animationSpeed  : 200,                                              // 运动时间
            cssClass        : '',                                               // 追加 class 类名
            close           : false,                                            // 是否显示底部 确定 取消 按钮
            btnText         : ['OK', 'Cancle'],                                 // 底部按钮文字

            onClickOk       : null,                                             // 确定的回调函数
            onClickCancle   : null,                                             // 取消的回调函数

        }, options);

        // Use these methods as private.
        this.fn.showNB = function () {
            $(this).stop().slideDown(asTime);
        };

        this.fn.hideNB = function () {

            $(this).stop().slideUp(asTime, function () {
                if ($bar.attr("id") === '__notifyBar' + rand) {
                    $(this).slideUp(asTime, function () {
                        $(this).remove();
                    });
                    
                } else {
                    $(this).slideUp(asTime);
                }
            });

            $(".mask").fadeOut(asTime).remove();

        };

        if (settings.jqObject) {
            settings.html = settings.jqObject.html();
        }
        console.log(settings.html);
        $bar = $('<div class = "modal-dialog"></div>')
                .addClass(settings.cssClass)
                .attr("id", "__notifyBar" + rand)

        var baseStr = '<div class="color-line"></div><div class="modal-header"><h4 class="modal-title">'+ settings.title +'</h4></div><div class="modal-body">'+ settings.html +'</div>'

        var btnStr = '<div class="modal-footer"><button class="btn btn-primary ok" type="button">'+ settings.btnText[0] +'</button><button class="btn btn-default cancel" type="button">'+ settings.btnText[1] +'</button></div>'

        if(settings.btnText.length == 1){

            btnStr = '<div class="modal-footer"><button class="btn btn-primary ok" type="button">'+ settings.btnText[0] +'</button></div>'

        }




        text_wrapper = $(baseStr + btnStr )

        var mask = $('<div class = "mask"></div>')

        $bar.html(text_wrapper).hide();

        $('body').append(mask)

        var id = $bar.attr("id");
        switch (settings.animationSpeed) {
            case "slow":
                asTime = 600;
                break;
            case "default":
            case "normal":
                asTime = 400;
                break;
            case "fast":
                asTime = 200;
                break;
            default:
                asTime = settings.animationSpeed;
        }
        $("body").prepend($bar);
        
        // 判断自动消失 并且控制底部按钮
        if ( !settings.close) {
            
            $(".modal-footer").hide()

        }

        // 检测页面中正在出现的弹框，并且立刻结束上一次弹框的运动，出现下一个
        if ($('.modal-dialog:visible').length > 0) {
            $('.modal-dialog:visible').stop().slideUp(asTime, function () {
                $bar.showNB();
            });
        } else {
            $bar.showNB();
        }

        $bar.find(".ok").click(function(){

            if(settings.onClickOk != null){

                settings.onClickOk();
                
                $bar.hideNB();

            }else{

                $bar.hideNB();
                
            }


        });

        $bar.find(".cancel").click(function(){

            if(settings.onClickCancle != null){

                settings.onClickCancle();

                $bar.hideNB();
                
            }else{

                $bar.hideNB();
                
            }


        });
        
        return $bar;
    };
})(jQuery);