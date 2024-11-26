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
        var request = new RestRequest("products")
        {
            Method = Method.Get
        };

        var response = await _restClient.ExecuteAsync<IEnumerable<ProductDto>>(request);

        return !response.IsSuccessful
            ? throw new Exception($"Error retrieving all products. Message was {response.Content}")
            : response.Data ?? [];
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

    //public async Task<IEnumerable<ProductDto>> GetTenLatestProducts()
    //{
    //    return await _restClient.Get<IEnumerable<ProductDto>>(new RestRequest("blogposts/latest10"));
    //}


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
}
