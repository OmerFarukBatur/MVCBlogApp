using MVCBlogApp.Application.Repositories.Meal;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Meal
{
    public class MealReadRepository : ReadRepository<E.Meal>, IMealReadRepository
    {
        public MealReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
