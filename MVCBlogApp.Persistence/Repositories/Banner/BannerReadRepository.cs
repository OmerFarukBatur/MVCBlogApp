using MVCBlogApp.Application.Repositories.Banner;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Banner
{
    public class BannerReadRepository : ReadRepository<E.Banner>, IBannerReadRepository
    {
        public BannerReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
