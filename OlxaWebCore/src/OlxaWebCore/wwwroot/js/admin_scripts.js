/*---------------загрузка изображений в админ/портфолио-------------------*/
$('.file-input').change(function () {
    var curElement = $(this).parent().parent().find('.image');
    console.log(curElement);
    var reader = new FileReader();

    reader.onload = function (e) {
        // get loaded data and render thumbnail.
        curElement.attr('src', e.target.result);
    };

    // read the image file as a data URL.
    reader.readAsDataURL(this.files[0]);
});

/*-------------------------------------скрипт для таблицы---------------------*/
$(function () {
    $("table").colResizable();
    $("#service-table").colResizable({
        liveDrag: true,
        postbackSafe: true,
        headerOnly: false
    });
});
/*----------------------------------скрипт автозаполнения------------------------*/
$(function () {
    var autocompleteUrl = 'Find'; //'@Url.Action("Find")';
    $("input#categoryService").autocomplete({
        source: autocompleteUrl,
        minLength: 1,  
    });
});