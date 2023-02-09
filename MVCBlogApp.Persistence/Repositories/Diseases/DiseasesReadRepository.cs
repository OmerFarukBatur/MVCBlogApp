using MVCBlogApp.Application.Repositories.Diseases;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Diseases
{
    public class DiseasesReadRepository : ReadRepository<E.Diseases>, IDiseasesReadRepository
    {
        public DiseasesReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
