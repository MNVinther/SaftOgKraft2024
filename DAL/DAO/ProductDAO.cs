using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DAL.Model;
using System.Collections;

namespace DAL.DAO;

public class ProductDAO : BaseDAO, IProductDAO
{
    // #TODO Not sure about this one - lokal variabel i den metode hvor den skal bruges.
    
    public ProductDAO(string connectionString) : base(connectionString)
    {
    }

    public async Task<IEnumerable<Product>> GetTenLatestProductsAsync()
    {
        try
        {
            // Define the query
            var query = "SELECT TOP(10) ProductId as Id, ProductName as Name, Description, Price FROM Product ORDER BY ProductId DESC";

            // Create and use a new connection
            using var connection = CreateConnection();

            // Execute the query and retrieve the products
            return await connection.QueryAsync<Product>(query);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting latest blog posts: '{ex.Message}'.", ex);
}
}

    public async Task<Product> GetProductByIdAsync(int id)
    {
        try
        {
            var query = "SELECT * FROM Product WHERE ProductId = @Id";
            using var connection = CreateConnection();
            var product = await connection.QueryFirstOrDefaultAsync<Product>(query, new { Id = id });
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} was not found.");
            }
            return product;
        }

        catch (Exception ex)
        {
            throw new Exception($"Error retrieving product with ID {id}: '{ex.Message}'.", ex);
        }
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
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

    public Task<int> InsertAsync(Product product)
    {
        throw new NotImplementedException();
    }
}
