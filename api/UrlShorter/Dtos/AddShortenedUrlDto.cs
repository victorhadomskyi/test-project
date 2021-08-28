using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Dtos
{
    public class AddShortenedUrlDto
    {
        [Url]
        [Required]
        public string Url { get; set; }
    }
}
