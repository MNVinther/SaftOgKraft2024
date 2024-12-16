using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaftOgKraft.OrderManager.ApiClient.DTOs;
public class OrderLineDto
{
    //public int OrderLineId { get; set; }

    //public int OrderId { get; set; }
    
    public int Quantity { get; set; }

    public string? ProductName { get; set; }

    public int ProductId { get; set; }

    public decimal UnitPrice { get; set; }
 
    public bool Packed { get; set; }
}
