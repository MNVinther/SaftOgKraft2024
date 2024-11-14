using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.DAO
{
    public interface IProductDAO
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> Get(int id);
        Task<int> Insert(Product product);
        Task<IEnumerable<Product>> GetTenLatestProducts();
    }
}
