using MVCBlogApp.Application.Repositories.Lab;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Lab
{
    public class LabReadRepository : ReadRepository<E.Lab>, ILabReadRepository
    {
        public LabReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
