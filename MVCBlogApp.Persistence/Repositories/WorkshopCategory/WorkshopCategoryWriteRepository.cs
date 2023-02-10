using MVCBlogApp.Application.Repositories.WorkshopCategory;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.WorkshopCategory
{
    public class WorkshopCategoryWriteRepository : WriteRepository<E.WorkshopCategory>, IWorkshopCategoryWriteRepository
    {
        public WorkshopCategoryWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
