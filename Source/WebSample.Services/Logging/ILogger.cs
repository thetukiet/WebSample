
namespace WebSample.Services.Logging
{
    public interface ILogger
    {
        void Error(object sender, string message);
        void Info(object sender, string message);
        void Debug(object sender, string message);
    }
}
