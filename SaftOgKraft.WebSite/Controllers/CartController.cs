using Microsoft.AspNetCore.Mvc;
using SaftOgKraft.WebSite.Models;
using RestSharp;
using System.Text.Json;
using SaftOgKraft.WebSite.ApiClient;

namespace SaftOgKraft.WebSite.Controllers;
public class CartController : Controller
{

    private readonly SaftOgKraft.WebSite.ApiClient.IRestClient _restClient;

    public CartController(SaftOgKraft.WebSite.ApiClient.IRestClient restClient) => _restClient = restClient;

    public IActionResult Index()
    {
        return View();
    }

    public async Task<ActionResult> Edit(int id, int quantity)
    {
        var cart = await LoadUpdateAndSaveCart(async cart =>
        {
            var product = await _restClient.GetProductByIdAsync(id);
            cart.ChangeQuantity(new ProductQuantity(product, quantity));
        });
        return View("Index", cart);
    }

    public async Task<ActionResult> Add(int id, int quantity)
    {
        var product = LoadUpdateAndSaveCart(async cart =>
        {
            var product = await _restClient.GetProductByIdAsync(id);
            cart.ChangeQuantity(new ProductQuantity(product, quantity));
        });

        return RedirectToAction("Index");
    }

    public async Task<ActionResult> Delete(int id)
    {
  
        var cart = await LoadUpdateAndSaveCart(async cart =>
        {
            cart.RemoveProductById(id);
            await Task.CompletedTask;
        });

        return RedirectToAction("Index"); 
    }

    public async Task<ActionResult> EmptyCart()
    {
        var cart = await LoadUpdateAndSaveCart(async cart =>
        {
            cart.EmptyAll();
            await Task.CompletedTask;
        });
        return RedirectToAction("Index");
    }

    private void SaveCartToCookie(Cart cart)
    {
        var cookieOptions = new CookieOptions();
        cookieOptions.Expires = DateTime.Now.AddDays(5);
        cookieOptions.Secure = true;
        cookieOptions.Path = "/";
        Response.Cookies.Append("Cart", JsonSerializer.Serialize(cart), cookieOptions);
    }

    private Cart GetCartFromCookie()
    {
        Request.Cookies.TryGetValue("Cart", out string? cookie);
        if (cookie == null) { return new Cart(); }
        return JsonSerializer.Deserialize<Cart>(cookie) ?? new Cart();
    }

    private async Task<Cart> LoadUpdateAndSaveCart(Func<Cart, Task> asyncAction)
    {
        Cart cart = GetCartFromCookie();
        await asyncAction(cart);
        ViewBag.Cart = cart;
        SaveCartToCookie(cart);
        return cart;
    }
}
