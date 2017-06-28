/*----------------------------------------фиксированное меню---------------------------*/
var h_hght = 100; // высота шапки
var h_mrg = 0;    // отступ когда шапка уже не видна
$(function () {
    var elem = $('.navigation');
    var top = $(this).scrollTop();
    if (top > h_hght) {
        elem.css('top', h_mrg);
    }
    $(window).scroll(function () {
        top = $(this).scrollTop();
        if (top + h_mrg < h_hght) {
            elem.css('top', (h_hght - top));
            elem.css('box-shadow', ('none'));
            elem.css('border-bottom', ('none'));
        }
        else {
            elem.css('top', h_mrg);
            elem.css('border-bottom', ('1px solid @color-gray-light'));
            elem.css('box-shadow', ('0 6px 4px -4px rgba(0, 0, 0, .2'));

        }
    });
});
/*---------------------------------------кнопка меню для мобильных----------------------*/
$(document).ready(function () {

    $('.menu-trigger').click(function () {
        $('.main-menu').slideToggle(500);
    });
    $(window).resize(function () {
        if ($(window).width() > 500) {
            $('.main-menu').removeAttr('style');
        }
    });
});
/*--------------------------------прокрутка наверх--------------------------------------*/
$(function () {
    $(window).scroll(function () {
        if ($(this).scrollTop() > 300) {
            $('#toTop').fadeIn();
        }
        else {
            $('#toTop').fadeOut();
        }
    });
    $('#toTop').click(function () {
        $('body,html').animate({ scrollTop: 0 }, 600);
    });
});

/*----------------------------------плавная прокрутка к форме заявки-------------------*/
$(function () {
    $("a[href^='#']").click(function () {
        var _href = $(this).attr("href");
        $("html, body").animate({ scrollTop: $(_href).offset().top + "px" });
        return false;
    });
});


/*--------------------модальное окно инпут с загрузкой файлов--------------------------*/

$(function () {
    var wrapper = $(".file_upload"),
        inp = wrapper.find("input"),
        btn = wrapper.find("button"),
        lbl = wrapper.find("div");

    btn.add(lbl).click(function () {
        inp.click();
    });

    var file_api = (window.File && window.FileReader && window.FileList && window.Blob) ? true : false;

    inp.change(function () {

        var file_name;
        if (file_api && inp[0].files[0])
            file_name = inp[0].files[0].name;
        else
            file_name = inp.val().replace("C:\\fakepath\\", '');
        if (!file_name.length)
            return;

        if (lbl.is(":visible")) {
            lbl.text(file_name);
            btn.text("Выбрать");
        } else
            btn.text(file_name);
    }).change();

});
$(window).resize(function () {
    $(".file_upload input").triggerHandler("change");
});

/*--------------------Загрузка файлов для формы----------------*/
(function () {

    'use strict';

    $('.input-file').each(function () {
        var $input = $(this),
            $label = $input.next('.js-labelFile'),
            labelVal = $label.html();

        $input.on('change', function (element) {
            var fileName = '';
            if (element.target.value) fileName = element.target.value.split('\\').pop();
            fileName ? $label.addClass('has-file').find('.js-fileName').html(fileName) : $label.removeClass('has-file').html(labelVal);
        });
    });

})();
/*------------------слайдер для промо-сайта--------------------*/
$('.slider').each(function () {
    var $this = $(this);
    var $group = $this.find('.slide_group');
    var $slides = $this.find('.slide');
    var bulletArray = [];
    var currentIndex = 0;
    var timeout;

    function move(newIndex) {
        var animateLeft, slideLeft;

        advance();

        if ($group.is(':animated') || currentIndex === newIndex) {
            return;
        }

        bulletArray[currentIndex].removeClass('active');
        bulletArray[newIndex].addClass('active');

        if (newIndex > currentIndex) {
            slideLeft = '100%';
            animateLeft = '-100%';
        } else {
            slideLeft = '-100%';
            animateLeft = '100%';
        }

        $slides.eq(newIndex).css({
            display: 'block',
            left: slideLeft
        });
        $group.animate({
            left: animateLeft
        }, function () {
            $slides.eq(currentIndex).css({
                display: 'none'
            });
            $slides.eq(newIndex).css({
                left: 0
            });
            $group.css({
                left: 0
            });
            currentIndex = newIndex;
        });
    }

    function advance() {
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            if (currentIndex < ($slides.length - 1)) {
                move(currentIndex + 1);
            } else {
                move(0);
            }
        }, 4000);
    }

    $('.next_btn').on('click', function () {
        if (currentIndex < ($slides.length - 1)) {
            move(currentIndex + 1);
        } else {
            move(0);
        }
    });

    $('.previous_btn').on('click', function () {
        if (currentIndex !== 0) {
            move(currentIndex - 1);
        } else {
            move(3);
        }
    });

    $.each($slides, function (index) {
        var $button = $('<a class="slide_btn">&bull;</a>');

        if (index === currentIndex) {
            $button.addClass('active');
        }
        $button.on('click', function () {
            move(index);
        }).appendTo('.slide_buttons');
        bulletArray.push($button);
    });

    advance();
});


/*-----------------------фильтр в портфолио-----------------------------------------*/
if ($('.filter-grid').length > 0) {
    var $filterGrid = $('.filter-grid');

    $('.nav-filters').on('click', 'a', function (e) {
        e.preventDefault();
        $('.nav-filters li').removeClass('active');
        $(this).parent().addClass('active');
        var $filterValue = $(this).attr('data-filter');
        $filterGrid.isotope({ filter: $filterValue });
    });
}

/*--------------------Галерея на главной странице------------------------------*/
$('.portfolio').each(function (index) {
    $(this).attr('id', 'img' + (index + 1));
});

$('.portfolio').each(function () {
    $('#navi').append('<div class="circle"></div>');
});

$('.circle').each(function (index) {
    $(this).attr('id', 'circle' + (index + 1));
});

$('.portfolio').click(function () {
    if ($(this).hasClass('opened')) {
        $(this).removeClass('opened');
        $(".portfolio").fadeIn("fast");
        $(this).find('.ombra').fadeOut();
        $("#navi div").removeClass("activenav");
    }
    else {
        var indexi = $("#maincontent .portfolio").index(this) + 1;
        $(this).addClass('opened');
        $(".portfolio").not(this).fadeOut("fast");
        $(this).find('.ombra').fadeIn();
        $("#circle" + indexi).addClass('activenav');
    }
});

//navi buttons
$("#navi div").click(function () {
    if ($(this).hasClass("activenav")) {
        return false;
    }

    $("#navi div").removeClass("activenav");
    $(".portfolio").removeClass('opened');
    $(".portfolio").show();
    $('.ombra').hide();

    var index = $("#navi div").index(this) + 1;
    $("#img" + index).addClass('opened');
    $(".portfolio").not("#img" + index).fadeOut("fast");
    $("#img" + index).find('.ombra').fadeIn();

    $(this).addClass("activenav");
});

/*-------------------этапы/шаги разработки/страница разработки-----------------------*/
$(function () {
    $("#tabs").tabs({
        show: { effect: "blind", direction: "right", duration: 300 }
    });
    $("#accordion").accordion();

    var btn = $('#accordion li a');
    var wrapper = $('#accordion li');

    $(btn).on('click', function () {
        $(btn).removeClass('active');
        $(btn).parent().find('.addon').removeClass('fadein');

        $(this).addClass('active');
        $(this).parent().find('.addon').addClass('fadein');
    });
});


/*--------------------прокрутка от сексии к секции------------*/
//$(document).ready(function() {  

//    $(".landing-wrapper").onepage_scroll({
//        sectionContainer: "section",
//        easing: "ease",
//        animationTime: 1000,
//        pagination: true,
//        updateURL: false,
//        loop: false,
//        keyboard: true,
//        responsiveFallback: false,
//        direction: "vertical"
//    });
//});


