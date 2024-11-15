using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.DAO;
internal interface ITestInterface
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetAsync(int id);
    Task<int> InsertAsync(Product product);
    Task<IEnumerable<Product>> GetTenLatestProductsAsync();
}
