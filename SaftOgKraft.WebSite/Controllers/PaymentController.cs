using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaftOgKraft.WebSite.ApiClient;
using SaftOgKraft.WebSite.Models;
using SaftOgKraft.WebSite.ApiClient.DTOs;
using System.Diagnostics;

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
    public async Task<IActionResult> Pay()
    {
        // Retrieve the cart from the cookie
        var cart = GetCartFromCookie();

        // Check if the cart is empty
        if (cart == null || cart.ProductQuantities.Count == 0)
        {
            return RedirectToAction("Index", "Cart"); // Redirect to the cart page if no items are in the cart
        }

       
        // Calculate the total amount for the order using the GetTotal method from Cart
        decimal totalAmount = cart.GetTotal();

        // Create the OrderDto object
        var orderDto = new OrderDto
        {
            CustomerId = 1,
            OrderDate = DateTime.Now,
            TotalAmount = totalAmount,
            //Status = "Pending", // Or whatever default status you want to assign
            OrderLines = cart.ProductQuantities.Select(pq => new OrderLineDto
            {
                ProductId = pq.Key, // Use the productId from the dictionary key
                Quantity = pq.Value.Quantity,
                UnitPrice = pq.Value.GetTotalPrice() / pq.Value.Quantity 
            }).ToList()
        };

        try
        {
            // Call the RestApiClient to create the order
            var createdOrder = await _restClient.CreateOrderAsync(orderDto);

            // Clear the cart after the order is created (optional)
            ClearCart(); 

            // Redirect to the confirmation page, passing the OrderId
            return RedirectToAction("Confirmation", new { orderId = createdOrder.OrderId });
        }
        catch (Exception ex)
        {
         // Create an instance of ErrorViewModel with the exception message
    var errorViewModel = new ErrorViewModel
    {
        ErrorMessage = ex.Message,  // Set the error message
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
        
    };

    // Return the error view with the ErrorViewModel
    return View("Error", errorViewModel);
}
    }
    private void ClearCart()
    {
        Response.Cookies.Delete("Cart");
    }
    public IActionResult Confirmation(int orderId)
    {
        return View(orderId);
    }
}
