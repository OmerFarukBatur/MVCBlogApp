using MVCBlogApp.Application.Repositories.DietList;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.DietList
{
    public class DietListReadRepository : ReadRepository<E.DietList>, IDietListReadRepository
    {
        public DietListReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
