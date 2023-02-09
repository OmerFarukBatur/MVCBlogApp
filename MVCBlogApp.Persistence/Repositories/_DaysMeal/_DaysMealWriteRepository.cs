using MVCBlogApp.Application.Repositories._DaysMeal;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories._DaysMeal
{
    public class _DaysMealWriteRepository : WriteRepository<E._DaysMeal>, I_DaysMealWriteRepository
    {
        public _DaysMealWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
