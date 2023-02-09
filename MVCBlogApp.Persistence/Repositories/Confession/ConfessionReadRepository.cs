using MVCBlogApp.Application.Repositories.Confession;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Confession
{
    public class ConfessionReadRepository : ReadRepository<E.Confession>, IConfessionReadRepository
    {
        public ConfessionReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
