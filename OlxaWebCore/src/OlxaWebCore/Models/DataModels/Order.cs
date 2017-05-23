using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Models.DataModels
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
