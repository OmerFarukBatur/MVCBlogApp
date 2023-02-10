using MVCBlogApp.Application.Repositories.Lab;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Lab
{
    public class LabWriteRepository : WriteRepository<E.Lab>, ILabWriteRepository
    {
        public LabWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
