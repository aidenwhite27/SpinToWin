/*using Microsoft.EntityFrameworkCore;
namespace Model;

public class TestContext : GameContext
{
    public string DbName { get; }

    public TestContext(string name)
    {
        DbName = name;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        =>options.UseInMemoryDatabase(DbName);
}*/