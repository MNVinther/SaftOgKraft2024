using System.ComponentModel.DataAnnotations;

namespace SaftOgKraft.WebApi.Controllers.DTOs;

public class ProductDTO
{
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public decimal Price { get; set; }
    
    public string? Description { get; set; }
}
