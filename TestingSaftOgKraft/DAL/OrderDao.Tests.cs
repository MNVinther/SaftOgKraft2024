using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO;
using DAL.Model;
using Dapper;

namespace TestingSaftOgKraft.DAL;
public class OrderDaoTest
{
    private readonly string _connectionstring = "Data Source=hildur.ucn.dk;Initial Catalog=DMA-CSD-S231_10503093;User ID=DMA-CSD-S231_10503093;Password=Password1!;TrustServerCertificate=True;";

    [Test]
    public async Task CreateOrderAsyncTest()
    {
        // Arrange
        var _orderDAO = new OrderDAO(_connectionstring);

        // Simulate product with stock
        var product = new Product() { Id = 1, Name = "Test Product", Description = "Test Description", Price = 50 };

        // Create orderlines for the order
        var orderLines = new List<OrderLine>
        {
        new OrderLine() { ProductId = product.Id, Quantity = 2, UnitPrice = product.Price }
    };

        // Create a test order
        var order = new Order()
        {
            OrderDate = DateTime.Now,
            CustomerId = 1, 
            TotalAmount = product.Price * 2,
            Status = "Pending",
            OrderLines = orderLines
        };

        // Act
        var result = await _orderDAO.CreateOrderAsync(order);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<Order>());

        Assert.Multiple(() =>
        {
            Assert.That(result.OrderId, Is.GreaterThan(0));
            Assert.That(result.OrderDate, Is.EqualTo(order.OrderDate).Within(TimeSpan.FromSeconds(5)));
            Assert.That(result.CustomerId, Is.EqualTo(1));
            Assert.That(result.TotalAmount, Is.EqualTo(order.TotalAmount));
            Assert.That(result.Status, Is.EqualTo("Pending"));
            Assert.That(result.OrderLines, Has.Count.EqualTo(1));

            // Verify orderline values
            var resultOrderLine = result.OrderLines.First();
            Assert.That(resultOrderLine.ProductId, Is.EqualTo(product.Id));
            Assert.That(resultOrderLine.Quantity, Is.EqualTo(2));
            Assert.That(resultOrderLine.UnitPrice, Is.EqualTo(product.Price));
        });
    }

    [Test]
    public async Task GetAllOrdersAsyncTest()
    {
        // Arrange
        var _orderDAO = new OrderDAO(_connectionstring);

        // Act
        var orders = (await _orderDAO.GetAllOrdersAsync()).ToList();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(orders, Is.Not.Null);
            Assert.That(orders.Count, Is.GreaterThan(0));

            // Verify each order has valid properties
            foreach (var order in orders)
            {
                Assert.That(order.OrderId, Is.GreaterThan(0));
                Assert.That(order.CustomerId, Is.GreaterThan(0));
                Assert.That(order.OrderDate, Is.Not.EqualTo(default(DateTime)));
                Assert.That(order.TotalAmount, Is.GreaterThanOrEqualTo(0));
                Assert.That(order.Status, Is.Not.Null.And.Not.Empty);
                Assert.That(order.OrderLines, Is.Not.Null);
            }
        });
    }
   
    [Test]
    public async Task GetOrderLinesAsyncTest()
    {
        // Arrange
        var _orderDAO = new OrderDAO(_connectionstring);
        var testOrderId = 105; 

        // Act
        var orderLines = (await _orderDAO.GetOrderLinesAsync(testOrderId)).ToList();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(orderLines, Is.Not.Null);
            Assert.That(orderLines.Count, Is.GreaterThan(0));

            foreach (var orderLine in orderLines)
            {
                Assert.That(orderLine.OrderId, Is.EqualTo(testOrderId));
                Assert.That(orderLine.Quantity, Is.GreaterThan(0));
                Assert.That(orderLine.UnitPrice, Is.GreaterThan(0));
                Assert.That(orderLine.ProductId, Is.GreaterThan(0));
                Assert.That(orderLine.ProductName, Is.Not.Null.And.Not.Empty);
            }
        });
    }
}
