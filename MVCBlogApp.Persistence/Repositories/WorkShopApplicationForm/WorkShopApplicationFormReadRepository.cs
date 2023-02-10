using MVCBlogApp.Application.Repositories.WorkShopApplicationForm;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.WorkShopApplicationForm
{
    public class WorkShopApplicationFormReadRepository : ReadRepository<E.WorkShopApplicationForm>, IWorkShopApplicationFormReadRepository
    {
        public WorkShopApplicationFormReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
