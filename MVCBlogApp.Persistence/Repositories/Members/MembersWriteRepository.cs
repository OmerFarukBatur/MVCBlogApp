using MVCBlogApp.Application.Repositories.Members;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Members
{
    public class MembersWriteRepository : WriteRepository<E.Members>, IMembersWriteRepository
    {
        public MembersWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
