using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Models.DataModels
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Представьтесь, пожалуйста")]
        [Display(Name = "Имя клиента")]
        public string Name { get; set; }

        
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Required (ErrorMessage = "Не указан email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Телефон")]
        public string Tel { get; set; }

        [Display(Name = "Комментарий клиента")]
        public string Comment { get; set; }

        [Display(Name = "Заметка")]
        public string Note { get; set; } //наши заметки о клиенте

        [Display(Name = "Файлы")]
        public string File { get; set; }

        [Display(Name = "Страница заказа")]
        public string UrlOrder { get; set; } // страница с которой был сделан заказ

        [Display(Name = "Добавлен в CRM")]
        public bool AddCRM { get; set; }

        [Display(Name = "Дата заказа")]
        public DateTime DateOrder{get;set;}
    }
}
