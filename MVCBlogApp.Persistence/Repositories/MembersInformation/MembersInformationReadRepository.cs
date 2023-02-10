using MVCBlogApp.Application.Repositories.MembersInformation;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.MembersInformation
{
    public class MembersInformationReadRepository : ReadRepository<E.MembersInformation>, IMembersInformationReadRepository
    {
        public MembersInformationReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
