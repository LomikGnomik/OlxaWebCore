
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
        }
        else {
            elem.css('top', h_mrg);
        }
    });
});


/*--------------------------------прокрутка наверх--------------------------------------*/
$(function () {
    $(window).scroll(function () {
        if ($(this).scrollTop() != 0) {
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
