using MVCBlogApp.Application.Repositories.DiseasesCardiovascular;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.DiseasesCardiovascular
{
    public class DiseasesCardiovascularWriteRepository : WriteRepository<E.DiseasesCardiovascular>, IDiseasesCardiovascularWriteRepository
    {
        public DiseasesCardiovascularWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
