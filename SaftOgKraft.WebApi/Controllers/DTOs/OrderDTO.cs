using System.ComponentModel.DataAnnotations;
using DAL.Model;

namespace SaftOgKraft.WebApi.Controllers.DTOs;

public class OrderDTO
{
        
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
       
        public List<OrderLineDTO> OrderLines { get; set; }

        public OrderDTO()
        {
            OrderLines = new List<OrderLineDTO>();
        }
    }
