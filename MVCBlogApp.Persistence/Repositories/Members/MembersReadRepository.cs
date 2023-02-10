using MVCBlogApp.Application.Repositories.Members;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Members
{
    public class MembersReadRepository : ReadRepository<E.Members>, IMembersReadRepository
    {
        public MembersReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
