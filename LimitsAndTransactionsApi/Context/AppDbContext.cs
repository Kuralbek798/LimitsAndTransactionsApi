using LimitsAndTransactionsApi.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace LimitsAndTransactionsApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        public DbSet<ApiKey> ApiKeys { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Заполнение начальных данных
            modelBuilder.Entity<ApiKey>().HasData(

                new ApiKey { Id = Guid.NewGuid(), EncryptedApiKey = "F5z8tDG0AI0Xon4zLcuLZsXXPAbiMkYDQJHBzYUOLXGHRFDqq4AWvWxil+mRt0+w", CreatedTime = DateTimeOffset.UtcNow, Description = "twelve", Active = true }
            );
        }
    }
}
