using MVCBlogApp.Application.Repositories.ImageCarousel;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.ImageCarousel
{
    public class ImageCarouselWriteRepository : WriteRepository<E.ImageCarousel>, IImageCarouselWriteRepository
    {
        public ImageCarouselWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
