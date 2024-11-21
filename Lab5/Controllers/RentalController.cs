using Lab5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Lab5.Controllers;

public class RentalController : Controller
{
    private readonly HttpClient _httpClient;

    public RentalController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Action to view a list of customers
    public async Task<IActionResult> Customers()
    {
        var response = await _httpClient.GetAsync("http://localhost:5000/api/data/customers");
        if (!response.IsSuccessStatusCode)
            return View("Error", $"Failed to fetch customers. Status code: {response.StatusCode}");

        var customers = await response.Content.ReadAsStringAsync();
        var customerList = JsonSerializer.Deserialize<List<CustomerViewModel>>(customers);

        return View(customerList);
    }

    // Action to view details of a specific customer
    public async Task<IActionResult> CustomerDetails(int id)
    {
        var response = await _httpClient.GetAsync($"http://localhost:5000/api/data/customers/{id}");
        if (!response.IsSuccessStatusCode)
            return View("Error", $"Failed to fetch customer details. Status code: {response.StatusCode}");

        var customer = await response.Content.ReadAsStringAsync();
        var customerDetails = JsonSerializer.Deserialize<CustomerViewModel>(customer);

        return View(customerDetails);
    }

    // Action to view a list of movie rentals
    public async Task<IActionResult> MovieRentals()
    {
        var response = await _httpClient.GetAsync("http://localhost:5000/api/data/customer-movie-rentals");
        if (!response.IsSuccessStatusCode)
            return View("Error", $"Failed to fetch movie rentals. Status code: {response.StatusCode}");

        var rentals = await response.Content.ReadAsStringAsync();
        var rentalList = JsonSerializer.Deserialize<List<MovieRentalViewModel>>(rentals);

        return View(rentalList);
    }

    // Action to view details of a specific movie rental
    public async Task<IActionResult> MovieRentalDetails(int id)
    {
        var response = await _httpClient.GetAsync($"http://localhost:5000/api/data/customer-movie-rentals/{id}");
        if (!response.IsSuccessStatusCode)
            return View("Error", $"Failed to fetch movie rental details. Status code: {response.StatusCode}");

        var rental = await response.Content.ReadAsStringAsync();
        var rentalDetails = JsonSerializer.Deserialize<MovieRentalViewModel>(rental);

        return View(rentalDetails);
    }

    // Action to perform search by date range
    public async Task<IActionResult> SearchByDate(DateTime startDate, DateTime endDate)
    {
        var response = await _httpClient.GetAsync($"http://localhost:5000/api/data/search-by-date?startDate={startDate}&endDate={endDate}");
        if (!response.IsSuccessStatusCode)
            return View("Error", $"Failed to fetch rentals by date. Status code: {response.StatusCode}");

        var rentals = await response.Content.ReadAsStringAsync();
        var rentalList = JsonSerializer.Deserialize<List<MovieRentalViewModel>>(rentals);

        return View("SearchResults", rentalList);
    }
}
