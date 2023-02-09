using MVCBlogApp.Application.Repositories.CalcBmh;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.CalcBmh
{
    public class CalcBmhReadRepository : ReadRepository<E.CalcBmh>, ICalcBmhReadRepository
    {
        public CalcBmhReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
