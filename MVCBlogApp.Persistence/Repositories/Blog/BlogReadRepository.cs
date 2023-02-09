using MVCBlogApp.Application.Repositories.Blog;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Blog
{
    public class BlogReadRepository : ReadRepository<E.Blog>, IBlogReadRepository
    {
        public BlogReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
