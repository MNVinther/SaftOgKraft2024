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

    public DateTime OrderDate { get; set; }

    public int CustomerId { get; set; }

    public decimal TotalAmount { get; set; }

    public string? Status { get; set; }

    public List<OrderLineDto> OrderLines { get; set; } = new List<OrderLineDto>(); 


}
