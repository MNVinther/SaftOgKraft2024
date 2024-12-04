using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using SaftOgKraft.OrderManager.ApiClient.DTOs;

namespace SaftOgKraft.OrderManager.ApiClient;
public class OrderRestClient : IOrderRestClient
{
    //restsharp klienten
    private readonly RestClient _restClient;  

    //constructor der modtager basis URL'en til APi'et
    //https://localhost:7106/api/v1/


    public OrderRestClient(string baseApiUrl) => _restClient = new RestClient(baseApiUrl);


    public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
    {
        // Create a GET request for the orders
        var request = new RestRequest("orders/all", Method.Get);

        try
        {
            // Execute the request and recive a collection OrderDto
            var response = await _restClient.ExecuteAsync<IEnumerable<OrderDto>>(request);

            if (!response.IsSuccessful)
            {
                // Handle failure by throwing an exception
                throw new Exception($"Error fetching orders: {response.Content}");
            }

            return response.Data ?? new List<OrderDto>();

        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to get Orders: {ex.Message}", ex);
        }

    }
    public async Task<IEnumerable<OrderLineDto>> GetOrderLinesAsync(int orderId)
    {
        // Create a GET request for the orderLines
        var request = new RestRequest($"orders/{orderId}/lines", Method.Get);

        // Execute the request and recive a collection OrderLineDto
        var response = await _restClient.ExecuteAsync<IEnumerable<OrderLineDto>>(request);

        if (!response.IsSuccessful)
        {
            // Handle failure by throwing an exception
            throw new Exception($"Error fetching order lines for order ID {orderId}: {response.Content}");
        }
        return response.Data ?? [];
    }

    //public Task<IEnumerable<OrderLineDto>> GetOrderLinesAsync(int orderId)
    //{
    //    var filteredOrderLines = _orderLines.Where(line => line.OrderId == orderId).ToList();
    //    return Task.FromResult<IEnumerable<OrderLineDto>>(filteredOrderLines);
    //}

    public Task<OrderDto> GetOrderByIdAsync(int id)
    {
        throw new NotImplementedException();
    }


    public Task<bool> UpdateOrderAsync(OrderDto order)
    {
        throw new NotImplementedException();
    }
    public Task<int> CreateOrderAsync(OrderDto order)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteOrderAsync(int id)
    {
        throw new NotImplementedException();
    }
}
