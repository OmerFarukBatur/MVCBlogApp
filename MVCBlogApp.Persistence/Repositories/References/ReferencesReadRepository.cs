using MVCBlogApp.Application.Repositories.References;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.References
{
    public class ReferencesReadRepository : ReadRepository<E.References>, IReferencesReadRepository
    {
        public ReferencesReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
