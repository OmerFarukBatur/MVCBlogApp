using MVCBlogApp.Application.Repositories.WorkshopType;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.WorkshopType
{
    public class WorkshopTypeWriteRepository : WriteRepository<E.WorkshopType>, IWorkshopTypeWriteRepository
    {
        public WorkshopTypeWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
