using MVCBlogApp.Application.Repositories.PressType;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.PressType
{
    public class PressTypeReadRepository : ReadRepository<E.PressType>, IPressTypeReadRepository
    {
        public PressTypeReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
