using OlxaWebCore.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Models.Interfaces
{
   public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
