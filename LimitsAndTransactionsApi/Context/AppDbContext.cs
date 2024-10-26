using LimitsAndTransactionsApi.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace LimitsAndTransactionsApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<ExchangeRate> ExchangeRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExchangeRate>()
                .ToTable("exchange_rates");
        }
    }
}
