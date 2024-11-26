using System.ComponentModel.DataAnnotations;

namespace SaftOgKraft.WebApi.Controllers.DTOs;

public class OrderDTO
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    [Required]
    public int CustomerId { get; set; }
    [Required]
    public decimal TotalAmount { get; set; }
    [Required]
    public required string Status { get; set; }
}
