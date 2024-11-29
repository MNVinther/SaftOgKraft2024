using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SaftOgKraft.WebSite.ApiClient.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public required string Description { get; set; }
    public string? PictureUrl { get; set; }
    //static int Stock { get; set; }
}
