using MVCBlogApp.Application.Repositories.BlogType;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.BlogType
{
    public class BlogTypeWriteRepository : WriteRepository<E.BlogType>, IBlogTypeWriteRepository
    {
        public BlogTypeWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
