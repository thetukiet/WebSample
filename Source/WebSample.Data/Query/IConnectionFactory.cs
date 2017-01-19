using System.Data;

namespace WebSample.Data.Query
{
    public interface IConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
