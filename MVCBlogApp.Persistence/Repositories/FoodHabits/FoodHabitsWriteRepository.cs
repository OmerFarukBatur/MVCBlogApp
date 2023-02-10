using MVCBlogApp.Application.Repositories.FoodHabits;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.FoodHabits
{
    public class FoodHabitsWriteRepository : WriteRepository<E.FoodHabits>, IFoodHabitsWriteRepository
    {
        public FoodHabitsWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
