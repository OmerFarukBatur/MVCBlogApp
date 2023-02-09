using MVCBlogApp.Application.Repositories.Case;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Case
{
    public class CaseWriteRepository : WriteRepository<E.Case>, ICaseWriteRepository
    {
        public CaseWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
