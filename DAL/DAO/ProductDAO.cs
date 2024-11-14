using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DAL.Model;
using System.Collections;

namespace DAL.DAO
{
    public class ProductDAO : BaseDAO, IProductDAO
    {
        // #TODO Not sure about this one
        private const string SELECT_TEN_QUERY = "SELECT TOP(10) Id, Name, Description, Price FROM Product ORDER BY Id DESC";
        public ProductDAO(string connectionString) : base(connectionString)
        {
        }

        public async Task<IEnumerable<Product>> GetTenLatestProducts()
        {
            try
            {
            using var connection = CreateConnection();
            return await connection.QueryAsync<Product>(SELECT_TEN_QUERY, new { amount = 10 });
        }
            catch (Exception ex)
            {
                throw new Exception($"Error getting latest blog posts: '{ex.Message}'.", ex);
    }
}
        
        Task<Product> Get(int id)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<Product>> GetAll()
        {
            try
            {
                var query = "SELECT * FROM Product";
                using var connection = CreateConnection();
                return (await connection.QueryAsync<Product>(query)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting all blog posts: '{ex.Message}'.", ex);
            }
        }

        Task<int> IProductDAO.Insert(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
