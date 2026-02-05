namespace Tests;
using Model;
using Server;

public class PlayerTest
{
    [Fact]
    public void CheckSessionExpiration_ShouldReturnFalse()
    {
        Player player = new Player {LastSessionStart = DateTime.Now};
        Assert.False(player.isSessionExpired());
    }

    [Fact]
    public void CheckSessionExpiration_ShouldReturnTrue()
    {
        Player player = new Player {LastSessionStart = DateTime.Now.AddMinutes(-6)};
        Assert.True(player.isSessionExpired());
    }
}