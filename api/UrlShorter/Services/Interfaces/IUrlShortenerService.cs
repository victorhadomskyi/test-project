using System.Collections.Generic;
using System.Threading.Tasks;
using UrlShortener.Models;

namespace UrlShortener.Services.Interfaces
{
    public interface IUrlShortenerService
    {
        Task<Response<List<string>>> GetAsync();

        Task<Response<string>> GetAsync(string encryptedUrl);

        Task<Response<string>> AddEncodedUrlAsync(string url, string baseUrl);
    }
}
