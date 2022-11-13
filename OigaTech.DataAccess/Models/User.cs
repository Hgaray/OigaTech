using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OigaTech.DataAccess.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
    }
}
