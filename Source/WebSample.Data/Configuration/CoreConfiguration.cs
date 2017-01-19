
namespace WebSample.Data.Configuration
{
    public class CoreConfiguration : ICoreConfiguration
    {
        private const string DefaultConnectionStringKey = "MainConnection";
        private const string DefaultCurrencyKey = "DefaultCurrency";
        private const string MoneyFormatTypeKey = "MoneyFormatType";
        private const string DateTimeFormatStringKey = "DateTimeFormatString";

        private readonly IAppSettingManager _appSettingManager;


        public CoreConfiguration(IAppSettingManager appSettingManager)
        {
            _appSettingManager = appSettingManager;
            Initialize();
        }

        private void Initialize()
        {
            ConnectionString = _appSettingManager.GetConnectionString(DefaultConnectionStringKey);
            DefaultCurrency = _appSettingManager.GetString(DefaultCurrencyKey);
            MoneyFormatType = _appSettingManager.GetInteger(MoneyFormatTypeKey);
            DateTimeFormatString = _appSettingManager.GetString(DateTimeFormatStringKey);
            DateTimeFormatString = string.IsNullOrWhiteSpace(DateTimeFormatString) ? "MM/dd/yyyy" : DateTimeFormatString;
        }

        public string DefaultCurrency { private set; get; }

        public string ConnectionString { private set; get; }        

        public static int MoneyFormatType { private set; get; }

        public static string DateTimeFormatString { private set; get; }
    }
}
