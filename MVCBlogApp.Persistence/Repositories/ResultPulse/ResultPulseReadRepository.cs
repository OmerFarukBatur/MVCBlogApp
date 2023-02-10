using MVCBlogApp.Application.Repositories.ResultPulse;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.ResultPulse
{
    public class ResultPulseReadRepository : ReadRepository<E.ResultPulse>, IResultPulseReadRepository
    {
        public ResultPulseReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
