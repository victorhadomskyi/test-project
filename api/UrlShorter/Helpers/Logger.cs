using UrlShortener.Helpers.Interfaces;

namespace UrlShortener.Helpers
{
    public class Logger : ILogger
    {
        public void LogInfo(string info)
        {
            // Mock method to imitate logging.
            System.Console.WriteLine(info);
        }
    }
}
