using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Repositories.Book
{
    public interface IBookWriteRepository : IWriteRepository<E.Book>
    {
    }
}
