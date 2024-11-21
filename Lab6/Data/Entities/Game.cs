namespace Lab6.Data.Entities;

public class Game
{
    public int GameId { get; set; }
    public string GameTitle { get; set; }
    public decimal GameRentalDailyRate { get; set; }
    public int GameNumberInStock { get; set; }
}
