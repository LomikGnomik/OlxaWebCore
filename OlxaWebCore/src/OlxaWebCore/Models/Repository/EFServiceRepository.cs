using OlxaWebCore.Data;
using OlxaWebCore.Models.DataModels;
using OlxaWebCore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Models.Repository
{
    public class EFServiceRepository: IServiceRepository
    {
        private ApplicationDbContext context;

        public EFServiceRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Service> Services => context.Services;

        // Save Service
        public void SaveService(Service service)
        {
            if (service.ServiceID == 0)
            {
                context.Services.Add(service);
            }
            else
            {
                Service dbEntry = context.Services
                    .FirstOrDefault(p => p.ServiceID == service.ServiceID);
                if (dbEntry != null)
                {
                    dbEntry.Title = service.Title;
                    dbEntry.Description = service.Description;
                    dbEntry.Published = service.Published;
                    dbEntry.Category = service.Category;
                    dbEntry.Price = service.Price;
                    dbEntry.DemoAdmin = service.DemoAdmin;
                    dbEntry.DemoSite = service.DemoSite;
                    dbEntry.PriceForClient = service.PriceForClient;
                    dbEntry.SortingWeight = service.SortingWeight;
                    dbEntry.TimeDevelopForClient = service.TimeDevelopForClient;
                    
                }
            }
            context.SaveChanges();
        }
        // Delete service
        public Service DeleteService(int serviceID)
        {
            Service dbEntry = context.Services
                    .FirstOrDefault(p => p.ServiceID == serviceID);
            if (dbEntry != null)
            {
                context.Services.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }


        public IEnumerable<String> FindCategory()
        {
            IEnumerable<String> category = context.Services
              //  .Where(t => t.Category.StartsWith(term))
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return category ;
        }
    }
}
