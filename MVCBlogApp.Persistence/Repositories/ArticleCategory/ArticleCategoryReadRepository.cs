using MVCBlogApp.Application.Repositories.ArticleCategory;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.ArticleCategory
{
    public class ArticleCategoryReadRepository : ReadRepository<E.ArticleCategory>, IArticleCategoryReadRepository
    {
        public ArticleCategoryReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
