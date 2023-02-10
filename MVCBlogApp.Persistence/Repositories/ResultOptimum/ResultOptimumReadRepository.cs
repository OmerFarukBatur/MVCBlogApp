using MVCBlogApp.Application.Repositories.ResultOptimum;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.ResultOptimum
{
    public class ResultOptimumReadRepository : ReadRepository<E.ResultOptimum>, IResultOptimumReadRepository
    {
        public ResultOptimumReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
