using MVCBlogApp.Application.Repositories.DiseasesDigestiveDisorders;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.DiseasesDigestiveDisorders
{
    public class DiseasesDigestiveDisordersWriteRepository : WriteRepository<E.DiseasesDigestiveDisorders>, IDiseasesDigestiveDisordersWriteRepository
    {
        public DiseasesDigestiveDisordersWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
