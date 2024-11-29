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
    public required DateTime OrderDate { get; set; }
    public required int CustomerId { get; set; }
    public required decimal TotalAmount { get; set; }
    public required string Status { get; set; }

    public byte [] Version {  get; set; } 
    public List<OrderLine> OrderLines { get; set; }



}

