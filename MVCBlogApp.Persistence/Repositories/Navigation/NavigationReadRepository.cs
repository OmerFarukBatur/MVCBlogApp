using MVCBlogApp.Application.Repositories.Navigation;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Navigation
{
    public class NavigationReadRepository : ReadRepository<E.Navigation>, INavigationReadRepository
    {
        public NavigationReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
