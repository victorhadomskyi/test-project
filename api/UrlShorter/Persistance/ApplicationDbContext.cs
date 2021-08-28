using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain;
using UrlShortener.Persistance.Interfaces;

namespace UrlShortener.Persistance
{
    public class ApplicationDbContext: DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EncyptedUrl> EncyptedUrls { get; set; }
    }
}
