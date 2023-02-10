using MVCBlogApp.Application.Repositories.SeminarVisuals;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.SeminarVisuals
{
    public class SeminarVisualsWriteRepository : WriteRepository<E.SeminarVisuals>, ISeminarVisualsWriteRepository
    {
        public SeminarVisualsWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
