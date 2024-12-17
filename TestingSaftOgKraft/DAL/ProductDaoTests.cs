using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using NUnit.Framework;
using DAL.Model;
using DAL.DAO;
using System.Data;
using SaftOgKraft.WebApi.Controllers;

public class ProductDAOTest
{
    private readonly string _connectionstring = "Data Source=hildur.ucn.dk;Initial Catalog=DMA-CSD-S231_10503093;User ID=DMA-CSD-S231_10503093;Password=Password1!;TrustServerCertificate=True;";

    [Test]
    public async Task GetTenLatestProductsTest()
    {
        //Arrange
        var _productDAO = new ProductDAO(_connectionstring);
        //Act
        var products = (await _productDAO.GetTenLatestProductsAsync()).ToList();
        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(products, Is.Not.Null);
            Assert.That(products.Count, Is.EqualTo(10));
            Assert.That(products, Is.Ordered.Descending.By(nameof(Product.Id)));
        });

    }
    
    [Test]
    public async Task GetAllProductsTest()
    {
        //Arange
        var _productDAO = new ProductDAO(_connectionstring);
        //Act
        var products = (await _productDAO.GetAllAsync()).ToList();
        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(products, Is.Not.Null);
            Assert.That(products.Count(), Is.EqualTo(15));
            Assert.That(products, Is.All.Not.Null);

        });
    }

    [Test]
    public async Task GetProductByIdAsyncValidIdTest()
    {
        //Arrange
        var _ProductDAO = new ProductDAO(_connectionstring);
        var validId = 1;

        //Act
        var product = await _ProductDAO.GetProductByIdAsync(validId);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(product, Is.Not.Null);
            Assert.That(product.Id, Is.EqualTo(validId));
            Assert.That(product.Name, Is.Not.Null.Or.Empty);
            Assert.That(product.Price, Is.GreaterThan(0));
        });
    }

  




}
