using System.ComponentModel.DataAnnotations;

namespace SaftOgKraft.WebApi.Controllers.DTOs;

public class OrderDTO
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    
    public int CustomerId { get; set; }
    
    public decimal TotalAmount { get; set; }
    
    public string? Status { get; set; }
}
