using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Repositories.Article
{
    public interface IArticleWriteRepository : IWriteRepository<E.Article>
    {
    }
}
