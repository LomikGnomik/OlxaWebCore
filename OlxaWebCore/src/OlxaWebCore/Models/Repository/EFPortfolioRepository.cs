using OlxaWebCore.Data;
using OlxaWebCore.Models.DataModels;
using OlxaWebCore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Models.Repository
{
    public class EFPortfolioRepository : IPortfolioRepository
    {
        private ApplicationDbContext context;

        public EFPortfolioRepository(ApplicationDbContext ctx)
        {
           context = ctx;
        }
        public IEnumerable<Portfolio> Portfolios => context.Portfolios;
    }
}
