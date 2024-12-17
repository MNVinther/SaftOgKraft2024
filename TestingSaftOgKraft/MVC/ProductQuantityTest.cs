using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaftOgKraft.WebSite.Models;

namespace TestingSaftOgKraft.MVC;
public class ProductQuantityTest
{
    [Test]
    public void GetTotalPriceTest()
    {
        //Arrange
        var productQuantity = new ProductQuantity()
        {
            Price = 25,
            Quantity = 2
        };

        var expectedTotal = productQuantity.GetTotalPrice(); 

        //Act 

        var actualTotal = productQuantity.GetTotalPrice();

        //Assert
        Assert.That(actualTotal, Is.EqualTo(expectedTotal));

    }
}
