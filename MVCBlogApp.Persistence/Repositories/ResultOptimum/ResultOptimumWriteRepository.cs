using MVCBlogApp.Application.Repositories.ResultOptimum;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.ResultOptimum
{
    public class ResultOptimumWriteRepository : WriteRepository<E.ResultOptimum>, IResultOptimumWriteRepository
    {
        public ResultOptimumWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
