using MVCBlogApp.Application.Repositories.Press;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Press
{
    public class PressWriteRepository : WriteRepository<E.Press>, IPressWriteRepository
    {
        public PressWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
