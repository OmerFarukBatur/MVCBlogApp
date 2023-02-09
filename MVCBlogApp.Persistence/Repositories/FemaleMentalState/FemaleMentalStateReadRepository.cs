using MVCBlogApp.Application.Repositories.FemaleMentalState;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.FemaleMentalState
{
    public class FemaleMentalStateReadRepository : ReadRepository<E.FemaleMentalState>, IFemaleMentalStateReadRepository
    {
        public FemaleMentalStateReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
