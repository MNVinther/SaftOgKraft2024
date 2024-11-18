using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient; Udkommenteret da denne var blevet Obsolete, og anbefaling er at man bruger Microsoft.Data.SqlClient.
using Microsoft.Data.SqlClient;
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
        protected BaseDAO(string connectionString) => _connectionString = connectionString;

        // Method to create a new SQL connection
        // Return a new SqlConnection object using the provided connection string
        protected IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
