using MVCBlogApp.Application.Repositories.SLeftNavigation;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.SLeftNavigation
{
    public class SLeftNavigationReadRepository : ReadRepository<E.SLeftNavigation>, ISLeftNavigationReadRepository
    {
        public SLeftNavigationReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
