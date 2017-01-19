using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace WebSample.Data.Query
{
    public static class ExecuteStrategy
    {
        public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            int result;
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = commandType;
                command.CommandText = commandText;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                result = command.ExecuteNonQuery();
            }
            return result;
        }

        public static object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            object result;
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = commandType;
                command.CommandText = commandText;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                result = command.ExecuteScalar();
            }
            return result;
        }


        public static void ExecuteDataReader(SqlConnection connection, CommandType commandType, string commandText, Action<IDataReader> processData, params DbParameter[] parameters)
        {
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = commandType;
                command.CommandText = commandText;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                using (IDataReader dataReader = command.ExecuteReader())
                {
                    processData(new SafeDataReader(dataReader));
                }
            }
        }

        public static DataTable ExecuteDataTable(SqlConnection connection, CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            var result = new DataTable();
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = commandType;
                command.CommandText = commandText;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(result);
                }
            }
            return result;
        }


        public static DataSet ExecuteDataSet(SqlConnection connection, CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            var result = new DataSet();
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = commandType;
                command.CommandText = commandText;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(result);
                }
            }
            return result;
        }        
    }
}