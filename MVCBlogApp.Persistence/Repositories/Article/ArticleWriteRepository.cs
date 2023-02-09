using MVCBlogApp.Application.Repositories.Article;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Article
{
    public class ArticleWriteRepository : WriteRepository<E.Article>, IArticleWriteRepository
    {
        public ArticleWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
