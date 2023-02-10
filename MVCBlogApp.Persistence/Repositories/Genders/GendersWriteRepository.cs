using MVCBlogApp.Application.Repositories.Genders;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Genders
{
    public class GendersWriteRepository : WriteRepository<E.Genders>, IGendersWriteRepository
    {
        public GendersWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
