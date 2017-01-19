using System;
using System.Collections.Specialized;
using System.Configuration;

namespace WebSample.Data.Configuration
{
    public class AppSettingManager : IAppSettingManager
    {
        private readonly NameValueCollection _appSettings;

        public AppSettingManager()
        {
            _appSettings = ConfigurationManager.AppSettings;
        }

        public string GetConnectionString(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }

        public string GetString(string key)
        {
            return _appSettings[key];
        }

        public bool GetBoolean(string key, bool defaultValue = false)
        {
            string value = _appSettings[key];

            if (value != null)
            {
                bool result;
                if (bool.TryParse(value, out result))
                {
                    return result;
                }
            }

            return defaultValue;
        }

        public int GetInteger(string key, int defaultValue = 0)
        {
            string value = _appSettings[key];

            if (value != null)
            {
                int result;
                if (int.TryParse(value, out result))
                {
                    return result;
                }
            }

            return defaultValue;
        }


        public Guid GetGuid(string key, Guid defaultValue = default(Guid))
        {
            string value = _appSettings[key];

            if (value != null)
            {
                Guid result;
                if (Guid.TryParse(value, out result))
                {
                    return result;
                }
            }

            return defaultValue;
        }

        public TimeSpan GetTime(string key, TimeSpan defaultTime = new TimeSpan())
        {
            string value = _appSettings[key];

            if (value != null)
            {
                try
                {
                    value = value.Trim();
                    var timeVals = value.Split(':');
                    if(timeVals.Length > 3 || timeVals.Length < 2)
                        return defaultTime;

                    int second = 0;
                    if (timeVals.Length == 3)
                        second = int.Parse(timeVals[2]);

                    var hour = int.Parse(timeVals[0]);
                    var minute = int.Parse(timeVals[1]);

                    return new TimeSpan(hour, minute, second);
                }
                catch (Exception)
                {
                    return defaultTime;
                }                
            }

            return defaultTime;
        }
    }
}
