using Microsoft.EntityFrameworkCore;

namespace KantorAvalonia;

public class ExchangeContext : DbContext
{
    public DbSet<CurrencyRate> Rates { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=exchange.db");
    }
}