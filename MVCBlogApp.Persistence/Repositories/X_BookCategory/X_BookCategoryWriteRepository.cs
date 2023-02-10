using MVCBlogApp.Application.Repositories.X_BookCategory;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.X_BookCategory
{
    public class X_BookCategoryWriteRepository : WriteRepository<E.X_BookCategory>, IX_BookCategoryWriteRepository
    {
        public X_BookCategoryWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
