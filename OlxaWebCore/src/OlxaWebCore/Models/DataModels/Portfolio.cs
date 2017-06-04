using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Models.DataModels
{
    public class Portfolio
    {
        public int PortfolioID { get; set; }

        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Display(Name = "Ссылка на сайт")]
        public string Link { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Категория")]
        public string Category { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Срок разработки")]
        public string DevelopmentTime { get; set; }

        [Display(Name = "Опубликованно?")]
        public bool Published { get; set; }

        [Display(Name = "Ссылка на папку с картинками")]
        public string Image { get; set; }

        [Display(Name = "Отзыв")]
        public string Review { get; set; }

        [Display(Name = "Мета")]
        public string Meta { get; set; }
    }
}
