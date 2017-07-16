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
/*---------------------------------tinyMCE(Description)---------------------------*/


  tinymce.init({
      selector: '#Description',

      plugins: [
   'advlist autolink lists link image charmap print preview anchor',
   'searchreplace visualblocks code fullscreen',
   'insertdatetime media table contextmenu paste code'
      ],
      toolbar: 'undo redo | insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
      content_css: [
       '//fonts.googleapis.com/css?family=Lato:300,300i,400,400i',
       '//www.tinymce.com/css/codepen.min.css'],

      file_browser_callback : function(field_name, url, type, win) {     
          var w = window,
          d = document,
          e = d.documentElement,
          g = d.getElementsByTagName('body')[0],
          x = w.innerWidth || e.clientWidth || g.clientWidth,
          y = w.innerHeight|| e.clientHeight|| g.clientHeight;

          var cmsURL = '/lib/rich-filemanager/index.html?&field_name=' + field_name + '&langCode=ru';
          // var cmsURL = '/lib/rich-filemanager/index.html?&field_name=' + field_name + '&langCode=' + tinymce.settings.language; выдаёт ошибку
          if(type == 'image') {		    
              cmsURL = cmsURL + "&type=images";
          }
          tinyMCE.activeEditor.windowManager.open({
              file : cmsURL,
              title : 'Filemanager',
              width : x * 0.8,
              height : y * 0.8,
              resizable : "yes",
              close_previous : "no"
          });		    
      }
  });
  /*---------------------------------tinyMCE(ShortDescription)---------------------------*/


  tinymce.init({
      selector: '#ShortDescription',

      plugins: [
   'advlist autolink lists link image charmap print preview anchor',
   'searchreplace visualblocks code fullscreen',
   'insertdatetime media table contextmenu paste code'
      ],
      toolbar: 'undo redo | insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
      content_css: [
       '//fonts.googleapis.com/css?family=Lato:300,300i,400,400i',
       '//www.tinymce.com/css/codepen.min.css'],

      file_browser_callback: function (field_name, url, type, win) {
          var w = window,
          d = document,
          e = d.documentElement,
          g = d.getElementsByTagName('body')[0],
          x = w.innerWidth || e.clientWidth || g.clientWidth,
          y = w.innerHeight || e.clientHeight || g.clientHeight;

          var cmsURL = '/lib/rich-filemanager/index.html?&field_name=' + field_name + '&langCode=ru';
          // var cmsURL = '/lib/rich-filemanager/index.html?&field_name=' + field_name + '&langCode=' + tinymce.settings.language; выдаёт ошибку
          if (type == 'image') {
              cmsURL = cmsURL + "&type=images";
          }
          tinyMCE.activeEditor.windowManager.open({
              file: cmsURL,
              title: 'Filemanager',
              width: x * 0.8,
              height: y * 0.8,
              resizable: "yes",
              close_previous: "no"
          });
      }
  });