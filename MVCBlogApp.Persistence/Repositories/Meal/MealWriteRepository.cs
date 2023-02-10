using MVCBlogApp.Application.Repositories.Meal;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Meal
{
    public class MealWriteRepository : WriteRepository<E.Meal>, IMealWriteRepository
    {
        public MealWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
