using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace TestingSaftOgKraft.DB;
[TestFixture]
public class ConnectionStringTest
{
    [Test]
    public void TestDatabaseConnection()
    {
        // Arrange
        string connectionString = "Data Source=hildur.ucn.dk;Initial Catalog=DMA-CSD-S231_10503093;User ID=DMA-CSD-S231_10503093;Password=Password1!;TrustServerCertificate=True;";

        // Act & Assert
        Assert.DoesNotThrow(() =>
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
            }
        }, "The connection string is invalid or the database is unavailable.");
    }
}
