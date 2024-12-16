using System.ComponentModel.DataAnnotations;

namespace DAL.Model;

public class OrderLine
{
    public int OrderLineId { get; set; }
    public int OrderId { get; set; }
    public string? ProductName { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
