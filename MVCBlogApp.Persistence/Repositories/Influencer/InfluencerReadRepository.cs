using MVCBlogApp.Application.Repositories.Influencer;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Influencer
{
    public class InfluencerReadRepository : ReadRepository<E.Influencer>, IInfluencerReadRepository
    {
        public InfluencerReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
