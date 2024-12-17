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
        var request = new RestRequest($"orders", Method.Get);

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
        var request = new RestRequest($"orders/{orderId}", Method.Get);

        // Execute the request and recive a collection OrderLineDto
        var response = await _restClient.ExecuteAsync<IEnumerable<OrderLineDto>>(request);

        if (!response.IsSuccessful)
        {
            // Handle failure by throwing an exception
            throw new Exception($"Error fetching order lines for order ID {orderId}: {response.Content}");
        }
        return response.Data ?? throw new NullReferenceException("Null reference when trying to get order lines with method GetOrderLinesAsync in OrderRestClient.cs in the OrderManager project.");
    }

    public async Task<bool> UpdateOrderStatusAsync(int orderId, string status)
    {
        // Create a GET request for staus on order
        var request = new RestRequest($"orders/{orderId}", Method.Put);

        // Add the status as a JSON body to the request
        request.AddJsonBody(new { Status = status });

        // Execute the request and get the response
        var response = await _restClient.ExecuteAsync(request);

        if (!response.IsSuccessful)
        {
            // Handle failure by throwing an exception
            throw new Exception($"Error updating order status for order ID {orderId}: {response.Content}");
        }
        return response.IsSuccessful;
    }

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
