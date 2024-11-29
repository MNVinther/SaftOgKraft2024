using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaftOgKraft.WebSite.ApiClient;
using SaftOgKraft.WebSite.Models;

namespace SaftOgKraft.WebSite.Controllers;
public class PaymentController : Controller
{
    private readonly IRestClient _restClient;

    public PaymentController(IRestClient restClient)
    {
        _restClient = restClient;
    }
    public IActionResult Index()
    {
        return View(GetCartFromCookie());
    }

    private Cart GetCartFromCookie()
    {
        Request.Cookies.TryGetValue("Cart", out string? cookie);
        if (cookie == null) { return new Cart(); }
        return JsonSerializer.Deserialize<Cart>(cookie) ?? new Cart();
    }
}
