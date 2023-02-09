using MVCBlogApp.Application.Repositories.Banner;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Banner
{
    public class BannerWriteRepository : WriteRepository<E.Banner>, IBannerWriteRepository
    {
        public BannerWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
