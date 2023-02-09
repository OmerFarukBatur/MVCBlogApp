using MVCBlogApp.Application.Repositories.BlogType;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.BlogType
{
    public class BlogTypeReadRepository : ReadRepository<E.BlogType>, IBlogTypeReadRepository
    {
        public BlogTypeReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
