using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using UrlShortener.Domain;

namespace UrlShortener.Persistance.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<EncyptedUrl> EncyptedUrls { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
