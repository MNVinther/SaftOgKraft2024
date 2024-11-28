using SaftOgKraft.WebSite.ApiClient.DTOs;
namespace SaftOgKraft.WebSite.Models;

public class ProductQuantity
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }

    public ProductQuantity(ProductDto product, int quantity)
    {
        ProductId = product.Id;
        Quantity = quantity;
        ProductName = product.Name;
        Price = product.Price;
    }

    public ProductQuantity() { }

    public decimal GetTotalPrice()
    {
        return Price * Quantity;
    }

}
