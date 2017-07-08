using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Models.DataModels
{
    public class Service
    {
        public virtual int ServiceID { get; set; }

        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        public virtual decimal Price { get; set; }

        //строка с диапозоном цены для клиента
        public virtual string PriceForClient { get; set; }
        //время разработки.строка для клиентов
        public virtual string TimeDevelopForClient { get; set; }
        //
        public virtual string DemoSite { get; set; }
        //
        public virtual string DemoAdmin { get; set; }

        public virtual bool Published { get; set; }

        public virtual string Category { get; set; }

        [Display(Name = "Вес Сортировки")]
        public virtual int SortingWeight { get; set; }
    }
}
