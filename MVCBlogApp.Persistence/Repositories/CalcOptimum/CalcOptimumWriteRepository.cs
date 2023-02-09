using MVCBlogApp.Application.Repositories.CalcOptimum;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.CalcOptimum
{
    public class CalcOptimumWriteRepository : WriteRepository<E.CalcOptimum>, ICalcOptimumWriteRepository
    {
        public CalcOptimumWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
