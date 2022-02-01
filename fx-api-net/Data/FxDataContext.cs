using System;
using FundhouseFx.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace FundhouseFx.Data
{
    public class FxDataContext : DbContext
    {
        public DbSet<Currency> Currencies { get; set; }

        public DbSet<SpotRate> SpotRates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = $"Data Source={AppContext.BaseDirectory}/Resources/fundhouse_fx.db";
            
            optionsBuilder.UseSqlite(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FxDataContext).Assembly);
        }
    }
}