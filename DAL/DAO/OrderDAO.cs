using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using Dapper;

namespace DAL.DAO;
public class OrderDAO : BaseDAO, IOrderDAO
{
    public OrderDAO(string connectionString) : base(connectionString)
    {
    }

    #region !!-- Crud section for Order. --!!
    public async Task<int> InsertOrderAsync(Order entity)
    {
        // TODO: Kig på values om de skal parses som "entity.property" .
        try
        {
        var query = 
            "INSERT INTO Order (OrderId, OrderDate, CustomerId, TotalAmount, Status) " +
            "OUTPUT INSERTED.Id " +
            "VALUES (@OrderId, @OrderDate, @CustomerId, @TotalAmount, @Status";
        using var connection = CreateConnection();
        return await connection.QuerySingleAsync<int>(query, entity);

        }
        catch (Exception ex)
        {
            throw new Exception($"Error inserting new order: '{ex.Message}'.", ex);
        }
    }
    #endregion
}



#region Unused code
//public async Task<IEnumerable<Order>> GetAllOrdersAsync()
//{
//    var query = "SELECT OrderId, OrderDate, CustomerId, TotalAmount, Status FROM Order ORDER BY OrderId DESC";

//    using var connection = CreateConnection();

//    return await connection.QueryAsync<Order>(query);
//}
#endregion
