using OlxaWebCore.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlxaWebCore.Models.ViewModels
{
    public class PortfolioListViewModel
    {
        public IEnumerable<Portfolio> Portfolios { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
