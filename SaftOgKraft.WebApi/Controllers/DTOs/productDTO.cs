using System.ComponentModel.DataAnnotations;

namespace SaftOgKraft.WebApi.Controllers.DTOs;

public class ProductDTO
{
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public required string Description { get; set; }
}
