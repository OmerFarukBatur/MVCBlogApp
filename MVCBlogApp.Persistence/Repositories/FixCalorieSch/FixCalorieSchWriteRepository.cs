using MVCBlogApp.Application.Repositories.FixCalorieSch;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.FixCalorieSch
{
    public class FixCalorieSchWriteRepository : WriteRepository<E.FixCalorieSch>, IFixCalorieSchWriteRepository
    {
        public FixCalorieSchWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
