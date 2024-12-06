using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaftOgKraft.OrderManager.ApiClient.DTOs;
public class OrderLineDto
{

    public int OrderLineId { get; set; }

    [Required]
    public required int OrderId { get; set; }
    
    [Required]
    public string ProductName { get; set; }

    [Required]
    public required int ProductId { get; set; }

    [Required]
    public required int Quantity { get; set; }

    [Required]
    public required decimal UnitPrice { get; set; }

    [Required] 
    public bool Packed { get; set; }
}
