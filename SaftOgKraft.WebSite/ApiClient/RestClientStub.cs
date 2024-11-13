// using NPOI.SS.Formula.Functions; What is this?
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.DTOs;

namespace WebApiClient
{
    public class RestClientStub : IRestClient
    {
        private static List<ProductDto> _products = new List<ProductDto>()
        {
            new ProductDto() { Id = 1, Name = "KraftigSaft", Price = 10, Description = "Den lækreste saft" },
            new ProductDto() { Id = 2, Name = "SødeSaft", Price = 8, Description = "Sød og frugtrig saft" },
            new ProductDto() { Id = 3, Name = "CitrusSaft", Price = 12, Description = "Frisk citrussmag" },
            new ProductDto() { Id = 4, Name = "BærrySaft", Price = 11, Description = "Fuld af bærsmag" },
            new ProductDto() { Id = 5, Name = "GrønSaft", Price = 9, Description = "Grøn smoothie" },
            new ProductDto() { Id = 6, Name = "6Saft", Price = 8, Description = "Sød og frugtrig saft" },
            new ProductDto() { Id = 7, Name = "7Saft", Price = 12, Description = "Frisk citrussmag" },
            new ProductDto() { Id = 8, Name = "8Saft", Price = 11, Description = "Fuld af bærsmag" },
            new ProductDto() { Id = 9, Name = "9Saft", Price = 9, Description = "Grøn smoothie" },
            new ProductDto() { Id = 10, Name = "10Saft", Price = 9, Description = "Grøn smoothie" },
        };

        public Task<int> CreateProductAsync(ProductDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetProductByPartOfNameOrDescriptionAsync(string partOfNameOrDescription)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetTenLatestProducts()
        {
            // Get the first 10 products from the _products collection
            var products = _products.Take(10);

            // Return the selected products as a completed task (to match the asynchronous method signature)
            return Task.FromResult(products);
        }


        public Task<bool> UpdateProductAsync(ProductDto entity)
        {
            throw new NotImplementedException();
        }
    }
}