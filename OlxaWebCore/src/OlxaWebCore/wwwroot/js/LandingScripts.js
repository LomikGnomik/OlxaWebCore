
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

