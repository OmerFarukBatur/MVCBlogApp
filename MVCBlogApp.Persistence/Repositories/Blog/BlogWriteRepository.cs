using MVCBlogApp.Application.Repositories.Blog;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Blog
{
    public class BlogWriteRepository : WriteRepository<E.Blog>, IBlogWriteRepository
    {
        public BlogWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
