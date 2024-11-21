using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DataController(ApplicationDbContext context)
    {
        _context = context;
    }

    // --- 4.a: Viewing two dictionaries (list and single element) ---

    // Get a list of customers (dictionary 1)
    [HttpGet("customers")]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await _context.Customers.ToListAsync();
        return Ok(customers);
    }

    // Get details of a customer by ID
    [HttpGet("customers/{id}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null) return NotFound();
        return Ok(customer);
    }

    // Get a list of games (dictionary 2)
    [HttpGet("games")]
    public async Task<IActionResult> GetGames()
    {
        var games = await _context.Games.ToListAsync();
        return Ok(games);
    }

    // Get details of a game by ID
    [HttpGet("games/{id}")]
    public async Task<IActionResult> GetGameById(int id)
    {
        var game = await _context.Games.FindAsync(id);
        if (game == null) return NotFound();
        return Ok(game);
    }

    // --- 4.b: Viewing the central table (list and single element) ---

    // Get all rental records (central table)
    [HttpGet("customer-movie-rentals")]
    public async Task<IActionResult> GetCustomerMovieRentals()
    {
        var rentals = await _context.CustomerMovieRentals
            .Include(r => r.Customer)
            .Include(r => r.Movie)
            .ToListAsync();
        return Ok(rentals);
    }

    // Get rental details by ID
    [HttpGet("customer-movie-rentals/{id}")]
    public async Task<IActionResult> GetCustomerMovieRentalById(int id)
    {
        var rental = await _context.CustomerMovieRentals
            .Include(r => r.Customer)
            .Include(r => r.Movie)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (rental == null) return NotFound();
        return Ok(rental);
    }

    // --- 4.c: Search ---

    // Search by date range
    [HttpGet("search-by-date")]
    public async Task<IActionResult> SearchByDateRange(DateTime startDate, DateTime endDate)
    {
        var rentals = await _context.CustomerMovieRentals
            .Where(r => r.RentalDateOut >= startDate && r.RentalDateOut <= endDate)
            .Include(r => r.Customer)
            .Include(r => r.Movie)
            .ToListAsync();
        return Ok(rentals);
    }

    // Search by a list of IDs
    [HttpGet("search-by-list")]
    public async Task<IActionResult> SearchByList([FromQuery] List<int> movieIds)
    {
        var rentals = await _context.CustomerMovieRentals
            .Where(r => movieIds.Contains(r.MovieId))
            .Include(r => r.Customer)
            .Include(r => r.Movie)
            .ToListAsync();
        return Ok(rentals);
    }

    // Search by value range
    [HttpGet("search-by-value-range")]
    public async Task<IActionResult> SearchByValueRange(decimal minValue, decimal maxValue)
    {
        var rentals = await _context.CustomerMovieRentals
            .Where(r => r.RentalAmountDue >= minValue && r.RentalAmountDue <= maxValue)
            .Include(r => r.Customer)
            .Include(r => r.Movie)
            .ToListAsync();
        return Ok(rentals);
    }

    // Search with JOIN (two tables)
    [HttpGet("search-advanced")]
    public async Task<IActionResult> SearchWithJoin(string customerName, string movieTitle)
    {
        var rentals = await _context.CustomerMovieRentals
            .Include(r => r.Customer)
            .Include(r => r.Movie)
            .Where(r => r.Customer.CustomerName.Contains(customerName) && r.Movie.MovieTitle.Contains(movieTitle))
            .ToListAsync();

        return Ok(rentals);
    }
}
