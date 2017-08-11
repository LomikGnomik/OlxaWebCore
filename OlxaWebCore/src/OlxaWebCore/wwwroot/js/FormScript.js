/*----------------------------------форма заявки ШАБЛОННЫЙ САЙТ----------------------------*/
//(function ($) {
//    return fn.floatedLabel = function (options) {
//        var defaults, settings;
//        defaults = {
//            focusClass: 'focus',
//            activeClass: 'active',
//            errorClass: 'error'
//        };
//        settings = $.extend({}, defaults, options);
//        return this.each(function () {
//            var element, input, label;
//            label = $(this);
//            if (!label.prop('for')) {
//                return;
//            }
//            element = label.parents('.field').first();
//            input = $("#" + (label.prop('for'))).filter('textarea, input, select').first();
//            return input.bind('checkval', function () {
//                return element.toggleClass(settings.activeClass, !!input.val());
//            }).on('keyup input change', function () {
//                element.removeClass(settings.errorClass);
//                return input.trigger('checkval');
//            }).on('blur', function () {
//                return element.removeClass(settings.focusClass);
//            }).on('focus', function () {
//                return element.addClass(settings.focusClass);
//            }).trigger('checkval');
//        });
//    };
//});

//$(function () {
//    $('.label').floatedLabel();
//    return $('.select').customSelect();
//});
