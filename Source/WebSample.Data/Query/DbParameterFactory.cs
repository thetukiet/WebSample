using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace WebSample.Data.Query
{
    public static class DbParameterFactory
    {
        public static DbParameter CreateParameter(string name, object value)
        {
            SqlParameter parameter = CreateParameter(name);
            parameter.Value = value;
            return parameter;
        }

        public static DbParameter CreateParameter(string name, DbType type)
        {
            SqlParameter parameter = CreateParameter(name);
            parameter.DbType = type;
            parameter.Direction = ParameterDirection.Input;
            return parameter;
        }

        public static DbParameter CreateParameter(string name, DbType type, object value)
        {
            SqlParameter parameter = CreateParameter(name);
            parameter.DbType = type;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = value;
            return parameter;
        }

        public static DbParameter CreateParameter(string name, DbType type, ParameterDirection direction)
        {
            SqlParameter parameter = CreateParameter(name);
            parameter.DbType = type;
            parameter.Direction = direction;
            return parameter;
        }

        public static DbParameter CreateParameter(string name, DbType type, int size, ParameterDirection direction)
        {
            SqlParameter parameter = CreateParameter(name);
            parameter.DbType = type;
            parameter.Direction = direction;
            parameter.Size = size;
            return parameter;
        }

        private static SqlParameter CreateParameter(string inputName)
        {
            inputName = inputName.Trim();
            if (inputName.StartsWith("@"))
            {
                inputName = inputName.TrimStart('@');
            }

            var parameterName = "@" + inputName.Trim();

            return new SqlParameter
            {
                ParameterName = parameterName
            };
        }
    }
}
