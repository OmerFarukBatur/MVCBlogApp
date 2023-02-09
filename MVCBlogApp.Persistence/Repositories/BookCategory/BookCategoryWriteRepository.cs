using MVCBlogApp.Application.Repositories.BookCategory;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.BookCategory
{
    public class BookCategoryWriteRepository : WriteRepository<E.BookCategory>, IBookCategoryWriteRepository
    {
        public BookCategoryWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
