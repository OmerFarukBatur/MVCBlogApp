using MVCBlogApp.Application.Repositories._DaysMeal;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories._DaysMeal
{
    public class _DaysMealReadRepository : ReadRepository<E._DaysMeal>, I_DaysMealReadRepository
    {
        public _DaysMealReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
