using Microsoft.EntityFrameworkCore;
namespace Model;

public class GameContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Prize> Prizes { get; set; }
    public string DbPath { get; }
    public string DbName { get; }

    public GameContext()
    {
        DbPath = "../spintowin.db";
    }

    public GameContext(string name)
    {
        DbName = name;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (DbName is null)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
        else
        {
            options.UseInMemoryDatabase(DbName);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        if (DbName is null)
        {
            modelBuilder.Entity<Player>().HasData(
                new Player {PlayerId = 1234567}
            );

            modelBuilder.Entity<Prize>().HasData(
                new Prize { PrizeId = 1, Description = "No Prize", Weight = 0.5m},
                new Prize { PrizeId = 2, Description = "$5 Free Play", Weight = 0.25m},
                new Prize { PrizeId = 3, Description = "$10 Free Play", Weight = 0.15m},
                new Prize { PrizeId = 4, Description = "Food Voucher", Weight = 0.07m},
                new Prize { PrizeId = 5, Description = "Gift Item", Weight = 0.03m}
            );
        }
    }
}