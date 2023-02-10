using MVCBlogApp.Application.Repositories.FoodTime;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.FoodTime
{
    public class FoodTimeWriteRepository : WriteRepository<E.FoodTime>, IFoodTimeWriteRepository
    {
        public FoodTimeWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
