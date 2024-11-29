using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using Dapper;
using System.Data;

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
    // This async method CreateOrder is used for creating an order for the sale on the website.
    // We do so by first checking if we have the requested products in stock. 
    // Then If we have the products we insert an order in DB.
    // Thereafter we insert OrderLines into DB
    // if any of these fails we rollback
    public async Task<Order> CreateOrder(Order entity)
    {
        IDbConnection connection = CreateConnection();
        connection.Open();
        using IDbTransaction transaction = connection.BeginTransaction();

        try
        {
            // Step 1: here we check if there is enough products available
            // and sets a new stock when we have subtracted the amounts needed in the order 
            foreach (var orderLine in entity.OrderLines)
            {
                string updateStockSql = @"
                UPDATE Product
                SET Stock = Stock - @Quantity, Version = NEWID()
                WHERE ProductId = @ProductId AND Stock >= @Quantity AND Version = @ProductRowVersion;
                
                IF (@@ROWCOUNT = 0)
                    THROW 50000, 'Not enough stock available or stock has been modified', 1;";

                await connection.ExecuteAsync(updateStockSql, new
                {
                    ProductId = orderLine.ProductId,
                    Quantity = orderLine.Quantity,
                    ProductRowVersion = orderLine.ProductRowVersion
                }, transaction);
            }

            // Step 2: Here we handle how to insert an order into DB
            string insertOrderSql = @"
            INSERT INTO [Order] (OrderDate, CustomerId, TotalAmount, Status)
            OUTPUT INSERTED.OrderId, INSERTED.Version
            VALUES (@OrderDate, @CustomerId, @TotalAmount, @Status);"; // Status is pending as deafault in DB

            var orderResult = await connection.QuerySingleAsync<(int OrderId, byte[] Version)>(insertOrderSql, entity, transaction);
            entity.OrderId = orderResult.OrderId;
            entity.Version = orderResult.Version;

            // Step 3: Insert OrderLines
            string insertOrderLineSql = @"
            INSERT INTO Orderlines (OrderId, ProductId, Quantity, Price)
            VALUES (@OrderId, @ProductId, @Quantity, @Price);";

            foreach (OrderLine orderLine in entity.OrderLines)
            {
                await connection.ExecuteAsync(insertOrderLineSql, new
                {
                    OrderId = entity.OrderId, 
                    ProductId = orderLine.ProductId,
                    Quantity = orderLine.Quantity,
                    Price = orderLine.UnitPrice,
                }, transaction);
            }

           
            transaction.Commit();

            return entity;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new DataException ("Error creating order", ex); 
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
