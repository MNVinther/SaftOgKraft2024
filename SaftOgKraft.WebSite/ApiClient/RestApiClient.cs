using RestSharp;
using SaftOgKraft.WebSite.ApiClient.DTOs;

namespace SaftOgKraft.WebSite.ApiClient;

public class RestApiClient : IRestClient
{
    //restsharp klienten
    private readonly RestClient _restClient;


    //constructor der modtager basis URL'en til APi'et
    //https://localhost:7106/api/v1/

    public RestApiClient(string baseApiUrl)
    {
        _restClient = new RestClient(baseApiUrl);
    }

    public RestApiClient(RestClient mockClient)
    {
        _restClient = mockClient;
    }


    public async Task<int> CreateProductAsync(ProductDto product)
    {
        var request = new RestRequest("products", Method.Post)
                      .AddJsonBody(product);
        //var response = await _restClient.ExecuteAsync<IEnumerable<ProductDto>>(request);
        var response = await _restClient.ExecuteAsync<int>(request);
        return !response.IsSuccessful
            ? throw new Exception($"Error creating product. Status: {response.StatusCode}, Message: {response.Content}")
            : response.Data;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var request = new RestRequest($"products/{id}", Method.Delete);
        var response = await _restClient.ExecuteAsync<bool>(request);
        return !response.IsSuccessful
            ? throw new Exception($"Error deleting product. Status: {response.StatusCode}, Message: {response.Content}")
            : response.Data;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var request = new RestRequest("products/all")
        {
            Method = Method.Get
        };

        var response = await _restClient.ExecuteAsync<IEnumerable<ProductDto>>(request);

        return !response.IsSuccessful
            ? throw new Exception($"Error retrieving all products. Message was {response.Content}")
            : response.Data ?? [];
    }

    public async Task<IEnumerable<ProductDto>?> GetSortedProductsAsync(string sortOrder = "")
    {
            var request = new RestRequest($"products/sorted?sortOrder={sortOrder}", Method.Get);
            //request.Method = Method.Get;

            var response = await _restClient.ExecuteAsync<IEnumerable<ProductDto>>(request);
        return !response.IsSuccessful
                ? throw new Exception($"Error retrieving sorted products. Message was {response.Content}")
                : response.Data;
    }

    public async Task<IEnumerable<ProductDto>> GetProductByPartOfNameOrDescriptionAsync(string partOfNameOrDescription)
    {
        // Create a request from the Api endpoint
        var request = new RestRequest($"products/search", Method.Get);

        // Add a query parameter "searchstring" to the request
        // This parameter filters products based on part of their name or description
        request.AddParameter("searchstring", partOfNameOrDescription);

        // Execute the request and deserialize the response to ProductDto
        var response = await _restClient.ExecuteAsync<IEnumerable<ProductDto>>(request);

        // Check if the latest was successful
        return response.IsSuccessful
            ? response.Data ?? []
            : throw new Exception($"Error getting product by part of name: {response.StatusCode} - {response.StatusDescription}");
    }   
   
    public async Task<IEnumerable<ProductDto>> GetTenLatestProducts()
    {
        // Create a request for the "products" endpoint with a GET method
        var request = new RestRequest($"products/ten-latest", Method.Get);

        // Add a query parameter "filter" with the value "GetTenLatest"
        //request.AddParameter("filter", "latest10");

        // Execute the request asynchronously and deserialize the response to a list of ProductDto objects
        var response = await _restClient.ExecuteAsync<IEnumerable<ProductDto>>(request);
        if (!response.IsSuccessful)
        {
            throw new Exception($"Error retrieving latest products. Message was {response.Content}");
        }

        // Nullcheck
        if (response.Data == null)
        {
            throw new Exception($"The response was null. Message was {response.Content}");
            
          }
        // Return the data from the response, or an empty list if the data is null
        return response.Data;
    }


    // Updating a product by sending a PUT request
    public async Task<ProductDto> GetProductByIdAsync(int id)
    {

            var request = new RestRequest($"products/{id}", Method.Get);

        var response = await _restClient.ExecuteAsync<ProductDto>(request);
        return !response.IsSuccessful
            ? throw new Exception($"Error retrieving product with ID {id}. Message was: {response.Content}")
            : response.Data;
    }

    // public Task<bool> UpdateProductAsync(ProductDto entity)
    public async Task<bool> UpdateProductAsync(ProductDto product)
    {
        var request = new RestRequest($"products/{product.Id}", Method.Put)
                      .AddJsonBody(product);
        var response = await _restClient.ExecuteAsync<bool>(request);
        return !response.IsSuccessful
            ? throw new Exception($"Error updating product. Status: {response.StatusCode}, Message: {response.Content}")
            : response.Data;
            }


    public async Task<OrderDto> CreateOrderAsync(OrderDto order)
    {
        var request = new RestRequest($"orders/create", Method.Post);

        request.AddJsonBody(order);

        var response = await _restClient.ExecuteAsync<OrderDto>(request);

        if (!response.IsSuccessful)
        {
            throw new Exception($"Error creating new order: {response.ErrorMessage}");
        }
        return response.Data;
    }

}








#region method graveyard
// Retrieves the ten latest products by sending a GET request
// public async Task<IEnumerable<ProductDto>> GetTenLatestProducts()
// {
// Create a GET request for products get ten latest
// var request = new RestRequest($"products/ten-latest", Method.Get);

// Add a query parameter "filter" with the value "GetTenLatest"
//request.AddParameter("filter", "latest10");

// Execute the request and recive a collection of ProductDto
// var response = await _restClient.ExecuteAsync<IEnumerable<ProductDto>>(request);
// if (!response.IsSuccessful)
// {
// Handle failure by throwing an exception
// throw new Exception($"Error retrieving latest products. Message was {response.Content}");
// }
// Return a list of products or an empty list 
// return response.Data;
// }

//public async Task<IEnumerable<ProductDto>> GetTenLatestProducts()
//{
//    return await _restClient.Get<IEnumerable<ProductDto>>(new RestRequest("blogposts/latest10"));
//}

//public async Task<int> CreateProductAsync(ProductDto product)
//    {
//        // Create a POST request for products and add the product data as JSON.
//        var request = new RestRequest("products", Method.Post)
//                      .AddJsonBody(product);

//        // Execute the request 
//        var response = await _restClient.ExecuteAsync<int>(request);
//        if (!response.IsSuccessful)
//        {
//        // Handle failure by throwing an exception
//            throw new Exception($"Error creating product. Status: {response.StatusCode}, Message: {response.Content}");
//        }

//        // Return the product ID if the request was successful
//        return response.Data;
//    }

// public async Task<bool> UpdateProductAsync(ProductDto product)
// {
// Create a PUT request for product id
// var request = new RestRequest($"products/{product.Id}", Method.Put)
// .AddJsonBody(product);
// Execute the request and recive a collection of ProductDto
// var response = await _restClient.ExecuteAsync<bool>(request);
// if (!response.IsSuccessful)
// {
// Handle failure by throwing an exception
// throw new Exception($"Error updating product. Status: {response.StatusCode}, Message: {response.Content}");
// }
// Return true if the product was updated
// return response.Data;
// }

// Searches for products by part of their name or description.
// public async Task<IEnumerable<ProductDto>> GetProductByPartOfNameOrDescriptionAsync(string partOfNameOrDescription)
// {
// Create a GET request for products search
// var request = new RestRequest($"products/search", Method.Get);

// Add a query parameter "searchstring" to the request
// This parameter filters products based on part of their name or description
// request.AddParameter("searchstring", partOfNameOrDescription);

// Execute the request and recive a collection of ProductDto
//  var response = await _restClient.ExecuteAsync<IEnumerable<ProductDto>>(request);

// Check if the latest was successful
// if (response.IsSuccessful)
// {
//    return response.Data ?? [];
// }
//else
//{
//     throw new Exception($"Error getting product by part of name: {response.StatusCode} - {response.StatusDescription}");
//   }
// }

// Retrieves all products by sending a GET request
// public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
// {
//   // Create a GET request for the products
// var request = new RestRequest("products");
// request.Method = Method.Get;

// Execute the request and recive a collection of ProductDto
// var response = await _restClient.ExecuteAsync<IEnumerable<ProductDto>>(request);

// if (!response.IsSuccessful)
// {
// Handle failure by throwing an exception
// throw new Exception($"Error retrieving all products. Message was {response.Content}");
// }
// return response.Data ?? Enumerable.Empty<ProductDto>();
// }  
#endregion

