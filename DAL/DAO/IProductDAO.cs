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
        IEnumerable<Product> GetAll();
        Product Get(int id);
        int Insert(Product product);
        IEnumerable<Product> GetTenLatestProducts();
    }
}
