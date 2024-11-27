using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaftOgKraft.WebSite.ApiClient;

namespace SaftOgKraft.WebSite.Controllers;
public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;
    private readonly IRestClient _restClient;

    // Constructor: Sets up the logger and API client using dependency injection
    public ProductController(ILogger<ProductController> logger, IRestClient restClient)
    {
        _logger = logger;
        _restClient = restClient;
    }

    // GET: ProductController
    public async Task<ActionResult> Index()
    {
        var products = await _restClient.GetAllProductsAsync();

        return View(products);
    }

    
    public async Task<ActionResult> GetSortedProducts(string sortOrder = "")
    {
        var products = await _restClient.GetSortedProductsAsync(sortOrder);
        return Json(products);
    }

    // GET: ProductController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }
}
