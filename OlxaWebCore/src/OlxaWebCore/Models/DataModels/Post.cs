using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Models.DataModels
{
    public class Post
    {
        public int PostID { get; set; }
       // [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Заголовок")]
        public virtual string Title
        { get; set; }

     //   [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Короткое описание")]
        public virtual string ShortDescription
        { get; set; }

     //   [Required]
        [Display(Name = "Описание")]
        public virtual string Description
        { get; set; }

        [Display(Name = "Мета")]
        public virtual string Meta
        { get; set; }

        //[Display(Name = "")]
        //public virtual string UrlSlug
        //{ get; set; }

        [Display(Name = "Опубликованно?")]
        public virtual bool Published
        { get; set; }

      //  [Required]
        [Display(Name = "Категория")]
        public virtual string Category
        { get; set; }

      //  [DataType(DataType.Date)]
        [Display(Name = "Дата написания поста")]
        public virtual DateTime PostedOn
        { get; set; }

        //[DataType(DataType.Date)]
        //[Display(Name = "Пост изменён")]
        //public virtual DateTime? Modified
        //{ get; set; }

        [Display(Name = "Количество просмотров")]
        public virtual int Counter //счётчик просмотров
        { get; set; }

        [Display(Name = "Изображение")]
        public virtual string Picture //превью поста в блоге
        { get; set; }
        [Display(Name = "Вес Сортировки")]
        public virtual int SortingWeight { get; set; }
    }
}
