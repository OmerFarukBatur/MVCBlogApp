using MVCBlogApp.Application.Repositories.Carousel;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.Carousel
{
    public class CarouselWriteRepository : WriteRepository<E.Carousel>, ICarouselWriteRepository
    {
        public CarouselWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
