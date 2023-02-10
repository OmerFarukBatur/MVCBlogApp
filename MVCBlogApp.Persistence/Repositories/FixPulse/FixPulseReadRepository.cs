using MVCBlogApp.Application.Repositories.FixPulse;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.FixPulse
{
    public class FixPulseReadRepository : ReadRepository<E.FixPulse>, IFixPulseReadRepository
    {
        public FixPulseReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
