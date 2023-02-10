using MVCBlogApp.Application.Repositories.FixBmh;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.FixBmh
{
    public class FixBmhReadRepository : ReadRepository<E.FixBmh>, IFixBmhReadRepository
    {
        public FixBmhReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
