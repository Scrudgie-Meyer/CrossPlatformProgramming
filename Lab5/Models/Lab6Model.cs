namespace Lab5.Models;


public class CustomerViewModel
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerAddress { get; set; }
}

public class MovieRentalViewModel
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string MovieTitle { get; set; }
    public DateTime RentalDateOut { get; set; }
    public decimal RentalAmountDue { get; set; }
}

