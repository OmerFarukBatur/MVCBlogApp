using MVCBlogApp.Application.Repositories.User;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.User
{
    public class UserReadRepository : ReadRepository<E.User>, IUserReadRepository
    {
        public UserReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
