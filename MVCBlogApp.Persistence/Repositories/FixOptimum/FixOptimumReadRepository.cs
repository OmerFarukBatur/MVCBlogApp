using MVCBlogApp.Application.Repositories.FixOptimum;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.FixOptimum
{
    public class FixOptimumReadRepository : ReadRepository<E.FixOptimum>, IFixOptimumReadRepository
    {
        public FixOptimumReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
