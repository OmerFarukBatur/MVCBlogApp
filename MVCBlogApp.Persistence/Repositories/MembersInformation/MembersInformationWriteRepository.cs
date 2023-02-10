using MVCBlogApp.Application.Repositories.MembersInformation;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.MembersInformation
{
    public class MembersInformationWriteRepository : WriteRepository<E.MembersInformation>, IMembersInformationWriteRepository
    {
        public MembersInformationWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
