using MVCBlogApp.Application.Repositories.CalcOptimum;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.CalcOptimum
{
    public class CalcOptimumReadRepository : ReadRepository<E.CalcOptimum>, ICalcOptimumReadRepository
    {
        public CalcOptimumReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
