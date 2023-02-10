using MVCBlogApp.Application.Repositories.PressType;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.PressType
{
    public class PressTypeWriteRepository : WriteRepository<E.PressType>, IPressTypeWriteRepository
    {
        public PressTypeWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
