using System;

namespace WebSample.Data.Configuration
{
    public interface IAppSettingManager
    {
        /// <summary>
        /// Reads the connection string with specified key.
        /// </summary>
        string GetConnectionString(string key);

        /// <summary>
        /// Reads a string from the configuration. If string does not exist returns null.
        /// </summary>
        string GetString(string key);

        /// <summary>
        /// Reads a boolean from the configuration. If string does not exist or is not parsed as boolean returns defaultValue.
        /// </summary>
        bool GetBoolean(string key, bool defaultValue = false);

        /// <summary>
        /// Reads an integer from the configuration. If string does not exist or is not parsed as boolean returns defaultValue.
        /// </summary>
        int GetInteger(string key, int defaultValue = 0);

        /// <summary>
        /// Reads a Guid from the configuration.
        /// </summary>
        Guid GetGuid(string key, Guid defaultValue = default(Guid));

        TimeSpan GetTime(string key, TimeSpan defaultTime = default(TimeSpan));
    }
}
