using MVCBlogApp.Application.Repositories.X_BlogCategory;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.X_BlogCategory
{
    public class X_BlogCategoryWriteRepository : WriteRepository<E.X_BlogCategory>, IX_BlogCategoryWriteRepository
    {
        public X_BlogCategoryWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
