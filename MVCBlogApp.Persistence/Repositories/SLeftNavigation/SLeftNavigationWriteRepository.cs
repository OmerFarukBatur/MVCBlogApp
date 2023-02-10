using MVCBlogApp.Application.Repositories.SLeftNavigation;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.SLeftNavigation
{
    public class SLeftNavigationWriteRepository : WriteRepository<E.SLeftNavigation>, ISLeftNavigationWriteRepository
    {
        public SLeftNavigationWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
