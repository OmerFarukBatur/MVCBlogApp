using MVCBlogApp.Application.Repositories.ResultBMI;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.ResultBMI
{
    public class ResultBMIWriteRepository : WriteRepository<E.ResultBMI>, IResultBMIWriteRepository
    {
        public ResultBMIWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
