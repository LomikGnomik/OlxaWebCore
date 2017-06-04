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

        // Save portfolio
        public void SavePortfolio(Portfolio portfolio)
        {
            if (portfolio.PortfolioID == 0)
            {
                context.Portfolios.Add(portfolio);
            }
            else
            {
                Portfolio dbEntry = context.Portfolios
                    .FirstOrDefault(p => p.PortfolioID == portfolio.PortfolioID);
                if (dbEntry != null)
                {
                    dbEntry.Title = portfolio.Title;
                    dbEntry.Description = portfolio.Description;
                    dbEntry.Meta = portfolio.Meta;
                    dbEntry.DevelopmentTime = portfolio.DevelopmentTime;
                    dbEntry.Image = portfolio.Image;
                    dbEntry.Link = portfolio.Link;
                    dbEntry.Review = portfolio.Review;
                    dbEntry.Price = portfolio.Price;
                    dbEntry.Published = portfolio.Published;
                    dbEntry.Category = portfolio.Category;
                }
            }
            context.SaveChanges();
        }
        // Delete portfolio
        public Portfolio DeletePortfolio(int portfolioID)
        {
            Portfolio dbEntry = context.Portfolios
                    .FirstOrDefault(p => p.PortfolioID == portfolioID);
            if (dbEntry != null)
            {
                context.Portfolios.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
