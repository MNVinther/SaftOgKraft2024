using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.DTOs;

namespace WebApiClient
{
    public class RestApiClient : IRestClient
    {

        //restshart klienten
        RestClient _restClient;

        //constructor der modtager basis URL'en til APi'et
        //https://localhost:7243/api/v1/

        public RestApiClient(string baseApiUrl) => _restClient = new RestClient(baseApiUrl);

        public async Task<int> CreateProductAsync(ProductDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> GetProductByPartOfNameOrDescriptionAsync(string partOfNameOrDescription)
        {
            // Create a request from the Api endpoint
            var request = new RestRequest($"products/search", Method.Get);

            // Add a query parameter to filter by part of the name
            request.AddParameter("searchstring", partOfNameOrDescription);

            // Execute the request and deserialize the response to ProductDto
            var response = await _restClient.ExecuteAsync<IEnumerable<ProductDto>>(request);

            // Check if the latest was successful
            if (response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                throw new Exception($"Error getting product by part of name: {response.StatusCode} - {response.StatusDescription}");
            }
        }

        public async Task<IEnumerable<ProductDto>> GetTenLatestProducts()
        {

            //TRÆK FRA API
            var request = new RestRequest($"products", Method.Get);
            request.AddParameter("filter", "GetTenLatest");
            var response = await _restClient.ExecuteAsync<IEnumerable<ProductDto>>(request);
            if (!response.IsSuccessful)
            {
                throw new Exception($"Error retrieving latest products. Message was {response.Content}");
            }
            return response.Data;
        }

        public async Task<bool> UpdateProductAsync(ProductDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
