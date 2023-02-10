using MVCBlogApp.Application.Repositories.MembersAuth;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.MembersAuth
{
    public class MembersAuthWriteRepository : WriteRepository<E.MembersAuth>, IMembersAuthWriteRepository
    {
        public MembersAuthWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
