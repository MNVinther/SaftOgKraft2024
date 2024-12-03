using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.Model;
public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public int CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public string? Status { get; set; }
    public byte [] Version {  get; set; }
    public List<OrderLine> OrderLines { get; set; }

    public Order()
    {
        OrderLines = new List<OrderLine>();
    }
}

