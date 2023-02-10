using MVCBlogApp.Application.Repositories.WorkShopApplicationForm;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.WorkShopApplicationForm
{
    public class WorkShopApplicationFormWriteRepository : WriteRepository<E.WorkShopApplicationForm>, IWorkShopApplicationFormWriteRepository
    {
        public WorkShopApplicationFormWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
