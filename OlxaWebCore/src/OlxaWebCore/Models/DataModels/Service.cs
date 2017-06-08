using System;
using System.Collections.Generic;
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

        public virtual bool Published { get; set; }

        public virtual string Category { get; set; }
    }
}
