using MVCBlogApp.Application.Repositories.HearAboutUS;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.HearAboutUS
{
    public class HearAboutUSWriteRepository : WriteRepository<E.HearAboutUS>, IHearAboutUSWriteRepository
    {
        public HearAboutUSWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
