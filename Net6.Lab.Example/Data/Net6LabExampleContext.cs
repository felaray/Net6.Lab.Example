using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Net6.Lab.Example.Model;

namespace Net6.Lab.Example.Data
{
    public class Net6LabExampleContext : DbContext
    {
        public Net6LabExampleContext(DbContextOptions<Net6LabExampleContext> options)
            : base(options)
        {
        }

        public DbSet<Net6.Lab.Example.Model.WeatherForecast> WeatherForecast { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<WeatherForecast>()
                .ToTable("WeatherForecast", b => b.IsTemporal());
        }

    }
}
