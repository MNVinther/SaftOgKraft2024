using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public abstract class BaseDAO
    {
        private string _connectionString;

        public BaseDAO(string connectionString) => _connectionString = connectionString;

        protected IDbConnection CreateConnection();
        {
            return new SQLConnection(_connectionString);
        }

    }
}
