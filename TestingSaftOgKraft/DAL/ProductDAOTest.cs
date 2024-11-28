using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DAL.DAO;
using System.Text;
using DAL.Model;

namespace TestingSaftOgKraft.DAL;
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


}
