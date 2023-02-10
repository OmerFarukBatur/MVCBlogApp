using MVCBlogApp.Application.Repositories.References;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.References
{
    public class ReferencesWriteRepository : WriteRepository<E.References>, IReferencesWriteRepository
    {
        public ReferencesWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
