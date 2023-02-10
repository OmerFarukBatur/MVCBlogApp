using MVCBlogApp.Application.Repositories.Influencer;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Influencer
{
    public class InfluencerWriteRepository : WriteRepository<E.Influencer>, IInfluencerWriteRepository
    {
        public InfluencerWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
