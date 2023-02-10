using MVCBlogApp.Application.Repositories.WorkshopEducation;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.WorkshopEducation
{
    public class WorkshopEducationWriteRepository : WriteRepository<E.WorkshopEducation>, IWorkshopEducationWriteRepository
    {
        public WorkshopEducationWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
