using MVCBlogApp.Application.Repositories.Workshop;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Workshop
{
    public class WorkshopReadRepository : ReadRepository<E.Workshop>, IWorkshopReadRepository
    {
        public WorkshopReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
