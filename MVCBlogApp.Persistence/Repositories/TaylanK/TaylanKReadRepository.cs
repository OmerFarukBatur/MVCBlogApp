using MVCBlogApp.Application.Repositories.TaylanK;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.TaylanK
{
    public class TaylanKReadRepository : ReadRepository<E.TaylanK>, ITaylanKReadRepository
    {
        public TaylanKReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
