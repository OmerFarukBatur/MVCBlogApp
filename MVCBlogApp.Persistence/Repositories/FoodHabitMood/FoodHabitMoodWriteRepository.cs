using MVCBlogApp.Application.Repositories.FoodHabitMood;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.FoodHabitMood
{
    public class FoodHabitMoodWriteRepository : WriteRepository<E.FoodHabitMood>, IFoodHabitMoodWriteRepository
    {
        public FoodHabitMoodWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
