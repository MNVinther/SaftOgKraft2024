﻿namespace SaftOgKraft.WebSite.ApiClient.DTOs;

public class OrderLineDto
{
  
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    
}