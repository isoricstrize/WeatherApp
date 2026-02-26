using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Domain.Entities;

namespace WeatherApp.WebApi.Data
{
    public class CitiesDbContext(DbContextOptions<CitiesDbContext> options) : DbContext(options)
    {
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasKey(c => c.GeoNameId);
        }
    }
}