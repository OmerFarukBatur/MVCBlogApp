using MVCBlogApp.Application.Repositories.User;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.User
{
    public class UserWriteRepository : WriteRepository<E.User>, IUserWriteRepository
    {
        public UserWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
