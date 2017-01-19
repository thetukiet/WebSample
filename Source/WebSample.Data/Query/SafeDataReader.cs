using System;
using System.Data;
using System.Xml;

namespace WebSample.Data.Query
{
    public class SafeDataReader : IDataReader
    {
        protected IDataReader DataReader;

        /// <summary>
        /// Initializes the SafeDataReader object to use data from
        /// the provided DataReader object.
        /// </summary>
        /// <param name="dataReader">The source DataReader object containing the data.</param>
        public SafeDataReader(IDataReader dataReader)
        {
            DataReader = dataReader;
        }

        /// <summary>
        /// Gets a string value from the datareader.
        /// </summary>
        /// <remarks>
        /// Returns "" for null.
        /// </remarks>
        public string GetString(string name)
        {
            return GetString(DataReader.GetOrdinal(name));
        }

        public string GetString(int i)
        {
            if (DataReader.IsDBNull(i))
                return string.Empty;
            return DataReader.GetString(i);
        }


        /// <summary>
        /// Gets a value of type <see cref="System.Object" /> from the datareader.
        /// </summary>
        /// <remarks>
        /// Returns Nothing for null.
        /// </remarks>
        public object GetValue(string name)
        {
            return GetValue(DataReader.GetOrdinal(name));
        }

        public object GetValue(int i)
        {
            if (DataReader.IsDBNull(i))
                return null;
            return DataReader.GetValue(i);
        }

        /// <summary>
        /// Gets an integer from the datareader.
        /// </summary>
        /// <remarks>
        /// Returns 0 for null.
        /// </remarks>
        public int GetInt32(string name)
        {
            return GetInt32(DataReader.GetOrdinal(name));
        }

        public int GetInt32(int i)
        {
            if (DataReader.IsDBNull(i))
                return 0;
            return DataReader.GetInt32(i);
        }

        public int? GetNullableInt32(string name)
        {
            return GetNullableInt32(DataReader.GetOrdinal(name));
        }

        public int? GetNullableInt32(int i)
        {
            if (DataReader.IsDBNull(i))
                return null;
            return DataReader.GetInt32(i);
        }

        /// <summary>
        /// Gets a double from the datareader.
        /// </summary>
        /// <remarks>
        /// Returns 0 for null.
        /// </remarks>
        public double GetDouble(string name)
        {
            return GetDouble(DataReader.GetOrdinal(name));
        }

        public double GetDouble(int i)
        {
            if (DataReader.IsDBNull(i))
                return 0;
            return DataReader.GetDouble(i);
        }

        public double? GetNullableDouble(string name)
        {
            return GetNullableDouble(DataReader.GetOrdinal(name));
        }

        public double? GetNullableDouble(int i)
        {
            if (DataReader.IsDBNull(i))
                return null;
            return DataReader.GetDouble(i);
        }


        /// <summary>
        /// Gets a Guid value from the datareader.
        /// </summary>
        public Guid GetGuid(string name)
        {
            return GetGuid(DataReader.GetOrdinal(name));
        }

        public Guid GetGuid(int i)
        {
            if (DataReader.IsDBNull(i))
                return Guid.Empty;
            return DataReader.GetGuid(i);
        }

        public Guid? GetNullableGuid(string name)
        {
            return GetNullableGuid(DataReader.GetOrdinal(name));
        }

        public Guid? GetNullableGuid(int i)
        {
            if (DataReader.IsDBNull(i))
            {
                return null;
            }
            return DataReader.GetGuid(i);
        }

        /// <summary>
        /// Reads the next row of data from the datareader.
        /// </summary>
        public bool Read()
        {
            return DataReader.Read();
        }

        /// <summary>
        /// Moves to the next result set in the datareader.
        /// </summary>
        public bool NextResult()
        {
            return DataReader.NextResult();
        }

        /// <summary>
        /// Closes the datareader.
        /// </summary>
        public void Close()
        {
            DataReader.Close();
        }

        /// <summary>
        /// Returns the depth property value from the datareader.
        /// </summary>
        public int Depth
        {
            get
            {
                return DataReader.Depth;
            }
        }

        /// <summary>
        /// Returns the FieldCount property from the datareader.
        /// </summary>
        public int FieldCount
        {
            get
            {
                return DataReader.FieldCount;
            }
        }

        /// <summary>
        /// Gets a boolean value from the datareader.
        /// </summary>
        public bool GetBoolean(string name)
        {
            return GetBoolean(DataReader.GetOrdinal(name));
        }

        public bool GetBoolean(int i)
        {
            if (DataReader.IsDBNull(i))
                return false;
            return DataReader.GetBoolean(i);
        }

        public bool? GetNullableBoolean(string name)
        {
            return GetNullableBoolean(DataReader.GetOrdinal(name));
        }

        public bool? GetNullableBoolean(int i)
        {
            if (DataReader.IsDBNull(i))
                return null;
            return DataReader.GetBoolean(i);
        }

        /// <summary>
        /// Gets a byte value from the datareader.
        /// </summary>
        public byte GetByte(string name)
        {
            return GetByte(DataReader.GetOrdinal(name));
        }

        public byte GetByte(int i)
        {
            if (DataReader.IsDBNull(i))
                return 0;
            return DataReader.GetByte(i);
        }

        /// <summary>
        /// Invokes the GetBytes method of the underlying datareader.
        /// </summary>
        public Int64 GetBytes(string name, Int64 fieldOffset,
                              byte[] buffer, int bufferoffset, int length)
        {
            return GetBytes(DataReader.GetOrdinal(name), fieldOffset, buffer, bufferoffset, length);
        }

        public Int64 GetBytes(int i, Int64 fieldOffset,
                              byte[] buffer, int bufferoffset, int length)
        {
            if (DataReader.IsDBNull(i))
                return 0;
            return DataReader.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
        }

        /// <summary>
        /// Gets a char value from the datareader.
        /// </summary>
        public char GetChar(string name)
        {
            return GetChar(DataReader.GetOrdinal(name));
        }

        public char GetChar(int i)
        {
            if (DataReader.IsDBNull(i))
                return char.MinValue;
            char[] myChar = new char[1];
            DataReader.GetChars(i, 0, myChar, 0, 1);
            return myChar[0];
        }

        /// <summary>
        /// Invokes the GetChars method of the underlying datareader.
        /// </summary>
        public Int64 GetChars(string name, Int64 fieldoffset,
                              char[] buffer, int bufferoffset, int length)
        {
            return GetChars(DataReader.GetOrdinal(name), fieldoffset, buffer, bufferoffset, length);
        }

        public Int64 GetChars(int i, Int64 fieldoffset,
                              char[] buffer, int bufferoffset, int length)
        {
            if (DataReader.IsDBNull(i))
                return 0;
            return DataReader.GetChars(i, fieldoffset, buffer, bufferoffset, length);
        }

        /// <summary>
        /// Invokes the GetData method of the underlying datareader.
        /// </summary>
        public IDataReader GetData(string name)
        {
            return GetData(DataReader.GetOrdinal(name));
        }

        public IDataReader GetData(int i)
        {
            return DataReader.GetData(i);
        }

        /// <summary>
        /// Invokes the GetDataTypeName method of the underlying datareader.
        /// </summary>
        public string GetDataTypeName(string name)
        {
            return GetDataTypeName(DataReader.GetOrdinal(name));
        }

        public string GetDataTypeName(int i)
        {
            return DataReader.GetDataTypeName(i);
        }

        /// <summary>
        /// Gets a date value from the datareader.
        /// </summary>
        public DateTime GetDateTime(string name)
        {
            return GetDateTime(DataReader.GetOrdinal(name));
        }

        public DateTime GetDateTime(int i)
        {
            if (DataReader.IsDBNull(i))
                return DateTime.MinValue;
            return DataReader.GetDateTime(i);
        }

        public DateTime? GetNullableDateTime(string name)
        {
            return GetNullableDateTime(DataReader.GetOrdinal(name));
        }

        public DateTime? GetNullableDateTime(int i)
        {
            if (DataReader.IsDBNull(i))
                return null;
            return DataReader.GetDateTime(i);
        }

        public decimal GetDecimal(string name)
        {
            return GetDecimal(DataReader.GetOrdinal(name));
        }

        public decimal GetDecimal(int i)
        {
            if (DataReader.IsDBNull(i))
                return 0;
            return DataReader.GetDecimal(i);
        }

        public decimal? GetNullableDecimal(string name)
        {
            return GetNullableDecimal(DataReader.GetOrdinal(name));
        }

        public decimal? GetNullableDecimal(int i)
        {
            if (DataReader.IsDBNull(i))
                return null;
            return DataReader.GetDecimal(i);
        }

        /// <summary>
        /// Invokes the GetFieldType method of the underlying datareader.
        /// </summary>
        public Type GetFieldType(string name)
        {
            return GetFieldType(DataReader.GetOrdinal(name));
        }

        public Type GetFieldType(int i)
        {
            return DataReader.GetFieldType(i);
        }

        /// <summary>
        /// Gets a Single value from the datareader.
        /// </summary>
        public float GetFloat(string name)
        {
            return GetFloat(DataReader.GetOrdinal(name));
        }

        public float GetFloat(int i)
        {
            if (DataReader.IsDBNull(i))
                return 0;
            return DataReader.GetFloat(i);
        }

        /// <summary>
        /// Gets a Short value from the datareader.
        /// </summary>
        public short GetInt16(string name)
        {
            return GetInt16(DataReader.GetOrdinal(name));
        }

        public short GetInt16(int i)
        {
            if (DataReader.IsDBNull(i))
                return 0;
            return DataReader.GetInt16(i);
        }

        public short? GetNullableInt16(string name)
        {
            return GetNullableInt16(DataReader.GetOrdinal(name));
        }

        public short? GetNullableInt16(int i)
        {
            if (DataReader.IsDBNull(i))
                return null;
            return DataReader.GetInt16(i);
        }

        /// <summary>
        /// Gets a Long value from the datareader.
        /// </summary>
        public Int64 GetInt64(string name)
        {
            return GetInt64(DataReader.GetOrdinal(name));
        }

        public Int64 GetInt64(int i)
        {
            if (DataReader.IsDBNull(i))
                return 0;
            return DataReader.GetInt64(i);
        }

        /// <summary>
        /// Gets an XML document from the datareader
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public XmlDocument GetXml(string name)
        {
            return GetXml(DataReader.GetOrdinal(name));
        }

        /// <summary>
        /// Gets an XML document from the datareader
        /// </summary>
        /// <returns></returns>
        public XmlDocument GetXml(int i)
        {
            XmlDocument doc = new XmlDocument();
            if (DataReader.IsDBNull(i))
            {
                return doc;
            }
            doc.LoadXml(DataReader.GetString(i));
            return doc;
        }

        /// <summary>
        /// Invokes the GetName method of the underlying datareader.
        /// </summary>
        public string GetName(int i)
        {
            return DataReader.GetName(i);
        }

        /// <summary>
        /// Gets an ordinal value from the datareader.
        /// </summary>
        public int GetOrdinal(string name)
        {
            return DataReader.GetOrdinal(name);
        }

        /// <summary>
        /// Determines if a column exists in the result set
        /// This method will loop through the fields which can have a small performance hit 
        /// if you use it a lot and you may want to consider caching the results
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public bool HasColumn(string columnName)
        {
            for (int i = 0; i < DataReader.FieldCount; i++)
            {
                if (DataReader.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase)) return true;
            }
            return false;
        }

        /// <summary>
        /// Invokes the GetSchemaTable method of the underlying datareader.
        /// </summary>
        public DataTable GetSchemaTable()
        {
            return DataReader.GetSchemaTable();
        }


        /// <summary>
        /// Invokes the GetValues method of the underlying datareader.
        /// </summary>
        public int GetValues(object[] values)
        {
            return DataReader.GetValues(values);
        }

        /// <summary>
        /// Returns the IsClosed property value from the datareader.
        /// </summary>
        public bool IsClosed
        {
            get
            {
                return DataReader.IsClosed;
            }
        }

        /// <summary>
        /// Invokes the IsDBNull method of the underlying datareader.
        /// </summary>
        public bool IsDBNull(int i)
        {
            return DataReader.IsDBNull(i);
        }

        public bool IsDBNull(string name)
        {
            return IsDBNull(GetOrdinal(name));
        }

        /// <summary>
        /// Returns a value from the datareader.
        /// </summary>
        /// <remarks>
        /// Returns Nothing if the value is null.
        /// </remarks>
        public object this[string name]
        {
            get
            {
                object val = DataReader[name];
                if (DBNull.Value.Equals(val))
                    return null;
                return val;
            }
        }

        /// <summary>
        /// Returns a value from the datareader.
        /// </summary>
        /// <remarks>
        /// Returns Nothing if the value is null.
        /// </remarks>
        public object this[int i]
        {
            get
            {
                if (DataReader.IsDBNull(i))
                    return null;
                return DataReader[i];
            }
        }

        /// <summary>
        /// Returns the RecordsAffected property value from the underlying datareader.
        /// </summary>
        public int RecordsAffected
        {
            get
            {
                return DataReader.RecordsAffected;
            }
        }


        /// <summary>
        /// Calls the Dispose method on the underlying datareader.
        /// </summary>
        public void Dispose()
        {
            DataReader.Dispose();
        }
    }
}