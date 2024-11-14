using Microsoft.AspNetCore.Mvc;
using SaftOgKraft.WebSite.Models;
using System.Diagnostics;
using SaftOgKraft.WebSite.ApiClient;

namespace SaftOgKraft.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRestClient _restClient;

        public HomeController(ILogger<HomeController> logger, IRestClient restClient)
        {
            _logger = logger;
            _restClient = restClient;   
        }

        public async Task<IActionResult> Index()
        {
            var latestProducts = await _restClient.GetTenLatestProducts();
            return View(latestProducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
