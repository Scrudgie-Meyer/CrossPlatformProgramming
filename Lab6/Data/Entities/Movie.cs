namespace Lab6.Data.Entities;

public class Movie
{
    public int MovieId { get; set; }
    public string MovieTitle { get; set; }
    public decimal MovieRentalDailyRate { get; set; }
    public int MovieNumberInStock { get; set; }
}
