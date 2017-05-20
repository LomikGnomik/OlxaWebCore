using OlxaWebCore.Models.DataModels;
using System.Collections.Generic;

namespace OlxaWebCore.Models.ViewModels
{
    public class BlogListViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
