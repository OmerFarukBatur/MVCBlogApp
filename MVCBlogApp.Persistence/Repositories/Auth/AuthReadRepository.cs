using MVCBlogApp.Application.Repositories.Auth;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Auth
{
    public class AuthReadRepository : ReadRepository<E.Auth>, IAuthReadRepository
    {
        public AuthReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
