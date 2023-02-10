using MVCBlogApp.Application.Repositories.OurTeam;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.OurTeam
{
    public class OurTeamWriteRepository : WriteRepository<E.OurTeam>, IOurTeamWriteRepository
    {
        public OurTeamWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
