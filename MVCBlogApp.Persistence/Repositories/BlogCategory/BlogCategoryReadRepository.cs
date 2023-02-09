using MVCBlogApp.Application.Repositories.BlogCategory;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.BlogCategory
{
    public class BlogCategoryReadRepository : ReadRepository<E.BlogCategory>, IBlogCategoryReadRepository
    {
        public BlogCategoryReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
