using MVCBlogApp.Application.Repositories.ArticleCategory;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.ArticleCategory
{
    public class ArticleCategoryWriteRepository : WriteRepository<E.ArticleCategory>, IArticleCategoryWriteRepository
    {
        public ArticleCategoryWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
