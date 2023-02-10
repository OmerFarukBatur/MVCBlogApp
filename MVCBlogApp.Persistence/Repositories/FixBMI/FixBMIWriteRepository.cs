using MVCBlogApp.Application.Repositories.FixBMI;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.FixBMI
{
    public class FixBMIWriteRepository : WriteRepository<E.FixBMI>, IFixBMIWriteRepository
    {
        public FixBMIWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
