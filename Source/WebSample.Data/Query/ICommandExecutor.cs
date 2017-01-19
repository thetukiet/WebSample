
using System.Data;

namespace WebSample.Data.Query
{    
    public interface ICommandExecutor
    {
        T Execute<T>(ICommand<T> cmd);
        int ExecuteNonQuery(string sql, CommandType commandType, object paramAttributes = null);
    }
}

