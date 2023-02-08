using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Repositories.Book
{
    public interface IBookReadRepository : IReadRepository<E.Book>
    {
    }
}
