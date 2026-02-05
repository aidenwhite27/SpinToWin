namespace Tests;
using Model;
using Server;

public class GameTest 
{
    [Fact]
    public void CheckItemSubstitution_ShouldReturnSubstitution()
    {
        using (var _context = new GameContext("CheckItemSubstitution_ShouldReturnSubstitution"))
        {
            _context.Prizes.Add(new Prize {PrizeId = 1, Description = "Gift Item", Weight=1.0m});
            _context.Prizes.Add(new Prize {PrizeId = 2, Description = "$10 Free Play", Weight=0m});
            _context.SaveChanges();

            Server.GameController gc = new GameController(_context);
            Assert.Equal("$10 Free Play", gc.getRandomPrize(true).Description);
            _context.Dispose();
        }
    }

    [Fact]
    public void CheckItemSubstitution_ShouldReturnGift()
    {
        using (var _context = new GameContext("CheckItemSubstitution_ShouldReturnGift"))
        {
            _context.Prizes.Add(new Prize {PrizeId = 1, Description = "Gift Item", Weight=1.0m});
            _context.Prizes.Add(new Prize {PrizeId = 2, Description = "$10 Free Play", Weight=0m});
            _context.SaveChanges();

            Server.GameController gc = new GameController(_context);
            Assert.Equal("Gift Item", gc.getRandomPrize(false).Description);
        }
    }
}