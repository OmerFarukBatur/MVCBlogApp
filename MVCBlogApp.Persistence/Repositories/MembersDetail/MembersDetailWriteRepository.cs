using MVCBlogApp.Application.Repositories.MembersDetail;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.MembersDetail
{
    public class MembersDetailWriteRepository : WriteRepository<E.MembersDetail>, IMembersDetailWriteRepository
    {
        public MembersDetailWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
