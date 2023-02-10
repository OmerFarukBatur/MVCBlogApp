using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Status
{
    public class StatusWriteRepository : WriteRepository<E.Status>, IStatusWriteRepository
    {
        public StatusWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
