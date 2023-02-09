using MVCBlogApp.Application.Repositories.DiseasesDigestiveDisorders;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.DiseasesDigestiveDisorders
{
    public class DiseasesDigestiveDisordersReadRepository : ReadRepository<E.DiseasesDigestiveDisorders>, IDiseasesDigestiveDisordersReadRepository
    {
        public DiseasesDigestiveDisordersReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
