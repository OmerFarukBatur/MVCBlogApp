using MVCBlogApp.Application.Repositories.FoodHabitMood;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.FoodHabitMood
{
    public class FoodHabitMoodReadRepository : ReadRepository<E.FoodHabitMood>, IFoodHabitMoodReadRepository
    {
        public FoodHabitMoodReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
