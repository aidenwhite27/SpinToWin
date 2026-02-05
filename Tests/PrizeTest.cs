namespace Tests;
using Model;
using Server;

public class PrizeTest
{
    [Fact]
    public void CheckSumPrizeWeights_ShouldEqualOne()
    {
        using (var _context = new GameContext())
        {
            _context.Database.EnsureCreated();
            decimal PrizeWeightSum = _context.Prizes.Sum(p => p.Weight);
            Assert.Equal(1.0m, PrizeWeightSum);
        }
    }
}