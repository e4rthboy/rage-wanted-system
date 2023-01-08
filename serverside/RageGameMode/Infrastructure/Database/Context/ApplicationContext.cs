using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;
using RageGameMode.Domain.Fraction.Entity;
using Player = RageGameMode.Domain.Player.Entity.Player;

namespace RageGameMode.Infrastructure.Database.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Fraction> Fractions { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;user=root;password=secret;database=testmode_db";

            optionsBuilder
                .UseMySql(connectionString);
        }
    }
}