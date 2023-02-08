using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Repositories.Blog
{
    public interface IBlogReadRepository : IReadRepository<E.Blog>
    {
    }
}
