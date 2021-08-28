using System.Collections.Generic;
using System.Threading.Tasks;
using UrlShortener.Domain;

namespace UrlShortener.Repositories.Interfaces
{
    public interface IEncryptedUrlRepository
    {
        Task<List<EncyptedUrl>> GetAsync();

        Task<EncyptedUrl> GetAsync(string encryptedUrl);

        Task<string> AddAsync(EncyptedUrl encryptedUrl);
    }
}
