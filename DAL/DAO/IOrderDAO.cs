using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.DAO;
public interface IOrderDAO
{
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    //Task<Order> GetOrderByIdAsync(int orderId);
    Task<Order> CreateOrderAsync(Order entity);
    Task<IEnumerable<OrderLine>> GetOrderLinesAsync(int orderId);
    Task<bool> UpdateOrderStatusAsync (int orderId, string status);

}
