using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace WebSample.Data.Query
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly IConnectionFactory _connectionFactory;

        public CommandExecutor(IConnectionFactory factory)
        {
            _connectionFactory = factory;
        }

        public T Execute<T>(ICommand<T> cmd)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                return cmd.Execute((SqlConnection)connection);
            }
        }

        
        // TODO: Need to setup with Transaction and Command Timeout
        public int ExecuteNonQuery(string sql, CommandType commandType, object paramAttributes = null)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var command = connection.CreateCommand();
                command.CommandType = commandType;
                command.CommandText = sql;
                SetupParameters(command, paramAttributes);
                return command.ExecuteNonQuery();
            }
        }


        // TODO: Need to setup with Transaction and Command Timeout
        public object ExecuteScalar(string sql, CommandType commandType, object paramAttributes = null)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var command = connection.CreateCommand();
                command.CommandType = commandType;
                command.CommandText = sql;
                SetupParameters(command, paramAttributes);
                return command.ExecuteScalar();
            }
        }


        internal void SetupParameters(IDbCommand command, object paramAttributes)
        {
            if (paramAttributes == null)
                return;
            
            var defineParams = TypeDescriptor.GetProperties(paramAttributes);
            foreach (PropertyDescriptor param in defineParams)
            {
                var usingParam = DbParameterFactory.CreateParameter(param.Name, param.GetValue(paramAttributes));
                command.Parameters.Add(usingParam);
            }
        }
    }
}

