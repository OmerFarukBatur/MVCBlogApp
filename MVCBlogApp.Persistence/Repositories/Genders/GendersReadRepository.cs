using MVCBlogApp.Application.Repositories.Genders;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Genders
{
    public class GendersReadRepository : ReadRepository<E.Genders>, IGendersReadRepository
    {
        public GendersReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
