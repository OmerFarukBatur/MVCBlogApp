using MVCBlogApp.Application.Repositories.ResultBMh;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.ResultBMh
{
    public class ResultBMhReadRepository : ReadRepository<E.ResultBMh>, IResultBMhReadRepository
    {
        public ResultBMhReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
