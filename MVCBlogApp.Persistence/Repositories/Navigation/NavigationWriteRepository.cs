using MVCBlogApp.Application.Repositories.Navigation;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Navigation
{
    public class NavigationWriteRepository : WriteRepository<E.Navigation>, INavigationWriteRepository
    {
        public NavigationWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
