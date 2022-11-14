using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OigaTech.Dto
{
    public  class UserPaginatedResponse: QueryPagination
    {
        public List<UserDto> Users { get; set; }
    }
}
