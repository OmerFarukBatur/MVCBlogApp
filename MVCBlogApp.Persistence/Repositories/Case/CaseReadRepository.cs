using MVCBlogApp.Application.Repositories.Case;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Case
{
    public class CaseReadRepository : ReadRepository<E.Case>, ICaseReadRepository
    {
        public CaseReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
