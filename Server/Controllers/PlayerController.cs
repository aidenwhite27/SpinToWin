using Model;
using Microsoft.AspNetCore.Mvc;

namespace Server;

[Route("api/[controller]")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly GameContext _context;

    public PlayerController(GameContext context)
    {
        _context = context;
    }

    [HttpPost("{login}")]
    public async Task<ActionResult<Player>> Login(Player player)
    {
        bool playerExists = _context.Players.Any(p => p.PlayerId == player.PlayerId);

        if (!playerExists)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpGet("{id}/status")]
    public async Task<ActionResult<Player>> Status(int id)
    {
        Player? foundPlayer = _context.Players.Where(p => p.PlayerId == id).FirstOrDefault();

        if (foundPlayer == default)
        {
            return NotFound();
        }

        if (foundPlayer.LastSessionStart.Date != DateTime.Now.Date)
        {
            foundPlayer.PlaysRemaining = 3;
            _context.SaveChanges();
        }

        return foundPlayer;
    }
}


