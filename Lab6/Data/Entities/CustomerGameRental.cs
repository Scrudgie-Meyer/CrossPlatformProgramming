namespace Lab6.Data.Entities;

public class CustomerGameRental
{
    public int CustomerId { get; set; }
    public int GameId { get; set; }
    public DateTime RentalDateOut { get; set; }
    public DateTime RentalDateReturned { get; set; }
    public decimal RentalAmountDue { get; set; }

    public Customer Customer { get; set; }
    public Game Game { get; set; }
}

