using MVCBlogApp.Application.Repositories.FixOptimum;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.FixOptimum
{
    public class FixOptimumWriteRepository : WriteRepository<E.FixOptimum>, IFixOptimumWriteRepository
    {
        public FixOptimumWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
