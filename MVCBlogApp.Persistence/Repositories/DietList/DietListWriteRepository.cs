using MVCBlogApp.Application.Repositories.DietList;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.DietList
{
    public class DietListWriteRepository : WriteRepository<E.DietList>, IDietListWriteRepository
    {
        public DietListWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
