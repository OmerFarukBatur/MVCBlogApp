using MVCBlogApp.Application.Repositories.BlogCategory;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.BlogCategory
{
    public class BlogCategoryWriteRepository : WriteRepository<E.BlogCategory>, IBlogCategoryWriteRepository
    {
        public BlogCategoryWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
