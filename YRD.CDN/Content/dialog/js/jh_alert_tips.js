/**
 * 范围：今合网 用户后台
 * 内容：提示信息类弹框（不包括弹框套用表单）
 * 作者：马英武
 * 时间：2016-07-28
 * 备注：
 *     1. 只适用于简单的信息提示的情况，如果只是弹窗里边嵌套表单，请查看 jh_alert_form.js
 *     2. 此弹窗按钮不显示时，可自动消失，无需重写弹窗关闭方法
 *     3. 返回当前弹窗DOM元素
 */
(function ($) {
    'use strict';

    $.jhNotifyBar = function (options) {
        var rand = parseInt(Math.random() * 100000000, 0),
            text_wrapper, asTime,
            $bar = {},
            settings = {};

        settings = $.extend({
            type            : 'success',                                        // 弹框类型（success, error, warning）
            mainMsg         : 'your main tips message',                         // 主要内容
            detailMsg       : 'your detail tips message',                       // 详细内容
            delay           : 2000,                                             // 显示延迟时间    
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
            $bar = settings.jqObject;
            settings.html = $bar.html();
        } else {            
            $bar = $('<div></div>')
                    .addClass("jh_tips_form")
                    .addClass(settings.cssClass)
                    .attr("id", "__notifyBar" + rand)

            var btnStr = '<div class="jh_button_container"><button class = "ok">'+ settings.btnText[0] +'</button><button class = "cancle">' + settings.btnText[1] + '</button></div>'

            if(settings.btnText.length == 1){

                if(settings.btnText[0].toLowerCase() == "ok" || settings.btnText[0] == "确定" || settings.btnText[0] == "提交" ){

                    btnStr = '<div class="jh_button_container"><button class = "ok">'+ settings.btnText[0] +'</button></div>'

                }else{

                    btnStr = '<div class="jh_button_container"><button class = "cancle">'+ settings.btnText[0] +'</button></div>'

                }

            }

            switch(settings.type.toLowerCase()){

                case 'warning' :
                    
                    var iconStr = '<div class="fa fa-circle-thin circle_box circle_wraning"><span class="fa fa-exclamation"></span></div>';
                    break;

                case 'success' :
                    var iconStr = '<div class="fa fa-circle-thin circle_box circle_success"><span class="fa fa-check"></span></div>';
                    break;

                case 'error' :
                    var iconStr = '<div class="fa fa-circle-thin circle_box circle_error"><span class="fa fa fa-close"></span></div>';
                    break;
            }

            if(typeof settings.mainMsg != "string"){

                var mainMsg = settings.mainMsg.html();

            }else{

                var mainMsg = settings.mainMsg;

            }

            if(typeof settings.detailMsg != "string"){

                var detailMsg = settings.detailMsg.html();

            }else{

                var detailMsg = settings.detailMsg;

            }

            text_wrapper = $(iconStr + '<h2>'+ mainMsg +'</h2><p>'+ detailMsg +'</p>'+ btnStr )

            var mask = $('<div class = "mask"></div>')

        }

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
            
            $(".jh_button_container").hide()

            setTimeout(function () {
                $bar.hideNB(settings.delay);
            }, settings.delay + asTime);

        }

        // 检测页面中正在出现的弹框，并且立刻结束上一次弹框的运动，出现下一个
        if ($('.jh_tips_form:visible').length > 0) {
            $('.jh_tips_form:visible').stop().slideUp(asTime, function () {
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

        $bar.find(".cancle").click(function(){

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