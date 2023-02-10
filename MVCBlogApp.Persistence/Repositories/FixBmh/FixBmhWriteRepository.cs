using MVCBlogApp.Application.Repositories.FixBmh;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.FixBmh
{
    public class FixBmhWriteRepository : WriteRepository<E.FixBmh>, IFixBmhWriteRepository
    {
        public FixBmhWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
