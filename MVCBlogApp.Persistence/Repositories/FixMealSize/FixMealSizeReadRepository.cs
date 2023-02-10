using MVCBlogApp.Application.Repositories.FixMealSize;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.FixMealSize
{
    public class FixMealSizeReadRepository : ReadRepository<E.FixMealSize>, IFixMealSizeReadRepository
    {
        public FixMealSizeReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
