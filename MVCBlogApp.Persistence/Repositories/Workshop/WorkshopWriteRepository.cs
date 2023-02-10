using MVCBlogApp.Application.Repositories.Workshop;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Workshop
{
    public class WorkshopWriteRepository : WriteRepository<E.Workshop>, IWorkshopWriteRepository
    {
        public WorkshopWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
