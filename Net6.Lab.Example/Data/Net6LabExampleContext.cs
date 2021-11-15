using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Net6.Lab.Example.Models;

namespace Net6.Lab.Example.Data
{
    public class Net6LabExampleContext : DbContext
    {
        public Net6LabExampleContext(DbContextOptions<Net6LabExampleContext> options)
            : base(options)
        {
        }

        public DbSet<Todo> Todo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Todo>()
                .ToTable("Todo", b => b.IsTemporal());
        }

    }
}
