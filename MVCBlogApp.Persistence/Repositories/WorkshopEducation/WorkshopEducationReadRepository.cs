using MVCBlogApp.Application.Repositories.WorkshopEducation;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.WorkshopEducation
{
    public class WorkshopEducationReadRepository : ReadRepository<E.WorkshopEducation>, IWorkshopEducationReadRepository
    {
        public WorkshopEducationReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
