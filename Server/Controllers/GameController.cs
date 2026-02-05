using Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Server;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private GameContext _context;
    private Random rand;

    public GameController(GameContext context)
    {
        _context = context;
        rand = new Random();
    }

    [HttpPost("play")]
    public async Task<ActionResult<Dictionary<string, string>>> Play(Player player)
    {
        Player? foundPlayer = _context.Players.Where(
            p => p.PlayerId == player.PlayerId).FirstOrDefault();

        if (foundPlayer == default)
        {
            return NotFound();
        }

        if (foundPlayer.isSessionExpired())
        {
            return Forbid("Session Expired");
        }

        if (foundPlayer.PlaysRemaining <= 0)
        {
            return Forbid("No Plays Remaining");
        }

        if (foundPlayer.PlaysRemaining == 3)
        {
            foundPlayer.LastSessionStart = DateTime.Now;
        }

        foundPlayer.PlaysRemaining -= 1;

        Prize prize = getRandomPrize(player.HasWonGift);

        _context.Add(new Game {PlayerId = foundPlayer.PlayerId, 
            GameTime = DateTime.Now, PrizeId = prize.PrizeId});
        _context.SaveChanges();

        Dictionary<string, string> response = new Dictionary<string, string>();
        response["player"] = JsonSerializer.Serialize(player);
        response["prize"] = JsonSerializer.Serialize(prize);
        return response;
    }

    public Prize getRandomPrize(bool HasWonGift)
    {
        var prizes = _context.Prizes;
        decimal randomNum = (decimal)rand.NextDouble();
        decimal cumSum = 0m;

        Prize selected = prizes.First();
        foreach (Prize prize in prizes)
        {
            cumSum += prize.Weight;
            if (randomNum < cumSum)
            {
                selected = prize;
                break;
            }
        }

        if (HasWonGift && selected.Description == "Gift Item")
        {
            selected = prizes.Where(p => p.Description == "$10 Free Play").FirstOrDefault();
        }
        return selected;
    }
}


