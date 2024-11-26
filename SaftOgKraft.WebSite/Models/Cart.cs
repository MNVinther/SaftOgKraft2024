namespace SaftOgKraft.WebSite.Models;

public class Cart
{
    public Dictionary<int, ProductQuantity> ProductQuantities { get; set; }

    public Cart(Dictionary<int, ProductQuantity>? productQuantities = null)
    {
        ProductQuantities = productQuantities ?? new Dictionary<int, ProductQuantity>();
    }

    public void ChangeQuantity(ProductQuantity productQuantity)
    {
        if (ProductQuantities.ContainsKey(productQuantity.ProductId))
        {
            ProductQuantities[productQuantity.ProductId].Quantity += productQuantity.Quantity;
            if (ProductQuantities[productQuantity.ProductId].Quantity <= 0)
            {
                ProductQuantities.Remove(productQuantity.ProductId);
            }
        }
        else
        {
            ProductQuantities[productQuantity.ProductId] = productQuantity;
        }
    }

    public void RemoveProductById(int productId) => ProductQuantities.Remove(productId);

    public void UpdateCart(int productId, int quantity) => ProductQuantities[productId].Quantity = quantity;

    #region Helper Methods

    public decimal GetTotal()
    {
        decimal total = 0;
        foreach (ProductQuantity productQuantity in ProductQuantities.Values)
        {
            total += productQuantity.GetTotalPrice();
        }
        return total;
    }

    public int GetNumberOfProducts() => ProductQuantities.Sum(productQuantity => productQuantity.Value.Quantity);

    internal void EmptyAll() => ProductQuantities.Clear();

    #endregion
}
