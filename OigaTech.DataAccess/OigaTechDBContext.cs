using Microsoft.EntityFrameworkCore;
using OigaTech.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OigaTech.DataAccess
{
    public  class OigaTechDBContext:DbContext
    {
        public OigaTechDBContext(DbContextOptions<OigaTechDBContext> options) : base(options)
        {

        }

        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(e => new { e.UserName }, "Unique_UserName").IsUnique(true);
        }
    }
}
