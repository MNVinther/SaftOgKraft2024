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
        IEnumerable<Product> GetTenLatestProducts();
        Product GetProductFromPartOfName(string partOfName);
        int AddProduct(Product product);

    }
}
