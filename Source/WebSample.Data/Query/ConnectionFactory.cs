using System.Data;
using System.Data.SqlClient;
using WebSample.Data.Configuration;

namespace WebSample.Data.Query
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;

        public ConnectionFactory(ICoreConfiguration configuration)
        {
            _connectionString = configuration.ConnectionString;
        }

        public IDbConnection CreateConnection()
        {
            var result = new SqlConnection(_connectionString);
            result.Open();

            return result;
        }
    }
}
