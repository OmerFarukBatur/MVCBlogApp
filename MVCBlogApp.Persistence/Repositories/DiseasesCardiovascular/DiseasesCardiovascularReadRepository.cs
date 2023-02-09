using MVCBlogApp.Application.Repositories.DiseasesCardiovascular;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.DiseasesCardiovascular
{
    public class DiseasesCardiovascularReadRepository : ReadRepository<E.DiseasesCardiovascular>, IDiseasesCardiovascularReadRepository
    {
        public DiseasesCardiovascularReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
