using MVCBlogApp.Application.Repositories.WorkshopCategory;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.WorkshopCategory
{
    public class WorkshopCategoryReadRepository : ReadRepository<E.WorkshopCategory>, IWorkshopCategoryReadRepository
    {
        public WorkshopCategoryReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
