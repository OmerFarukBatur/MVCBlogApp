using MVCBlogApp.Application.Repositories.OurTeam;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.OurTeam
{
    public class OurTeamReadRepository : ReadRepository<E.OurTeam>, IOurTeamReadRepository
    {
        public OurTeamReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
