using MVCBlogApp.Application.Repositories.FixFeedPyramid;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.FixFeedPyramid
{
    public class FixFeedPyramidWriteRepository : WriteRepository<E.FixFeedPyramid>, IFixFeedPyramidWriteRepository
    {
        public FixFeedPyramidWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
