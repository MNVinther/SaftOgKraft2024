//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using SaftOgKraft.OrderManager.ApiClient.DTOs;

//namespace SaftOgKraft.OrderManager.ApiClient;
//public class OrderRestClientStub : IOrderRestClient
//{
//    private static List<OrderDto> _orders = new List<OrderDto>()
//    {
//    new OrderDto { OrderId = 1, CustomerId = 001, OrderDate = DateTime.Now.AddDays(-2), TotalAmount = 120.50m },
//    new OrderDto { OrderId = 2, CustomerId = 002, OrderDate = DateTime.Now.AddDays(-1), TotalAmount = 350.00m },
//    new OrderDto { OrderId = 3, CustomerId = 003, OrderDate = DateTime.Now, TotalAmount = 75.00m },
//    new OrderDto { OrderId = 4, CustomerId = 004, OrderDate = DateTime.Now.AddDays(-3), TotalAmount = 180.00m },
//    new OrderDto { OrderId = 5, CustomerId = 005, OrderDate = DateTime.Now.AddDays(-5), TotalAmount = 50.75m },
//    new OrderDto { OrderId = 6, CustomerId = 006, OrderDate = DateTime.Now.AddDays(-7), TotalAmount = 600.00m },
//    new OrderDto { OrderId = 7, CustomerId = 007, OrderDate = DateTime.Now.AddDays(-8), TotalAmount = 125.25m },
//    new OrderDto { OrderId = 8, CustomerId = 008, OrderDate = DateTime.Now.AddDays(-10), TotalAmount = 320.10m },
//    new OrderDto { OrderId = 9, CustomerId = 009, OrderDate = DateTime.Now.AddDays(-12), TotalAmount = 640.40m },
//        new OrderDto { OrderId = 10, CustomerId = 10, OrderDate = DateTime.Now, TotalAmount = 75.00m }
//    };

//    private static List<OrderLineDto> _orderLines = new List<OrderLineDto>()
//     {
//    new OrderLineDto { OrderLineId = 1, OrderId = 1, ProductId = 101, Quantity = 2, UnitPrice = 50.00m },
//    new OrderLineDto { OrderLineId = 2, OrderId = 1, ProductId = 102, Quantity = 1, UnitPrice = 20.50m },
//    new OrderLineDto { OrderLineId = 3, OrderId = 2, ProductId = 103, Quantity = 2, UnitPrice = 100.00m },
//    new OrderLineDto { OrderLineId = 4, OrderId = 2, ProductId = 104, Quantity = 3, UnitPrice = 50.00m },
//    new OrderLineDto { OrderLineId = 5, OrderId = 3, ProductId = 105, Quantity = 1, UnitPrice = 75.00m },
//    new OrderLineDto { OrderLineId = 6, OrderId = 4, ProductId = 106, Quantity = 2, UnitPrice = 75.00m },
//    new OrderLineDto { OrderLineId = 7, OrderId = 4, ProductId = 107, Quantity = 1, UnitPrice = 30.00m },
//    new OrderLineDto { OrderLineId = 8, OrderId = 5, ProductId = 108, Quantity = 1, UnitPrice = 50.75m },
//    new OrderLineDto { OrderLineId = 9, OrderId = 6, ProductId = 109, Quantity = 5, UnitPrice = 100.00m },
//    new OrderLineDto { OrderLineId = 10, OrderId = 6, ProductId = 110, Quantity = 2, UnitPrice = 50.00m },
//    new OrderLineDto { OrderLineId = 11, OrderId = 7, ProductId = 111, Quantity = 1, UnitPrice = 125.25m },
//    new OrderLineDto { OrderLineId = 12, OrderId = 8, ProductId = 112, Quantity = 2, UnitPrice = 110.05m },
//    new OrderLineDto { OrderLineId = 13, OrderId = 8, ProductId = 113, Quantity = 1, UnitPrice = 100.00m },
//    new OrderLineDto { OrderLineId = 14, OrderId = 9, ProductId = 114, Quantity = 4, UnitPrice = 160.10m },
//    new OrderLineDto { OrderLineId = 15, OrderId = 10, ProductId = 115, Quantity = 1, UnitPrice = 75.00m }
//    };


//    public Task<int> CreateOrderAsync(OrderDto order)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<bool> DeleteOrderAsync(int id)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
//    {
//        return Task.FromResult<IEnumerable<OrderDto>>(_orders);
//    }

//    public Task<OrderDto> GetOrderByIdAsync(int id)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<IEnumerable<OrderLineDto>> GetOrderLinesAsync(int orderId)
//    {
//        var filteredOrderLines = _orderLines.Where(line => line.OrderId == orderId).ToList();
//        return Task.FromResult<IEnumerable<OrderLineDto>>(filteredOrderLines);
//    }

//    public Task<bool> UpdateOrderAsync(OrderDto order)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<bool> UpdateOrderStatusAsync(int currentOrderId, string status)
//    {
//        throw new NotImplementedException();
//    }
//}
