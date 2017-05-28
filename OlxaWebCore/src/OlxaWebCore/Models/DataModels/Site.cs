using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Models.DataModels
{
    public class Site
    {
        public int SiteID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; } // цена для клиентов на всём сайте

        public string TypeSite { get; set; }
    }
}
