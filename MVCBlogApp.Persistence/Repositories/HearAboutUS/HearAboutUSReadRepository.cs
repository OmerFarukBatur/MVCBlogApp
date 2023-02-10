using MVCBlogApp.Application.Repositories.HearAboutUS;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.HearAboutUS
{
    public class HearAboutUSReadRepository : ReadRepository<E.HearAboutUS>, IHearAboutUSReadRepository
    {
        public HearAboutUSReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
