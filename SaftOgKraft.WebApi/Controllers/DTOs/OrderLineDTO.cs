
﻿namespace SaftOgKraft.WebApi.Controllers.DTOs;

public class OrderLineDTO
{
   
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    
}
