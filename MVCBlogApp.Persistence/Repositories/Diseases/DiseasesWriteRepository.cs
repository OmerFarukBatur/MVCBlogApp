using MVCBlogApp.Application.Repositories.Diseases;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Diseases
{
    public class DiseasesWriteRepository : WriteRepository<E.Diseases>, IDiseasesWriteRepository
    {
        public DiseasesWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
