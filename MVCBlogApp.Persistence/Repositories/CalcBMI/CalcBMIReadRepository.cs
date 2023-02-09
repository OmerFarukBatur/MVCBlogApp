using MVCBlogApp.Application.Repositories.CalcBMI;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.CalcBMI
{
    public class CalcBMIReadRepository : ReadRepository<E.CalcBMI>, ICalcBMIReadRepository
    {
        public CalcBMIReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
