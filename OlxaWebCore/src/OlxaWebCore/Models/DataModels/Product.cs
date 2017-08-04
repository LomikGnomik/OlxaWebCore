using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Models.DataModels
{
    public class Product
    {
        public int ProductID { get; set; }

        public virtual string Name { get; set; }

        public virtual int Price { get; set; }

        public virtual string TimeDevelop { get; set; }

        public virtual string Preview { get; set; } //Ссылка на картинку превьюшки

        public virtual string ShortDescription { get; set; }

        public virtual string Description { get; set; }

        public virtual string Category { get; set; }   // Визитка, Лендинг, Корпоративный, Интернет магазин, Информационный 

        public virtual string DemoLink { get; set; }

        [Display(Name = "Вес Сортировки")]
        public virtual int SortingWeight { get; set; }

        [Display(Name = "Опубликованно?")]
        public virtual bool Published
        { get; set; }
    }
}
