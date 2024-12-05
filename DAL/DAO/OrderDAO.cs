using System;
using System.Collections.Generic;
using System.Data;
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
    // This async method CreateOrder is used for creating an order for the sale on the website.
    // We do so by first checking if we have the requested products in stock. 
    // Then If we have the products we insert an order in DB.
    // Thereafter we insert OrderLines into DB
    // if any of these fails we rollback
    public async Task<Order> CreateOrderAsync(Order entity)
    {
        using var connection = CreateConnection();
        connection.Open();
        using var transaction = connection.BeginTransaction();

        try
        {
            // Step 1: Insert Order
            string insertOrderSql = @"
        INSERT INTO [Order] (OrderDate, CustomerId, TotalAmount)
        OUTPUT INSERTED.OrderId, INSERTED.Version
        VALUES (@OrderDate, @CustomerId, @TotalAmount);";

            var orderResult = await connection.QuerySingleAsync<(int OrderId, byte[] Version)>(insertOrderSql, entity, transaction);
            entity.OrderId = orderResult.OrderId;
            entity.Version = orderResult.Version;

            // Step 2: Insert OrderLines
            string insertOrderLineSql = @"
        INSERT INTO OrderLine (OrderId, ProductId, Quantity, UnitPrice)
        VALUES (@OrderId, @ProductId, @Quantity, @UnitPrice);";

            foreach (var orderLine in entity.OrderLines)
            {
                // Insert the OrderLine
                await connection.ExecuteAsync(insertOrderLineSql, new
                {
                    OrderId = entity.OrderId,
                    ProductId = orderLine.ProductId,
                    Quantity = orderLine.Quantity,
                    UnitPrice = orderLine.UnitPrice
                }, transaction);

                // Step 3: Deduct Stock for the Product
                string updateProductStockSql = @"
            UPDATE Product
            SET Stock = Stock - @Quantity
            WHERE ProductId = @ProductId AND Stock >= @Quantity;

            IF (@@ROWCOUNT = 0)
                THROW 50000, 'Not enough stock available or stock has been modified.', 1;";

                await connection.ExecuteAsync(updateProductStockSql, new
                {
                    ProductId = orderLine.ProductId,
                    Quantity = orderLine.Quantity
                }, transaction);
            }

            // Commit transaction
            transaction.Commit();
            return entity;
        }
        catch (Exception ex)
        {
            // Rollback transaction in case of error
            transaction.Rollback();
            throw new DataException("Error creating order and updating stock", ex);
        }
    }

    // This method retrieves all orders from the database

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        try
        {
            var query = "SELECT * FROM [dbo].[Order]";
            using var connection = CreateConnection();
            return (await connection.QueryAsync<Order>(query)).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error fetching all orders: {ex.Message}", ex);
        }
    }

    // This method retrieves all order lines associated with a specific order ID from the database
    public async Task<IEnumerable<OrderLine>> GetOrderLinesAsync(int orderId)
    {
        try
        {
            var query = "SELECT ol.* FROM [dbo].[OrderLine] ol INNER JOIN [dbo].[Order] o ON ol.OrderId = o.OrderId WHERE ol.OrderId = @OrderId";
            using var connection = CreateConnection();
            return (await connection.QueryAsync<OrderLine>(query, new { OrderId = orderId })).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error fetching order lines for order ID {orderId}: {ex.Message}", ex);
        }
    }

    //public async Task<Order> GetOrderByIdAsync(int orderId)
    //{
    //    try
    //    {
    //        var query = "SELECT * FROM [dbo].[Order] WHERE OrderId = @orderId";
    //        using var connection = CreateConnection();
    //        return (await connection.QueryAsync<Order>(query, new { OrderId = orderId })).ToList();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception($"Error fetching all orders: {ex.Message}", ex);
    //    }
    //}



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
