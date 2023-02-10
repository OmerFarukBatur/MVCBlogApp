using MVCBlogApp.Application.Repositories.MembersDetail;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.MembersDetail
{
    public class MembersDetailReadRepository : ReadRepository<E.MembersDetail>, IMembersDetailReadRepository
    {
        public MembersDetailReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
