using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SaftOgKraft.WebSite.Models;
using System.Diagnostics;
using SaftOgKraft.WebSite.ApiClient;

namespace SaftOgKraft.WebSite.Controllers;

// HomeController for handling web requests related to it 

public class HomeController : Controller
{

    private readonly ILogger<HomeController> _logger;
    private readonly IRestClient _restClient;

    // Constructor: Sets up the logger and API client using dependency injection
    public HomeController(ILogger<HomeController> logger, IRestClient restClient)
    {
        _logger = logger;
        _restClient = restClient;   
    }


    // Action: Handles GET requests to the Home/Index - GET: ProductsController
    public async Task<IActionResult> Index()
    {
        // Fetches the 10 latest products using the API client
        var latestProducts = await _restClient.GetTenLatestProducts();

        // Returns a View result with the fetched products
        return View(latestProducts);
    }

    // Action: Handles GET requests to Home/Privacy
    public IActionResult Privacy()
    {
        // Returns the "Privacy" view
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
