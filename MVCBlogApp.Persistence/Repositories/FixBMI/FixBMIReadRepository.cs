using MVCBlogApp.Application.Repositories.FixBMI;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.FixBMI
{
    public class FixBMIReadRepository : ReadRepository<E.FixBMI>, IFixBMIReadRepository
    {
        public FixBMIReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
