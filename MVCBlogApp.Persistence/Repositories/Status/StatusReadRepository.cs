using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Status
{
    public class StatusReadRepository : ReadRepository<E.Status>, IStatusReadRepository
    {
        public StatusReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
