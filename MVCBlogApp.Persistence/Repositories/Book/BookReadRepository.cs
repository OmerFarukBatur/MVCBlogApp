using MVCBlogApp.Application.Repositories.Book;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Book
{
    public class BookReadRepository : ReadRepository<E.Book>, IBookReadRepository
    {
        public BookReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
