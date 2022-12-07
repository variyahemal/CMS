using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Utilities
{
    public class PagedResult<T> where T : class
    {
        public PagedResult()
        {
            Data = new List<T>();
        }
        public List<T> Data { get; set; }
        public long TotalItems { get; set; } = 0;
        public long PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 1;
    }
}
