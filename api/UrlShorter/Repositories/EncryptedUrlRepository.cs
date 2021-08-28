using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Domain;
using UrlShortener.Persistance.Interfaces;
using UrlShortener.Repositories.Interfaces;

namespace UrlShortener.Repositories
{
    public class EncryptedUrlRepository : IEncryptedUrlRepository
    {
        private readonly IApplicationDbContext _dbContext;

        public EncryptedUrlRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<EncyptedUrl>> GetAsync()
        {
            return _dbContext.EncyptedUrls.
                ToListAsync();
        }

        public Task<EncyptedUrl> GetAsync(string encryptedUrl)
        {
            return _dbContext.EncyptedUrls.
                FirstOrDefaultAsync(encUrl => encUrl.EncryptedUrl == encryptedUrl);
        }

        public async Task<string> AddAsync(EncyptedUrl encryptedUrl)
        {
            var existingEntity = await _dbContext.EncyptedUrls.
                FirstOrDefaultAsync(encUrl => encUrl.Url == encryptedUrl.Url);

            if (existingEntity == null)
            {
                await _dbContext.EncyptedUrls.
                    AddAsync(encryptedUrl);
                await _dbContext.SaveChangesAsync();
                return encryptedUrl.EncryptedUrl;
            }

            return null;
        }
    }
}
