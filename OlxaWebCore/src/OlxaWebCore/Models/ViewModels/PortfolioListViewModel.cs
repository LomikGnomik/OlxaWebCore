using OlxaWebCore.Models.DataModels;
using System.Collections.Generic;

namespace OlxaWebCore.Models.ViewModels
{
    public class PortfolioListViewModel
    {
        public IEnumerable<Portfolio> Portfolios { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
