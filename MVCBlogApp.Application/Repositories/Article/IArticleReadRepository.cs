using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Repositories.Article
{
    public interface IArticleReadRepository : IReadRepository<E.Article>
    {
    }
}
