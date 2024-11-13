using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaftOgKraft.WebSite.ApiClient.DTO;

namespace SaftOgKraft.WebSite.ApiClient
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