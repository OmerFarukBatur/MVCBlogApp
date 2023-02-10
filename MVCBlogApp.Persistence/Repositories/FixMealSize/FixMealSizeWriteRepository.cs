using MVCBlogApp.Application.Repositories.FixMealSize;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.FixMealSize
{
    public class FixMealSizeWriteRepository : WriteRepository<E.FixMealSize>, IFixMealSizeWriteRepository
    {
        public FixMealSizeWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
