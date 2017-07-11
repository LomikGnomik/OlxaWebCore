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
//$(function () {
//    $("a[href^='#']").click(function () {
//        var _href = $(this).attr("href");
//        $("html, body").animate({ scrollTop: $(_href).offset().top + "px" });
//        return false;
//    });
//});


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


/*-----------------согласие на обработку информации----------------------------*/
$(document).ready(function () {
    $('#continue').prop('disabled', false);
    $('#agree').change(function () {
        $('#continue').prop('disabled', function (i, val) {
            return !val;
        })
    });
})


/*---------------------интернет магазин эффект*/
$('.avTile').hover(function () {
    $('.avFeature').toggleClass('active');
});
$('.firewallTile').hover(function () {
    $('.firewallFeature').toggleClass('active');
});
$('.backupTile').hover(function () {
    $('.backupFeature').toggleClass('active');
});
$('.vulnerabilitiesTile').hover(function () {
    $('.vulnerabilitiesFeature').toggleClass('active');
});
$('.spamfilterTile').hover(function () {
    $('.spamfilterFeature').toggleClass('active');
});
$('.smpTile').hover(function () {
    $('.smpFeature').toggleClass('active');
});
$('.tuneupTile').hover(function () {
    $('.tuneupFeature').toggleClass('active');
});
$('.idpTile').hover(function () {
    $('.idpFeature').toggleClass('active');
});
$('.parentalTile').hover(function () {
    $('.parentalFeature').toggleClass('active');
});

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

drawer.on('click', function () {
    admin.addClass('hidden');
})