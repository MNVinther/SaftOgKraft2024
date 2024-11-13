using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.DTOs;

namespace WebApiClient
{
    public interface IRestClient
    {
        Task<IEnumerable<ProductDto>> GetProductByPartOfNameOrDescriptionAsync(string partOfNameOrDescription);

        Task<IEnumerable<ProductDto>> GetTenLatestProducts();
        Task<int> CreateProductAsync(ProductDto entity);
        Task<bool> UpdateProductAsync(ProductDto entity);
        Task<bool> DeleteProductAsync(int id);
        //Task<bool> UpdateProductAsync(ProductDto product);

    }
}