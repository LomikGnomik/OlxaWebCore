using OlxaWebCore.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Models.Interfaces
{
    public interface IServiceRepository
    {
        IEnumerable<Service> Services { get; }

        void SaveService(Service service);
        Service DeleteService(int serviceID);
    }
}
