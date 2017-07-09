/*------------первый экран-----------*/
var dialogOpener = $('.dialogOpener');
var dialog = $('#dialog');
var drawerOpener = $('#drawerOpener');
var drawer = $('#drawer');

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

/*------------секция плючы лендинга*/


    var zqLineWrapWidth = $('.zqLineWrap').width();
    var allZqLi = $(".zqLI");

    $(window).scroll(function () {
        var windowScrollTop = $(window).scrollTop();
        allZqLi.each(function () {
            var zqLiOffsetTop = $(this).offset().top;
            if (windowScrollTop > zqLiOffsetTop - zqLineWrapWidth) {
                $(this).find(".zqLine").addClass("zqJS");
            } else {
                $(this).find(".zqLine").removeClass("zqJS");
            }

        })
    });

