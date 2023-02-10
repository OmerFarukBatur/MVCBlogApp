using MVCBlogApp.Application.Repositories.MasterRoot;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.MasterRoot
{
    public class MasterRootReadRepository : ReadRepository<E.MasterRoot>, IMasterRootReadRepository
    {
        public MasterRootReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
