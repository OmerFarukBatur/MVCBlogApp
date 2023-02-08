using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Repositories.Blog
{
    public interface IBlogWriteRepository : IWriteRepository<E.Blog>
    {
    }
}
