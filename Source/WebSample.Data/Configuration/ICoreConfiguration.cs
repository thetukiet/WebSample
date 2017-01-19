
namespace WebSample.Data.Configuration
{
    public interface ICoreConfiguration
    {
        string DefaultCurrency { get; }

        string ConnectionString { get; }
    }
}
