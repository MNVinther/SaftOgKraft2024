using RestSharp;
using WebApiClient.DTOs;

namespace WebApiClient
{
    public class RestApiClient : IRestClient
    {
        //restsharp klienten
        private readonly RestClient _restClient;

        //constructor der modtager basis URL'en til APi'et
        //https://localhost:7243/api/v1/

        public RestApiClient(string baseApiUrl)
        {
            _restClient = new RestClient(baseApiUrl);
        }

        public Task<int> CreateProductAsync(ProductDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
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
            if (response.IsSuccessful)
            {
                return response.Data ?? [];
            }
            else
            {
                throw new Exception($"Error getting product by part of name: {response.StatusCode} - {response.StatusDescription}");
            }
        }

        public async Task<IEnumerable<ProductDto>> GetTenLatestProducts()
        {
            // Create a request for the "products" endpoint with a GET method
            var request = new RestRequest($"products", Method.Get);

            // Add a query parameter "filter" with the value "GetTenLatest"
            request.AddParameter("filter", "GetTenLatest");

            // Execute the request asynchronously and deserialize the response to a list of ProductDto objects
            var response = await _restClient.ExecuteAsync<IEnumerable<ProductDto>>(request);
            if (!response.IsSuccessful)
            {
                throw new Exception($"Error retrieving latest products. Message was {response.Content}");
            }
            // Return the data from the response, or an empty list if the data is null
            return response.Data ?? [];
        }

        public Task<bool> UpdateProductAsync(ProductDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
