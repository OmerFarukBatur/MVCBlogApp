using MVCBlogApp.Application.Repositories.Book;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Book
{
    public class BookWriteRepository : WriteRepository<E.Book>, IBookWriteRepository
    {
        public BookWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
