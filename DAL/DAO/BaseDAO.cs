using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DAL.DAO
{
    public abstract class BaseDAO
    {
        private readonly string _connectionString;

        // Constructor to initialize the connection string
        public BaseDAO(string connectionString) => _connectionString = connectionString;

        // Method to create a new SQL connection
        protected IDbConnection CreateConnection()
        {
            // Return a new SqlConnection object using the provided connection string
            return new SqlConnection(_connectionString);
        }
    }
}
