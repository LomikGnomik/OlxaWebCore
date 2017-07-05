using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Models.DataModels
{
    public class Portfolio
    {
        public virtual int PortfolioID { get; set; }

        [Display(Name = "Заголовок")]
        public virtual string Title { get; set; }

        [Display(Name = "Ссылка на сайт")]
        public virtual string Link { get; set; }

        [Display(Name = "Аннотация")]
        public virtual string ShortDescription { get; set; }

        [Display(Name = "Описание")]
        public virtual string Description { get; set; }

        [Display(Name = "Категория")]
        public virtual string Category { get; set; }

        [Display(Name = "Цена")]
        public virtual decimal Price { get; set; }

        [Display(Name = "Срок разработки")]
        public virtual string DevelopmentTime { get; set; }

        [Display(Name = "Опубликованно?")]
        public virtual bool Published { get; set; }

        [Display(Name = "Имена изображений")]
        public virtual string Image { get; set; }

        [Display(Name = "Отзыв")]
        public virtual string Review { get; set; }

        [Display(Name = "Мета")]
        public virtual string Meta { get; set; }

        [Display(Name ="Вес Сортировки")]
        public virtual int SortingWeight { get; set; }

    }
}
