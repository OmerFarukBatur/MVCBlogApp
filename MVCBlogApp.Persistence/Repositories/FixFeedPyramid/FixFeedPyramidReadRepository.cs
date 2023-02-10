using MVCBlogApp.Application.Repositories.FixFeedPyramid;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.FixFeedPyramid
{
    public class FixFeedPyramidReadRepository : ReadRepository<E.FixFeedPyramid>, IFixFeedPyramidReadRepository
    {
        public FixFeedPyramidReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
