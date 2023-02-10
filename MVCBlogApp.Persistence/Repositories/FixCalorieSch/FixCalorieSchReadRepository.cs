using MVCBlogApp.Application.Repositories.FixCalorieSch;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.FixCalorieSch
{
    public class FixCalorieSchReadRepository : ReadRepository<E.FixCalorieSch>, IFixCalorieSchReadRepository
    {
        public FixCalorieSchReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
