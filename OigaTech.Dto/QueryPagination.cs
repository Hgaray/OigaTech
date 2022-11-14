using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OigaTech.Dto
{
    public class QueryPagination
    {
        public int PageIndex { get; set; } = 0;
        public int TotalCount { get; set; } = 0;
        public decimal TotalPages { get; set; } = 0;
        
    }
}
