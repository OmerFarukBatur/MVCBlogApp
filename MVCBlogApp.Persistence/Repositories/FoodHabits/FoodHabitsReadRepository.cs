using MVCBlogApp.Application.Repositories.FoodHabits;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.FoodHabits
{
    public class FoodHabitsReadRepository : ReadRepository<E.FoodHabits>, IFoodHabitsReadRepository
    {
        public FoodHabitsReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
