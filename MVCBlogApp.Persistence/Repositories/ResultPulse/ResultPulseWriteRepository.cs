using MVCBlogApp.Application.Repositories.ResultPulse;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.ResultPulse
{
    public class ResultPulseWriteRepository : WriteRepository<E.ResultPulse>, IResultPulseWriteRepository
    {
        public ResultPulseWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
