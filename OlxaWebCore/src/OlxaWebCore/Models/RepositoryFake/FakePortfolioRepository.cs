using OlxaWebCore.Models.DataModels;
using OlxaWebCore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Models.RepositoryFake
{
    public class FakePortfolioRepository:IPortfolioRepository
    {
        public IEnumerable<Portfolio> Portfolios => new List<Portfolio> {
new Portfolio { PortfolioID=1, Title="первый" , Description="Описание" }
        };
    }
}
