using MVCBlogApp.Application.Repositories.ResultBMh;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.ResultBMh
{
    public class ResultBMhWriteRepository : WriteRepository<E.ResultBmh>, IResultBMhWriteRepository
    {
        public ResultBMhWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
