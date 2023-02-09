using MVCBlogApp.Application.Repositories.CalcPulse;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.CalcPulse
{
    public class CalcPulseReadRepository : ReadRepository<E.CalcPulse>, ICalcPulseReadRepository
    {
        public CalcPulseReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
