using MVCBlogApp.Application.Repositories.X_BookCategory;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.X_BookCategory
{
    public class X_BookCategoryReadRepository : ReadRepository<E.X_BookCategory>, IX_BookCategoryReadRepository
    {
        public X_BookCategoryReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
