/*----------------------------------------фиксированное меню---------------------------*/
//var h_hght = 100; // высота шапки
//var h_mrg = 0;    // отступ когда шапка уже не видна
//$(function () {
//    var elem = $('.navigation');
//    var top = $(this).scrollTop();
//    if (top > h_hght) {
//        elem.css('top', h_mrg);
//    }
//    $(window).scroll(function () {
//        top = $(this).scrollTop();
//        if (top + h_mrg < h_hght) {
//            elem.css('top', (h_hght - top));
//            elem.css('box-shadow', ('none'));
//            elem.css('border-bottom', ('none'));
//        }
//        else {
//            elem.css('top', h_mrg);
//            elem.css('border-bottom', ('1px solid @color-gray-light'));
//            elem.css('box-shadow', ('0 6px 4px -4px rgba(0, 0, 0, .2'));

//        }
//    });
//});
$(function () {
    var elem = $('.navigation-sm');
    var height = 200;
    $(window).scroll(function () {
        var scroll = getCurrentScroll();
        if (scroll >= height) {
            elem.css('border-bottom', ('1px solid @color-gray-light'));
            elem.css('box-shadow', ('0 6px 4px -4px rgba(0, 0, 0, .2'));
        }
        else {
            elem.css('box-shadow', ('none'));
            elem.css('border-bottom', ('none'));
        }
    });
    function getCurrentScroll() {
        return window.pageYOffset || document.documentElement.scrollTop;
    }
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
var isMobile = {
    Android: function () { return navigator.userAgent.match(/Android/i) ? true : false; },
    BlackBerry: function () { return navigator.userAgent.match(/BlackBerry/i) ? true : false; },
    iOS: function () { return navigator.userAgent.match(/iPhone|iPad|iPod/i) ? true : false; },
    Windows: function () { return navigator.userAgent.match(/IEMobile/i) ? true : false; },
    any: function () { return (isMobile.Android() || isMobile.BlackBerry() || isMobile.iOS() || isMobile.Windows()); }
};

if (!isMobile.any()) {
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
}




/*----------------------------------плавная прокрутка к форме заявки-------------------*/
//$(function () {
//    $("a[href^='#']").click(function () {
//        var _href = $(this).attr("href");
//        $("html, body").animate({ scrollTop: $(_href).offset().top + "px" });
//        return false;
//    });
//});


/*--------------------модальное окно инпут с загрузкой файлов--------------------------*/

//$(function () {
//    var wrapper = $(".file_upload"),
//        inp = wrapper.find("input"),
//        btn = wrapper.find("button"),
//        lbl = wrapper.find("div");

//    btn.add(lbl).click(function () {
//        inp.click();
//    });

//    var file_api = (window.File && window.FileReader && window.FileList && window.Blob) ? true : false;

//    inp.change(function () {

//        var file_name;
//        if (file_api && inp[0].files[0])
//            file_name = inp[0].files[0].name;
//        else
//            file_name = inp.val().replace("C:\\fakepath\\", '');
//        if (!file_name.length)
//            return;

//        if (lbl.is(":visible")) {
//            lbl.text(file_name);
//            btn.text("Выбрать");
//        } else
//            btn.text(file_name);
//    }).change();

//});
//$(window).resize(function () {
//    $(".file_upload input").triggerHandler("change");
//});

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

/*-------------------этапы/шаги разработки/страница разработки-----------------------*/
$(function () {
    $("#develop-tabs").tabs({
        show: { effect: "blind", direction: "right", duration: 300 }
    });
    $("#develop-accordion").accordion();

    var btn = $('#develop-accordion li a');
    var wrapper = $('#develop-accordion li');

    $(btn).on('click', function () {
        $(btn).removeClass('active');
        $(btn).parent().find('.addon').removeClass('fadein');

        $(this).addClass('active');
        $(this).parent().find('.addon').addClass('fadein');
    });
});

/*-----------------согласие на обработку информации----------------------------*/
$(document).ready(function () {
    $('.continue').prop('disabled', false);
    $('.agree').change(function () {
        $('.continue').prop('disabled', function (i, val) {
            return !val;
        })
    });
})

/*------------------------первый экран с видами сайтов картинки в изометрии-------------------*/
var dialogOpener = $('.dialogOpener');
var dialog = $('#dialog');
var drawerOpener = $('#drawerOpener');
var drawer = $('#drawer');
var adminOpenen = $('#adminOpenen');
var admin = $('#admin');

dialogOpener.on('click', function () {
    dialog.removeClass('hidden');
});

dialog.on('click', function () {
    dialog.addClass('hidden');
})

drawerOpener.on('click', function () {
    drawer.toggleClass('hidden');
});

drawer.on('click', function () {
    drawer.addClass('hidden');
})

adminOpenen.on('click', function () {
    admin.toggleClass('hidden');
});

admin.on('click', function () {
    admin.addClass('hidden');
})

/*----------------------------------страница цены эффект для аккордиона--------------------------------------*/

var accordWithPage = function () {
    var faqDiv = $('#faq-links div');
    $(function () {
        faqDiv.on("click", function () {
            var hideSec = 'faq-hide';
            var $this = $(this),
            $id = $this.attr('id'),
            $class = '.' + $('.about-' + $id).attr('class').replace(hideSec, '');

            $('#faq-wrapper').addClass(hideSec);
            $('.about-' + $id).removeClass(hideSec);
            $('div[class*=about]').not($class).addClass(hideSec);
        });
    });

    $(function () {
        var select = 'faq-selected';
        faqDiv.click(function () {

            if ($(this).hasClass(select)) {
                $(this).removeClass(select);
            } else {
                $('#faq-links .faq-selected').removeClass(select);
                $(this).addClass(select);
            }
        }); //faq link selected
    });



    //Accordion

    $(function () {

        var expand = 'expanded';
        var content = $('.faq-content');
        //FAQ Accordion
        $('.faq-accordion > li > a').click(function (e) {
            e.preventDefault();
            if ($(this).hasClass(expand)) {
                $(this).removeClass(expand);
                //          $('.faq-accordion > li > a > div').not(this).css('opacity', '1');//returns li back to normal state
                $(this).parent().children('ul').stop(true, true).slideUp();
            } else {
                //            $('.faq-accordion > li > a > div').not(this).css('opacity', '0.5');//dims inactive li
                $('.faq-accordion > li > a.expanded').removeClass(expand);
                $(this).addClass(expand);
                content.filter(":visible").slideUp();
                $(this).parent().children('ul').stop(true, true).slideDown();
            }
        }); //accordion function

        content.hide();

    });

}

accordWithPage();

/*$(function () {
   $("#faq-links div").click(function () {
    $('.slide-left').fadeOut( "slow", "linear" );
     $('.slide-left').fadeIn( "slow", "linear" );
    }); //faq link fade in and out
  }); //document ready*/



/*валидация email в форме */

$(document).ready(function () {
    $('#email').blur(function () {
        if ($(this).val() != '') {
            var pattern = /^([a-z0-9_\.-])+@[a-z0-9-]+\.([a-z]{2,4}\.)?[a-z]{2,4}$/i;
            if (pattern.test($(this).val())) {
                $(this).css({ 'border': '1px solid #569b44' });
                $('#valid').text('Верно');
            } else {
                $(this).css({ 'border': '1px solid #ff0000' });
                $('#valid').text('Не верно');
            }
        } else {
            $(this).css({ 'border': '1px solid #ff0000' });
            $('#valid').text('Поле email не должно быть пустым');
        }
    });
});