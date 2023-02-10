using MVCBlogApp.Application.Repositories.TaylanK;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.TaylanK
{
    public class TaylanKWriteRepository : WriteRepository<E.TaylanK>, ITaylanKWriteRepository
    {
        public TaylanKWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
