using MVCBlogApp.Application.Repositories.X_BlogCategory;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.X_BlogCategory
{
    public class X_BlogCategoryReadRepository : ReadRepository<E.X_BlogCategory>, IX_BlogCategoryReadRepository
    {
        public X_BlogCategoryReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
