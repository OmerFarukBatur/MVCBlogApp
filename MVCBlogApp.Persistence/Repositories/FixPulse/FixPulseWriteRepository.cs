using MVCBlogApp.Application.Repositories.FixPulse;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.FixPulse
{
    public class FixPulseWriteRepository : WriteRepository<E.FixPulse>, IFixPulseWriteRepository
    {
        public FixPulseWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
