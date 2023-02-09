using MVCBlogApp.Application.Repositories.CalcPulse;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.CalcPulse
{
    public class CalcPulseWriteRepository : WriteRepository<E.CalcPulse>, ICalcPulseWriteRepository
    {
        public CalcPulseWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
