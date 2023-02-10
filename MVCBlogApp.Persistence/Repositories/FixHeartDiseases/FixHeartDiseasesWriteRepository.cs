using MVCBlogApp.Application.Repositories.FixHeartDiseases;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.FixHeartDiseases
{
    public class FixHeartDiseasesWriteRepository : WriteRepository<E.FixHeartDiseases>, IFixHeartDiseasesWriteRepository
    {
        public FixHeartDiseasesWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
