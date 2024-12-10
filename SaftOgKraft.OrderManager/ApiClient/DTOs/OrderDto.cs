using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaftOgKraft.OrderManager.ApiClient.DTOs;
public class OrderDto
{
    public int OrderId { get; set; }

    [Required]
    public required DateTime OrderDate { get; set; }

    [Required]
    public required int CustomerId { get; set; }

    [Required]
    public required decimal TotalAmount { get; set; }
    public string Status { get; set; }


}
