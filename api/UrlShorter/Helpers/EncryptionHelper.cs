using UrlShortener.Helpers.Interfaces;

namespace UrlShortener.Helpers
{
    public class EncryptionHelper : IEncryptionHelper
    {
        public string EncryptUrl(string url)
        {
            return url.GetHashCode().ToString();
        }
    }
}
