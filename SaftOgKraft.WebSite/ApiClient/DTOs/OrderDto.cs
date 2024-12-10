using System.ComponentModel.DataAnnotations;

namespace SaftOgKraft.WebSite.ApiClient.DTOs;

public class OrderDto
{
    public int OrderId {  get; set; }
    public DateTime OrderDate { get; set; }
    public int CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public List<OrderLineDto> OrderLines { get; set; } = new List<OrderLineDto>();

}
