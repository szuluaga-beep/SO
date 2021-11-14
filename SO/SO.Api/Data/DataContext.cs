using Microsoft.EntityFrameworkCore;
using SO.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SO.Api.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<pet> pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<pet>().HasIndex(p => p.Name).IsUnique();
        }
    }
}
