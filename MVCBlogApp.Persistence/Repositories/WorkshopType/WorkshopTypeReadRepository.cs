using MVCBlogApp.Application.Repositories.WorkshopType;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.WorkshopType
{
    public class WorkshopTypeReadRepository : ReadRepository<E.WorkshopType>, IWorkshopTypeReadRepository
    {
        public WorkshopTypeReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
