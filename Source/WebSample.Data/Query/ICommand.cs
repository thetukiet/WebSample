using System.Data.SqlClient;

namespace WebSample.Data.Query
{
    public interface ICommand<T>
    {
        T Execute(SqlConnection connection);
    }
}
