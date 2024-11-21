namespace Lab6.Data.Entities;

public class CustomerMovieRental
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int MovieId { get; set; }
    public DateTime RentalDateOut { get; set; }
    public DateTime RentalDateReturned { get; set; }
    public decimal RentalAmountDue { get; set; }

    public Customer Customer { get; set; }
    public Movie Movie { get; set; }
}

