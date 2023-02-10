using MVCBlogApp.Application.Repositories.SeminarVisuals;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.SeminarVisuals
{
    public class SeminarVisualsReadRepository : ReadRepository<E.SeminarVisuals>, ISeminarVisualsReadRepository
    {
        public SeminarVisualsReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
