using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Domain
{
    public class EncyptedUrl
    {
        [Key]
        public int UrlId { get; set; }
        public string EncryptedUrl { get; set; }
        public string Url { get; set; }
    }
}
