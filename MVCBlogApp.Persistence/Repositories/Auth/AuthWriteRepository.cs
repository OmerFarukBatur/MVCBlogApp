using MVCBlogApp.Application.Repositories.Auth;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Auth
{
    public class AuthWriteRepository : WriteRepository<E.Auth>, IAuthWriteRepository
    {
        public AuthWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
