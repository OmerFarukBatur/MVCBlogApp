using MVCBlogApp.Application.Repositories.ResultBMI;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.ResultBMI
{
    public class ResultBMIReadRepository : ReadRepository<E.ResultBMI>, IResultBMIReadRepository
    {
        public ResultBMIReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
