using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaftOgKraft.OrderManager.ApiClient.DTOs;

namespace SaftOgKraft.OrderManager.ApiClient;
public interface IOrderRestClient
{
    Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
    Task<IEnumerable<OrderLineDto>> GetOrderLinesAsync(int orderId);
    Task<OrderDto> GetOrderByIdAsync(int id);
    Task<int> CreateOrderAsync(OrderDto order);
    Task<bool> UpdateOrderAsync(OrderDto order);
    Task<bool> DeleteOrderAsync(int id);
}
