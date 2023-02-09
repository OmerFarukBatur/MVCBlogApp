using MVCBlogApp.Persistence.Contexts;
using MVCBlogApp.Persistence.Repositories;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Repositories.Article
{
    public class ArticleReadRepository : ReadRepository<E.Article>, IArticleReadRepository
    {
        public ArticleReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
