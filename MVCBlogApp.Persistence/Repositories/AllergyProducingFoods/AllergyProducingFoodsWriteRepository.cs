using MVCBlogApp.Application.Repositories.AllergyProducingFoods;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.AllergyProducingFoods
{
    public class AllergyProducingFoodsWriteRepository : WriteRepository<E.AllergyProducingFoods>, IAllergyProducingFoodsWriteRepository
    {
        public AllergyProducingFoodsWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
