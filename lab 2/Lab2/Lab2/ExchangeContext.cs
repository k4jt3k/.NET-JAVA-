using Microsoft.EntityFrameworkCore;

namespace Lab2
{
    public class ExchangeContext : DbContext
    {
        public DbSet<CurrencyRate> Rates { get; set; }

        public ExchangeContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=exchange.db");
        }
    }
}