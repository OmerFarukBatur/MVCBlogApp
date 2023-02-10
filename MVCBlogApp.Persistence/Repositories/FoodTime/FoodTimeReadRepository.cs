using MVCBlogApp.Application.Repositories.FoodTime;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.FoodTime
{
    public class FoodTimeReadRepository : ReadRepository<E.FoodTime>, IFoodTimeReadRepository
    {
        public FoodTimeReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
