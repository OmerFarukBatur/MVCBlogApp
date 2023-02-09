using MVCBlogApp.Application.Repositories.AllergyProducingFoods;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.AllergyProducingFoods
{
    public class AllergyProducingFoodsReadRepository : ReadRepository<E.AllergyProducingFoods>, IAllergyProducingFoodsReadRepository
    {
        public AllergyProducingFoodsReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
