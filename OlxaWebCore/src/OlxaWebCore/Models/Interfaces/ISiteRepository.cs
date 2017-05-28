using OlxaWebCore.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Models.Interfaces
{
   public interface ISiteRepository
    {
        IEnumerable<Site> Sites { get; }

        void SaveSite(Site site);
        Site DeleteSite(int siteID);
    }
}
