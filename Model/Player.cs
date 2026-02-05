namespace Model;
public class Player
{
    public int PlayerId { get; set; }
    public bool HasWonGift { get; set; }
    public DateTime LastSessionStart { get; set; }
    public int PlaysRemaining { get; set; }

    public Player()
    {
        HasWonGift = false;
        LastSessionStart = new DateTime();
        PlaysRemaining = 3;
    }

    public bool isSessionExpired()
    {
        DateTime currDateTime = DateTime.Now;
        if (LastSessionStart.Date == currDateTime.Date)
        {
            if (LastSessionStart.AddMinutes(5) < currDateTime)
            {
                return true;
            }
        }
        return false;
    }
}