using MVCBlogApp.Application.Repositories.ImageCarousel;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.ImageCarousel
{
    public class ImageCarouselReadRepository : ReadRepository<E.ImageCarousel>, IImageCarouselReadRepository
    {
        public ImageCarouselReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
