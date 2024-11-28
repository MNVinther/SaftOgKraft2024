using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaftOgKraft.WebSite.ApiClient.DTOs;

namespace SaftOgKraft.WebSite.ApiClient
{
    public interface IRestClient
    {
        Task<IEnumerable<ProductDto>> GetProductByPartOfNameOrDescriptionAsync(string partOfNameOrDescription);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();

        Task<IEnumerable<ProductDto>> GetTenLatestProducts();

        Task<ProductDto> GetProductByIdAsync(int id);
        Task<int> CreateProductAsync(ProductDto product);
        Task<bool> UpdateProductAsync(ProductDto product);
        Task<bool> DeleteProductAsync(int id);
        //Task<bool> UpdateProductAsync(ProductDto product);

    }
}
