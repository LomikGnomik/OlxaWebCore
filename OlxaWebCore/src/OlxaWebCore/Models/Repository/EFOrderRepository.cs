using OlxaWebCore.Data;
using OlxaWebCore.Models.DataModels;
using OlxaWebCore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Models.Repository
{
    public class EFOrderRepository : IOrderRepository
    {
        private ApplicationDbContext context;

        public EFOrderRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Order> Orders => context.Orders;


        // Save order
        public void SaveOrder(Order order)
        {
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            else
            {
                Order dbEntry = context.Orders
                    .FirstOrDefault(p => p.OrderID == order.OrderID);
                if (dbEntry != null)
                {
                    dbEntry.Comment = order.Comment;
                    dbEntry.Email = order.Email;
                    dbEntry.File = order.File;
                    dbEntry.Tel = order.Tel;
                    dbEntry.Name = order.Name;
                    dbEntry.UrlOrder = order.UrlOrder;
                    dbEntry.Note = order.Note;
                    dbEntry.AddCRM = order.AddCRM;

                }
            }
            context.SaveChanges();
        }
        // Delete order
        public Order DeleteOrder(int orderID)
        {
            Order dbEntry = context.Orders
                    .FirstOrDefault(p => p.OrderID == orderID);
            if (dbEntry != null)
            {
                context.Orders.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
