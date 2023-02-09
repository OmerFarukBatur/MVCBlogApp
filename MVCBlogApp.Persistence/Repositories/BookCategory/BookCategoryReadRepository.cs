using MVCBlogApp.Application.Repositories.BookCategory;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.BookCategory
{
    public class BookCategoryReadRepository : ReadRepository<E.BookCategory>, IBookCategoryReadRepository
    {
        public BookCategoryReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
