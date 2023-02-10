using MVCBlogApp.Application.Repositories.MasterRoot;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.MasterRoot
{
    public class MasterRootWriteRepository : WriteRepository<E.MasterRoot>, IMasterRootWriteRepository
    {
        public MasterRootWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
