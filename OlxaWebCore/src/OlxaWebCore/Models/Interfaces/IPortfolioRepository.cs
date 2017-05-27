using OlxaWebCore.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Models.Interfaces
{
    public interface IPortfolioRepository
    {
        IEnumerable<Portfolio> Portfolios {get;}

        void SavePortfolio(Portfolio portfolio);
        Portfolio DeletePortfolio(int portfolioID);
    }
}
