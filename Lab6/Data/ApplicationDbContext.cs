using Lab6.Data.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public string ConnectionString { get; set; }
    public DbSet<InventoryItemType> InventoryItemTypes { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerMovieRental> CustomerMovieRentals { get; set; }
    public DbSet<CustomerGameRental> CustomerGameRentals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Визначаємо первинний ключ для Inventory
        modelBuilder.Entity<Inventory>().HasKey(i => i.InventoryItemId);
        modelBuilder.Entity<CustomerGameRental>().HasKey(cgr => cgr.Id);


        // InventoryItemType
        modelBuilder.Entity<InventoryItemType>().HasData(
            new InventoryItemType { InventoryItemTypeId = 1, InventoryItemTypeDescription = "DVD" },
            new InventoryItemType { InventoryItemTypeId = 2, InventoryItemTypeDescription = "Blu-ray" },
            new InventoryItemType { InventoryItemTypeId = 3, InventoryItemTypeDescription = "Game Disc" }
        );

        // Inventory
        modelBuilder.Entity<Inventory>().HasData(
            new Inventory { InventoryItemId = 1, InventoryItemTypeId = 1, InventoryItemDescription = "DVD - Inception" },
            new Inventory { InventoryItemId = 2, InventoryItemTypeId = 2, InventoryItemDescription = "Blu-ray - The Matrix" },
            new Inventory { InventoryItemId = 3, InventoryItemTypeId = 3, InventoryItemDescription = "Game Disc - Halo" },
            new Inventory { InventoryItemId = 4, InventoryItemTypeId = 3, InventoryItemDescription = "Game Disc - FIFA" }
        );

        // Movie
        modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = 1, MovieId = 1, MovieTitle = "Inception", MovieRentalDailyRate = 1.99m, MovieNumberInStock = 10 },
            new Movie { Id = 2, MovieId = 2, MovieTitle = "The Matrix", MovieRentalDailyRate = 2.49m, MovieNumberInStock = 5 }
        );

        // Game
        modelBuilder.Entity<Game>().HasData(
            new Game { Id = 1, GameId = 1, GameTitle = "Halo", GameRentalDailyRate = 3.99m, GameNumberInStock = 7 },
            new Game { Id = 2, GameId = 2, GameTitle = "FIFA", GameRentalDailyRate = 2.99m, GameNumberInStock = 3 }
        );

        // Customer
        modelBuilder.Entity<Customer>().HasData(
            new Customer { CustomerId = 1, CustomerCode = "C001", CustomerName = "John Doe", CustomerAddress = "123 Main St", CustomerOtherDetails = "Regular customer" },
            new Customer { CustomerId = 2, CustomerCode = "C002", CustomerName = "Jane Smith", CustomerAddress = "456 Oak St", CustomerOtherDetails = "VIP customer" }
        );

        // CustomerMovieRentals
        modelBuilder.Entity<CustomerMovieRental>().HasData(
            new CustomerMovieRental { Id = 1, CustomerId = 1, MovieId = 1, RentalDateOut = DateTime.Now.AddDays(-5), RentalDateReturned = DateTime.Now.AddDays(-2), RentalAmountDue = 4.99m },
            new CustomerMovieRental { Id = 2, CustomerId = 2, MovieId = 2, RentalDateOut = DateTime.Now.AddDays(-3), RentalDateReturned = DateTime.Now.AddDays(-1), RentalAmountDue = 6.99m }
        );

        // CustomerGameRentals
        modelBuilder.Entity<CustomerGameRental>().HasData(
            new CustomerGameRental { Id = 1, CustomerId = 1, GameId = 1, RentalDateOut = DateTime.Now.AddDays(-10), RentalDateReturned = DateTime.Now.AddDays(-7), RentalAmountDue = 9.99m },
            new CustomerGameRental { Id = 2, CustomerId = 2, GameId = 2, RentalDateOut = DateTime.Now.AddDays(-2), RentalDateReturned = DateTime.Now.AddDays(-1), RentalAmountDue = 5.99m }
        );

        base.OnModelCreating(modelBuilder);
    }

}
