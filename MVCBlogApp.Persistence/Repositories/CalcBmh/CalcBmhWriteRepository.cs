using MVCBlogApp.Application.Repositories.CalcBmh;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.CalcBmh
{
    public class CalcBmhWriteRepository : WriteRepository<E.CalcBmh>, ICalcBmhWriteRepository
    {
        public CalcBmhWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
