using MVCBlogApp.Application.Repositories.Days;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Days
{
    public class DaysWriteRepository : WriteRepository<E.Days>, IDaysWriteRepository
    {
        public DaysWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
