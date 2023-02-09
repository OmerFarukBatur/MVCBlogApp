using MVCBlogApp.Application.Repositories.CalcBMI;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.CalcBMI
{
    public class CalcBMIWriteRepository : WriteRepository<E.CalcBMI>, ICalcBMIWriteRepository
    {
        public CalcBMIWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
