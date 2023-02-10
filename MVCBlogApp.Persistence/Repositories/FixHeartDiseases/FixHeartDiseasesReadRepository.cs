using MVCBlogApp.Application.Repositories.FixHeartDiseases;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.FixHeartDiseases
{
    public class FixHeartDiseasesReadRepository : ReadRepository<E.FixHeartDiseases>, IFixHeartDiseasesReadRepository
    {
        public FixHeartDiseasesReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
