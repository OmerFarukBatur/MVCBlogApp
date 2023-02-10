using MVCBlogApp.Application.Repositories.MembersAuth;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.MembersAuth
{
    public class MembersAuthReadRepository : ReadRepository<E.MembersAuth>, IMembersAuthReadRepository
    {
        public MembersAuthReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
