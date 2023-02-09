using MVCBlogApp.Application.Repositories.FemaleMentalState;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.FemaleMentalState
{
    public class FemaleMentalStateWriteRepository : WriteRepository<E.FemaleMentalState>, IFemaleMentalStateWriteRepository
    {
        public FemaleMentalStateWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
