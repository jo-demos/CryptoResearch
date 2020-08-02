using Microsoft.EntityFrameworkCore;

namespace CryptoResearch.Models
{
    public class MyContext : DbContext
    {
        public DbSet<Currency> Currencys { get; set; }
        public DbSet<Broker> Brokers { get; set; }

        public MyContext(DbContextOptions<MyContext> opcoes) : base(opcoes)
        {
            Database.Migrate();
        }
    }
}