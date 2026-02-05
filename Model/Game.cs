namespace Model;
public class Game
{
    public int GameId { get; set; }
    public DateTime GameTime { get; set; }
    public int PlayerId { get; set; }
    public int PrizeId { get; set; }
}