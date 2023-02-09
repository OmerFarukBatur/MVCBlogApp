using MVCBlogApp.Application.Repositories.Days;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Days
{
    public class DaysReadRepository : ReadRepository<E.Days>, IDaysReadRepository
    {
        public DaysReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
