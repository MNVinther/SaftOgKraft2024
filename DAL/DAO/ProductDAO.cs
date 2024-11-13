using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class ProductDAO : BaseDAO, IProductDAO
    {
        // #TODO Not sure about this one
        private const string SELECT_TEN_QUERY = "SELECT TOP(10) Id, Name, Description, Price BY Id DESC";
        public ProductDAO(string connectionString) : base(connectionString)
        {
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetTenLatestProducts()
        {
            using var connection = CreateConnection();
            return connection.Query<Product>(SELECT_TEN_QUERY).ToList();
        }

        public int Insert(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
