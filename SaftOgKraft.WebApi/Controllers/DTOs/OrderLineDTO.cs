using System.ComponentModel.DataAnnotations;

namespace SaftOgKraft.WebApi.Controllers.DTOs;

public class OrderLineDTO
{
    public int OrderLineId { get; set; }
    public int OrderId { get; set; }
    public string ProductName { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public byte[] ProductRowVersion { get; set; }
    public bool Packed { get; set; }
}
