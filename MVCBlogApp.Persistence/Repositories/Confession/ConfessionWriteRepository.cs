using MVCBlogApp.Application.Repositories.Confession;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Confession
{
    public class ConfessionWriteRepository : WriteRepository<E.Confession>, IConfessionWriteRepository
    {
        public ConfessionWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
